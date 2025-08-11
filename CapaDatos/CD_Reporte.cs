using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Reporte
    {
        public List<ReporteAsistencia> RepAsistencia(string FechaInicio, string FechaFin, int IdUsuario) 
        {
            List<ReporteAsistencia> lista = new List<ReporteAsistencia>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try 
                {
                    StringBuilder query = new StringBuilder();
                    SqlCommand cmd = new SqlCommand("sp_ReporteAsistencia", oconexion);
                    cmd.Parameters.AddWithValue("FechaInicio", FechaInicio);
                    cmd.Parameters.AddWithValue("FechaFin", FechaFin);
                    cmd.Parameters.AddWithValue("IdUsuario", IdUsuario);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new ReporteAsistencia()
                            {
                                Ingreso = dr["Ingreso"].ToString(),
                                Salida = dr["Salida"].ToString(),
                                Documento = dr["Documento"].ToString(),
                                Nombre = dr["NombreCompleto"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                            });
                        }
                    }
                }

                catch (Exception ex)
                {
                    lista = new List<ReporteAsistencia>(); //Lista vacia
                }
            }
            return lista;
        }






    }
}

