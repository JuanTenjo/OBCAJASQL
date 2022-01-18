
namespace OBCAJASQL.Forms.Caja
{
    partial class FrmCruceDepositos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCruceDepositos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtHistocruce = new System.Windows.Forms.TextBox();
            this.TxtFacturDepo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DgCajaCruceDepositos = new System.Windows.Forms.DataGridView();
            this.TxtLblValCruzar = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.label39 = new System.Windows.Forms.Label();
            this.BtnRegistraCaja = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LblCodEntiFac = new System.Windows.Forms.Label();
            this.lblNivelPermitido = new System.Windows.Forms.Label();
            this.lblNombreUser = new System.Windows.Forms.Label();
            this.lblCodigoUser = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.ReciboNro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaDepos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VrDeposito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VrAfectado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Saldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgCajaCruceDepositos)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(507, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "DEPOSITOS REGISTRADOS AL USUARIO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.TxtFacturDepo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TxtHistocruce);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(4, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(507, 45);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(50, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "Historia Clinica:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtHistocruce
            // 
            this.TxtHistocruce.Location = new System.Drawing.Point(154, 13);
            this.TxtHistocruce.Name = "TxtHistocruce";
            this.TxtHistocruce.Size = new System.Drawing.Size(111, 20);
            this.TxtHistocruce.TabIndex = 29;
            // 
            // TxtFacturDepo
            // 
            this.TxtFacturDepo.Location = new System.Drawing.Point(351, 13);
            this.TxtFacturDepo.Name = "TxtFacturDepo";
            this.TxtFacturDepo.Size = new System.Drawing.Size(102, 20);
            this.TxtFacturDepo.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(264, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 30;
            this.label2.Text = "Nro Factura:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DgCajaCruceDepositos
            // 
            this.DgCajaCruceDepositos.AllowUserToAddRows = false;
            this.DgCajaCruceDepositos.AllowUserToDeleteRows = false;
            this.DgCajaCruceDepositos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgCajaCruceDepositos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgCajaCruceDepositos.BackgroundColor = System.Drawing.Color.White;
            this.DgCajaCruceDepositos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgCajaCruceDepositos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ReciboNro,
            this.FechaDepos,
            this.VrDeposito,
            this.VrAfectado,
            this.Saldo});
            this.DgCajaCruceDepositos.Location = new System.Drawing.Point(7, 87);
            this.DgCajaCruceDepositos.MultiSelect = false;
            this.DgCajaCruceDepositos.Name = "DgCajaCruceDepositos";
            this.DgCajaCruceDepositos.ReadOnly = true;
            this.DgCajaCruceDepositos.RowHeadersVisible = false;
            this.DgCajaCruceDepositos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgCajaCruceDepositos.Size = new System.Drawing.Size(504, 113);
            this.DgCajaCruceDepositos.TabIndex = 3;
            // 
            // TxtLblValCruzar
            // 
            this.TxtLblValCruzar.Location = new System.Drawing.Point(409, 203);
            this.TxtLblValCruzar.Name = "TxtLblValCruzar";
            this.TxtLblValCruzar.ReadOnly = true;
            this.TxtLblValCruzar.Size = new System.Drawing.Size(102, 20);
            this.TxtLblValCruzar.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(309, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 20);
            this.label4.TabIndex = 32;
            this.label4.Text = "Valor a cruzar:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label41
            // 
            this.label41.BackColor = System.Drawing.Color.White;
            this.label41.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.ForeColor = System.Drawing.Color.Black;
            this.label41.Location = new System.Drawing.Point(164, 212);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(50, 23);
            this.label41.TabIndex = 207;
            this.label41.Text = "Salir";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnSalir
            // 
            this.BtnSalir.BackColor = System.Drawing.Color.White;
            this.BtnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnSalir.BackgroundImage")));
            this.BtnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnSalir.FlatAppearance.BorderSize = 0;
            this.BtnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.BtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSalir.Location = new System.Drawing.Point(164, 234);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(50, 44);
            this.BtnSalir.TabIndex = 206;
            this.BtnSalir.UseVisualStyleBackColor = false;
            // 
            // label39
            // 
            this.label39.BackColor = System.Drawing.Color.White;
            this.label39.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.ForeColor = System.Drawing.Color.Black;
            this.label39.Location = new System.Drawing.Point(91, 212);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(67, 23);
            this.label39.TabIndex = 205;
            this.label39.Text = "Registrar";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnRegistraCaja
            // 
            this.BtnRegistraCaja.BackColor = System.Drawing.Color.White;
            this.BtnRegistraCaja.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnRegistraCaja.BackgroundImage")));
            this.BtnRegistraCaja.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnRegistraCaja.FlatAppearance.BorderSize = 0;
            this.BtnRegistraCaja.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.BtnRegistraCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRegistraCaja.Location = new System.Drawing.Point(94, 234);
            this.BtnRegistraCaja.Name = "BtnRegistraCaja";
            this.BtnRegistraCaja.Size = new System.Drawing.Size(64, 44);
            this.BtnRegistraCaja.TabIndex = 204;
            this.BtnRegistraCaja.UseVisualStyleBackColor = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LblCodEntiFac);
            this.groupBox2.Controls.Add(this.lblNivelPermitido);
            this.groupBox2.Controls.Add(this.lblNombreUser);
            this.groupBox2.Controls.Add(this.lblCodigoUser);
            this.groupBox2.Controls.Add(this.label45);
            this.groupBox2.Location = new System.Drawing.Point(312, 226);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(199, 52);
            this.groupBox2.TabIndex = 208;
            this.groupBox2.TabStop = false;
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
            this.lblNombreUser.Size = new System.Drawing.Size(193, 25);
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
            // ReciboNro
            // 
            this.ReciboNro.DataPropertyName = "ReciCaja";
            this.ReciboNro.HeaderText = "Recibo Nro.";
            this.ReciboNro.Name = "ReciboNro";
            this.ReciboNro.ReadOnly = true;
            // 
            // FechaDepos
            // 
            this.FechaDepos.DataPropertyName = "FecDepo";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.FechaDepos.DefaultCellStyle = dataGridViewCellStyle1;
            this.FechaDepos.HeaderText = "Fecha Depos.";
            this.FechaDepos.Name = "FechaDepos";
            this.FechaDepos.ReadOnly = true;
            // 
            // VrDeposito
            // 
            this.VrDeposito.DataPropertyName = "ValDepo";
            this.VrDeposito.HeaderText = "Vr Deposito.";
            this.VrDeposito.Name = "VrDeposito";
            this.VrDeposito.ReadOnly = true;
            // 
            // VrAfectado
            // 
            this.VrAfectado.DataPropertyName = "ValAfec";
            this.VrAfectado.HeaderText = "Vr Afectado.";
            this.VrAfectado.Name = "VrAfectado";
            this.VrAfectado.ReadOnly = true;
            // 
            // Saldo
            // 
            this.Saldo.DataPropertyName = "Saldepo";
            this.Saldo.HeaderText = "Saldo.";
            this.Saldo.Name = "Saldo";
            this.Saldo.ReadOnly = true;
            // 
            // FrmCruceDepositos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 290);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.BtnRegistraCaja);
            this.Controls.Add(this.TxtLblValCruzar);
            this.Controls.Add(this.DgCajaCruceDepositos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCruceDepositos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cruce Depositos";
            this.Load += new System.EventHandler(this.FrmCruceDepositos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgCajaCruceDepositos)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtFacturDepo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtHistocruce;
        private System.Windows.Forms.DataGridView DgCajaCruceDepositos;
        private System.Windows.Forms.TextBox TxtLblValCruzar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Button BtnRegistraCaja;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label LblCodEntiFac;
        private System.Windows.Forms.Label lblNivelPermitido;
        private System.Windows.Forms.Label lblNombreUser;
        private System.Windows.Forms.Label lblCodigoUser;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReciboNro;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaDepos;
        private System.Windows.Forms.DataGridViewTextBoxColumn VrDeposito;
        private System.Windows.Forms.DataGridViewTextBoxColumn VrAfectado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Saldo;
    }
}