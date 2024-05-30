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
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        Application.Current.MainPage = new NavigationPage(new MainPage());

    }
}