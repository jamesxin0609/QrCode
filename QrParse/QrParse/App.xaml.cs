using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using ZXing.Mobile;

namespace QrParse
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            NavigationPage NaviPage = new NavigationPage(new QrParse.MainPage());
            MainPage = NaviPage;
            //NaviPage.BarBackgroundColor = new Color(186, 85, 211); 

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
