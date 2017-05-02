using Android.App;
using Android.Widget;
using Android.OS;

namespace AndroidAppLab04
{
    [Activity(Label = "AndroidAppLab04", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            //SetContentView(Resource.Layout.Main);

            var Validator = new PCLProject.AppValidator(new AndroidDialog(this));
            Validator.EMail = "tuusuario";
            Validator.Password = "tucontraseña";
            Validator.Device = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);
            Validator.Validate();
        }
    }
}