using System;
using Students.Objects;

namespace Students.Interfaces
{
    public interface IStudent
    {
        public string FullName { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Group Group { get; set; }

        public int GroupId { get; set; }
    }
}
