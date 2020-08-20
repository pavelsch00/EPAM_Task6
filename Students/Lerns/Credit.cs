using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Lerns
{
    public class Credit : Lern
    {
        public Credit(string name, DateTime date, bool assessment) : base(name, date)
        {
            Assessment = assessment;
        }

        public bool Assessment { get; set; }

        public override string ToString() => base.ToString() + $"Assessment: {Assessment}\n";
    }
}
