using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrongerAppTry1.Classes
{
    enum SetType {
        Regular ,
        WarmUp,
        DropSet,
    }

    struct Set
    {
        public double rep { get; set; }
        public double weight { get; set; }
        public SetType type { get; set; }


        public Set(double rep, double weight, SetType setType = SetType.Regular)
        {
            this.rep = rep;
            this.weight = weight;
            this.type = setType;
        }
    }
}
