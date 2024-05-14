using StrongerAppTry1.Classes;

namespace StrongerAppTry1.Pages;

public partial class NewPage1 : ContentPage
{
	public NewPage1()
	{
		InitializeComponent();
		Exercise exercise = new Exercise("incline dumbbell bench press", "strong", BodyGroup.Chest, ImageSource.FromFile("incline_dumbbell_bench_press.png"));
        ExerciseName.Text = exercise._Name;

    }

}