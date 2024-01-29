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

        private async void OnInsertarButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackgroundColor = Color.Green;
            await button.ScaleTo(1.2, 200, Easing.SinOut);
            await Task.Delay(200);
            await button.ScaleTo(1, 200, Easing.SinOut);
            button.BackgroundColor = Color.FromHex("#FEC100"); 
            await DisplayAlert("Éxito", "La nota se agregó exitosamente.", "Aceptar");
        }
    }
}