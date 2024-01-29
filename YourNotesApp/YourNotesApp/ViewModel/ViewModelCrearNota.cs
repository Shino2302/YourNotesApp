using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace YourNotesApp.ViewModel
{
    public class ViewModelCrearNota : BaseViewModel
    {
        #region VARIABLES
        private string _tituloNota;
        private string _nota;

        #endregion
        #region CONSTRUCTOR
        public ViewModelCrearNota(INavigation navigation)
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
            set {  SetValue(ref _nota, value);}
        }
        #endregion

        #region PROCESOS
        public async Task AgregarNota()
        {

        }
        #endregion

        #region COMANDOS
        public ICommand AgregarNotaCommand => new Command(async () => AgregarNota());
        #endregion
    }
}
