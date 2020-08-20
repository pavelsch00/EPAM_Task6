using Students;
using Students.Lerns;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ORM
{
    public class Orm
    {
        public Orm(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public string ConnectionString { get; set; }

        public void AddToBd(Student student)
        {

        }

        public List<Student> GetStudentFromBd()
        {
            string sqlExpression = "SELECT * FROM Students";
            var studetns = new List<Student>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        string fullName = (string)reader.GetValue(1);
                        string gender = (string)reader.GetValue(2);
                        DateTime dateOfBirth = DateTime.Parse(reader.GetValue(3).ToString());
                        int groupId = (int)reader.GetValue(4);

                        studetns.Add(new Student(fullName, gender, dateOfBirth.ToShortDateString(), GetGroupFromBd(groupId)));
                    }
                }

                reader.Close();
            }

            return studetns;
        }

        public  Group GetGroupFromBd(int groupId)
        {
            string sqlExpression = "SELECT * FROM Groups";
            var session = new List<Session>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        if((int)reader.GetValue(0) == groupId)
                        {
                            return new Group((string)reader.GetValue(1), GetSessionsFromBd((int)reader.GetValue(2)));
                        }
                    }
                }

                reader.Close();
            }

            return null;
        }

        public List<Session> GetSessionsFromBd(int sessionId)
        {
            string sqlExpression = "SELECT * FROM Sessions";
            var session = new List<Session>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        if ((int)reader.GetValue(0) == sessionId)
                        {
                            session.Add(new Session(sessionId, GetCreditFromBd(sessionId), GetExamsFromBd(sessionId)));
                        }
                    }
                }

                reader.Close();
            }

            return session;
        }

        public List<Exam> GetExamsFromBd(int sessionId)
        {
            string sqlExpression = "SELECT * FROM Exams";
            var exam = new List<Exam>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        if ((int)reader.GetValue(0) == sessionId)
                        {
                            exam.Add(new Exam((string)reader.GetValue(1), (DateTime)reader.GetValue(2), (int)reader.GetValue(3)));
                        }
                    }
                }

                reader.Close();
            }

            return exam;
        }

        public List<Credit> GetCreditFromBd(int sessionId)
        {
            string sqlExpression = "SELECT * FROM Exams";
            var credit = new List<Credit>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        if ((int)reader.GetValue(0) == sessionId)
                        {
                            credit.Add(new Credit((string)reader.GetValue(1), (DateTime)reader.GetValue(2), (int)reader.GetValue(3) == 1 ? true : false));
                        }
                    }
                }

                reader.Close();
            }

            return credit;
        }
    }
}
