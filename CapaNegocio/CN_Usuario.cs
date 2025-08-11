using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Usuario
    {
        private CD_Usuario objcd_usuario = new CD_Usuario();
        private CD_Asistencia objcd_Asistencia = new CD_Asistencia();

        public List<Usuario> Listar()
        {
            return objcd_usuario.Listar();
        }

        //ListarAsistencia

        //RegistrarAsistencia
        /*public List<Asistencia> RegistrarAsistencia()
        {
            return objcd_Asistencia.RegistrarAsistencia();
        }*/
        public int Registrar(Usuario objUsuario, out string Mensaje) 
        {
            Mensaje = string.Empty;

            if (objUsuario.Documento == "")
            {
                Mensaje += "Es necesario el Documento del usuario\n";
            }

            if (objUsuario.NombreCompleto == "") {
                Mensaje += "Es necesario el nombre completo del usuario\n";
            }

            if (objUsuario.Clave == "")
            {
                Mensaje += "Es necesario la clave del usuario\n";
            }

            if (Mensaje != string.Empty) {
                return 0;
            }

            return objcd_usuario.Registrar(objUsuario, out Mensaje);
        }

        public bool Editar(Usuario objUsuario, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (objUsuario.Documento == "")
            {
                Mensaje += "Es necesario el Documento del usuario\n";
            }

            if (objUsuario.NombreCompleto == "")
            {
                Mensaje += "Es necesario el nombre completo del usuario\n";
            }

            if (objUsuario.Clave == "")
            {
                Mensaje += "Es necesario la clave del usuario\n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else {
                return objcd_usuario.Editar(objUsuario, out Mensaje);
            }

                
        }

        public bool Eliminar(Usuario objUsuario, out string Mensaje)
        {
            return objcd_usuario.Eliminar(objUsuario, out Mensaje);
        }

        public int RegistrarHuella(Usuario objUsuario, out string Mensaje)
        {
            return objcd_usuario.RegistrarHuella(objUsuario, out Mensaje);
        }

        public bool EditarHuella(Usuario objUsuario, out string Mensaje)
        {
            return objcd_usuario.EditarHuella(objUsuario, out Mensaje);
        }

        //Asistencia
        public bool BuscarUsuario(Usuario objUsuario, out string Mensaje, out int IdUsuario)
        {
            return objcd_usuario.BuscarUsuario(objUsuario, out Mensaje, out IdUsuario);
        }


    }
}
