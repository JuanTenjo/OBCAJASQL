
namespace OBCAJASQL.Forms.Caja.Reportes
{
    partial class FrmReportesGenerales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReportesGenerales));
            this.label17 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.RdResume = new System.Windows.Forms.RadioButton();
            this.RdServicios = new System.Windows.Forms.RadioButton();
            this.RdCuentasContables = new System.Windows.Forms.RadioButton();
            this.RdDigitadoresRecibos = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RdAnulados = new System.Windows.Forms.RadioButton();
            this.RdValidados = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtFecFinal = new System.Windows.Forms.DateTimePicker();
            this.DtFecInicial = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.CboNomServi = new System.Windows.Forms.ComboBox();
            this.LblNombreDelServicio = new System.Windows.Forms.Label();
            this.CboDigiNom = new System.Windows.Forms.ComboBox();
            this.LblDigitador = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.BtnMostrar = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.LblNomCajAct = new System.Windows.Forms.Label();
            this.LblCodCajAct = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.LblCodEntiFac = new System.Windows.Forms.Label();
            this.lblNivelPermitido = new System.Windows.Forms.Label();
            this.lblNombreUser = new System.Windows.Forms.Label();
            this.lblCodigoUser = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.White;
            this.label17.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(363, 333);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(64, 23);
            this.label17.TabIndex = 229;
            this.label17.Text = "Salir";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label39
            // 
            this.label39.BackColor = System.Drawing.Color.White;
            this.label39.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.ForeColor = System.Drawing.Color.Black;
            this.label39.Location = new System.Drawing.Point(223, 333);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(64, 23);
            this.label39.TabIndex = 227;
            this.label39.Text = "Mostrar";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.RdResume);
            this.groupBox3.Controls.Add(this.RdServicios);
            this.groupBox3.Controls.Add(this.RdCuentasContables);
            this.groupBox3.Controls.Add(this.RdDigitadoresRecibos);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(12, 148);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(175, 175);
            this.groupBox3.TabIndex = 225;
            this.groupBox3.TabStop = false;
            // 
            // RdResume
            // 
            this.RdResume.AutoSize = true;
            this.RdResume.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdResume.Location = new System.Drawing.Point(6, 114);
            this.RdResume.Name = "RdResume";
            this.RdResume.Size = new System.Drawing.Size(153, 18);
            this.RdResume.TabIndex = 9;
            this.RdResume.Text = "Por digitadores &Resume";
            this.RdResume.UseVisualStyleBackColor = true;
            this.RdResume.CheckedChanged += new System.EventHandler(this.RdResume_CheckedChanged);
            // 
            // RdServicios
            // 
            this.RdServicios.AutoSize = true;
            this.RdServicios.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdServicios.Location = new System.Drawing.Point(6, 92);
            this.RdServicios.Name = "RdServicios";
            this.RdServicios.Size = new System.Drawing.Size(93, 18);
            this.RdServicios.TabIndex = 8;
            this.RdServicios.Text = "Por &Servicios";
            this.RdServicios.UseVisualStyleBackColor = true;
            this.RdServicios.CheckedChanged += new System.EventHandler(this.RdServicios_CheckedChanged);
            // 
            // RdCuentasContables
            // 
            this.RdCuentasContables.AutoSize = true;
            this.RdCuentasContables.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdCuentasContables.Location = new System.Drawing.Point(6, 68);
            this.RdCuentasContables.Name = "RdCuentasContables";
            this.RdCuentasContables.Size = new System.Drawing.Size(147, 18);
            this.RdCuentasContables.TabIndex = 7;
            this.RdCuentasContables.Text = "Por &Cuentas contables";
            this.RdCuentasContables.UseVisualStyleBackColor = true;
            this.RdCuentasContables.CheckedChanged += new System.EventHandler(this.RdCuentasContables_CheckedChanged);
            // 
            // RdDigitadoresRecibos
            // 
            this.RdDigitadoresRecibos.AutoSize = true;
            this.RdDigitadoresRecibos.Checked = true;
            this.RdDigitadoresRecibos.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdDigitadoresRecibos.Location = new System.Drawing.Point(6, 46);
            this.RdDigitadoresRecibos.Name = "RdDigitadoresRecibos";
            this.RdDigitadoresRecibos.Size = new System.Drawing.Size(149, 18);
            this.RdDigitadoresRecibos.TabIndex = 6;
            this.RdDigitadoresRecibos.TabStop = true;
            this.RdDigitadoresRecibos.Text = "Por &Digitadores recibos";
            this.RdDigitadoresRecibos.UseVisualStyleBackColor = true;
            this.RdDigitadoresRecibos.CheckedChanged += new System.EventHandler(this.RdDigitadoresRecibos_CheckedChanged);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(175, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "Listar los recibos por";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.RdAnulados);
            this.groupBox2.Controls.Add(this.RdValidados);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(12, 59);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(175, 83);
            this.groupBox2.TabIndex = 224;
            this.groupBox2.TabStop = false;
            // 
            // RdAnulados
            // 
            this.RdAnulados.AutoSize = true;
            this.RdAnulados.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdAnulados.Location = new System.Drawing.Point(6, 53);
            this.RdAnulados.Name = "RdAnulados";
            this.RdAnulados.Size = new System.Drawing.Size(74, 18);
            this.RdAnulados.TabIndex = 7;
            this.RdAnulados.Text = "Anulados";
            this.RdAnulados.UseVisualStyleBackColor = true;
            this.RdAnulados.CheckedChanged += new System.EventHandler(this.RdAnulados_CheckedChanged);
            // 
            // RdValidados
            // 
            this.RdValidados.AutoSize = true;
            this.RdValidados.Checked = true;
            this.RdValidados.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdValidados.Location = new System.Drawing.Point(6, 31);
            this.RdValidados.Name = "RdValidados";
            this.RdValidados.Size = new System.Drawing.Size(62, 18);
            this.RdValidados.TabIndex = 6;
            this.RdValidados.TabStop = true;
            this.RdValidados.Text = "Válidos";
            this.RdValidados.UseVisualStyleBackColor = true;
            this.RdValidados.CheckedChanged += new System.EventHandler(this.RdValidados_CheckedChanged);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(175, 23);
            this.label6.TabIndex = 5;
            this.label6.Text = "Mostrar sólo los";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.DtFecFinal);
            this.groupBox1.Controls.Add(this.DtFecInicial);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(196, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(254, 83);
            this.groupBox1.TabIndex = 223;
            this.groupBox1.TabStop = false;
            // 
            // DtFecFinal
            // 
            this.DtFecFinal.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.DtFecFinal.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.DtFecFinal.CustomFormat = "dd-MMM-yyyy";
            this.DtFecFinal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtFecFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtFecFinal.Location = new System.Drawing.Point(122, 51);
            this.DtFecFinal.Name = "DtFecFinal";
            this.DtFecFinal.Size = new System.Drawing.Size(127, 22);
            this.DtFecFinal.TabIndex = 22;
            // 
            // DtFecInicial
            // 
            this.DtFecInicial.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.DtFecInicial.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.DtFecInicial.CustomFormat = "dd-MMM-yyyy";
            this.DtFecInicial.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtFecInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtFecInicial.Location = new System.Drawing.Point(122, 29);
            this.DtFecInicial.Name = "DtFecInicial";
            this.DtFecInicial.Size = new System.Drawing.Size(127, 22);
            this.DtFecInicial.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "Fecha final:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "Fecha inicial:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(254, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Periodo a mostrar";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.White;
            this.groupBox4.Controls.Add(this.CboNomServi);
            this.groupBox4.Controls.Add(this.LblNombreDelServicio);
            this.groupBox4.Controls.Add(this.CboDigiNom);
            this.groupBox4.Controls.Add(this.LblDigitador);
            this.groupBox4.Location = new System.Drawing.Point(193, 148);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(257, 175);
            this.groupBox4.TabIndex = 230;
            this.groupBox4.TabStop = false;
            // 
            // CboNomServi
            // 
            this.CboNomServi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CboNomServi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CboNomServi.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboNomServi.FormattingEnabled = true;
            this.CboNomServi.Location = new System.Drawing.Point(0, 118);
            this.CboNomServi.Name = "CboNomServi";
            this.CboNomServi.Size = new System.Drawing.Size(252, 22);
            this.CboNomServi.TabIndex = 26;
            this.CboNomServi.Visible = false;
            this.CboNomServi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CboNomServi_KeyPress);
            // 
            // LblNombreDelServicio
            // 
            this.LblNombreDelServicio.BackColor = System.Drawing.Color.LightSeaGreen;
            this.LblNombreDelServicio.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNombreDelServicio.ForeColor = System.Drawing.Color.White;
            this.LblNombreDelServicio.Location = new System.Drawing.Point(0, 89);
            this.LblNombreDelServicio.Name = "LblNombreDelServicio";
            this.LblNombreDelServicio.Size = new System.Drawing.Size(252, 23);
            this.LblNombreDelServicio.TabIndex = 25;
            this.LblNombreDelServicio.Text = "Nombre del servicio";
            this.LblNombreDelServicio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblNombreDelServicio.Visible = false;
            // 
            // CboDigiNom
            // 
            this.CboDigiNom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CboDigiNom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CboDigiNom.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboDigiNom.FormattingEnabled = true;
            this.CboDigiNom.Location = new System.Drawing.Point(0, 56);
            this.CboDigiNom.Name = "CboDigiNom";
            this.CboDigiNom.Size = new System.Drawing.Size(252, 22);
            this.CboDigiNom.TabIndex = 24;
            this.CboDigiNom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CboDigiNom_KeyPress);
            // 
            // LblDigitador
            // 
            this.LblDigitador.BackColor = System.Drawing.Color.LightSeaGreen;
            this.LblDigitador.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDigitador.ForeColor = System.Drawing.Color.White;
            this.LblDigitador.Location = new System.Drawing.Point(-3, 30);
            this.LblDigitador.Name = "LblDigitador";
            this.LblDigitador.Size = new System.Drawing.Size(255, 23);
            this.LblDigitador.TabIndex = 23;
            this.LblDigitador.Text = "Nombre del digitador";
            this.LblDigitador.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(293, 333);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 23);
            this.label8.TabIndex = 232;
            this.label8.Text = "&Exportar";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.BackgroundImage = global::OBCAJASQL.Properties.Resources.exportar1;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(293, 355);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 44);
            this.button1.TabIndex = 231;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // BtnSalir
            // 
            this.BtnSalir.BackColor = System.Drawing.Color.White;
            this.BtnSalir.BackgroundImage = global::OBCAJASQL.Properties.Resources.cerrar40px;
            this.BtnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnSalir.FlatAppearance.BorderSize = 0;
            this.BtnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.BtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSalir.Location = new System.Drawing.Point(363, 355);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(64, 44);
            this.BtnSalir.TabIndex = 228;
            this.BtnSalir.UseVisualStyleBackColor = false;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // BtnMostrar
            // 
            this.BtnMostrar.BackColor = System.Drawing.Color.White;
            this.BtnMostrar.BackgroundImage = global::OBCAJASQL.Properties.Resources.mostrar;
            this.BtnMostrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnMostrar.FlatAppearance.BorderSize = 0;
            this.BtnMostrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.BtnMostrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMostrar.Location = new System.Drawing.Point(223, 355);
            this.BtnMostrar.Name = "BtnMostrar";
            this.BtnMostrar.Size = new System.Drawing.Size(64, 44);
            this.BtnMostrar.TabIndex = 226;
            this.BtnMostrar.UseVisualStyleBackColor = false;
            this.BtnMostrar.Click += new System.EventHandler(this.BtnMostrar_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.White;
            this.groupBox5.Controls.Add(this.LblNomCajAct);
            this.groupBox5.Controls.Add(this.LblCodCajAct);
            this.groupBox5.Controls.Add(this.label29);
            this.groupBox5.Location = new System.Drawing.Point(12, 4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(438, 52);
            this.groupBox5.TabIndex = 233;
            this.groupBox5.TabStop = false;
            // 
            // LblNomCajAct
            // 
            this.LblNomCajAct.BackColor = System.Drawing.Color.White;
            this.LblNomCajAct.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNomCajAct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.LblNomCajAct.Location = new System.Drawing.Point(131, 12);
            this.LblNomCajAct.Name = "LblNomCajAct";
            this.LblNomCajAct.Size = new System.Drawing.Size(292, 32);
            this.LblNomCajAct.TabIndex = 22;
            this.LblNomCajAct.Text = "NomCajAct";
            this.LblNomCajAct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblCodCajAct
            // 
            this.LblCodCajAct.BackColor = System.Drawing.Color.White;
            this.LblCodCajAct.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCodCajAct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.LblCodCajAct.Location = new System.Drawing.Point(74, 12);
            this.LblCodCajAct.Name = "LblCodCajAct";
            this.LblCodCajAct.Size = new System.Drawing.Size(51, 32);
            this.LblCodCajAct.TabIndex = 21;
            this.LblCodCajAct.Text = "Cod";
            this.LblCodCajAct.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label29
            // 
            this.label29.BackColor = System.Drawing.Color.White;
            this.label29.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.Black;
            this.label29.Location = new System.Drawing.Point(21, 12);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(51, 32);
            this.label29.TabIndex = 20;
            this.label29.Text = "CAJA:";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.LblCodEntiFac);
            this.groupBox6.Controls.Add(this.lblNivelPermitido);
            this.groupBox6.Controls.Add(this.lblNombreUser);
            this.groupBox6.Controls.Add(this.lblCodigoUser);
            this.groupBox6.Controls.Add(this.label45);
            this.groupBox6.Location = new System.Drawing.Point(12, 347);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(175, 52);
            this.groupBox6.TabIndex = 234;
            this.groupBox6.TabStop = false;
            // 
            // LblCodEntiFac
            // 
            this.LblCodEntiFac.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCodEntiFac.Location = new System.Drawing.Point(124, 5);
            this.LblCodEntiFac.Name = "LblCodEntiFac";
            this.LblCodEntiFac.Size = new System.Drawing.Size(34, 13);
            this.LblCodEntiFac.TabIndex = 33;
            this.LblCodEntiFac.Text = "CodEntiFac";
            this.LblCodEntiFac.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblCodEntiFac.Visible = false;
            // 
            // lblNivelPermitido
            // 
            this.lblNivelPermitido.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNivelPermitido.Location = new System.Drawing.Point(85, 5);
            this.lblNivelPermitido.Name = "lblNivelPermitido";
            this.lblNivelPermitido.Size = new System.Drawing.Size(25, 13);
            this.lblNivelPermitido.TabIndex = 32;
            this.lblNivelPermitido.Text = "NivelPermitido";
            this.lblNivelPermitido.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNivelPermitido.Visible = false;
            // 
            // lblNombreUser
            // 
            this.lblNombreUser.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreUser.Location = new System.Drawing.Point(6, 24);
            this.lblNombreUser.Name = "lblNombreUser";
            this.lblNombreUser.Size = new System.Drawing.Size(169, 25);
            this.lblNombreUser.TabIndex = 12;
            this.lblNombreUser.Text = "NombreUser";
            // 
            // lblCodigoUser
            // 
            this.lblCodigoUser.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigoUser.Location = new System.Drawing.Point(42, 5);
            this.lblCodigoUser.Name = "lblCodigoUser";
            this.lblCodigoUser.Size = new System.Drawing.Size(37, 13);
            this.lblCodigoUser.TabIndex = 11;
            this.lblCodigoUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label45
            // 
            this.label45.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.Location = new System.Drawing.Point(-1, 5);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(37, 13);
            this.label45.TabIndex = 10;
            this.label45.Text = "ID:";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmReportesGenerales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 417);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.BtnMostrar);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmReportesGenerales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "REPORTES RELACIONADOS CON LOS INGRESOS DE CAJA";
            this.Load += new System.EventHandler(this.FrmReportesGenerales_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Button BtnMostrar;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton RdResume;
        private System.Windows.Forms.RadioButton RdServicios;
        private System.Windows.Forms.RadioButton RdCuentasContables;
        private System.Windows.Forms.RadioButton RdDigitadoresRecibos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton RdAnulados;
        private System.Windows.Forms.RadioButton RdValidados;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker DtFecFinal;
        private System.Windows.Forms.DateTimePicker DtFecInicial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox CboDigiNom;
        private System.Windows.Forms.Label LblDigitador;
        private System.Windows.Forms.ComboBox CboNomServi;
        private System.Windows.Forms.Label LblNombreDelServicio;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label LblNomCajAct;
        private System.Windows.Forms.Label LblCodCajAct;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label LblCodEntiFac;
        private System.Windows.Forms.Label lblNivelPermitido;
        private System.Windows.Forms.Label lblNombreUser;
        private System.Windows.Forms.Label lblCodigoUser;
        private System.Windows.Forms.Label label45;
    }
}