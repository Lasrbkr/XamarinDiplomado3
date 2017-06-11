using System;
using Android.App;
using Android.OS;
using Android.Widget;

namespace Lab10
{
    [Activity(Label = "@string/ApplicationName", Icon = "@drawable/icon")]
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
            SetContentView(Resource.Layout.Validacion);

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
                ValidateLab10();
            }
        }

        private async void ValidateLab10()
        {
            SALLab10.ServiceClient ServiceClient = new SALLab10.ServiceClient();
            string StudentEmail = txtEmail.Text.Trim();
            string Password = txtPassword.Text.Trim();
            string myDevice = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);

            SALLab10.ResultInfo Result = await ServiceClient.ValidateAsync(StudentEmail, Password, myDevice);

            ResultadoText.Visibility = Android.Views.ViewStates.Visible;
            ResultadoText.Text = $"{Result.Status}\n{Result.Fullname}\n{Result.Token}";
        }
    }
}