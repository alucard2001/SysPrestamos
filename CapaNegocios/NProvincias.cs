using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocios
{
    public class NProvincias
    {
        //Método Insertar que llama al método Insertar de la clase 
        //de la CapaDatos
        public static string Insertar(string nombre)
        {
            DProvincias Obj = new DProvincias();
            Obj.Provincia = nombre;
            
            return Obj.Insertar(Obj);
        }

        //Método Editar que llama al método Editar de la clase 
        //de la CapaDatos
        public static string Editar(int codigoprovincia, string nombre)
        {
            DProvincias Obj = new DProvincias();
            Obj.CodigoProvincia = codigoprovincia;
            Obj.Provincia= nombre;
           
            return Obj.Editar(Obj);
        }

        //Método Eliminar que llama al método Eliminar de la clase 
        //de la CapaDatos
        public static string Eliminar(int codigoprovincia)
        {
            DProvincias Obj = new DProvincias();
            Obj.CodigoProvincia = codigoprovincia;
            return Obj.Eliminar(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase 
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return new DProvincias().Mostrar();
        }

        //Método BuscarNombre que llama al método BuscarNombre
        //de la clase  de la CapaDatos

        public static DataTable BuscarNombre(string textobuscar)
        {
            DProvincias Obj = new DProvincias();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }

    }
}
