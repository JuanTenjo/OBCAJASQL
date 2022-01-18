using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OBCAJASQL.Class;
using System.Data.SqlClient;


namespace OBCAJASQL.Forms.Caja
{
    public partial class FrmInputReciboCaja : Form
    {
        public FrmInputReciboCaja()
        {
            InitializeComponent();
        }

        private void BtnListo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtReciboCaja.Text))
            {
                Utils.Titulo01 = "Control de ejecución";
                Utils.Informa = "Lo siento pero se ha digitado ningun numero de recibo" + "\r";
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Utils.ReciboCaja = TxtReciboCaja.Text;
                this.Dispose();
            }

        }
    }
}
