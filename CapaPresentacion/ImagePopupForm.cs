using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace CapaPresentacion
{
    public partial class ImagePopupForm: Form
    {
        public ImagePopupForm(string imagePath, string soundPath = null)
        {
            InitializeComponent();
            // Configura el formulario
            this.FormBorderStyle = FormBorderStyle.None; // Sin bordes
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.LightGray; // Fondo del formulario

            // PictureBox para la imagen
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = Image.FromFile("C:\\Users\\Victor\\Desktop\\proyecto control asistencia - copia\\SistemaControl\\versiones\\Asistencia\\CapaPresentacion\\Resources\\checkAsistencia.png");
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom; // Ajusta la imagen
            pictureBox.Dock = DockStyle.Fill; // Ocupa todo el espacio

            // Botón para cerrar (opcional)
            Button btnClose = new Button();
            btnClose.Text = "X";
            btnClose.BackColor = Color.Red;
            btnClose.Click += (s, e) => this.Close();
            btnClose.Location = new Point(this.Width - 30, 5); // Esquina superior derecha

            // Agrega controles al formulario
            this.Controls.Add(pictureBox);
            this.Controls.Add(btnClose);

            // Reproduce el sonido si se proporciona una ruta
            if (!string.IsNullOrEmpty(soundPath))
            {
                try
                {
                    SoundPlayer player = new SoundPlayer(soundPath);
                    player.Play(); // Reproduce el sonido una vez
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al reproducir el sonido: {ex.Message}");
                }
            }

            // Cierra automáticamente después de 5 segundos
            AutoCloseForm(700);
        }

        private async void AutoCloseForm(int milliseconds)
        {
            await Task.Delay(milliseconds);
            this.Close();
        }

        private void ImagePopupForm_Load(object sender, EventArgs e)
        {

        }
    }
}
