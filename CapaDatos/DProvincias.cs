using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DProvincias
    {
        //Declaracion Variables
        private int _CodigoProvincia;
        private string _Provincia;
        private string _TextoBuscar;

        //Encasulamiento Get & Set
        public int CodigoProvincia
        {
            get { return _CodigoProvincia; }
            set { _CodigoProvincia = value; }
        }

        public string Provincia
        {
            get { return _Provincia; }
            set { _Provincia = value; }
        }

        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }

        //Constructor Vacío
        public DProvincias()
        {

        }

        //Constructor con parámetros
        public DProvincias(int codigoprovincia, string provincia, string textobuscar)
        {
            this.CodigoProvincia = codigoprovincia;
            this.Provincia = provincia;
            this.TextoBuscar = textobuscar;
        }

        //Método Insertar
        public string Insertar(DProvincias Provincias)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código
                SqlCon.ConnectionString = Connetion.Cn;
                SqlCon.Open();
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsertar_Provincias";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParCodigoProvincia = new SqlParameter();
                ParCodigoProvincia.ParameterName = "@codigo";
                ParCodigoProvincia.SqlDbType = SqlDbType.Int;
                ParCodigoProvincia.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParCodigoProvincia);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Provincias.Provincia;
                SqlCmd.Parameters.Add(ParNombre);

                              //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;

        }

        //Método Editar
        public string Editar(DProvincias Provincias)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código
                SqlCon.ConnectionString = Connetion.Cn;
                SqlCon.Open();
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_Provincias";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                SqlParameter ParCodigoProvincia = new SqlParameter();
                ParCodigoProvincia.ParameterName = "@codigo";
                ParCodigoProvincia.SqlDbType = SqlDbType.Int;
                ParCodigoProvincia.Value = Provincias.CodigoProvincia;
                SqlCmd.Parameters.Add(ParCodigoProvincia);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Provincias.Provincia;
                SqlCmd.Parameters.Add(ParNombre);

         
                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Actualizo el Registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }

        //Método Eliminar
        public string Eliminar(DProvincias Provincias)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código
                SqlCon.ConnectionString = Connetion.Cn;
                SqlCon.Open();
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speliminar_Provincias";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParCodigoProvincia = new SqlParameter();
                ParCodigoProvincia.ParameterName = "@codigo";
                ParCodigoProvincia.SqlDbType = SqlDbType.Int;
                ParCodigoProvincia.Value = Provincias.CodigoProvincia;
                SqlCmd.Parameters.Add(ParCodigoProvincia);


                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Elimino el Registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }

        //Método Mostrar
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("Provincias");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Connetion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "Prestamos.spmostrar_Provincias";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }


        //Método BuscarNombre
        public DataTable BuscarNombre(DProvincias Provincias)
        {
            DataTable DtResultado = new DataTable("Provincias");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Connetion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_Provincias";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Provincias.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }
    }
}
