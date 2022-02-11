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

namespace OBCAJASQL.Forms.Pagares.Reportes
{
    public partial class FrmReportesPagares : Form
    {
        public FrmReportesPagares()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CboDigiNom_KeyPress(object sender, KeyPressEventArgs e)
        {
            CboDigiNom.DroppedDown = false;
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

        private void CargarCombo()
        {
            try
            {
                Utils.SqlDatos = "SELECT [Datos tarifas contradas].CodiTar, [Datos tarifas contradas].NomTar FROM [ACDATOXPSQL].[dbo].[Datos tarifas contradas] ORDER BY [Datos tarifas contradas].NomTar;";

                DataSet dataSet2 = Conexion.SQLDataSet(Utils.SqlDatos);

                if (dataSet2 != null && dataSet2.Tables.Count > 0)
                {
                    this.CboDigiNom.DataSource = dataSet2.Tables[0];
                    this.CboDigiNom.ValueMember = "CodiTar";
                    this.CboDigiNom.DisplayMember = "NomTar";
                }

            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "en la funcion cargar combobox" + "\r";
                Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        int MarVigenAnul = 1;
        int MarInfo = 1;
        private void FrmReportesPagares_Load(object sender, EventArgs e)
        {
            try
            {
                CargarDatosUser();
                CargarCombo();
            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "al abrir formulario de reportes de pagos y ´pagares" + "\r";
                Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            //Por Digitadores
            MarInfo = 1;
            CboDigiNom.Visible = true;
            TxtFacNumPa.Visible = false;
            TxtTipoDoCodeu.Visible = false;
            TxtNumDoCodeu.Visible = false;
            TxtTipoDoRespon.Visible = false;
            TxtNumDoRespon.Visible = false;
            TxtHistoriaPaci.Visible = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            //Por cuentas contables
            MarInfo = 2;
            CboDigiNom.Visible = false;
            TxtFacNumPa.Visible = false;
            TxtTipoDoCodeu.Visible = false;
            TxtNumDoCodeu.Visible = false;
            TxtTipoDoRespon.Visible = false;
            TxtNumDoRespon.Visible = false;
            TxtHistoriaPaci.Visible = false;
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //Por facturas
            MarInfo = 3;
            CboDigiNom.Visible = false;
            TxtFacNumPa.Visible = true;
            TxtTipoDoCodeu.Visible = false;
            TxtNumDoCodeu.Visible = false;
            TxtTipoDoRespon.Visible = false;
            TxtNumDoRespon.Visible = false;
            TxtHistoriaPaci.Visible = false;
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            //Por Codeudores
            MarInfo = 4;
            CboDigiNom.Visible = false;
            TxtFacNumPa.Visible = false;
            TxtTipoDoCodeu.Visible = true;
            TxtNumDoCodeu.Visible = true;
            TxtTipoDoRespon.Visible = false;
            TxtNumDoRespon.Visible = false;
            TxtHistoriaPaci.Visible = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //Por responsables
            MarInfo = 5;
            CboDigiNom.Visible = false;
            TxtFacNumPa.Visible = false;
            TxtTipoDoCodeu.Visible = true;
            TxtNumDoCodeu.Visible = true;
            TxtTipoDoRespon.Visible = false;
            TxtNumDoRespon.Visible = false;
            TxtHistoriaPaci.Visible = false;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            //Por pacientes
            MarInfo = 6;
            CboDigiNom.Visible = false;
            TxtFacNumPa.Visible = false;
            TxtTipoDoCodeu.Visible = false;
            TxtNumDoCodeu.Visible = false;
            TxtTipoDoRespon.Visible = false;
            TxtNumDoRespon.Visible = false;
            TxtHistoriaPaci.Visible = true;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            //Por Todo
            MarInfo = 7;
            CboDigiNom.Visible = false;
            TxtFacNumPa.Visible = false;
            TxtTipoDoCodeu.Visible = false;
            TxtNumDoCodeu.Visible = false;
            TxtTipoDoRespon.Visible = false;
            TxtNumDoRespon.Visible = false;
            TxtHistoriaPaci.Visible = false;
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void radioButtonValidas_CheckedChanged(object sender, EventArgs e)
        {
            MarVigenAnul = 1;
        }

        private void radioButtonAnuladas_CheckedChanged(object sender, EventArgs e)
        {
            MarVigenAnul = 2;
        }

        private void BtnMostrar_Click(object sender, EventArgs e)
        {
            try
            {
                string ND = "", Para01 = "", TD = "",  RVal = "", F0F = "", F0I = "", Para02 = "", Para03 = "", Para04 = "", Para05 = "", Para06 = "";
                int FGF = 0, RVA = 0;

                Utils.Titulo01 = "Control para mostrar datos";

                F0I = DtFecInicial.Value.ToString("yyyy-MM-dd");
                F0F = DtFecFinal.Value.ToString("yyyy-MM-dd");

                Utils.FechaInicial = F0I;
                Utils.FechaFinal = F0F;


                // Para los pagarés pagados por caja

                Para01 = "[Datos recibos de caja].[FechaPagoCaja] >= CONVERT(Datetime,'" + F0I + "',102)";
                Para02 = "[Datos recibos de caja].[FechaPagoCaja] <= CONVERT(Datetime,'" + F0F + "',102)";

                //Defina si muestra los  validos o los anulados
                switch (MarVigenAnul)
                {
                    case 1: //Muesta los pagares vigentes
                        RVA = 0;
                        Para06 = "[Datos registro de pagares].[AnuladoRecibo] = 0";
                        RVal = "pagarés válidos";
                        break;
                    case 2: //Muesta los pagares anulado
                        RVA = -1;
                        Para06 = "[Datos registro de pagares].[AnuladoRecibo] = 1";
                        RVal = "pagarés válidos";
                        break;
                    default:
                        break;
                }


                switch (MarInfo)
                {
                    case 1: //Muestra por digitadores


                        if (CboDigiNom.SelectedIndex == -1)
                        {
                            Utils.Informa = "Lo siento pero usted no ha seleccionado" + "\r";
                            Utils.Informa += "el nombre del digitador a mostrar" + "\r";
                            MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        ND = CboDigiNom.SelectedValue.ToString();

                        Para03 = "[Datos registro de pagares].[CodRegis] = '" + ND + "'";

                        Utils.Informa = "¿Usted desea mostrar todo los " + RVal + "\r";
                        Utils.Informa += "realizados por " + CboDigiNom.Text + "\r";
                        Utils.Informa += $"entre el {F0I} y el {F0F}?";


                        Para04 = "(" + Para01 + " and " + Para02 + ") and " + Para03 + " and " + Para06;

                        Utils.infNombreInforme = "Informe pagares por digitadores";

                        break;
                    case 2:

                        Para04 = "(" + Para01 + " and " + Para02 + " and " + Para06;

                        Utils.Informa = "¿Usted desea mostrar todo los " + RVal + "\r";
                        Utils.Informa += "que afectaron las cuentas contables" + "\r";
                        Utils.Informa += $"entre el {F0I} y el {F0F}?";

                        Utils.infNombreInforme = "Informe pagares por cuentas";


                        break;
                    case 3:

                        if (string.IsNullOrWhiteSpace(TxtFacNumPa.Text))
                        {
                            Utils.Informa = "Lo siento pero usted no ha difitado";
                            Utils.Informa += "el numero de la cuenta a mostrar";
                            MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            TxtFacNumPa.Select();
                        }

                        ND = TxtFacNumPa.Text;

                        Para03 = "[Datos registro de pagares].[NumFacPaga] = '" + ND + "'";

                        Utils.Informa = "¿Usted desea mostrar todo los " + RVal + "\r";
                        Utils.Informa += "registrados a la factura " + TxtFacNumPa.Text + "\r";
                        Utils.Informa += $"entre el {F0I} y el {F0F}?";

                        Para04 = "(" + Para01 + " and " + Para02 + " and " + Para03 + " and " + Para06;

                        Utils.infNombreInforme = "Informe pagares por digitadores";

                        break;
                    case 4: //Por codeudor del pagaré


                        if (string.IsNullOrWhiteSpace(TxtTipoDoCodeu.Text))
                        {
                            Utils.Informa = "Lo siento pero usted no ha digitado";
                            Utils.Informa += "el tipo de documento del codeudor.";
                            MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            TxtTipoDoCodeu.Select();
                        }


                        if (string.IsNullOrWhiteSpace(TxtNumDoCodeu.Text))
                        {
                            Utils.Informa = "Lo siento pero usted no ha digitado";
                            Utils.Informa += "el numero de documento del codeudor.";
                            MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            TxtNumDoCodeu.Select();
                        }

                        TD = TxtTipoDoCodeu.Text;
                        ND = TxtNumDoCodeu.Text;

                        Para03 = "[Datos registro de pagares].[TDCodeudor] = " + TD;
                        Para05 = "[Datos registro de pagares].[CodeuPaga] = " + ND;

                        Utils.Informa = "¿Usted desea mostrar todo los " + RVal + "\r";
                        Utils.Informa += "registrados al codeudor " + TD + ": " + ND +"\r";
                        Utils.Informa += $"entre el {F0I} y el {F0F}?";

                        Para04 = Para01 + " and " + Para02 + " and " + Para03 + " and " + Para05 + " and " + Para06;

                        Utils.infNombreInforme = "Informe pagares por digitadores";

                        break;
                    case 5:

                        //Por responsables

                        if (string.IsNullOrWhiteSpace(TxtTipoDoRespon.Text)) 
                        {
                            Utils.Informa = "Lo siento pero usted no ha digitado";
                            Utils.Informa += "el tipo de documento del responsable.";
                            MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            TxtTipoDoRespon.Select();
                        }

                        if (string.IsNullOrWhiteSpace(TxtNumDoRespon.Text))
                        {
                            Utils.Informa = "Lo siento pero usted no ha digitado";
                            Utils.Informa += "el numero de documento del responsable.";
                            MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            TxtNumDoRespon.Select();
                        }

                        TD = TxtTipoDoRespon.Text;
                        ND = TxtNumDoRespon.Text;

                        Para03 = "[Datos registro de pagares].[TDRespon] = " + TD;
                        Para05 = "[Datos registro de pagares].[NumTerPaga] = " + ND;

                        Utils.Informa = "¿Usted desea mostrar todo los " + RVal + "\r";
                        Utils.Informa += "registrados al responsable " + TD + ": " + ND + "\r";
                        Utils.Informa += $"entre el {F0I} y el {F0F}?";

                        Para04 = Para01 + " and " + Para02 + " and " + Para03 + " and " + Para05 + " and " + Para06;

                        Utils.infNombreInforme = "Informe pagares por digitadores";

                        break;
                    case 6:   //Por pacientes

                        if (string.IsNullOrWhiteSpace(TxtHistoriaPaci.Text))
                        {
                            Utils.Informa = "Lo siento pero usted no ha digitado";
                            Utils.Informa += "el número de historia del paciente.";
                            MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            TxtHistoriaPaci.Select();
                        }

                        ND = TxtHistoriaPaci.Text;

                        Para03 = "[Datos registro de pagares].[HistoriaPaga] = '"+ ND +"'";

                        Utils.Informa = "¿Usted desea mostrar todo los " + RVal + "\r";
                        Utils.Informa += "realizados a la historia No. " + TD + ": " + ND + "\r";
                        Utils.Informa += $"entre el {F0I} y el {F0F}?";

                        Para04 = Para01 + " and " + Para02 + " and " + Para03 + " and " + Para06;

                        Utils.infNombreInforme = "Informe pagares por pacientes";

                        break;
                    case 7:

                        Para04 = "(" + Para01 + " and " + Para02 + ")" + " and " + Para06;

                        Utils.Informa = "¿Usted desea mostrar todo los " + RVal + "\r";
                        Utils.Informa += "realizados y registrados " + TD + ": " + ND + "\r";
                        Utils.Informa += $"entre el {F0I} y el {F0F}?";

                        Utils.infNombreInforme = "Informe todos los pagares";

                        break;
                    default:
                        break;
                }

                var res = MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if(res == DialogResult.Yes)
                {
                    FrmReportes frmReportes = new FrmReportes();
                    frmReportes.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "al dar click en el boton mostrar" + "\r";
                Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
