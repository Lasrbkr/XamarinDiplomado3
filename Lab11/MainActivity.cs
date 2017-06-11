using Android.App;
using Android.Widget;
using Android.OS;

namespace Lab11
{
    [Activity(Label = "Lab11", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Complex Data;
        TextView ResultadoText;
        int Counter = 0;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Android.Util.Log.Debug("Lab11log", "Activity A - OnCreate");
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            ResultadoText = FindViewById<TextView>(Resource.Id.ResultValidateText);
            FindViewById<Button>(Resource.Id.StartActivity).Click += (s, e) =>
            {
                var ActivityIntent = new Android.Content.Intent(this, typeof(SecondActivity));
                StartActivity(ActivityIntent);
            };

            Data = (Complex)this.FragmentManager.FindFragmentByTag("Data");
            if (Data == null)
            {
                //no ha sido almacenado y se agrega el fragmento a la activity
                Data = new Complex();
                Data.Validado = false;
                var FragmentTransaction = this.FragmentManager.BeginTransaction();
                FragmentTransaction.Add(Data, "Data");
                FragmentTransaction.Commit();
            }
            if (bundle != null)
            {
                Counter = bundle.GetInt("CounterValue", 0);

                Android.Util.Log.Debug("Lab11log", "Activity A - Recovered Instance State");
            }

            ResultadoText.Text = Data.Resultado;

            var ClickCounter = FindViewById<Button>(Resource.Id.ClicksCounter);
            ClickCounter.Text = Resources.GetString(Resource.String.ClicksCounter_Text, Counter);
            ClickCounter.Text += $"\n{Data.ToString()}";

            ClickCounter.Click += (s, e) =>
            {
                Counter++;
                ClickCounter.Text = Resources.GetString(Resource.String.ClicksCounter_Text, Counter);

                //Modificar con cualquier valor para verificar persistencia
                Data.Real++;
                Data.Imaginary++;
                //Mostrar el valor de los miembros
                ClickCounter.Text += $"\n{Data.ToString()}";
            };

            if (!Data.Validado)
                ValidateLab11();
        }

        private async void ValidateLab11()
        {
            SALLab11.ServiceClient ServiceClient = new SALLab11.ServiceClient();
            string StudentEmail = "micorreo";
            string Password = "micontraseña";
            string myDevice = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);

            SALLab11.ResultInfo Result = await ServiceClient.ValidateAsync(StudentEmail, Password, myDevice);

            ResultadoText.Visibility = Android.Views.ViewStates.Visible;
            ResultadoText.Text = $"{Result.Status}\n{Result.Fullname}\n{Result.Token}";
            Data.Resultado = $"{Result.Status}\n{Result.Fullname}\n{Result.Token}";
            Data.Validado = true;
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            outState.PutInt("CounterValue", Counter);
            Android.Util.Log.Debug("Lab11log", "Activity A - OnSaveInstance");

            base.OnSaveInstanceState(outState);
        }

        protected override void OnStart()
        {
            base.OnStart();
            Android.Util.Log.Debug("Lab11log", "Activity A - OnStart");
        }

        protected override void OnResume()
        {
            base.OnResume();
            Android.Util.Log.Debug("Lab11log", "Activity A - OnResume");
        }

        protected override void OnPause()
        {
            base.OnPause();
            Android.Util.Log.Debug("Lab11log", "Activity A - OnPause");
        }

        protected override void OnStop()
        {
            base.OnStop();
            Android.Util.Log.Debug("Lab11log", "Activity A - OnStop");
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            Android.Util.Log.Debug("Lab11log", "Activity A - OnDestroy");
        }

        protected override void OnRestart()
        {
            base.OnRestart();
            Android.Util.Log.Debug("Lab11log", "Activity A - OnRestart");
        }
    }
}