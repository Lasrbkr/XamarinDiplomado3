using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace Lab05P1
{
    [Activity(Label = "Phone App", MainLauncher = true)]
    public class MainActivity : Activity
    {
        string TranslatedNumber = string.Empty;
        EditText PhoneNumberText;
        TextView ResultText;
        Button TranslateButton;
        Button CallButton;
        Button CallHistoryButton;
        static readonly List<string> PhoneNumbers = new List<string>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            PhoneNumberText = FindViewById<EditText>(Resource.Id.PhoneNumberText);
            ResultText = FindViewById<TextView>(Resource.Id.ResultText);
            TranslateButton = FindViewById<Button>(Resource.Id.TranslateButton);
            CallButton = FindViewById<Button>(Resource.Id.CallButton);
            CallHistoryButton = FindViewById<Button>(Resource.Id.CallHistory);

            CallButton.Enabled = false;

            TranslateButton.Click += TranslateButton_Click;
            CallButton.Click += CallButton_Click;
            CallHistoryButton.Click += CallHistoryButton_Click;

            //Validate();
            ValidateLab06();
        }

        void TranslateButton_Click(object sender, System.EventArgs e)
        {
            PhoneTranslator translator = new PhoneTranslator();
            TranslatedNumber = translator.ToNumber(PhoneNumberText.Text);
            if (string.IsNullOrWhiteSpace(TranslatedNumber))
            {
                CallButton.Text = "Llamar";
                CallButton.Enabled = false;
            }
            else
            {
                CallButton.Text = $"Llamar al {TranslatedNumber}";
                CallButton.Enabled = true;
            }
        }

        void CallButton_Click(object sender, System.EventArgs e)
        {
            // Intentar marcar el número telefónico
            var CallDialog = new AlertDialog.Builder(this);
            CallDialog.SetMessage($"Llamar al número {TranslatedNumber}?");
            CallDialog.SetNeutralButton("Llamar", delegate
            {
                PhoneNumbers.Add(TranslatedNumber);
                CallHistoryButton.Enabled = true;
                // Crear un intento para marcar el número telefónico
                var CallIntent = new Android.Content.Intent(Android.Content.Intent.ActionCall);
                CallIntent.SetData(Android.Net.Uri.Parse($"tel:{TranslatedNumber}"));

                StartActivity(CallIntent);
            });
            CallDialog.SetNegativeButton("Cancelar", delegate { });
            // Mostrar el cuadro de diálogo al usuario y esperar una respuesta.
            CallDialog.Show();
        }

        void CallHistoryButton_Click(object sender, System.EventArgs e)
        {
            var Intent = new Android.Content.Intent(this, typeof(CallHistoryActivity));
            Intent.PutStringArrayListExtra("phone_numbers", PhoneNumbers);

            StartActivity(Intent);
        }

        private async void Validate()
        {
            SALLab05.ServiceClient ServiceClient = new SALLab05.ServiceClient();
            string StudentEmail = "tucorreo";
            string Password = "tucontraseña";
            string myDevice = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);

            SALLab05.ResultInfo Result = await ServiceClient.ValidateAsync(StudentEmail, Password, myDevice);

            ResultText.Text = $"{Result.Status}\n{Result.Fullname}\n{Result.Token}";
        }
        private async void ValidateLab06()
        {
            SALLab06.ServiceClient ServiceClient = new SALLab06.ServiceClient();
            string StudentEmail = "tucorreo";
            string Password = "tucontraseña";
            string myDevice = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);

            SALLab06.ResultInfo Result = await ServiceClient.ValidateAsync(StudentEmail, Password, myDevice);

            ResultText.Text = $"{Result.Status}\n{Result.Fullname}\n{Result.Token}";
        }
    }
}