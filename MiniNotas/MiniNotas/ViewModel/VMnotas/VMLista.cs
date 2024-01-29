using MiniNotas.Datos;
using MiniNotas.Model;
using MiniNotas.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using MiniNotas.ModelView;

namespace MiniNotas.ViewModel
{
    public class VMLista : BaseViewModel
    {
        #region VARIABLES
        List<Mnotas> _ListaNota;
        string _TxtTitulo;
        string _TxtNota;
        public Mnotas _Notas { get; set; }
        #endregion

        #region CONSTRUCTOR
        public VMLista(INavigation navigation)
        {
            Navigation = navigation;
            MostrarNota();
        }
        #endregion

        #region OBJETO
        public string TxtTitulo
        {
            get { return _Notas.Titulo; }
            set { SetValue(ref _TxtTitulo, value); }
        }
        public string TxtNota
        {
            get { return _Notas.Nota; }
            set { SetValue(ref _TxtNota, value); }
        }
        public List<Mnotas> ListaNotas
        {
            get { return _ListaNota; }
            set
            {
                SetValue(ref _ListaNota, value);
                OnpropertyChanged();
            }
        }

    
        #endregion

        #region PROCESO
        private async Task EliminarNota(Mnotas nota)
        {
            bool confirmacion = await Application.Current.MainPage.DisplayAlert("Eliminar Nota", "¿Estás seguro de que quieres Eliminar la nota?", "Sí", "Cancelar");
            if (confirmacion)
            {
                var funcion = new DNotas();
                await funcion.EliminarNotas(nota);
                await MostrarNota();

            }
           
        }

        public async Task MostrarNota()
        {
            var funcion = new DNotas();
            ListaNotas = await funcion.MostrarNotas();
        }

        public async Task GoRegistrar()
        {
            await Navigation.PushAsync(new RegistarNota());
        }

        public async Task GoEditar(Mnotas notas)
        {
            await Navigation.PushAsync(new EditarNotas(notas));
        }
        #endregion

        #region COMANDO
        public ICommand IraRegistrocommand => new Command(async () => await GoRegistrar());
        public ICommand EliminarNotaCommand => new Command<Mnotas>(async (nota) => await EliminarNota(nota));
        public ICommand IraEditarcommand => new Command<Mnotas>(async (n) => await GoEditar(n));
        #endregion
    }
}
