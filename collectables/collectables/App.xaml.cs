using collectables.Services;
using collectables.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace collectables
{
    public partial class App : Application
    {

        public static string DatabaseLocation { get; private set; } 

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        

        public App(string databaseLocation) : this()
        {
            InitializeComponent();
            if (databaseLocation == null)
            {
                throw new ArgumentNullException(nameof(databaseLocation));
            }

            DatabaseLocation = databaseLocation;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
