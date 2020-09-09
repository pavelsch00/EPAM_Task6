using ORM.Creators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Objects
{
    public class StudentResult : BaseModel
    {
        public StudentResult(Student student, string mark, EducationalSubject educationalSubject)
        {
            Student = student;

            Mark = mark;

            EducationalSubject = educationalSubject;
        }

        public StudentResult()
        {
        }

        public Student Student { get; set; }

        public EducationalSubject EducationalSubject { get; set; }

        public int StudentId { get; set; }

        public int EducationalSubjectId { get; set; }

        public string Mark { get; set; }

        public override string ToString() => $"\n{Student} {EducationalSubject}\t Assesment: {Mark}";
    }
}
