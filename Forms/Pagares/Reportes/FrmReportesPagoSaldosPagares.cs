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
    public partial class FrmReportesPagoSaldosPagares : Form
    {
        public FrmReportesPagoSaldosPagares()
        {
            InitializeComponent();
        }

        int MarInfo = 1;
        int MarVigenAnul = 1;
        int TipoPagos = 1;
        int EstadoPaga = 3;
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


        private void FrmReportesPagoSaldosPagares_Load(object sender, EventArgs e)
        {
            try
            {
                CargarDatosUser();
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
            MarInfo = 1;
            TxtPagaNum.Visible = true;
            LblNoPagare.Visible = true;
            TxtNumDoTerce.Visible = false;
            LblDocumentoNo.Visible = false;
            TxtHistoNum.Visible = false;
            LblHistoriaNo.Visible = false;

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            MarInfo = 2;
            TxtPagaNum.Visible = false;
            LblNoPagare.Visible = false;
            TxtNumDoTerce.Visible = true;
            LblDocumentoNo.Visible = true;
            TxtHistoNum.Visible = false;
            LblHistoriaNo.Visible = false;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            MarInfo = 3;
            TxtPagaNum.Visible = false;
            LblNoPagare.Visible = false;
            TxtNumDoTerce.Visible = false;
            LblDocumentoNo.Visible = false;
            TxtHistoNum.Visible = true;
            LblHistoriaNo.Visible = true;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            MarInfo = 4;
            TxtPagaNum.Visible = false;
            LblNoPagare.Visible = false;
            TxtNumDoTerce.Visible = false;
            LblDocumentoNo.Visible = false;
            TxtHistoNum.Visible = false;
            LblHistoriaNo.Visible = false;
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

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            TipoPagos = 1;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            TipoPagos = 2;
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {

            DtFecInicial.Enabled = false;
            DtFecFinal.Enabled = false;
            radioButton2.Enabled = false;       
            radioButton1.Enabled = false;

            EstadoPaga = 1;
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            DtFecInicial.Enabled = false;
            DtFecFinal.Enabled = false;
            radioButton2.Enabled = false;
            radioButton1.Enabled = false;
            EstadoPaga = 2;
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            DtFecInicial.Enabled = true;
            DtFecFinal.Enabled = true;
            radioButton2.Enabled = true;
            radioButton1.Enabled = true;
            EstadoPaga = 3;
        }

        private void BtnMostrar_Click(object sender, EventArgs e)
        {
            try
            {
                Utils.Titulo01 = "Control para mostrar datos";

                string F0I, F0F, PN = "", Tipag = "", Para08 = "", ND = "", Para06 = "", Para010 = "", Para05 = "", RVal = "", Para011 = "", Para012 = "", Para01 = "", Para02 = "", Para03 = "", Para04 = "", Para07 = "";
                int RVA = 0;

                F0I = DtFecInicial.Value.ToString("yyyy-MM-dd");
                F0F = DtFecFinal.Value.ToString("yyyy-MM-dd");

                Utils.FechaInicial = F0I;
                Utils.FechaFinal = F0F;


                // Para los pagarés pagados por caja

                Para01 = "[Datos recibos de caja].[FechaPagoCaja] >= CONVERT(Datetime,'" + F0I + "',102)";
                Para02 = "[Datos recibos de caja].[FechaPagoCaja] <= CONVERT(Datetime,'" + F0F + "',102)";

                //Para los pagarés pagados por medio electrónico

                Para03 = "[Datos abonos electronicos a pagares].[FecConsig_Elect] >= CONVERT(Datetime,'" + F0I + "',102)";
                Para04 = "[Datos abonos electronicos a pagares].[FecConsig_Elect] <= CONVERT(Datetime,'" + F0I + "',102)";

                //Defina si muestra los  validos o los anulados
                switch (MarVigenAnul)
                {
                    case 1: //Muesta los pagares vigentes
                        RVA = 0;
                        Para07 = "[Datos registro de pagares].[AnuladoRecibo] = 0";
                        RVal = "pagarés válidos";
                        break;
                    case 2: //Muesta los pagares anulado
                        RVA = -1;
                        Para07 = "[Datos registro de pagares].[AnuladoRecibo] = 1";
                        RVal = "pagarés válidos";
                        break;
                    default:
                        break;
                }

                Para011 = "([Datos registro cuotas pagares].[ValCuota] - [Datos registro cuotas pagares].[ValPagado]) <> 0";
                Para012 = "([Datos registro cuotas pagares].[ValCuota] - [Datos registro cuotas pagares].[ValPagado]) = 0";

                //Define si muestra los pagarés con saldos o sin saldos o todos

                switch (EstadoPaga)
                {
                    case 1: //Con saldos:

                        switch (MarInfo)
                        {
                            case 1: //Muesta Abonos por Pagarés

                                if (string.IsNullOrWhiteSpace(TxtPagaNum.Text))
                                {
                                    Utils.Informa = "Lo siento pero usted no ha digitado" + "\r";
                                    Utils.Informa += "al abrir formulario de reportes de pagos y ´pagares" + "\r";
                                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }


                                PN = TxtPagaNum.Text;

                                Para05 = "[Datos registro de pagares].[NumPaga] = '" + PN + "'";

                                Utils.Informa = "¿Usted desea mostrar el saldo" + "\r";
                                Utils.Informa += "registrados al pagaré " + PN;

                                Para010 = Para05 + " and " + Para07 + " and " + Para011;

                                Utils.infNombreInforme = "Informe saldos de pagares";
                                TxtPagaNum.Clear();

                                break;
                            case 2: //Muestra Aboonos por tercero


                                if (string.IsNullOrWhiteSpace(TxtNumDoTerce.Text))
                                {
                                    Utils.Informa = "Lo siento pero usted no ha digitado" + "\r";
                                    Utils.Informa += "el numero del pagare a mostrar" + "\r";
                                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                                ND = TxtNumDoTerce.Text;

                                Para06 = "[Datos registro de pagares].[NumTerPaga] = '" + ND + "'";

                                Utils.Informa = "¿Usted desea mostrar el saldo registrado" + "\r";
                                Utils.Informa += "al tercero con documento No. " + ND;

                                Para010 = Para06 + " and " + Para07 + " and " + Para011;

                                Utils.infNombreInforme = "Informe saldos de pagares";
                                TxtHistoNum.Clear();



                                break;
                            case 3: //Muestra Abonos por Paciente

                                if (string.IsNullOrWhiteSpace(TxtHistoNum.Text))
                                {
                                    Utils.Informa = "Lo siento pero usted no ha digitado";
                                    Utils.Informa += "el número de historia del paciente.";
                                }

                                ND = TxtHistoNum.Text;

                                Para08 = "[Datos registro de pagares].HistoriaPaga = " + ND;
                                Para010 = Para08 + " and " + Para07 + " and " + Para011;

                                Utils.Informa = "¿Usted desea mostrar el saldo del pagaré" + "\r";
                                Utils.Informa += "registrado a la historia No. " + ND;

                                Utils.infNombreInforme = "Informe saldos de pagares";
                                TxtHistoNum.Clear();

                                break;
                            case 4: //Muestra Abonos por todos


                                Para010 = Para07 + " and " + Para011;

                                Utils.Informa = "¿Usted desea mostrar todos los" + "\r";
                                Utils.Informa += "pagarés con saldos registrados?";

                                Utils.infNombreInforme = "Informe saldos de pagares";

                                break;
                            default:
                                break;
                        }
                        break;
                    case 2: //Sin saldos

                        switch (MarInfo)
                        {
                            case 1: //Muestra Abonos por Pagares

                                if (string.IsNullOrWhiteSpace(TxtPagaNum.Text))
                                {
                                    Utils.Informa = "Lo siento pero usted no ha digitado" + "\r";
                                    Utils.Informa += "al abrir formulario de reportes de pagos y ´pagares" + "\r";
                                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }


                                PN = TxtPagaNum.Text;

                                Para05 = "[Datos registro de pagares].[NumPaga] = '" + PN + "'";

                                Utils.Informa = "¿Usted desea mostrar el pagaré" + "\r";
                                Utils.Informa += "registrados sin saldo?";

                                Para010 = Para05 + " and " + Para07 + " and " + Para012;

                                Utils.infNombreInforme = "Informe saldos de pagares";
                                TxtPagaNum.Clear();


                                break;
                            case 2: //Muestra Aboonos por tercero


                                if (string.IsNullOrWhiteSpace(TxtNumDoTerce.Text))
                                {
                                    Utils.Informa = "Lo siento pero usted no ha digitado" + "\r";
                                    Utils.Informa += "el numero del pagare a mostrar" + "\r";
                                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                                ND = TxtNumDoTerce.Text;

                                Para06 = "[Datos registro de pagares].[NumTerPaga] = '" + ND + "'";

                                Utils.Informa = "¿Usted desea mostrar el pagaré registrado sin " + "\r";
                                Utils.Informa += "saldo al tercero con documento No. " + ND;

                                Para010 = Para06 + " and " + Para07 + " and " + Para012;

                                Utils.infNombreInforme = "Informe saldos de pagares";
                                TxtHistoNum.Clear();



                                break;
                            case 3: //Muestra Abonos por Paciente

                                if (string.IsNullOrWhiteSpace(TxtHistoNum.Text))
                                {
                                    Utils.Informa = "Lo siento pero usted no ha digitado";
                                    Utils.Informa += "el número de historia del paciente.";
                                }

                                ND = TxtHistoNum.Text;

                                Para08 = "[Datos registro de pagares].HistoriaPaga = " + ND;
                                Para010 = Para08 + " and " + Para07 + " and " + Para012;

                                Utils.Informa = "¿Usted desea mostrar el pagaré registrado" + "\r";
                                Utils.Informa += "sin  saldo a la historia No. " + ND;

                                Utils.infNombreInforme = "Informe saldos de pagares";
                                TxtHistoNum.Clear();

                                break;
                            case 4: //Muestra Abonos por todos


                                Para010 = Para07 + " and " + Para012;

                                Utils.Informa = "¿Usted desea mostrar todos los" + "\r";
                                Utils.Informa += "pagarés registrados sin saldos?";

                                Utils.infNombreInforme = "Informe saldos de pagares";

                                break;
                            default:
                                break;
                        }
                        break;
                    case 3: //Todos

                        switch (TipoPagos)
                        {
                            case 1:

                                Tipag = "POR CAJA";

                                switch (MarInfo)
                                {
                                    case 1: //Muestra Abonos por Pagares

                                        if (string.IsNullOrWhiteSpace(TxtPagaNum.Text))
                                        {
                                            Utils.Informa = "Lo siento pero usted no ha digitado" + "\r";
                                            Utils.Informa += "el numero del pagare a mostrar" + "\r";
                                            MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            return;
                                        }

                                        PN = TxtPagaNum.Text;

                                        Para05 = "[Datos registro de pagares].[NumPaga] = '" + PN + "'";

                                        Utils.Informa = "¿Usted desea mostrar todo los  " + RVal + "\r";
                                        Utils.Informa += "abonos registrados al pagaré ";
                                        Utils.Informa += $"entre el {F0I} y el {F0F}?";

                                        Para010 = Para01 + " and " + Para02 + " and " + Para05 + " and " + Para07;

                                        Utils.infNombreInforme = "Informe pagares abonos por caja";
                                        TxtPagaNum.Clear();

                                        break;
                                    case 2: //Muestra Abonos por Tercero

                                        if (string.IsNullOrWhiteSpace(TxtNumDoTerce.Text))
                                        {
                                            Utils.Informa = "Lo siento pero usted no ha digitado" + "\r";
                                            Utils.Informa += "el numero del pagare a mostrar" + "\r";
                                            MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            return;
                                        }

                                        ND = TxtNumDoTerce.Text;

                                        Para06 = "[Datos registro de pagares].[NumTerPaga] = '" + ND + "'";

                                        Utils.Informa = "¿Usted desea mostrar todo los Abonos " + "\r";
                                        Utils.Informa += "registrados a la historia No. " + ND;
                                        Utils.Informa += $"entre el {F0I} y el {F0F}?";

                                        Para010 = Para01 + " and " + Para02 + " and " + Para06 + " and " + Para07;

                                        Utils.infNombreInforme = "Informe pagares abonos por caja";
                                        TxtNumDoTerce.Clear();

                                        break;
                                    case 3: //Muestra Abonos por Paciente

                                        if (string.IsNullOrWhiteSpace(TxtHistoNum.Text))
                                        {
                                            Utils.Informa = "Lo siento pero usted no ha digitado";
                                            Utils.Informa += "el número de historia del paciente.";
                                        }

                                        ND = TxtHistoNum.Text;

                                        Para08 = "[Datos registro de pagares].HistoriaPaga = " + ND;
                                        Para010 = Para01 + " and " + Para02 + " and " + Para08 + " and " + Para07;

                                        Utils.Informa = "¿Usted desea mostrar todo los Abonos " + RVal + "\r";
                                        Utils.Informa += "registrados a la historia No. " + ND;
                                        Utils.Informa += $"entre el {F0I} y el {F0F}?";

                                        Utils.infNombreInforme = "Informe pagares abonos por caja";
                                        TxtHistoNum.Clear();

                                        break;
                                    case 4: //Muestra Abonos por todos


                                        Para010 = Para01 + " and " + Para02 + " and " + Para07;

                                        Utils.Informa = "¿Usted desea mostrar todo los Abonos" + "\r";
                                        Utils.Informa += "realizados y registrados";
                                        Utils.Informa += $"entre el {F0I} y el {F0F}?";

                                        Utils.infNombreInforme = "Informe pagares abonos por caja";

                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case 2:

                                Tipag = "ELECTRONICOS";

                                switch (MarInfo)
                                {
                                    case 1: //Muestra Abonos por Pagares

                                        if (string.IsNullOrWhiteSpace(TxtPagaNum.Text))
                                        {
                                            Utils.Informa = "Lo siento pero usted no ha digitado" + "\r";
                                            Utils.Informa += "el numero del pagare a mostrar" + "\r";
                                            MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            return;
                                        }

                                        PN = TxtPagaNum.Text;

                                        Para05 = "[Datos registro de pagares].[NumPaga] = '" + PN + "'";

                                        Utils.Informa = "¿Usted desea mostrar todo los " + RVal + "\r";
                                        Utils.Informa += "abonos registrados al pagaré ";
                                        Utils.Informa += $"entre el {F0I} y el {F0F}?";

                                        Para010 = Para03 + " and " + Para04 + " and " + Para05 + " and " + Para07;

                                        Utils.infNombreInforme = "Informe pagares abonos electronicos";
                                        TxtPagaNum.Clear();


                                        break;
                                    case 2: //Muestra Abonos por Tercero
                                        if (string.IsNullOrWhiteSpace(TxtNumDoTerce.Text))
                                        {
                                            Utils.Informa = "Lo siento pero usted no ha digitado" + "\r";
                                            Utils.Informa += "el numero del pagare a mostrar" + "\r";
                                            MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            return;
                                        }

                                        ND = TxtNumDoTerce.Text;

                                        Para06 = "[Datos registro de pagares].[NumTerPaga] = '" + ND + "'";

                                        Utils.Informa = "¿Usted desea mostrar todo los Abonos " + "\r";
                                        Utils.Informa += "registrados a la historia No. " + ND;
                                        Utils.Informa += $"entre el {F0I} y el {F0F}?";

                                        Para010 = Para03 + " and " + Para04 + " and " + Para06 + " and " + Para07;

                                        Utils.infNombreInforme = "Informe pagares abonos electronicos";
                                        TxtNumDoTerce.Clear();

                                        break;
                                    case 3: //Muestra Abonos por Paciente

                                        if (string.IsNullOrWhiteSpace(TxtHistoNum.Text))
                                        {
                                            Utils.Informa = "Lo siento pero usted no ha digitado";
                                            Utils.Informa += "el número de historia del paciente.";
                                        }

                                        ND = TxtHistoNum.Text;

                                        Para08 = "[Datos registro de pagares].HistoriaPaga = " + ND;
                                        Para010 = Para03 + " and " + Para04 + " and " + Para08 + " and " + Para07;

                                        Utils.Informa = "¿Usted desea mostrar todo los Abonos " + RVal + "\r";
                                        Utils.Informa += "registrados a la historia No. " + ND;
                                        Utils.Informa += $"entre el {F0I} y el {F0F}?";

                                        Utils.infNombreInforme = "Informe pagares abonos electronicos";
                                        TxtHistoNum.Clear();

                                        break;
                                    case 4: //Muestra Abonos por todos


                                        Para010 = Para03 + " and " + Para04 + " and " + Para07;

                                        Utils.Informa = "¿Usted desea mostrar todo los Abonos" + "\r";
                                        Utils.Informa += "realizados y registrados";
                                        Utils.Informa += $"entre el {F0I} y el {F0F}?";

                                        Utils.infNombreInforme = "Informe pagares abonos electronicos";

                                        break;
                                    default:
                                        break;
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }

                var res = MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if(res == DialogResult.Yes)
                {
                    Utils.condicion = Para010;
                    FrmReportes frmReportes = new FrmReportes();
                    frmReportes.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error al" + "\r";
                Utils.Informa += "hacer click sobre el botón mostrar" + "\r";
                Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
