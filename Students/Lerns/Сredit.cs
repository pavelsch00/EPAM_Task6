using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Lerns
{
    public class Сredit : Lern
    {
        public Сredit(string name, DateTime date, bool assessment) : base(name, date)
        {
            Assessment = assessment;
        }

        public bool Assessment { get; set; }
    }
}
