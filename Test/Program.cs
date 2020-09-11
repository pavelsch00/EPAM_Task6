using Microsoft.Office.Interop.Excel;
using Students.Enums;
using Students.Reports;

namespace Test
{
    class Program
    {
        static void Main()
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudentsDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string path = @"..\..\..\..\..\Students\Resources\Report1.xlsx";
            // SessionResultsGroups.GenerateSessionReport(connectionString);
            var sessionResultsGroups = new GenerationReport(connectionString);
            sessionResultsGroups.GenerationSessionResultReportByGroup(path, 4, SortOrder.Ascending);
            
            // SessionResultsGroups.GetBadStudent(connectionString, 2, XlSortOrder.xlAscending);
        }
    }
}
