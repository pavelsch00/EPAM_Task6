using Microsoft.Office.Interop.Excel;
using Students.Reports;

namespace Test
{
    class Program
    {
        static void Main()
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudentsDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            // SessionResultsGroups.GenerateSessionReport(connectionString);
            var sessionResultsGroups = new SessionResultsGroups(connectionString);
            sessionResultsGroups.GenerateSessionReport(4, XlSortOrder.xlAscending);
            
            // SessionResultsGroups.GetBadStudent(connectionString, 2, XlSortOrder.xlAscending);
        }
    }
}
