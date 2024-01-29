using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YourNotesApp.ViewModel;

namespace YourNotesApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TuListaDeNotas : ContentPage
	{
		public TuListaDeNotas ()
		{
			InitializeComponent();
			BindingContext = new ViewModelTuListaDeNotas(Navigation);
		}
	}
}