using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.Creators
{
    public abstract class FabricBaseModel
    {
        public abstract BaseModel Create();
    }
}
