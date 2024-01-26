using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniNotas.Conexion
{
    public class Cconexion
    {
        public static FirebaseClient firebase = new FirebaseClient("https://mininotas-c9c93-default-rtdb.firebaseio.com/Notas");
    }
}
