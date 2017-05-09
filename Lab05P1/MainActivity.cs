﻿using Android.App;
using Android.Widget;
using Android.OS;

namespace Lab05P1
{
    [Activity(Label = "Phone App", MainLauncher = true)]
    public class MainActivity : Activity
    {
        string TranslatedNumber = string.Empty;
        EditText PhoneNumberText;
        Button TranslateButton;
        Button CallButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            PhoneNumberText = FindViewById<EditText>(Resource.Id.PhoneNumberText);
            TranslateButton = FindViewById<Button>(Resource.Id.TranslateButton);
            CallButton = FindViewById<Button>(Resource.Id.CallButton);

            CallButton.Enabled = false;

            TranslateButton.Click += TranslateButton_Click;
            CallButton.Click += CallButton_Click;
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
                // Crear un intento para marcar el número telefónico
                var CallIntent = new Android.Content.Intent(Android.Content.Intent.ActionCall);
                CallIntent.SetData(Android.Net.Uri.Parse($"tel:{TranslatedNumber}"));

                StartActivity(CallIntent);
            });
            CallDialog.SetNegativeButton("Cancelar", delegate { });
            // Mostrar el cuadro de diálogo al usuario y esperar una respuesta.
            CallDialog.Show();
        }
    }
}