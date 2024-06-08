using StrongerAppTry1.Classes;

namespace StrongerAppTry1.Pages;

public partial class NewPage3 : ContentPage
{
    ExerciseWithSet1 exerciseWithSet1;

    public NewPage3()
	{
		InitializeComponent();
        exerciseWithSet1 = new ExerciseWithSet1();
        //SetsVertical.Add(exerciseWithSet1.AddSet());
        WorkoutVertical.Add((new ExerciseWithSet1()).CreateMainLayout());
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Application.Current.MainPage = new NavigationPage(new MainPage());

    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {

        exerciseWithSet1.AddSet();
    }
}