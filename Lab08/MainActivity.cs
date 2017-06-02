using Android.App;
using Android.Widget;
using Android.OS;

namespace Lab08
{
    [Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/icon")]
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

            //var ViewGroup = (Android.Views.ViewGroup)Window.DecorView.FindViewById(Android.Resource.Id.Content);
            //var MainLayout = ViewGroup.GetChildAt(0) as LinearLayout;
            //MainLayout.SetPadding(10, 10, 10, 10);
            //var HeaderImage = new ImageView(this);
            //HeaderImage.SetImageResource(Resource.Drawable.Xamarin_Diplomado_30);
            //MainLayout.AddView(HeaderImage);

            //var UserNameTextView = new TextView(this);
            //UserNameTextView.Text = GetString(Resource.String.UserName);
            //MainLayout.AddView(UserNameTextView);
            Validate();
        }

        private async void Validate()
        {
            SALLab08.ServiceClient ServiceClient = new SALLab08.ServiceClient();
            string StudentEmail = "tucorreo";
            string Password = "tucontraseña";
            string myDevice = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);

            SALLab08.ResultInfo Result = await ServiceClient.ValidateAsync(StudentEmail, Password, myDevice);

            txtNombre.Text = Result.Fullname;
            txtEstatus.Text = Result.Status.ToString();
            txtToken.Text = Result.Token;
        }
    }
}

