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
	public partial class ModificarNota : ContentPage
	{
		public ModificarNota ()
		{
			InitializeComponent();
			BindingContext = new ViewModelModificarNota(Navigation);
		}
	}
}