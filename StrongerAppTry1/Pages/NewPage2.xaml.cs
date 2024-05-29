namespace StrongerAppTry1.Pages;

public partial class NewPage2 : ContentPage
{
	public NewPage2()
	{
		InitializeComponent();
        Border border = new Border();
        border.Style = (Style)Application.Current.Resources["CustomBorderSmallStyle"];
        Label labelx = new Label();
        labelx.Text = "40";
        labelx.Style = (Style)Application.Current.Resources["CustomLabelSetStyle"];
        border.Content =(labelx);

        RepStack.Add(border);
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        Application.Current.MainPage = new NavigationPage(new MainPage());

    }
}