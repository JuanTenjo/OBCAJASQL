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
    public partial class FrmCajaDepositos : Form
    {
        public FrmCajaDepositos()
        {
            InitializeComponent();
        }

        #region Funcion

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
            private void CargarCombobox()
            {
                try
                {
                    this.cboTipDoTer.DataSource = null;
                    this.cboTipDoTer.Items.Clear();



                    Utils.SqlDatos = " SELECT[Datos documentos empresas].CodIdenti, [Datos documentos empresas].NomIdenti " +
                    " FROM [ACDATOXPSQL].[dbo].[Datos documentos empresas] " +
                    " ORDER BY [Datos documentos empresas].CodIdenti, [Datos documentos empresas].NomIdenti; ";

                    DataSet dataSet = Conexion.SQLDataSet(Utils.SqlDatos);

                    if (dataSet != null && dataSet.Tables.Count > 0)
                    {
                        this.cboTipDoTer.DataSource = dataSet.Tables[0];
                        this.cboTipDoTer.ValueMember = "CodIdenti";
                        this.cboTipDoTer.DisplayMember = "NomIdenti";
                    }


                    Utils.SqlDatos = " SELECT [Datos tipos de usuarios].CodTipoUsuar, [Datos tipos de usuarios].NomTipo FROM [ACDATOXPSQL].[dbo].[Datos tipos de usuarios] ORDER BY  [Datos tipos de usuarios].NomTipo;";

                    DataSet dataSet4 = Conexion.SQLDataSet(Utils.SqlDatos);

                    if (dataSet4 != null && dataSet4.Tables.Count > 0)
                    {
                        this.CboRegimUsua.DataSource = dataSet4.Tables[0];
                        this.CboRegimUsua.ValueMember = "CodTipoUsuar";
                        this.CboRegimUsua.DisplayMember = "NomTipo";
                    }

                    Utils.SqlDatos = " SELECT [Datos de los bancos].CodiBanco, [Datos de los bancos].NomBanco FROM [GEOGRAXPSQL].[dbo].[Datos de los bancos] ORDER BY [Datos de los bancos].NomBanco;";

                    DataSet dataSet5 = Conexion.SQLDataSet(Utils.SqlDatos);

                    if (dataSet5 != null && dataSet5.Tables.Count > 0)
                    {
                        this.CboLIstaBancos.DataSource = dataSet5.Tables[0];
                        this.CboLIstaBancos.ValueMember = "CodiBanco";
                        this.CboLIstaBancos.DisplayMember = "NomBanco";
                    }

                    Utils.SqlDatos = "SELECT [Datos ctas contables IPS].CueContaIPS,  " +
                    " [Datos ctas contables IPS].NomCConIPS " +
                    " FROM [GEOGRAXPSQL].[dbo].[Datos ctas contables IPS] WHERE ((([Datos ctas contables IPS].CueContaIPS) <> '0000000')) " +
                    " ORDER BY[Datos ctas contables IPS].NomCConIPS; ";

                    DataSet dataSet6 = Conexion.SQLDataSet(Utils.SqlDatos);

                    if (dataSet6 != null && dataSet6.Tables.Count > 0)
                    {
                        this.CboNumCuenDepo.DataSource = dataSet6.Tables[0];
                        this.CboNumCuenDepo.ValueMember = "CueContaIPS";
                        this.CboNumCuenDepo.DisplayMember = "NomCConIPS";
                    }


                    this.CboFinDepo.DataSource = null;
                    this.CboFinDepo.Items.Clear();

                    Utils.SqlDatos = " SELECT [Datos fin de los depositos].CodFinDepo, " +
                    " [Datos fin de los depositos].NomFinDepo FROM [BDCAJASQL].[dbo].[Datos fin de los depositos] " +
                    " WHERE ((([Datos fin de los depositos].HabilDepo) = 'True')) " +
                    " ORDER BY[Datos fin de los depositos].NomFinDepo; ";

                    DataSet dataSet7 = Conexion.SQLDataSet(Utils.SqlDatos);

                    if (dataSet7 != null && dataSet7.Tables.Count > 0)
                    {
                        this.CboFinDepo.DataSource = dataSet7.Tables[0];
                        this.CboFinDepo.ValueMember = "CodFinDepo";
                        this.CboFinDepo.DisplayMember = "NomFinDepo";
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
            private void BuscarPacientes()
            {
                try
                {
                    string SqlPacientes = "SELECT Nombre1, Nombre2, Apellido1, Apellido2, TipoUsar ";
                    SqlPacientes = SqlPacientes + "FROM [ACDATOXPSQL].[dbo].[Datos del Paciente] ";
                    SqlPacientes = SqlPacientes + "WHERE HistorPaci= '" + TxtHisUsa.Text + "' ";
                    SqlPacientes = SqlPacientes + "ORDER BY HistorPaci";


                    SqlDataReader TabPacientes;
                    //    SqlDataReader TabUsuaTemp = Conexion.SQLDataReader(SqlsuaTemp);

                    using (SqlConnection connection2 = new SqlConnection(Conexion.conexionSQL))
                    {
                        SqlCommand command2 = new SqlCommand(SqlPacientes, connection2);
                        command2.Connection.Open();
                        TabPacientes = command2.ExecuteReader();

                        if (TabPacientes.HasRows)
                        {
                            TabPacientes.Read();

                            TxtNomUsaDepo.Text = TabPacientes["Nombre1"].ToString() + " " + TabPacientes["Nombre2"].ToString() + " " + TabPacientes["Apellido1"].ToString() + " " + TabPacientes["Apellido2"].ToString();
                            CboRegimUsua.SelectedValue = TabPacientes["TipoUsar"].ToString();

                        }
                        else
                        {
                            Utils.Titulo01 = "Control de ejecución";
                            Utils.Informa = "Lo siento pero el número de historia" + "\r";
                            Utils.Informa += "codigitado no existe en este sistema. " + "\r";
                            Utils.Informa += "Por favor corrija el número o pulse" + "\r";
                            Utils.Informa += "la tecla [ESC] para continuar." + "\r";
                            MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                }
                catch (Exception ex)
                {
                    Utils.Titulo01 = "Control de errores de ejecución";
                    Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                    Utils.Informa += "en la funcion BuscarPacientes" + "\r";
                    Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        #endregion

        #region RadioButton

        private void RbEfect_CheckedChanged(object sender, EventArgs e)
        {
            FormaPago = 1;
            CboLIstaBancos.Visible = false;
            TxtNumDocumentoP.Visible = false;
            TxtCenCajaD.Text = "111";
            TxtCtaConD.Text = "110501";
        }

        private void RbCheque_CheckedChanged(object sender, EventArgs e)
        {
            FormaPago = 2;
            CboLIstaBancos.Visible = true;
            TxtNumDocumentoP.Visible = true;
            LblDocumentoPago.Text = "Cheque No.";
            TxtCenCajaD.Text = "111";
            TxtCtaConD.Text = "110501";
        }

        private void RbTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            FormaPago = 3;
            CboLIstaBancos.Visible = true;
            TxtNumDocumentoP.Visible = true;

            LblDocumentoPago.Text = "Recibo No.";

            TxtCenCajaD.Text = "112";
            TxtCtaConD.Text = "112005";
        }

        private void RbBonos_CheckedChanged(object sender, EventArgs e)
        {
            FormaPago = 4;
            CboLIstaBancos.Visible = false;
            TxtNumDocumentoP.Visible = false;

            TxtCenCajaD.Text = "112";
            TxtCtaConD.Text = "112005";
        }

        #endregion

        #region Botones
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        #endregion


        int FormaPago = 1;
        private void FrmCajaDepositos_Load(object sender, EventArgs e)
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
                Utils.Informa += "al abrir el formulario Caja Depositos" + "\r";
                Utils.Informa += "Error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtHistoriaNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((int)e.KeyChar == (int)Keys.Enter)
                {
                    if (string.IsNullOrWhiteSpace(TxtHisUsa.Text) == false)
                    {
                        BuscarPacientes();
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
                Utils.Informa += "después intentar buscar el numero de historia" + "\r";
                Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buscarTercero()
        {
            try
            {
                Utils.Titulo01 = "Control para registrar datos";

                if (string.IsNullOrWhiteSpace(TxtNitCCTer.Text))
                {
                    Utils.Informa = "Lo siento pero este campo no puede contener" + "\r";
                    Utils.Informa += "un valor nulo o vacío. Por favor corrija el" + "\r";
                    Utils.Informa += "número o pulse la tecla [ESC] para continuar." + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string CNT = TxtNitCCTer.Text;



                //Revisamos si ya selecciono el tipo de documento

                if (cboTipDoTer.SelectedIndex == -1)
                {
                    Utils.Informa = "Lo siento pero usted no ha seleccionado" + "\r";
                    Utils.Informa += "el tipo de documento del tercero, por lo tanto" + "\r";
                    Utils.Informa += "no se puede validar si existe o no." + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string TDT = cboTipDoTer.SelectedValue.ToString();


                if (string.IsNullOrWhiteSpace(TxtCarem.Text))
                {
                    Utils.Informa = "Lo siento pero usted no ha digitado el" + "\r";
                    Utils.Informa += "código de la sucursal del tercero, por lo" + "\r";
                    Utils.Informa += "tanto no se puede validar si existe o no." + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string SucurTer = TxtCarem.Text;

                //Procede a buscarlo en la base de datos


                string SqlEmpTer = "SELECT RazonSol, SucurProv, TipoDocu " +
                " FROM [GEOGRAXPSQL].[dbo].[Datos proveedores] " +
                " WHERE TipoDocu = '" + TDT + "' AND IdenProve = '" + CNT + "'  AND SucurProv = '" + SucurTer + "' " +
                " ORDER BY TipoDocu, IdenProve, SucurProv ";

                SqlDataReader TabEmpTer;
                //    SqlDataReader TabUsuaTemp = Conexion.SQLDataReader(SqlsuaTemp);

                using (SqlConnection connection2 = new SqlConnection(Conexion.conexionSQL))
                {
                    SqlCommand command2 = new SqlCommand(SqlEmpTer, connection2);
                    command2.Connection.Open();
                    TabEmpTer = command2.ExecuteReader();

                    if (TabEmpTer.HasRows)
                    {
                        TabEmpTer.Read();

                        TxtNomTerDepo.Text = TabEmpTer["RazonSol"].ToString();
                        TxtCarem.Text = TabEmpTer["SucurProv"].ToString();

                    }
                }
            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "en la funcion buscarTercero" + "\r";
                Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void TxtNitCCTer_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((int)e.KeyChar == (int)Keys.Enter)
                {
                    buscarTercero();
                }
            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "despues de dar enter en el numero de CC o Nit" + "\r";
                Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBuscarPaci_Click(object sender, EventArgs e)
        {
            try
            {

                FrmBuscarPacientes frmBuscarPacientes = new FrmBuscarPacientes();
                frmBuscarPacientes.ShowDialog();

                TxtHisUsa.Text = Utils.HistoriaNumero;

                if (string.IsNullOrWhiteSpace(TxtHisUsa.Text) == false)
                {
                    BuscarPacientes();
                }

            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "de hacer click sobre el botón de pacientes" + "\r";
                Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBuscarTercer_Click(object sender, EventArgs e)
        {
            try
            {

                FrmBuscarTerceros frmBuscarTerceros = new FrmBuscarTerceros();
                frmBuscarTerceros.ShowDialog();

                cboTipDoTer.SelectedValue = Utils.TipDocFac;
                TxtNitCCTer.Text = Utils.NitCC;
                TxtCarem.Text = Utils.SucurTer;

                buscarTercero();

            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "de hacer click sobre el botón de buscar terceros" + "\r";
                Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRegistraCaja_Click(object sender, EventArgs e)
        {
            try
            {
                int proce = 0;
                string His = "", CCon = "", Para05 = "", SqlDepoPaci = "", SqlReciCaja = "", QPaga = "", FunReciNum = "", CodCa ="", DetaPago = "", ND01 = "", NomReci = "",SqlTerceros = "", ForPa = "", BN01 = "",Tipag = "", Enti = "", NumEnti = "", Cuencaja = "", CenCaja = "", CCos = "110", NCC = "", TD = "", CarT = "", PaReg = "", Paci02 = "", FD = "", UsReci = "";
                int CanReg = 1;
                double Por01 = 0;
                bool estaRegis;
                int X = 4; //No afecta a ningún documento cruce
                int Y = 0; //Número de documento cruce.
                int Z = 3; //Paga deposito

                Utils.Titulo01 = "Control para expedir facturas";

                if (string.IsNullOrWhiteSpace(LblCodCajAct.Text))
                {
                    Utils.Informa = "Lo siento pero mientras no se tenga" + "\r";
                    Utils.Informa = "definida la identificación de la caja," + "\r";
                    Utils.Informa = "no se puede realizar este proceso." + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                CodCa = LblCodCajAct.Text;

                if (string.IsNullOrWhiteSpace(TxtHisUsa.Text))
                {
                    Utils.Informa = "Lo siento pero usted no ha digitado un número de historia válido" + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(TxtNomUsaDepo.Text))
                {
                    Utils.Informa = "Lo siento pero el número de historia digitado no tiene un nombre válido" + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if(cboTipDoTer.SelectedIndex == -1)
                {
                    Utils.Informa = "Lo siento pero usted no ha digitado tipo de documento del tercero que realiza el pago" + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(TxtNitCCTer.Text))
                {
                    Utils.Informa = "Lo siento pero usted no ha digitado un número de Nit o CC válido para expedir el recibo de caja" + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (CboNumCuenDepo.SelectedIndex == -1)
                {
                    Utils.Informa = "Lo siento pero usted no ha digitado el número de cuenta contable para el depósito" + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(TxtValorPagos.Text))
                {
                    Utils.Informa = "Lo siento pero usted no digitado el valor del depósito" + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (CboFinDepo.SelectedIndex == -1)
                {
                    Utils.Informa = "Lo siento pero usted no ha seleccionado el fin del depósito" + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if(Convert.ToInt32(TxtValorPagos.Text) < 0)
                {
                    Utils.Informa = "Lo siento pero el valor del depósito debe ser siempre mayor a cero (0)" + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                His = TxtHisUsa.Text;
                CCon = CboNumCuenDepo.SelectedValue.ToString();
                NCC = TxtNitCCTer.Text;
                TD = cboTipDoTer.SelectedValue.ToString();
                CarT = TxtCarem.Text;
                PaReg = TxtValorPagos.Text;
                Paci02 = TxtNomUsaDepo.Text;
                FD = CboFinDepo.SelectedValue.ToString();
                UsReci = lblCodigoUser.Text;

                Cuencaja = TxtCtaConD.Text;
                CenCaja = TxtCenCajaD.Text;

                switch (FormaPago)
                {
                    case 1: //Pago en efectivo
                        ForPa = "Pago en efectivo";
                        Tipag = "EF";
                        Enti = null;
                        NumEnti = null;
                        break;

                    case 2: //Pago en cheque

                        BN01 = CboLIstaBancos.SelectedValue.ToString();
                        if (string.IsNullOrWhiteSpace(BN01))
                        {
                            Utils.Informa = "Lo siento pero usted no ha seleccionado el nombre de la entidad bancaria" + "\r";
                            MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        ND01 = TxtNumDocumentoP.Text;
                        if (string.IsNullOrWhiteSpace(ND01))
                        {
                            Utils.Informa = "Lo siento pero usted no ha digitado el número del cheque" + "\r";
                            MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        ForPa = "Pago con cheque del " + CboLIstaBancos.Text;
                        Tipag = "CH";
                        Enti = CboLIstaBancos.Text;
                        NumEnti = TxtNumDocumentoP.Text;
                        break;
                    case 3: //Pago con tarjeta de credito

                        BN01 = CboLIstaBancos.SelectedValue.ToString();
                        if (string.IsNullOrWhiteSpace(BN01))
                        {
                            Utils.Informa = "Lo siento pero usted no ha seleccionado el nombre de la entidad bancaria" + "\r";
                            MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        ND01 = TxtNumDocumentoP.Text;
                        if (string.IsNullOrWhiteSpace(ND01))
                        {
                            Utils.Informa = "Lo siento pero usted no ha digitado el número del cheque" + "\r";
                            MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        ForPa = "Pago con tarjeta de crédito " + CboLIstaBancos.Text;
                        Tipag = "TC";
                        Enti = CboLIstaBancos.Text;
                        NumEnti = TxtNumDocumentoP.Text;

                        break;
                    case 4: //Pago con bono
                        ForPa = "Pago con bonos ";
                        Tipag = "BO";
                        Enti = null;
                        NumEnti = null;
                        break;
                    default:
                        break;
                }

                //Revisamos el documento de identificación del tercero existe, en la tabla de proveedores

                SqlTerceros = "SELECT TipoDocu, IdenProve, SucurProv, RazonSol ";
                SqlTerceros = SqlTerceros + "FROM [GEOGRAXPSQL].[dbo].[Datos proveedores] ";
                SqlTerceros = SqlTerceros + "WHERE TipoDocu='" + TD + "' AND IdenProve='" + NCC + "'  AND SucurProv='" + CarT + "' ";
                SqlTerceros = SqlTerceros + "ORDER BY TipoDocu";


                using (SqlConnection connection = new SqlConnection(Conexion.conexionSQL))
                {
                    SqlCommand command = new SqlCommand(SqlTerceros, connection);
                    command.Connection.Open();
                    SqlDataReader TabTerceros = command.ExecuteReader();

                    if(TabTerceros.HasRows == false)
                    {
                        Utils.Informa = "Lo siento pero el documento de" + "\r";
                        Utils.Informa = "identificación del recibo de caja" + "\r";
                        Utils.Informa = "a registrar, no existe en la base" + "\r";
                        Utils.Informa = "de datos de terceros, por lo tanto" + "\r";
                        Utils.Informa = "no se puede realizar el recibo." + "\r";
                        MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        TabTerceros.Read();
                        NomReci = TabTerceros["RazonSol"].ToString();
                    }

                    Utils.Informa = "¿Usted desea registrar un depósito" + "\r";
                    Utils.Informa = "para " + FD + "al usuario " + "\r";
                    Utils.Informa =  Paci02 + "\r";
                    Utils.Informa = "por La suma de " + PaReg + "\r";
                    Utils.Informa = "Forma de pago " + ForPa +"?"+ "\r";
                    var res = MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    DetaPago = "Depósito para " + FD;
                    Por01 = 100;
                    if(res == DialogResult.Yes)
                    {
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
                                //Puede seguir porque registro un recibo de caja bien
                                //Proceda a grabar los datos del recibo del recibo de caja
                                QPaga = "Depósitos";

                                SqlReciCaja = "SELECT * FROM [BDCAJASQL].[dbo].[Datos recibos de caja] ";
                                SqlReciCaja = SqlReciCaja + "WHERE ReciboCaja = '" + FunReciNum + "' ";
                                SqlReciCaja = SqlReciCaja + "ORDER BY ReciboCaja";

                              
                                using (SqlConnection connection2 = new SqlConnection(Conexion.conexionSQL))
                                {
                                    SqlCommand command2 = new SqlCommand(SqlTerceros, connection2);
                                    command2.Connection.Open();
                                    SqlDataReader TabReciCaja = command2.ExecuteReader();


                                    if(TabReciCaja.HasRows == false)
                                    {
                                        proce = 1;
                                    }
                                    else
                                    {
                                        Utils.Informa = "Lo siento pero el número de recibo de caja";
                                        Utils.Informa += "generado por el sistema ya existe.";
                                        Utils.Informa += "Favor comunicarse con el area de sistemas";
                                        MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }

                                if(proce == 1)
                                {
                                    Utils.SqlDatos = "INSERT INTO [BDCAJASQL].[dbo].[Datos recibos de caja]" +
                                    "(" +
                                    "ReciboCaja," +
                                    "CodCaja," +
                                    "HistorPaciente," +
                                    "RegRecibe," +
                                    "TipoDocu," +
                                    "NumDocu," +
                                    "SucuDocu," +
                                    "TipDocu," +
                                    "DocuCruce," +
                                    "TipoPago," +
                                    "TipoPagoCaja," +
                                    "DocumNumero," +
                                    "EntidadDocumen," +
                                    "ElPagoEsPor," +
                                    "FechaPagoCaja," +
                                    "FecRegis," +
                                    "CodRegis," +
                                    "AnuladoRecibo" +
                                    ")" +
                                    "VALUES" +
                                    "(" +
                                    "'" + FunReciNum + "'," +
                                    "'" + CodCa + "'," +
                                    "'" + His + "'," +
                                    "'" + CboRegimUsua.SelectedValue.ToString() + "'," +
                                    "'" + TD + "'," +
                                    "'" + NCC + "'," +
                                    "'" + CarT + "'," +
                                    "'" + X + "'," +
                                    "'" + Y + "'," +
                                    "'" + Z + "'," +
                                    "'" + Tipag + "'," +
                                    "'" + NumEnti + "'," +
                                    "'" + Enti + "'," +
                                    "'" + QPaga + "'," +
                                    $"{Conexion.ValidarFechaNula(DateTime.Now.ToString("yyyy-MM-dd"))}" +
                                    $"{Conexion.ValidarFechaNula(DateTime.Now.ToString("yyyy-MM-dd"))}" +
                                    "'" + UsReci + "'," +
                                    "'" + false + "'" +
                                    ")";

                                     estaRegis = Conexion.SqlInsert(Utils.SqlDatos);
                                }

                                //Siga a grabar el detalle y el depósito en las tablas respectivas
                                //Proceda a grabar la doble partida

                                List<SqlParameter> parameters = new List<SqlParameter>();


                                Utils.SqlDatos = "INSERT [BDCAJASQL].[dbo].[Datos detalles recibos de caja] (ReciboNum,CuentaContable,DetaPagoCaja,CentroCosto,CantidadCaja,PorcenPago,ValorUnitaCaja,NatuMovi,DebiCaja) ";
                                Utils.SqlDatos += "VALUES (@ReciboNum,@CuentaContable,@DetaPagoCaja,@CentroCosto,@CantidadCaja,@PorcenPago,@ValorUnitaCaja,@NatuMovi,@DebiCaja)";


                                parameters = new List<SqlParameter>
                                        {
                                            new SqlParameter("@ReciboNum", SqlDbType.VarChar){ Value = FunReciNum},
                                            new SqlParameter("@CuentaContable", SqlDbType.VarChar){ Value = Cuencaja },
                                            new SqlParameter("@DetaPagoCaja", SqlDbType.VarChar){ Value = DetaPago},
                                            new SqlParameter("@CentroCosto", SqlDbType.VarChar){ Value = CenCaja},
                                            new SqlParameter("@CantidadCaja", SqlDbType.VarChar){ Value = CanReg},
                                            new SqlParameter("@PorcenPago", SqlDbType.VarChar){ Value = Por01},
                                            new SqlParameter("@ValorUnitaCaja", SqlDbType.VarChar){ Value = 0},
                                            new SqlParameter("@NatuMovi", SqlDbType.VarChar){ Value = "D"},
                                            new SqlParameter("@DebiCaja", SqlDbType.VarChar){ Value = PaReg},
                                        };

                                estaRegis = Conexion.SqlInsert(Utils.SqlDatos, parameters);

                                parameters = new List<SqlParameter>
                                        {
                                            new SqlParameter("@ReciboNum", SqlDbType.VarChar){ Value = FunReciNum},
                                            new SqlParameter("@CuentaContable", SqlDbType.VarChar){ Value = CCon },
                                            new SqlParameter("@DetaPagoCaja", SqlDbType.VarChar){ Value = DetaPago},
                                            new SqlParameter("@CentroCosto", SqlDbType.VarChar){ Value = CCos},
                                            new SqlParameter("@CantidadCaja", SqlDbType.VarChar){ Value = CanReg},
                                            new SqlParameter("@PorcenPago", SqlDbType.VarChar){ Value = Por01},
                                            new SqlParameter("@ValorUnitaCaja", SqlDbType.VarChar){ Value = PaReg},
                                            new SqlParameter("@NatuMovi", SqlDbType.VarChar){ Value = "C"},
                                            new SqlParameter("@DebiCaja", SqlDbType.VarChar){ Value = 0},
                                        };

                                estaRegis = Conexion.SqlInsert(Utils.SqlDatos, parameters);


              
                                //Proceda a registrar el depósito

                                SqlDepoPaci = "SELECT * FROM [BDCAJASQL].[dbo].[Datos depositos a usuarios] ";
                                SqlDepoPaci = SqlDepoPaci + "WHERE ReciCaja='" + FunReciNum + "' ";
                                SqlDepoPaci = SqlDepoPaci + "ORDER BY ReciCaja";


                                using (SqlConnection connection2 = new SqlConnection(Conexion.conexionSQL))
                                {
                                    SqlCommand command2 = new SqlCommand(SqlDepoPaci, connection2);
                                    command2.Connection.Open();
                                    SqlDataReader TabDepoPaci = command2.ExecuteReader();

                                    if(TabDepoPaci.HasRows == false)
                                    {
                                        proce = 1;
                                    }
                                    else
                                    {
                                        proce = 0;
                                    }

                                }

                                if(proce == 1)
                                {
                                    Utils.SqlDatos = "INSERT INTO [BDCAJASQL].[dbo].[Datos depositos a usuarios]" +
                                    "(" +
                                    "ReciCaja," +
                                    "HisDepo," +
                                    "ValDepo," +
                                    "FecDepo," +
                                    "FinDepo," +
                                    "Saldepo," +
                                    "FecRegis," +
                                    "CodiRegis" +
                                    ")" +
                                    "VALUES" +
                                    "(" +
                                    "'" + FunReciNum + "'," +
                                    "'" + His + "'," +
                                    "'" + PaReg + "'," +
                                    $"{Conexion.ValidarFechaNula(DateTime.Now.ToString("yyyy-MM-dd"))}" +
                                    "'" + CboFinDepo.SelectedValue.ToString() + "'," +
                                    "'" + PaReg + "'," +
                                     $"{Conexion.ValidarFechaNula(DateTime.Now.ToString("yyyy-MM-dd"))}" +
                                    "'" + UsReci + "'" +
                                    ")";

                                    estaRegis = Conexion.SqlInsert(Utils.SqlDatos);
                                }
                                else
                                {
                                    //El usuario ya tiene un deposito registrado con el mismo recibo

                                    Utils.Informa = "Por favor tenga en cuenta que ya el usuario tiene";
                                    Utils.Informa += "registrado un depósito con el mismo número de recibo.";
                                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }


                                //Proceda a imprimir el recibo
                                Utils.condicion = "[BDCAJASQL].[dbo].[Datos recibos de caja].ReciboCaja = " + FunReciNum;

                                TxtHisUsa.Text = "";
                                TxtNomUsaDepo.Text = "";
                                TxtNitCCTer.Text = "";
                                TxtNomTerDepo.Text = "";
                                TxtValorPagos.Text = "";
                                TxtHisUsa.Text = "";

                                string infoCajaSql = "SELECT [Datos recibos de caja].ReciboCaja, [Datos recibos de caja].HistorPaciente, " +
                                " Trim([Apellido1] + ' ' + [Apellido2]) + ' ' + Trim([Nombre1] + ' ' + [Nombre2]) AS Paciente, " +
                                " [Datos recibos de caja].TipoDocu, [Datos recibos de caja].NumDocu, [Datos recibos de caja].SucuDocu, " +
                                " [Datos proveedores].RazonSol, [Datos recibos de caja].DocumNumero, [Datos recibos de caja].EntidadDocumen, " +
                                " [Datos recibos de caja].FechaPagoCaja, [Datos recibos de caja].CodRegis, [Datos detalles recibos de caja].CodServi, " +
                                " [Datos detalles recibos de caja].DetaPagoCaja, [Datos detalles recibos de caja].CantidadCaja, [Datos detalles recibos de caja].ValorUnitaCaja, " +
                                " ([CuentaContable] + '-' + [CentroCosto]) AS CuenCenT, ([CantidadCaja]*[ValorUnitaCaja]) AS VT, [Datos recibos de caja].AnuladoRecibo, " +
                                " [Datos recibos de caja].FechAnulado, [Datos recibos de caja].CodiAnul, [Datos recibos de caja].RazonAnula, " +
                                " [Datos recibos de caja].ObserCaja FROM [GEOGRAXPSQL].[dbo].[Datos proveedores] INNER JOIN (([ACDATOXPSQL].[dbo].[Datos del Paciente] " +
                                " INNER JOIN [BDCAJASQL].[dbo].[Datos recibos de caja] ON [Datos del Paciente].HistorPaci = [Datos recibos de caja].HistorPaciente) " +
                                " INNER JOIN [BDCAJASQL].[dbo].[Datos detalles recibos de caja] ON [Datos recibos de caja].ReciboCaja = [BDCAJASQL].[dbo].[Datos detalles recibos de caja].ReciboNum) " +
                                " ON ([Datos proveedores].TipoDocu = [Datos recibos de caja].TipoDocu) AND ([Datos proveedores].IdenProve = [Datos recibos de caja].NumDocu) " +
                                " AND ([Datos proveedores].SucurProv = [Datos recibos de caja].SucuDocu) " +
                                " WHERE ((([Datos detalles recibos de caja].ValorUnitaCaja) > 0)) AND " + Utils.Condicion + " ORDER BY [Datos recibos de caja].ReciboCaja; ";

                                Utils.SqlDatos = infoCajaSql;
                                Utils.infNombreInforme = "Informe recibos de cajas";

                                FrmReciboDeCajas frmReciboDeCajas2 = new FrmReciboDeCajas();
                                frmReciboDeCajas2.ShowDialog();


                                break;
                        }//End Swich
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "de hacer click sobre el botón de registrar" + "\r";
                Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCopias_Click(object sender, EventArgs e)
        {
            try
            {
                string SqlReciCaja = "", ReciCaja = "", Tipofactura = "", infoCajaSql = "", NomInfoCa = "";
                int ConTiPro = 0;

                FrmInputReciboCaja frmInputReciboCaja = new FrmInputReciboCaja();
                frmInputReciboCaja.ShowDialog();

                ReciCaja = Utils.ReciboCaja;

                if (string.IsNullOrWhiteSpace(ReciCaja))
                {
                    //No dijito nada
                }
                else
                {
                    SqlReciCaja = "SELECT * FROM [BDCAJASQL].[dbo].[Datos recibos de caja] ";
                    SqlReciCaja = SqlReciCaja + "WHERE ReciboCaja = '" + ReciCaja + "' ";
                    SqlReciCaja = SqlReciCaja + "ORDER BY ReciboCaja";

                    using (SqlConnection connection = new SqlConnection(Conexion.conexionSQL))
                    {
                        SqlCommand command = new SqlCommand(SqlReciCaja, connection);
                        command.Connection.Open();
                        SqlDataReader TabReciCaja = command.ExecuteReader();

                        if (TabReciCaja.HasRows == false)
                        {
                            Utils.Informa = "Lo siento pero el número de recibo " + ReciCaja + "\r";
                            Utils.Informa += "no se encuentrada registrado en este sistema." + "\r";
                            MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ConTiPro = 0;
                        }
                        else
                        {
                            TabReciCaja.Read();

                            //Proceda a mostrar el recibo No operativos u otros pagos

                            Tipofactura = TabReciCaja["TipDocu"].ToString();


                            Utils.Condicion = "[BDCAJASQL].[dbo].[Datos recibos de caja].[ReciboCaja] = '" + ReciCaja + "'";

                            switch (Tipofactura)
                            {
                                case "5":

                                    infoCajaSql = "SELECT [Datos recibos de caja].ReciboCaja, [Datos recibos de caja].HistorPaciente, " +
                                  " Trim([Apellido1] + ' ' + [Apellido2]) + ' ' + Trim([Nombre1] + ' ' + [Nombre2]) AS Paciente, " +
                                  " [Datos recibos de caja].TipoDocu, [Datos recibos de caja].NumDocu, [Datos recibos de caja].SucuDocu, " +
                                  " [Datos proveedores].RazonSol, [Datos recibos de caja].DocumNumero, [Datos recibos de caja].EntidadDocumen, " +
                                  " [Datos recibos de caja].FechaPagoCaja, [Datos recibos de caja].CodRegis, [Datos detalles recibos de caja].CodServi, " +
                                  " [Datos detalles recibos de caja].DetaPagoCaja, [Datos detalles recibos de caja].CantidadCaja, [Datos detalles recibos de caja].ValorUnitaCaja, " +
                                  " ([CuentaContable] + '-' + [CentroCosto]) AS CuenCenT, ([CantidadCaja]*[ValorUnitaCaja]) AS VT, [Datos recibos de caja].AnuladoRecibo, " +
                                  " [Datos recibos de caja].FechAnulado, [Datos recibos de caja].CodiAnul, [Datos recibos de caja].RazonAnula, " +
                                  " [Datos recibos de caja].ObserCaja FROM [GEOGRAXPSQL].[dbo].[Datos proveedores] INNER JOIN (([ACDATOXPSQL].[dbo].[Datos del Paciente] " +
                                  " INNER JOIN [BDCAJASQL].[dbo].[Datos recibos de caja] ON [Datos del Paciente].HistorPaci = [Datos recibos de caja].HistorPaciente) " +
                                  " INNER JOIN [BDCAJASQL].[dbo].[Datos detalles recibos de caja] ON [Datos recibos de caja].ReciboCaja = [BDCAJASQL].[dbo].[Datos detalles recibos de caja].ReciboNum) " +
                                  " ON ([Datos proveedores].TipoDocu = [Datos recibos de caja].TipoDocu) AND ([Datos proveedores].IdenProve = [Datos recibos de caja].NumDocu) " +
                                  " AND ([Datos proveedores].SucurProv = [Datos recibos de caja].SucuDocu) " +
                                  " WHERE ((([Datos detalles recibos de caja].ValorUnitaCaja) > 0)) AND " + Utils.Condicion + " ORDER BY [Datos recibos de caja].ReciboCaja; ";

                                    NomInfoCa = "Informe recibos de cajas preformateado IngOp";

                                    break;
                                default:


                             
                                        infoCajaSql = "SELECT [Datos recibos de caja].ReciboCaja, [Datos recibos de caja].HistorPaciente, " +
                                        " Trim([Apellido1] + ' ' + [Apellido2]) + ' ' + Trim([Nombre1] + ' ' + [Nombre2]) AS Paciente, " +
                                        " [Datos recibos de caja].TipoDocu, [Datos recibos de caja].NumDocu, [Datos recibos de caja].SucuDocu, " +
                                        " [Datos proveedores].RazonSol, [Datos recibos de caja].DocumNumero, [Datos recibos de caja].EntidadDocumen, " +
                                        " [Datos recibos de caja].FechaPagoCaja, [Datos recibos de caja].CodRegis, [Datos detalles recibos de caja].CodServi, " +
                                        " [Datos detalles recibos de caja].DetaPagoCaja, [Datos detalles recibos de caja].CantidadCaja, [Datos detalles recibos de caja].ValorUnitaCaja, " +
                                        " ([CuentaContable] + '-' + [CentroCosto]) AS CuenCenT, ([CantidadCaja]*[ValorUnitaCaja]) AS VT, [Datos recibos de caja].AnuladoRecibo, " +
                                        " [Datos recibos de caja].FechAnulado, [Datos recibos de caja].CodiAnul, [Datos recibos de caja].RazonAnula, " +
                                        " [Datos recibos de caja].ObserCaja FROM [GEOGRAXPSQL].[dbo].[Datos proveedores] INNER JOIN (([ACDATOXPSQL].[dbo].[Datos del Paciente] " +
                                        " INNER JOIN [BDCAJASQL].[dbo].[Datos recibos de caja] ON [Datos del Paciente].HistorPaci = [Datos recibos de caja].HistorPaciente) " +
                                        " INNER JOIN [BDCAJASQL].[dbo].[Datos detalles recibos de caja] ON [Datos recibos de caja].ReciboCaja = [BDCAJASQL].[dbo].[Datos detalles recibos de caja].ReciboNum) " +
                                        " ON ([Datos proveedores].TipoDocu = [Datos recibos de caja].TipoDocu) AND ([Datos proveedores].IdenProve = [Datos recibos de caja].NumDocu) " +
                                        " AND ([Datos proveedores].SucurProv = [Datos recibos de caja].SucuDocu) " +
                                        " WHERE ((([Datos detalles recibos de caja].ValorUnitaCaja) > 0)) AND " + Utils.Condicion + " ORDER BY [Datos recibos de caja].ReciboCaja; ";

                                        NomInfoCa = "Informe recibos de cajas";
                                   

                                    break;
                            }

                            //Proceda a mostrar el recibo
                            ConTiPro = 1;
                        }
                    }

                    //Muestre el recibo
                    if (ConTiPro == 1)
                    {
                        Utils.SqlDatos = infoCajaSql;
                        Utils.infNombreInforme = NomInfoCa;
                        Report.FrmReciboDeCajas frm = new Report.FrmReciboDeCajas();
                        frm.ShowDialog();

                    }

                }



            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "hacer click sobre el botón copias" + "\r";
                Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
