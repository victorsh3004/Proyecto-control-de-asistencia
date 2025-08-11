using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Asistencia
    {
        private CD_Asistencia objcd_Asistencia = new CD_Asistencia();

        //Lista Asistencia
        public List<Asistencia> ListarAsistencia()
        {
            return objcd_Asistencia.ListarAsistencia();
        }

        //Registrar asistencia
        public int RegistrarAsistencia(Asistencia objcdAsistencia, out string Mensaje)
        {
            return objcd_Asistencia.RegistrarAsistencia(objcdAsistencia, out Mensaje);
        }


    }
}
