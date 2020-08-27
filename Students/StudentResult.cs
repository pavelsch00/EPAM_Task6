using System;
using System.Collections.Generic;
using System.Text;

namespace Students
{
    public class StudentResult : EducationalSubject
    {
        public StudentResult(int studentId, int educationalSubjectSubjectId, string mark)
        {
            StudentId = studentId;

            EducationalSubjectSubjectId = educationalSubjectSubjectId;

            Mark = mark;
        }

        public StudentResult()
        {
        }

        int StudentId { get; set; }

        int EducationalSubjectSubjectId { get; set; }

        public string Mark { get; set; }

        public override string ToString() => $"\n Name: {Name}\t Date: {Date.ToShortDateString()}\t Type:{Type}\t Assesment: {Mark}";
    }
}
