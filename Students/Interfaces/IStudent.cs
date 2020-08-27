using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Interfaces
{
    public interface IStudent
    {
        public string FullName { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int GroupId { get; set; }
    }
}
