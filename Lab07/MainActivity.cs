using System;
using Android.App;
using Android.OS;
using Android.Widget;

namespace Lab07
{
    [Activity(Label = "@string/ValidarActividad", Icon = "@drawable/icon")]
    public class ValidacionActivity : Activity
    {
        Button btnValidar;
        EditText txtEmail;
        EditText txtPassword;
        TextView ResultadoText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Main);

            txtEmail = FindViewById<EditText>(Resource.Id.textEmailAddress);
            txtPassword = FindViewById<EditText>(Resource.Id.textPassword);
            btnValidar = FindViewById<Button>(Resource.Id.ValidarButton);
            ResultadoText = FindViewById<TextView>(Resource.Id.ResultValidateText);

            btnValidar.Click += BtnValidar_Click;
        }

        void BtnValidar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtEmail.Text.Trim()) && !string.IsNullOrWhiteSpace(txtPassword.Text.Trim()))
            {
                ValidateLab07();
            }
        }

        private async void ValidateLab07()
        {
            SALLab07.ServiceClient ServiceClient = new SALLab07.ServiceClient();
            string StudentEmail = txtEmail.Text.Trim();
            string Password = txtPassword.Text.Trim();
            string myDevice = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);

            SALLab07.ResultInfo Result = await ServiceClient.ValidateAsync(StudentEmail, Password, myDevice);

            if(Android.OS.Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                var Builder = new Notification.Builder(this)
                    .SetContentTitle("Validación de actividad")
                    .SetContentText($"{Result.Status} {Result.Fullname} {Result.Token}")
                    .SetSmallIcon(Resource.Drawable.Icon);

                Builder.SetCategory(Notification.CategoryMessage);

                var ObjectNotification = Builder.Build();
                var Manager = GetSystemService(Android.Content.Context.NotificationService) as NotificationManager;
                Manager.Notify(0, ObjectNotification);
            }
            else
            {
                ResultadoText.Text = $"{Result.Status}\n{Result.Fullname}\n{Result.Token}";
            }
        }
    }
}