using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class VerificarHuella : CaptureForm
    {
        private DPFP.Template Template;
        private DPFP.Verification.Verification Verificator;
        //private UsuariosDBEntities contexto;
        //private List<Usuario> listaUsuario;
        private System.Windows.Forms.Timer delayTimer;


        public void Verify(DPFP.Template template)
        {
            Template = template;
            ShowDialog();
        }

        protected override void Init()
        {
            base.Init();
            base.Text = "Verificación de Huella Digital";
            Verificator = new DPFP.Verification.Verification();     // Create a fingerprint template verificator
            UpdateStatus(0);
        }

        private void UpdateStatus(int FAR)
        {
            // Show "False accept rate" value
            SetStatus(String.Format("False Accept Rate (FAR) = {0}", FAR));
        }

        protected override void Process(DPFP.Sample Sample)
        {
            base.Process(Sample);
            bool validacion = false;

            // Process the sample and create a feature set for the enrollment purpose.
            DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification);

            // Check quality of the sample and start verification if it's good
            // TODO: move to a separate task
            if (features != null)
            {
                // Compare the feature set with our template
                DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();

                DPFP.Template template = new DPFP.Template();
                Stream stream;
                
                List<Usuario> listaUsuario = new CN_Usuario().Listar();

                foreach (Usuario emp in listaUsuario)
                {
                    if (emp.Huella != null) {
                        stream = new MemoryStream(emp.Huella);
                        template = new DPFP.Template(stream);

                        Verificator.Verify(features, template, ref result);
                        UpdateStatus(result.FARAchieved);
                        if (result.Verified)
                        {

                            string mensaje = string.Empty;

                            Asistencia objAsistencia = new Asistencia()
                            {
                                IdUsuario = Convert.ToInt32(emp.IdUsuario),
                                Documento = emp.Documento,
                                NombreCompleto = emp.NombreCompleto,
                            };

                            int idUsuarioGenerado = new CN_Asistencia().RegistrarAsistencia(objAsistencia, out mensaje);

                            if (idUsuarioGenerado == 0)
                            {
                                MakeReport("Ingreso Registrado Usuario: " + emp.NombreCompleto + " " + emp.Documento);
                            }
                            else if (idUsuarioGenerado == 1)
                            {
                                /*The fingerprint was VERIFIED*/
                                MakeReport("Salida Registrada Usuario: " + emp.NombreCompleto + " " + emp.Documento);
                            }
                            else if (idUsuarioGenerado == -1)
                            {
                                MakeReport("Usuario " + emp.NombreCompleto + " ya registro su salida");
                            }
                            else if (idUsuarioGenerado == -2)
                            {
                                MakeReport("Usuario " + emp.NombreCompleto + " ya registro su ingreso");
                            }
                            else if (idUsuarioGenerado == -3)
                            {
                                MakeReport("Usuario no registro su Huella");
                            }
                            frmAsistencia objAsis = new frmAsistencia();

                            objAsis.LimpiarTablaAsistencia();
                            objAsis.ListarTablaAsistencia();

                            validacion = true;
                            //form.Show();
                            //this.Hide();

                            //form.FormClosing += frm_closing;
                            break;
                        }
                        stream.Dispose();

                        //stream.SetLength(0); // Borra los datos
                        //stream.Capacity = 0; // Reduce la capacidad a cero
                    }


                }
                if(!validacion)
                {
                    MakeReport("USUARIO NO REGISTRADO");
                }



            }
        }

        public VerificarHuella()
        {
            InitializeComponent();
        }

        private void VerificarHuella_Load(object sender, EventArgs e)
        {

        }
    }
}
