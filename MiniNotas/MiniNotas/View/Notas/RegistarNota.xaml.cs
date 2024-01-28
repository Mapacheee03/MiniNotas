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

            // Cambia el color del botón a verde para indicar éxito
            button.BackgroundColor = Color.Green;

            // Escala el botón a 1.2
            await button.ScaleTo(1.2, 200, Easing.SinOut);
            await Task.Delay(200);

            // Vuelve a escalar el botón a 1 y restaura el color original
            await button.ScaleTo(1, 200, Easing.SinOut);
            button.BackgroundColor = Color.FromHex("#FEC100"); // Color original del botón

            // Muestra un mensaje de éxito
            await DisplayAlert("Éxito", "La nota se agregó exitosamente.", "Aceptar");
        }
    }
}