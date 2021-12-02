
namespace OBCAJASQL.Forms
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.auditoriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.facturasConSaldoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ingresosGeneralesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pagosAFacturasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.depositosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ingresosDeCajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesGeneralesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crucesPorDesositosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anularRecibosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pagaresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ingresarPagaresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pagosDePagaresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pagosYSaldosDePagareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pagaresRegistradosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anularPagaresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parametroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datosDeLaEmpresaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.lblFecha = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCodUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNomUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.LblNombreEmpresa = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.administraciónToolStripMenuItem,
            this.cajaToolStripMenuItem,
            this.pagaresToolStripMenuItem,
            this.parametroToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "&Archivo";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.salirToolStripMenuItem.Text = "&Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // administraciónToolStripMenuItem
            // 
            this.administraciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.auditoriaToolStripMenuItem});
            this.administraciónToolStripMenuItem.Name = "administraciónToolStripMenuItem";
            this.administraciónToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.administraciónToolStripMenuItem.Text = "&Administración";
            // 
            // auditoriaToolStripMenuItem
            // 
            this.auditoriaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.facturasConSaldoToolStripMenuItem});
            this.auditoriaToolStripMenuItem.Name = "auditoriaToolStripMenuItem";
            this.auditoriaToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.auditoriaToolStripMenuItem.Text = "&Auditoria";
            // 
            // facturasConSaldoToolStripMenuItem
            // 
            this.facturasConSaldoToolStripMenuItem.Name = "facturasConSaldoToolStripMenuItem";
            this.facturasConSaldoToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.facturasConSaldoToolStripMenuItem.Text = "&Facturas Con Saldo";
            this.facturasConSaldoToolStripMenuItem.Click += new System.EventHandler(this.facturasConSaldoToolStripMenuItem_Click);
            // 
            // cajaToolStripMenuItem
            // 
            this.cajaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ingresosGeneralesToolStripMenuItem,
            this.pagosAFacturasToolStripMenuItem,
            this.depositosToolStripMenuItem,
            this.reportesToolStripMenuItem,
            this.anularRecibosToolStripMenuItem});
            this.cajaToolStripMenuItem.Name = "cajaToolStripMenuItem";
            this.cajaToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.cajaToolStripMenuItem.Text = "&Caja";
            // 
            // ingresosGeneralesToolStripMenuItem
            // 
            this.ingresosGeneralesToolStripMenuItem.Name = "ingresosGeneralesToolStripMenuItem";
            this.ingresosGeneralesToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.ingresosGeneralesToolStripMenuItem.Text = "&Ingresos Generales";
            this.ingresosGeneralesToolStripMenuItem.Click += new System.EventHandler(this.ingresosGeneralesToolStripMenuItem_Click);
            // 
            // pagosAFacturasToolStripMenuItem
            // 
            this.pagosAFacturasToolStripMenuItem.Name = "pagosAFacturasToolStripMenuItem";
            this.pagosAFacturasToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.pagosAFacturasToolStripMenuItem.Text = "&Pagos a Facturas";
            // 
            // depositosToolStripMenuItem
            // 
            this.depositosToolStripMenuItem.Name = "depositosToolStripMenuItem";
            this.depositosToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.depositosToolStripMenuItem.Text = "&Depositos";
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ingresosDeCajaToolStripMenuItem,
            this.reportesGeneralesToolStripMenuItem,
            this.crucesPorDesositosToolStripMenuItem});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.reportesToolStripMenuItem.Text = "&Reportes";
            // 
            // ingresosDeCajaToolStripMenuItem
            // 
            this.ingresosDeCajaToolStripMenuItem.Name = "ingresosDeCajaToolStripMenuItem";
            this.ingresosDeCajaToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.ingresosDeCajaToolStripMenuItem.Text = "&Ingresos De Caja";
            // 
            // reportesGeneralesToolStripMenuItem
            // 
            this.reportesGeneralesToolStripMenuItem.Name = "reportesGeneralesToolStripMenuItem";
            this.reportesGeneralesToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.reportesGeneralesToolStripMenuItem.Text = "&Reportes Generales";
            // 
            // crucesPorDesositosToolStripMenuItem
            // 
            this.crucesPorDesositosToolStripMenuItem.Name = "crucesPorDesositosToolStripMenuItem";
            this.crucesPorDesositosToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.crucesPorDesositosToolStripMenuItem.Text = "&Cruces Por Depositos";
            // 
            // anularRecibosToolStripMenuItem
            // 
            this.anularRecibosToolStripMenuItem.Name = "anularRecibosToolStripMenuItem";
            this.anularRecibosToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.anularRecibosToolStripMenuItem.Text = "&Anular Recibo";
            // 
            // pagaresToolStripMenuItem
            // 
            this.pagaresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ingresarPagaresToolStripMenuItem,
            this.pagosDePagaresToolStripMenuItem,
            this.reportesToolStripMenuItem1,
            this.anularPagaresToolStripMenuItem});
            this.pagaresToolStripMenuItem.Name = "pagaresToolStripMenuItem";
            this.pagaresToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.pagaresToolStripMenuItem.Text = "&Pagares";
            // 
            // ingresarPagaresToolStripMenuItem
            // 
            this.ingresarPagaresToolStripMenuItem.Name = "ingresarPagaresToolStripMenuItem";
            this.ingresarPagaresToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.ingresarPagaresToolStripMenuItem.Text = "&Ingresar Pagares";
            // 
            // pagosDePagaresToolStripMenuItem
            // 
            this.pagosDePagaresToolStripMenuItem.Name = "pagosDePagaresToolStripMenuItem";
            this.pagosDePagaresToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.pagosDePagaresToolStripMenuItem.Text = "&Pagos De Pagares";
            // 
            // reportesToolStripMenuItem1
            // 
            this.reportesToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pagosYSaldosDePagareToolStripMenuItem,
            this.pagaresRegistradosToolStripMenuItem});
            this.reportesToolStripMenuItem1.Name = "reportesToolStripMenuItem1";
            this.reportesToolStripMenuItem1.Size = new System.Drawing.Size(167, 22);
            this.reportesToolStripMenuItem1.Text = "&Reportes";
            // 
            // pagosYSaldosDePagareToolStripMenuItem
            // 
            this.pagosYSaldosDePagareToolStripMenuItem.Name = "pagosYSaldosDePagareToolStripMenuItem";
            this.pagosYSaldosDePagareToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.pagosYSaldosDePagareToolStripMenuItem.Text = "&Pagos y Saldos De Pagare";
            // 
            // pagaresRegistradosToolStripMenuItem
            // 
            this.pagaresRegistradosToolStripMenuItem.Name = "pagaresRegistradosToolStripMenuItem";
            this.pagaresRegistradosToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.pagaresRegistradosToolStripMenuItem.Text = "&Pagares Registrados";
            // 
            // anularPagaresToolStripMenuItem
            // 
            this.anularPagaresToolStripMenuItem.Name = "anularPagaresToolStripMenuItem";
            this.anularPagaresToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.anularPagaresToolStripMenuItem.Text = "&Anular Pagares";
            // 
            // parametroToolStripMenuItem
            // 
            this.parametroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.datosDeLaEmpresaToolStripMenuItem});
            this.parametroToolStripMenuItem.Name = "parametroToolStripMenuItem";
            this.parametroToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.parametroToolStripMenuItem.Text = "&Parametros";
            // 
            // datosDeLaEmpresaToolStripMenuItem
            // 
            this.datosDeLaEmpresaToolStripMenuItem.Name = "datosDeLaEmpresaToolStripMenuItem";
            this.datosDeLaEmpresaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.datosDeLaEmpresaToolStripMenuItem.Text = "Datos de la Empresa";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblFecha,
            this.lblCodUsuario,
            this.lblNomUsuario});
            this.toolStrip1.Location = new System.Drawing.Point(0, 425);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // lblFecha
            // 
            this.lblFecha.BackColor = System.Drawing.Color.White;
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(118, 20);
            this.lblFecha.Text = "toolStripStatusLabel1";
            this.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCodUsuario
            // 
            this.lblCodUsuario.BackColor = System.Drawing.Color.White;
            this.lblCodUsuario.Name = "lblCodUsuario";
            this.lblCodUsuario.Size = new System.Drawing.Size(118, 20);
            this.lblCodUsuario.Text = "toolStripStatusLabel1";
            // 
            // lblNomUsuario
            // 
            this.lblNomUsuario.BackColor = System.Drawing.Color.White;
            this.lblNomUsuario.Name = "lblNomUsuario";
            this.lblNomUsuario.Size = new System.Drawing.Size(118, 20);
            this.lblNomUsuario.Text = "toolStripStatusLabel2";
            // 
            // LblNombreEmpresa
            // 
            this.LblNombreEmpresa.AutoSize = true;
            this.LblNombreEmpresa.BackColor = System.Drawing.Color.Transparent;
            this.LblNombreEmpresa.Dock = System.Windows.Forms.DockStyle.Right;
            this.LblNombreEmpresa.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LblNombreEmpresa.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNombreEmpresa.ForeColor = System.Drawing.Color.White;
            this.LblNombreEmpresa.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LblNombreEmpresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblNombreEmpresa.Location = new System.Drawing.Point(705, 24);
            this.LblNombreEmpresa.Margin = new System.Windows.Forms.Padding(30, 10, 30, 10);
            this.LblNombreEmpresa.Name = "LblNombreEmpresa";
            this.LblNombreEmpresa.Padding = new System.Windows.Forms.Padding(0, 30, 40, 0);
            this.LblNombreEmpresa.Size = new System.Drawing.Size(95, 48);
            this.LblNombreEmpresa.TabIndex = 6;
            this.LblNombreEmpresa.Text = "label1";
            this.LblNombreEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::OBCAJASQL.Properties.Resources.fondo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LblNombreEmpresa);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPrincipal";
            this.Text = "GESTION CAJA 1.1.1  (17-11-2021)  *** SIIGHOS PLUS ***";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administraciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cajaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pagaresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem auditoriaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem facturasConSaldoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ingresosGeneralesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pagosAFacturasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem depositosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ingresosDeCajaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesGeneralesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crucesPorDesositosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem anularRecibosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ingresarPagaresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pagosDePagaresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pagosYSaldosDePagareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pagaresRegistradosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem anularPagaresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parametroToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblFecha;
        private System.Windows.Forms.ToolStripStatusLabel lblCodUsuario;
        private System.Windows.Forms.ToolStripStatusLabel lblNomUsuario;
        private System.Windows.Forms.Label LblNombreEmpresa;
        private System.Windows.Forms.ToolStripMenuItem datosDeLaEmpresaToolStripMenuItem;
    }
}