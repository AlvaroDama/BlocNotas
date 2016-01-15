using BlocNotas.Module;
using Xamarin.Forms;

namespace BlocNotas
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            var start = new StartUp(this);
            start.Run();
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
