using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using ClosedXML.Excel;
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
    public partial class frmReportes: Form
    {
        public frmReportes()
        {
            InitializeComponent();
        }

        private void frmReportes_Load(object sender, EventArgs e)
        {
            List<Usuario> lista = new CN_Usuario().Listar();
            cboUsuario.Items.Add(new opcionCombo() { Valor = 0, Texto = "TODOS" });

            foreach (Usuario item in lista) {
                cboUsuario.Items.Add(new opcionCombo() { Valor = item.IdUsuario, Texto = item.NombreCompleto });
            }

            cboUsuario.DisplayMember = "Texto";
            cboUsuario.ValueMember = "Valor";
            cboUsuario.SelectedIndex = 0;


            foreach (DataGridViewColumn columna in dgvDataReport.Columns)
            {
                cboBusqueda.Items.Add(new opcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
            }
            cboBusqueda.DisplayMember = "Texto";
            cboBusqueda.ValueMember = "Valor";
            cboBusqueda.SelectedIndex = 0;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int IdUsuario = Convert.ToInt32(((opcionCombo)cboUsuario.SelectedItem).Valor.ToString());

            List<ReporteAsistencia> lista = new List<ReporteAsistencia>();

            lista = new CN_Reporte().RepAsistencia(
                txtFechainicio.Value.ToString(),
                txtFechafin.Value.ToString(),
                IdUsuario
                );

            dgvDataReport.Rows.Clear();

            foreach (ReporteAsistencia ra in lista) {
                dgvDataReport.Rows.Add(new object[] {
                    ra.Ingreso,
                    ra.Salida,
                    ra.Documento,
                    ra.Nombre,
                    ra.Descripcion
                });
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (dgvDataReport.Rows.Count < 1)
            {
                MessageBox.Show("No hay registros para exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else {
                DataTable dt = new DataTable();

                foreach (DataGridViewColumn columna in dgvDataReport.Columns)
                {
                    dt.Columns.Add(columna.HeaderText, typeof(string));
                }

                foreach (DataGridViewRow row in dgvDataReport.Rows) {
                    if (row.Visible) {
                        dt.Rows.Add(new object[] {
                            row.Cells[0].Value.ToString(),
                            row.Cells[1].Value.ToString(),
                            row.Cells[2].Value.ToString(),
                            row.Cells[3].Value.ToString(),
                            row.Cells[4].Value.ToString(),

                        });
                    }
                }

                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.FileName = string.Format("ReporteAsistencia_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
                saveFile.Filter = "Excel Files | *.xlsx";

                if (saveFile.ShowDialog() == DialogResult.OK) {

                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dt, "Informe");
                        hoja.ColumnsUsed().AdjustToContents();
                        wb.SaveAs(saveFile.FileName);
                        MessageBox.Show("Reporte Generado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch
                    {
                        MessageBox.Show("Error al generar reporte", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }

            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((opcionCombo)cboBusqueda.SelectedItem).Valor.ToString();

            if (dgvDataReport.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvDataReport.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtBuscar.Text.Trim().ToUpper()))
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
            }
        }

        private void btnLimpiarBuscador_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = "";
            foreach (DataGridViewRow row in dgvDataReport.Rows)
            {
                row.Visible = true;
            }
        }
    }
}
