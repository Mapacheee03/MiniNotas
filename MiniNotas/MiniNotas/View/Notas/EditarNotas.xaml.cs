using MiniNotas.Model;
using MiniNotas.ViewModel.Notas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MiniNotas.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditarNotas : ContentPage
    {
        public EditarNotas(Mnotas Notitas)
        {
            InitializeComponent();
            BindingContext = new VMEditar(Navigation, Notitas);
        }

       
    }

    
}