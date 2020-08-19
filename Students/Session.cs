﻿using Students.Lerns;
using System;
using System.Collections.Generic;
using System.Text;

namespace Students
{
    public class Session
    {
        public Session(int number, List<Сredit> credit, List<Exam> exam)
        {
            Number = number;
            Credit = credit;
            Exam = exam;
        }

        public int Number { get; set; }

        public List<Сredit> Credit { get; set; }

        public List<Exam> Exam { get; set; }
    }
}
