using Firebase.Database.Query;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;
using Xamarin.Essentials;
using LiteDB;
using System.Linq;
using MiniNotas.Conexion;
using MiniNotas.Model;


namespace MiniNotas.Datos
{
    public class DNotas
    {
        public async Task InsertarNota(Mnotas parametros)
        {
            await Cconexion.firebase.Child("Notas").PostAsync(new Mnotas
            {
                IdNota = parametros.IdNota,
                Titulo = parametros.Titulo,
                Nota = parametros.Nota

            });
        }
        public async Task<List<Mnotas>> MostrarNotas()
        {
            return (await Cconexion.firebase.Child("Notas")
                .OnceAsync<Mnotas>())
                .Select(item => new Mnotas
                {
                    IdNota = item.Key,
                    Titulo = item.Object.Titulo,
                    Nota = item.Object.Nota
                }).ToList();
        }
        public async Task EliminarNotas(Mnotas mnotas)
        {
            string id = mnotas.IdNota;
            await Cconexion.firebase.Child("Notas").Child(id).DeleteAsync();
        }
        public async Task ActualizarNotas(Mnotas parametros)
        {
            await Cconexion.firebase.Child("Notas").Child(parametros.IdNota).PutAsync(new Mnotas
            {
                IdNota = parametros.IdNota,
                Titulo = parametros.Titulo,
                Nota = parametros.Nota
            });
        }
    }
}
