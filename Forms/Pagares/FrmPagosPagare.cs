using OBCAJASQL.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OBCAJASQL.Forms.Pagares
{
    public partial class FrmPagosPagare : Form
    {
        public FrmPagosPagare()
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
                    LblCodCajAct.Text = Utils.CodCaja;
                    LblNomCajAct.Text = Utils.NombgPre;
                    TxtCenCajaD.Text = Utils.CenCosCaja;
                    TxtCtaConD.Text = Utils.CuenConta;


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
                Utils.SqlDatos = " SELECT [Datos de los bancos].CodiBanco, [Datos de los bancos].NomBanco FROM [GEOGRAXPSQL].[dbo].[Datos de los bancos] ORDER BY [Datos de los bancos].NomBanco;";

                DataSet dataSet5 = Conexion.SQLDataSet(Utils.SqlDatos);

                if (dataSet5 != null && dataSet5.Tables.Count > 0)
                {
                    this.CboLIstaBancos.DataSource = dataSet5.Tables[0];
                    this.CboLIstaBancos.ValueMember = "CodiBanco";
                    this.CboLIstaBancos.DisplayMember = "NomBanco";
                }

                Utils.SqlDatos = "SELECT [Datos cuentas bancarias].NitBanco, [Datos cuentas bancarias].SucurNitBanco,  " +
                "[Datos cuentas bancarias].CodiBanco, [Datos cuentas bancarias].NumCuenta, " +
                "[Datos cuentas bancarias].CtaActiva FROM [GEOGRAXPSQL].[dbo].[Datos cuentas bancarias] " +
                " WHERE((([Datos cuentas bancarias].CtaActiva) = 'True')) ORDER BY [Datos cuentas bancarias].NumCuenta; ";

                DataSet dataSet4 = Conexion.SQLDataSet(Utils.SqlDatos);

                if (dataSet4 != null && dataSet4.Tables.Count > 0)
                {
                    this.CboCuentasbancarias.DataSource = dataSet4.Tables[0];
                    this.CboCuentasbancarias.ValueMember = "NumCuenta";
                    this.CboCuentasbancarias.DisplayMember = "NitBanco";
                }


                Utils.SqlDatos = " SELECT DISTINCT A.CodCuenta, A.NomCuenta FROM  [BDCAJASQL].[dbo].[Datos cuentas contables] AS A INNER JOIN [BDCAJASQL].[dbo].[Datos cuentas contables] AS B ON A.CodCuenta = B.CodCuenta";

                DataSet dataSet3 = Conexion.SQLDataSet(Utils.SqlDatos);

                if (dataSet3 != null && dataSet3.Tables.Count > 0)
                {
                    this.CboCuentaContaInteres.DataSource = dataSet3.Tables[0];
                    this.CboCuentaContaInteres.ValueMember = "CodCuenta";
                    this.CboCuentaContaInteres.DisplayMember = "NomCuenta";
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


        int FormaPago = 1;
        private void FrmPagosPagare_Load(object sender, EventArgs e)
        {
            try
            {
                CargarDatosUser();
                CargarCombobox();
            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "al cargar el formulario pagos a pagares" + "\r";
                Utils.Informa += "Error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtFacNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((int)e.KeyChar == (int)Keys.Enter)
                {
                    if (string.IsNullOrWhiteSpace(TxtPagaNum.Text) == false)
                    {

                        string f = "", Enrutadatos = "", Sql2 = "", TDRes = "", NDRes = "", TDCodeu = "", NDCodeu = "", TNP = "";
                        DialogResult res;

                        f = TxtPagaNum.Text;

                        Utils.Titulo01 = "Control para mostrar datos";

                        string Sql1 = "SELECT * FROM [BDCAJASQL].[dbo].[Datos registro de pagares] WHERE NumPaga='" + f + "' ORDER BY NumPaga ";




                        using (SqlConnection connection = new SqlConnection(Conexion.conexionSQL))
                        {
                            SqlCommand command = new SqlCommand(Sql1, connection);
                            command.Connection.Open();
                            SqlDataReader Rst1 = command.ExecuteReader();


                            if(Rst1.HasRows == false)
                            {
                                Utils.Informa = "Lo siento pero el número del pagare o letra" + "\r";
                                Utils.Informa += "digitado no existe en este sistema." + "\r";
                                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                //Muestre los datos del pagaré encontrado
                                Rst1.Read();

                                if (Convert.ToBoolean(Rst1["AnuladoRecibo"]) == true)
                                {
                                    Utils.Informa = "Lo siento pero el número del pagare o letra " + "\r";
                                    Utils.Informa += "Nro. " + f + " digitado se encuentra anulado." + "\r";
                                    Utils.Informa += "Por tanto no se pueden registrar pagos." + "\r";
                                    Utils.Informa += "Por favor presione la tecla Esc para anular la entrada." + "\r";
                                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                else
                                {
                                    TxtHisPaga.Text = Rst1["HistoriaPaga"].ToString();
                                    TxtNomUsua.Text = Rst1["NomUsaR"].ToString();
                                    TxtValTolPaga.Text = Rst1["ValorPaga"].ToString();
                                    DtVenPaga.Value =  Convert.ToDateTime(Rst1["FecVenPaga"].ToString());
                                    TxtTDR.Text = Rst1["TDRespon"].ToString();
                                    TxtNDR.Text = Rst1["NumTerPaga"].ToString();
                                    TDRes = Rst1["TDRespon"].ToString();
                                    NDRes = Rst1["NumTerPaga"].ToString();

                                    TxtCtaConta.Text = Rst1["CuentaConta"].ToString();
                                    TxtTDC.Text = Rst1["TDCodeudor"].ToString();
                                    TxtNDC.Text = Rst1["CodeuPaga"].ToString();

                                    TxtTolAbo.Text = Rst1["PagoPaga"].ToString();

                                    double s = Convert.ToDouble(Rst1["ValorPaga"]) - Convert.ToDouble(Rst1["PagoPaga"]);

                                    TxtSalPaga.Text = s.ToString();

                                    if (String.IsNullOrWhiteSpace(TxtNDC.Text))
                                    {
                                        //no busca nda
                                    }
                                    else
                                    {
                                        if (string.IsNullOrWhiteSpace(TxtNDC.Text))
                                        {
                                            //El pagaré se registró sin codeudor
                                        }
                                        else
                                        {
                                            //Proceda a buscar el nombre del codeudor
                                            TDCodeu = Rst1["TDCodeudor"].ToString();
                                            NDCodeu = Rst1["CodeuPaga"].ToString();

                                            Sql2 = "SELECT * FROM [BDCAJASQL].[dbo].[Datos terceros] WHERE TipoDocu='" + TDCodeu + "' AND NumDocu='" + NDCodeu + "' ORDER BY TipoDocu";

                                            using (SqlConnection connection2 = new SqlConnection(Conexion.conexionSQL))
                                            {
                                                SqlCommand command2 = new SqlCommand(Sql2, connection2);
                                                command2.Connection.Open();
                                                SqlDataReader Rst2 = command2.ExecuteReader();

                                                if (Rst2.HasRows == false)
                                                {
                                                    //no se encontró el nombre del codeudor
                                                    TxtNCC.Text = "";
                                                }
                                                else
                                                {
                                                    Rst2.Read();
                                                    TxtNCC.Text = Rst2["NomAdmin"].ToString();
                                                }


                                            }

                                        }
                                    }

                                }

                            }
                        }

                        Sql2 = "SELECT * FROM [BDCAJASQL].[dbo].[Datos terceros] WHERE TipoDocu='" + TDRes + "' AND NumDocu='" + NDRes + "' ORDER BY TipoDocu";


                        using (SqlConnection connection = new SqlConnection(Conexion.conexionSQL))
                        {
                            SqlCommand command = new SqlCommand(Sql2, connection);
                            command.Connection.Open();
                            SqlDataReader Rst2 = command.ExecuteReader();

                            if(Rst2.HasRows == false)
                            {
                                //no se encontró el nombre del responsable
                                TxtNCR.Text = "";

                            }
                            else
                            {
                                Rst2.Read();
                                TxtNCR.Text = Rst2["NomAdmin"].ToString();      
                            }

                        }


                        string Sql3 = "SELECT * FROM [BDCAJASQL].[dbo].[Datos registro cuotas pagares] WHERE NumPaga='" + f + "' ORDER BY NumPaga";

                        using (SqlConnection connection = new SqlConnection(Conexion.conexionSQL))
                        {
                            SqlCommand command = new SqlCommand(Sql3, connection);
                            command.Connection.Open();
                            SqlDataReader Rst3 = command.ExecuteReader();

                            if(Rst3.HasRows == false)
                            {
                                Utils.Informa = "Lo siento pero el pagare digitado, no " + "\r";
                                Utils.Informa += "tiene las cuotas de pagos registradas." + "\r";
                                Utils.Informa += "Por favor comunicarle este problema" + "\r";
                                Utils.Informa += "al administrador del sistema." + "\r";
                                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            else
                            {

                                double ValCuota = 0, ValPagado = 0, DesVarios = 0, DesComi = 0, ValInteres = 0, ValInMora = 0, ValorPaga = 0;
                                string FecVenCuota, date;
                                DateTime FecVenCuotaDate, dateD;
                                GridDetaCuotas.Rows.Clear();

                                while (Rst3.Read())
                                {

                                    ValCuota = Convert.ToDouble(Rst3["ValCuota"]);
                                    ValPagado = Convert.ToDouble(Rst3["ValPagado"]);
                                    DesVarios = Convert.ToDouble(Rst3["DesVarios"]);
                                    DesComi = Convert.ToDouble(Rst3["DesComi"]);
                                    FecVenCuota = Convert.ToDateTime(Rst3["FecVenCuota"]).ToString("dd-MM-yyyy");
                                    date = DateTime.Now.Date.ToString("dd-MM-yyyy");
                                    FecVenCuotaDate = Convert.ToDateTime(FecVenCuota);
                                    dateD = Convert.ToDateTime(date);

                                    ValorPaga = ValCuota - (DesComi + DesVarios + ValPagado);


                                    if (ValCuota > (ValPagado + DesComi + DesVarios))
                                    {
                                        //Copiela porque aún no se ha pagado

                                        ValInteres = ((ValCuota * Convert.ToDouble(Rst3["IntAplicado"])) / 100);


                                        if (FecVenCuotaDate < dateD)
                                        {
                                            //Cuando la cuota pasa de la fecha de pago cobre interes de mora
                                           ValInMora = ((ValCuota * Convert.ToDouble(Rst3["InterMora"])) / 100);

                                           GridDetaCuotas.Rows.Add(Rst3["CuoPaga"].ToString(), Rst3["ValCuota"].ToString(), ValInteres, Rst3["IntAplicado"].ToString(),  Rst3["InterMora"].ToString(), ValInMora, Rst3["FecVenCuota"].ToString(), Rst3["DesComi"].ToString(), Rst3["DesVarios"].ToString(), Rst3["ValPagado"].ToString(), ValorPaga);

                                        }
                                        else
                                        {

                                            GridDetaCuotas.Rows.Add(Rst3["CuoPaga"].ToString(), Rst3["ValCuota"].ToString(), ValInteres, Rst3["IntAplicado"].ToString(), 0, 0, Rst3["FecVenCuota"].ToString(), Rst3["DesComi"].ToString(), Rst3["DesVarios"].ToString(), Rst3["ValPagado"].ToString(), ValorPaga);

                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Utils.Titulo01 = "Control de ejecución";
                        Utils.Informa = "Lo siento pero este campo no puede" + "\r";
                        Utils.Informa += "contener un valor nulo o vacío" + "\r";
                        Utils.Informa += "Por favor corrija el número" + "\r";
                        MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "antes de actualizar el número el numero del pagare." + "\r";
                Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RbEfect_CheckedChanged(object sender, EventArgs e)
        {
            FormaPago = 1;
            CboLIstaBancos.Visible = false;
            TxtNumDocumentoP.Visible = false;
            LblTextFechaconsinacion.Visible = false;
            DtFeconsigelectro.Visible = false;
            LblNuncuenban.Visible = false;
            CboCuentasbancarias.Visible = false;
            TxtCenCajaD.Text = "111";
            TxtCtaConD.Text = "110501";
        }

        private void RbCheque_CheckedChanged(object sender, EventArgs e)
        {
            FormaPago = 2;
            CboLIstaBancos.Visible = true;
            TxtNumDocumentoP.Visible = true;
            LblDocumentoPago.Text = "Cheque No:";
            LblTextFechaconsinacion.Visible = false;
            DtFeconsigelectro.Visible = false;
            LblNuncuenban.Visible = false;
            CboCuentasbancarias.Visible = false;
            TxtCenCajaD.Text = "111";
            TxtCtaConD.Text = "110501";
        }

        private void RbTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            FormaPago = 3;
            CboLIstaBancos.Visible = true;
            TxtNumDocumentoP.Visible = true;
            LblDocumentoPago.Text = "Recibo No:";
            LblTextFechaconsinacion.Visible = false;
            DtFeconsigelectro.Visible = false;
            LblNuncuenban.Visible = false;
            CboCuentasbancarias.Visible = false;
            TxtCenCajaD.Text = "112";
            TxtCtaConD.Text = "112005";
        }

        private void RbBonos_CheckedChanged(object sender, EventArgs e)
        {
            FormaPago = 4;
            CboLIstaBancos.Visible = false;
            TxtNumDocumentoP.Visible = false;
            LblDocumentoPago.Text = "";
            LblTextFechaconsinacion.Visible = false;
            DtFeconsigelectro.Visible = false;
            LblNuncuenban.Visible = false;
            CboCuentasbancarias.Visible = false;
            TxtCenCajaD.Text = "112";
            TxtCtaConD.Text = "112005";
        }

        private void RbConFac_CheckedChanged(object sender, EventArgs e)
        {
            FormaPago = 5;
            CboLIstaBancos.Visible = true;
            TxtNumDocumentoP.Visible = true;
            LblDocumentoPago.Text = "Consignación No:";
            LblTextFechaconsinacion.Visible = true;
            LblTextFechaconsinacion.Text = "F Consigna";
            DtFeconsigelectro.Visible = true;
            LblNuncuenban.Visible = true;
            CboCuentasbancarias.Visible = true;
            TxtCenCajaD.Text = "112";
            TxtCtaConD.Text = "112005";
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void CboCuentaContaInteres_KeyPress(object sender, KeyPressEventArgs e)
        {
            CboCuentaContaInteres.DroppedDown = false;
        }

        private void CboLIstaBancos_KeyPress(object sender, KeyPressEventArgs e)
        {
            CboLIstaBancos.DroppedDown = false;
        }

        private void BtnRegistraCaja_Click(object sender, EventArgs e)
        {
            try
            {

                string UsReci = "", SqlPagoelectro = "", Sql5 = "", Sql4 = "",  FunPagoElectro = "", Sql2 = "", FechaPago = "", FunReciNum = "", Cuentabanca = "", CodCa = "", Tipag = "", NumEnti = "", Enti = "", NPcan = "", FormPa = "", C = "", Descri2 = "", Cuencaja = "", CenCaja = "", Descri3 = "", Descri1 = "";
                double VP = 0, VCuot = 0, VIF = 0, VIM = 0, DCom = 0, DesVA = 0, ValDePa = 0;
                int N = 1, RDt = 1;
                Utils.Titulo01 = "Control para registrar pagos a pagarés";
                DialogResult res;
                UsReci = lblCodigoUser.Text;

                if (string.IsNullOrWhiteSpace(LblCodCajAct.Text))
                {
                    Utils.Informa = "Lo siento pero mientras no se tenga" + "\r";
                    Utils.Informa += "definida la identificación de la caja," + "\r";
                    Utils.Informa += "no se puede realizar este proceso.";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LblCodCajAct.Select();
                    return;
                }

                CodCa = LblCodCajAct.Text;

                ////Revisamos si se seleccionó el número del pagaré

                if (string.IsNullOrWhiteSpace(TxtPagaNum.Text))
                {
                    Utils.Informa = "Lo siento pero usted no ha digitado el número" + "\r";
                    Utils.Informa += "del pagaré o letra de cambio a pagare" + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TxtPagaNum.Select();
                    return;
                }

                NPcan = TxtPagaNum.Text;

                //revisamos si el saldo es mayor a cero

                if(Convert.ToDouble(TxtSalPaga.Text) <= 0)
                {
                    Utils.Informa = "Lo siento pero el saldo del pagaré es cero (0)" + "\r";
                    Utils.Informa += "por tanto ya no hay nada para cancelar." + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TxtSalPaga.Select();
                    return;
                }

                //Revisamos si el usuario tiene jerarquía para hacer el registro

                if(Convert.ToDouble(lblNivelPermitido.Text) <= 0)
                {
                    Utils.Informa = "Lo siento pero el registro del usuario" + "\r";
                    Utils.Informa += "no es válido, por tanto no puede realizar" + "\r";
                    Utils.Informa += "el registro de este pago." + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lblNivelPermitido.Select();
                    return;
                }

               
                if(GridDetaCuotas.SelectedRows.Count < 0)
                {
                    Utils.Informa = "Lo siento pero no ha seleccionado" + "\r";
                    Utils.Informa += "una cuota para realizar el pago" + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //Revisamos si hay una cuota para pagar

                C = GridDetaCuotas.SelectedCells[0].Value.ToString();

                    //revisamos si existe un valor de pago en la cuota seleccionada

                VP = Convert.ToDouble(GridDetaCuotas.SelectedCells[10].Value.ToString());

                if(VP <= 0)
                {
                    Utils.Informa = "Lo siento pero el valor a cancelar no" + "\r";
                    Utils.Informa += "puede ser menor o igual a cero (0)" + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                N = 1;

                VCuot = Convert.ToDouble(GridDetaCuotas.SelectedCells[1].Value.ToString());

                Utils.Informa = "¿Usted desea registrar el pago de la cuota " + C + "\r";
                Utils.Informa += "del pagaré " + NPcan + " por valor de " + VCuot + "?." + "\r";
                Utils.Informa += "Valor a cancelar:  " + VP;

                //Tomamos los intereses de financiación

                VIF = Convert.ToDouble(GridDetaCuotas.SelectedCells[3].Value.ToString());

                if(VIF > 0)
                {
                    //revisamos si seleccionó el número de la cuenta de intereses
                    if(CboCuentaContaInteres.SelectedIndex == -1)
                    {
                        Utils.Informa = "Lo siento pero usted no ha seleccionado" + "\r";
                        Utils.Informa += "el número de cuenta contable de los" + "\r";
                        Utils.Informa += "interes de financiación." + "\r";
                        MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    N += 1;
                    Descri2 = "Pago intereses de financiacion";
                    Utils.Informa += "interes de financiación." + VIF + "\r";
                }


                //Tomamos los intereses de mora

                VIM = Convert.ToDouble(GridDetaCuotas.SelectedCells[5].Value.ToString());

                if (VIM > 0)
                {
                    Utils.Informa += "Intereses de mora:  " + VIM + "\r";

                    if (CboCuentaContaInteres.SelectedIndex == -1)
                    {
                        Utils.Informa = "Lo siento pero usted no ha seleccionado" + "\r";
                        Utils.Informa += "el número de cuenta contable de los" + "\r";
                        Utils.Informa += "interes de financiación." + "\r";
                        MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    N += 1;
                    Descri3 = "Pago intereses de mora";
                    Utils.Informa += "interes de financiación." + VIM + "\r";

                }


                //Descuentos por comisión

                DCom = Convert.ToDouble(GridDetaCuotas.SelectedCells[7].Value.ToString());

                if(DCom > 0)
                {
                    Utils.Informa += "Descuentos por comisión: " + DCom;
                }

                //Descuentos varios


                DesVA = Convert.ToDouble(GridDetaCuotas.SelectedCells[8].Value.ToString());

                if(DesVA  > 0)
                {
                    Utils.Informa += "Descuentos especial: " + DesVA;
                }

                //Revisamos si la persona hace un abono o pago total  a la cuota del pagaré

                if(VCuot - (DCom + DesVA) == VP)
                {
                    //el pago es total
                    Descri1 = "Pago total cuota No: " + C + " del Dcto" + NPcan;

                }
                else
                {
                    Descri1 = "Abono a la cuota No: " + C + " del Dcto" + NPcan;
                }

                Cuencaja = TxtCenCajaD.Text;
                CenCaja = TxtCenCajaD.Text;

                //Revisemos la forma de pago

                switch (FormaPago)
                {

                    case 1: //Pago en efectivo

                        FormPa = "Pago en efectivo";
                        Enti = "";
                        NumEnti = "";
                        Tipag = "EF";

                        break;
                    case 2: //Pago en cheque

                        if(CboLIstaBancos.SelectedIndex == -1)
                        {
                            Utils.Informa = "Lo siendo pero usted no ha digitado el";
                            Utils.Informa += "nombre del banco del cheque recibido";
                            CboLIstaBancos.Select();
                            return;
                        }

                        //Revisamos si digitó el número del cheque

                        if (string.IsNullOrWhiteSpace(TxtNumDocumentoP.Text))
                        {
                            Utils.Informa = "Lo siento pero usted no ha digitado";
                            Utils.Informa += "el número del cheque recibido.";
                            TxtNumDocumentoP.Select();
                            return;
                        }

                        FormPa = "Pago con cheque del " + CboLIstaBancos.SelectedValue.ToString();
                        Enti = CboLIstaBancos.Text;
                        NumEnti = TxtNumDocumentoP.Text;
                        Tipag = "CH";

                        break;
                    case 3: //Tarjeta de credito
                        //Revise si selecciono el nombre del banco de la tarjeta


                        if(CboLIstaBancos.SelectedIndex == -1)
                        {
                            Utils.Informa = "Lo siento pero usted no ha digitado el nombre";
                            Utils.Informa += "de la entidad de la tarjeta de crédito.";
                            MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (string.IsNullOrWhiteSpace(TxtNumDocumentoP.Text))
                        {
                            Utils.Informa = "Lo siento pero usted no ha digitado el número";
                            Utils.Informa += "el recibo de pago de la tarjeta.";
                            TxtNumDocumentoP.Select();
                            return;
                        }

                        FormPa = "Pago con tarjeta de credito " + CboLIstaBancos.Text;
                        Enti = CboLIstaBancos.SelectedValue.ToString();
                        NumEnti = TxtNumDocumentoP.Text;
                        Tipag = "TC";


                        break;

                    case 4: //Pago en bonos


                        FormPa = "Pago con bonos";
                        Enti = null;
                        NumEnti = null;
                        Tipag = "BO";
                      
                        break;
                    case 5: //Pago por consignacion electronica
                        

                        if(lblNivelPermitido.Text == "1")
                        {

                        }
                        else
                        {
                            Utils.Informa = "Lo siento pero usted no tiene permiso" + "\r";
                            Utils.Informa += "para afectar pagos a pagares por " + "\r";
                            Utils.Informa += "para afectar pagos a pagares por " + "\r";
                            Utils.Informa += "para afectar pagos a pagares por " + "\r";
                            MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if(CboLIstaBancos.SelectedIndex == -1)
                        {
                            Utils.Informa = "Lo siento pero usted no ha digitado el" + "\r";
                            Utils.Informa += "nombre del banco donde consigna." + "\r";
                            MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }


                        //Revisamos si digito el numero del cheque

                        if (string.IsNullOrWhiteSpace(TxtNumDocumentoP.Text))
                        {
                            Utils.Informa = "Lo siento pero usted no ha digitado el" + "\r";
                            Utils.Informa += "el número de la consignación." + "\r";
                            MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if(CboCuentasbancarias.SelectedIndex == -1)
                        {
                            Utils.Informa = "Lo siento pero usted no ha ingresado" + "\r";
                            Utils.Informa += "el número de la cuenta bancaria." + "\r";
                            MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        FormPa = "Pago electronico de " + CboLIstaBancos.Text;
                        Enti = CboLIstaBancos.SelectedValue.ToString();
                        NumEnti = TxtNumDocumentoP.Text;
                        Tipag = "PE"; //Pago electronico
                        Cuentabanca = CboCuentasbancarias.SelectedValue.ToString();
                        FechaPago = DtFeconsigelectro.Value.ToString("dd-MM-yyyy");



                        break;


                    default:
                        return;
                }

                res = MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (res == DialogResult.Yes)
                {

                    if (Tipag != "PE")
                    {

                        //Procedemos a buscar el consecutivo de recibos de caja


                        FunReciNum = ConseReciCaja(1, UsReci, CodCa);

                        switch (FunReciNum)
                        {
                            case "-3": //Consecutivo fuera del rango
                                Utils.Informa = "Lo siento pero el  número  consecutivo de" + "\r";
                                Utils.Informa += "recibos de caja llegó al limite aceptado," + ".?" + "\r";
                                Utils.Informa += "favor comunicarse con el area de sistemas" + "\r";
                                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            case "-2": //Fecha menor a la última generada
                                Utils.Informa = "Lo siento pero la fecha del sistema es menor" + "\r";
                                Utils.Informa += "a la fecha del último recibo generado. " + ".?" + "\r";
                                Utils.Informa += "Favor comunicarse con el area de sistemas" + "\r";
                                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            case "-1": //Error en la funcion
                                return;
                            case "0": //No se encontró el registro de contadores
                                Utils.Informa = "Lo siento pero no  fue  posible  encontrar" + "\r";
                                Utils.Informa += "el registro único de la tabla contadores. " + ".?" + "\r";
                                Utils.Informa += "favor comunicarse con el area de sistemas" + "\r";
                                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            default:
                                //Puede seguir con el proceso
                                break;
                        }


                        Sql2 = "SELECT * FROM [BDCAJASQL].[dbo].[Datos recibos de caja] ";
                        Sql2 = Sql2 + "WHERE ReciboCaja = '" + FunReciNum + "' ";
                        Sql2 = Sql2 + "ORDER BY ReciboCaja";


                        int proce = 0;

                        using (SqlConnection connection = new SqlConnection(Conexion.conexionSQL))
                        {
                            SqlCommand command = new SqlCommand(Sql2, connection);
                            command.Connection.Open();
                            SqlDataReader TabReciCaja = command.ExecuteReader();

                            if (TabReciCaja.HasRows == false)
                            {
                                //Puede agregar tranquilamente el recibo, porque no existe
                                proce = 1;
                            }

                        }

                        if (proce == 1)
                        {
                            Utils.SqlDatos = "INSERT INTO [BDCAJASQL].[dbo].[Datos recibos de caja]" +
                            "(" +
                            "ReciboCaja," +
                            "CodCaja," +
                            "HistorPaciente," +
                            "TipoDocu," +
                            "NumDocu," +
                            "CardiNitCC," +
                            "TipDocu," +
                            "DocuCruce," +
                            "TipoPagoCaja," +
                            "DocumNumero," +
                            "EntidadDocumen," +
                            "FechaPagoCaja," +
                            "TipoPago," +
                            "ElPagoEsPor," +
                            "FecRegis," +
                            "CodRegis" +
                            ")" +
                            "VALUES" +
                            "(" +
                            "'" + FunReciNum + "'," +
                            "'" + CodCa + "'," +
                            "'" + TxtHisPaga.Text + "'," +
                            "'" + TxtTDR.Text + "'," +
                            "'" + TxtNDR.Text + "'," +
                            "'" + "0001" + "'," + //Cardinal del particular
                            "'" + "3" + "'," + //Tipo de documento de cruce
                            "'" + NPcan + "'," +
                            "'" + Tipag + "'," +
                            "'" + NumEnti + "'," +
                            "'" + Enti + "'," +
                            $"{Conexion.ValidarFechaNula(DateTime.Now.ToString("yyyy-MM-dd"))}" +
                            "'" + "4" + "'," +
                            "'" + "Pago total" + "'," +
                            $"{Conexion.ValidarFechaNula(DateTime.Now.ToString("yyyy-MM-dd"))}" +
                            "'" + UsReci + "'" +
                            ")";

                            bool estaRegis = Conexion.SqlInsert(Utils.SqlDatos);

                            //Proceda a hacer el registro del detalle del recibo de pago

                            RDt = 1;

                            //Siga a grabar el detalle



                            List<SqlParameter> parameters = new List<SqlParameter>();


                            Utils.SqlDatos = "INSERT [BDCAJASQL].[dbo].[Datos detalles recibos de caja] (ReciboNum,CodServi,CentroCosto,CantidadCaja,NatuMovi,DebiCaja,CuentaContable,DetaPagoCaja,ValorUnitaCaja,PorcenPago) ";
                            Utils.SqlDatos += "VALUES (@ReciboNum,@CodServi,@CentroCosto,@CantidadCaja,@NatuMovi,@DebiCaja,@CuentaContable,@DetaPagoCaja,@ValorUnitaCaja,@PorcenPago)";

                            parameters = new List<SqlParameter>
                            {
                                            new SqlParameter("@ReciboNum", SqlDbType.VarChar){ Value = FunReciNum},
                                            new SqlParameter("@CodServi", SqlDbType.VarChar){ Value = "0"},
                                            new SqlParameter("@CentroCosto", SqlDbType.VarChar){ Value = TxtCenCosto.Text},
                                            new SqlParameter("@CantidadCaja", SqlDbType.VarChar){ Value = 1},
                                            new SqlParameter("@NatuMovi", SqlDbType.VarChar){ Value = "C"},
                                            new SqlParameter("@DebiCaja", SqlDbType.VarChar){ Value = 0},
                            };


                            for (int i = 0; i < N; i++)
                            {
                                switch (RDt)
                                {
                                    case 1: //El registro de la cuota

                                        parameters.Add(new SqlParameter("@CuentaContable", SqlDbType.VarChar) { Value = TxtCtaConta.Text });
                                        parameters.Add(new SqlParameter("@DetaPagoCaja", SqlDbType.VarChar) { Value = Descri1 });
                                        parameters.Add(new SqlParameter("@ValorUnitaCaja", SqlDbType.VarChar) { Value = VP });
                                        parameters.Add(new SqlParameter("@PorcenPago", SqlDbType.VarChar) { Value = (100 * (VP / 100)) });


                                        break;
                                    case 2: //Es el registro de los intereses de financiación

                                        parameters = new List<SqlParameter>
                                        {
                                            new SqlParameter("@CuentaContable", SqlDbType.VarChar){ Value = CboCuentaContaInteres.SelectedValue.ToString()},
                                            new SqlParameter("@DetaPagoCaja", SqlDbType.VarChar){ Value = Descri2},
                                            new SqlParameter("@ValorUnitaCaja", SqlDbType.VarChar){ Value = VIF},
                                            new SqlParameter("@PorcenPago", SqlDbType.VarChar){ Value = GridDetaCuotas.SelectedCells[2].Value.ToString() },
                                        };


                                        break;
                                    case 3: //Es el registro de los intereses de mora

                                        parameters = new List<SqlParameter>
                                        {
                                            new SqlParameter("@CuentaContable", SqlDbType.VarChar){ Value = CboCuentaContaInteres.SelectedValue.ToString()},
                                            new SqlParameter("@DetaPagoCaja", SqlDbType.VarChar){ Value = Descri3},
                                            new SqlParameter("@ValorUnitaCaja", SqlDbType.VarChar){ Value = VIM},
                                            new SqlParameter("@PorcenPago", SqlDbType.VarChar){ Value =  GridDetaCuotas.SelectedCells[4].Value.ToString() },
                                        };



                                        break;

                                    default:
                                        break;
                                }

                                ValDePa += VP;
                                RDt += 1;

                                Conexion.SqlInsert(Utils.SqlDatos, parameters);

                            }




                            if (ValDePa > 0)
                            {
                                //Pasamos a grabar el debito

                                Utils.SqlDatos = "INSERT [BDCAJASQL].[dbo].[Datos detalles recibos de caja] (ReciboNum,CuentaContable,DetaPagoCaja,CentroCosto,CantidadCaja,PorcenPago,ValorUnitaCaja,NatuMovi,DebiCaja) ";
                                Utils.SqlDatos += "VALUES (@ReciboNum,@CuentaContable,@DetaPagoCaja,@CentroCosto,@CantidadCaja,@PorcenPago,@ValorUnitaCaja,@NatuMovi,@DebiCaja)";

                                parameters = null;

                                parameters = new List<SqlParameter>
                                {
                                    new SqlParameter("@ReciboNum", SqlDbType.VarChar){ Value = FunReciNum},
                                    new SqlParameter("@CuentaContable", SqlDbType.VarChar){ Value = Cuencaja},
                                    new SqlParameter("@DetaPagoCaja", SqlDbType.VarChar){ Value = "Pago a cuotas de pagarés"},
                                    new SqlParameter("@CentroCosto", SqlDbType.VarChar){ Value = CenCaja},
                                    new SqlParameter("@CantidadCaja", SqlDbType.VarChar){ Value = 1},
                                    new SqlParameter("@PorcenPago", SqlDbType.VarChar){ Value = 100},
                                    new SqlParameter("@ValorUnitaCaja", SqlDbType.VarChar){ Value = 0},
                                    new SqlParameter("@NatuMovi", SqlDbType.VarChar){ Value = "D"},
                                    new SqlParameter("@DebiCaja", SqlDbType.VarChar){ Value = ValDePa},
                                };

                                Conexion.SqlInsert(Utils.SqlDatos, parameters);
                            }

                            //Proceda a expedir el recibo de caja respectivo

                            Utils.infNombreInforme = "Informe recibos de cajas preformateado";

                        }
                        else
                        {
                            //no agrega recibo porque existe
                        }

                    }
                    else
                    {
                        Utils.Informa = "Realmente desea afectar el pagare " + NPcan + "\r";
                        Utils.Informa += "Mediante pago electrónico?. " + "\r";
                        res = MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (res == DialogResult.Yes)
                        {
                            //Afecta tabla pagos electronicos
                            FunPagoElectro = ConseElecPagoPagare(UsReci);

                            switch (FunPagoElectro)
                            {

                                case "-3": //Consecutivo fuera de rango

                                    Utils.Informa = "Lo siento pero el  número  consecutivo de pagos" + "\r";
                                    Utils.Informa += "electroncios de caja llegó al limite aceptado," + "\r";
                                    Utils.Informa += "Favor comunicarse con el area de sistemas" + "\r";
                                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                    return;
                                case "-1": //Error en la función
                                    return;
                                case "0": //No se encontro el resitro de contadores

                                    Utils.Informa = "Lo siento pero no  fue  posible  encontrar" + "\r";
                                    Utils.Informa += "el registro único de la tabla contadores." + "\r";
                                    Utils.Informa += "Favor comunicarse con el area de sistemas" + "\r";
                                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                default:
                                    //Puede seguir con el proceso
                                    break;
                            }

                            Utils.SqlDatos = "INSERT INTO [BDCAJASQL].[dbo].[Datos abonos electronicos a pagares]" +
                            "(" +
                            "ConseConsig_Elect," +
                            "NumPagare_Elect," +
                            "TipoPago_Elect," +
                            "CuotaNumPa_Elect," +
                            "NumConsig_Elect," +
                            "EntidConsig_Elect," +
                            "Cuenconsig_Elect," +
                            "ValPago_Elect," +
                            "FecConsig_Elect," +
                            "Descripcion_Elect," +
                            "FecRegis_Elect," +
                            "CodRegis_Elect" +
                            ")" +
                            "VALUES" +
                            "(" +
                            "'" + FunPagoElectro + "'," +
                            "'" + NPcan + "'," +
                            "'" + Tipag + "'," +
                            "'" + C + "'," +
                            "'" + TxtNumDocumentoP.Text + "'," +
                            "'" + Enti + "'," + //Cardinal del particular
                            "'" + CboCuentasbancarias.SelectedValue.ToString() + "'," + //Tipo de documento de cruce
                            "'" + VP + "'," +
                            $"{Conexion.ValidarFechaNula(DtFeconsigelectro.Value.ToString("yyyy-MM-dd"))}" +
                            "'" + NumEnti + "'," +
                            "'" + Enti + "'," +
                            $"{Conexion.ValidarFechaNula(DateTime.Now.ToString("yyyy-MM-dd"))}" +
                            "'" + Descri1 + "'," +
                            $"{Conexion.ValidarFechaNula(DateTime.Now.ToString("yyyy-MM-dd"))}" +
                            "'" + UsReci + "'" +
                            ")";

                            bool estaRegis = Conexion.SqlInsert(Utils.SqlDatos);

                            if (estaRegis)
                            {
                                Utils.Informa = "El pago electrónico al pagaré, fue " + "\r";
                                Utils.Informa += "Registrado satisfactoriamente." + "\r";
                                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }


                        }

                    }//Fin Tipo Pago
                }


                //Proceda a afectar el pago del pagaré
                double ValCancecuota = 0, SalAcul = 0;

                if (res == DialogResult.Yes)
                {

                    Sql4 = "SELECT * FROM [BDCAJASQL].[dbo].[Datos registro de pagares] WHERE NumPaga='" + NPcan + "' ORDER BY NumPaga";

                    using (SqlConnection connection3 = new SqlConnection(Conexion.conexionSQL))
                    {
                        SqlCommand command3 = new SqlCommand(Sql4, connection3);
                        command3.Connection.Open();
                        SqlDataReader Rst4 = command3.ExecuteReader();

                        if(Rst4.HasRows == false)
                        {
                            Utils.Informa = "Lo siento pero el pago no se puede afectar, no existe ," + "\r";
                            Utils.Informa += "el pagare o la cuota a pagar no es valida. " + "\r";
                            Utils.Informa += "Por favor verifique la información";
                            MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            Rst4.Read();
                            //Antes de afectar el pago en el registro principal, hagalo en el detalle

                            Sql5 = "SELECT * FROM [BDCAJASQL].[dbo].[Datos registro cuotas pagares] WHERE NumPaga='" + NPcan + "' AND CuoPaga='" + C + "' ORDER BY NumPaga";

                            DataTable Rst5 = Conexion.SQLDataTable(Sql5);

                            if(Rst5.Rows.Count < 0)
                            {
                                Utils.Informa = "Lo siento pero el número de la cuota" + "\r";
                                Utils.Informa += "a cancelar no se pudo encontrar " + "\r";
                                Utils.Informa += "en el sistema. ";
                                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                foreach (DataRow row in Rst5.Rows)
                                {
                                    ValCancecuota =  Convert.ToDouble(row["ValPagado"]);
                                }

                                Utils.SqlDatos = "UPDATE [BDCAJASQL].[dbo].[Datos registro cuotas pagares] SET " +
                                      "IntAplicado = '" + GridDetaCuotas.SelectedCells[2].Value.ToString() + "'," +
                                      "ValInteres = '" + VIF + "'," +
                                      "InterMora = '" + GridDetaCuotas.SelectedCells[4].Value.ToString() + "'," +
                                      "ValInMora = '" + VIM + "'," +
                                      "DesComi = '" + GridDetaCuotas.SelectedCells[7].Value.ToString() + "'," +
                                      "DesVarios = '" + GridDetaCuotas.SelectedCells[8].Value.ToString() + "'," +
                                      "ValPagado = '" + ValCancecuota + VP + "'," +
                                      $"FecPaCuota = {Conexion.ValidarFechaNula(DateTime.Now.Date.ToString("yyyy-MM-dd"))}" +
                                      $"FecModi = {Conexion.ValidarFechaNula(DateTime.Now.Date.ToString("yyyy-MM-dd"))}" +
                                      "CodModi = '" + UsReci + "'" +
                                      "WHERE NumPaga='" + NPcan + "' AND CuoPaga='" + C + "' ";

                                Conexion.SQLUpdate(Utils.SqlDatos);

                                //Proceda a afectar el pago principal

                                SalAcul = Convert.ToDouble(Rst4["PagoPaga"]) + VP + Convert.ToDouble(GridDetaCuotas.SelectedCells[7].Value.ToString()) + Convert.ToDouble(GridDetaCuotas.SelectedCells[8].Value.ToString());

                                Utils.SqlDatos = "UPDATE [BDCAJASQL].[dbo].[Datos registro de pagares] SET PagoPaga = '" + SalAcul + "', FecCanPaga = Convert(Datetime,'" + DateTime.Now.Date.ToString("yyyy-MM-dd") + "', 102) " +
                                "WHERE NumPaga='" + NPcan + "' ";

                                Conexion.SQLUpdate(Utils.SqlDatos);

                                TxtTolAbo.Text = SalAcul.ToString();
                                TxtSalPaga.Text = (Convert.ToDouble(TxtValTolPaga.Text) - SalAcul).ToString();


                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "al registrar el pago." + "\r";
                Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private string ConseElecPagoPagare(string UsReci)
        {
            try
            {
                string Convertido = "";
                string SqlCaja = "SELECT * FROM [BDCAJASQL].[dbo].[Datos consecutivos generales] ";
                double Caj = 0;
                using (SqlConnection connection3 = new SqlConnection(Conexion.conexionSQL))
                {
                    SqlCommand command3 = new SqlCommand(SqlCaja, connection3);
                    command3.Connection.Open();
                    SqlDataReader RstCaja = command3.ExecuteReader();

                    if(RstCaja.HasRows == false)
                    {
                        return "0";
                    }
                    else
                    {
                        RstCaja.Read();

                        Caj = Convert.ToDouble(RstCaja["Conse_ElecPag"]);
                        Caj += 1;

                        Utils.SqlDatos = "UPDATE [BDCAJASQL].[dbo].[Datos consecutivos generales] SET Conse_ElecPag = '"+ Caj + "', CodReg_ElecPag = '"+ UsReci + "',FecRegis_ElecPag = CONVERT(Datetime, '"+ DateTime.Now.Date +"', 106)  ";

                        Conexion.SQLUpdate(Utils.SqlDatos);

                        //Devuelva el campo convertido en un string

                        Convertido = "";
                        switch (Caj)
                        {
                            case double resul when resul < 10:

                                Convertido =  "00000" + Caj.ToString();

                                break;
                            case double resul when resul >= 10 && resul <= 99:

                                Convertido =  "0000" + Caj.ToString();

                                break;
                            case double resul when resul >= 100 && resul <= 999:

                                Convertido =  "000" + Caj.ToString();

                                break;
                            case double resul when resul >= 1000 && resul <= 9999:

                                Convertido =  "00" + Caj.ToString();

                                break;
                            case double resul when resul >= 10000 && resul <= 99999:

                                Convertido =  "0" + Caj.ToString();

                                break;
                            case double resul when resul >= 100000 && resul <= 999999:

                                Convertido = Caj.ToString();

                                break;

                            default:
                                //Valor no permitido
                                return "-3";
                        }

                    }
                }

                return Convertido;


            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "DE EJECUCIÓN EN LA FUNCIÓN ConseReciCaja. " + "\r";
                Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "-1";
            }
        }

        private string ConseReciCaja(int Actualizo, string US, string CCj)
        {
            try
            {
                //Esta función permite devolver el consecutivo de recibos de caja

                //'*************************** A partir del 24 de septiembre de 2014 se modifica ***************************
                //'*****************Para invocar esta función debe estar abierta la base de datos de caja ********************

                string Convertido = "";
                string SqlConseCaja = "SELECT * FROM [BDCAJASQL].[dbo].[Datos cajas y consecutivos] ";
                SqlConseCaja += "WHERE CodCaja = '" + CCj + "' ";
                SqlConseCaja += "ORDER BY CodCaja";

                double Caj = 0;


                using (SqlConnection connection3 = new SqlConnection(Conexion.conexionSQL))
                {
                    SqlCommand command3 = new SqlCommand(SqlConseCaja, connection3);
                    command3.Connection.Open();
                    SqlDataReader TabConseCaja = command3.ExecuteReader();

                    if (TabConseCaja.HasRows == false)
                    {
                        //No se encontró la caja en la tabla
                        return "0";
                    }
                    else
                    {

                        TabConseCaja.Read();

                        //Revisamos si la caja se encuentra habilitada

                        string FecUlti = DateTime.Now.Date.ToString("yyyy-MM-dd");

                        if (Convert.ToBoolean(TabConseCaja["HabilCaja"]) == false)
                        {
                            //La caja no se encuentra habilitada
                            return "-4";
                        }
                        else
                        {
                            //Controle que no se registre recibos de caja con fechas anteriores a la de hoy

                            DateTime FechaUltima = Convert.ToDateTime(TabConseCaja["FecCaja"]);

                            //'Revisemos que esta no sea mayor a la del sistema

                            if (FechaUltima > DateTime.Now.Date)
                            {
                                return "-2";
                            }
                            else
                            {
                                ///Revisamos si existen consecutivos no asignados
                                if (Convert.ToDouble(TabConseCaja["UltiConCaja"]) == 0)
                                {
                                    //No existen recibos de caja perdidos en esta bodega
                                    Caj = Convert.ToDouble(TabConseCaja["ConseCaja"]);
                                    Caj += 1;
                                    //Proceda a actualizar el campo de facturas
                                    if (Actualizo == 1)
                                    {
                                        Utils.SqlDatos = "UPDATE [BDCAJASQL].[dbo].[Datos cajas y consecutivos]  SET ConseCaja = '" + Caj + "', UsarCaja = '" + US + "', FecCaja = Convert(Date,'" + FecUlti + "',102) WHERE CodCaja= '" + CCj + "'  ";


                                        bool sqlUpdate = Conexion.SQLUpdate(Utils.SqlDatos);



                                    }

                                }
                                else
                                {
                                    Caj = Convert.ToDouble(TabConseCaja["UltiConCaja"]);

                                    if (Actualizo == 1)
                                    {
                                        Utils.SqlDatos = "UPDATE [BDCAJASQL].[dbo].[Datos cajas y consecutivos]  SET UltiConCaja = '" + 0 + "' WHERE CodCaja= '" + CCj + "'  ";


                                        bool sqlUpdate = Conexion.SQLUpdate(Utils.SqlDatos);
                                    }

                                }

                                //Devuelva el campo convertido en un string
                                Convertido = "";

                                switch (Caj)
                                {
                                    case double resul when resul < 10:

                                        Convertido = CCj + "00000" + Caj.ToString();

                                        break;
                                    case double resul when resul >= 10 && resul <= 99:

                                        Convertido = CCj + "0000" + Caj.ToString();

                                        break;
                                    case double resul when resul >= 100 && resul <= 999:

                                        Convertido = CCj + "000" + Caj.ToString();

                                        break;
                                    case double resul when resul >= 1000 && resul <= 9999:

                                        Convertido = CCj + "00" + Caj.ToString();

                                        break;
                                    case double resul when resul >= 10000 && resul <= 99999:

                                        Convertido = CCj + "0" + Caj.ToString();

                                        break;
                                    case double resul when resul >= 100000 && resul <= 999999:

                                        Convertido = CCj + Caj.ToString();

                                        break;

                                    default:
                                        //Valor no permitido
                                        return "-3";
                                }

                                return Convertido;

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "DE EJECUCIÓN EN LA FUNCIÓN ConseReciCaja. " + "\r";
                Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "-1";
            }

        }

    }
}
