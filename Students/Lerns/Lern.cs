using Students.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Lerns
{
    public abstract class Lern : ILern
    {
        public Lern(string name, DateTime date)
        {
            Name = name;
            Date = date;
        }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public override string ToString() => $"\n Date: {Date}\t Name: {Name}\t ";
    }
}
