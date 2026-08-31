using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AIUBCourseScheduler.Services
{
    public sealed class ExcelCourseRow
    {
        public int ExcelRowNumber { get; init; }

        public string SourceClassId { get; init; } = string.Empty;
        public string Status { get; init; } = string.Empty;
        public int Capacity { get; init; }
        public int EnrolledCount { get; init; }

        public string CourseTitle { get; init; } = string.Empty;
        public string Section { get; init; } = string.Empty;
        public string Faculty { get; init; } = string.Empty;
        public string OfferingType { get; init; } = string.Empty;

        public string MeetingDay { get; init; } = string.Empty;
        public TimeSpan StartTime { get; init; }
        public TimeSpan EndTime { get; init; }

        public string Room { get; init; } = string.Empty;
        public string Department { get; init; } = string.Empty;

        // 3 বা কম seat থাকলে online registration বন্ধ
        public bool IsOnlineRegistrationAvailable =>
            Capacity - EnrolledCount > 3;
    }

    public sealed class ExcelValidationResult
    {
        public string SheetName { get; init; } = string.Empty;
        public string TermName { get; init; } = string.Empty;

        public int TotalRows { get; set; }

        public List<ExcelCourseRow> ValidData { get; } =
            new List<ExcelCourseRow>();

        public List<string> Errors { get; } =
            new List<string>();

        public int ValidRows => ValidData.Count;

        public int InvalidRows =>
            TotalRows - ValidRows;
    }

    public static class ExcelImportService
    {
        private static readonly string[] RequiredHeaders =
        {
            "Class ID",
            "Status",
            "Capacity",
            "Count",
            "Course Title",
            "Section",
            "Faculty",
            "Type",
            "Day",
            "Start Time",
            "End Time",
            "Room",
            "Department"
        };

        private static readonly HashSet<string> ValidDays =
            new HashSet<string>(
                new[]
                {
                    "Sunday",
                    "Monday",
                    "Tuesday",
                    "Wednesday",
                    "Thursday",
                    "Friday",
                    "Saturday"
                },
                StringComparer.OrdinalIgnoreCase
            );

        public static ExcelValidationResult Validate(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath) ||
                !File.Exists(filePath))
            {
                throw new FileNotFoundException(
                    "The selected Excel file was not found."
                );
            }

            using XLWorkbook workbook = new XLWorkbook(filePath);

            IXLWorksheet? worksheet =
                workbook.Worksheets.FirstOrDefault();

            if (worksheet == null)
            {
                throw new InvalidDataException(
                    "The Excel workbook does not contain any worksheet."
                );
            }

            int headerRowNumber = FindHeaderRow(worksheet);

            Dictionary<string, int> headerColumns =
                ReadHeaders(worksheet, headerRowNumber);

            string[] missingHeaders = RequiredHeaders
                .Where(header => !headerColumns.ContainsKey(header))
                .ToArray();

            if (missingHeaders.Length > 0)
            {
                throw new InvalidDataException(
                    "Required columns were not found:\n" +
                    string.Join(", ", missingHeaders)
                );
            }

            ExcelValidationResult result =
                new ExcelValidationResult
                {
                    SheetName = worksheet.Name,
                    TermName = ExtractTermName(worksheet.Name)
                };

            int lastRowNumber =
                worksheet.LastRowUsed()?.RowNumber()
                ?? headerRowNumber;

            for (int rowNumber = headerRowNumber + 1;
                 rowNumber <= lastRowNumber;
                 rowNumber++)
            {
                IXLRow row = worksheet.Row(rowNumber);

                if (IsEmptyRow(row, headerColumns))
                {
                    continue;
                }

                result.TotalRows++;

                if (TryReadRow(
                    row,
                    rowNumber,
                    headerColumns,
                    out ExcelCourseRow? courseRow,
                    out string error))
                {
                    result.ValidData.Add(courseRow!);
                }
                else
                {
                    result.Errors.Add(
                        $"Row {rowNumber}: {error}"
                    );
                }
            }

            return result;
        }

        private static int FindHeaderRow(
            IXLWorksheet worksheet)
        {
            int lastRow =
                worksheet.LastRowUsed()?.RowNumber() ?? 0;

            int rowsToCheck = Math.Min(lastRow, 20);

            for (int rowNumber = 1;
                 rowNumber <= rowsToCheck;
                 rowNumber++)
            {
                Dictionary<string, int> headers =
                    ReadHeaders(worksheet, rowNumber);

                if (headers.ContainsKey("Class ID") &&
                    headers.ContainsKey("Course Title") &&
                    headers.ContainsKey("Section"))
                {
                    return rowNumber;
                }
            }

            throw new InvalidDataException(
                "The Excel header row could not be found."
            );
        }

        private static Dictionary<string, int> ReadHeaders(
            IXLWorksheet worksheet,
            int rowNumber)
        {
            Dictionary<string, int> headers =
                new Dictionary<string, int>(
                    StringComparer.OrdinalIgnoreCase
                );

            int lastColumn =
                worksheet.LastColumnUsed()?.ColumnNumber() ?? 0;

            for (int columnNumber = 1;
                 columnNumber <= lastColumn;
                 columnNumber++)
            {
                string header = worksheet
                    .Cell(rowNumber, columnNumber)
                    .GetFormattedString()
                    .Trim();

                if (!string.IsNullOrWhiteSpace(header))
                {
                    headers[header] = columnNumber;
                }
            }

            return headers;
        }

        private static bool IsEmptyRow(
            IXLRow row,
            Dictionary<string, int> headers)
        {
            return RequiredHeaders.All(header =>
                string.IsNullOrWhiteSpace(
                    GetText(row, headers, header)
                )
            );
        }

        private static bool TryReadRow(
            IXLRow row,
            int rowNumber,
            Dictionary<string, int> headers,
            out ExcelCourseRow? result,
            out string error)
        {
            result = null;
            error = string.Empty;

            string classId =
                GetText(row, headers, "Class ID");

            string status =
                GetText(row, headers, "Status");

            string capacityText =
                GetText(row, headers, "Capacity");

            string countText =
                GetText(row, headers, "Count");

            string rawCourseTitle =
                GetText(row, headers, "Course Title");

            string section =
                GetText(row, headers, "Section");

            string faculty =
                GetText(row, headers, "Faculty");

            string type =
                GetText(row, headers, "Type");

            string day =
                GetText(row, headers, "Day");

            string startTimeText =
                GetText(row, headers, "Start Time");

            string endTimeText =
                GetText(row, headers, "End Time");

            string room =
                GetText(row, headers, "Room");

            string department =
                GetText(row, headers, "Department");

            // Excel-এর schedule না থাকা 15-value row skip
            if (type == "15" ||
                day == "15" ||
                startTimeText == "15" ||
                endTimeText == "15" ||
                room == "15")
            {
                error = "Schedule information is unavailable.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(classId) ||
                string.IsNullOrWhiteSpace(rawCourseTitle) ||
                string.IsNullOrWhiteSpace(section) ||
                string.IsNullOrWhiteSpace(type) ||
                string.IsNullOrWhiteSpace(day) ||
                string.IsNullOrWhiteSpace(room) ||
                string.IsNullOrWhiteSpace(department))
            {
                error = "One or more required values are empty.";
                return false;
            }

            if (!int.TryParse(
                capacityText,
                NumberStyles.Integer,
                CultureInfo.InvariantCulture,
                out int capacity) ||
                capacity <= 0)
            {
                error = "Capacity is not valid.";
                return false;
            }

            if (!int.TryParse(
                countText,
                NumberStyles.Integer,
                CultureInfo.InvariantCulture,
                out int enrolledCount) ||
                enrolledCount < 0 ||
                enrolledCount > capacity)
            {
                error = "Enrolled count is not valid.";
                return false;
            }

            if (!ValidDays.Contains(day))
            {
                error = "Class day is not valid.";
                return false;
            }

            if (!type.Equals(
                    "Theory",
                    StringComparison.OrdinalIgnoreCase) &&
                !type.Equals(
                    "Lab",
                    StringComparison.OrdinalIgnoreCase))
            {
                error = "Course type must be Theory or Lab.";
                return false;
            }

            if (!TryParseTime(startTimeText, out TimeSpan startTime))
            {
                error = "Start time is not valid.";
                return false;
            }

            if (!TryParseTime(endTimeText, out TimeSpan endTime))
            {
                error = "End time is not valid.";
                return false;
            }

            if (endTime <= startTime)
            {
                error = "End time must be after start time.";
                return false;
            }

            string sectionSuffix = $"[{section}]";

            if (!rawCourseTitle.EndsWith(
                sectionSuffix,
                StringComparison.OrdinalIgnoreCase))
            {
                error =
                    "Course title section does not match Section column.";
                return false;
            }

            string cleanCourseTitle = rawCourseTitle
                .Substring(
                    0,
                    rawCourseTitle.Length - sectionSuffix.Length
                )
                .Trim();

            result = new ExcelCourseRow
            {
                ExcelRowNumber = rowNumber,
                SourceClassId = classId,
                Status = status,
                Capacity = capacity,
                EnrolledCount = enrolledCount,
                CourseTitle = cleanCourseTitle,
                Section = section,
                Faculty = faculty,
                OfferingType = type,
                MeetingDay = day,
                StartTime = startTime,
                EndTime = endTime,
                Room = room,
                Department = department
            };

            return true;
        }

        private static string GetText(
            IXLRow row,
            Dictionary<string, int> headers,
            string header)
        {
            return row
                .Cell(headers[header])
                .GetFormattedString()
                .Trim();
        }

        private static bool TryParseTime(
            string value,
            out TimeSpan time)
        {
            if (DateTime.TryParse(
                value,
                CultureInfo.InvariantCulture,
                DateTimeStyles.NoCurrentDateDefault,
                out DateTime dateTime))
            {
                time = dateTime.TimeOfDay;
                return true;
            }

            time = default;
            return false;
        }

        private static string ExtractTermName(
            string sheetName)
        {
            Match match = Regex.Match(
                sheetName,
                @"(?<year>\d{4}-\d{4})\s*,\s*(?<term>[A-Za-z]+)",
                RegexOptions.IgnoreCase
            );

            if (!match.Success)
            {
                return sheetName.Trim();
            }

            string term = match.Groups["term"].Value;
            string year = match.Groups["year"].Value;

            return $"{term} {year}";
        }
    }
}