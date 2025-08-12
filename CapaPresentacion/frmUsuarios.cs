using CapaNegocio;
using CapaPresentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaEntidad;
using System.Windows.Controls;


namespace CapaPresentacion
{
    public partial class frmUsuarios: Form
    {
        private DPFP.Template Template;
        //private UsuariosDBEntities contexto;
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            cboEstado.Items.Add(new opcionCombo() { Valor = 1, Texto = "Activo" });
            cboEstado.Items.Add(new opcionCombo() { Valor = 0, Texto = "No Activo" });

            cboEstado.DisplayMember = "Texto";
            cboEstado.ValueMember = "Valor";
            cboEstado.SelectedIndex = 0;

            List<Rol> listaRol = new CN_Rol().Listar();

            foreach (Rol item in listaRol) {
                cboRol.Items.Add(new opcionCombo() { Valor = item.IdRol, Texto = item.Descripcion });

            }

            cboRol.DisplayMember = "Texto";
            cboRol.ValueMember = "Valor";
            cboRol.SelectedIndex = 0;

            foreach (DataGridViewColumn columna in dgvData.Columns) {
                if (columna.Visible == true && columna.Name != "btnSeleccionar") {
                    
                    cboBusqueda.Items.Add(new opcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cboBusqueda.DisplayMember = "Texto";
            cboBusqueda.ValueMember = "Valor";
            cboBusqueda.SelectedIndex = 0;

            //MOSTRAR TODOS LOS USUARIOS
            List<Usuario> listaUsuario = new CN_Usuario().Listar();

            foreach (Usuario item in listaUsuario)
            {
                dgvData.Rows.Add(new object[] {" ",item.IdUsuario, item.Documento, item.NombreCompleto, item.Correo, item.Clave,
                    item.oRol.IdRol,
                    item.oRol.Descripcion,
                    item.Estado == true ? 1 : 0,
                    item.Estado == true ? "Activo" : "No Activo",
                    item.Huella == null ? "No resgitrado" : "Registrado"
                });
                
            }

            cboRol.DisplayMember = "Texto";
            cboRol.ValueMember = "Valor";
            cboRol.SelectedIndex = 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            Usuario objUsuario = new Usuario()
            {
                IdUsuario = Convert.ToInt32(txtId.Text),
                Documento = txtDocumento.Text,
                NombreCompleto = txtNombreCompleto.Text,
                Correo = txtCorreo.Text,
                Clave = txtClave.Text,
                oRol = new Rol() {
                    IdRol = Convert.ToInt32(((opcionCombo)cboRol.SelectedItem).Valor)
                },
                Estado = Convert.ToInt32(((opcionCombo)cboEstado.SelectedItem).Valor) == 1 ? true : false
            };

            if (objUsuario.IdUsuario == 0)
            {
                int idUsuarioGenerado = new CN_Usuario().Registrar(objUsuario, out mensaje);

                if (idUsuarioGenerado != 0)
                {
                    /*dgvData.Rows.Add(new object[] {" ",txtId.Text, txtDocumento.Text, txtNombreCompleto.Text, txtCorreo.Text, txtClave.Text,
                ((opcionCombo)cboRol.SelectedItem).Valor.ToString(),
                ((opcionCombo)cboRol.SelectedItem).Texto.ToString(),
                ((opcionCombo)cboEstado.SelectedItem).Valor.ToString(),
                ((opcionCombo)cboEstado.SelectedItem).Texto.ToString(),
                "No registrado"
                });*/
                    //limpiartabla();
                    //frmUsuarios_Load(sender, e);
                    limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
            else { 
                bool resultado = new CN_Usuario().Editar(objUsuario, out mensaje);

                if (resultado)
                {
                    DataGridViewRow row = dgvData.Rows[Convert.ToInt32(txtIndice.Text)];
                    row.Cells["Id"].Value = txtId.Text;
                    row.Cells["Documento"].Value = txtDocumento.Text;
                    row.Cells["NombreCompleto"].Value = txtNombreCompleto.Text;
                    row.Cells["Correo"].Value = txtNombreCompleto.Text;
                    row.Cells["Clave"].Value = txtClave.Text;
                    row.Cells["IdRol"].Value = ((opcionCombo)cboRol.SelectedItem).Valor.ToString();
                    row.Cells["Rol"].Value = ((opcionCombo)cboRol.SelectedItem).Texto.ToString();
                    row.Cells["EstadoValor"].Value = ((opcionCombo)cboEstado.SelectedItem).Valor.ToString();
                    row.Cells["Estado"].Value = ((opcionCombo)cboEstado.SelectedItem).Texto.ToString();
                    row.Cells["RegistroHuella"].Value = "No registrado";

                    limpiar();
                    //limpiartabla();
                    //frmUsuarios_Load(sender, e);

                }
                else {
                    MessageBox.Show(mensaje);
                
                }
            }

            

        }

        private void limpiar() {
            txtIndice.Text = "-1";
            txtId.Text = "0";
            txtDocumento.Text = "";
            txtNombreCompleto.Text = "";
            txtCorreo.Text = "";
            txtClave.Text = "";
            txtConfirmarClave.Text = "";
            cboRol.SelectedIndex = 0;
            cboEstado.SelectedIndex = 0;
            btnHuella.Visible = false;
            btnHuella.Enabled = false;

            txtDocumento.Select();
        }

        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.check20.Width;
                var h = Properties.Resources.check20.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.check20, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvData.Columns[e.ColumnIndex].Name == "btnSeleccionar") {
                
                int indice = e.RowIndex;

                if (indice >= 0) {
                    btnHuella.Visible = true;
                    btnHuella.Enabled = true;
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dgvData.Rows[indice].Cells["Id"].Value.ToString();
                    txtDocumento.Text = dgvData.Rows[indice].Cells["Documento"].Value.ToString();
                    txtNombreCompleto.Text = dgvData.Rows[indice].Cells["NombreCompleto"].Value.ToString();
                    txtCorreo.Text = dgvData.Rows[indice].Cells["Correo"].Value.ToString();
                    txtClave.Text = dgvData.Rows[indice].Cells["Clave"].Value.ToString();
                    txtConfirmarClave.Text = dgvData.Rows[indice].Cells["Clave"].Value.ToString();

                    foreach (opcionCombo oc in cboRol.Items) {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvData.Rows[indice].Cells["IdRol"].Value)) {
                            int indice_combo = cboRol.Items.IndexOf(oc);
                            cboRol.SelectedIndex = indice_combo;
                            break;

                        }
                    }
                    foreach (opcionCombo oc in cboEstado.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvData.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            int indice_combo = cboEstado.Items.IndexOf(oc);
                            cboEstado.SelectedIndex = indice_combo;
                            break;

                        }
                    }

                }
            }
        }

