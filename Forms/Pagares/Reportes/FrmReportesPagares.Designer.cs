
namespace OBCAJASQL.Forms.Pagares.Reportes
{
    partial class FrmReportesPagares
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonAnuladas = new System.Windows.Forms.RadioButton();
            this.radioButtonValidas = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DtFecFinal = new System.Windows.Forms.DateTimePicker();
            this.DtFecInicial = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtFacNumPa = new System.Windows.Forms.TextBox();
            this.TxtHistoriaPaci = new System.Windows.Forms.TextBox();
            this.TxtTipoDoCodeu = new System.Windows.Forms.TextBox();
            this.LblHistoriaNo = new System.Windows.Forms.Label();
            this.LblDocumentoNo = new System.Windows.Forms.Label();
            this.LblNoPagare = new System.Windows.Forms.Label();
            this.CboDigiNom = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.BtnMostrar = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.LblCodEntiFac = new System.Windows.Forms.Label();
            this.lblNivelPermitido = new System.Windows.Forms.Label();
            this.lblNombreUser = new System.Windows.Forms.Label();
            this.lblCodigoUser = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.TxtNumDoCodeu = new System.Windows.Forms.TextBox();
            this.TxtNumDoRespon = new System.Windows.Forms.TextBox();
            this.TxtTipoDoRespon = new System.Windows.Forms.TextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.radioButtonAnuladas);
            this.groupBox1.Controls.Add(this.radioButtonValidas);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.groupBox1.Location = new System.Drawing.Point(12, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(150, 110);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // radioButtonAnuladas
            // 
            this.radioButtonAnuladas.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonAnuladas.Location = new System.Drawing.Point(4, 67);
            this.radioButtonAnuladas.Name = "radioButtonAnuladas";
            this.radioButtonAnuladas.Size = new System.Drawing.Size(143, 17);
            this.radioButtonAnuladas.TabIndex = 6;
            this.radioButtonAnuladas.Text = "Anuladas";
            this.radioButtonAnuladas.UseVisualStyleBackColor = true;
            this.radioButtonAnuladas.CheckedChanged += new System.EventHandler(this.radioButtonAnuladas_CheckedChanged);
            // 
            // radioButtonValidas
            // 
            this.radioButtonValidas.Checked = true;
            this.radioButtonValidas.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonValidas.Location = new System.Drawing.Point(4, 37);
            this.radioButtonValidas.Name = "radioButtonValidas";
            this.radioButtonValidas.Size = new System.Drawing.Size(143, 24);
            this.radioButtonValidas.TabIndex = 5;
            this.radioButtonValidas.TabStop = true;
            this.radioButtonValidas.Text = "Válidas";
            this.radioButtonValidas.UseVisualStyleBackColor = true;
            this.radioButtonValidas.CheckedChanged += new System.EventHandler(this.radioButtonValidas_CheckedChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(-3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Listar Los Pagarés";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.DtFecFinal);
            this.groupBox3.Controls.Add(this.DtFecInicial);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(168, 21);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(232, 110);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            // 
            // DtFecFinal
            // 
            this.DtFecFinal.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.DtFecFinal.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.DtFecFinal.CustomFormat = "dd-MMM-yyyy";
            this.DtFecFinal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtFecFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtFecFinal.Location = new System.Drawing.Point(106, 61);
            this.DtFecFinal.Name = "DtFecFinal";
            this.DtFecFinal.Size = new System.Drawing.Size(113, 22);
            this.DtFecFinal.TabIndex = 26;
            // 
            // DtFecInicial
            // 
            this.DtFecInicial.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.DtFecInicial.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.DtFecInicial.CustomFormat = "dd-MMM-yyyy";
            this.DtFecInicial.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtFecInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtFecInicial.Location = new System.Drawing.Point(106, 39);
            this.DtFecInicial.Name = "DtFecInicial";
            this.DtFecInicial.Size = new System.Drawing.Size(113, 22);
            this.DtFecInicial.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(16, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 23);
            this.label4.TabIndex = 24;
            this.label4.Text = "Fecha final:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(16, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 23);
            this.label5.TabIndex = 23;
            this.label5.Text = "Fecha inicial:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(-3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(235, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Periodo a listar";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.White;
            this.groupBox4.Controls.Add(this.radioButton7);
            this.groupBox4.Controls.Add(this.radioButton1);
            this.groupBox4.Controls.Add(this.radioButton2);
            this.groupBox4.Controls.Add(this.radioButton5);
            this.groupBox4.Controls.Add(this.radioButton6);
            this.groupBox4.Controls.Add(this.radioButton3);
            this.groupBox4.Controls.Add(this.radioButton4);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Location = new System.Drawing.Point(12, 137);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(150, 196);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            // 
            // radioButton5
            // 
            this.radioButton5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton5.Location = new System.Drawing.Point(3, 173);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(143, 17);
            this.radioButton5.TabIndex = 8;
            this.radioButton5.Text = "&Todos";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            // 
            // radioButton6
            // 
            this.radioButton6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton6.Location = new System.Drawing.Point(4, 148);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(143, 24);
            this.radioButton6.TabIndex = 7;
            this.radioButton6.Text = "Por &Pacientes";
            this.radioButton6.UseVisualStyleBackColor = true;
            this.radioButton6.CheckedChanged += new System.EventHandler(this.radioButton6_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton3.Location = new System.Drawing.Point(3, 56);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(153, 17);
            this.radioButton3.TabIndex = 6;
            this.radioButton3.Text = "Por &Cuentas contables";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.Checked = true;
            this.radioButton4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton4.Location = new System.Drawing.Point(3, 26);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(143, 24);
            this.radioButton4.TabIndex = 5;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Por &Digitadores";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(-3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(153, 23);
            this.label6.TabIndex = 3;
            this.label6.Text = "Lista los pagarés por";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.TxtNumDoRespon);
            this.groupBox2.Controls.Add(this.TxtTipoDoRespon);
            this.groupBox2.Controls.Add(this.TxtNumDoCodeu);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.TxtFacNumPa);
            this.groupBox2.Controls.Add(this.TxtHistoriaPaci);
            this.groupBox2.Controls.Add(this.TxtTipoDoCodeu);
            this.groupBox2.Controls.Add(this.LblHistoriaNo);
            this.groupBox2.Controls.Add(this.LblDocumentoNo);
            this.groupBox2.Controls.Add(this.LblNoPagare);
            this.groupBox2.Controls.Add(this.CboDigiNom);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(168, 137);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(232, 196);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(6, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 20);
            this.label7.TabIndex = 231;
            this.label7.Text = "Documento No:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TxtFacNumPa
            // 
            this.TxtFacNumPa.Location = new System.Drawing.Point(96, 67);
            this.TxtFacNumPa.Name = "TxtFacNumPa";
            this.TxtFacNumPa.Size = new System.Drawing.Size(127, 20);
            this.TxtFacNumPa.TabIndex = 228;
            // 
            // TxtHistoriaPaci
            // 
            this.TxtHistoriaPaci.Location = new System.Drawing.Point(96, 145);
            this.TxtHistoriaPaci.Name = "TxtHistoriaPaci";
            this.TxtHistoriaPaci.Size = new System.Drawing.Size(127, 20);
            this.TxtHistoriaPaci.TabIndex = 230;
            this.TxtHistoriaPaci.Visible = false;
            // 
            // TxtTipoDoCodeu
            // 
            this.TxtTipoDoCodeu.Location = new System.Drawing.Point(96, 94);
            this.TxtTipoDoCodeu.Name = "TxtTipoDoCodeu";
            this.TxtTipoDoCodeu.Size = new System.Drawing.Size(37, 20);
            this.TxtTipoDoCodeu.TabIndex = 229;
            this.TxtTipoDoCodeu.Visible = false;
            // 
            // LblHistoriaNo
            // 
            this.LblHistoriaNo.BackColor = System.Drawing.Color.LightSeaGreen;
            this.LblHistoriaNo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblHistoriaNo.ForeColor = System.Drawing.Color.White;
            this.LblHistoriaNo.Location = new System.Drawing.Point(6, 145);
            this.LblHistoriaNo.Name = "LblHistoriaNo";
            this.LblHistoriaNo.Size = new System.Drawing.Size(84, 20);
            this.LblHistoriaNo.TabIndex = 227;
            this.LblHistoriaNo.Text = "Historia No:";
            this.LblHistoriaNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblDocumentoNo
            // 
            this.LblDocumentoNo.BackColor = System.Drawing.Color.LightSeaGreen;
            this.LblDocumentoNo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDocumentoNo.ForeColor = System.Drawing.Color.White;
            this.LblDocumentoNo.Location = new System.Drawing.Point(6, 93);
            this.LblDocumentoNo.Name = "LblDocumentoNo";
            this.LblDocumentoNo.Size = new System.Drawing.Size(84, 20);
            this.LblDocumentoNo.TabIndex = 226;
            this.LblDocumentoNo.Text = "Documento No:";
            this.LblDocumentoNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblNoPagare
            // 
            this.LblNoPagare.BackColor = System.Drawing.Color.LightSeaGreen;
            this.LblNoPagare.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNoPagare.ForeColor = System.Drawing.Color.White;
            this.LblNoPagare.Location = new System.Drawing.Point(6, 65);
            this.LblNoPagare.Name = "LblNoPagare";
            this.LblNoPagare.Size = new System.Drawing.Size(84, 21);
            this.LblNoPagare.TabIndex = 225;
            this.LblNoPagare.Text = "No. Pagaré:";
            this.LblNoPagare.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CboDigiNom
            // 
            this.CboDigiNom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CboDigiNom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CboDigiNom.FormattingEnabled = true;
            this.CboDigiNom.Location = new System.Drawing.Point(6, 37);
            this.CboDigiNom.Name = "CboDigiNom";
            this.CboDigiNom.Size = new System.Drawing.Size(217, 21);
            this.CboDigiNom.TabIndex = 4;
            this.CboDigiNom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CboDigiNom_KeyPress);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(-3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nombre del digitador";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(16, 338);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 21);
            this.label9.TabIndex = 141;
            this.label9.Text = "Mostrar";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnMostrar
            // 
            this.BtnMostrar.BackColor = System.Drawing.Color.White;
            this.BtnMostrar.BackgroundImage = global::OBCAJASQL.Properties.Resources.mostrar;
            this.BtnMostrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnMostrar.FlatAppearance.BorderSize = 0;
            this.BtnMostrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.BtnMostrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMostrar.Location = new System.Drawing.Point(16, 360);
            this.BtnMostrar.Name = "BtnMostrar";
            this.BtnMostrar.Size = new System.Drawing.Size(65, 42);
            this.BtnMostrar.TabIndex = 140;
            this.BtnMostrar.UseVisualStyleBackColor = false;
            this.BtnMostrar.Click += new System.EventHandler(this.BtnMostrar_Click);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(90, 338);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 21);
            this.label10.TabIndex = 139;
            this.label10.Text = "Salir";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnSalir
            // 
            this.BtnSalir.BackColor = System.Drawing.Color.White;
            this.BtnSalir.BackgroundImage = global::OBCAJASQL.Properties.Resources.cerrar40px;
            this.BtnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnSalir.FlatAppearance.BorderSize = 0;
            this.BtnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.BtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSalir.Location = new System.Drawing.Point(90, 360);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(57, 42);
            this.BtnSalir.TabIndex = 138;
            this.BtnSalir.UseVisualStyleBackColor = false;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.LblCodEntiFac);
            this.groupBox7.Controls.Add(this.lblNivelPermitido);
            this.groupBox7.Controls.Add(this.lblNombreUser);
            this.groupBox7.Controls.Add(this.lblCodigoUser);
            this.groupBox7.Controls.Add(this.label16);
            this.groupBox7.Location = new System.Drawing.Point(224, 338);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(162, 64);
            this.groupBox7.TabIndex = 137;
            this.groupBox7.TabStop = false;
            // 
            // LblCodEntiFac
            // 
            this.LblCodEntiFac.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCodEntiFac.Location = new System.Drawing.Point(121, 9);
            this.LblCodEntiFac.Name = "LblCodEntiFac";
            this.LblCodEntiFac.Size = new System.Drawing.Size(34, 13);
            this.LblCodEntiFac.TabIndex = 31;
            this.LblCodEntiFac.Text = "CodEntiFac";
            this.LblCodEntiFac.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblCodEntiFac.Visible = false;
            // 
            // lblNivelPermitido
            // 
            this.lblNivelPermitido.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNivelPermitido.Location = new System.Drawing.Point(82, 9);
            this.lblNivelPermitido.Name = "lblNivelPermitido";
            this.lblNivelPermitido.Size = new System.Drawing.Size(25, 13);
            this.lblNivelPermitido.TabIndex = 30;
            this.lblNivelPermitido.Text = "NivelPermitido";
            this.lblNivelPermitido.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNivelPermitido.Visible = false;
            // 
            // lblNombreUser
            // 
            this.lblNombreUser.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreUser.Location = new System.Drawing.Point(3, 22);
            this.lblNombreUser.Name = "lblNombreUser";
            this.lblNombreUser.Size = new System.Drawing.Size(152, 32);
            this.lblNombreUser.TabIndex = 11;
            this.lblNombreUser.Text = "NombreUser";
            this.lblNombreUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCodigoUser
            // 
            this.lblCodigoUser.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigoUser.Location = new System.Drawing.Point(31, 9);
            this.lblCodigoUser.Name = "lblCodigoUser";
            this.lblCodigoUser.Size = new System.Drawing.Size(76, 13);
            this.lblCodigoUser.TabIndex = 9;
            this.lblCodigoUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(1, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(31, 13);
            this.label16.TabIndex = 8;
            this.label16.Text = "ID:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TxtNumDoCodeu
            // 
            this.TxtNumDoCodeu.Location = new System.Drawing.Point(134, 94);
            this.TxtNumDoCodeu.Name = "TxtNumDoCodeu";
            this.TxtNumDoCodeu.Size = new System.Drawing.Size(89, 20);
            this.TxtNumDoCodeu.TabIndex = 233;
            this.TxtNumDoCodeu.Visible = false;
            // 
            // TxtNumDoRespon
            // 
            this.TxtNumDoRespon.Location = new System.Drawing.Point(134, 121);
            this.TxtNumDoRespon.Name = "TxtNumDoRespon";
            this.TxtNumDoRespon.Size = new System.Drawing.Size(89, 20);
            this.TxtNumDoRespon.TabIndex = 235;
            this.TxtNumDoRespon.Visible = false;
            // 
            // TxtTipoDoRespon
            // 
            this.TxtTipoDoRespon.Location = new System.Drawing.Point(96, 121);
            this.TxtTipoDoRespon.Name = "TxtTipoDoRespon";
            this.TxtTipoDoRespon.Size = new System.Drawing.Size(37, 20);
            this.TxtTipoDoRespon.TabIndex = 234;
            this.TxtTipoDoRespon.Visible = false;
            // 
            // radioButton1
            // 
            this.radioButton1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(3, 126);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(143, 17);
            this.radioButton1.TabIndex = 10;
            this.radioButton1.Text = "Por &Responsables";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.Location = new System.Drawing.Point(3, 76);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(143, 24);
            this.radioButton2.TabIndex = 9;
            this.radioButton2.Text = "Por &Facturas";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton7
            // 
            this.radioButton7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton7.Location = new System.Drawing.Point(3, 99);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(143, 24);
            this.radioButton7.TabIndex = 11;
            this.radioButton7.Text = "Por Code&udores";
            this.radioButton7.UseVisualStyleBackColor = true;
            this.radioButton7.CheckedChanged += new System.EventHandler(this.radioButton7_CheckedChanged);
            // 
            // FrmReportesPagares
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 411);
            this.ControlBox = false;
            this.Controls.Add(this.label9);
            this.Controls.Add(this.BtnMostrar);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmReportesPagares";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "REPORTES RELACIONADOS CON LOS PAGARES REGISTRADOS";
            this.Load += new System.EventHandler(this.FrmReportesPagares_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonAnuladas;
        private System.Windows.Forms.RadioButton radioButtonValidas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker DtFecFinal;
        private System.Windows.Forms.DateTimePicker DtFecInicial;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CboDigiNom;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtFacNumPa;
        private System.Windows.Forms.TextBox TxtHistoriaPaci;
        private System.Windows.Forms.TextBox TxtTipoDoCodeu;
        private System.Windows.Forms.Label LblHistoriaNo;
        private System.Windows.Forms.Label LblDocumentoNo;
        private System.Windows.Forms.Label LblNoPagare;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button BtnMostrar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label LblCodEntiFac;
        private System.Windows.Forms.Label lblNivelPermitido;
        private System.Windows.Forms.Label lblNombreUser;
        private System.Windows.Forms.Label lblCodigoUser;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox TxtNumDoCodeu;
        private System.Windows.Forms.TextBox TxtNumDoRespon;
        private System.Windows.Forms.TextBox TxtTipoDoRespon;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton7;
    }
}