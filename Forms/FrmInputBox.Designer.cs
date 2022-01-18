
namespace OBCAJASQL.Forms
{
    partial class FrmInputBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInputBox));
            this.BtnListo = new System.Windows.Forms.Button();
            this.TxtValue = new System.Windows.Forms.TextBox();
            this.LblTexto = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnListo
            // 
            this.BtnListo.Location = new System.Drawing.Point(199, 64);
            this.BtnListo.Name = "BtnListo";
            this.BtnListo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BtnListo.Size = new System.Drawing.Size(75, 23);
            this.BtnListo.TabIndex = 12;
            this.BtnListo.Text = "Aceptar";
            this.BtnListo.UseVisualStyleBackColor = true;
            this.BtnListo.Click += new System.EventHandler(this.BtnListo_Click);
            // 
            // TxtValue
            // 
            this.TxtValue.Location = new System.Drawing.Point(15, 38);
            this.TxtValue.Name = "TxtValue";
            this.TxtValue.Size = new System.Drawing.Size(421, 20);
            this.TxtValue.TabIndex = 11;
            // 
            // LblTexto
            // 
            this.LblTexto.BackColor = System.Drawing.Color.LightSeaGreen;
            this.LblTexto.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTexto.ForeColor = System.Drawing.Color.White;
            this.LblTexto.Location = new System.Drawing.Point(12, 9);
            this.LblTexto.Name = "LblTexto";
            this.LblTexto.Size = new System.Drawing.Size(424, 23);
            this.LblTexto.TabIndex = 9;
            this.LblTexto.Text = "Por favor digite el número";
            this.LblTexto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmInputBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 96);
            this.Controls.Add(this.BtnListo);
            this.Controls.Add(this.TxtValue);
            this.Controls.Add(this.LblTexto);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmInputBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Input Box";
            this.Load += new System.EventHandler(this.FrmInputBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnListo;
        private System.Windows.Forms.TextBox TxtValue;
        private System.Windows.Forms.Label LblTexto;
    }
}