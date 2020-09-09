using ORM.Creators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Objects
{
    public class Session : BaseModel
    {
        public Session(int number, Group group)
        {
            SessionNumber = number;
            Group = group;
        }

        public Session(int number)
        {
            SessionNumber = number;
        }

        public Session()
        {

        }

        public int GroupId { get; set; }

        public Group Group { get; set; }

        public int SessionNumber { get; set; }

        public override string ToString() => $"\nSession Number: {SessionNumber} {Group}";
    }
}
