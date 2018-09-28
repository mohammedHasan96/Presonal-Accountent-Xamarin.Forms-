#define Run

using PersonalAccountant.Models.DataAccess;
using Plugin.Notifications;
using System;
using System.Globalization;
using System.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PersonalAccountant
{
    public partial class App : Application
    {
        readonly string ResourceId = "PersonalAccountant.Resources";
        CultureInfo ci = CultureInfo.CurrentCulture;
        public App()
        {
#if Run
            SqliteDA.InitialDB();
#endif
            if (ci.EnglishName.ToLower().Contains("arabic"))
                Values.ResourcesManager = new ResourceManager($"{ResourceId}.Ar", typeof(MainPage).Assembly);
            else
                Values.ResourcesManager = new ResourceManager($"{ResourceId}.En", typeof(MainPage).Assembly);
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
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
