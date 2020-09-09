using ORM.Creators;
using Students.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Creators.Objects
{
    public class StudentResultCreator : FabricBaseModel
    {
        public override BaseModel Create()
        {
            return new StudentResult();
        }
    }
}
