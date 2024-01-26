using MiniNotas.ViewModel.Notas;
using MiniNotas.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MiniNotas.ViewModel;

namespace MiniNotas.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListarNotas : ContentPage
    {
        VMLista vM;
        public ListarNotas()
        {
            InitializeComponent();
            vM = new VMLista(Navigation);
            BindingContext = vM;
            this.Appearing += ListarNotas_Appearing;

        }
        private async void ListarNotas_Appearing(object sender, EventArgs e)
        {
            await vM.MostrarNota();
        }
    }
}