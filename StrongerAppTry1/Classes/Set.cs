using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrongerAppTry1.Classes
{
    public enum SetType {
        Regular ,
        WarmUp,
        DropSet,
    }
    //enum Rpe
    //{
    //    None,
    //}

    public struct Set
    {
        public double rep { get; set; }
        public double weight { get; set; }
        public SetType type { get; set; }

        public double rpe {  get; set; }

        public Set(double rep, double weight, SetType setType = SetType.Regular,double rpe =0)
        {
            this.rep = rep;
            this.weight = weight;
            this.type = setType;
            this.rpe =rpe ;
        }
    }
}
