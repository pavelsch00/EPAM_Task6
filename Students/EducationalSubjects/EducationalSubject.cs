using Students.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Students.EducationalSubjects
{
    public class EducationalSubject : ILern
    {
        public EducationalSubject(string name, DateTime date, string type)
        {
            Name = name;
            Date = date;
            Type = type;
        }

        public EducationalSubject(string name, DateTime date, string type, int assessment)
        {
            Name = name;
            Date = date;
            Type = type;
            Assessment = assessment;
        }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public string Type { get; set; }

        public int Assessment { get; set; }

        public override string ToString()
        {
            if (Type == "Exam")
            {
                return $"\n Name: {Name}\t Date: {Date.ToShortDateString()}\t Type:{Type}\t Assesment: {Assessment}";
            }else
            {
                bool flag = Assessment == 1 ? true : false;
                return $"\n Name: {Name}\t Date: {Date.ToShortDateString()}\t Type:{Type}\t Assesment: {flag}";
            }
        }
    }
}
