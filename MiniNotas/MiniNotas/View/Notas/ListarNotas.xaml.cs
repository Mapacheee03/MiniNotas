using Xamarin.Forms;
using MiniNotas.ViewModel;
using System;
using Xamarin.Forms.Xaml;
using MiniNotas.Model;

namespace MiniNotas.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListarNotas : ContentPage
    {
        VMLista vM;

        // Constructor sin parámetros
        public ListarNotas()
        {
            InitializeComponent();
            vM = new VMLista(Navigation);
            BindingContext = vM;
            this.Appearing += ListarNotas_Appearing;
            this.Disappearing += ListarNotas_Disappearing;

        }

        private void ListarNotas_Disappearing(object sender, System.EventArgs e)
        {
            // Cancelar la suscripción al mensaje "NotaEliminada"
            MessagingCenter.Unsubscribe<VMLista, string>(this, "NotaEliminada");
        }

        // Método para mostrar el mensaje emergente
        private async void ShowMessage(string message)
        {
            await DisplayAlert("Mensaje", message, "OK");
        }

        private void ListarNotas_Appearing(object sender, EventArgs e)
        {
            // Utiliza la variable this como contexto en lugar de sender
            MessagingCenter.Subscribe<VMLista, string>(this, "NotaEliminada", (context, message) => ShowMessage(message));
            vM.MostrarNota(); // Espera a que se muestren las notas
        }

        private async void OnEliminarButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            // Realiza la animación tipo POP
            await button.ScaleTo(1.2, 100, Easing.CubicOut);
            await button.ScaleTo(1, 100, Easing.CubicIn);

        }
    }
}
