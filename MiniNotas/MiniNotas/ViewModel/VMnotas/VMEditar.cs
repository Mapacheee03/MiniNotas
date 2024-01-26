using MiniNotas.Datos;
using MiniNotas.Model;
using MiniNotas.ModelView;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MiniNotas.ViewModel.Notas
{
    public class VMEditar : BaseViewModel
    {
        #region VARIABLES
        string _TxtTitulo;
        string _TxtNota;
        public Mnotas _Notas { get; set; }
        #endregion
        #region CONSTRUCTOR
        public VMEditar(INavigation navigation, Mnotas notas)
        {
            Navigation = navigation;
            _Notas = notas;
        }
        #endregion
        #region OBJETOS
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
        #endregion
        #region PROCESO
        public async Task Editar()
        {
            var funcion = new DNotas();
            var parametros = new Mnotas();
            parametros.IdNota = _Notas.IdNota;
            parametros.Titulo = TxtTitulo;
            parametros.Nota = TxtNota;

            await funcion.ActualizarNotas(parametros);
            await Volver();
        }
        public async Task Eliminar()
        {

            var funcion = new DNotas();
            await funcion.EliminarNotas(_Notas);
            await Volver(); ;
        }
        public async Task Volver()
        {
            await Navigation.PopAsync();
        }
        #endregion
        #region COMANDOS
        public ICommand Editarcommand => new Command(async () => await Editar());
        public ICommand Eliminarcommand => new Command(async () => await Eliminar());
        public ICommand Volvercommand => new Command(async () => await Volver());

        #endregion
    }
}
