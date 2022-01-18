
namespace OBCAJASQL.Forms.Caja
{
    partial class FrmBuscarTerceros
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBuscarTerceros));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RbCualquier = new System.Windows.Forms.RadioButton();
            this.RbPrimeName = new System.Windows.Forms.RadioButton();
            this.RbName = new System.Windows.Forms.RadioButton();
            this.RbDocu = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TxtCualquierBuscar = new System.Windows.Forms.TextBox();
            this.TxtPrimerasBuscar = new System.Windows.Forms.TextBox();
            this.TxtCompletoBuscar = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtSucuTer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtNitCCBuscar = new System.Windows.Forms.TextBox();
            this.CboTpDoc = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DgListaTercerosEncontrados = new System.Windows.Forms.DataGridView();
            this.TDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocumentoNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreTercero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label39 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.BtnEligeTercero = new System.Windows.Forms.Button();
            this.BtnMostrarTer = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgListaTercerosEncontrados)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.RbCualquier);
            this.groupBox1.Controls.Add(this.RbPrimeName);
            this.groupBox1.Controls.Add(this.RbName);
            this.groupBox1.Controls.Add(this.RbDocu);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(181, 147);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // RbCualquier
            // 
            this.RbCualquier.AutoSize = true;
            this.RbCualquier.Location = new System.Drawing.Point(6, 107);
            this.RbCualquier.Name = "RbCualquier";
            this.RbCualquier.Size = new System.Drawing.Size(151, 17);
            this.RbCualquier.TabIndex = 4;
            this.RbCualquier.TabStop = true;
            this.RbCualquier.Text = "Cualquier parte del nombre";
            this.RbCualquier.UseVisualStyleBackColor = true;
            this.RbCualquier.CheckedChanged += new System.EventHandler(this.RbCualquier_CheckedChanged);
            // 
            // RbPrimeName
            // 
            this.RbPrimeName.AutoSize = true;
            this.RbPrimeName.Location = new System.Drawing.Point(6, 84);
            this.RbPrimeName.Name = "RbPrimeName";
            this.RbPrimeName.Size = new System.Drawing.Size(120, 17);
            this.RbPrimeName.TabIndex = 3;
            this.RbPrimeName.TabStop = true;
            this.RbPrimeName.Text = "Primeras del nombre";
            this.RbPrimeName.UseVisualStyleBackColor = true;
            this.RbPrimeName.CheckedChanged += new System.EventHandler(this.RbPrimeName_CheckedChanged);
            // 
            // RbName
            // 
            this.RbName.AutoSize = true;
            this.RbName.Location = new System.Drawing.Point(6, 61);
            this.RbName.Name = "RbName";
            this.RbName.Size = new System.Drawing.Size(108, 17);
            this.RbName.TabIndex = 2;
            this.RbName.TabStop = true;
            this.RbName.Text = "Nombre completo";
            this.RbName.UseVisualStyleBackColor = true;
            this.RbName.CheckedChanged += new System.EventHandler(this.RbName_CheckedChanged);
            // 
            // RbDocu
            // 
            this.RbDocu.AutoSize = true;
            this.RbDocu.Location = new System.Drawing.Point(6, 38);
            this.RbDocu.Name = "RbDocu";
            this.RbDocu.Size = new System.Drawing.Size(150, 17);
            this.RbDocu.TabIndex = 1;
            this.RbDocu.TabStop = true;
            this.RbDocu.Text = "Por documento identifición";
            this.RbDocu.UseVisualStyleBackColor = true;
            this.RbDocu.CheckedChanged += new System.EventHandler(this.RbDocu_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Parámetros de busqueda";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.TxtCualquierBuscar);
            this.groupBox2.Controls.Add(this.TxtPrimerasBuscar);
            this.groupBox2.Controls.Add(this.TxtCompletoBuscar);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.TxtSucuTer);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.TxtNitCCBuscar);
            this.groupBox2.Controls.Add(this.CboTpDoc);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(199, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(403, 147);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // TxtCualquierBuscar
            // 
            this.TxtCualquierBuscar.Location = new System.Drawing.Point(92, 99);
            this.TxtCualquierBuscar.Name = "TxtCualquierBuscar";
            this.TxtCualquierBuscar.Size = new System.Drawing.Size(305, 20);
            this.TxtCualquierBuscar.TabIndex = 218;
            this.TxtCualquierBuscar.Visible = false;
            // 
            // TxtPrimerasBuscar
            // 
            this.TxtPrimerasBuscar.Location = new System.Drawing.Point(93, 76);
            this.TxtPrimerasBuscar.Name = "TxtPrimerasBuscar";
            this.TxtPrimerasBuscar.Size = new System.Drawing.Size(305, 20);
            this.TxtPrimerasBuscar.TabIndex = 217;
            this.TxtPrimerasBuscar.Visible = false;
            // 
            // TxtCompletoBuscar
            // 
            this.TxtCompletoBuscar.Location = new System.Drawing.Point(93, 53);
            this.TxtCompletoBuscar.Name = "TxtCompletoBuscar";
            this.TxtCompletoBuscar.Size = new System.Drawing.Size(305, 20);
            this.TxtCompletoBuscar.TabIndex = 216;
            this.TxtCompletoBuscar.Visible = false;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(0, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 23);
            this.label6.TabIndex = 215;
            this.label6.Text = "Cualquier:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(0, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 23);
            this.label5.TabIndex = 214;
            this.label5.Text = "Primeras:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 23);
            this.label4.TabIndex = 213;
            this.label4.Text = "Nombre:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtSucuTer
            // 
            this.TxtSucuTer.Location = new System.Drawing.Point(343, 31);
            this.TxtSucuTer.Name = "TxtSucuTer";
            this.TxtSucuTer.Size = new System.Drawing.Size(54, 20);
            this.TxtSucuTer.TabIndex = 212;
            this.TxtSucuTer.Text = "000";
            this.TxtSucuTer.Visible = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(280, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 23);
            this.label2.TabIndex = 211;
            this.label2.Text = "Sucursal:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtNitCCBuscar
            // 
            this.TxtNitCCBuscar.Location = new System.Drawing.Point(144, 33);
            this.TxtNitCCBuscar.Name = "TxtNitCCBuscar";
            this.TxtNitCCBuscar.Size = new System.Drawing.Size(135, 20);
            this.TxtNitCCBuscar.TabIndex = 210;
            this.TxtNitCCBuscar.Visible = false;
            // 
            // CboTpDoc
            // 
            this.CboTpDoc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CboTpDoc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CboTpDoc.DropDownWidth = 200;
            this.CboTpDoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboTpDoc.FormattingEnabled = true;
            this.CboTpDoc.Items.AddRange(new object[] {
            "Valor Neto",
            "Valor Copago"});
            this.CboTpDoc.Location = new System.Drawing.Point(93, 32);
            this.CboTpDoc.Name = "CboTpDoc";
            this.CboTpDoc.Size = new System.Drawing.Size(50, 21);
            this.CboTpDoc.TabIndex = 209;
            this.CboTpDoc.Visible = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 23);
            this.label3.TabIndex = 21;
            this.label3.Text = "Documento:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DgListaTercerosEncontrados
            // 
            this.DgListaTercerosEncontrados.AllowUserToAddRows = false;
            this.DgListaTercerosEncontrados.AllowUserToDeleteRows = false;
            this.DgListaTercerosEncontrados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgListaTercerosEncontrados.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgListaTercerosEncontrados.BackgroundColor = System.Drawing.Color.White;
            this.DgListaTercerosEncontrados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgListaTercerosEncontrados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TDoc,
            this.DocumentoNo,
            this.NombreTercero,
            this.Sucursal});
            this.DgListaTercerosEncontrados.Location = new System.Drawing.Point(12, 165);
            this.DgListaTercerosEncontrados.MultiSelect = false;
            this.DgListaTercerosEncontrados.Name = "DgListaTercerosEncontrados";
            this.DgListaTercerosEncontrados.ReadOnly = true;
            this.DgListaTercerosEncontrados.RowHeadersVisible = false;
            this.DgListaTercerosEncontrados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgListaTercerosEncontrados.Size = new System.Drawing.Size(585, 150);
            this.DgListaTercerosEncontrados.TabIndex = 2;
            // 
            // TDoc
            // 
            this.TDoc.DataPropertyName = "TipoDocu";
            this.TDoc.FillWeight = 57.7622F;
            this.TDoc.HeaderText = "T. Doc.";
            this.TDoc.Name = "TDoc";
            this.TDoc.ReadOnly = true;
            // 
            // DocumentoNo
            // 
            this.DocumentoNo.DataPropertyName = "IdenProve";
            this.DocumentoNo.FillWeight = 81.21829F;
            this.DocumentoNo.HeaderText = "Documento No.";
            this.DocumentoNo.Name = "DocumentoNo";
            this.DocumentoNo.ReadOnly = true;
            // 
            // NombreTercero
            // 
            this.NombreTercero.DataPropertyName = "RazonSol";
            this.NombreTercero.FillWeight = 189.9712F;
            this.NombreTercero.HeaderText = "Nombre del tercero";
            this.NombreTercero.Name = "NombreTercero";
            this.NombreTercero.ReadOnly = true;
            // 
            // Sucursal
            // 
            this.Sucursal.DataPropertyName = "SucurProv";
            this.Sucursal.FillWeight = 71.04839F;
            this.Sucursal.HeaderText = "Sucursal";
            this.Sucursal.Name = "Sucursal";
            this.Sucursal.ReadOnly = true;
            // 
            // label39
            // 
            this.label39.BackColor = System.Drawing.Color.White;
            this.label39.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.ForeColor = System.Drawing.Color.Black;
            this.label39.Location = new System.Drawing.Point(175, 320);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(67, 23);
            this.label39.TabIndex = 201;
            this.label39.Text = "Mostrar";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(245, 320);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 23);
            this.label7.TabIndex = 203;
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
            this.BtnEligeTercero.Location = new System.Drawing.Point(248, 342);
            this.BtnEligeTercero.Name = "BtnEligeTercero";
            this.BtnEligeTercero.Size = new System.Drawing.Size(64, 44);
            this.BtnEligeTercero.TabIndex = 202;
            this.BtnEligeTercero.UseVisualStyleBackColor = false;
            this.BtnEligeTercero.Click += new System.EventHandler(this.BtnEligeTercero_Click);
            // 
            // BtnMostrarTer
            // 
            this.BtnMostrarTer.BackColor = System.Drawing.Color.White;
            this.BtnMostrarTer.BackgroundImage = global::OBCAJASQL.Properties.Resources.mostrar;
            this.BtnMostrarTer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnMostrarTer.FlatAppearance.BorderSize = 0;
            this.BtnMostrarTer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.BtnMostrarTer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMostrarTer.Location = new System.Drawing.Point(178, 342);
            this.BtnMostrarTer.Name = "BtnMostrarTer";
            this.BtnMostrarTer.Size = new System.Drawing.Size(64, 44);
            this.BtnMostrarTer.TabIndex = 200;
            this.BtnMostrarTer.UseVisualStyleBackColor = false;
            this.BtnMostrarTer.Click += new System.EventHandler(this.BtnMostrarTer_Click);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(318, 320);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 23);
            this.label9.TabIndex = 207;
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
            this.BtnSalir.Location = new System.Drawing.Point(318, 342);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(64, 44);
            this.BtnSalir.TabIndex = 206;
            this.BtnSalir.UseVisualStyleBackColor = false;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // FrmBuscarTerceros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 398);
            this.ControlBox = false;
            this.Controls.Add(this.label9);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.BtnEligeTercero);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.BtnMostrarTer);
            this.Controls.Add(this.DgListaTercerosEncontrados);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmBuscarTerceros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BUSCAR TERCEROS";
            this.Load += new System.EventHandler(this.FrmBuscarTerceros_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgListaTercerosEncontrados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton RbCualquier;
        private System.Windows.Forms.RadioButton RbPrimeName;
        private System.Windows.Forms.RadioButton RbName;
        private System.Windows.Forms.RadioButton RbDocu;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CboTpDoc;
        private System.Windows.Forms.TextBox TxtSucuTer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtNitCCBuscar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtCualquierBuscar;
        private System.Windows.Forms.TextBox TxtPrimerasBuscar;
        private System.Windows.Forms.TextBox TxtCompletoBuscar;
        private System.Windows.Forms.DataGridView DgListaTercerosEncontrados;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Button BtnMostrarTer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button BtnEligeTercero;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn TDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocumentoNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreTercero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sucursal;
    }
}