using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using Application = Microsoft.Maui.Controls.Application;

namespace StrongerAppTry1.Classes
{
    public class ExerciseWithSet
    {
        public Exercise _Exercise { get; set; }
        public List<Set> _Sets { get; set; }
        public List<SetHelper> _SetsHelper { get; set; }




        public Grid grid;
        public VerticalStackLayout VerticalSet;
        public VerticalStackLayout VerticalPreviousSet;
        public VerticalStackLayout VerticalWeight;
        public VerticalStackLayout VerticalRep;
        public ExerciseWithSet(Exercise exercise) {
            _Exercise = exercise;
            _Sets = new List<Set>();
            _SetsHelper = new List<SetHelper>();    
            ShowExercise();
            addSet();
        }
        //Add a new set that is visibale 
        public void addSet(Set set)
        {
            _SetsHelper.Add(new SetHelper(set));


            

           
           


        }
        public void addSet()
        {
            Set set = new Set(_SetsHelper.Count+1,0, 0);

            _SetsHelper.Add( new SetHelper( set));

            
        }

        private Label AddPrevious(string text)
        {
            var label = new Label
            {
                Text = text,
                Style = (Style)Application.Current.Resources["CustomLabelPreviousSetStyle"]
            };

            VerticalPreviousSet.Children.Add(CreateStyledBorder(label));
            return label;
        }

        public void removeLastSet()
        {
            _Sets.RemoveAt(_Sets.Count - 1);

        }

        public Grid CreateGrid()
        {
            var grid = new Grid();

            // Define the ColumnDefinitions
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2.5, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

            // Define the RowDefinitions
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            return grid;
        }

        public void ShowExercise()
        {
            grid = CreateGrid();
            CreateExerciseNameLabel(grid);
            CreateVertical();

            AddToGridVertical(VerticalSet,0);
            AddToGridVertical(VerticalPreviousSet, 1);
            AddToGridVertical(VerticalWeight, 2);
            AddToGridVertical(VerticalRep, 3);
            

        }

        private void AddToGridVertical(VerticalStackLayout views , int column)
        {
            grid.Children.Add(PutInsideBorder(views, column));
        }

        private void CreateVertical()
        {
            VerticalSet = CreateSet();
            VerticalPreviousSet = CreatePreviousSetStack();
            VerticalWeight = CreateWeightStack();
            VerticalRep = CreateRepsStack();
        }



        private Label CreateExerciseNameLabel(Grid grid)
        {
            Label ExerciseNameLabel = new Label
            {
                Style = (Style)Microsoft.Maui.Controls.Application.Current.Resources["ExerciseLabelStyle"],
                Text = _Exercise._Name
            };
            grid.SetColumnSpan(ExerciseNameLabel, 4);
            grid.Add(ExerciseNameLabel);

            return ExerciseNameLabel;
        }

        private Label AddSetNumber( int SetNumber)
        {

            var label = new Label
            {
                Text = SetNumber + "",
                Style = (Style)Application.Current.Resources["CustomLabelSetStyle"]
            };
      
            VerticalSet.Children.Add(CreateBorderForSet(label));
            return label;
        }

        private static Border CreateBorderForSet(Label label)
        {
            var border = new Border
            {
                Style = (Style)Application.Current.Resources["CustomBorderSmallNoStyle"]
            };
            border.Content = label;
            return border;
        }

        // Helper method to create a styled Border with a Label




        // Helper method to create a styled Border with a Label
        private Border CreateStyledBorder(Label label)
        {
            var border = new Border
            {
                Style = (Style)Application.Current.Resources["CustomBorderPreviousSetStyle"]
            };

            border.Content = label;
            return border;

        }
        public Border PutInsideBorder(VerticalStackLayout views, int column )
        {
            var mainBorder = new Border
            {
                Stroke = new SolidColorBrush(Color.FromArgb("#2b3238")),
            };
            Grid.SetRow(mainBorder, 1);
            Grid.SetColumn(mainBorder, column);
            // Add the VerticalStackLayout to the main Border
            mainBorder.Content = views;

            // Add the main Border to the page's content (assuming it's a Grid or similar)

            return mainBorder;
        }
       

        private Entry AddEntry(VerticalStackLayout verticalStackLayout,string text)
        {
            Entry entry = new Entry
            {
                Text = text,
                Style = (Style)Application.Current.Resources["CustomEntrySetStyle"]
            };
           

            verticalStackLayout.Children.Add(CreateStyledBorderWithEntry(entry));
            return entry;
        }


        // Helper method to create a styled Border with an Entry
        private Border CreateStyledBorderWithEntry(Entry entry)
        {
            var border = new Border
            {
                Style = (Style)Application.Current.Resources["CustomBorderSmallStyle"]
            };

            border.Content = entry;
            return border;
        }

        

        public VerticalStackLayout CreateRepsStack()
        {
            var verticalStackLayout = new VerticalStackLayout();

            // Set Grid.Column for the VerticalStackLayout
            Grid.SetColumn(verticalStackLayout, 1);

            // Create and style the first Label
            var labelReps = new Label
            {
                Text = "REPS",
                Style = (Style)Application.Current.Resources["CustomLabelStyle"]
            };
            verticalStackLayout.Children.Add(labelReps);
            return verticalStackLayout;
        }

        public VerticalStackLayout CreateWeightStack()
        {

            var verticalStackLayout = new VerticalStackLayout();

            // Set Grid.Column for the VerticalStackLayout
            Grid.SetColumn(verticalStackLayout, 1);

            // Create and style the first Label
            var labelKg = new Label
            {
                Text = "KG",
                Style = (Style)Application.Current.Resources["CustomLabelStyle"]
            };
            verticalStackLayout.Children.Add(labelKg);



            return verticalStackLayout;
        }
        public VerticalStackLayout CreatePreviousSetStack()
        {
            // Create the VerticalStackLayout
            var verticalStackLayout = new VerticalStackLayout();

            // Set Grid.Column for the VerticalStackLayout
            Grid.SetColumn(verticalStackLayout, 1);

            // Create and style the first Label
            var labelPrevious = new Label
            {
                Text = "PREVIOUS",
                Style = (Style)Application.Current.Resources["CustomLabelStyle"]
            };
            verticalStackLayout.Children.Add(labelPrevious);

            // Add the VerticalStackLayout to the main Border
            return verticalStackLayout;


        }
        private VerticalStackLayout CreateSet()
        {

            var setStack = new VerticalStackLayout();


            // Create and style the first Label
            var labelSet = new Label
            {
                Text = "SET",
                Style = (Style)Application.Current.Resources["CustomLabelStyle"]
            };
            setStack.Children.Add(labelSet);


            return setStack;
        }
    }
}

