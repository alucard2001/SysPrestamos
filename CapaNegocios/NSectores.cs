using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocios
{
    public class NSectores
    {
        //Método Insertar que llama al método Insertar de la clase 
        //de la CapaDatos
        public static string Insertar(string nombre,int codigo_provincia)
        {
            DSectores Obj = new DSectores();
            Obj.Sector = nombre;
            Obj.CodigoProvincia = codigo_provincia;

            return Obj.Insertar(Obj);
        }

        //Método Editar que llama al método Editar de la clase 
        //de la CapaDatos
        public static string Editar(int codigo_sector, string nombre, int codigoprovincia)
        {
            DSectores Obj = new DSectores();
            Obj.CodigoSector = codigo_sector;
            Obj.Sector = nombre;
            Obj.CodigoProvincia = codigoprovincia;


            return Obj.Editar(Obj);
        }

        //Método Eliminar que llama al método Eliminar de la clase 
        //de la CapaDatos
        public static string Eliminar(int codigo_sector)
        {
            DSectores Obj = new DSectores();
            Obj.CodigoSector = codigo_sector;
            return Obj.Eliminar(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase 
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return new DSectores().Mostrar();
        }

        //Método BuscarNombre que llama al método BuscarNombre
        //de la clase  de la CapaDatos

        public static DataTable BuscarNombre(string textobuscar)
        {
            DSectores Obj = new DSectores();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }

    }
}
