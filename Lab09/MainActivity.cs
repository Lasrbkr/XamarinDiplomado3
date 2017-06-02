using Android.App;
using Android.Widget;
using Android.OS;

namespace Lab09
{
    [Activity(Label = "Lab09", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        TextView txtNombre;
        TextView txtEstatus;
        TextView txtToken;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            txtNombre = FindViewById<TextView>(Resource.Id.NameValue);
            txtEstatus = FindViewById<TextView>(Resource.Id.StatusValue);
            txtToken = FindViewById<TextView>(Resource.Id.TokenValue);

            Validate();
        }

        private async void Validate()
        {
            SALLab09.ServiceClient ServiceClient = new SALLab09.ServiceClient();
            string StudentEmail = "tucorreo";
            string Password = "contraseña";
            string myDevice = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);

            SALLab09.ResultInfo Result = await ServiceClient.ValidateAsync(StudentEmail, Password, myDevice);

            txtNombre.Text = Result.Fullname;
            txtEstatus.Text = Result.Status.ToString();
            txtToken.Text = Result.Token;
        }
    }
}