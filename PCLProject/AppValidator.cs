using System;
namespace PCLProject
{
    public class AppValidator
    {
        IDialog Dialog;
        public string EMail { get; set; }
        public string Password { get; set; }
        public string Device { get; set; }

        public AppValidator(IDialog platformDialog)
        {
            Dialog = platformDialog;
        }

        public async void Validate()
        {
            string Result;
            var ServiceClient = new SALLab04.ServiceClient();
            var SvcResult = await ServiceClient.ValidateAsync(EMail, Password, Device);
            /* Aquí se puede implementar la funcionalidad
             principal de la clase. Por el momento solo devuelve
             una cadena fija. */
            Result = $"{SvcResult.Status}\n{SvcResult.Fullname}\n{SvcResult.Token}";//"¡Aplicación validada!";
            /* Invocar el código específico de la plataforma */
            Dialog.Show(Result);
        }
    }
}