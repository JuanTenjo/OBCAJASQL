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
    public partial class FrmBuscarServicios : Form
    {
        public FrmBuscarServicios()
        {
            InitializeComponent();
        }

        private void BtnBuscarADmin_Click(object sender, EventArgs e)
        {
            try
            {
                string SqlDatos = "", NoBus = "";
                int CodiBus = 0;
                Utils.Titulo01 = "Control para buscar datos";

                SqlDatos = "SELECT [Datos catalogo de servicios].CodInterno, [Datos catalogo de servicios].NomServicio, [Datos catalogo de servicios].CodiMedMin, " +
                " [Datos catalogo de servicios].CenCosto, [Datos catalogo de servicios].ValorCUPS, [Datos catalogo de servicios].ValorParti,  " +
                " [Datos catalogo de servicios].ValorSoat, [Datos catalogo de servicios].ValorIss, [Datos catalogo de servicios].ValorEspecial01,  " +
                " [Datos catalogo de servicios].ValorEspecial02, [Datos catalogo de servicios].ValorEspecial03, [Datos catalogo de servicios].ValorEspecial04,  " +
                " [Datos catalogo de servicios].HabilPro, " +
                " [Datos catalogo de servicios].ActuaValUni, [Datos catalogo de servicios].GrupoServi " +
                " FROM [ACDATOXPSQL].[dbo].[Datos catalogo de servicios] ";


                switch (CboAmbitoBuscar.SelectedIndex)
                {
                    case 0: //Busca por las iniciales del nombre

                        if (string.IsNullOrWhiteSpace(TxtParaBuscar.Text))
                        {
                            Utils.Informa = "Lo siento pero usted no ha digitado las" + "\r";
                            Utils.Informa = "letras iniciales del servicio a buscar" + "\r";
                            MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            NoBus = "las iniciales ";
                            CodiBus = CboAmbitoBuscar.SelectedIndex;
                            SqlDatos += "WHERE [Datos catalogo de servicios].NomServicio Like '" + TxtParaBuscar.Text + "%'";
                        }

                        break;
                    case 1://Busca por el nombre completo

                        if (string.IsNullOrWhiteSpace(TxtParaBuscar.Text))
                        {
                            Utils.Informa = "Lo siento pero usted no ha digitado las" + "\r";
                            Utils.Informa = "nombre completo del procedimiento a buscar" + "\r";
                            MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            NoBus = "el nombre completo ";
                            CodiBus = CboAmbitoBuscar.SelectedIndex;
                            SqlDatos += "WHERE [Datos catalogo de servicios].NomServicio Like '%" + TxtParaBuscar.Text + "%'";
                        }
                        break;
                    case 2: //Busca por el código interno IPS

                        if (string.IsNullOrWhiteSpace(TxtParaBuscar.Text))
                        {
                            Utils.Informa = "Lo siento pero usted no ha digitado las" + "\r";
                            Utils.Informa = "código IPS del procedimiento a buscar" + "\r";
                            MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            NoBus = "el código IPS ";
                            CodiBus = CboAmbitoBuscar.SelectedIndex;
                            SqlDatos += "WHERE [Datos catalogo de servicios].CodInterno = '" + TxtParaBuscar.Text + "'";
                        }

                        break;

                    default:
                        break;
                }

                SqlDatos += " ORDER BY [Datos catalogo de servicios].NomServicio ";

                //Proceda a buscar


                DataSet dataSet = Conexion.SQLDataSet(SqlDatos);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    Utils.Titulo01 = "Control de ejecución";
                    Utils.Informa = "Lo siento pero se ha encontrado ningún servicio con los criterios" + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    DgLisServicios.DataSource = dataSet.Tables[0];
                }

            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "al dar click en buscar" + "\r";
                Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEligeTercero_Click(object sender, EventArgs e)
        {
            try
            {
                string CodigoServi = "";

                if (DgLisServicios.SelectedRows.Count > 0)
                {
                    CodigoServi = DgLisServicios.SelectedCells[0].Value.ToString();
                }
                else
                {
                    Utils.Informa = " Primerammente se debe seleccionar un servicio de la lista" + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Utils.CodigoServi = CodigoServi;

                this.Dispose();

            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "de hacer click sobre el botón de elegir" + "\r";
                Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
