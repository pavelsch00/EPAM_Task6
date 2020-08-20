using ORM;
using Students;
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
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudentsDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            /*
            string sqlExpression = "SELECT * FROM Students";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    // выводим названия столбцов
                    Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));

                    while (reader.Read()) // построчно считываем данные
                    {
                        object id = reader.GetValue(0);
                        object name = reader.GetValue(1);
                        object age = reader.GetValue(2);
                        DateTime ff = DateTime.Parse(reader.GetValue(3).ToString());
                        Console.WriteLine("{0} \t{1} \t{2} \t{3}", id, name, age, ff.ToShortDateString());
                    }
                }

                reader.Close();
            }*/

            Orm orm = new Orm(connectionString);

            List<Student> students = new List<Student>();
            students = orm.GetStudentFromBd();

            foreach (var item in students)
            {
                Console.WriteLine(item);
            }
        }
    }
}
