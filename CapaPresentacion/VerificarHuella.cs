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
                            bool pictureBox1 = false;

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
                                BtnShowImage_Click(null, EventArgs.Empty, idUsuarioGenerado);

                            }
                            else if (idUsuarioGenerado == 1)
                            {
                                /*The fingerprint was VERIFIED*/
                                MakeReport("Salida Registrada Usuario: " + emp.NombreCompleto + " " + emp.Documento);
                                BtnShowImage_Click(null, EventArgs.Empty, idUsuarioGenerado);
                            }
                            else if (idUsuarioGenerado == -1)
                            {
                                MakeReport("Usuario " + emp.NombreCompleto + " ya registro su salida");
                                BtnShowImage_Click(null, EventArgs.Empty, idUsuarioGenerado);
                            }
                            else if (idUsuarioGenerado == -2)
                            {
                                MakeReport("Usuario " + emp.NombreCompleto + " ya registro su ingreso");
                                BtnShowImage_Click(null, EventArgs.Empty, idUsuarioGenerado);
                            }
                            else if (idUsuarioGenerado == -3)
                            {
                                MakeReport("Usuario no registro su Huella");
                                BtnShowImage_Click(null, EventArgs.Empty, idUsuarioGenerado);
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
                    BtnShowImage_Click(null, EventArgs.Empty, 5);
                }



            }
        }

        public VerificarHuella()
        {
            InitializeComponent();

            /*PictureBox pictureBox1 = new PictureBox();
            pictureBox1.Image = Image.FromFile("C:\\Users\\Victor\\Desktop\\proyecto control asistencia - copia\\SistemaControl\\versiones\\Asistencia\\CapaPresentacion\\Resources\\checkAsistencia.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Dock = DockStyle.Fill; // Ocupa todo el formulario
            this.Controls.Add(pictureBox1);
            */



            

        }

        
        private void BtnShowImage_Click(object sender, EventArgs e, int idUsuarioGenerado)
        {
            string imagePath = "C:\\Users\\Victor\\Desktop\\proyecto control asistencia - copia\\SistemaControl\\versiones\\Asistencia\\CapaPresentacion\\Resources\\checkAsistencia.png";
            string soundPath = "C:\\Users\\Victor\\Desktop\\proyecto control asistencia - copia\\SistemaControl\\versiones\\Asistencia\\CapaPresentacion\\Resources\\Ingreso.wav";
            switch (idUsuarioGenerado)
            {
                case 0:
                    imagePath = "C:\\Users\\Victor\\Desktop\\proyecto control asistencia - copia\\SistemaControl\\versiones\\Asistencia\\CapaPresentacion\\Resources\\checkAsistencia.png";
                    soundPath = "C:\\Users\\Victor\\Desktop\\proyecto control asistencia - copia\\SistemaControl\\versiones\\Asistencia\\CapaPresentacion\\Resources\\Ingreso.wav";
                    break;
                case 1:
                    imagePath = "C:\\Users\\Victor\\Desktop\\proyecto control asistencia - copia\\SistemaControl\\versiones\\Asistencia\\CapaPresentacion\\Resources\\checkAsistencia.png";
                    soundPath = "C:\\Users\\Victor\\Desktop\\proyecto control asistencia - copia\\SistemaControl\\versiones\\Asistencia\\CapaPresentacion\\Resources\\Salida.wav";
                    break;
                case -1:
                    imagePath = "C:\\Users\\Victor\\Desktop\\proyecto control asistencia - copia\\SistemaControl\\versiones\\Asistencia\\CapaPresentacion\\Resources\\checkAsistencia.png";
                    soundPath = "C:\\Users\\Victor\\Desktop\\proyecto control asistencia - copia\\SistemaControl\\versiones\\Asistencia\\CapaPresentacion\\Resources\\YaRegistro.wav";
                    break;
                case -2:
                    imagePath = "C:\\Users\\Victor\\Desktop\\proyecto control asistencia - copia\\SistemaControl\\versiones\\Asistencia\\CapaPresentacion\\Resources\\checkAsistencia.png";
                    soundPath = "C:\\Users\\Victor\\Desktop\\proyecto control asistencia - copia\\SistemaControl\\versiones\\Asistencia\\CapaPresentacion\\Resources\\YaRegistro.wav";
                    break;
                case -3:
                    imagePath = "C:\\Users\\Victor\\Desktop\\proyecto control asistencia - copia\\SistemaControl\\versiones\\Asistencia\\CapaPresentacion\\Resources\\checkAsistencia.png";
                    soundPath = "C:\\Users\\Victor\\Desktop\\proyecto control asistencia - copia\\SistemaControl\\versiones\\Asistencia\\CapaPresentacion\\Resources\\NoRegistrado.wav"; 
                    break;
                case 5:
                    imagePath = "C:\\Users\\Victor\\Desktop\\proyecto control asistencia - copia\\SistemaControl\\versiones\\Asistencia\\CapaPresentacion\\Resources\\checkAsistencia.png";
                    soundPath = "C:\\Users\\Victor\\Desktop\\proyecto control asistencia - copia\\SistemaControl\\versiones\\Asistencia\\CapaPresentacion\\Resources\\NoRegistrado.wav";
                    break;
                default:
                    imagePath = "C:\\Users\\Victor\\Desktop\\proyecto control asistencia - copia\\SistemaControl\\versiones\\Asistencia\\CapaPresentacion\\Resources\\checkAsistencia.png";
                    soundPath = "C:\\Users\\Victor\\Desktop\\proyecto control asistencia - copia\\SistemaControl\\versiones\\Asistencia\\CapaPresentacion\\Resources\\Ingreso.wav";
                    break;
            }
            
            // Abre el formulario emergente con la imagen
            ImagePopupForm popup = new ImagePopupForm(imagePath, soundPath);
            popup.ShowDialog(); // Modal (bloquea la ventana principal)
                                // O usa popup.Show(); para no modal
        }
        private void VerificarHuella_Load(object sender, EventArgs e)
        {

        }
    }
}
