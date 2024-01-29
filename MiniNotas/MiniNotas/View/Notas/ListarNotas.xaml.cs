using Xamarin.Forms;
using MiniNotas.ViewModel;
using System;
using Xamarin.Forms.Xaml;
using MiniNotas.Model;
using System.Threading.Tasks;
using System.Collections.Generic;

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
        private void ListarNotas_Appearing(object sender, EventArgs e)
        {
            MessagingCenter.Subscribe<VMLista, string>(this, "NotaEliminada", (context, message) => ShowMessage(message));
            vM.MostrarNota(); 
        }
        private async void HandleSwipeItem(object sender, EventArgs e)
        {
            var swipeItem = (SwipeItem)sender;
            Color originalColor = swipeItem.BackgroundColor;
            List<Color> colors = new List<Color>
            {
                Color.FromRgb(255, 0, 0),   // Rojo
                Color.FromRgb(0, 255, 0),   // Verde
                Color.FromRgb(0, 0, 255)    // Azul
            };
            foreach (Color color in colors)
            {
                swipeItem.BackgroundColor = color;
                await Task.Delay(2000); 
            }
            swipeItem.BackgroundColor = originalColor;
        }

    }
}
