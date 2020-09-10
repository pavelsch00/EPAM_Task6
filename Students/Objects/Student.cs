using ORM.Creators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Objects
{
    public class Student : BaseModel
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

        public Student()
        {
            Group = new Group();
        }

        public string FullName { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Group Group { get; set; }

        public int GroupId { get; set; }

        public override string ToString() => $"\nFullName: {FullName}\t Gender: {Gender} \tDateOfBirth: {DateOfBirth.ToShortDateString()} {Group}";

        public override bool Equals(object obj)
        {
            return obj is Student student &&
                   FullName == student.FullName &&
                   Gender == student.Gender &&
                   DateOfBirth == student.DateOfBirth;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FullName, Gender, DateOfBirth);
        }
    }
}
