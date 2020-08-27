using System;
using System.Collections.Generic;
using System.Text;

namespace Students
{
    public class Session
    {
        public Session(int number, int groupId)
        {
            Number = number;
            GroupId = groupId;
        }

        public Session(int number)
        {
            Number = number;
        }

        public Session()
        {

        }

        public int Id { get; set; }

        public int GroupId { get; set; }

        public int Number { get; set; }

        public override string ToString() => $"\nSession Number: {Number}";
    }
}
