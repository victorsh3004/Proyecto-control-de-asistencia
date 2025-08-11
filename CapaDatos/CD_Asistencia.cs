using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Asistencia
    {

        public List<Asistencia> ListarAsistencia()
        {
            List<Asistencia> lista = new List<Asistencia>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("Select u.IdUsuario, u.Documento, u.NombreCompleto, a.HoraIngreso, a.HoraSalida, a.EstadoAsistencia from usuario u");
                    query.AppendLine("inner join asistencia a on u.IdUsuario = a.IdUsuario where a.HoraSalida IS NULL or a.HoraSalida >= DATEADD(MINUTE, -30, GETDATE())");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Asistencia()
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                Documento = dr["Documento"].ToString(),
                                NombreCompleto = dr["NombreCompleto"].ToString(),
                                HoraIngreso = Convert.ToDateTime(dr["HoraIngreso"]),
                                HoraSalida = dr["HoraSalida"] != DBNull.Value
                                ? Convert.ToDateTime(dr["HoraSalida"])
                                : (DateTime?)null,
                                EstadoAsistencia = Convert.ToInt32(dr["EstadoAsistencia"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Asistencia>(); //Lista vacia
                }
            }
            return lista;
        }

        //RegistrarAsistencia
        public int RegistrarAsistencia(Asistencia objcdAsistencia, out string Mensaje)//out string es un parametro de salida 
        {
            int respuesta = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {

                    SqlCommand cmd = new SqlCommand("SP_REGISTRARASISTENCIA".ToString(), oconexion);
                    cmd.Parameters.AddWithValue("IdUsuario", objcdAsistencia.IdUsuario);
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output; //EstadoAsistencia 0 Ingreso, 1 salida
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToInt32(cmd.Parameters["Respuesta"].Value);
                    // 1 ACtualización de hora de salida //-2Ya registro ingreso / 0 Registro nueva asistencia / -1 Ya ingreso su salida

                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                respuesta = -1;
                Mensaje = ex.Message;
            }

            return respuesta;
        }
    }
}
