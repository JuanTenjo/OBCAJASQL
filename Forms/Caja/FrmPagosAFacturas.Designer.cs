
namespace OBCAJASQL.Forms.Caja
{
    partial class FrmPagosAFacturas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPagosAFacturas));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LblNomCajAct = new System.Windows.Forms.Label();
            this.LblCodCajAct = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.LblNomCajAct);
            this.groupBox1.Controls.Add(this.LblCodCajAct);
            this.groupBox1.Controls.Add(this.label29);
            this.groupBox1.Location = new System.Drawing.Point(7, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(732, 52);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // LblNomCajAct
            // 
            this.LblNomCajAct.BackColor = System.Drawing.Color.White;
            this.LblNomCajAct.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNomCajAct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.LblNomCajAct.Location = new System.Drawing.Point(360, 13);
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
            this.LblCodCajAct.Location = new System.Drawing.Point(303, 13);
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
            this.label29.Location = new System.Drawing.Point(250, 13);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(51, 32);
            this.label29.TabIndex = 20;
            this.label29.Text = "CAJA:";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmPagosAFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 450);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPagosAFacturas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CANCELACION DE FACTURAS POR CAJA";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label LblNomCajAct;
        private System.Windows.Forms.Label LblCodCajAct;
        private System.Windows.Forms.Label label29;
    }
}