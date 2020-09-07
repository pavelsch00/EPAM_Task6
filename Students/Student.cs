using Students.Interfaces;
using System;

namespace Students
{
    public class Student : BaseModel, IStudent
    {
        public Student(string fullName, string gender, string dateofBirth, int groupId)
        {
            FullName = fullName;
            Gender = gender;
            DateOfBirth = DateTime.Parse(dateofBirth);
            GroupId = groupId;
        }

        public Student(string fullName, string gender, string dateofBirth)
        {
            FullName = fullName;
            Gender = gender;
            DateOfBirth = DateTime.Parse(dateofBirth);
        }

        public Student()
        {

        }

        public string FullName { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int GroupId { get; set; }

        public override string ToString() => $"\nId: {Id}\t FullName: {FullName}\t Gender: {Gender} \tDateOfBirth: {DateOfBirth.ToShortDateString()} \tGroupId: {GroupId}";
    }
}
