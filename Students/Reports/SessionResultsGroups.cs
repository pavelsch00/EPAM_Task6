using System;
using System.Collections.Generic;
using System.Text;
using IronXL;

namespace Students.Reports
{
    public class SessionResultsGroups
    {
        public static void GenerateSessionReport(int sessionNumber, string filePath)
        {
            /*CustomORM orm = CustomORM.Instance;
            List<Session> sessions = orm.Sessions.Where(obj => obj.SemesterNumber == sessionNumber).ToList();

            foreach (Session session in sessions)
            {
                session.Group = orm.Groups.First(obj => obj.ID == session.GroupID);
                session.Group.Students = orm.Students.Where(obj => obj.GroupID == session.GroupID).ToList();

                foreach (Student student in session.Group.Students)
                {
                    student.ExamResults = orm.ExamResults.Where(obj => obj.StudentID == student.ID).ToList();
                }
            }

            var fileXLSX = WorkBook.Create(ExcelFileFormat.XLSX);
            fileXLSX.Metadata.Title = "IronXL New File";
            var workSheet = fileXLSX.CreateWorkSheet("SessionReport");

            workSheet["A1"].Value = nameof(Session);
            workSheet["B1"].Value = nameof(Group);
            workSheet["C1"].Value = "Average Mark";

            int cellNumber = 2;

            foreach (Session session in sessions)
            {
                workSheet[$"A{cellNumber}"].Value = session.SemesterNumber;
                workSheet[$"B{cellNumber}"].Value = session.Group.Name;
                workSheet[$"C{cellNumber}"].Value = GetAverageMarkForGroup(session.Group);
            }

            fileXLSX.SaveAs(filePath);*/
        }
    }
}
