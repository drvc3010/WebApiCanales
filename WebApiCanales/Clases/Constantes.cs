using System.Data;
using System.Data.SqlClient;



namespace WebApiCanales.Clases
{
    public class Constantes
    {
        
        private const string SQLSERVERCONNECTION = "Server = sql5046.site4now.net; Database = DB_A4F54F_dd; User Id = DB_A4F54F_dd_admin;Password = bbva2019;";


        public ConsultaTicket ticketDetail(string idATM)
        {
            ConsultaTicket cst = new ConsultaTicket();
            SqlConnection cn = new SqlConnection(SQLSERVERCONNECTION);
            cn.Open();
            SqlDataAdapter dap = new SqlDataAdapter("SPS_TICKET_ATM_BY_ID", cn);
            DataTable dt = new DataTable();
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@IDATM", idATM);
           
            dap.Fill(dt);
            cn.Close();
            if (dt.Rows.Count <=0)
            {
                cst.problema = "no se encontro informacion sobre el código de cajero ingresado.";
                
            }

            else
            {
              
                cst.problema = dt.Rows[0]["Problem"].ToString();
                cst.estadoTicket = dt.Rows[0]["Status"].ToString();
                cst.descripcion = dt.Rows[0]["Summary"].ToString();
                cst.asignado = dt.Rows[0]["Assigned"].ToString();
                cst.territorioATM = dt.Rows[0]["TERRITORIO"].ToString();
                cst.marca = dt.Rows[0]["Marca"].ToString();
                cst.direccion = dt.Rows[0]["Direccion"].ToString();
                cst.ubicacion = dt.Rows[0]["Ubicacion"].ToString();
                cst.nombreOficina = dt.Rows[0]["NOMBRE"].ToString();
                cst.urlMap = dt.Rows[0]["urlMap"].ToString();
              
               
            }
            
            return cst;
        }
        public int InsertDataSqlServer(string data)
        {
            int result = 0;
            SqlConnection con = new SqlConnection(SQLSERVERCONNECTION);
            SqlCommand cmd = new SqlCommand("SPI_VOTACION", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@option", data);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public string RegisterTicketATM(string IdCajero , string CodRegistro , string NomUser , string Categoria , string SubCat , string Descripcion)
        {
            int result = 0;
            string val = "";
            SqlConnection con = new SqlConnection(SQLSERVERCONNECTION);
            SqlCommand cmd = new SqlCommand("SPI_TICKET_ATM", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idcajero", IdCajero);
            cmd.Parameters.AddWithValue("@codigoregistro", CodRegistro);
            cmd.Parameters.AddWithValue("@nombreusuario", NomUser);
            cmd.Parameters.AddWithValue("@categoria", Categoria);
            cmd.Parameters.AddWithValue("@subcategoria", SubCat);
            cmd.Parameters.AddWithValue("@descripcion", Descripcion);
            con.Open();
            result = cmd.ExecuteNonQuery();

            if (result > 0)
            {
                val = "Se registro correctamente su ticket, en breve nos cantactaremos con usted.";
            }
            else
            {
                val = "No se pudo registrar su ticket, por favor intentelo nuevamente.";
            }

            con.Close();
            return val;

        }
    }
}
