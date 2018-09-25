using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DSectores
    {
        //Declaracion Variables
        private int _CodigoSector;
        private string _Sector;
        private int _CodigoProvincia;
        
        private string _TextoBuscar;

        //Encasulamiento Get & Set
        public int CodigoSector
        {
            get { return _CodigoSector; }
            set { _CodigoSector = value; }
        }
        
        public string Sector
        {
            get { return _Sector; }
            set { _Sector = value; }
        }
        
        public int CodigoProvincia
        {
            get { return _CodigoProvincia; }
            set { _CodigoProvincia = value; }
        }
               
        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }

        //Constructor Vacío
        public DSectores()
        {

        }

        //Constructor con parámetros
        public DSectores(int codigo_sectores, string sector, int codigo_provincia, string textobuscar)
        {
            this.CodigoSector = codigo_sectores;
            this.Sector = sector;
            this.CodigoProvincia = CodigoProvincia;

            this.TextoBuscar = textobuscar;
        }

         //Método Insertar
        public string Insertar(DSectores Sectores)
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
                SqlCmd.CommandText = "Prestamos.spinsertar_Sectores";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParCodigo_Sector = new SqlParameter();
                ParCodigo_Sector.ParameterName = "@codigo";
                ParCodigo_Sector.SqlDbType = SqlDbType.Int;
                ParCodigo_Sector.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParCodigo_Sector);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Sectores.Sector;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParCodigoProvincia = new SqlParameter();
                ParCodigoProvincia.ParameterName = "@codigo_provincia";
                ParCodigoProvincia.SqlDbType = SqlDbType.Int;
                ParCodigoProvincia.Value = Sectores.CodigoProvincia;
                SqlCmd.Parameters.Add(ParCodigoProvincia);

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
        public string Editar(DSectores Sectores)
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
                SqlCmd.CommandText = "Prestamos.speditar_Sectores";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParCodigo_Sector = new SqlParameter();
                ParCodigo_Sector.ParameterName = "@codigo";
                ParCodigo_Sector.SqlDbType = SqlDbType.Int;
                ParCodigo_Sector.Value = Sectores.CodigoSector;
                SqlCmd.Parameters.Add(ParCodigo_Sector);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Sectores.Sector;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParCodigoProvincia = new SqlParameter();
                ParCodigoProvincia.ParameterName = "@codigo_provincia";
                ParCodigoProvincia.SqlDbType = SqlDbType.Int;
                ParCodigoProvincia.Value = Sectores.CodigoProvincia;
                SqlCmd.Parameters.Add(ParCodigoProvincia);

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

        //Método Eliminar
        public string Eliminar(DSectores Sectores)
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
                SqlCmd.CommandText = "Prestamos.speliminar_Sectores";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                SqlParameter ParCodigo_Sector = new SqlParameter();
                ParCodigo_Sector.ParameterName = "@codigo";
                ParCodigo_Sector.SqlDbType = SqlDbType.Int;
                ParCodigo_Sector.Value = Sectores.CodigoSector;
                SqlCmd.Parameters.Add(ParCodigo_Sector);


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
            DataTable DtResultado = new DataTable("Sectores");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Connetion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "Prestamos.spmostrar_Sectores";
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
        public DataTable BuscarNombre(DSectores Sectores)
        {
            DataTable DtResultado = new DataTable("Sectores");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Connetion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "Prestamos.spbuscar_Sectores_Provincias";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Sectores.TextoBuscar;
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

