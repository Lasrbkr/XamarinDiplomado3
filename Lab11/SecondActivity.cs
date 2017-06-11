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

namespace Lab11
{
    [Activity(Label = "SecondActivity")]
    public class SecondActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Android.Util.Log.Debug("Lab11log", "Activity B - OnCreate");

            // Create your application here
        }

        protected override void OnStart()
        {
            base.OnStart();
            Android.Util.Log.Debug("Lab11log", "Activity B - OnStart");
        }

        protected override void OnResume()
        {
            base.OnResume();
            Android.Util.Log.Debug("Lab11log", "Activity B - OnResume");
        }

        protected override void OnPause()
        {
            base.OnPause();
            Android.Util.Log.Debug("Lab11log", "Activity B - OnPause");
        }

        protected override void OnStop()
        {
            base.OnStop();
            Android.Util.Log.Debug("Lab11log", "Activity B - OnStop");
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            Android.Util.Log.Debug("Lab11log", "Activity B - OnDestroy");
        }

        protected override void OnRestart()
        {
            base.OnRestart();
            Android.Util.Log.Debug("Lab11log", "Activity B - OnRestart");
        }
    }
}