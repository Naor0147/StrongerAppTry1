using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrongerAppTry1.Classes
{
    class ExerciseWithSet
    {
        public Exercise Exercise { get; set; }
        public List<Set> Sets { get; set; }

        public ExerciseWithSet(Exercise exercise) { 
            Exercise = exercise;
            Sets = new List<Set>();
        
        }

        public void addSet(Set set)
        {
            Sets.Add(set);
        }
        public void removeLastSet()
        {
            Sets.RemoveAt(Sets.Count - 1);

        }


    }
}
