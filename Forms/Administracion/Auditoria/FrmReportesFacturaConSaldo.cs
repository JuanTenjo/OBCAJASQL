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



namespace OBCAJASQL.Forms.Administracion.Auditoria
{
    public partial class FrmReportesFacturaConSaldo : Form
    {
        public FrmReportesFacturaConSaldo()
        {
            InitializeComponent();
        }

        #region RadiosButton
        private void radioButtonValidas_CheckedChanged(object sender, EventArgs e)
        {
            MarVigenAnul = 1;
        }

        private void radioButtonAnuladas_CheckedChanged(object sender, EventArgs e)
        {
            MarVigenAnul = 2;
        }

        private void radioButtonEntidad_CheckedChanged(object sender, EventArgs e)
        {
            MarInfo = 1;
        }

        private void radioButtonTodas_CheckedChanged(object sender, EventArgs e)
        {
            MarInfo = 2;
        }


        #endregion

        #region ComboBox

        private void cboNomEnti_KeyPress(object sender, KeyPressEventArgs e)
        {
            cboNomEnti.DroppedDown = false;
        }

        #endregion

        #region Funciones

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
                    LblCodEntiFac.Text = Utils.codUnicoEmpresa; // '*********************** Se agrega a partir del 13 de octubre de 2020 *********************************

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

        private void CargarCombobox()
        {
            try
            {
                this.cboNomEnti.DataSource = null;
                this.cboNomEnti.Items.Clear();

                Utils.SqlDatos = "SELECT [Datos empresas y terceros].CarAdmin, " +
                " ([NomAdmin] + ' ' + [ProgrAmin]) AS Entidad FROM [ACDATOXPSQL].[dbo].[Datos empresas y terceros]" +
                "  WHERE ((([Datos empresas y terceros].HabilEmp) = 'True')) AND [NomAdmin] + ' ' + [ProgrAmin] is not NULL ORDER BY([NomAdmin] + ' ' + [ProgrAmin]); ";

                DataSet dataSet = Conexion.SQLDataSet(Utils.SqlDatos);

                if (dataSet != null && dataSet.Tables.Count > 0)
                {
                    this.cboNomEnti.DataSource = dataSet.Tables[0];
                    this.cboNomEnti.ValueMember = "CarAdmin";
                    this.cboNomEnti.DisplayMember = "Entidad";
                }


            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "en la funcion CargarCombobox" + "\r";
                Utils.Informa += "Error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } //Carga los combobox iniciales

        #endregion

        #region Botones
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        #endregion



        //Variables para los RadioButton
        int MarVigenAnul = 1;
        int MarInfo = 1;

        private void FrmReportesFacturaConSaldo_Load(object sender, EventArgs e)
        {
            try
            {

                CargarCombobox();
                CargarDatosUser();

            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "al abrir el formulario Reportes Facturas con Saldo" + "\r";
                Utils.Informa += "Error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void BtnMostrar_Click(object sender, EventArgs e)
        {
            try
            {
                int RVA = 0;
                string Para03 = "", Para01 = "", Para02 = "", F01, F02, RVal = "", ND, Para05, Para04 = "";

                Utils.Titulo01 = "Control para mostrar datos";

                //Cuales FACTURAS muestra

                if(DateInicial.Value > DateFinal.Value)
                {
                    Utils.Informa = "Lo siento pero usted ha seleccionado" + "\r";
                    Utils.Informa += "una fecha inicial mayor que la fecha final" + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DateInicial.Select();
                    return;
                }

                F01 = Convert.ToString(DateInicial.Value.ToString("yyyy-MM-dd"));
                F02 = Convert.ToString(DateFinal.Value.ToString("yyyy-MM-dd"));

              

                Para01 = "[ACDATOXPSQL].[dbo].[Datos de las facturas realizadas].FechaFac >=  " + "CONVERT(DATETIME,'" + Convert.ToDateTime(F01).ToString("yyyy-MM-dd") + "',102)";
                Para02 = "[ACDATOXPSQL].[dbo].[Datos de las facturas realizadas].FechaFac <= " + "CONVERT(DATETIME,'" + Convert.ToDateTime(F02).ToString("yyyy-MM-dd") + "',102)";

                //Defina si muestra las  validas o las anuladas

                switch (MarVigenAnul)
                {
                    case 1:

                        RVA = 0;
                        Para03 = "[ACDATOXPSQL].[dbo].[Datos de las facturas realizadas].AnuladaFac = 'False'";
                        RVal = "facturas vigentes";

                        break;
                    case 2:

                        RVA = -1;
                        Para03 = "[ACDATOXPSQL].[dbo].[Datos de las facturas realizadas].AnuladaFac = 'True'";
                        RVal = "facturas anuladas";

                        break;
                    default:
                        break;
                }

                switch (MarInfo)
                {
                    case 1: //Muestra por entidad

                        if(cboNomEnti.SelectedIndex  == -1 || string.IsNullOrWhiteSpace(cboNomEnti.Text))
                        {
                            Utils.Informa = "Lo siento pero usted no ha seleccionado" + "\r";
                            Utils.Informa += "el nombre de la entidad a mostrar" + "\r";
                            MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cboNomEnti.Select();
                            return;
                        }

                        ND = cboNomEnti.SelectedValue.ToString();

                        Para05 = "[ACDATOXPSQL].[dbo].[Datos de las facturas realizadas].Cartercero = '" + ND + "'";

                        if(RVA == 0)
                        {
                            //Facturas VIGENTES
                            Utils.Informa = "¿Usted desea mostrar todas las " + RVal +  "\r";
                            Utils.Informa += "realizadas a " + cboNomEnti.Text +  "\r";
                            Utils.Informa += "entre el " + F01 + " y el " + F02 + "\r";

                            Para04 = "( " + Para01 + " and " + Para02 + " ) and " + Para03 + " and " + Para05;

                        }
                        else
                        {
                            Utils.Informa = "¿Usted desea mostrar todas las " + RVal + "\r";
                            Utils.Informa += "realizadas a " + cboNomEnti.Text + "\r";
                            Utils.Informa += "entre el " + F01 + " y el " + F02 + "\r";

                            Para04 = "( " + Para01 + " and " + Para02 + " ) and " + Para03 + " and " + Para05;
                        }

                        Utils.infNombreInforme = "Informe facturas con saldos por entidades";

                    break;

                    case 2: //Muestra todas las facturas con saldos

                        Para04 = "( " + Para01 + " and " + Para02 + " ) and " + Para03;

                        Utils.Informa = "¿Usted desea mostrar todas las " + RVal + "\r";
                        Utils.Informa += " con saldos realizados entre el " + "\r";
                        Utils.Informa +=  F01 + " y el " + F02 + "?" + "\r";


                        Utils.infNombreInforme = "Informe facturas con saldos todas";


                        break;
                    default:
                        break;
                }

                var res = MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if(res == DialogResult.Yes)
                {
                    Utils.condicion = Para04;
                    Utils.FecInicial = F01;
                    Utils.FecFinal = F02;

                    FrmReportFacturaSaldo frmReportFacturaSaldo = new FrmReportFacturaSaldo();
                    frmReportFacturaSaldo.ShowDialog();

                }

            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "al dar click al boton mostrar" + "\r";
                Utils.Informa += "Error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
