using ORM.Creators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Tables
{
    public class StudentResult : BaseModel
    {
        public StudentResult(int studentId, int educationalSubjectSubjectId, string mark, EducationalSubject educationalSubject)
        {
            StudentId = studentId;

            EducationalSubjectSubjectId = educationalSubjectSubjectId;

            Mark = mark;

            EducationalSubject = educationalSubject;
        }

        public StudentResult()
        {
        }

        public int StudentId { get; set; }

        public int EducationalSubjectSubjectId { get; set; }

        public string Mark { get; set; }

        public EducationalSubject EducationalSubject { get; set; }

        public override string ToString() => $"\n Name: {EducationalSubject.Name}\t Date: {EducationalSubject.Date.ToShortDateString()}\t Type:{EducationalSubject.Type}\t Assesment: {Mark}";
    }
}
