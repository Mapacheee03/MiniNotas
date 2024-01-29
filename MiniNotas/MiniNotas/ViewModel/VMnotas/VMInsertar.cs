using MiniNotas.Model;
using MiniNotas.Datos;
using MiniNotas.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using MiniNotas.ModelView;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MiniNotas.ViewModel.Notas
{
    public class VMInsertar : BaseViewModel
    {
        #region VARIABLES
       
        string _Txtidnota;
        string _TxtTitulo;
        string _TxtNota;
        #endregion
        #region COSNTRUCTOR
        public VMInsertar(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion
        #region OBJETOS
    
        public string Txtidnota
        {
            get { return _Txtidnota; }
            set { SetValue(ref _Txtidnota, value); }
        }
        public string TxtTitulo
        {
            get { return _TxtTitulo; }
            set { SetValue(ref _TxtTitulo, value); }
        }
        public string TxtNota
        {
            get { return _TxtNota; }
            set { SetValue(ref _TxtNota, value); }
        }
        #endregion
        #region PROCESOS
        public async Task Insertar()
        {
            var funcion = new DNotas();
            var parametros = new Mnotas();
            parametros.Nota = TxtNota;
            parametros.Titulo = TxtTitulo;
            await funcion.InsertarNota(parametros);
            await Task.Delay(1000); 

            await Volver();
            
        }
       
        public async Task Volver()
        {
            await Navigation.PopAsync();
        }
        #endregion
        #region COMANDOS
        public ICommand Insertarcommand => new Command(async () => await Insertar());
        public ICommand Volvercommand => new Command(async () => await Volver());   
        #endregion

    }
}
