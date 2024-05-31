using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StrongerAppTry1.Classes
{
    public class SetHelper
    {

        public int SetNumber;
        public Set set;
        public Entry WeightEntry, RepEntry;
        public Label PreviousSet;
        public SetHelper(int setNumber, Set set, Entry weightEntry, Entry repEntry, Label previousSet)
        {
            SetNumber = setNumber;
            this.set = set;
            WeightEntry = weightEntry;
            RepEntry = repEntry;
            PreviousSet = previousSet;
            weightEntry.TextChanged += TextChanged;
            RepEntry.TextChanged += TextChanged;
        }

        private void TextChanged(object? sender, TextChangedEventArgs e)
        {
            string text = e.NewTextValue;
            //Regular expressions are used to match whether the user input contains numbers
            string result = Regex.Replace(text, @"[^0-9.]+", ""); // Remove all characters except digits and dot
            int dotIndex = result.IndexOf('.'); // Find the index of the first dot

            // If there is more than one dot, remove the extra dots
            if (dotIndex != -1)
            {
                result = result.Substring(0, dotIndex + 1) + Regex.Replace(result.Substring(dotIndex + 1), @"\.", "");
            }
            (sender as Entry).Text = result;


            UpdateSet();
        }

        public void UpdateSet()
        {
            double weight = 0;
            if (double.TryParse(WeightEntry.Text,out weight))
            {
                set.weight = weight;
            }
            double reps = 0;
            if(double.TryParse(RepEntry.Text, out reps))
            {
                set.rep = reps;
            }
            
        }
    }
    
}
