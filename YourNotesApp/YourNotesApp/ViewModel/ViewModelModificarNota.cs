using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace YourNotesApp.ViewModel
{
    class ViewModelModificarNota : BaseViewModel
    {
        #region VARIABLES
        private string _tituloNota;
        private string _nota;

        #endregion
        #region CONSTRUCTOR
        public ViewModelModificarNota(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion
        #region OBJETOS
        public string TituloNota
        {
            get { return _tituloNota; }
            set { SetValue(ref _tituloNota, value); }
        }
        public string Nota
        {
            get { return _nota; }
            set { SetValue(ref _nota, value); }
        }
        #endregion
        #region PROCESOS
        public async void VolverALista()
        {
            await Navigation.PopAsync();
        }
        public async Task ModificarNota()
        {
            VolverALista();
        }
        #endregion
        #region COMANDOS
        public ICommand VolverAListaCommand => new Command(async () => VolverALista());
        public ICommand ModificarNotaCommand => new Command(async () => ModificarNota());
        #endregion
    }
}
