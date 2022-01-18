
namespace OBCAJASQL.Forms.Caja
{
    partial class FrmInputReciboCaja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInputReciboCaja));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtReciboCaja = new System.Windows.Forms.TextBox();
            this.BtnListo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(2, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(424, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Por favor digite el número";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(2, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(424, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "del recibo de caja, al cual le desea sacar una copia.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TxtReciboCaja
            // 
            this.TxtReciboCaja.Location = new System.Drawing.Point(5, 62);
            this.TxtReciboCaja.Name = "TxtReciboCaja";
            this.TxtReciboCaja.Size = new System.Drawing.Size(421, 20);
            this.TxtReciboCaja.TabIndex = 7;
            // 
            // BtnListo
            // 
            this.BtnListo.Location = new System.Drawing.Point(189, 88);
            this.BtnListo.Name = "BtnListo";
            this.BtnListo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BtnListo.Size = new System.Drawing.Size(75, 23);
            this.BtnListo.TabIndex = 8;
            this.BtnListo.Text = "Listo";
            this.BtnListo.UseVisualStyleBackColor = true;
            this.BtnListo.Click += new System.EventHandler(this.BtnListo_Click);
            // 
            // FrmInputReciboCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 116);
            this.Controls.Add(this.BtnListo);
            this.Controls.Add(this.TxtReciboCaja);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmInputReciboCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Expedir copias de un recibo registrado";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtReciboCaja;
        private System.Windows.Forms.Button BtnListo;
    }
}