using Android.App;
using Android.Widget;
using Android.OS;

namespace AndroidAppLab03
{
    [Activity(Label = "AndroidAppLab03", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            //SetContentView(Resource.Layout.Main);

            var Helper = new SharedProjectLab03.MySharedCode();
            new AlertDialog.Builder(this).SetMessage(Helper.GetFilePath("demo.dat")).Show();

            //Validate();
        }

        private async void Validate()
        {
            SALLab03.ServiceClient ServiceClient = new SALLab03.ServiceClient();
            string StudentEmail = "tucorreo";
            string Password = "tucontraseña";
            string myDevice = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);

            SALLab03.ResultInfo Result = await ServiceClient.ValidateAsync(StudentEmail, Password, myDevice);

            Android.App.AlertDialog.Builder Builder = new AlertDialog.Builder(this);
            AlertDialog Alert = Builder.Create();
            Alert.SetTitle("Resultado de la verificación");
            Alert.SetMessage($"{Result.Status}\n{Result.Fullname}\n{Result.Token}");
            Alert.SetButton("Ok", (s, ev) => { });
            Alert.Show();
        }
    }
}