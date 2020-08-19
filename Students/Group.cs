using Students.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Students
{
    public class Group : IGroup
    {
        public Group(string name, List<Session> session)
        {
            Name = name;
            Session = session;
        }

        public Group(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public List<Session> Session { get; set; }
    }
}
