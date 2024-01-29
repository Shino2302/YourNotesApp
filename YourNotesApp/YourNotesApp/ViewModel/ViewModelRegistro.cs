using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using YourNotesApp.Model;
using YourNotesApp.Servicios;

namespace YourNotesApp.ViewModel
{
    public class ViewModelRegistro : BaseViewModel
    {
        #region VARIABLES
        private string _nombre;
        private string _apellido;
        private string _nombreDeUsuario;
        private string _email;
        private string _password;
        //private string _profilePicture;
        #endregion
        #region CONSTRUCTOR
        public ViewModelRegistro(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion
        #region OBJETOS
        public string Nombre
        {
            get { return _nombre; }
            set { SetValue(ref _nombre, value); }
        }
        public string Apellido
        {
            get { return _apellido; }
            set { SetValue(ref _apellido, value); }
        }
        public string NombreDeUsuario
        {
            get { return _nombreDeUsuario; }
            set { SetValue(ref _nombreDeUsuario, value); }
        }
        public string Email
        {
            get { return _email; }
            set { SetValue(ref _email, value); }
        }
        public string Password
        {
            get { return _password; }
            set { SetValue(ref _password, value); }
        }
        //public string ProfilePicture
        //{
        //    get { return _profilePicture; }
        //    set { SetValue(ref _profilePicture, value); }
        //}
        #endregion
        #region PROCESOS
        public async Task RegistrarUsuario()
        {
            Usuario oUsuario = new Usuario()
            {
                Nombre = _nombre,
                Apellido = _apellido,
                NombreDeUsuario = _nombreDeUsuario,
                Email = _email,
                Password = _password
            };
            bool respuesta = await ApiServiceAuthentication.RegistrarUsuario(oUsuario);

            if (!respuesta)
                await DisplayAlert("Tenemos un problema", "No pudimos registrar a tu usuario, vuelvalo a intentar en unos minutos", "Aceptar");
            else
            {
                ResponseAuthentication response 
                await ApiServicesFirebase.RegistrarUsuario(oUsuario,)
                await DisplayAlert("Esta Hecho!", $"El usuario {oUsuario.NombreDeUsuario} a sido registrado exitosamente", "Continuar");
                await Navigation.PushAsync(new Login());
            }        
        }
        public async void RegresarALogin()
        {
            await Navigation.PopAsync();
        }
        #endregion

        #region COMANDOS
        public ICommand RegistrarUsuarioCommand => new Command(async () => await RegistrarUsuario());
        public ICommand RegresarALoginCommand => new Command(async () => await RegistrarUsuario());
        #endregion
    }
}
