#region Referencias
using System;
using Android.App;
using Android.Widget;
using Android.OS;
using XamarinDiplomado;
#endregion
namespace Lab1
{
    [Activity(Label = "Lab1", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Button button;
        TextView textViewDev;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            button = FindViewById<Button>(Resource.Id.MyButton);
            textViewDev = FindViewById<TextView>(Resource.Id.textViewDev);

            button.Click += Button_Click;

        }

        async void Button_Click(object sender, EventArgs e)
        {
            textViewDev.Text = "Luis Antonio Salas";
            string mydevice = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);
            ServiceHelper service = new ServiceHelper();
            await service.InsertarEntidad("your email", "lab1", mydevice);
            button.Text = "Gracias por completar el lab1";
        }
    }
}