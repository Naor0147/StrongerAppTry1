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
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            App.Current.MainPage = new NavigationPage(new NewPage1());
            Image1.Source = ImageSource.FromFile("incline_dumbbell_bench_press.png");

        }
    }

}
