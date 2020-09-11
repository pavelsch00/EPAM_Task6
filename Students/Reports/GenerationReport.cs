using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Office.Interop.Excel;
using Students.Objects;
using Students.WorkWithORM;

namespace Students.Reports
{
    public class GenerationReport
    {
        public GenerationReport(string connectionString)
        {
            StudentDBContext = new StudentDBContext(connectionString);
        }

        public StudentDBContext StudentDBContext { get; set; }

        public void GenerateSessionReport(int sortableSheet, XlSortOrder xlSortOrder)
        {
            Application excelApp = new Application();
            Workbook workBook = excelApp.Workbooks.Add();
            Worksheet workSheet = (Worksheet)workBook.ActiveSheet;

            workSheet.Cells[1, "A"] = "Session";
            workSheet.Cells[1, "B"] = "Group";
            workSheet.Cells[1, "C"] = "Student";
            workSheet.Cells[1, "D"] = "EducationSubject";
            workSheet.Cells[1, "E"] = "Type";
            workSheet.Cells[1, "F"] = "Mark";

            int i = 2;

            foreach (var item in StudentDBContext.StudentResult.Collection)
            {
                workSheet.Cells[i, "A"] = item.SessionEducationalSubject.Session.SessionNumber;
                workSheet.Cells[i, "B"] = item.SessionEducationalSubject.Session.Group.Name;
                workSheet.Cells[i, "C"] = item.Student.FullName;
                workSheet.Cells[i, "D"] = item.SessionEducationalSubject.EducationalSubject.SubjectName;
                workSheet.Cells[i, "E"] = item.SessionEducationalSubject.EducationalSubject.SubjectType;
                workSheet.Cells[i, "F"] = item.Mark;
                i++;
            }

            SortSheet(workSheet, i, sortableSheet, xlSortOrder);

            try
            {
                workBook.Close(true, $"{Environment.CurrentDirectory}" + @"..\..\..\..\..\Students\Resources\Report1.xlsx");
                excelApp.Quit();
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Invalid path to file.");
            }
        }

        public void GenerateAverageSessionReport(int sortableSheet, XlSortOrder xlSortOrder)
        {
            Application excelApp = new Application();
            Workbook workBook = excelApp.Workbooks.Add();
            Worksheet workSheet = (Worksheet)workBook.ActiveSheet;

            workSheet.Cells[1, "A"] = "Session";
            workSheet.Cells[1, "B"] = "Group";
            workSheet.Cells[1, "C"] = "Average Mark";
            workSheet.Cells[1, "D"] = "Min Mark";
            workSheet.Cells[1, "E"] = "Max Mark";

            int i = 2;

            List<int> temp = StudentDBContext.StudentResult.Collection.Select(item => item.SessionEducationalSubject.SessionId).Distinct().ToList();

            foreach (var item in StudentDBContext.StudentResult.Collection)
            {
                if (temp.Where(obj => obj == item?.SessionEducationalSubject?.SessionId).Select(obj => obj).Count() == 1)
                {
                    workSheet.Cells[i, "A"] = item?.SessionEducationalSubject?.Session?.SessionNumber;
                    workSheet.Cells[i, "B"] = item?.SessionEducationalSubject?.Session?.Group.Name;

                    workSheet.Cells[i, "C"] = GetResultStudentForGroup(StudentDBContext.StudentResult.Collection
                        .Where(item => item.SessionEducationalSubject?
                        .EducationalSubject.SubjectType == "Exam")
                        .Select(item => item).ToList(),
                        item.SessionEducationalSubject.SessionId,
                        item.SessionEducationalSubject.Session.GroupId).Average();

                    workSheet.Cells[i, "D"] = GetResultStudentForGroup(StudentDBContext.StudentResult.Collection
                        .Where(item => item.SessionEducationalSubject?
                        .EducationalSubject.SubjectType == "Exam")
                        .Select(item => item).ToList(),
                        item.SessionEducationalSubject.SessionId,
                        item.SessionEducationalSubject.Session.GroupId).Min();

                    workSheet.Cells[i, "E"] = GetResultStudentForGroup(StudentDBContext.StudentResult.Collection
                        .Where(item => item.SessionEducationalSubject?
                        .EducationalSubject.SubjectType == "Exam")
                        .Select(item => item).ToList(),
                        item.SessionEducationalSubject.SessionId,
                        item.SessionEducationalSubject.Session.GroupId).Max();
                    i++;
                    temp.Add(item.SessionEducationalSubject.SessionId);
                }
            }

            SortSheet(workSheet, i, sortableSheet, xlSortOrder);

            try
            {
                workBook.Close(true, $"{Environment.CurrentDirectory}" + @"..\..\..\..\..\Students\Resources\Report2.xlsx");
                excelApp.Quit();
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Invalid path to file.");
            }
        }

        public void GetBadStudent(int sortableSheet, XlSortOrder xlSortOrder)
        {
            Application excelApp = new Application();
            Workbook workBook = excelApp.Workbooks.Add();
            Worksheet workSheet = (Worksheet)workBook.ActiveSheet;

            workSheet.Cells[1, "A"] = "Group";
            workSheet.Cells[1, "B"] = "Student";

            int i = 2;
            int tempMark = 4;

            List<int> temp = StudentDBContext.StudentResult.Collection.Select(item => item.StudentId).Distinct().ToList();

            foreach (var item in StudentDBContext.StudentResult.Collection)
            {
                int.TryParse(item.Mark, out tempMark);
                if (temp.Where(obj => obj == item.StudentId).Select(obj => obj).Count() == 1 &&
                    ((tempMark < 4 && tempMark != 0) || item.Mark == "Not Passed"))
                {
                    workSheet.Cells[i, "A"] = item.SessionEducationalSubject.Session.Group.Name;
                    workSheet.Cells[i, "B"] = item.Student.FullName;
                    temp.Add(item.StudentId);
                    i++;
                }
            
            }

            SortSheet(workSheet, i, sortableSheet, xlSortOrder);

            try
            {
                workBook.Close(true, $"{Environment.CurrentDirectory}" + @"..\..\..\..\..\Students\Resources\Report3.xlsx");
                excelApp.Quit();
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Invalid path to file.");
            }
        }

        private static void SortSheet(Worksheet workSheet, int maxLine, int sortableSheet, XlSortOrder xlSortOrder)
        {
            var rngSort = workSheet.get_Range("A1", $"F{maxLine}");
            rngSort.Sort(rngSort.Columns[sortableSheet, Type.Missing], xlSortOrder,
            null, Type.Missing, XlSortOrder.xlAscending,
            Type.Missing, XlSortOrder.xlAscending,
            XlYesNoGuess.xlYes, Type.Missing, Type.Missing,
            XlSortOrientation.xlSortColumns);
        }

        private static List<double> GetResultStudentForGroup(List<StudentResult> listStudentResults, int sessionId, int groupId)
        {
            return listStudentResults.Where(item => item.SessionEducationalSubject.SessionId == sessionId 
            && item.SessionEducationalSubject.Session.GroupId == groupId)
                .Select(item => double.Parse(item.Mark)).ToList();
        }
    }
}
