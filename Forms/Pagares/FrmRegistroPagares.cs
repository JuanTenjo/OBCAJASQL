using OBCAJASQL.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;
using OBCAJASQL.Report;

namespace OBCAJASQL.Forms.Pagares
{
    public partial class FrmRegistroPagares : Form
    {
        public FrmRegistroPagares()
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

                Utils.SqlDatos = "SELECT [Datos ctas contables IPS].CueContaIPS, [Datos ctas contables IPS].NomCConIPS, [Datos ctas contables IPS].CueContaIPS + ' ' + [Datos ctas contables IPS].NomCConIPS as display " +
                " FROM [GEOGRAXPSQL].[dbo].[Datos ctas contables IPS] WHERE"  +
                " ((([Datos ctas contables IPS].CueContaIPS) <> '0000000') AND((Left([CueContaIPS], 2)) = '14')) ORDER BY[Datos ctas contables IPS].NomCConIPS; ";

                DataSet dataSet = Conexion.SQLDataSet(Utils.SqlDatos);

                if (dataSet != null && dataSet.Tables.Count > 0)
                {
                    this.CboCuenConta.DataSource = dataSet.Tables[0];
                    this.CboCuenConta.ValueMember = "CueContaIPS";
                    this.CboCuenConta.DisplayMember = "Display";
                }



                Utils.SqlDatos = "SELECT [Datos documentos empresas].CodIdenti, [Datos documentos empresas].NomIdenti FROM[GEOGRAXPSQL].[dbo].[Datos documentos empresas] ORDER BY[Datos documentos empresas].CodIdenti, [Datos documentos empresas].NomIdenti; ";

                DataSet dataSet2 = Conexion.SQLDataSet(Utils.SqlDatos);
                DataSet dataSet7 = Conexion.SQLDataSet(Utils.SqlDatos);

          
                this.CboTDRes.DataSource = dataSet2.Tables[0];
                this.CboTDRes.ValueMember = "CodIdenti";
                this.CboTDRes.DisplayMember = "NomIdenti";

                this.CboTDCodeu.DataSource = dataSet7.Tables[0];
                this.CboTDCodeu.ValueMember = "CodIdenti";
                this.CboTDCodeu.DisplayMember = "NomIdenti";
                

                Utils.SqlDatos = "SELECT ([TipoDocu] + [IdenProve]) AS Identi, [Datos proveedores].RazonSol, [Datos proveedores].TipoDocu, " + 
                " [Datos proveedores].IdenProve, [Datos proveedores].SucurProv, " +
                " [Datos proveedores].HabilPro FROM[GEOGRAXPSQL].[dbo].[Datos proveedores] WHERE ((([Datos proveedores].HabilPro) = 'True')) " +
                " ORDER BY [Datos proveedores].RazonSol; ";

                DataSet dataSet3 = Conexion.SQLDataSet(Utils.SqlDatos);
                DataSet dataSet6 = Conexion.SQLDataSet(Utils.SqlDatos);

                this.CboNomRespon.DataSource = dataSet3.Tables[0];
                this.CboNomRespon.ValueMember = "IdenProve";
                this.CboNomRespon.DisplayMember = "RazonSol";

                this.CboNomCodeu.DataSource = dataSet6.Tables[0];
                this.CboNomCodeu.ValueMember = "IdenProve";
                this.CboNomCodeu.DisplayMember = "RazonSol";

                

                Utils.SqlDatos = " SELECT [Datos ctas contables IPS].CueContaIPS, [Datos ctas contables IPS].NomCConIPS  " +
                " FROM [GEOGRAXPSQL].[dbo].[Datos ctas contables IPS] " +
                " WHERE ((Left([CueContaIPS], 2) = '14')) " +
                " ORDER BY [Datos ctas contables IPS].NomCConIPS; ";

                DataSet dataSet4 = Conexion.SQLDataSet(Utils.SqlDatos);

                if (dataSet4 != null && dataSet4.Tables.Count > 0)
                {
                    this.CboNomCueConta.DataSource = dataSet4.Tables[0];
                    this.CboNomCueConta.ValueMember = "CueContaIPS";
                    this.CboNomCueConta.DisplayMember = "NomCConIPS";
                    
                }


                Utils.SqlDatos = " SELECT [Datos documentos consecutivos].NDocum, [Datos documentos consecutivos].Asignado  "+
                "FROM [BDCAJASQL].[dbo].[Datos documentos consecutivos] WHERE((([Datos documentos consecutivos].Asignado) = 'False')) "+
                "ORDER BY[Datos documentos consecutivos].NDocum; ";

                DataSet dataSet5 = Conexion.SQLDataSet(Utils.SqlDatos);

                if (dataSet5 != null && dataSet5.Tables.Count > 0)
                {
                    this.CboPagaNum.DataSource = dataSet5.Tables[0];
                    this.CboPagaNum.ValueMember = "NDocum";
                    this.CboPagaNum.DisplayMember = "NDocum";
                    
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


        int MarDefiPago = 1;
        private void FrmRegistroPagares_Load(object sender, EventArgs e)
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
                Utils.Informa += "al abrir el formulario registro pagares" + "\r";
                Utils.Informa += "Error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void CboPagaNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            CboPagaNum.DroppedDown = false;
        }

