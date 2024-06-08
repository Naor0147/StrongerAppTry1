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
        public int NumberOfTheSet { get; set; }
        public double Reps { get; set; }
        public double Weight { get; set; }
        public SetType SetType { get; set; }

        public double rpe {  get; set; }

        public Set(int NumberOfTheSet, double rep, double weight, SetType setType = SetType.Regular,double rpe =0)
        {
            this.NumberOfTheSet = NumberOfTheSet;  
            this.Reps = rep;
            this.Weight = weight;
            this.SetType = setType;
            this.rpe =rpe ;
        }
    }
}
