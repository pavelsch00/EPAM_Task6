using Students.Lerns;
using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Interfaces
{
    public interface ISession
    {
        public int Number { get; set; }

        public List<Credit> Credit { get; set; }

        public List<Exam> Exam { get; set; }
    }
}
