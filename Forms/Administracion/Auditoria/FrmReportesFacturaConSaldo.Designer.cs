
namespace OBCAJASQL.Forms.Administracion.Auditoria
{
    partial class FrmReportesFacturaConSaldo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReportesFacturaConSaldo));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonAnuladas = new System.Windows.Forms.RadioButton();
            this.radioButtonValidas = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DateFinal = new System.Windows.Forms.DateTimePicker();
            this.DateInicial = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButtonTodas = new System.Windows.Forms.RadioButton();
            this.radioButtonEntidad = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cboNomEnti = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.LblCodEntiFac = new System.Windows.Forms.Label();
            this.lblNivelPermitido = new System.Windows.Forms.Label();
            this.lblNombreUser = new System.Windows.Forms.Label();
            this.lblCodigoUser = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.BtnMostrar = new System.Windows.Forms.Button();
            this.BtnExportar = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.radioButtonAnuladas);
            this.groupBox1.Controls.Add(this.radioButtonValidas);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(3, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(155, 92);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // radioButtonAnuladas
            // 
            this.radioButtonAnuladas.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonAnuladas.Location = new System.Drawing.Point(9, 64);
            this.radioButtonAnuladas.Name = "radioButtonAnuladas";
            this.radioButtonAnuladas.Size = new System.Drawing.Size(143, 17);
            this.radioButtonAnuladas.TabIndex = 4;
            this.radioButtonAnuladas.Text = "Anuladas";
            this.radioButtonAnuladas.UseVisualStyleBackColor = true;
            this.radioButtonAnuladas.CheckedChanged += new System.EventHandler(this.radioButtonAnuladas_CheckedChanged);
            // 
            // radioButtonValidas
            // 
            this.radioButtonValidas.Checked = true;
            this.radioButtonValidas.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonValidas.Location = new System.Drawing.Point(9, 34);
            this.radioButtonValidas.Name = "radioButtonValidas";
            this.radioButtonValidas.Size = new System.Drawing.Size(143, 24);
            this.radioButtonValidas.TabIndex = 3;
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
            this.label2.Location = new System.Drawing.Point(-3, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Listar las";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.DateFinal);
            this.groupBox2.Controls.Add(this.DateInicial);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(164, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(452, 92);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // DateFinal
            // 
            this.DateFinal.CustomFormat = "dd-MMM-yyyy";
            this.DateFinal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateFinal.Location = new System.Drawing.Point(334, 46);
            this.DateFinal.Name = "DateFinal";
            this.DateFinal.Size = new System.Drawing.Size(115, 22);
            this.DateFinal.TabIndex = 13;
            this.DateFinal.Value = new System.DateTime(2020, 9, 30, 8, 32, 0, 0);
            // 
            // DateInicial
            // 
            this.DateInicial.CustomFormat = "dd-MMM-yyyy";
            this.DateInicial.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateInicial.Location = new System.Drawing.Point(110, 46);
            this.DateInicial.Name = "DateInicial";
            this.DateInicial.Size = new System.Drawing.Size(115, 22);
            this.DateInicial.TabIndex = 12;
            this.DateInicial.Value = new System.DateTime(2020, 9, 1, 8, 32, 0, 0);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(227, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 22);
            this.label7.TabIndex = 11;
            this.label7.Text = "Fecha Final:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(6, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 22);
            this.label6.TabIndex = 10;
            this.label6.Text = "Fecha Inicial:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(-3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(455, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Periodo a listar";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.radioButtonTodas);
            this.groupBox3.Controls.Add(this.radioButtonEntidad);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(3, 99);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(155, 92);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            // 
            // radioButtonTodas
            // 
            this.radioButtonTodas.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonTodas.Location = new System.Drawing.Point(9, 64);
            this.radioButtonTodas.Name = "radioButtonTodas";
            this.radioButtonTodas.Size = new System.Drawing.Size(143, 17);
            this.radioButtonTodas.TabIndex = 4;
            this.radioButtonTodas.Text = "Por todas";
            this.radioButtonTodas.UseVisualStyleBackColor = true;
            this.radioButtonTodas.CheckedChanged += new System.EventHandler(this.radioButtonTodas_CheckedChanged);
            // 
            // radioButtonEntidad
            // 
            this.radioButtonEntidad.Checked = true;
            this.radioButtonEntidad.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonEntidad.Location = new System.Drawing.Point(9, 34);
            this.radioButtonEntidad.Name = "radioButtonEntidad";
            this.radioButtonEntidad.Size = new System.Drawing.Size(143, 24);
            this.radioButtonEntidad.TabIndex = 3;
            this.radioButtonEntidad.TabStop = true;
            this.radioButtonEntidad.Text = "Por entidad";
            this.radioButtonEntidad.UseVisualStyleBackColor = true;
            this.radioButtonEntidad.CheckedChanged += new System.EventHandler(this.radioButtonEntidad_CheckedChanged);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(-3, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Lista los recibos por";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.White;
            this.groupBox4.Controls.Add(this.cboNomEnti);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Location = new System.Drawing.Point(164, 99);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(452, 92);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            // 
            // cboNomEnti
            // 
            this.cboNomEnti.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboNomEnti.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboNomEnti.DropDownWidth = 460;
            this.cboNomEnti.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNomEnti.FormattingEnabled = true;
            this.cboNomEnti.Location = new System.Drawing.Point(6, 47);
            this.cboNomEnti.Name = "cboNomEnti";
            this.cboNomEnti.Size = new System.Drawing.Size(440, 22);
            this.cboNomEnti.TabIndex = 7;
            this.cboNomEnti.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboNomEnti_KeyPress);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(-3, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(452, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "Lista los recibos por";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.LblCodEntiFac);
            this.groupBox6.Controls.Add(this.lblNivelPermitido);
            this.groupBox6.Controls.Add(this.lblNombreUser);
            this.groupBox6.Controls.Add(this.lblCodigoUser);
            this.groupBox6.Controls.Add(this.label16);
            this.groupBox6.Location = new System.Drawing.Point(3, 197);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(155, 66);
            this.groupBox6.TabIndex = 89;
            this.groupBox6.TabStop = false;
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
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(445, 197);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 23);
            this.label10.TabIndex = 123;
            this.label10.Text = "Salir";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(376, 197);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 23);
            this.label8.TabIndex = 127;
            this.label8.Text = "Exportar";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(312, 197);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 23);
            this.label9.TabIndex = 129;
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
            this.BtnMostrar.Location = new System.Drawing.Point(312, 219);
            this.BtnMostrar.Name = "BtnMostrar";
            this.BtnMostrar.Size = new System.Drawing.Size(58, 44);
            this.BtnMostrar.TabIndex = 128;
            this.BtnMostrar.UseVisualStyleBackColor = false;
            this.BtnMostrar.Click += new System.EventHandler(this.BtnMostrar_Click);
            // 
            // BtnExportar
            // 
            this.BtnExportar.BackColor = System.Drawing.Color.White;
            this.BtnExportar.BackgroundImage = global::OBCAJASQL.Properties.Resources.exportar;
            this.BtnExportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnExportar.FlatAppearance.BorderSize = 0;
            this.BtnExportar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.BtnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExportar.Location = new System.Drawing.Point(376, 219);
            this.BtnExportar.Name = "BtnExportar";
            this.BtnExportar.Size = new System.Drawing.Size(63, 44);
            this.BtnExportar.TabIndex = 126;
            this.BtnExportar.UseVisualStyleBackColor = false;
            // 
            // BtnSalir
            // 
            this.BtnSalir.BackColor = System.Drawing.Color.White;
            this.BtnSalir.BackgroundImage = global::OBCAJASQL.Properties.Resources.cerrar40px;
            this.BtnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnSalir.FlatAppearance.BorderSize = 0;
            this.BtnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.BtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSalir.Location = new System.Drawing.Point(445, 219);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(50, 44);
            this.BtnSalir.TabIndex = 122;
            this.BtnSalir.UseVisualStyleBackColor = false;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // FrmReportesFacturaConSaldo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 268);
            this.ControlBox = false;
            this.Controls.Add(this.label9);
            this.Controls.Add(this.BtnMostrar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.BtnExportar);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmReportesFacturaConSaldo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reportes Facturas Con Saldo";
            this.Load += new System.EventHandler(this.FrmReportesFacturaConSaldo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonAnuladas;
        private System.Windows.Forms.RadioButton radioButtonValidas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DateFinal;
        private System.Windows.Forms.DateTimePicker DateInicial;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButtonTodas;
        private System.Windows.Forms.RadioButton radioButtonEntidad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cboNomEnti;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label LblCodEntiFac;
        private System.Windows.Forms.Label lblNivelPermitido;
        private System.Windows.Forms.Label lblNombreUser;
        private System.Windows.Forms.Label lblCodigoUser;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button BtnExportar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button BtnMostrar;
    }
}