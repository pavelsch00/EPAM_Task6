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
            DateOfBirth = DateTime.Parse(dateofBirth);
            Group = group;
        }

        public Student(string fullName, string gender, string dateofBirth)
        {
            FullName = fullName;
            Gender = gender;
            DateOfBirth = DateTime.Parse(dateofBirth);
        }

        public string FullName { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Group Group { get; set; }

        public override string ToString() => $"FullName: {FullName}\t Gender: {Gender} \tDateOfBirth: {DateOfBirth.ToShortDateString()}{Group?.ToString()}";
    }
}
