using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Interfaces
{
    public interface ISession
    {
        public int Number { get; set; }

        public int GroupId { get; set; }
    }
}
