using MiniNotas.ModelView;
using MiniNotas.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MiniNotas
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ListarNotas());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