        private void btnHuella_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtId.Text) != 0)
            {
                //txtId.Text = dgvData.Rows[indice].Cells["Id"].Value.ToString();
                string mensaje = string.Empty;

                CapturarHuella capturar = new CapturarHuella();
                capturar.OnTemplate += this.OnTemplate;
                capturar.ShowDialog();

                byte[] streamHuella = Template.Bytes;

                Usuario objUsuario = new Usuario()
                {
                    IdUsuario = int.Parse(txtId.Text),
                    Huella = streamHuella
                };

                bool resultado = new CN_Usuario().EditarHuella(objUsuario, out mensaje);

                if (resultado)
                {
                    DataGridViewRow row = dgvData.Rows[Convert.ToInt32(txtIndice.Text)];
                    row.Cells["Id"].Value = txtId.Text;
                    row.Cells["Documento"].Value = txtDocumento.Text;
                    row.Cells["NombreCompleto"].Value = txtNombreCompleto.Text;
                    row.Cells["Correo"].Value = txtCorreo.Text;
                    row.Cells["Clave"].Value = txtClave.Text;
                    row.Cells["IdRol"].Value = ((opcionCombo)cboRol.SelectedItem).Valor.ToString();
                    row.Cells["Rol"].Value = ((opcionCombo)cboRol.SelectedItem).Texto.ToString();
                    row.Cells["EstadoValor"].Value = ((opcionCombo)cboEstado.SelectedItem).Valor.ToString();
                    row.Cells["Estado"].Value = ((opcionCombo)cboEstado.SelectedItem).Texto.ToString();
                    row.Cells["RegistroHuella"].Value = "Registrado";

                    limpiar();

                }
                else
                {
                    MessageBox.Show(mensaje);





                }

            }
        }

        private void OnTemplate(DPFP.Template template)
        {
            this.Invoke(new Function(delegate ()
            {
                Template = template;
                //btnAgregar.Enabled = (Template != null);
                if (Template != null)
                {
                    MessageBox.Show("Hola la huella fue capturada correctamente The fingerprint template is ready for fingerprint verification.", "Fingerprint Enrollment");
                    //txtHuella.Text = "Huella capturada correctamente";
                }
                else
                {
                    MessageBox.Show("The fingerprint template is not valid. Repeat fingerprint enrollment.", "Fingerprint Enrollment");
                }
            }));
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtId.Text) != 0) {
                if (MessageBox.Show("¿Desea eliminar el usuario", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    string mensaje = string.Empty;
                    Usuario objUsuario = new Usuario()
                    {
                        IdUsuario = Convert.ToInt32(txtId.Text),
                    };

                    bool respuesta = new CN_Usuario().Eliminar(objUsuario, out mensaje);

                    if (respuesta)
                    {
                        dgvData.Rows.RemoveAt(Convert.ToInt32(txtIndice.Text));
                    }
                    else {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                
                }
            } 
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((opcionCombo)cboBusqueda.SelectedItem).Valor.ToString();

            if (dgvData.Rows.Count > 0) {
                foreach (DataGridViewRow row in dgvData.Rows) {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtBuscar.Text.Trim().ToUpper()))
                    {
                        row.Visible = true;
                    }
                    else {
                        row.Visible = false;
                    }
                }
            }
        }

        private void btnLimpiarBuscador_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = "";
            foreach (DataGridViewRow row in dgvData.Rows) {
                row.Visible = true;
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            limpiartabla();
            frmUsuarios_Load(sender, e);
        }

        private void limpiartabla() {
            dgvData.Rows.Clear();
        }
    }
}
