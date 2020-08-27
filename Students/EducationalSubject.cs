﻿using Students.Interfaces;
using System;

namespace Students
{
    public class EducationalSubject : ILern
    {
        public EducationalSubject(string name, DateTime date, string type)
        {
            Name = name;
            Date = date;
            Type = type;
        }

        public EducationalSubject()
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public string Type { get; set; }

        public override string ToString() => $"\n Name: {Name}\t Date: {Date.ToShortDateString()}\t Type:{Type}";
    }
}
