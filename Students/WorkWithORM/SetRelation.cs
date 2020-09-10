using System.Collections.Generic;
using System.Linq;
using Students.Objects;

namespace Students.WorkWithCrud
{
    public class SetRelation
    {
        public static List<Session> BindSessionWithGroup(List<Session> sessions, List<Group> groups)
        {
            var bindSessions = new List<Session>();
            Session tempSession = null;
            foreach (var item in sessions)
            {
                tempSession = item;
                tempSession.Group = groups.Where(obj => obj.Id == item.GroupId).Select(item => item).FirstOrDefault();
                bindSessions.Add(tempSession);
            }

            return bindSessions;
        }

        public static List<Student> BindStudentWithGroup(List<Student> students, List<Group> groups)
        {
            var bindStudents = new List<Student>();
            Student tempStudent = null;
            foreach (var item in students)
            {
                tempStudent = item;
                tempStudent.Group = groups.Where(obj => obj.Id == item.GroupId).Select(item => item).FirstOrDefault();
                bindStudents.Add(tempStudent);
            }

            return bindStudents;
        }


        public static List<StudentResult> BindStudentResultWithStudent(List<StudentResult> studentResults, List<Student> students, List<SessionEducationalSubject> educationalSubjects)
        {
            var bindStudentResults = new List<StudentResult>();
            StudentResult tempStudentResult = null;
            foreach (var item in studentResults)
            {
                tempStudentResult = item;
                tempStudentResult.Student = students.Where(obj => obj.Id == item.StudentId).Select(item => item).FirstOrDefault();
                tempStudentResult.SessionEducationalSubject = educationalSubjects.Where(obj => obj.Id == item.SessionEducationalSubjectId).Select(item => item).FirstOrDefault();
                bindStudentResults.Add(tempStudentResult);
            }

            return bindStudentResults;
        }

        public static List<SessionEducationalSubject> BindSessionEducationalSubjectWithSession(List<SessionEducationalSubject> studentResults, List<Session> session, List<EducationalSubject> educationalSubject)
        {
            var bindStudentResults = new List<SessionEducationalSubject>();
            SessionEducationalSubject tempStudentResult = null;
            foreach (var item in studentResults)
            {
                tempStudentResult = item;
                tempStudentResult.Session = session.Where(obj => obj.Id == item.SessionId).Select(item => item).FirstOrDefault();
                tempStudentResult.EducationalSubject = educationalSubject.Where(obj => obj.Id == item.EducationalSubjectId).Select(item => item).FirstOrDefault();
                bindStudentResults.Add(tempStudentResult);
            }

            return bindStudentResults;
        }
    }
}
