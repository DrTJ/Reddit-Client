using Xamarin.Forms;

namespace RedditClient
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new RedditClientPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
