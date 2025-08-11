using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using DPFP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmAsistencia: Form
    {
        private DPFP.Template Template;

        public frmAsistencia()
        {
            InitializeComponent();
        }

        private void frmAsistencia_Load(object sender, EventArgs e)
        {
            ListarTablaAsistencia();
            
        }

        public void ListarTablaAsistencia() {
            //MOSTRAR TODOS LOS USUARIOS
            List<Asistencia> listaUsuarioAsistencia = new CN_Asistencia().ListarAsistencia();

            foreach (Asistencia item in listaUsuarioAsistencia)
            {
                dgvDataAsistencia.Rows.Add(new object[] {" ",item.IdUsuario,item.Documento, item.NombreCompleto, item.HoraIngreso, item.HoraSalida, item.EstadoAsistencia
                });
            }
        }

        public void LimpiarTablaAsistencia() {
            dgvDataAsistencia.Rows.Clear(); // Elimina todas las filas
        }



        private void btnHuella_Click(object sender, EventArgs e)
        {
            VerificarHuella verificar = new VerificarHuella();
            verificar.ShowDialog();

             string mensaje = string.Empty;
             bool resultado = false;
             int respuestaAsistencia = 0;

            //CapturarHuella capturar = new CapturarHuella();
            //verificar.OnTemplate += this.OnTemplate;
            //verificar.ShowDialog();
            /*
             byte[] streamHuella = Template.Bytes;

             Usuario objUsuario = new Usuario()
             {
                 Huella = streamHuella
             };

             resultado = new CN_Usuario().BuscarUsuario(objUsuario, out mensaje, out int IdUsuariorespuesta);

            if (resultado)
            {
                Asistencia objUsuarioAsistencia = new Asistencia()
                {
                    IdUsuario = IdUsuariorespuesta,
                };

                respuestaAsistencia = new CN_Asistencia().RegistrarAsistencia(objUsuarioAsistencia, out mensaje);

                 if (respuestaAsistencia == 1)
                 {
                   //  dgvData.Rows.Add(new object[] {" ",, txtDocumento.Text, txtNombreCompleto.Text, txtClave.Text,
                 //((opcionCombo)cboRol.SelectedItem).Valor.ToString(),
                 //((opcionCombo)cboRol.SelectedItem).Texto.ToString(),
                 //((opcionCombo)cboEstado.SelectedItem).Valor.ToString(),
                 //((opcionCombo)cboEstado.SelectedItem).Texto.ToString(),
                 //"No registrado"
                 //});


                 }
                 else
                 {
                     MessageBox.Show(mensaje);
                 }
             }*/
        }

        private void OnTemplate(DPFP.Template template)
        {
            this.Invoke(new Function(delegate ()
            {
                Template = template;
                //btnAgregar.Enabled = (Template != null);
                if (Template != null)
                {
                    MessageBox.Show("HolaThe fingerprint template is ready for fingerprint verification.", "Fingerprint Enrollment");
                    //txtHuella.Text = "Huella capturada correctamente";
                }
                else
                {
                    MessageBox.Show("The fingerprint template is not valid. Repeat fingerprint enrollment.", "Fingerprint Enrollment");
                }
            }));
        }

        private void btnHuella_Click_1(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            VerificarHuella capturar = new VerificarHuella();
            //capturar.OnTemplate += this.OnTemplate;
            //capturar.ShowDialog();

            //byte[] streamHuella = Template.Bytes;
        }
    }
}
