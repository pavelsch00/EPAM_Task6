using ORM;
using Microsoft.Office.Interop.Excel;
using ORM;
using Students;
using Students.Reports;
using Students.WorkWithCrud;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Task6;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            // SessionResultsGroups.GenerateSessionReport(connectionString);
            var sessionResultsGroups = new SessionResultsGroups(connectionString);
            sessionResultsGroups.GenerateAverageSessionReport(3, XlSortOrder.xlAscending);

            // SessionResultsGroups.GetBadStudent(connectionString, 2, XlSortOrder.xlAscending);
        }
    }
}
