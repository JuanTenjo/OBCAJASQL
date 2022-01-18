using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OBCAJASQL.Report;
using OBCAJASQL.Class;
using System.Data.SqlClient;


namespace OBCAJASQL.Forms.Caja
{
    public partial class FrmCruceDepositos : Form
    {
        public FrmCruceDepositos()
        {
            InitializeComponent();
        }

        private void CargarDatosUser()
        {
            try
            {

                if (Utils.codUsuario == "0000" || Utils.codUsuario == "001")
                {

                    Utils.Titulo01 = "Control de errores de ejecución";
                    Utils.Informa = "Lo siento pero este formulario no se puede" + "\r";
                    Utils.Informa += "abrir en este instante, porque el código del" + "\r";
                    Utils.Informa += "usuario no es válido para realizar operaciones" + "\r";
                    Utils.Informa += "con las historias clinicas de los usuarios." + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {

                    lblCodigoUser.Text = Utils.codUsuario;
                    lblNombreUser.Text = Utils.nomUsuario;
                    LblCodEntiFac.Text = Utils.codUnicoEmpresa; // '*********************** Se agrega a partir del 13 de noviembre de 2021 *********************************
                    lblNivelPermitido.Text = Utils.nivelPermiso;


                }
            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "al cargar la informacion del usario" + "\r";
                Utils.Informa += "Error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } //Carga datos de los usuairos

        private void FrmCruceDepositos_Load(object sender, EventArgs e)
        {
            try
            {
                CargarDatosUser();

                TxtHistocruce.Text = Utils.Histocruce;
                TxtFacturDepo.Text = Utils.FacturDepo;

                GridCruceDepositos();

            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "al abrir formulario Cruce Depositos" + "\r";
                Utils.Informa += "Error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GridCruceDepositos()
        {
            try
            {

                Utils.SqlDatos = "SELECT [Datos depositos a usuarios].HisDepo, [Datos depositos a usuarios].ReciCaja, [Datos depositos a usuarios].ValDepo,[Datos depositos a usuarios].FecDepo,  "+
                " [Datos depositos a usuarios].ValAfec, [Datos depositos a usuarios].Saldepo "+
                " FROM [BDCAJASQL].[dbo].[Datos depositos a usuarios] WHERE [Datos depositos a usuarios].HisDepo = '"+ TxtHistocruce.Text  +"' ; ";

                DataSet dataSet = Conexion.SQLDataSet(Utils.SqlDatos);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return;
                }
                else
                {
                    DgCajaCruceDepositos.DataSource = dataSet.Tables[0];
                }

            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "en la funcion GridCruceDepositos" + "\r";
                Utils.Informa += "Error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




    }
}
