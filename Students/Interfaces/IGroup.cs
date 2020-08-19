using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Interfaces
{
    public interface IGroup
    {

        public string Name { get; set; }

        public List<Session> Session { get; set; }
    }
}
