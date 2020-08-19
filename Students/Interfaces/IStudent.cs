using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Interfaces
{
    public interface IStudent
    {
        public string FullName { get; set; }

        public string Gender { get; set; }

        public string DateofBirth { get; set; }

        public Group Group { get; set; }
    }
}
