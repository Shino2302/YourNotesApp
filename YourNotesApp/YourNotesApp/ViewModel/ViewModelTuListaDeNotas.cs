using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using YourNotesApp.Model;
using YourNotesApp.Servicios;
using YourNotesApp.Views;

namespace YourNotesApp.ViewModel
{
    public class ViewModelTuListaDeNotas : BaseViewModel
    {
        #region VARIABLES
        private ObservableCollection<Notas> _tusNotas;

        #endregion

        #region CONSTRUCTOR
        public ViewModelTuListaDeNotas(INavigation navigation)
        {
            Navigation = navigation;
            MostrarNotas();
        }
        #endregion

        #region OBJETOS
        public ObservableCollection<Notas> TusNotas
        {
            get { return _tusNotas; }
            set { SetValue(ref _tusNotas, value);
                OnpropertyChanged();
            }
        }
        #endregion
        
        #region PROCESOS
        public async Task MostrarNotas()
        {
            Dictionary<string, Notas> oObjetos = await ApiServicesFirebase.ObtenerListaDeNotas();
            if(oObjetos != null)
            {
                if(oObjetos.Count > 0)
                {
                    foreach(KeyValuePair<string, Notas> item in oObjetos)
                    {
                        _tusNotas.Add(new Notas
                        {
                            IdNota = item.Key,
                            TituloNota = item.Value.TituloNota,
                            Nota = item.Value.Nota
                        });
                    }
                }
            }
            else
            {
                await ApiServicesFirebase.AgregarNota(new Notas
                {
                    TituloNota = "Titulo de ejemplo",
                    Nota = "Aquí va el contenido de tu nota"
                });
            }
        }
        public async void PaginaDeAgregar()
        {
            await Navigation.PushAsync(new CrearNota());
        }
        public async Task AbrirVistaModificar()
        {
            await Navigation.PushAsync(new ModificarNota());
        }
        #endregion
        
        #region COMANDOS
        public ICommand IrAPaginaAgregar => new Command(async () => PaginaDeAgregar());
        public ICommand ModificarNotaCommand => new Command(async () => AbrirVistaModificar());
        #endregion
    }
}
