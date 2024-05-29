namespace StrongerAppTry1.Pages;

public partial class Excerics_Page : ContentPage
{
	public Excerics_Page()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        Application.Current.MainPage = new NavigationPage(new MainPage());

    }
}