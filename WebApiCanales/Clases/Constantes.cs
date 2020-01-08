using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCanales.Clases
{
    public class Constantes
    {
        
        private const string SQLSERVERCONNECTION = "Server = sql5046.site4now.net; Database = DB_A4F54F_dd; User Id = DB_A4F54F_dd_admin;Password = bbva2019;";


        public string  ticketDetail(string idATM)
        {
            string result = "";
            string problema = "", descripcion = "", subcategoria = "";
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
                result = "no se encontro informacion sobre el código de cajero ingresado.";
            }

            else
            {
                
              result = "Problema : " + dt.Rows[0]["Problem"].ToString() + " || " +
                        "Estado Ticket : " + dt.Rows[0]["Status"].ToString() + " || " +
                       "Descripción : " + dt.Rows[0]["Summary"].ToString() + " || " +
                       "Asignado a : " + dt.Rows[0]["Assigned"].ToString() + " || " +
                       "Territorio ATM : " + dt.Rows[0]["Summary"].ToString();
            }
            return result;
           // return dt;
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
            /*if (k != 0)
            {
                lblmsg.Text = "Record Inserted Succesfully into the Database";
                lblmsg.ForeColor = System.Drawing.Color.CornflowerBlue;
            }*/

            return result;
        }

        public int RegisterTicketATM(string IdCajero , string CodRegistro , string NomUser , string Categoria , string SubCat , string Descripcion)
        {
            int result = 0;
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
            con.Close();
            return result;

        }
    }
}
