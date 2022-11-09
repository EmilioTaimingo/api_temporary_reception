using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using api_temporary_reception.Models;
using MySql.Data.MySqlClient;

namespace api_temporary_reception.Context
{
    public class temporary_ReceptionCommands: DBContext
    {
        public static Reply Recepcion_Temporal(Reception oReception)
        {

            Reply oReply = new Reply();

            string connectionString = $"server ={GetRDSConections().Writer}; {Data_base}";
            using (MySqlConnection conexion = new MySqlConnection(connectionString))
            {

                // Comandos
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "alta_paquetes_sp";
                // Parametros de SP

                // in pa_id int(11)
                cmd.Parameters.AddWithValue("@pa_id", 0);
                //in pa_fecharecepcion datetime
                DateTime Fecha = DateTime.Now;
                cmd.Parameters.AddWithValue("@pa_fecharecepcion", Fecha);//model
                //in pa_codigorecoleccion varchar(4)
                cmd.Parameters.AddWithValue("@pa_codigorecoleccion", "");
                //in pa_fechaingresobodega datetime
                cmd.Parameters.AddWithValue("@pa_fechaingresobodega", null);
                //in pa_fechasalidabodega datetime
                cmd.Parameters.AddWithValue("@pa_fechasalidabodega", null);
                //in pa_fechacargaoperador datetime
                cmd.Parameters.AddWithValue("@pa_fechacargaoperador", null);
                //in pa_fechaentregafinal datetime
                cmd.Parameters.AddWithValue("@pa_fechaentregafinal", null);
                //in pa_gps longtext
                cmd.Parameters.AddWithValue("@pa_gps", "");
                //in pa_intento int(11)
                cmd.Parameters.AddWithValue("@pa_intento", 0);
                //in pa_foto longtext
                cmd.Parameters.AddWithValue("@pa_foto", oReception.Photography);
                //in op_id int(11)
                cmd.Parameters.AddWithValue("@op_id", oReception.Operator_Id);
                //in us_id int(11)
                cmd.Parameters.AddWithValue("@us_id", "");
                //in ep_id int(11) 
                cmd.Parameters.AddWithValue("@ep_id", oReception.Status_Id);
                //in bo_id int(11)
                cmd.Parameters.AddWithValue("@bo_id", "");
                //in co_id int(11) 
                cmd.Parameters.AddWithValue("@co_id", oReception.Condition_Id);
                //in zo_id int(11)
                cmd.Parameters.AddWithValue("@zo_id", null);
                //in an_id int(11)
                cmd.Parameters.AddWithValue("@an_id", null);
                //in de_id int(11)
                cmd.Parameters.AddWithValue("@de_id", null);
                //in pa_guia varchar(50)
                cmd.Parameters.AddWithValue("@pa_guia", oReception.Guide_Number);//model
                // Ejecucion              
                try
                {
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    oReply.Result = 200;
                    oReply.Message = "Ok successful";
                    return oReply;
                }
                catch (Exception ex)
                {
                    cmd.ExecuteNonQuery();
                    oReply.Result = 400;
                    oReply.Message = "Bad Request";
                    return oReply;
                }

            }
        }
    }
}