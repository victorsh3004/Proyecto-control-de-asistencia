using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Reporte
    {
        private CD_Reporte objcd_Reporte = new CD_Reporte();

        public List<ReporteAsistencia> RepAsistencia(string FechaInicio, string FechaFin, int IdUsuario)
        {
            return objcd_Reporte.RepAsistencia(FechaInicio, FechaFin, IdUsuario);
        }
    }
}