        private void CboCuenConta_KeyPress(object sender, KeyPressEventArgs e)
        {
            CboCuenConta.DroppedDown = false;
        }

        private void CboNomCueConta_KeyPress(object sender, KeyPressEventArgs e)
        {
            CboNomCueConta.DroppedDown = false;
        }

        private void CboNomRespon_KeyPress(object sender, KeyPressEventArgs e)
        {
            CboNomRespon.DroppedDown = false;
        }

        private void CboNomCodeu_KeyPress(object sender, KeyPressEventArgs e)
        {
            CboNomCodeu.DroppedDown = false;
        }


        private void CargaFactura()
        {
            try
            {
                string SqlFacturas = "", Cta = "", CarFac = "", SqlCuenConsu = "", H = "", SqlEmpTer = "", SqlPacientes = "";
                int ConTiPro = 0;
                double ValFacTol = 0, ValDesFac = 0, ValPagosFac = 0, ValDepo = 0, ValNeto = 0;

                string f = TxtFacNum.Text;

                Utils.Titulo01 = "Control para mostrar datos";

                SqlFacturas = "SELECT * FROM [ACDATOXPSQL].[dbo].[Datos de las facturas realizadas] ";
                SqlFacturas += "WHERE NumFactura='" + f + "' ";
                SqlFacturas += "ORDER BY NumFactura";

                using (SqlConnection connection = new SqlConnection(Conexion.conexionSQL))
                {

                    SqlCommand command = new SqlCommand(SqlFacturas, connection);
                    command.Connection.Open();
                    SqlDataReader TabFacturas = command.ExecuteReader();


                    if (TabFacturas.HasRows == false)
                    {
                        Utils.Informa = "Lo siento pero el número de factura" + "\r";
                        Utils.Informa += "digitado no existe en este sistema"  + "\r";
                        Utils.Informa += "Por favor corrija el número o pulse"  + "\r";
                        Utils.Informa += "la tecla [ESC] para continuar";
                        MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        TabFacturas.Read();

                        if(Convert.ToBoolean(TabFacturas["AnuladaFac"]) == true)
                        {
                            Utils.Informa = "Lo siento pero el número de factura" + "\r";
                            Utils.Informa += "digitado se encuentra anulado en este sistema"  + "\r";
                            Utils.Informa += "Por favor corrija el número o pulse"  + "\r";
                            Utils.Informa += "la tecla [ESC] para continuar";
                            MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {


                            Cta = TabFacturas["NumCuenFac"].ToString();

                            DtFecFactur.Value = Convert.ToDateTime(TabFacturas["FechaFac"]);
                            TxtValTol.Text = string.Format("{0:C2}", TabFacturas["ValorTotal"]);
                            TxtValCompar.Text = string.Format("{0:C2}", TabFacturas["Copago"]);

                            TxtValDepo.Text = string.Format("{0:C2}", TabFacturas["PagoConDepos"]);
                            TxtValNeto.Text = string.Format("{0:C2}", TabFacturas["ValorFac"]);
                            //Con base al cardinal de la factura, buscamos algunos datos de la empresa

                            CarFac = TabFacturas["Cartercero"].ToString();

                            //Con Base al número de cuenta de consumos buscamos la factura

                            SqlCuenConsu = "SELECT * FROM [ACDATOXPSQL].[dbo].[Datos cuentas de consumos] ";
                            SqlCuenConsu += "WHERE CuenNum='" + Cta + "' ";
                            SqlCuenConsu += "ORDER BY CuenNum";

                            using (SqlConnection connection2 = new SqlConnection(Conexion.conexionSQL))
                            {

                                SqlCommand command2 = new SqlCommand(SqlCuenConsu, connection2);
                                command2.Connection.Open();
                                SqlDataReader TabCuenConsu = command2.ExecuteReader();

                                if(TabCuenConsu.HasRows == false)
                                {
                                    Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                                    Utils.Informa += "fatal en el sistema, ya que el número de"  + "\r";
                                    Utils.Informa += "la cuenta de la factura no se pudo"  + "\r";
                                    Utils.Informa += "encontrar en la base de datos.";
                                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    ConTiPro = 0;
                                }
                                else
                                {
                                    TabCuenConsu.Read();
                                    //Tome el número de la historia

                                    H = TabCuenConsu["HistoNum"].ToString();
                                    TxtCuenFactur.Text = H;
                                    ConTiPro = 1;
                                }
                            }

                            if(ConTiPro == 1)
                            {
                                //Buscamos los datos del nombre del paciente

                                SqlPacientes = "SELECT * FROM [ACDATOXPSQL].[dbo].[Datos del Paciente] ";
                                SqlPacientes += "WHERE HistorPaci='" + H + "' ";
                                SqlPacientes += "ORDER BY HistorPaci";

                                using (SqlConnection connection3 = new SqlConnection(Conexion.conexionSQL))
                                {

                                    SqlCommand command3 = new SqlCommand(SqlPacientes, connection3);
                                    command3.Connection.Open();
                                    SqlDataReader TabPacientes = command3.ExecuteReader();

                                    if(TabPacientes.HasRows == false)
                                    {
                                        Utils.Informa += "fatal en el sistema, ya que el número de" + "\r";
                                        Utils.Informa += "la historia de la cuenta no se pudo"  + "\r";
                                        Utils.Informa += "encontrar en la base de datos.";
                                        MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        ConTiPro = 0;                      Utils.Informa = "Lo siento pero se ha presentado un error";
                  
                                    }
                                    else
                                    {
                                        TabPacientes.Read();

                                        TxtTDUsar.Text = TabPacientes["TipoIden"].ToString();
                                        TxtNDUsar.Text = TabPacientes["NumIden"].ToString();
                                        TxtNomUsuar.Text = TabPacientes["Nombre1"].ToString() + " " + TabPacientes["Nombre2"].ToString() + " " + TabPacientes["Apellido1"].ToString() + " " + TabPacientes["Apellido2"].ToString();
                                        ConTiPro = 1;
                                    }


                                }
                            }

                            if(ConTiPro == 1)
                            {

                                SqlEmpTer = "SELECT * FROM [ACDATOXPSQL].[dbo].[Datos empresas y terceros] ";
                                SqlEmpTer += "WHERE CarAdmin = '" + CarFac + "' ";
                                SqlEmpTer += "ORDER BY CarAdmin";


                                using (SqlConnection connection4 = new SqlConnection(Conexion.conexionSQL))
                                {

                                    SqlCommand command4 = new SqlCommand(SqlEmpTer, connection4);
                                    command4.Connection.Open();
                                    SqlDataReader TabEmpTer = command4.ExecuteReader();

                                    if(TabEmpTer.HasRows == false)
                                    {
                                        Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                                        Utils.Informa += "fatal en el sistema, porque el cardinal"  + "\r";
                                        Utils.Informa += "de la factura no se pudo encontrar en la"  + "\r";
                                        Utils.Informa += "tabla de empresas y terceros."  + "\r";
                                        Utils.Informa += "Por favor corrija el número o pulse"  + "\r";
                                        Utils.Informa += "la tecla [ESC] para continuar.";
                                        MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        ConTiPro = 0;
                                    }
                                    else
                                    {
                                        TabEmpTer.Read();

                                        //Muestre algunos datos


                                        if(Convert.ToInt32(TabFacturas["Copago"]) == 0)
                                        {
                                            //Necesariamente va ha cancelar es una factura por el valor neto
                                            //hace el metodo de cancelación neto
                                            MarDefiPago = 2;
                                            RbNeto.Checked = true;
                                            RbCompartido.Checked = false;
                                        }
                                        else
                                        {
                                            MarDefiPago = 1;
                                            RbCompartido.Checked = true;
                                            RbNeto.Checked = false;
                                        }
                                    }

                                    //Muestre los saldos

                                    string SaldCopa = ((double)TabFacturas["Copago"] + (double)TabFacturas["ValorOtros"] - (double)TabFacturas["CanceCopago"] + (double)TabFacturas["PagoConDepos"]).ToString();
                                    TxtSaldCopa.Text = string.Format("{0:C2}", SaldCopa);

                                    ValFacTol = (double)TabFacturas["ValorFac"] + (double)TabFacturas["Copago"] + (double)TabFacturas["NotaDebito"];
                                    ValDesFac = (double)TabFacturas["NotaCredito"] + (double)TabFacturas["DesVarios"] + (double)TabFacturas["Retencion"] + (double)TabFacturas["DesTramite"] + (double)TabFacturas["OtrosDescuentos"];
                                    ValPagosFac = (double)TabFacturas["PagoFac"] + (double)TabFacturas["CanceCopago"] + (double)TabFacturas["PagoConDepos"];


                                    string SaldNeto = (ValFacTol - (ValDesFac + ValPagosFac)).ToString();
                                    TxtSaldoNeto.Text = string.Format("{0:C2}", SaldNeto);

                                    TxtTDTer.Text = TabEmpTer["TipoDocu"].ToString();
                                    TxtNDTer.Text = TabEmpTer["NumDocu"].ToString();
                                    TxtCodSucTer.Text = TabEmpTer["SucuDoc"].ToString();
                                    TxtNomTer.Text = TabEmpTer["NomAdmin"].ToString();

                                }
                            }
                        }
                    }
                }

                //Se asume que el valor del pagaré es igual al valor compartido menos el deposito o al valor neto
                //de la factura.


                if(MarDefiPago == 1)
                {
                    //double ValTolPaga = ValDepo - ValDepo;
                    double ValTolPaga = double.Parse(TxtValCompar.Text, NumberStyles.Currency) - double.Parse(TxtValDepo.Text, NumberStyles.Currency);
                    TxtValPaga.Text = string.Format("{0:C2}", ValTolPaga);
                }
                else
                {
                    TxtValPaga.Text = string.Format("{0:2}", TxtValNeto.Text);
                }

                //Grabe en la tabla local la primera cuota del pagaré


                GridDetalleRegistroCuotas.Rows.Clear();

                GridDetalleRegistroCuotas.Rows.Add(1, double.Parse(TxtValPaga.Text, NumberStyles.Currency), "100", DtFecVenPaga.Value, CboPagaNum.SelectedValue.ToString());

                CargarTotales();

            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "en la funcion CargaFactura" + "\r";
                Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtFacNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((int)e.KeyChar == (int)Keys.Enter)
                {
                    if (string.IsNullOrWhiteSpace(TxtFacNum.Text) == false)
                    {

                        CargaFactura();

                    }//TxtNumfactura

                }//KeyChar
            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "despues de dar enter para buscar el numero de factura" + "\r";
                Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RbCompartido_CheckedChanged(object sender, EventArgs e)
        {
            MarDefiPago = 1;
        }

        private void RbNeto_CheckedChanged(object sender, EventArgs e)
        {
            MarDefiPago = 2;
        }



        private void CargaCuota()
        {
            try
            {
                if(Convert.ToDouble(TxtNumCuoPaga.Text) > 0)
                {

                    GridDetalleRegistroCuotas.Rows.Clear();

                    double ValCuo = 0, P = 0;
                    int Ncuotas = 0;

                    Utils.Titulo01 = "Control de entrada de datos";

                    Ncuotas = Convert.ToInt32(TxtNumCuoPaga.Text);

                    double ValPaga = double.Parse(TxtValPaga.Text, NumberStyles.Currency);

                    ValCuo = double.Parse(TxtValPaga.Text, NumberStyles.Currency) / Convert.ToDouble(TxtNumCuoPaga.Text);

                    P = (ValCuo * 100) / ValPaga;

                    DateTime date = DateTime.Now.Date;

                    DateTime FechaCuota = date.AddMonths(Ncuotas);

                    for (int i = 1; i <= Ncuotas; i++)
                    {
                        GridDetalleRegistroCuotas.Rows.Add(i, ValCuo, P, date.AddMonths(i), CboPagaNum.SelectedValue.ToString());
                    }

                    CargarTotales();

                }
            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "en la funcion CargaCuota" + "\r";
                Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtNumCuoPaga_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Utils.Titulo01 = "Control de entrada de datos";

                int valor;

                bool esNumero = int.TryParse(TxtNumCuoPaga.Text, out valor);

                if (!esNumero)
                {
                    Utils.Informa = "LO SIENTO PERO EL NÚMERO DE CUOTAS DEL" + "\r";
                    Utils.Informa += "PAGARE TIENE QUER TIPO NUMERO" + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    GridDetalleRegistroCuotas.Rows.Clear();
                    return;
                }

                if (Convert.ToInt32(TxtNumCuoPaga.Text) <= 0)
                {
                    Utils.Informa = "LO SIENTO PERO EL NÚMERO DE CUOTAS DEL" + "\r";
                    Utils.Informa += "PAGARE NO PUEDE SER MENOR A UNO (1)" + "\r";
                    Utils.Informa += "Por favor corrija el valor o pulse" + "\r";
                    Utils.Informa += "la tecla [ESC] para anular la acción." + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if(Convert.ToInt32(TxtNumCuoPaga.Text) > 4)
                {
                    Utils.Informa = "LO SIENTO PERO EL NÚMERO DE CUOTAS DEL" + "\r";
                    Utils.Informa += "PAGARE NO PUEDE SER MAYOR A cuatro(4)" + "\r";
                    Utils.Informa += "Por favor corrija el valor o pulse" + "\r";
                    Utils.Informa += "la tecla [ESC] para anular la acción." + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (double.Parse(TxtValPaga.Text,NumberStyles.Currency) <= 0)
                {
                    Utils.Informa = "LO SIENTO PERO EL VALOR TOTAL DEL PAGARE" + "\r";
                    Utils.Informa += "NO PUEDE SER MENOR O IGUAL A CERO" + "\r";
                    Utils.Informa += "Por favor corrija el valor o pulse" + "\r";
                    Utils.Informa += "la tecla [ESC] para anular la acción." + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    CargaCuota();
                }
            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "al actualizar el numero de cuota" + "\r";
                Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CargarTotales()
        {
            try
            {
                double totalValor = 0;
                double totalPorce = 0;

                if (GridDetalleRegistroCuotas.Rows.Count > 0)
                {
                    foreach (DataGridViewRow Row in GridDetalleRegistroCuotas.Rows)
                    {
                        totalValor += Convert.ToDouble(Row.Cells[1].Value);
                        totalPorce += Convert.ToDouble(Row.Cells[2].Value);
                    }

                    TxtTotalPaga.Text = totalValor.ToString();
                    TxtTotalPorcentaje.Text = totalPorce.ToString();
                }
            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "al calcular los totales de la grilla" + "\r";
                Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRegistraPagares_Click(object sender, EventArgs e)
        {
            try
            {
                double VT = 0, VTD = 0, SalFac = 0;
                int NC = 0, Conti = 0;
                string FVP = "", FN = "", NRP = "", SqlMovFac = "", SqlFacturas = "", SqlDocPaga = "", Sucur = "",  PN = "", NUP = "", NCR = "", SqlRegPaga = "";


                Utils.SqlDatos = "Control para registrar pagarés";

                //Revisamos si se digitó el número de factura

                if (string.IsNullOrWhiteSpace(TxtFacNum.Text))
                {
                    Utils.Informa = "Lo siento pero usted no ha digitado" + "\r";
                    Utils.Informa += "el número de la factura a la que se" + "\r";
                    Utils.Informa += "le afecta con el pagaré a registrar" + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //Revisamos si se digitó el número de cuenta contable

                if (CboCuenConta.SelectedIndex == -1)
                {
                    Utils.Informa = "Lo siento pero usted no ha digitado el" + "\r";
                    Utils.Informa += "número de la cuenta contable a la que" + "\r";
                    Utils.Informa += "se le afecta con el pagaré a registrar." + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //Revisamos si se digitó el responsable

                if (CboNomRespon.SelectedIndex == -1)
                {
                    Utils.Informa = "Lo siento pero usted no ha digitado el" + "\r";
                    Utils.Informa += "número del documento de identificación de la" + "\r";
                    Utils.Informa += "persona responsable del pagaré a registrar." + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                //Revisamos si el total del pagaré es igual al total de pagos de las cuotas
                VT = double.Parse(TxtValPaga.Text, NumberStyles.Currency);
                VTD = double.Parse(TxtTotalPaga.Text, NumberStyles.Currency);

                if (VT != VTD)
                {
                    Utils.Informa = "Lo siento pero el valor total del pagaré es" + "\r";
                    Utils.Informa += "diferente al valor total de las cuotas registradas," + "\r";
                    Utils.Informa += "por lo tanto no se puede realizar en este sistema." + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //Revisamos la realción de los saldos y el valor del pagare

                if(MarDefiPago == 1)
                {
                    //Valor Compartido


                    double SaldoNeto= ConverToDouble(TxtSaldoNeto.Text);
                    double SaldCopa = ConverToDouble(TxtSaldCopa.Text);
                    double IntePaga = ConverToDouble(TxtIntePaga.Text);
                    double MoraPaga = ConverToDouble(TxtMoraPaga.Text);

                    ///Revisamos cuanto seria el valor con los intereses
                    SalFac = SaldCopa + (((SaldCopa * IntePaga) / 100) + ((SaldCopa * MoraPaga) / 100)); //Si los interes se tuvieran encuenta en el principio                      

                    if (VT > SaldCopa)
                    {
                        Utils.Informa = "Lo siento pero el valor del pagaré no puede ser" + "\r";
                        Utils.Informa += "mayor al saldo del valor compartido de la factura." + "\r";
                        MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        //Valor neto

                        SalFac = SaldoNeto + (((SaldoNeto * IntePaga) / 100) + ((SaldCopa + MoraPaga) / 100));

                        if(VT > SaldoNeto)
                        {
                            Utils.Informa = "Lo siento pero el valor del pagaré no puede ser" + "\r";
                            Utils.Informa += "ser mayor al saldo del valor neto de la factura." + "\r";
                            MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }//if(MarDefiPago == 1)

                if(CboPagaNum.SelectedIndex == -1)
                {
                    Utils.Informa = "Lo siento pero usted no seleccionado el número del pagaré a registrar." + "\r";
                    return;
                }

                NC = Convert.ToInt32(TxtNumCuoPaga.Text);
                FVP = DtFecVenPaga.Value.ToString("yyyy-MM-dd");
                FN = TxtFacNum.Text;
                NRP = CboNomRespon.SelectedValue.ToString();
                PN = CboPagaNum.SelectedValue.ToString();
                NUP = TxtNomUsuar.Text;


                if(MarDefiPago == 1)
                {
                    Utils.Informa = "¿Usted desea registrar el pagaré número" + "\r";
                    Utils.Informa += "para amortizar el pago del valor compartido de" + "\r";
                }
                else
                {
                    Utils.Informa = "¿Usted desea registrar el pagaré número " + "\r";
                    Utils.Informa += "para amortizar el pago del valor neto de" + "\r";
                }

                Utils.Informa += "la factura No. " + FN + " realizada al usuario " + "\r";
                Utils.Informa += "de  nombre: " + NUP + ".?" +  "\r";

                if(CboNomCodeu.SelectedIndex == -1)
                {
                    //pagare conn codeudor

                    Utils.Informa += "Responsable" + NRP;
              
                }
                else
                {
                    NCR = CboNomCodeu.SelectedValue.ToString();
                    Utils.Informa += "Responsable: " + NRP + "\r";
                    Utils.Informa += "Codeudor: " + NCR + "\r";
                }

                var res = MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if(res == DialogResult.Yes)
                {
                    Conti = 0;

                    //Revisamos si se registraron las cuotas


                    if (GridDetalleRegistroCuotas.Rows.Count < 0)
                    {
                        Utils.Informa = "Lo siento pero se ha presentado un error fatal" + "\r";
                        Utils.Informa += "den el sistema, los datos de registro de las" + "\r";
                        Utils.Informa += "cuotas del pagaré no se encontraron registradas.";
                        Utils.Informa += "Por lo tanto no se puede realizar el proceso.";
                        MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {

                        //Proceda a regsitrar el pagaré en la base de datos


                        SqlRegPaga = "SELECT * FROM [BDCAJASQL].[dbo].[Datos registro de pagares] ";
                        SqlRegPaga += "WHERE NumPaga='" + PN + "' ";
                        SqlRegPaga += "ORDER BY NumPaga";

                        using (SqlConnection connection = new SqlConnection(Conexion.conexionSQL))
                        {

                            SqlCommand command = new SqlCommand(SqlRegPaga, connection);
                            command.Connection.Open();
                            SqlDataReader TabRegPaga = command.ExecuteReader();


                            //Proceda a registrar el pagaré

                            if (TabRegPaga.HasRows == false)
                            {

                                Utils.SqlDatos = "INSERT INTO [BDCAJASQL].[dbo].[Datos registro de pagares]" +
                                "(" +
                                "NumPaga," +
                                "NumFacPaga," +
                                "TDRespon," +
                                "NumTerPaga," +
                                "SucRespon," +
                                "HistoriaPaga," +
                                "NomUsaR,";
                                if (CboNomCodeu.SelectedIndex == -1)
                                {
                                    Utils.SqlDatos += "TDCodeudor," +
                                    "CodeuPaga," +
                                    "SucCodeu,";
                                }
                                Utils.SqlDatos += "ValorPaga," +
                                "FecPagare," +
                                "FecVenPaga," +
                                "NumCuotas," +
                                "InterPaga," +
                                "InterMora," +
                                "CuentaConta," +
                                "FecCanPaga," +
                                "FecRegis," +
                                "CodRegis" +
                                ")" +
                                "VALUES" +
                                "(" +
                                "'" + PN + "'," +
                                "'" + FN + "'," +
                                "'" + CboTDRes.SelectedValue.ToString() + "'," +
                                "'" + TxtDocuRespon.Text + "'," +
                                "'" + TxtSucurRespon.Text + "'," +
                                "'" + TxtCuenFactur.Text + "'," +
                                "'" + TxtNomUsuar.Text + "',";
                                if (CboNomCodeu.SelectedIndex == -1)
                                {
                                    Utils.SqlDatos += "'" + CboTDCodeu.Text + "'," +
                                    "'" + TxtNumCodeu.Text + "'," +
                                    "'" + TxtSucurCode.Text + "',";
                                }
                                Utils.SqlDatos += "'" + VT + "'," +
                                $"{Conexion.ValidarFechaNula(DateTime.Now.ToString("yyyy-MM-dd"))}" +
                                $"{Conexion.ValidarFechaNula(DtFecVenPaga.Value.ToString())}" +
                                "'" + TxtNumCuoPaga.Text + "'," +
                                "'" + TxtIntePaga.Text + "'," +
                                "'" + TxtMoraPaga.Text + "'," +
                                "'" + CboCuenConta.SelectedValue.ToString() + "'," +
                                $"{Conexion.ValidarFechaNula(DateTime.Now.ToString("yyyy-MM-dd"))}" +
                                $"{Conexion.ValidarFechaNula(DateTime.Now.ToString("yyyy-MM-dd"))}" +
                                "'" + lblCodigoUser.Text + "'" +
                                ")";

                                Conexion.SqlInsert(Utils.SqlDatos);


                                //Procede a regiistrar el detalle

                                Utils.SqlDatos = "INSERT INTO [BDCAJASQL].[dbo].[Datos registro cuotas pagares](NumPaga,CuoPaga,ValCuota,PorCuota,FecVenCuota,CodRegis,FecRegis)" +
                                    "VALUES(@NumPaga,@CuoPaga,@ValCuota,@PorCuota,@FecVenCuota,@CodRegis,@FecRegis)";

                                List<SqlParameter> patameters = new List<SqlParameter>();

                                foreach (DataGridViewRow Row in GridDetalleRegistroCuotas.Rows)
                                {
                                    patameters = new List<SqlParameter>
                                    {
                                    new SqlParameter("@NumPaga", SqlDbType.VarChar){ Value  = Row.Cells[4].Value.ToString() },
                                    new SqlParameter("@CuoPaga", SqlDbType.VarChar){ Value  = Row.Cells[0].Value.ToString() },
                                    new SqlParameter("@ValCuota", SqlDbType.VarChar){ Value  = Row.Cells[1].Value.ToString() },
                                    new SqlParameter("@PorCuota", SqlDbType.VarChar){ Value  =  Row.Cells[2].Value.ToString() },
                                    new SqlParameter("@FecVenCuota", SqlDbType.VarChar){ Value  = Convert.ToDateTime(Row.Cells[3].Value).ToString("yyyy-MM-dd") },
                                    new SqlParameter("@CodRegis", SqlDbType.VarChar){ Value  = lblCodigoUser.Text },
                                    new SqlParameter("@FecRegis", SqlDbType.VarChar){ Value  = DateTime.Now.Date.ToString("yyyy-MM-dd") },
                                    };


                                    Conexion.SqlInsert(Utils.SqlDatos, patameters);

                                }

                                


                                SqlDocPaga = "SELECT * FROM [BDCAJASQL].[dbo].[Datos documentos consecutivos] ";
                                SqlDocPaga += "WHERE NDocum ='" + PN + "' ";
                                SqlDocPaga += "ORDER BY NDocum ";

                                using (SqlConnection connection2 = new SqlConnection(Conexion.conexionSQL))
                                {

                                    SqlCommand command2 = new SqlCommand(SqlRegPaga, connection2);
                                    command2.Connection.Open();
                                    SqlDataReader TabDocPaga = command2.ExecuteReader();

                                    if (TabDocPaga.HasRows == false)
                                    {
                                        //Casi imposible que entre por aqui, ya que por cuestiones de integridad
                                    }
                                    else
                                    {
                                        Utils.SqlDatos = "UPDATE [BDCAJASQL].[dbo].[Datos documentos consecutivos] SET Asignado =  1,CodModi = '" + lblCodigoUser.Text + "', FecModi = CONVERT(DATETIME, '" + DateTime.Now.ToString("yyyy-MM-dd") + "',102) " +
                                        "WHERE NDocum = '" + PN + "'";

                                        Conexion.SQLUpdate(Utils.SqlDatos);


                                    }
                                }

                                //Actualizamos la lista de documentos disponibles


                                Conti = 1;

                            }
                            else
                            {
                                Utils.Informa = "Lo siento  pero el  número del pagaré" + "\r";
                                Utils.Informa += "a registrar ya existe en este sistema," + "\r";
                                Utils.Informa += "por lo tanto no se puede volver a asignar";
                                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        } //Using


                        if(Conti == 1)
                        {
                            //Proceda a afectar la factura


                            SqlFacturas = "SELECT * FROM [ACDATOXPSQL].[dbo].[Datos de las facturas realizadas] ";
                            SqlFacturas += "WHERE NumFactura='" + FN + "' ";
                            SqlFacturas += "ORDER BY NumFactura";


                            using (SqlConnection connection = new SqlConnection(Conexion.conexionSQL))
                            {

                                SqlCommand command = new SqlCommand(SqlFacturas, connection);
                                command.Connection.Open();
                                SqlDataReader TabFacturas = command.ExecuteReader();


                                if (TabFacturas.HasRows == false)
                                {
                                    Utils.Informa = "A pesar que el pagaré se generó, la factura" + "\r";
                                    Utils.Informa += "no se pudo encontrar en este sistema, por lo" + "\r";
                                    Utils.Informa += "tanto no pudo ser afectada.";
                                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else
                                {
                                    TabFacturas.Read();

                                    if(MarDefiPago == 1)
                                    {
                                        //Abona o paga el valor compartido

                                        double CanceCoPago = Convert.ToDouble(TabFacturas["CanceCopago"]) + VT;

                                        Utils.SqlDatos = "UPDATE [ACDATOXPSQL].[dbo].[Datos de las facturas realizadas] SET CanceCopago = '" + CanceCoPago + "', FecCanCopa = CONVERT(DATETIME, '" + DateTime.Now.ToString("yyyy-MM-dd") + "',102), CodiModi = '" + lblCodigoUser.Text + "', FecModi = CONVERT(DATETIME, '" + DateTime.Now.ToString("yyyy-MM-dd") + "',102) " +
                                                        "WHERE NumFactura='" + FN + "'";

                                    }
                                    else
                                    {
                                        //Abonoa o paga el valor neto

                                        double PagoFac = Convert.ToDouble(TabFacturas["PagoFac"]) + VT;

                                        Utils.SqlDatos = "UPDATE [ACDATOXPSQL].[dbo].[Datos de las facturas realizadas] SET PagoFac = '" + PagoFac + "', FecCanCopa = CONVERT(DATETIME, '" + DateTime.Now.ToString("yyyy-MM-dd") + "',102), CodiModi = '" + lblCodigoUser.Text + "', FecModi = CONVERT(DATETIME, '" + DateTime.Now.ToString("yyyy-MM-dd") + "',102) " +
                                        "WHERE NumFactura='" + FN + "'";

                                    }

                                    Conexion.SQLUpdate(Utils.SqlDatos);

                                    //Procedemos a afectar los movvimientos de la factura


                                    Utils.SqlDatos = "INSERT INTO [ACDATOXPSQL].[dbo].[Datos movimientos facturas]" +
                                    "(" +
                                    "FactuNum," +
                                    "FecMovi," +
                                    "ValMovi," +
                                    "TipoMovi," +
                                    "SigNo," +
                                    "Documento," +
                                    "FecRegis," +
                                    "CodRegis" +
                                    ")" +
                                    "VALUES" +
                                    "(" +
                                    "'" + FN + "'," +
                                    $"{Conexion.ValidarFechaNula(DateTime.Now.ToString("yyyy-MM-dd"))}" +
                                    "'" + VT + "',";
                                    if (MarDefiPago == 1)
                                    {
                                        Utils.SqlDatos += "'" + "9" + "',";
                                    }
                                    else
                                    {
                                        Utils.SqlDatos += "'" + "1" + "',";
                                    }
                                    Utils.SqlDatos += "'" + "-" + "'," +
                                    "'" + PN + "'," +
                                    $"{Conexion.ValidarFechaNula(DateTime.Now.ToString("yyyy-MM-dd"))}" +
                                    "'" + lblCodigoUser.Text + "'" +
                                    ")";

                                    Conexion.SqlInsert(Utils.SqlDatos);

                                }
                            }

                            Utils.infNombreInforme = "Formato de los pagares";
                            Utils.NumPagaGlo = PN;
                            FrmReportes frmReportes = new FrmReportes();
                            frmReportes.ShowDialog();

                        }
                    }// if (GridDetalleRegistroCuotas.Rows.Count < 0)
                } //Dialogo
            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "despues de dar click en registrar" + "\r";
                Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private double ConverToDouble(string Numero)
        {
            try
            {

                return double.Parse(Numero, NumberStyles.Currency); 


            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "en la funcion Convert to double" + "\r";
                Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private void TxtValPaga_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Utils.Titulo01 = "Control de ejecución";
                if (double.Parse(TxtValNeto.Text, NumberStyles.Currency) <= 0)
                {
                    Utils.Informa = "LO SIENTO PERO EL VALOR TOTAL DEL PAGARE" + "\r";
                    Utils.Informa += "NO PUEDE SER MENOR O IGUAL A CERO (0)" + "\r";
                    Utils.Informa += "Por favor corrija el valor o pulse" + "\r";
                    Utils.Informa += "la tecla [ESC] para anular la acción." + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    CargaCuota();
                }
            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "despues de actualizar el valor total" + "\r";
                Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CboNomCueConta_SelectedIndexChanged(object sender, EventArgs e)
        {

            CboCuenConta.SelectedValue = CboNomCueConta.SelectedValue.ToString();



        }

        private void CboNomRespon_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Utils.SqlDatos = "SELECT ([TipoDocu] + [IdenProve]) AS Identi, [Datos proveedores].RazonSol, [Datos proveedores].TipoDocu, " +
                " [Datos proveedores].IdenProve, [Datos proveedores].SucurProv, " +
                " [Datos proveedores].HabilPro FROM [GEOGRAXPSQL].[dbo].[Datos proveedores] WHERE IdenProve = '" + CboNomRespon.SelectedValue.ToString() + "' ";

                SqlDataReader Prove = Conexion.SQLDataReader(Utils.SqlDatos);

                if (Prove.HasRows)
                {
                    Prove.Read();

                    CboTDRes.SelectedValue = Prove["TipoDocu"].ToString();
                    TxtDocuRespon.Text = Prove["IdenProve"].ToString();
                    TxtSucurRespon.Text = Prove["SucurProv"].ToString();
                }
            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "al buscar el responsable" + "\r";
                Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void CboNomCodeu_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Utils.SqlDatos = "SELECT ([TipoDocu] + [IdenProve]) AS Identi, [Datos proveedores].RazonSol, [Datos proveedores].TipoDocu, " +
                " [Datos proveedores].IdenProve, [Datos proveedores].SucurProv, " +
                " [Datos proveedores].HabilPro FROM [GEOGRAXPSQL].[dbo].[Datos proveedores] WHERE IdenProve = '" + CboNomCodeu.SelectedValue.ToString() + "' ";

                SqlDataReader Prove = Conexion.SQLDataReader(Utils.SqlDatos);

                if (Prove.HasRows)
                {
                    Prove.Read();

                    CboTDCodeu.SelectedValue = Prove["TipoDocu"].ToString();
                    TxtNumCodeu.Text = Prove["IdenProve"].ToString();
                    TxtSucurCode.Text = Prove["SucurProv"].ToString();
                }
            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "al buscar el codeudor" + "\r";
                Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCopias_Click(object sender, EventArgs e)
        {
            try
            {

                Utils.Titulo01 = "Expedir copias de un pagaré";

                FrmInputBox frmInputBox = new FrmInputBox();

                Utils.TextoInputBox = "Por favor digite el número del pagaré, al cual le desea sacar copias";

                frmInputBox.ShowDialog();

                if (string.IsNullOrWhiteSpace(Utils.ValueInput))
                {
                    //No digito anda
                }
                else
                {
                    Utils.infNombreInforme = "Formato de los pagares";
                    Utils.NumPagaGlo = Utils.ValueInput;
                    FrmReportes frmReportes = new FrmReportes();
                    frmReportes.ShowDialog();
                }


            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "al dar click en copias" + "\r";
                Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
