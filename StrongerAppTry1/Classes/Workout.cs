using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrongerAppTry1.Classes
{
    public class Workout
    {
        public string Name { get; set; }// Name of the workout 
        public DateTime DateTime { get; set; } // the date of the workout 
        public int Time;// how long the workout lasted 
        public List<ExerciseWithSet> Exercises; // the list that save the Exercises Performed in the workout
        
        public Workout()
        {
            Name = "Workout";
            DateTime = DateTime.Now;
            Time = 0;
            Exercises = new List<ExerciseWithSet>();

        }



    }
}
