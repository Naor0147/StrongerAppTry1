namespace StrongerAppTry1;

public partial class TestPage2 : ContentPage
{
	public TestPage2()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        Application.Current.MainPage = new NavigationPage(new MainPage());
    }
}