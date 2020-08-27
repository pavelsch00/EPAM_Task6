using Students;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ORM
{
    public class GetFromDb : BaseOrm
    {
        private const string _sqlExpressionGetStudent = "SELECT * FROM Students s" +
                " JOIN Groups gr ON s.GroupId = gr.Id";

        public GetFromDb(string connectionString) : base(connectionString)
        {
        }

        private int StudentId { get; set; }

        private int SessionId { get; set; }

        public List<Student> GetStudents()
        {
            var studetns = new List<Student>();

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlDataReader reader = new SqlCommand(_sqlExpressionGetStudent, connection).ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())

                    {
                        StudentId = (int)reader["Id"];
                        object fullName = reader["FullName"];
                        string gender = (string)reader["Gender"];
                        DateTime dateOfBirth = DateTime.Parse(reader["DateOfBirth"].ToString());
                        string group = (string)reader["GroupName"];
                        int groupId = (int)reader["GroupId"];

                        studetns.Add(new Student((string)fullName, gender, dateOfBirth.ToString()));
                    }
                }

                reader.Close();
            }

            return studetns;
        }

        public List<Session> GetSessions(int groupId)
        {
            string sqlExpression = $"SELECT * FROM Sessions s WHERE s.GroupId = {groupId}";
            var sessions = new List<Session>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlDataReader reader = new SqlCommand(sqlExpression, connection).ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SessionId = (int)reader["Id"];
                        sessions.Add(new Session((int)reader["SessionNumber"]));
                    }
                }

                reader.Close();
            }

            return sessions;
        }

        public List<EducationalSubject> GetEducationalSubjects(int groupId, int sessionId)
        {
            string sqlExpression = $"SELECT * FROM EducationalSubjects es" +
                $" JOIN Sessions gs ON es.Id = gs.Id AND gs.GroupId = {groupId} AND gs.Id = {sessionId}";
            var educationalSubjects = new List<EducationalSubject>();

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlDataReader reader = new SqlCommand(sqlExpression, connection).ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        educationalSubjects.Add(new EducationalSubject((string)reader["SubjectName"], DateTime.Parse(reader["Date"].ToString()), (string)reader["SubjectType"]));
                    }
                }

                reader.Close();
            }

            return educationalSubjects;
        }

        public int GetEducationalSubjectsResults(int sessionId)
        {
            string sqlExpression = $"SELECT * FROM EducationalSubjectsList esl" +
                $" JOIN EducationalSubjects es ON esl.SessionId = {sessionId} AND esl.EducationalSubjectId = es.SubjectId" +
                $" JOIN StudentsResults sr ON sr.SessionId = {sessionId} AND sr.SubjectId = es.SubjectId AND sr.StudentId = {StudentId}";
            int result = 0;

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlDataReader reader = new SqlCommand(sqlExpression, connection).ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    result = (int)reader["Value"]; 
                }

                reader.Close();
            }

            return result;
        }
    }
}
