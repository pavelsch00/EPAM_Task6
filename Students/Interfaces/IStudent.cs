using System;
using Students.Objects;

namespace Students.Interfaces
{
    /// <summary>
    /// Interface describes the IStudent.
    /// </summary>
    public interface IStudent
    {
        /// <summary>
        /// The property stores information about FullName.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// The property stores information about Gender.
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// The property stores information about DateOfBirth.
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// The property stores information about Group object.
        /// </summary>
        public Group Group { get; set; }

        /// <summary>
        /// The property stores information about GroupId.
        /// </summary>
        public int GroupId { get; set; }
    }
}
