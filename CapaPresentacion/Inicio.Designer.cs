namespace CapaPresentacion
{
    partial class Inicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuusuarios = new FontAwesome.Sharp.IconMenuItem();
            this.menumantenedor = new FontAwesome.Sharp.IconMenuItem();
            this.iconMenuItem1 = new FontAwesome.Sharp.IconMenuItem();
            this.iconMenuItem2 = new FontAwesome.Sharp.IconMenuItem();
            this.menuasistencia = new FontAwesome.Sharp.IconMenuItem();
            this.submenuregistrarventa = new FontAwesome.Sharp.IconMenuItem();
            this.verdetalleventa = new FontAwesome.Sharp.IconMenuItem();
            this.menuparteoperativo = new FontAwesome.Sharp.IconMenuItem();
            this.submenuregistrar = new FontAwesome.Sharp.IconMenuItem();
            this.submenuverdetalle = new FontAwesome.Sharp.IconMenuItem();
            this.menuEstadoPO = new FontAwesome.Sharp.IconMenuItem();
            this.menuacompaniamiento = new FontAwesome.Sharp.IconMenuItem();
            this.menureportes = new FontAwesome.Sharp.IconMenuItem();
            this.menuacercade = new FontAwesome.Sharp.IconMenuItem();
            this.menuTitulo = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.contenedor = new System.Windows.Forms.Panel();
            this.lblusuario = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuusuarios,
            this.menumantenedor,
            this.menuasistencia,
            this.menuparteoperativo,
            this.menuEstadoPO,
            this.menuacompaniamiento,
            this.menureportes,
            this.menuacercade});
            this.menu.Location = new System.Drawing.Point(0, 58);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1119, 73);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // menuusuarios
            // 
            this.menuusuarios.IconChar = FontAwesome.Sharp.IconChar.UsersGear;
            this.menuusuarios.IconColor = System.Drawing.Color.Black;
            this.menuusuarios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuusuarios.IconSize = 50;
            this.menuusuarios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuusuarios.Name = "menuusuarios";
            this.menuusuarios.Size = new System.Drawing.Size(64, 69);
            this.menuusuarios.Text = "Usuarios";
            this.menuusuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuusuarios.Click += new System.EventHandler(this.menuusuarios_Click);
            // 
            // menumantenedor
            // 
            this.menumantenedor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iconMenuItem1,
            this.iconMenuItem2});
            this.menumantenedor.IconChar = FontAwesome.Sharp.IconChar.ScrewdriverWrench;
            this.menumantenedor.IconColor = System.Drawing.Color.Black;
            this.menumantenedor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menumantenedor.IconSize = 50;
            this.menumantenedor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menumantenedor.Name = "menumantenedor";
            this.menumantenedor.Size = new System.Drawing.Size(84, 69);
            this.menumantenedor.Text = "Mantenedor";
            this.menumantenedor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // iconMenuItem1
            // 
            this.iconMenuItem1.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconMenuItem1.IconColor = System.Drawing.Color.Black;
            this.iconMenuItem1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconMenuItem1.Name = "iconMenuItem1";
            this.iconMenuItem1.Size = new System.Drawing.Size(109, 22);
            this.iconMenuItem1.Text = "Rol";
            this.iconMenuItem1.Click += new System.EventHandler(this.iconMenuItem1_Click);
            // 
            // iconMenuItem2
            // 
            this.iconMenuItem2.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconMenuItem2.IconColor = System.Drawing.Color.Black;
            this.iconMenuItem2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconMenuItem2.Name = "iconMenuItem2";
            this.iconMenuItem2.Size = new System.Drawing.Size(109, 22);
            this.iconMenuItem2.Text = "Estado";
            this.iconMenuItem2.Click += new System.EventHandler(this.iconMenuItem2_Click);
            // 
            // menuasistencia
            // 
            this.menuasistencia.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuregistrarventa,
            this.verdetalleventa});
            this.menuasistencia.IconChar = FontAwesome.Sharp.IconChar.Fingerprint;
            this.menuasistencia.IconColor = System.Drawing.Color.Black;
            this.menuasistencia.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuasistencia.IconSize = 50;
            this.menuasistencia.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuasistencia.Name = "menuasistencia";
            this.menuasistencia.Size = new System.Drawing.Size(72, 69);
            this.menuasistencia.Text = "Asistencia";
            this.menuasistencia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // submenuregistrarventa
            // 
            this.submenuregistrarventa.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuregistrarventa.IconColor = System.Drawing.Color.Black;
            this.submenuregistrarventa.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenuregistrarventa.Name = "submenuregistrarventa";
            this.submenuregistrarventa.Size = new System.Drawing.Size(129, 22);
            this.submenuregistrarventa.Text = "Registrar";
            this.submenuregistrarventa.Click += new System.EventHandler(this.submenuregistrarventa_Click);
            // 
            // verdetalleventa
            // 
            this.verdetalleventa.IconChar = FontAwesome.Sharp.IconChar.None;
            this.verdetalleventa.IconColor = System.Drawing.Color.Black;
            this.verdetalleventa.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.verdetalleventa.Name = "verdetalleventa";
            this.verdetalleventa.Size = new System.Drawing.Size(129, 22);
            this.verdetalleventa.Text = "Ver Detalle";
            this.verdetalleventa.Click += new System.EventHandler(this.verdetalleventa_Click);
            // 
            // menuparteoperativo
            // 
            this.menuparteoperativo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuregistrar,
            this.submenuverdetalle});
            this.menuparteoperativo.IconChar = FontAwesome.Sharp.IconChar.FileText;
            this.menuparteoperativo.IconColor = System.Drawing.Color.Black;
            this.menuparteoperativo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuparteoperativo.IconSize = 50;
            this.menuparteoperativo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuparteoperativo.Name = "menuparteoperativo";
            this.menuparteoperativo.Size = new System.Drawing.Size(93, 69);
            this.menuparteoperativo.Text = "PO Correctivo";
            this.menuparteoperativo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // submenuregistrar
            // 
            this.submenuregistrar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuregistrar.IconColor = System.Drawing.Color.Black;
            this.submenuregistrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenuregistrar.Name = "submenuregistrar";
            this.submenuregistrar.Size = new System.Drawing.Size(129, 22);
            this.submenuregistrar.Text = "Registrar";
            this.submenuregistrar.Click += new System.EventHandler(this.submenuregistrar_Click);
            // 
            // submenuverdetalle
            // 
            this.submenuverdetalle.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuverdetalle.IconColor = System.Drawing.Color.Black;
            this.submenuverdetalle.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenuverdetalle.Name = "submenuverdetalle";
            this.submenuverdetalle.Size = new System.Drawing.Size(129, 22);
            this.submenuverdetalle.Text = "Ver Detalle";
            this.submenuverdetalle.Click += new System.EventHandler(this.submenuverdetalle_Click);
            // 
            // menuEstadoPO
            // 
            this.menuEstadoPO.IconChar = FontAwesome.Sharp.IconChar.FileWaveform;
            this.menuEstadoPO.IconColor = System.Drawing.Color.Black;
            this.menuEstadoPO.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuEstadoPO.IconSize = 50;
            this.menuEstadoPO.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuEstadoPO.Name = "menuEstadoPO";
            this.menuEstadoPO.Size = new System.Drawing.Size(73, 69);
            this.menuEstadoPO.Text = "Estado PO";
            this.menuEstadoPO.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuEstadoPO.Click += new System.EventHandler(this.menuclientes_Click);
            // 
            // menuacompaniamiento
            // 
            this.menuacompaniamiento.IconChar = FontAwesome.Sharp.IconChar.PeoplePulling;
            this.menuacompaniamiento.IconColor = System.Drawing.Color.Black;
            this.menuacompaniamiento.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuacompaniamiento.IconSize = 50;
            this.menuacompaniamiento.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuacompaniamiento.Name = "menuacompaniamiento";
            this.menuacompaniamiento.Size = new System.Drawing.Size(120, 69);
            this.menuacompaniamiento.Text = "Acompañamientos";
            this.menuacompaniamiento.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuacompaniamiento.Click += new System.EventHandler(this.menuproveedores_Click);
            // 
            // menureportes
            // 
            this.menureportes.IconChar = FontAwesome.Sharp.IconChar.ChartBar;
            this.menureportes.IconColor = System.Drawing.Color.Black;
            this.menureportes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menureportes.IconSize = 50;
            this.menureportes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menureportes.Name = "menureportes";
            this.menureportes.Size = new System.Drawing.Size(65, 69);
            this.menureportes.Text = "Reportes";
            this.menureportes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menureportes.Click += new System.EventHandler(this.menureportes_Click);
            // 
            // menuacercade
            // 
            this.menuacercade.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            this.menuacercade.IconColor = System.Drawing.Color.Black;
            this.menuacercade.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuacercade.IconSize = 50;
            this.menuacercade.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuacercade.Name = "menuacercade";
            this.menuacercade.Size = new System.Drawing.Size(71, 69);
            this.menuacercade.Text = "Acerca de";
            this.menuacercade.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menuTitulo
            // 
            this.menuTitulo.AutoSize = false;
            this.menuTitulo.BackColor = System.Drawing.Color.SteelBlue;
            this.menuTitulo.Location = new System.Drawing.Point(0, 0);
            this.menuTitulo.Name = "menuTitulo";
            this.menuTitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuTitulo.Size = new System.Drawing.Size(1119, 58);
            this.menuTitulo.TabIndex = 1;
            this.menuTitulo.Text = "menuStrip1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Control de Asistencia";
            // 
            // contenedor
            // 
            this.contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contenedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contenedor.Location = new System.Drawing.Point(0, 131);
            this.contenedor.Name = "contenedor";
            this.contenedor.Size = new System.Drawing.Size(1119, 528);
            this.contenedor.TabIndex = 3;
            this.contenedor.Paint += new System.Windows.Forms.PaintEventHandler(this.contenedor_Paint);
            // 
            // lblusuario
            // 
            this.lblusuario.AutoSize = true;
            this.lblusuario.BackColor = System.Drawing.Color.SteelBlue;
            this.lblusuario.ForeColor = System.Drawing.Color.White;
            this.lblusuario.Location = new System.Drawing.Point(975, 23);
            this.lblusuario.Name = "lblusuario";
            this.lblusuario.Size = new System.Drawing.Size(51, 13);
            this.lblusuario.TabIndex = 4;
            this.lblusuario.Text = "lblusuario";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.SteelBlue;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(927, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Usuario:";
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 659);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblusuario);
            this.Controls.Add(this.contenedor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.menuTitulo);
            this.MainMenuStrip = this.menu;
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.MenuStrip menuTitulo;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconMenuItem menuacercade;
        private FontAwesome.Sharp.IconMenuItem menuusuarios;
        private FontAwesome.Sharp.IconMenuItem menumantenedor;
        private FontAwesome.Sharp.IconMenuItem menuasistencia;
        private FontAwesome.Sharp.IconMenuItem menuparteoperativo;
        private FontAwesome.Sharp.IconMenuItem menuEstadoPO;
        private FontAwesome.Sharp.IconMenuItem menuacompaniamiento;
        private FontAwesome.Sharp.IconMenuItem menureportes;
        private System.Windows.Forms.Panel contenedor;
        private System.Windows.Forms.Label lblusuario;
        private System.Windows.Forms.Label label3;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem1;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem2;
        private FontAwesome.Sharp.IconMenuItem submenuregistrarventa;
        private FontAwesome.Sharp.IconMenuItem verdetalleventa;
        private FontAwesome.Sharp.IconMenuItem submenuregistrar;
        private FontAwesome.Sharp.IconMenuItem submenuverdetalle;
    }
}

