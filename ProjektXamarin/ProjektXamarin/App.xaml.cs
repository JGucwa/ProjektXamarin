using ProjektXamarin.Base;
using System;
using System.IO;
using ProjektXamarin.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjektXamarin
{
    public partial class App : Application
    {
        private static App _instance;

        public static App Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new App();
                }
                return _instance;
            }
        }

        public int UserId = -1;
        public int CompanyId = -1;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage( new FlyoutPage1());
            //MainPage = new AddOffer();
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
