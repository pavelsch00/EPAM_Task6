using Microsoft.Office.Interop.Excel;
using Students.Enums;
using Students.Objects;
using Students.Reports;
using Students.WorkWithORM;
using System;
using System.Collections.Generic;

namespace Test
{
    class Program
    {
        static void Main()
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudentsDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            /*
            StudentDBContext studentDBContext = new StudentDBContext(connectionString);
            var student = new Student()
            {
                FullName = "Saladuhin Pavel Viktorovich",
                Gender = "Male",
                DateOfBirth = new DateTime(1999, 01, 25),
                GroupId = 1
            };

            var newStudent = new Student()
            {
                FullName = "Saladuhina Valentina Olegovna",
                Gender = "Woman",
                DateOfBirth = new DateTime(20, 11, 15),
                GroupId = 2
            };
            */
            // studentDBContext.Student.Сhange(31, newStudent);

            /*string path = @"..\..\..\..\..\Students\Resources\Report1.xlsx";
            // SessionResultsGroups.GenerateSessionReport(connectionString);
            var sessionResultsGroups = new GenerationReport(connectionString);
            sessionResultsGroups.GenerationSessionResultReportByGroup(2 , path, 4, SortOrder.Ascending);
            
            // SessionResultsGroups.GetBadStudent(connectionString, 2, XlSortOrder.xlAscending);*/
        }
    }
}
