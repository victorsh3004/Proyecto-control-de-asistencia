using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using CapaEntidad;
using System.Reflection;
using System.Collections;

namespace CapaDatos
{
    public class CD_Usuario
    {
        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("Select u.IdUsuario, u.Documento, u.NombreCompleto, u.Correo, u.Clave, u.Estado, u.Huella, r.IdRol, r.Descripcion from usuario u");
                    query.AppendLine("inner join rol r on r.IdRol = u.IdRol");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Usuario()
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                Documento = dr["Documento"].ToString(),
                                NombreCompleto = dr["NombreCompleto"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Clave = dr["Clave"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                                Huella = dr["Huella"] != DBNull.Value ? (byte[])dr["Huella"] : null,
                                oRol = new Rol() { IdRol = Convert.ToInt32(dr["IdRol"]), Descripcion = dr["Descripcion"].ToString() }
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Usuario>(); //Lista vacia
                }
            }
            return lista;
        }

       
        public int Registrar(Usuario objUsuario, out string Mensaje)//out string es un parametro de salida 
        {
            int IdUsuarioGenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena)) {

                    SqlCommand cmd = new SqlCommand("SP_REGISTRARUSUARIO".ToString(), oconexion);
                    cmd.Parameters.AddWithValue("Documento",objUsuario.Documento);
                    cmd.Parameters.AddWithValue("NombreCompleto", objUsuario.NombreCompleto); //Correo
                    cmd.Parameters.AddWithValue("Correo", objUsuario.Correo);
                    cmd.Parameters.AddWithValue("Clave", objUsuario.Clave);
                    cmd.Parameters.AddWithValue("IdRol", objUsuario.oRol.IdRol);
                    cmd.Parameters.AddWithValue("Estado", objUsuario.Estado);
                    cmd.Parameters.Add("IdUsuarioResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    IdUsuarioGenerado = Convert.ToInt32(cmd.Parameters["IdUsuarioResultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }
            }
            catch (Exception ex) {
                IdUsuarioGenerado = 0;
                Mensaje = ex.Message;
            }

            return IdUsuarioGenerado;
        }

        public int RegistrarHuella(Usuario objUsuario, out string Mensaje)//out string es un parametro de salida 
        {
            int IdUsuarioGenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {

                    SqlCommand cmd = new SqlCommand("SP_REGISTRARUSUARIOHUELLA".ToString(), oconexion);
                    cmd.Parameters.AddWithValue("IdUsuario", objUsuario.IdUsuario);
                    cmd.Parameters.AddWithValue("Documento", objUsuario.Documento);
                    cmd.Parameters.Add("IdUsuarioResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    IdUsuarioGenerado = Convert.ToInt32(cmd.Parameters["IdUsuarioResultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                IdUsuarioGenerado = 0;
                Mensaje = ex.Message;
            }

            return IdUsuarioGenerado;
        }
        public bool Editar(Usuario objUsuario, out string Mensaje)//out string es un parametro de salida 
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {

                    SqlCommand cmd = new SqlCommand("SP_EDITARUSUARIO".ToString(), oconexion);
                    cmd.Parameters.AddWithValue("IdUsuario", objUsuario.IdUsuario);
                    cmd.Parameters.AddWithValue("documento", objUsuario.Documento);
                    cmd.Parameters.AddWithValue("Correo", objUsuario.Correo);
                    cmd.Parameters.AddWithValue("NombreCompleto", objUsuario.NombreCompleto);
                    cmd.Parameters.AddWithValue("Clave", objUsuario.Clave);
                    cmd.Parameters.AddWithValue("IdRol", objUsuario.oRol.IdRol);
                    cmd.Parameters.AddWithValue("Estado", objUsuario.Estado);
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }

            return respuesta;
        }

        //EditarHuella
        public bool EditarHuella(Usuario objUsuario, out string Mensaje)//out string es un parametro de salida 
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {

                    SqlCommand cmd = new SqlCommand("SP_EDITARUSUARIOHUELLA".ToString(), oconexion);
                    cmd.Parameters.AddWithValue("IdUsuario", objUsuario.IdUsuario);
                    cmd.Parameters.AddWithValue("Huella", objUsuario.Huella);
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }

            return respuesta;
        }

        //temporal
        public class ResultadoAsistencia
        {
            public bool Respuesta { get; set; }
            public string Mensaje { get; set; }
            public int IdUsuario { get; set; }
        }

        //Asistencia
        public bool BuscarUsuario(Usuario objUsuario, out string Mensaje, out int IdUsuario)//out string es un parametro de salida 
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            //Usuario objUsuario = new Usuario()
            ResultadoAsistencia resultado = new ResultadoAsistencia();
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    

                    SqlCommand cmd = new SqlCommand("SP_ASISTENCIA".ToString(), oconexion);
                    cmd.Parameters.AddWithValue("Huella", objUsuario.Huella);
                    cmd.Parameters.Add("IdUsuario", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                    IdUsuario = Convert.ToInt32(cmd.Parameters["IdUsuario"].Value);
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
                IdUsuario = 0;
            }

            return respuesta;
        }

        public bool Eliminar(Usuario objUsuario, out string Mensaje)//out string es un parametro de salida 
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {

                    SqlCommand cmd = new SqlCommand("SP_ELIMINARUSUARIO".ToString(), oconexion);
                    cmd.Parameters.AddWithValue("IdUsuario", objUsuario.IdUsuario);
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }

            return respuesta;
        }


    }
}
