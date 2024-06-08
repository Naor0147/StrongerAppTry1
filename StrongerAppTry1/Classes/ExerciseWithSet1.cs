using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
namespace StrongerAppTry1.Classes
{
    class ExerciseWithSet1
    {
        //Grid the set works on
        public Grid grid;

        //Styles
        private Style _exerciseLabelStyle, _customLabelStyle, _customBorderSmallSetNoStyle, _addSetButtonStyle,_debugBorderStyle;
        public VerticalStackLayout setsVertical;

        //sets 
        public List<SetHelper> _SetsHelper { get; set; }

        public Exercise Exercise { get; set; }
        public ExerciseWithSet1()
        {
            Exercise = new Exercise("Exercise Name", "");
            InitializeFunction();
        }

      

        public ExerciseWithSet1(Exercise exercise)
        {
            Exercise = exercise;
            InitializeFunction();


        }
        private void InitializeFunction()
        {
            _SetsHelper = new List<SetHelper>();
            InitializeStyles();
            CreateLayout();
            AddSet();
        }
        public void AddSet()
        {
            AddSet(new Set(_SetsHelper.Count + 1, 0, 0));
        }
        public void AddSet(Set set)
        {
            SetHelper setHelper = new SetHelper(set);
            _SetsHelper.Add(setHelper);
            setsVertical.Add( setHelper.CreateCustomSet());
        }




        //chatgpt 

        private void InitializeStyles()
        {
            // Initialize the styles from the resource dictionary
            _debugBorderStyle = (Style)Application.Current.Resources["BorderDebug"];
            _exerciseLabelStyle = (Style)Application.Current.Resources["ExerciseLabelStyle"];
            _customLabelStyle = (Style)Application.Current.Resources["CustomLabelStyle"];
            _customBorderSmallSetNoStyle = (Style)Application.Current.Resources["CustomBorderSmallSetNoStyle"];
            _addSetButtonStyle = new Style(typeof(Button))
            {
                Setters =
            {
                new Setter { Property = Button.BackgroundColorProperty, Value = "#2b3238" },
                new Setter { Property = Button.FontAttributesProperty, Value = FontAttributes.Bold },
                new Setter { Property = Button.FontSizeProperty, Value = Device.GetNamedSize(NamedSize.Small, typeof(Button)) },
                new Setter { Property = Button.TextColorProperty, Value = "#44a3ea" },
                new Setter { Property = Button.VerticalOptionsProperty, Value = LayoutOptions.Center }
            }
            };
        }

        public View CreateMainLayout()
        {

            return MainBorder;
        }
        Border MainBorder;

        private void CreateLayout()
        {
            // Create the grid and store it in a variable
            var grid = CreateGrid();

            // Create and return the main border containing the vertical stack layout
            MainBorder = new Border
            {
                Style = _debugBorderStyle,
                Content = new VerticalStackLayout
                {
                    Children =
                {
                    CreateExerciseLabel(),
                    grid,
                    CreateAddSetButton()
                }
                }
                
            };
            
        }

        private Label CreateExerciseLabel()
        {
            // Create and return the exercise name label
            return new Label
            {
                Style = _exerciseLabelStyle,
                Text = Exercise._Name + " "
            };
        }

        private Label CreateLabel(string text, int row, int column)
        {
            // Create and return a label with the specified text, row, and column
            var label = new Label
            {
                Style = _customLabelStyle,
                Text = text
            }.SetGridRow(row).SetGridColumn(column);

            return label;
        }

        private Border CreateCustomBorder(int row, int column)
        {
            // Create and return a border with the specified row and column
            var border = new Border
            {
                Style = _customBorderSmallSetNoStyle
            }.SetGridRow(row).SetGridColumn(column);

            return border;
        }

        private Border CreateSetsVerticalLayout(int row, int columnSpan)
        {
            // Initialize the sets layout
            setsVertical = new VerticalStackLayout();

            // Create and return a border containing the vertical stack layout
            var border = new Border
            {
                Content = setsVertical
            }.SetGridRow(row).SetGridColumnSpan(columnSpan);

            return border;
        }

        private Button CreateAddSetButton()
        {
            // Create and return the "ADD SET" button with the style applied
            var button = new Button
            {
                Style = _addSetButtonStyle,
                Text = "ADD SET"
            }.SetGridRow(3).SetGridColumnSpan(4);

            // Attach the button click event handler
            button.Clicked += Button_Clicked;

            return button;
        }

        private void Button_Clicked(object? sender, EventArgs e)
        {
            // Handle the button click event to add a new set to the vertical stack layout
            AddSet();
        }

        private Grid CreateGrid()
        {
            // Create and return the grid layout with column and row definitions
            var grid = new Grid
            {
                ColumnDefinitions =
            {
                new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                new ColumnDefinition { Width = new GridLength(2.5, GridUnitType.Star) },
                new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) },
                new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) },
                new ColumnDefinition { Width = GridLength.Auto }
            },
                RowDefinitions =
            {
                new RowDefinition { Height = GridLength.Auto },
                new RowDefinition { Height = GridLength.Auto },
                new RowDefinition { Height = GridLength.Auto },
                new RowDefinition { Height = GridLength.Auto }
            }
            };

            // Add labels to the grid
            grid.Children.Add(CreateLabel("SET", 0, 0));
            grid.Children.Add(CreateLabel("PREVIOUS", 0, 1));
            grid.Children.Add(CreateLabel("KG", 0, 2));
            grid.Children.Add(CreateLabel("REPS", 0, 3));
            grid.Children.Add(CreateLabel("", 0, 4));

            // Add border to the grid
            grid.Children.Add(CreateCustomBorder(1, 4));

            // Add vertical stack layout inside a border in the grid
            grid.Children.Add(CreateSetsVerticalLayout(1, 5));

            return grid;
        }
    }



        //
     public static class ViewExtensions
        {
        public static T SetGridRow<T>(this T view, int row) where T : View
        {
            Grid.SetRow(view, row);
            return view;
        }

        public static T SetGridColumn<T>(this T view, int column) where T : View
        {
            Grid.SetColumn(view, column);
            return view;
        }

        public static T SetGridRowSpan<T>(this T view, int rowSpan) where T : View
        {
            Grid.SetRowSpan(view, rowSpan);
            return view;
        }

        public static T SetGridColumnSpan<T>(this T view, int columnSpan) where T : View
        {
            Grid.SetColumnSpan(view, columnSpan);
            return view;
        }
    }
}
