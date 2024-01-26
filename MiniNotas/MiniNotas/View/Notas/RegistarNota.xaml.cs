using MiniNotas.ViewModel.Notas;
using MiniNotas.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MiniNotas.Model;

namespace MiniNotas.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistarNota : ContentPage
    {
        public RegistarNota()
        {
            InitializeComponent();
            BindingContext = new VMInsertar(Navigation);
        }
    }
}