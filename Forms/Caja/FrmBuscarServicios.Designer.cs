
namespace OBCAJASQL.Forms.Caja
{
    partial class FrmBuscarServicios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBuscarServicios));
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CboAmbitoBuscar = new System.Windows.Forms.ComboBox();
            this.TxtParaBuscar = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.BtnEligeTercero = new System.Windows.Forms.Button();
            this.label39 = new System.Windows.Forms.Label();
            this.BtnBuscarADmin = new System.Windows.Forms.Button();
            this.DgLisServicios = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CodInterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodiMedMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CenCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorCUPS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorParti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorSoat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorIss = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorEspecial01 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorEspecial02 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorEspecial03 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorEspecial04 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HabilPro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActuaValUni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrupoServi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgLisServicios)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(350, 21);
            this.label4.TabIndex = 215;
            this.label4.Text = "Buscar por:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.TxtParaBuscar);
            this.groupBox1.Controls.Add(this.CboAmbitoBuscar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(362, 122);
            this.groupBox1.TabIndex = 216;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 21);
            this.label1.TabIndex = 216;
            this.label1.Text = "Letras iniciales:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CboAmbitoBuscar
            // 
            this.CboAmbitoBuscar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CboAmbitoBuscar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CboAmbitoBuscar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboAmbitoBuscar.DropDownWidth = 200;
            this.CboAmbitoBuscar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboAmbitoBuscar.FormattingEnabled = true;
            this.CboAmbitoBuscar.Items.AddRange(new object[] {
            "Iniciales del nombre",
            "Nombre completo",
            "Código IPS",
            "Cualquier parte del nombre"});
            this.CboAmbitoBuscar.Location = new System.Drawing.Point(9, 40);
            this.CboAmbitoBuscar.Name = "CboAmbitoBuscar";
            this.CboAmbitoBuscar.Size = new System.Drawing.Size(347, 21);
            this.CboAmbitoBuscar.TabIndex = 220;
            // 
            // TxtParaBuscar
            // 
            this.TxtParaBuscar.Location = new System.Drawing.Point(9, 88);
            this.TxtParaBuscar.Name = "TxtParaBuscar";
            this.TxtParaBuscar.Size = new System.Drawing.Size(347, 20);
            this.TxtParaBuscar.TabIndex = 221;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(218, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 23);
            this.label9.TabIndex = 222;
            this.label9.Text = "Salir";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnSalir
            // 
            this.BtnSalir.BackColor = System.Drawing.Color.White;
            this.BtnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnSalir.BackgroundImage")));
            this.BtnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnSalir.FlatAppearance.BorderSize = 0;
            this.BtnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.BtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSalir.Location = new System.Drawing.Point(218, 36);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(64, 44);
            this.BtnSalir.TabIndex = 221;
            this.BtnSalir.UseVisualStyleBackColor = false;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(145, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 23);
            this.label7.TabIndex = 220;
            this.label7.Text = "Elegir";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnEligeTercero
            // 
            this.BtnEligeTercero.BackColor = System.Drawing.Color.White;
            this.BtnEligeTercero.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnEligeTercero.BackgroundImage")));
            this.BtnEligeTercero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnEligeTercero.FlatAppearance.BorderSize = 0;
            this.BtnEligeTercero.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.BtnEligeTercero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEligeTercero.Location = new System.Drawing.Point(148, 36);
            this.BtnEligeTercero.Name = "BtnEligeTercero";
            this.BtnEligeTercero.Size = new System.Drawing.Size(64, 44);
            this.BtnEligeTercero.TabIndex = 219;
            this.BtnEligeTercero.UseVisualStyleBackColor = false;
            this.BtnEligeTercero.Click += new System.EventHandler(this.BtnEligeTercero_Click);
            // 
            // label39
            // 
            this.label39.BackColor = System.Drawing.Color.White;
            this.label39.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.ForeColor = System.Drawing.Color.Black;
            this.label39.Location = new System.Drawing.Point(75, 14);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(67, 23);
            this.label39.TabIndex = 218;
            this.label39.Text = "Mostrar";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnBuscarADmin
            // 
            this.BtnBuscarADmin.BackColor = System.Drawing.Color.White;
            this.BtnBuscarADmin.BackgroundImage = global::OBCAJASQL.Properties.Resources.mostrar;
            this.BtnBuscarADmin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnBuscarADmin.FlatAppearance.BorderSize = 0;
            this.BtnBuscarADmin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.BtnBuscarADmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBuscarADmin.Location = new System.Drawing.Point(78, 36);
            this.BtnBuscarADmin.Name = "BtnBuscarADmin";
            this.BtnBuscarADmin.Size = new System.Drawing.Size(64, 44);
            this.BtnBuscarADmin.TabIndex = 217;
            this.BtnBuscarADmin.UseVisualStyleBackColor = false;
            this.BtnBuscarADmin.Click += new System.EventHandler(this.BtnBuscarADmin_Click);
            // 
            // DgLisServicios
            // 
            this.DgLisServicios.AllowUserToAddRows = false;
            this.DgLisServicios.AllowUserToDeleteRows = false;
            this.DgLisServicios.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgLisServicios.BackgroundColor = System.Drawing.Color.White;
            this.DgLisServicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgLisServicios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodInterno,
            this.NomServicio,
            this.CodiMedMin,
            this.CenCosto,
            this.ValorCUPS,
            this.ValorParti,
            this.ValorSoat,
            this.ValorIss,
            this.ValorEspecial01,
            this.ValorEspecial02,
            this.ValorEspecial03,
            this.ValorEspecial04,
            this.HabilPro,
            this.ActuaValUni,
            this.GrupoServi});
            this.DgLisServicios.Location = new System.Drawing.Point(12, 140);
            this.DgLisServicios.MultiSelect = false;
            this.DgLisServicios.Name = "DgLisServicios";
            this.DgLisServicios.ReadOnly = true;
            this.DgLisServicios.RowHeadersVisible = false;
            this.DgLisServicios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgLisServicios.Size = new System.Drawing.Size(362, 184);
            this.DgLisServicios.TabIndex = 223;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.BtnBuscarADmin);
            this.groupBox2.Controls.Add(this.BtnEligeTercero);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label39);
            this.groupBox2.Controls.Add(this.BtnSalir);
            this.groupBox2.Location = new System.Drawing.Point(12, 330);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(362, 92);
            this.groupBox2.TabIndex = 224;
            this.groupBox2.TabStop = false;
            // 
            // CodInterno
            // 
            this.CodInterno.DataPropertyName = "CodInterno";
            this.CodInterno.FillWeight = 380.7107F;
            this.CodInterno.HeaderText = "CodInterno";
            this.CodInterno.Name = "CodInterno";
            this.CodInterno.ReadOnly = true;
            this.CodInterno.Width = 91;
            // 
            // NomServicio
            // 
            this.NomServicio.DataPropertyName = "NomServicio";
            this.NomServicio.FillWeight = 79.94924F;
            this.NomServicio.HeaderText = "NomServicio";
            this.NomServicio.Name = "NomServicio";
            this.NomServicio.ReadOnly = true;
            this.NomServicio.Width = 150;
            // 
            // CodiMedMin
            // 
            this.CodiMedMin.DataPropertyName = "CodiMedMin";
            this.CodiMedMin.FillWeight = 79.94924F;
            this.CodiMedMin.HeaderText = "CodiMedMin";
            this.CodiMedMin.Name = "CodiMedMin";
            this.CodiMedMin.ReadOnly = true;
            this.CodiMedMin.Width = 70;
            // 
            // CenCosto
            // 
            this.CenCosto.DataPropertyName = "CenCosto";
            this.CenCosto.FillWeight = 79.94924F;
            this.CenCosto.HeaderText = "CenCosto";
            this.CenCosto.Name = "CenCosto";
            this.CenCosto.ReadOnly = true;
            this.CenCosto.Width = 50;
            // 
            // ValorCUPS
            // 
            this.ValorCUPS.DataPropertyName = "ValorCUPS";
            this.ValorCUPS.FillWeight = 79.94924F;
            this.ValorCUPS.HeaderText = "ValorCUPS";
            this.ValorCUPS.Name = "ValorCUPS";
            this.ValorCUPS.ReadOnly = true;
            this.ValorCUPS.Width = 60;
            // 
            // ValorParti
            // 
            this.ValorParti.DataPropertyName = "ValorParti";
            this.ValorParti.FillWeight = 79.94924F;
            this.ValorParti.HeaderText = "ValorParti";
            this.ValorParti.Name = "ValorParti";
            this.ValorParti.ReadOnly = true;
            this.ValorParti.Width = 60;
            // 
            // ValorSoat
            // 
            this.ValorSoat.DataPropertyName = "ValorSoat";
            this.ValorSoat.FillWeight = 79.94924F;
            this.ValorSoat.HeaderText = "ValorSoat";
            this.ValorSoat.Name = "ValorSoat";
            this.ValorSoat.ReadOnly = true;
            this.ValorSoat.Width = 60;
            // 
            // ValorIss
            // 
            this.ValorIss.DataPropertyName = "ValorIss";
            this.ValorIss.FillWeight = 79.94924F;
            this.ValorIss.HeaderText = "ValorIss";
            this.ValorIss.Name = "ValorIss";
            this.ValorIss.ReadOnly = true;
            this.ValorIss.Width = 60;
            // 
            // ValorEspecial01
            // 
            this.ValorEspecial01.DataPropertyName = "ValorEspecial01";
            this.ValorEspecial01.FillWeight = 79.94924F;
            this.ValorEspecial01.HeaderText = "ValorEspecial01";
            this.ValorEspecial01.Name = "ValorEspecial01";
            this.ValorEspecial01.ReadOnly = true;
            this.ValorEspecial01.Width = 50;
            // 
            // ValorEspecial02
            // 
            this.ValorEspecial02.DataPropertyName = "ValorEspecial02";
            this.ValorEspecial02.FillWeight = 79.94924F;
            this.ValorEspecial02.HeaderText = "ValorEspecial02";
            this.ValorEspecial02.Name = "ValorEspecial02";
            this.ValorEspecial02.ReadOnly = true;
            this.ValorEspecial02.Width = 50;
            // 
            // ValorEspecial03
            // 
            this.ValorEspecial03.DataPropertyName = "ValorEspecial03";
            this.ValorEspecial03.FillWeight = 79.94924F;
            this.ValorEspecial03.HeaderText = "ValorEspecial03";
            this.ValorEspecial03.Name = "ValorEspecial03";
            this.ValorEspecial03.ReadOnly = true;
            this.ValorEspecial03.Width = 50;
            // 
            // ValorEspecial04
            // 
            this.ValorEspecial04.DataPropertyName = "ValorEspecial04";
            this.ValorEspecial04.FillWeight = 79.94924F;
            this.ValorEspecial04.HeaderText = "ValorEspecial04";
            this.ValorEspecial04.Name = "ValorEspecial04";
            this.ValorEspecial04.ReadOnly = true;
            this.ValorEspecial04.Width = 50;
            // 
            // HabilPro
            // 
            this.HabilPro.DataPropertyName = "HabilPro";
            this.HabilPro.FillWeight = 79.94924F;
            this.HabilPro.HeaderText = "HabilPro";
            this.HabilPro.Name = "HabilPro";
            this.HabilPro.ReadOnly = true;
            this.HabilPro.Width = 19;
            // 
            // ActuaValUni
            // 
            this.ActuaValUni.DataPropertyName = "ActuaValUni";
            this.ActuaValUni.FillWeight = 79.94924F;
            this.ActuaValUni.HeaderText = "ActuaValUni";
            this.ActuaValUni.Name = "ActuaValUni";
            this.ActuaValUni.ReadOnly = true;
            this.ActuaValUni.Width = 19;
            // 
            // GrupoServi
            // 
            this.GrupoServi.DataPropertyName = "GrupoServi";
            this.GrupoServi.FillWeight = 79.94924F;
            this.GrupoServi.HeaderText = "GrupoServi";
            this.GrupoServi.Name = "GrupoServi";
            this.GrupoServi.ReadOnly = true;
            this.GrupoServi.Width = 19;
            // 
            // FrmBuscarServicios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 434);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.DgLisServicios);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmBuscarServicios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BUSCAR PROCEDIMIENTOS Y/O SERVICIOS";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgLisServicios)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CboAmbitoBuscar;
        private System.Windows.Forms.TextBox TxtParaBuscar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button BtnEligeTercero;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Button BtnBuscarADmin;
        private System.Windows.Forms.DataGridView DgLisServicios;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodInterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodiMedMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn CenCosto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorCUPS;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorParti;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorSoat;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorIss;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorEspecial01;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorEspecial02;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorEspecial03;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorEspecial04;
        private System.Windows.Forms.DataGridViewTextBoxColumn HabilPro;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActuaValUni;
        private System.Windows.Forms.DataGridViewTextBoxColumn GrupoServi;
    }
}