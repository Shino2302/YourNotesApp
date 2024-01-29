using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using YourNotesApp.Model;
using YourNotesApp.Servicios;
using YourNotesApp.Views;

namespace YourNotesApp.ViewModel
{
    public class ViewModelLogin : BaseViewModel
    {
        #region VARIABLES
        private string _email;
        private string _password;
        #endregion

        #region CONSTRUCTOR
        public ViewModelLogin(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region OBJETOS
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
        #endregion
        
        #region PROCESOS
        public async void Ingresar()
        {
            UserAuthentication oUsuario = new UserAuthentication()
            {
                Email = _email,
                Password = _password,
                ReturnSecureToken = true
            };

            bool respuesta = await ApiServiceAuthentication.Login(oUsuario);
            if (!respuesta)
                await DisplayAlert("Tenemos un problema", "Usuario no encontrado", "OK");
            else
                Application.Current.MainPage = new NavigationPage(new TuListaDeNotas());
        }
        #endregion
        
        #region COMANDOS
        public ICommand IngresarCommand => new Command(Ingresar);
        #endregion
    }
}
