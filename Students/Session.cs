using Students.Lerns;
using System;
using System.Collections.Generic;
using System.Text;

namespace Students
{
    public class Session
    {
        public Session(int number, List<Credit> credit, List<Exam> exam)
        {
            Number = number;
            Credit = credit;
            Exam = exam;
        }

        public int Number { get; set; }

        public List<Credit> Credit { get; set; }

        public List<Exam> Exam { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in Credit)
            {
                sb.Append(item);
            }

            foreach (var item in Exam)
            {
                sb.Append(item);
            }

            return $"\nSession Number: {Number}" + sb;
        }
    }
}
