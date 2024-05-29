using StrongerAppTry1.Pages;

namespace StrongerAppTry1
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string text = button.Text;
            switch (text)
            {
                case "Exercise":
                    App.Current.MainPage = new NavigationPage(new NewPage1());

                    break;
                case "Exercises_Page":
                    App.Current.MainPage = new NavigationPage(new Excerics_Page());

                    break;
                case "Test":
                    App.Current.MainPage = new NavigationPage(new NewPage2());

                    break;


            }
           

        }
    }

}
