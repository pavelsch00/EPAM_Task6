using Students;
using Students.EducationalSubjects;
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

        private int StudentId { get; set; }

        private int SessionId { get; set; }

        public string ConnectionString { get; set; }

        public void AddToBd(Student student)
        {
        }

        public List<Student> GetStudentFromBd()
        {
            string sqlExpression = "SELECT * FROM Students s JOIN Genders g ON s.GenderId = g.GenderId" +
                " JOIN Groups gr ON s.GroupId = gr.GroupId";
            var studetns = new List<Student>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        StudentId = (int)reader["StudentId"];
                        string fullName = (string)reader["FullName"];
                        string gender = (string)reader["GenderName"];
                        DateTime dateOfBirth = DateTime.Parse(reader["DateOfBirth"].ToString());
                        string group = (string)reader["GroupName"];
                        studetns.Add(new Student(fullName, gender, dateOfBirth.ToString(), new Group(group, GetSessionsFromBd((int)reader["GroupId"]))));
                    }
                }

                reader.Close();
            }

            return studetns;
        }

        public List<Session> GetSessionsFromBd(int groupId)
        {
            string sqlExpression = $"SELECT * FROM GroupSessions gs" +
                $" JOIN Sessions s ON gs.GroupId = {groupId} AND s.SessionId = gs.SessionId";
            var sessions = new List<Session>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SessionId = (int)reader["SessionId"];
                        sessions.Add(new Session((int)reader["SessionNumber"], GetEducationalSubjectsFromBd(SessionId)));
                    }
                }

                reader.Close();
            }

            return sessions;
        }

        public List<EducationalSubject> GetEducationalSubjectsFromBd(int sessionId)
        {
            string sqlExpression = $"SELECT * FROM EducationalSubjectsList esl" +
                $" JOIN EducationalSubjects es ON esl.SessionsId = {sessionId} AND esl.EducationalSubjectsId = es.SubjectId" +
                $" JOIN EducationalSubjectNames esn ON esn.SubjectNameId = es.SubjectNameId" +
                $" JOIN EducationalSubjectTypes est ON est.SubjectTypeId = es.SubjectTypeId" +
                $" JOIN EducationalSubjectsDate esd ON esd.EducationalSubjectsDateId = es.DateId";
            var educationalSubjects = new List<EducationalSubject>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        educationalSubjects.Add(new EducationalSubject((string)reader["SubjectName"], DateTime.Parse(reader["Date"].ToString()), (string)reader["Type"], GetEducationalSubjectsResultFromBd((int)reader["EducationalSubjectsId"])));
                    }
                }

                reader.Close();
            }

            return educationalSubjects;
        }

        public int GetEducationalSubjectsResultFromBd(int educationalSubjectId)
        {
            string sqlExpression = $"SELECT * FROM Students" +
                $" JOIN StudentsResults sr ON sr.StudentId = {StudentId}" +
                $" JOIN EducationalSubjectResultList esrl ON esrl.EducationalSubjectResultListId = sr.EducationalSubjectResultListId AND esrl.SessionId = {SessionId}" +
                $" JOIN EducationalSubjectResults esr ON esr.EducationalSubjectResultId = esrl.EducationalSubjectResultId AND esr.EducationalSubjectsId = {educationalSubjectId}";
            int result = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

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
