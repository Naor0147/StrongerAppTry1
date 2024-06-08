using Microsoft.Maui.Controls.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StrongerAppTry1.Classes
{
    public class SetHelper
    {
        public Set set;
        public Entry WeightEntry, RepEntry;
        public Label PreviousSet;
        public Label SetNumber;
        public CheckBox checkBox;

        public Grid grid;

        //Styles
        private Style customBorderSmallStyle, customEntrySetStyle, customLabelSetStyle, customBorderPreviousSetStyle, customLabelPreviousSetStyle;

        //border
        public Border BorderWeight;
        public Border BorderPrevious;
        public Border BorderRep;
        //public SetHelper(int setNumber, Set set, Entry weightEntry, Entry repEntry, Label previousSet)

        public SetHelper(Set set)
        {
            CreateStyles();

            this.set = set;
            grid = NewGrid();

            this.grid = CreateCustomSet();
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
            CreateGreenBackground();
        }
        public void CreateGreenBackground()
        {
            var _color = new SolidColorBrush(Colors.Green);

            // Create a rectangle and set its properties
            var rectangle = new Microsoft.Maui.Controls.Shapes.Rectangle
            {
                Fill = _color,
                ZIndex = -1 // Ensure the rectangle is at the back
            };

            // Set the column span
            Grid.SetColumnSpan(rectangle, 5);

            // Add the rectangle to the grid
            grid.Add(rectangle);

            // Set the background color of WeightEntry
            BorderWeight.BackgroundColor = _color.Color;
            BorderRep.BackgroundColor = _color.Color;
            BorderPrevious.BackgroundColor = _color.Color;
            PreviousSet.BackgroundColor = _color.Color;
        }

        public void UpdateSet()
        {
            double weight = 0;
            if (double.TryParse(WeightEntry.Text, out weight))
            {
                set.Weight = weight;
            }
            double reps = 0;
            if (double.TryParse(RepEntry.Text, out reps))
            {
                set.Reps = reps;
            }
        }

        //Grid the set works on

        public void CreateStyles()
        {
            customBorderSmallStyle = (Style)Application.Current.Resources["CustomBorderSmallStyle"];
            customEntrySetStyle = (Style)Application.Current.Resources["CustomEntrySetStyle"];
            customLabelSetStyle = (Style)Application.Current.Resources["CustomLabelSetStyle"];
            customBorderPreviousSetStyle = (Style)Application.Current.Resources["CustomBorderPreviousSetStyle"];
            customLabelPreviousSetStyle = (Style)Application.Current.Resources["CustomLabelPreviousSetStyle"];
        }

        public Grid CreateCustomSet()
        {
            // Define styles for the controls

            // Create the grid
            CreateTheNumberSet();

            CreateLabelPreviousSet();

            // Add the second Border with Entry inside
            CreateEntryWeight();

            // Add the third Border with Entry inside
            CreateEntryReps();

            // Add the CheckBox
            CreateCheckBox();

            // Set the content of the page to the grid
            return grid;
        }

        private void CreateCheckBox()
        {
            checkBox = new CheckBox();
            Grid.SetColumn(checkBox, 4);

            grid.Children.Add(checkBox);
            checkBox.CheckedChanged += CheckBox_CheckedChanged;
        }

        private bool finished = false;
        private void CheckBox_CheckedChanged(object? sender, CheckedChangedEventArgs e)
        {
            finished = ((CheckBox)sender).IsChecked; 
        }

        private void CreateEntryReps()
        {
            RepEntry = new Entry
            {
                Style = customEntrySetStyle,
                Text = set.Reps + ""
            };
            RepEntry.TextChanged += TextChanged;

            BorderRep = new Border
            {
                Style = customBorderSmallStyle,
                Content = RepEntry,
            };
            Grid.SetColumn(BorderRep, 3);

            grid.Children.Add(BorderRep);
        }
        private void CreateEntryWeight()
        {
            WeightEntry = new Entry
            {
                Style = customEntrySetStyle,
                Text = set.Weight + ""
            };
            WeightEntry.TextChanged += TextChanged;

            BorderWeight = new Border
            {
                Style = customBorderSmallStyle,
                Content = WeightEntry,
            }.SetGridColumn(2);

            grid.Children.Add(BorderWeight);
        }

        /// <summary>
        /// Creating the looks of the set
        /// </summary>

        //create the label of the number set
        private void CreateTheNumberSet()
        {
            SetNumber = new Label
            {
                Style = customLabelSetStyle,
                Text = set.NumberOfTheSet + "",
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            this.grid.Children.Add(SetNumber);
        }
        //create the label of the Previous set
        private void CreateLabelPreviousSet()
        {
            PreviousSet = new Label
            {
                Style = customLabelPreviousSetStyle,
                Text = "60kg x 12"
            };
            BorderPrevious = new Border
            {
                Style = customBorderPreviousSetStyle,
                Content = PreviousSet,
                
            }.SetGridColumn(1);

            this.grid.Children.Add(BorderPrevious);
        }

        private static Grid NewGrid()
        {
            return new Grid
            {
                RowDefinitions = { new RowDefinition() },
                ColumnDefinitions = {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(2.5, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) },
                    new ColumnDefinition { Width = GridLength.Auto }
                }
            };
        }
    }
}