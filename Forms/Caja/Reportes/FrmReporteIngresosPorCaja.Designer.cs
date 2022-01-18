
namespace OBCAJASQL.Forms.Caja.Reportes
{
    partial class FrmReporteIngresosPorCaja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReporteIngresosPorCaja));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtFecFinal = new System.Windows.Forms.DateTimePicker();
            this.DtFecInicial = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RdAnulados = new System.Windows.Forms.RadioButton();
            this.RdValidados = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.RdTodos = new System.Windows.Forms.RadioButton();
            this.RdRegimenCosto = new System.Windows.Forms.RadioButton();
            this.RdPacientes = new System.Windows.Forms.RadioButton();
            this.RdRegimen = new System.Windows.Forms.RadioButton();
            this.RdEntidades = new System.Windows.Forms.RadioButton();
            this.RdUsuarios = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnMostrar = new System.Windows.Forms.Button();
            this.label39 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.DtFecFinal);
            this.groupBox1.Controls.Add(this.DtFecInicial);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(197, 83);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // DtFecFinal
            // 
            this.DtFecFinal.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.DtFecFinal.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.DtFecFinal.CustomFormat = "dd-MMM-yyyy";
            this.DtFecFinal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtFecFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtFecFinal.Location = new System.Drawing.Point(90, 51);
            this.DtFecFinal.Name = "DtFecFinal";
            this.DtFecFinal.Size = new System.Drawing.Size(101, 22);
            this.DtFecFinal.TabIndex = 22;
            // 
            // DtFecInicial
            // 
            this.DtFecInicial.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.DtFecInicial.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.DtFecInicial.CustomFormat = "dd-MMM-yyyy";
            this.DtFecInicial.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtFecInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtFecInicial.Location = new System.Drawing.Point(90, 29);
            this.DtFecInicial.Name = "DtFecInicial";
            this.DtFecInicial.Size = new System.Drawing.Size(101, 22);
            this.DtFecInicial.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 23);
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
            this.label1.Size = new System.Drawing.Size(87, 23);
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
            this.label3.Size = new System.Drawing.Size(197, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Periodo a mostrar";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.RdAnulados);
            this.groupBox2.Controls.Add(this.RdValidados);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(215, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(132, 83);
            this.groupBox2.TabIndex = 23;
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
            this.label6.Size = new System.Drawing.Size(130, 23);
            this.label6.TabIndex = 5;
            this.label6.Text = "Mostrar sólo los";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.RdTodos);
            this.groupBox3.Controls.Add(this.RdRegimenCosto);
            this.groupBox3.Controls.Add(this.RdPacientes);
            this.groupBox3.Controls.Add(this.RdRegimen);
            this.groupBox3.Controls.Add(this.RdEntidades);
            this.groupBox3.Controls.Add(this.RdUsuarios);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(12, 101);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(197, 175);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            // 
            // RdTodos
            // 
            this.RdTodos.AutoSize = true;
            this.RdTodos.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdTodos.Location = new System.Drawing.Point(6, 146);
            this.RdTodos.Name = "RdTodos";
            this.RdTodos.Size = new System.Drawing.Size(59, 18);
            this.RdTodos.TabIndex = 11;
            this.RdTodos.Text = "Todos";
            this.RdTodos.UseVisualStyleBackColor = true;
            this.RdTodos.CheckedChanged += new System.EventHandler(this.RdTodos_CheckedChanged);
            // 
            // RdRegimenCosto
            // 
            this.RdRegimenCosto.AutoSize = true;
            this.RdRegimenCosto.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdRegimenCosto.Location = new System.Drawing.Point(6, 124);
            this.RdRegimenCosto.Name = "RdRegimenCosto";
            this.RdRegimenCosto.Size = new System.Drawing.Size(154, 18);
            this.RdRegimenCosto.TabIndex = 10;
            this.RdRegimenCosto.Text = "Por regimen y c. costos";
            this.RdRegimenCosto.UseVisualStyleBackColor = true;
            this.RdRegimenCosto.CheckedChanged += new System.EventHandler(this.RdRegimenCosto_CheckedChanged);
            // 
            // RdPacientes
            // 
            this.RdPacientes.AutoSize = true;
            this.RdPacientes.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdPacientes.Location = new System.Drawing.Point(6, 98);
            this.RdPacientes.Name = "RdPacientes";
            this.RdPacientes.Size = new System.Drawing.Size(99, 18);
            this.RdPacientes.TabIndex = 9;
            this.RdPacientes.Text = "Por pacientes";
            this.RdPacientes.UseVisualStyleBackColor = true;
            this.RdPacientes.CheckedChanged += new System.EventHandler(this.RdPacientes_CheckedChanged);
            // 
            // RdRegimen
            // 
            this.RdRegimen.AutoSize = true;
            this.RdRegimen.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdRegimen.Location = new System.Drawing.Point(6, 76);
            this.RdRegimen.Name = "RdRegimen";
            this.RdRegimen.Size = new System.Drawing.Size(91, 18);
            this.RdRegimen.TabIndex = 8;
            this.RdRegimen.Text = "Por regimen";
            this.RdRegimen.UseVisualStyleBackColor = true;
            this.RdRegimen.CheckedChanged += new System.EventHandler(this.RdRegimen_CheckedChanged);
            // 
            // RdEntidades
            // 
            this.RdEntidades.AutoSize = true;
            this.RdEntidades.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdEntidades.Location = new System.Drawing.Point(6, 52);
            this.RdEntidades.Name = "RdEntidades";
            this.RdEntidades.Size = new System.Drawing.Size(100, 18);
            this.RdEntidades.TabIndex = 7;
            this.RdEntidades.Text = "Por entidades";
            this.RdEntidades.UseVisualStyleBackColor = true;
            this.RdEntidades.CheckedChanged += new System.EventHandler(this.RdEntidades_CheckedChanged);
            // 
            // RdUsuarios
            // 
            this.RdUsuarios.AutoSize = true;
            this.RdUsuarios.Checked = true;
            this.RdUsuarios.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdUsuarios.Location = new System.Drawing.Point(6, 30);
            this.RdUsuarios.Name = "RdUsuarios";
            this.RdUsuarios.Size = new System.Drawing.Size(90, 18);
            this.RdUsuarios.TabIndex = 6;
            this.RdUsuarios.TabStop = true;
            this.RdUsuarios.Text = "Por usuarios";
            this.RdUsuarios.UseVisualStyleBackColor = true;
            this.RdUsuarios.CheckedChanged += new System.EventHandler(this.RdUsuarios_CheckedChanged);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(197, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "Listar los recibos por";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnMostrar
            // 
            this.BtnMostrar.BackColor = System.Drawing.Color.White;
            this.BtnMostrar.BackgroundImage = global::OBCAJASQL.Properties.Resources.mostrar;
            this.BtnMostrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnMostrar.FlatAppearance.BorderSize = 0;
            this.BtnMostrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.BtnMostrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMostrar.Location = new System.Drawing.Point(248, 131);
            this.BtnMostrar.Name = "BtnMostrar";
            this.BtnMostrar.Size = new System.Drawing.Size(64, 44);
            this.BtnMostrar.TabIndex = 219;
            this.BtnMostrar.UseVisualStyleBackColor = false;
            this.BtnMostrar.Click += new System.EventHandler(this.BtnMostrar_Click);
            // 
            // label39
            // 
            this.label39.BackColor = System.Drawing.Color.White;
            this.label39.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.ForeColor = System.Drawing.Color.Black;
            this.label39.Location = new System.Drawing.Point(248, 109);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(64, 23);
            this.label39.TabIndex = 220;
            this.label39.Text = "Mostrar";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.White;
            this.label17.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(248, 190);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(64, 23);
            this.label17.TabIndex = 222;
            this.label17.Text = "Salir";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnSalir
            // 
            this.BtnSalir.BackColor = System.Drawing.Color.White;
            this.BtnSalir.BackgroundImage = global::OBCAJASQL.Properties.Resources.cerrar40px;
            this.BtnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnSalir.FlatAppearance.BorderSize = 0;
            this.BtnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.BtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSalir.Location = new System.Drawing.Point(248, 212);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(64, 44);
            this.BtnSalir.TabIndex = 221;
            this.BtnSalir.UseVisualStyleBackColor = false;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // FrmReporteIngresosPorCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 286);
            this.ControlBox = false;
            this.Controls.Add(this.label17);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.BtnMostrar);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmReporteIngresosPorCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "REPORTES DE INGRESOS POR CAJA";
            this.Load += new System.EventHandler(this.FrmReporteIngresosPorCaja_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DtFecFinal;
        private System.Windows.Forms.DateTimePicker DtFecInicial;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton RdAnulados;
        private System.Windows.Forms.RadioButton RdValidados;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton RdEntidades;
        private System.Windows.Forms.RadioButton RdUsuarios;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton RdTodos;
        private System.Windows.Forms.RadioButton RdRegimenCosto;
        private System.Windows.Forms.RadioButton RdPacientes;
        private System.Windows.Forms.RadioButton RdRegimen;
        private System.Windows.Forms.Button BtnMostrar;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button BtnSalir;
    }
}