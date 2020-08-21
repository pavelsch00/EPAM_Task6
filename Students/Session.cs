using Students.EducationalSubjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Students
{
    public class Session
    {
        public Session(int number, List<EducationalSubject> educationalSubjects)
        {
            Number = number;
            EducationalSubjects = educationalSubjects;
        }

        public Session(int number)
        {
            Number = number;
        }

        public int Number { get; set; }

        public List<EducationalSubject> EducationalSubjects { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in EducationalSubjects)
            {
                sb.Append(item);
            }

            return $"\nSession Number: {Number}" + sb;
        }
    }
}
