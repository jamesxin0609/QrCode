using Android.Opengl;
using Xamarin.Forms;
using System.Reflection.Emit;
using System.Threading;
using Java.Sql;
using Java.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Content.PM;

namespace QrParse.Droid
{
    [Activity(MainLauncher = true, NoHistory = true, Theme = "@style/Theme.Splash",
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class SplashScreen : Activity
    {
        int m_nSenconds = 3;
        TextView m_labelTimer;
        System.Threading.Timer timer;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.StartUI);
            TimerCallback timerDeledate = new TimerCallback(CheckStatus);
            timer = new System.Threading.Timer(timerDeledate, null, 1000, 1000);
            TextView text = (TextView)FindViewById(Resource.Id.textView1);
            string str = string.Format("倒计时：{0} 秒", m_nSenconds);
            text.SetText(str, TextView.BufferType.Normal);
            // Create your application here

        }

        private void CheckStatus(object state)
        {
            RunOnUiThread(() => 
            {
                m_nSenconds--;
                TextView text = (TextView)FindViewById(Resource.Id.textView1);
                string str = string.Format("倒计时：{0} 秒", m_nSenconds);
                text.SetText(str, TextView.BufferType.Normal);
                if (m_nSenconds == 0)
                {

                    timer.Dispose();
                    var intent = new Intent(this, typeof(MainActivity));
                    StartActivity(intent);
                    Finish();
                }
            });
            

            
            
        }
    }
}