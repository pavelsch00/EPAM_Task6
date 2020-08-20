using Students.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Lerns
{
    public class Exam : Lern
    {
        public Exam(string name, DateTime date, int assessment) : base(name, date)
        {
            Assessment = assessment;
        }

        public int Assessment { get; set; }

        public override string ToString() => base.ToString() + $"Assessment: {Assessment}\n";
    }
}
