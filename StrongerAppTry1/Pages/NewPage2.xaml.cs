using StrongerAppTry1.Classes;

namespace StrongerAppTry1.Pages;

public partial class NewPage2 : ContentPage
{
	public NewPage2()
	{
		InitializeComponent();
        Border border = new Border();
        border.Style = (Style)Application.Current.Resources["CustomBorderSmallStyle"];
        Entry EnteryX = new Entry();
        EnteryX.Text = "40";
        EnteryX.Style = (Style)Application.Current.Resources["CustomEntrySetStyle"];
        border.Content = (EnteryX);

        RepStack.Add(border);

        ExerciseWithSet exerciseWithSet = new ExerciseWithSet(new Exercise("Bench","work",BodyGroup.Chest));
        exerciseWithSet.addSet(new Set(12, 15));
        exerciseWithSet.addSet(new Set(42, 15));

        MyStackLayout.Add(exerciseWithSet.grid); 
       // MyStackLayout.Add(exerciseWithSet.grid); 

        ExerciseWithSet exerciseWithSet2 = new ExerciseWithSet(new Exercise("squat", "work", BodyGroup.Chest));
        MyStackLayout.Add(exerciseWithSet2.grid);
        exerciseWithSet2.addSet(new Set(12, 140));


    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Application.Current.MainPage = new NavigationPage(new MainPage());

    }
}