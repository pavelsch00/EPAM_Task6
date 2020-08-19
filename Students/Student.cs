using Students.Interfaces;
using System;

namespace Students
{
    public class Student : IStudent
    {
        public Student(string fullName, string gender, string dateofBirth, Group group)
        {
            FullName = fullName;
            Gender = gender;
            DateofBirth = dateofBirth;
            Group = group;
        }

        public Student(string fullName, string gender, string dateofBirth)
        {
            FullName = fullName;
            Gender = gender;
            DateofBirth = dateofBirth;
        }

        public string FullName { get; set; }

        public string Gender { get; set; }

        public string DateofBirth { get; set; }

        public Group Group { get; set; }
    }
}
