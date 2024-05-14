﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrongerAppTry1.Classes
{
    public enum BodyGroup
    {
        Arms,Legs, Shoulder,Back,Chest
    }
    

    enum BodyPart
    {
        Bicep,Triceps , Leg , Chest, Waist ,Hips, Thighs, Calves
    }

    public class Exercise
    { 
        public string _Name { get; set; }
        public string _Description { get; set; }
        public BodyGroup _BodyGroup{ get; set; }
        public ImageSource ImageSource { get; set; }

        public Exercise(string name, string description, BodyGroup bodyGroup, ImageSource imageSource)
        {
            _Name = name;
            _Description = description;
            _BodyGroup = bodyGroup;
            ImageSource = imageSource;
        }




    }
}