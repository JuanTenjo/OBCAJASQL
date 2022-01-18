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
    public partial class FrmCajaGeneral : Form
    {
        public FrmCajaGeneral()
        {
            InitializeComponent();
        }

        #region Funciones

        private int ContabiReciCajaST(string RelaNum, string PreD, string CD)
        {
            try
            {
                //**************** Creada el 16 de Diciembre de 2015 ***********************************
                //Reescrita en c# **************** el 21 de Diciembre de 2021 ***********************************
                int ConTiPro = 0, ItemGra = 0, CuanOrde = 0, CuanConta = 0;
                double ValDebitos = 0, VCreditos = 0, ValtolBruto = 0;
                string DFEc1 = "", SqlCMDAnoMovi = "", MFEc1 = "", FecDOc = "", DocAfNota = "", ItemConver = "", DocNoCon = "", AFEc1 = "", RelCruce = "", MFEc = "", DFEc = "", AFEc = "", M = "", V = "";
                string DetaPagoCaja = "";
                string SqlReciCaja01 = "SELECT [Datos recibos de caja].ReciboCaja, [Datos recibos de caja].CodCaja, [Datos recibos de caja].HistorPaciente, ";
                SqlReciCaja01 += "[Datos recibos de caja].TipoDocu, [Datos recibos de caja].NumDocu, [Datos recibos de caja].CardiNitCC, [Datos recibos de caja].TipDocu, ";
                SqlReciCaja01 += "[Datos recibos de caja].DocuCruce, [Datos recibos de caja].TipoPagoCaja, [Datos recibos de caja].DocumNumero, ";
                SqlReciCaja01 += "[Datos recibos de caja].EntidadDocumen, [Datos recibos de caja].FechaPagoCaja, [Datos recibos de caja].TipoPago, ";
                SqlReciCaja01 += "[Datos recibos de caja].ElPagoEsPor, [Datos recibos de caja].AnuladoRecibo, [Datos recibos de caja].SucuDocu ";
                SqlReciCaja01 += "FROM [BDCAJASQL].[dbo].[Datos recibos de caja] ";
                SqlReciCaja01 += "WHERE ((([Datos recibos de caja].ReciboCaja) = '" + RelaNum + "') And (([Datos recibos de caja].AnuladoRecibo) = 0)) ";
                SqlReciCaja01 += "ORDER BY [Datos recibos de caja].ReciboCaja;";

                DataTable datatable = Conexion.SQLDataTable(SqlReciCaja01);

                if (datatable.Rows.Count <= 0)
                {
                    //Dificilmente entra aquí
                    return -3;
                }
                else
                {
                    ValtolBruto = 0;

                    foreach (DataRow TabReciCaja01 in datatable.Rows)
                    {
                        RelCruce = TabReciCaja01["DocuCruce"].ToString();
                        DFEc = Convert.ToDateTime(TabReciCaja01["FechaPagoCaja"]).Day.ToString();
                        int Mes = Convert.ToDateTime(TabReciCaja01["FechaPagoCaja"]).Month;
                        MFEc = Mes.ToString();
                        AFEc = Convert.ToDateTime(TabReciCaja01["FechaPagoCaja"]).Year.ToString();

                        ConTiPro = 0;

                        V = AFEc;
                        M = Convert.ToInt32(MFEc) <= 9 ? "0" + MFEc : MFEc.ToString();

                        string SqlDetaCaja = "SELECT [Datos detalles recibos de caja].ReciboNum, [Datos detalles recibos de caja].CodServi, [Datos detalles recibos de caja].CuentaContable, ";
                        SqlDetaCaja += "[Datos detalles recibos de caja].CentroCosto, [Datos detalles recibos de caja].CantidadCaja, [Datos detalles recibos de caja].ValorUnitaCaja, ";
                        SqlDetaCaja += "[Datos detalles recibos de caja].DetaPagoCaja, [Datos detalles recibos de caja].PorcenPago, [Datos detalles recibos de caja].EnLetras, ";
                        SqlDetaCaja += "[Datos detalles recibos de caja].NatuMovi, [Datos detalles recibos de caja].DebiCaja, [Datos detalles recibos de caja].CrediCaja, [Datos detalles recibos de caja].TipDocConta, ";
                        SqlDetaCaja += "[Datos detalles recibos de caja].NumDocConta, [Datos detalles recibos de caja].SucurConta, [Datos detalles recibos de caja].Nit;DosConta ";
                        SqlDetaCaja += "FROM [BDCAJASQL].[dbo].[Datos detalles recibos de caja] ";
                        SqlDetaCaja += "WHERE ((([Datos detalles recibos de caja].ReciboNum)= '" + RelaNum + "')) ";
                        SqlDetaCaja += "ORDER BY [Datos detalles recibos de caja].ReciboNum, [Datos detalles recibos de caja].NatuMovi DESC;";


                        DataTable datatable2 = Conexion.SQLDataTable(SqlDetaCaja);


                        if (datatable2.Rows.Count <= 0)
                        {
                            //El recibo de caja a contabilizar no tiene registrado el detalle
                            ConTiPro = 1; //Para que no continue
                            return 1;
                        }
                        else
                        {
                            ValDebitos = 0;
                            VCreditos = 0;

                            //Debemos de totalizar el debito y el credito

                            foreach (DataRow TabDetaCaja in datatable2.Rows)
                            {
                                ValDebitos += Convert.ToDouble(TabDetaCaja["DebiCaja"]);
                                VCreditos += Convert.ToDouble(TabDetaCaja["CrediCaja"]);
                            }


                            if (VCreditos == ValDebitos)
                            {
                                //Débitos y créditos son iguales se puede proceder a registrar el comprobante

                                ItemGra = 0;
                                CuanOrde = CuanOrde + 0;
                                CuanConta = CuanConta + 1;


                                foreach (DataRow TabDetaCaja in datatable2.Rows)
                                {
                                    ItemGra = ItemGra + 1;
                                    //Arme la fecha del documneto en el formato MES,Dia y AÑO


                                    DFEc1 = DFEc.Length <= 9 ? "0" + DFEc.ToString() : DFEc.ToString();
                                    MFEc1 = MFEc.Length <= 9 ? "0" + MFEc.ToString() : MFEc.ToString();
                                    AFEc1 = AFEc;


                                    FecDOc = MFEc1 + "/" + DFEc1 + "/" + AFEc1;

                                    DocNoCon = RelaNum.PadLeft(15, '0');
                                    DocAfNota = RelCruce.PadLeft(15, '0');
                                    ItemConver = Convert.ToString(ItemGra).PadLeft(5, '0');

                                    //Revisamos si el documento ya se encuentra registrado en contabilidad

                                    //ValDebitos = ValDebitos + Convert.ToDouble(TabDetaCaja["DebiCaja"]);
                                    //VCreditos = VCreditos + Convert.ToDouble(TabDetaCaja["CrediCaja"]);

                                    SqlCMDAnoMovi = "SELECT * FROM [ADYSNET].[dbo].[CMDMOVIMIENTO] ";
                                    SqlCMDAnoMovi = SqlCMDAnoMovi + "WHERE CMDAnoMovimiento = '" + V + "' ";
                                    SqlCMDAnoMovi = SqlCMDAnoMovi + "AND CMDPeriodoMovimiento = '" + M + "' ";
                                    SqlCMDAnoMovi = SqlCMDAnoMovi + "AND CMDComprobanteMovimiento = '" + CD + "' ";
                                    SqlCMDAnoMovi = SqlCMDAnoMovi + "AND CMDPrefijoMovimiento = '" + PreD + "' ";
                                    SqlCMDAnoMovi = SqlCMDAnoMovi + "AND CMDDocumentoMovimiento = '" + DocNoCon + "' ";
                                    SqlCMDAnoMovi = SqlCMDAnoMovi + "AND CMDItemMovimiento = '" + ItemConver + "' ";
                                    SqlCMDAnoMovi = SqlCMDAnoMovi + "ORDER BY CMDAnoMovimiento, CMDPeriodoMovimiento, CMDComprobanteMovimiento, CMDPrefijoMovimiento, CMDDocumentoMovimiento, CMDItemMovimiento;";


                                    DataTable TabCMDAnoMovi = Conexion.SQLDataTable(SqlCMDAnoMovi);


                                    if (TabCMDAnoMovi.Rows.Count <= 0)
                                    {

                                        DetaPagoCaja = TabDetaCaja["DetaPagoCaja"].ToString();

                                        if (DetaPagoCaja.Length > 100)
                                        {
                                            DetaPagoCaja = DetaPagoCaja.Substring(0, 100);
                                        }


                                        Utils.SqlDatos = "INSERT INTO [ADYSNET].[dbo].[CMDMOVIMIENTO] " +
                                        "(" +
                                        "CMDAnoMovimiento," +
                                        "CMDPeriodoMovimiento," +
                                        "CMDComprobanteMovimiento," +
                                        "CMDPrefijoMovimiento," +
                                        "CMDDocumentoMovimiento," +
                                        "CMDFechaMovimiento," +
                                        "CMDItemMovimiento," +
                                        "CMDCodigoCuentaMovimiento," +
                                        "CMDIdentificadorUnoMovimiento," +
                                        "CMDIdentificadorDosMovimiento," +
                                        "CMDSucursalMovimiento," +
                                        "CMDCodCentroCostosMovimiento," +
                                        "CMDCodigoMonedaMovimiento," +
                                        "CMDCodigoActivoMovimiento," +
                                        "CMDCodigoDiferidoMovimiento," +
                                        "CMDPrefijoRefmovimiento," +
                                        "CMDDocumentoRefMovimiento," +
                                        "CMDComentariosMovimiento," +
                                        "CMDValorMovimiento," +
                                        "CMDNaturalezaMovimiento," +
                                        "CMDValorBaseMovimiento," +
                                        "CMDValorMonedaMovimiento," +
                                        "CMDOrigenMovimiento" +
                                        ")" +
                                        "VALUES" +
                                        "(" +
                                        "'" + V + "'," +
                                        "'" + M + "'," +
                                        "'" + CD + "'," +
                                        "'" + PreD + "'," +
                                        "'" + DocNoCon + "'," +
                                        $"{Conexion.ValidarFechaNula(FecDOc)}" + //El 28 de julio de 2014 se dejo así
                                        "'" + ItemConver + "'," +
                                        "'" + TabDetaCaja["CuentaContable"].ToString() + "'," +
                                        "'" + TabDetaCaja["NumDocConta"].ToString() + "'," +
                                        "'" + TabDetaCaja["NitDosConta"].ToString() + "'," +
                                        "'" + TabDetaCaja["SucurConta"].ToString() + "'," +
                                        "'" + TabDetaCaja["CentroCosto"].ToString() + "'," +
                                        "'" + "000" + "'," +
                                        "'" + "null" + "'," +
                                        "'" + "null" + "'," +
                                        "'" + "00000" + "',";

                                        if (TabReciCaja01["DocuCruce"].ToString() == "0" || TabReciCaja01["DocuCruce"].ToString() == "")
                                        {
                                            Utils.SqlDatos += "'" + DocNoCon + "',";

                                        }
                                        else
                                        {
                                            Utils.SqlDatos += "'" + DocAfNota + "',";
                                        }


                                        Utils.SqlDatos += "'" + DetaPagoCaja + "',";

                                        if (TabDetaCaja["TabDetaCaja"].ToString() == "D")
                                        {
                                            //Esta grabando un movimiento de naturaleza debito

                                            Utils.SqlDatos += "'" + TabDetaCaja["DebiCaja"].ToString() + "',";
                                            Utils.SqlDatos += "'" + "DNO" + "',";

                                        }
                                        else
                                        {
                                            //Graba el movimiento credito


                                            Utils.SqlDatos += "'" + TabDetaCaja["CrediCaja"].ToString() + "',";
                                            Utils.SqlDatos += "'" + "CNO" + "',";

                                        }

                                        Utils.SqlDatos += "'" + "0" + "'," +
                                        "'" + "0" + "'," +
                                        "'" + "DIG" + "'" +
                                        ")";



                                        bool estaRegis = Conexion.SqlInsert(Utils.SqlDatos);


                                    }
                                    else
                                    {
                                        //El recibo de caja No. " & RelaNum & " Ya fue registrado en SOFTLAND "
                                        return 3;
                                    }


                                }//For Each

                            }
                            else
                            {
                                return 2; //Las sumas no son iguales
                            }//Final de VCreditos = ValDebitos


                        }//Final de TabDetaCaja.BOF

                    }
                }

                return 4;

            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "en la función: ContabiReciCajaST" + "\r";
                Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        private string ValidarCtaContaST(string CtaVal, string CenCos)
        {
            try
            {

                string SqlGCUENTAPUC, SqlGCOSTOSADMIN;
                //Esta función valida la existencia de la cuenta contable y a su vez si requiere, centro que el mismo se encuentre defindo, y si no requiere debe devolver tres ceros

                SqlGCUENTAPUC = "SELECT GLBCodigoCuentaCuentaPUC, GLBIdTerceroCuentaPUC, GLBIdCentroCostosCuentaPUC ";
                SqlGCUENTAPUC = SqlGCUENTAPUC + "FROM [ADYSNET].[dbo].GCUENTAPUC ";
                SqlGCUENTAPUC = SqlGCUENTAPUC + "WHERE GLBCodigoCuentaCuentaPUC = '" + CtaVal + "' ";
                SqlGCUENTAPUC = SqlGCUENTAPUC + "ORDER BY GLBCodigoCuentaCuentaPUC;";

                using (SqlConnection connection2 = new SqlConnection(Conexion.conexionSQL))
                {
                    SqlCommand command2 = new SqlCommand(SqlGCUENTAPUC, connection2);
                    command2.Connection.Open();
                    SqlDataReader TabGCUENTAPUC = command2.ExecuteReader();

                    if (TabGCUENTAPUC.HasRows == false)
                    {
                        //No se encontro el registro que tiene cuenta
                        return "-3";
                    }
                    else
                    {

                        TabGCUENTAPUC.Read();

                        if (TabGCUENTAPUC["GLBIdCentroCostosCuentaPUC"].ToString() == "CC")
                        {
                            //Requiere de centro de cost


                            SqlGCOSTOSADMIN = "SELECT GLBCodigoCentroCostos ";
                            SqlGCOSTOSADMIN = SqlGCOSTOSADMIN + "FROM [ADYSNET].[dbo].GCENTROCOSTOSADMINISTRATIVA ";
                            SqlGCOSTOSADMIN = SqlGCOSTOSADMIN + "WHERE GLBCodigoCentroCostos = '" + CenCos + "' ";
                            SqlGCOSTOSADMIN = SqlGCOSTOSADMIN + " ORDER BY GLBCodigoCentroCostos;";


                            using (SqlConnection connection4 = new SqlConnection(Conexion.conexionSQL))
                            {
                                SqlCommand command4 = new SqlCommand(SqlGCUENTAPUC, connection4);
                                command4.Connection.Open();
                                SqlDataReader TabGCOSTOSADMIN = command4.ExecuteReader();

                                if (TabGCOSTOSADMIN.HasRows == false)
                                {
                                    return "-4"; //No existe el centro de consto y se requiere
                                }
                                else
                                {
                                    TabGCOSTOSADMIN.Read();
                                    return TabGCOSTOSADMIN["GLBCodigoCentroCostos"].ToString();
                                }

                            }
                        }
                        else
                        {
                            //No requiere
                            return "000";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "en la función: ValidarTerceroSofTland del Modulo" + "\r";
                Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "-1";
            }
        }
        private string ValidarTerceroSofTland(string NitSF, string SucST)
        {
            try
            {
                //********************* Se creó el 21 de marzo de 2015 **********************************************
                //********************* Se Recreó el 15 de diciembre de 2021 por tenjo en crack **********************************************


                string SqlTercerosST = "SELECT CMDTERCEROS.CMDIdentificadorUnoTerceros, CMDTERCEROS.CMDSucursalTerceros, ";
                SqlTercerosST += "CMDTERCEROS.CMDIdentificadorDosTerceros, GTERCEROS.GBLRazonSocialTerceros ";
                SqlTercerosST += "FROM [ADYSNET].[dbo].CMDTERCEROS INNER JOIN [ADYSNET].[dbo].GTERCEROS ON CMDTERCEROS.CMDIdentificadorUnoTerceros = ";
                SqlTercerosST += "GTERCEROS.GBLIdentificadorUnoTerceros AND CMDTERCEROS.CMDSucursalTerceros = GTERCEROS.GBLSucursalTerceros ";
                SqlTercerosST += "WHERE (CMDTERCEROS.CMDIdentificadorUnoTerceros = N'" + NitSF + "') AND ";
                SqlTercerosST += "(CMDTERCEROS.CMDSucursalTerceros = N'" + SucST + "')";


                using (SqlConnection connection2 = new SqlConnection(Conexion.conexionSQL))
                {
                    SqlCommand command2 = new SqlCommand(SqlTercerosST, connection2);
                    command2.Connection.Open();
                    SqlDataReader TabTercerosST = command2.ExecuteReader();

                    if (TabTercerosST.HasRows == false)
                    {
                        //No se encontro el registro que tiene el consecutivo
                        return "-3";
                    }
                    else
                    {
                        TabTercerosST.Read();

                        return TabTercerosST["CMDIdentificadorDosTerceros"].ToString();
                    }
                }


            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "en la función: ValidarTerceroSofTland" + "\r";
                Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "-1";
            }
        }
        private string TieneContabilidad(string CodEnti)
        {
            try
            {
                string SqlInfEmpre = "SELECT  ContaSIG ";
                SqlInfEmpre = SqlInfEmpre + "FROM [BDADMINSIG].[dbo].[Datos informacion de la empresa] ";
                SqlInfEmpre = SqlInfEmpre + "WHERE CodUnico = '" + CodEnti + "' ";
                SqlInfEmpre = SqlInfEmpre + "ORDER BY CodUnico ";

                using (SqlConnection connection2 = new SqlConnection(Conexion.conexionSQL))
                {
                    SqlCommand command2 = new SqlCommand(SqlInfEmpre, connection2);
                    command2.Connection.Open();
                    SqlDataReader TabTerceros = command2.ExecuteReader();


                    if (TabTerceros.HasRows == false)
                    {
                        //No se encontro el registro que tiene el consecutivo
                        return "0";
                    }
                    else
                    {
                        TabTerceros.Read();
                        return TabTerceros["ContaSIG"].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "en la función: TieneContabilidad " + "\r";
                Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "-1";
            }
        }

        private int ValidarPerioConta(string A, string P)
        {
            try
            {

                //'***************** Creada el 22 de marzo de 2015 ************************************************
                //'***************** ReCreada en c# el 15 de diciembre de 2021 por Tenjo el crack ************************************************

                //Permite revisar si un periodo contable existe y si esta abierto

                string SqlPerioConta = "SELECT  CMDPERIODO.* ";
                SqlPerioConta += "FROM [ADYSNET].[dbo].CMDPERIODO WHERE (CMDAnoPeriodo = '" + A + "') AND (CMDPeriodoPeriodo = '" + P + "') ";


                using (SqlConnection connection2 = new SqlConnection(Conexion.conexionSQL))
                {
                    SqlCommand command2 = new SqlCommand(SqlPerioConta, connection2);
                    command2.Connection.Open();
                    SqlDataReader TabPerioConta = command2.ExecuteReader();

                    if (TabPerioConta.HasRows == false)
                    {
                        //No existe periodo
                        return 2;
                    }
                    else
                    {
                        TabPerioConta.Read();

                        if (TabPerioConta["CMDEstadoPeriodo"].ToString() == "CE")
                        {
                            return 3;
                        }
                        else
                        {
                            return 4;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "en la función: ValidarPerioConta" + "\r";
                Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
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

                    TxtHistoriaNumero.Text = Utils.NumHisPrede; 
                    cboTipDoTer.SelectedValue = Utils.TipDocPre;
                    TxtNitNumero.Text = Utils.NumDocPre;
                    TxtCardiTer.Text = Utils.SucurPre;  


                    LblCodCajAct.Text = Utils.CodCaja;
                    LblNomCajAct.Text = Utils.NombgPre;

                    TxtCenCajaD.Text = Utils.CenCosCaja;
                    TxtCtaConD.Text = Utils.CuenConta;


                    CboTipoDocDebi.SelectedValue = Utils.TipoDocDebi;

                    TxtNumDocDebi.Text = Utils.NumDocDebi;
                    TxtSucuCtaDebi.Text = Utils.SucuCtaDebi;
                    TxtDigiVerDebi.Text = Utils.DigiVerDebi;
                    TxtNumDocDebiDos.Text = Utils.NumDocDebiDos;


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
                this.cboTipDoTer.DataSource = null;
                this.cboTipDoTer.Items.Clear();

                this.CboTipoDocDebi.DataSource = null;
                this.CboTipoDocDebi.Items.Clear();

                Utils.SqlDatos = " SELECT[Datos documentos empresas].CodIdenti, [Datos documentos empresas].NomIdenti " +
                " FROM [ACDATOXPSQL].[dbo].[Datos documentos empresas] " +
                " ORDER BY [Datos documentos empresas].CodIdenti, [Datos documentos empresas].NomIdenti; ";

                DataSet dataSet = Conexion.SQLDataSet(Utils.SqlDatos);

                if (dataSet != null && dataSet.Tables.Count > 0)
                {
                    this.cboTipDoTer.DataSource = dataSet.Tables[0];
                    this.cboTipDoTer.ValueMember = "CodIdenti";
                    this.cboTipDoTer.DisplayMember = "NomIdenti";

                    this.CboTipoDocDebi.DataSource = dataSet.Tables[0];
                    this.CboTipoDocDebi.ValueMember = "CodIdenti";
                    this.CboTipoDocDebi.DisplayMember = "NomIdenti";


                    this.TipoDocDeTer.DataSource = dataSet.Tables[0];
                    this.TipoDocDeTer.ValueMember = "CodIdenti";
                    this.TipoDocDeTer.DisplayMember = "NomIdenti";

                }


                Utils.SqlDatos = "SELECT [Datos tarifas contradas].CodiTar, [Datos tarifas contradas].NomTar FROM [ACDATOXPSQL].[dbo].[Datos tarifas contradas] ORDER BY [Datos tarifas contradas].NomTar;";

                DataSet dataSet2 = Conexion.SQLDataSet(Utils.SqlDatos);

                if (dataSet2 != null && dataSet2.Tables.Count > 0)
                {
                    this.CboCobraTarifa.DataSource = dataSet2.Tables[0];
                    this.CboCobraTarifa.ValueMember = "CodiTar";
                    this.CboCobraTarifa.DisplayMember = "NomTar";
                }

                Utils.SqlDatos = "SELECT [Datos centros de costo].CodiCentro, [Datos centros de costo].NomCentro, [Datos centros de costo].CateCentro FROM [ACDATOXPSQL].[dbo].[Datos centros de costo] " +
                " WHERE ((([Datos centros de costo].CateCentro) = 1 Or([Datos centros de costo].CateCentro) = 3)) ORDER BY[Datos centros de costo].CodiCentro; ";

                DataSet dataSet3 = Conexion.SQLDataSet(Utils.SqlDatos);

                if (dataSet3 != null && dataSet3.Tables.Count > 0)
                {
                    this.CentroCuenta.DataSource = dataSet3.Tables[0];
                    this.CentroCuenta.ValueMember = "CodiCentro";
                    this.CentroCuenta.DisplayMember = "NomCentro";
                }

                Utils.SqlDatos = " SELECT [Datos tipos de usuarios].CodTipoUsuar, [Datos tipos de usuarios].NomTipo FROM[ACDATOXPSQL].[dbo].[Datos tipos de usuarios] ORDER BY[Datos tipos de usuarios].NomTipo;";

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

        private void CargarUsuarioPredeterminado()
        {
            try
            {
                string T = "", D = "", S = "";
                string His01 = TxtHistoriaNumero.Text;

                string SqlPacientes = "SELECT Nombre1, Nombre2, Apellido1, Apellido2, TipoUsar ";
                SqlPacientes = SqlPacientes + "FROM [ACDATOXPSQL].[dbo].[Datos del Paciente] ";
                SqlPacientes = SqlPacientes + "WHERE HistorPaci= '" + His01 + "' ";
                SqlPacientes = SqlPacientes + "ORDER BY HistorPaci";

                DtFechaRecibo.Value = DateTime.Now.Date;

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

                        TxtNombrePaciente.Text = TabPacientes["Nombre1"].ToString() + " " + TabPacientes["Nombre2"].ToString() + " " + TabPacientes["Apellido1"].ToString() + " " + TabPacientes["Apellido2"].ToString();
                        CboRegimUsua.SelectedValue = TabPacientes["TipoUsar"].ToString();

                    }
                }

                T = cboTipDoTer.SelectedValue.ToString();
                D = TxtNitNumero.Text;
                S = TxtCardiTer.Text;

                string SqlEmpTer = "SELECT RazonSol, SucurProv, TipoDocu ";
                SqlEmpTer = SqlEmpTer + "FROM [GEOGRAXPSQL].[dbo].[Datos proveedores] ";
                SqlEmpTer = SqlEmpTer + "WHERE TipoDocu ='" + T + "' AND IdenProve ='" + D + "' AND SucurProv ='" + S + "' ";
                SqlEmpTer = SqlEmpTer + "ORDER BY TipoDocu, IdenProve, SucurProv ";

                SqlDataReader TabEmpTer;

                using (SqlConnection connection2 = new SqlConnection(Conexion.conexionSQL))
                {
                    SqlCommand command2 = new SqlCommand(SqlEmpTer, connection2);
                    command2.Connection.Open();
                    TabEmpTer = command2.ExecuteReader();

                    if (TabEmpTer.HasRows)
                    {
                        TabEmpTer.Read();

                        TxtNombreTercero.Text = TabEmpTer["RazonSol"].ToString();
                        TxtCardiTer.Text = TabEmpTer["SucurProv"].ToString();
                    }
                    else
                    {
                        TxtCodDoc.Text = "0";
                        TxtPreDoc.Text = "0";
                    }
                }


                string SqlDocConta = "SELECT [Datos documentos contables].CodModu, [Datos documentos contables].PreDocu, ";
                SqlDocConta = SqlDocConta + "[Datos documentos contables].NumDocu ";
                SqlDocConta = SqlDocConta + "FROM [BDADMINSIG].[dbo].[Datos documentos contables] ";
                SqlDocConta = SqlDocConta + "WHERE ((([Datos documentos contables].CodModu) = '01')) ";
                SqlDocConta = SqlDocConta + "ORDER BY [Datos documentos contables].CodModu;";


                SqlDataReader TabDocConta;

                using (SqlConnection connection2 = new SqlConnection(Conexion.conexionSQL))
                {
                    SqlCommand command2 = new SqlCommand(SqlDocConta, connection2);
                    command2.Connection.Open();
                    TabDocConta = command2.ExecuteReader();

                    if (TabDocConta.HasRows)
                    {
                        TabDocConta.Read();

                        TxtCodDoc.Text = TabDocConta["NumDocu"].ToString();
                        TxtPreDoc.Text = TabDocConta["PreDocu"].ToString();
                    }
                    else
                    {
                        TxtCodDoc.Text = "0";
                        TxtPreDoc.Text = "0";
                    }
                }



            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "en la funcion CargarUsuarioPredeterminado" + "\r";
                Utils.Informa += "Error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void buscarTercero()
        {
            try
            {
                Utils.Titulo01 = "Control para buscar datos";

                if (string.IsNullOrWhiteSpace(TxtNitNumero.Text))
                {
                    return;
                }

                string CNT = TxtNitNumero.Text;



                //Revisamos si ya selecciono el tipo de documento

                if (cboTipDoTer.SelectedIndex == -1)
                {
                    return;
                }

                if (string.IsNullOrWhiteSpace(TxtCardiTer.Text))
                {
                    return;
                }

                string TDT = cboTipDoTer.SelectedValue.ToString();

                string SucurTer = TxtCardiTer.Text;


                //Procede a buscarlo en la base de datos


                string SqlEmpTer = "SELECT RazonSol, SucurProv  " +
                " FROM [GEOGRAXPSQL].[dbo].[Datos proveedores] " +
                " WHERE TipoDocu = '" + TDT + "' AND IdenProve = '" + CNT + "' AND SucurProv = '" + SucurTer + "' " +
                " ORDER BY TipoDocu ";

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

                        TxtNombreTercero.Text = TabEmpTer["RazonSol"].ToString();
                        TxtCardiTer.Text = TabEmpTer["SucurProv"].ToString();

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

        private void BuscarPacientes()
        {
            try
            {
                string SqlPacientes = "SELECT Nombre1, Nombre2, Apellido1, Apellido2, TipoUsar ";
                SqlPacientes = SqlPacientes + "FROM [ACDATOXPSQL].[dbo].[Datos del Paciente] ";
                SqlPacientes = SqlPacientes + "WHERE HistorPaci= '" + TxtHistoriaNumero.Text + "' ";
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

                        TxtNombrePaciente.Text = TabPacientes["Nombre1"].ToString() + " " + TabPacientes["Nombre2"].ToString() + " " + TabPacientes["Apellido1"].ToString() + " " + TabPacientes["Apellido2"].ToString();
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

        #endregion

        #region botones


        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void BtnBuscarTercer_Click(object sender, EventArgs e)
        {
            try
            {

                FrmBuscarTerceros frmBuscarTerceros = new FrmBuscarTerceros();
                frmBuscarTerceros.ShowDialog();

                cboTipDoTer.SelectedValue = Utils.TipDocFac;
                TxtNitNumero.Text = Utils.NitCC;
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

        private void BtnBuscarPaci_Click(object sender, EventArgs e)
        {
            try
            {

                FrmBuscarPacientes frmBuscarPacientes = new FrmBuscarPacientes();
                frmBuscarPacientes.ShowDialog();

                TxtHistoriaNumero.Text = Utils.HistoriaNumero;

                if (string.IsNullOrWhiteSpace(TxtHistoriaNumero.Text) == false)
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

        private void BtnServicioCaja_Click(object sender, EventArgs e)
        {
            try
            {

                FrmBuscarServicios frmBuscarServicios = new FrmBuscarServicios();
                frmBuscarServicios.ShowDialog();

                if (string.IsNullOrWhiteSpace(Utils.CodigoServi) == false)
                {
                    if (GridDetalleRecibos.SelectedRows.Count > 0)
                    {
                        GridDetalleRecibos.SelectedCells[0].Value = Utils.CodigoServi;
                    }
                }

            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "de hacer click sobre el botón de servicios" + "\r";
                Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion

        #region DataGridView

        private void GridDetalleRecibos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            try
            {

                int ColumnIndex = this.GridDetalleRecibos.CurrentCell.ColumnIndex;

                int RowIndex = this.GridDetalleRecibos.CurrentCell.RowIndex;

                if (ColumnIndex != 0)
                {
                    return;
                }

                string Co01 = "", TipoTarifa = "", SqlTerceros = "", SqlCuenConta = "", TipDocCaja = "", NumDocCaja = "", SucCaja = "", NitDosT = "", CtaConReg = "", SqlCataSer = "", SqlTariCon = "", CampoTar = "";
                int ProCir = 0, ItemB = 0;
                double ValorUnita = 0;
                SqlDataReader TabCataSer;
                Utils.Titulo01 = "Control de existencia de datos";

                if (GridDetalleRecibos.SelectedRows.Count > 0)
                {

                    if (GridDetalleRecibos.SelectedCells[0].Value != null)
                    {


                        Co01 = GridDetalleRecibos.SelectedCells[0].Value.ToString();

                        //Busque el codigo digitado

                        DataGridViewRow row = this.GridDetalleRecibos.SelectedRows[0];

                        TipoTarifa = CboCobraTarifa.SelectedValue.ToString();

                        SqlCataSer = "SELECT * FROM [ACDATOXPSQL].[dbo].[Datos catalogo de servicios] ";
                        SqlCataSer += "WHERE CodInterno = '" + Co01 + "' ";
                        SqlCataSer += "ORDER BY CodInterno";

                        TabCataSer = Conexion.SQLDataReader(SqlCataSer);

                        if (TabCataSer.HasRows == false)
                        {
                            SqlCataSer = "SELECT * FROM [ACDATOXPSQL].[dbo].[Datos catalogo de servicios] ";
                            SqlCataSer += "WHERE CodiCUPS = '" + Co01 + "' ";
                            SqlCataSer += "ORDER BY CodiCUPS";

                            TabCataSer = Conexion.SQLDataReader(SqlCataSer);

                            if (TabCataSer.HasRows == false)
                            {
                                SqlCataSer = "SELECT * FROM [ACDATOXPSQL].[dbo].[Datos catalogo de servicios] ";
                                SqlCataSer += "WHERE CodiSOAT = '" + Co01 + "' ";
                                SqlCataSer += "ORDER BY CodiSOAT";

                                TabCataSer = Conexion.SQLDataReader(SqlCataSer);

                                if (TabCataSer.HasRows == false)
                                {
                                    //Definitivamente no existe el código

                                    Utils.Informa = "LO SIENTO PERO EL CÓDIGO DIGITADO" + "\r";
                                    Utils.Informa += "NO EXISTE EN ESTE SISTEMA." + "\r";
                                    Utils.Informa += "Por favor seleccione uno que exista o pulse" + "\r";
                                    Utils.Informa += "la tecla [ESC] para anular la acción." + "\r";
                                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                        }

                        TabCataSer.Read();

                        //Al llegar a este nivel es orque existe el código digitado

                        ProCir = Convert.ToInt32(TabCataSer["EsCirugia"]);

                        //Si es cirugía no permita

                        if (ProCir == -1)
                        {
                            Utils.Informa = "LO SIENTO PERO LOS CÓDIGO ASIGNADOS A" + "\r";
                            Utils.Informa += "PROCEDIMIENTOS QUIRURGICOS NO PUEDEN" + "\r";
                            Utils.Informa += "SER PAGADOS DIRECTAMENTE POR LA CAJA." + "\r";
                            MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            //Con base al código del tipo de tarifa buscamos el nombre del campo

                            SqlTariCon = "SELECT CodiTar, NomCampo FROM [ACDATOXPSQL].[dbo].[Datos tarifas contradas] ";
                            SqlTariCon += "WHERE CodiTar = '" + TipoTarifa + "' ";
                            SqlTariCon += "ORDER BY CodiTar";



                            using (SqlConnection connection = new SqlConnection(Conexion.conexionSQL))
                            {
                                SqlCommand command = new SqlCommand(SqlTariCon, connection);
                                command.Connection.Open();
                                SqlDataReader TabTariCon = command.ExecuteReader();

                                if (TabTariCon.HasRows == false)
                                {
                                    CampoTar = "ValorParti";
                                }
                                else
                                {
                                    TabTariCon.Read();
                                    CampoTar = TabTariCon["NomCampo"].ToString();
                                }
                            }

                            ValorUnita = Convert.ToDouble(TabCataSer[CampoTar]);


                            row.Cells[1].Value = TabCataSer["CuenConta"].ToString();
                            row.Cells[2].Value = TabCataSer["NomServicio"].ToString();

                            string CodigoCuenConta = TabCataSer["CenCosto"].ToString();

                            Utils.SqlDatos = "SELECT [Datos centros de costo].CodiCentro, [Datos centros de costo].NomCentro, [Datos centros de costo].CateCentro FROM [ACDATOXPSQL].[dbo].[Datos centros de costo] " +
                            " WHERE((([Datos centros de costo].CateCentro) = 1 Or([Datos centros de costo].CateCentro) = 3)) AND [Datos centros de costo].CodiCentro = '" + CodigoCuenConta + "' ; ";

                            using (SqlConnection connection = new SqlConnection(Conexion.conexionSQL))
                            {
                                SqlCommand command = new SqlCommand(Utils.SqlDatos, connection);
                                command.Connection.Open();
                                SqlDataReader TabCuenConta = command.ExecuteReader();

                                if (TabCuenConta.HasRows)
                                {
                                    GridDetalleRecibos.SelectedCells[3].Value = CodigoCuenConta;
                                }

                            }


                            row.Cells[4].Value = ValorUnita;


                            //[ActuaValUni] = TabCataSer![ActuaValUni] Ni idea que es


                            //Siempre se considera pago total

                            row.Cells[6].Value = "100";
                            row.Cells[7].Value = ValorUnita;
                            row.Cells[8].Value = ValorUnita;

                        }

                        if (Conexion.sqlConnection.State == ConnectionState.Open) Conexion.sqlConnection.Close();

                        //Validamos la cuenta contable


                        CtaConReg = GridDetalleRecibos.SelectedCells[1].Value.ToString();

                        if (string.IsNullOrWhiteSpace(CtaConReg))
                        {
                            Utils.Informa = "No olvide que usted debe registrar el" + "\r";
                            Utils.Informa += "número de la cuenta contable para que se" + "\r";
                            Utils.Informa += "pueda realizar el proceso de pago por caja." + "\r";
                            MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {

                            SqlCuenConta = "SELECT  [Datos ctas contables IPS].* ";
                            SqlCuenConta += "FROM [GEOGRAXPSQL].[dbo].[Datos ctas contables IPS] ";
                            SqlCuenConta += "WHERE  (CueContaIPS = N'" + CtaConReg + "')";


                            using (SqlConnection connection = new SqlConnection(Conexion.conexionSQL))
                            {
                                SqlCommand command = new SqlCommand(SqlCuenConta, connection);
                                command.Connection.Open();
                                SqlDataReader TabCuenConta = command.ExecuteReader();

                                if (TabCuenConta.HasRows == false)
                                {
                                    Utils.Informa = "El número de cuenta contable asociada al servicio" + "\r";
                                    Utils.Informa += "actual, no se encuentra definido en el plan de" + "\r";
                                    Utils.Informa += "cuentas, por lo tanto usted debe corregir el número." + "\r";
                                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else
                                {
                                    //'Revisamos si exige centro de costo
                                    TabCuenConta.Read();

                                    if (Convert.ToBoolean(TabCuenConta["RequieCentro"]) == true)
                                    {

                                        if(GridDetalleRecibos.SelectedCells[3].Value == null)
                                        {
                                            Utils.Informa = "Lo siento pero usted no ha digitado el centro " + "\r";
                                            Utils.Informa += "de costo de la cuenta contable a acreditar, por" + "\r";
                                            Utils.Informa += "lo tanto no se puede continuar con el proceso." + "\r";
                                            MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }         
                                    }

                                    //'Revisamos si requiere tercero

                                    if (TabCuenConta["RequieNit"].ToString() == "1")
                                    {
                                        //Que tipo de tercero, lo normal es que se asocia a la cuenta
                                        if (TabCuenConta["SiterObliga"].ToString() == "1")
                                        {
                                            TipDocCaja = TabCuenConta["TipoDocCuen"].ToString();
                                            NumDocCaja = TabCuenConta["NumDocCuen"].ToString();
                                            SucCaja = TabCuenConta["SucurCuen"].ToString();
                                            NitDosT = TabCuenConta["NitDosCuen"].ToString();
                                        }
                                        else
                                        {
                                            if (TabCuenConta["SiterObliga"].ToString() == "2")
                                            {
                                                TipDocCaja = cboTipDoTer.SelectedValue.ToString();
                                                NumDocCaja = TxtNitNumero.Text;
                                                SucCaja = TxtCardiTer.Text;

                                            }
                                            else
                                            {
                                                Utils.Informa = "Lo siento pero el número del documento de" + "\r";
                                                Utils.Informa += "identificación del tercero no se encuentra" + "\r";
                                                Utils.Informa += "parametrizado en la cuenta contable " + CtaConReg + "\r";
                                                Utils.Informa += "Por lo tanto no se puede continuar." + "\r";
                                                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                                TipDocCaja = "NIT";
                                                NumDocCaja = "0";
                                                SucCaja = "000";
                                                NitDosT = "0";
                                            }

                                        }


                                        //Validamos el tercero

                                        if (string.IsNullOrWhiteSpace(NumDocCaja) == false)
                                        {

                                            SqlTerceros = "SELECT TipoDocu, IdenProve, SucurProv, RazonSol, DigVeri, IdenProveDos ";
                                            SqlTerceros += "FROM [GEOGRAXPSQL].[dbo].[Datos proveedores] ";
                                            SqlTerceros += "WHERE TipoDocu='" + TipDocCaja + "' AND IdenProve='" + NumDocCaja + "'  AND SucurProv='" + SucCaja + "' ";
                                            SqlTerceros += "ORDER BY TipoDocu";

                                            using (SqlConnection connection2 = new SqlConnection(Conexion.conexionSQL))
                                            {
                                                SqlCommand command2 = new SqlCommand(SqlTerceros, connection2);
                                                command2.Connection.Open();
                                                SqlDataReader TabTerceros = command2.ExecuteReader();

                                                if (TabTerceros.HasRows == false)
                                                {
                                                    Utils.Informa = "Lo siento pero el documento de identificación" + "\r";
                                                    Utils.Informa += "del tercero de la cuenta crédito, no se encuentra" + "\r";
                                                    Utils.Informa += "registrado en la base de datos, por lo tanto no se" + "\r";
                                                    Utils.Informa += "puede registrar el pago." + "\r";
                                                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                                }
                                                else
                                                {
                                                    TabTerceros.Read();
                                                    //Muestre o asigne los datos del proveedor

                                                    GridDetalleRecibos.SelectedCells[9].Value = TipDocCaja;

                                                    row.Cells[10].Value = NumDocCaja;
                                                    row.Cells[11].Value = TabTerceros["DigVeri"].ToString();
                                                    row.Cells[12].Value = SucCaja;
                                                    row.Cells[13].Value = TabTerceros["IdenProveDos"].ToString();

                                                }
                                            }
                                        }
                                    }//Final de TabCuenConta![RequieNit] = True
                                }//Final de TabCuenConta.BOF
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "de actualizar el código del servicio en el dataGridView" + "\r";
                Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GridDetalleRecibos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                decimal TolValorUni = 0;

                foreach (DataGridViewRow Row in GridDetalleRecibos.Rows)
                {
                    TolValorUni += Convert.ToDecimal(Row.Cells[8].Value);
                }

                TxtNetoPaga.Text = TolValorUni.ToString();

            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "de actualizar el total del valor neto a pagar" + "\r";
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
        }

        private void RbCheque_CheckedChanged(object sender, EventArgs e)
        {
            FormaPago = 2;
            CboLIstaBancos.Visible = true;
            TxtNumDocumentoP.Visible = true;
            LblDocumentoPago.Text = "Cheque No.";
        }

        private void RbTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            FormaPago = 3;
            CboLIstaBancos.Visible = true;
            TxtNumDocumentoP.Visible = true;
            LblDocumentoPago.Text = "Recibo No.";
        }

        private void RbBonos_CheckedChanged(object sender, EventArgs e)
        {
            FormaPago = 4;
            CboLIstaBancos.Visible = false;
            TxtNumDocumentoP.Visible = false;
        }

        #endregion

        #region texbox&comboBox
        private void cboTipDoTer_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                buscarTercero();
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

        private void TxtNitNumero_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtHistoriaNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((int)e.KeyChar == (int)Keys.Enter)
                {
                    if (string.IsNullOrWhiteSpace(TxtHistoriaNumero.Text) == false)
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


        #endregion

        int FormaPago = 1;
        private void FrmCajaGeneral_Load(object sender, EventArgs e)
        {
            try
            {
                CargarCombobox();
                CargarDatosUser();
                //Muestre los datos o nombres preterminados
                CargarUsuarioPredeterminado();

            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "al abrir el formulario Caja General" + "\r";
                Utils.Informa += "Error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void BtnRegistraCaja_Click(object sender, EventArgs e)
        {
            try
            {
                Utils.Titulo01 = "Control para registrar ingresos por caja";

                string CodCa = "", infoCajaSql = "", Para05 = "",X = "", Y = "", Z = "", SqlReciCaja = "", QPaga = "", HisPa = "", UsReci = "", CCon = "", CCostoCre = "", FunValCtaD = "", NitDosDebi = "", NitDebitar = "", TD = "", NitCC = "", CardiNi = "", CobTar = "", Cuencaja = "";
                string FormPa = "", FunReciNum = "", ComDes = "", Enti = "", InformaST = "", FunTerceST = "",NomReci = "", FunProveDos = "", SucTerPaga = "", CodDocuMov = "", PreDoc = "", FunConta = "", AnVigen = "", MesPerio = "", CodEnti = "", SqlTerceros = "", TipDocDeb = "", NumDocDeb = "", SucurDeb = "",  SqlCuenConta = "", CenCaja = "", NDDigVer = "", NumEnti = "", Tipag = "";
                decimal NetPag = 0, TolDebiCaja = 0;
                int SiguePro = 0, FunConSoft = 0, FunValiPer = 0, canti = 0, ValorUni = 0, RG = 0, ErrConti = 0;


                if (string.IsNullOrWhiteSpace(LblCodCajAct.Text))
                {
                    Utils.Informa = "Lo siento pero mientras no se tenga" + "\r";
                    Utils.Informa += "definida la identificación de la caja," + "\r";
                    Utils.Informa += "no se puede realizar este proceso." + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                CodCa = LblCodCajAct.Text;

                if (string.IsNullOrWhiteSpace(TxtHistoriaNumero.Text))
                {
                    Utils.Informa = "Lo siento pero usted no ha digitado un número de" + "\r";
                    Utils.Informa += "historia válido que le permita a este sistema" + "\r";
                    Utils.Informa += "registrar un ingreso por caja." + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                HisPa = TxtHistoriaNumero.Text;

                if(cboTipDoTer.SelectedIndex == -1)
                {
                    Utils.Informa = "Lo siento pero usted no ha seleccionado" + "\r";
                    Utils.Informa += "el tipo de documento del tercero que le" + "\r";
                    Utils.Informa += "desea registrar el ingreso por caja." + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                TD = cboTipDoTer.SelectedValue.ToString();

                if (string.IsNullOrWhiteSpace(TxtNitNumero.Text))
                {
                    Utils.Informa = "Lo siento pero usted no ha digitado el Nit o CC del" + "\r";
                    Utils.Informa += "tercero que le desea registrar el ingreso por caja" + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                NitCC = TxtNitNumero.Text;

                if (string.IsNullOrWhiteSpace(TxtCardiTer.Text))
                {
                    Utils.Informa = "Lo siento pero usted no ha digitado la sucursal del" + "\r";
                    Utils.Informa += "tercero que le desea registrar el ingreso por caja" + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                CardiNi = TxtCardiTer.Text;

                if (CboCobraTarifa.SelectedIndex == -1)
                {
                    Utils.Informa = "Lo siento pero usted no ha definido el tipo" + "\r";
                    Utils.Informa += "de tarifa a utilizar en el ingreso por caja" + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                CobTar = CboCobraTarifa.SelectedValue.ToString();

                if (string.IsNullOrWhiteSpace(TxtCtaConD.Text))
                {
                    Utils.Informa = "Lo siento pero usted no ha digitado la cuenta" + "\r";
                    Utils.Informa += "contable asignada a la caja de ingresos." + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Cuencaja = TxtCtaConD.Text;

                if (string.IsNullOrWhiteSpace(TxtCenCajaD.Text))
                {
                    Utils.Informa = "Lo siento pero usted no ha digitado el centro" + "\r";
                    Utils.Informa += "de costos asignado a la caja de ingresos." + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                CenCaja = TxtCenCajaD.Text;


                NetPag = Convert.ToDecimal(TxtNetoPaga.Text);

                if(NetPag <= 0)
                {
                    Utils.Informa = "Lo siento pero el valor neto a pagar debe ser siempre mayor a cero (0)" + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //******************* ANTES DE SEGUIR SE DEBE EJECUTAR UN PROCESO LOS REGISTROS DE LA TABLAS TEMPORAL ********
                //1. Mirar que todas las cuentas contables existan
                //2, Que las cuentas contables que exijan terceros, estos se encuentren catalogados
                //3. Total por código el total a regsitra como debito. (Valor neto)

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
                            Utils.Informa = "Lo siento pero usted no ha digitado el" + "\r";
                            Utils.Informa += "nombre del banco del cheque recibido." + "\r";
                            MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        //Revisamos si digitó el número del cheque

                        if (string.IsNullOrWhiteSpace(TxtNumDocumentoP.Text))
                        {
                            Utils.Informa = "Lo siento pero usted no ha digitado" + "\r";
                            Utils.Informa += "el número del cheque recibido." + "\r";
                            MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        FormPa = "Pago con cheque del " + CboLIstaBancos.Text;
                        Enti = CboLIstaBancos.SelectedValue.ToString();
                        NumEnti = TxtNumDocumentoP.Text;
                        Tipag = "CH";

                        break;
                    case 3: //Tarjeta de credito
                            //Revise si seleccionó el nombre del banco de la tarjeta

                        if (CboLIstaBancos.SelectedIndex == -1)
                        {
                            Utils.Informa = "Lo siento pero usted no ha digitado el nombre" + "\r";
                            Utils.Informa += "de la entidad de la tarjeta de crédito." + "\r";
                            MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (string.IsNullOrWhiteSpace(TxtNumDocumentoP.Text))
                        {
                            Utils.Informa = "Lo siento pero Ud. no ha digitado el número" + "\r";
                            Utils.Informa += "del recibo de pago de la tarjeta." + "\r";
                            MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        FormPa = "Pago con tarjeta de crédito " + CboLIstaBancos.Text;
                        Enti = CboLIstaBancos.SelectedValue.ToString();
                        NumEnti = TxtNumDocumentoP.Text;
                        Tipag = "TC";

                        break;
                    case 4: //Pago en bonos

                        FormPa = "Pago con bonos ";
                        Enti = null;
                        NumEnti = null;
                        Tipag = "BO";


                        break;
                    default:
                        break;
                }// switch (FormaPago)


                SiguePro = 0;

                //Revisamos el documento de identificación del tercero existe, en la tabla de proveedores

                SqlTerceros = "SELECT TipoDocu, IdenProve, SucurProv, DigVeri, RazonSol, IdenProveDos ";
                SqlTerceros += "FROM  [GEOGRAXPSQL].[dbo].[Datos proveedores] ";
                SqlTerceros += "WHERE TipoDocu='" + TD + "' AND IdenProve='" + NitCC + "'  AND SucurProv='" + CardiNi + "' ";
                SqlTerceros += "ORDER BY TipoDocu";


                using (SqlConnection connection = new SqlConnection(Conexion.conexionSQL))
                {
                    SqlCommand command = new SqlCommand(SqlTerceros, connection);
                    command.Connection.Open();
                    SqlDataReader TabTerceros = command.ExecuteReader();

                    if(TabTerceros.HasRows == false)
                    {
                        Utils.Informa = "Lo siento pero el documento de" + "\r";
                        Utils.Informa += "identificación del recibo de caja" + "\r";
                        Utils.Informa += "a registrar, no existe en la base" + "\r";
                        Utils.Informa += "de datos, por lo tanto no se puede" + "\r";
                        Utils.Informa += "realizar el registro." + "\r";
                        MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        TabTerceros.Read();
                        //Existe, puede grabar tranquilamente


                        NomReci = TabTerceros["RazonSol"].ToString();
                        FunProveDos = TabTerceros["IdenProveDos"].ToString();
                        SucTerPaga = TabTerceros["SucurProv"].ToString();

                        //'************************ Como softland lleva el digito de verificación incluido en el nit, así se debe grabar en el detalle *****

                        if (string.IsNullOrWhiteSpace(TabTerceros["DigVeri"].ToString()))
                        {
                            NDDigVer = NitCC;
                        }
                        else
                        {
                            NDDigVer = NitCC + '-' + TabTerceros["DigVeri"].ToString();
                        }

                        SiguePro = 1;

                    }
                }

                CenCaja = TxtCenCajaD.Text;
                Cuencaja = TxtCtaConD.Text;

                //Validamos la cuenta Débito, de la caja, haber si existe y si exige tercero

                SqlCuenConta = "SELECT  [Datos ctas contables IPS].* ";
                SqlCuenConta += "FROM [GEOGRAXPSQL].[dbo].[Datos ctas contables IPS] ";
                SqlCuenConta += "WHERE  (CueContaIPS = N'" + Cuencaja + "')";

                using (SqlConnection connection = new SqlConnection(Conexion.conexionSQL))
                {
                    SqlCommand command = new SqlCommand(SqlCuenConta, connection);
                    command.Connection.Open();
                    SqlDataReader TabCuenConta = command.ExecuteReader();

                    if(TabCuenConta.HasRows == false)
                    {
                        Utils.Informa = "Lo siento pero este sistema no puede realizar el registro" + "\r";
                        Utils.Informa += "del pago, por que la cueta débito No. " + Cuencaja + "\r";
                        Utils.Informa += "no existe en el catalago de cuentas contables de la entidad." + "\r";
                        MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        //Revisamos si exige centro de costo
                        TabCuenConta.Read();

                        if(Convert.ToBoolean(TabCuenConta["RequieCentro"]) == true)
                        {
                            if (string.IsNullOrWhiteSpace(TxtCenCajaD.Text))
                            {
                                Utils.Informa = "Lo siento pero usted no ha digitado el centro" + "\r";
                                Utils.Informa += "de costo de la cuenta contable a debitar, por" + "\r";
                                Utils.Informa += "lo tanto no se puede continuar con el proceso." + "\r";
                                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            else
                            {
                                CenCaja = "000";
                            }
                        } // if(Convert.ToBoolean(TabCuenConta["RequieCentro"]) == true)

                        if (TabCuenConta["RequieNit"].ToString() == "1")
                        {
                            //Que tipo de tercero, lo normal es que se asocia a la cuenta
                            if (TabCuenConta["SiterObliga"].ToString() == "1")
                            {
                                TipDocDeb = TabCuenConta["TipoDocCuen"].ToString();
                                NumDocDeb = TabCuenConta["NumDocCuen"].ToString();
                                SucurDeb = TabCuenConta["SucurCuen"].ToString();
                                SiguePro = 1;
                            }
                            else
                            {
                                if (TabCuenConta["SiterObliga"].ToString() == "2")
                                {
                                    //Por tipo de pago puede cambiarse

                                    TipDocDeb = CboTipoDocDebi.SelectedValue.ToString();
                                    NumDocDeb = TxtNumDocDebi.Text;
                                    SucurDeb = TxtSucuCtaDebi.Text;
                                    SiguePro = 1;

                                }
                                else
                                {
                                    Utils.Informa = "Lo siento pero el número del documento de" + "\r";
                                    Utils.Informa += "identificación del tercero no se encuentra" + "\r";
                                    Utils.Informa += "parametrizado en la cuenta contable " + Cuencaja + "\r";
                                    Utils.Informa += "Por lo tanto no se puede continuar." + "\r";
                                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }// Final  if (TabCuenConta["SiterObliga"].ToString() == "2")
                            }// Final if(TabCuenConta["SiterObliga"].ToString() == "1")

                            //Verificamos is el nit existe

                            if (SiguePro == 1)
                            {

                                SqlTerceros = "SELECT TipoDocu, IdenProve, DigVeri, SucurProv, RazonSol, IdenProveDos ";
                                SqlTerceros += "FROM [GEOGRAXPSQL].[dbo].[Datos proveedores] ";
                                SqlTerceros += "WHERE TipoDocu='" + TipDocDeb + "' AND IdenProve='" + NumDocDeb + "'  AND SucurProv='" + SucurDeb + "' ";

                                using (SqlConnection connection2 = new SqlConnection(Conexion.conexionSQL))
                                {
                                    SqlCommand command2 = new SqlCommand(SqlTerceros, connection2);
                                    command2.Connection.Open();
                                    SqlDataReader TabTerceros = command2.ExecuteReader();

                                    if(TabTerceros.HasRows == false)
                                    {
                                        Utils.Informa = "Lo siento pero el documento de identificación" + "\r";
                                        Utils.Informa += "de la cuenta contable débito (Caja) a registrar," + "\r";
                                        Utils.Informa += "no existe en la base de datos de proveedores, por" + "\r";
                                        Utils.Informa += "lo tanto no se puede realizar el ingreso de caja." + "\r";
                                        MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                    else
                                    {
                                        TabTerceros.Read();

                                        if(TxtNumDocDebiDos.Text != TabTerceros["IdenProveDos"].ToString())
                                        {
                                            Utils.Informa = "Lo siento pero el documento de identificación dos" + "\r";
                                            Utils.Informa += "de la cuenta contable débito (Caja) a registrar," + "\r";
                                            Utils.Informa += "es diferente al registrado en base de datos, por" + "\r";
                                            Utils.Informa += "lo tanto no se puede realizar el ingreso de caja." + "\r";
                                            MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            return;
                                        }
                                        else
                                        {

                                            //************************ Como softland lleva el digito de verificación incluido en el nit, así se debe grabar en el detalle *****
                                            if (string.IsNullOrWhiteSpace(TabTerceros["DigVeri"].ToString()))
                                            {
                                                //El documento sigue siendo el mismo
                                                NitDebitar = TabTerceros["IdenProve"].ToString();
                                            }
                                            else
                                            {
                                                NitDebitar = TabTerceros["IdenProve"].ToString() + '-' + TabTerceros["DigVeri"].ToString();
                                            }

                                            NitDosDebi = TabTerceros["IdenProveDos"].ToString();
                                            SiguePro = 1;

                                        }


                                    }
                                }//Fin TabTerceros
                            }//Sigo Pro
                        }
                        else
                        {
                            TipDocDeb = "NIT";
                            NumDocDeb = "0";
                            SucurDeb = "000";
                            NitDebitar = "0";
                            NitDosDebi = "0";
                        }

                    }
                }// Fin TabCuenConta

                //Revisamos si la entidad tiene algún sistema contable

                CodEnti = LblCodEntiFac.Text;

                AnVigen = DateTime.Now.Year.ToString();

                MesPerio = DateTime.Now.Month < 9 ? "0" + DateTime.Now.Month.ToString() : DateTime.Now.Month.ToString();

                FunConta = TieneContabilidad(CodEnti);

                switch (FunConta)
                {
                    case "0": //No se tiene un sistema de contabilidad vinculado a SIIGHOS PLUS
                        InformaST = "";
                        break;
                    case "1"://Contabilidad SOFTLAND

                        CodDocuMov = TxtCodDoc.Text; //Codifo del documento del movimiento

                        PreDoc = TxtPreDoc.Text;

                        //Revisamos si el periodo contable existe de acuerdo a la fecha del documento

                        FunValiPer = ValidarPerioConta(AnVigen, MesPerio);

                        switch (FunValiPer)
                        {
                            case 0: //Error en la funcion
                                return;
                            case 1: //No existe el periodo

                                Utils.Informa = "Lo siento pero en este momento no se le puede" + "\r";
                                Utils.Informa += "registrar el pago y realizar la CONTABILIDAD" + "\r";
                                Utils.Informa += "en SOFTLAND, porque los datos del periodo" + "\r";
                                Utils.Informa += "contable no estan registrados. " + "\r";
                                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            case 3: //Periodo Cerrado

                                Utils.Informa = "Lo siento pero en este momento no se le puede" + "\r";
                                Utils.Informa += "registrar el pago y realizar la CONTABILIDAD" + "\r";
                                Utils.Informa += "en SOFTLAND, porque el periodo contable se" + "\r";
                                Utils.Informa += "encuentra cerrado. " + "\r";
                                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            default:
                                break;
                        }

                        //Validamos en softland el tercero que se seleccionó para el pago

                        FunTerceST = ValidarTerceroSofTland(NDDigVer, SucTerPaga);

                        switch (FunTerceST)
                        {
                            case "-1":
                                return;
                            case "-3":
                                Utils.Informa = "Lo siento pero en este momento no se le puede"  + "\r";
                                Utils.Informa += "registrar el pago y realizar la CONTABILIDAD porque" + "\r";
                                Utils.Informa += "los datos del tercero no estan registrados en SOFTLAND. " + "\r";
                                Utils.Informa += "Nit uno: " + NDDigVer +" Sucursal: " + CardiNi + " Nit dos: " + FunProveDos + "\r";
                                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            default:

                                //Revisamos si el Nit dos es igual al encontrado
                                if (FunProveDos == FunTerceST)
                                {
                                    //Cuando se tiene SofTland todo bien hasta aquí
                                    //Validamos las cuentas contables del débito y los créditos

                                    FunValCtaD = ValidarCtaContaST(Cuencaja, CenCaja);

                                    switch (FunValCtaD)
                                    {
                                        case "-1"://Error en la funcion
                                            return;
                                        case "-3": //No se encontró el Tercero en la tabla de proveedores
                                            Utils.Informa = "Lo siento pero en este momento no se le puede" + "\r";
                                            Utils.Informa += "registrar el pago y realizar la CONTABILIDAD porque" + "\r";
                                            Utils.Informa += "la cuenta contable débito no esta registrada en SOFTLAND." + "\r";
                                            MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            return;
                                        case "-4":
                                            Utils.Informa = "Lo siento pero en este momento no se le puede" + "\r";
                                            Utils.Informa += "registrar el pago y realizar la CONTABILIDAD porque" + "\r";
                                            Utils.Informa += "el centro de costo del débito no esta registrado en SOFTLAND." + "\r";
                                            MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            return;
                                        default:


                                            //Validamos las cuentas contables del crédito, para ello abro la instancia local



                                            if(GridDetalleRecibos.Rows.Count <= 0)
                                            {
                                                Utils.Informa = "Lo siento pero en este momento no se le puede" + "\r";
                                                Utils.Informa += "el detalle de pago del recibo de caja a registrar," + "\r";
                                                Utils.Informa += "por lo tanto no se puede continuar." + "\r";
                                                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                return;
                                            }
                                            else
                                            {
                                                TolDebiCaja = 0;
                                                RG = 0;
                                                ErrConti = 0;
                                                foreach (DataGridViewRow row in GridDetalleRecibos.Rows)
                                                {
                                                    canti = Convert.ToInt32(row.Cells["CantiSer1"].Value.ToString());
                                                    ValorUni = Convert.ToInt32(row.Cells["ValorUnita1"].Value.ToString());

                                                    if(canti > 0 && ValorUni > 0)
                                                    {

                                                        CCon = row.Cells["CuentaContable1"].Value.ToString();
                                                        CCostoCre = row.Cells["CentroCuenta"].Value.ToString();
                                                        TolDebiCaja += Convert.ToDecimal(row.Cells["ValorTotal1"].Value.ToString());
                                                        RG += 1;

                                                        FunValCtaD = ValidarCtaContaST(CCon, CCostoCre);

                                                        switch (FunValCtaD)
                                                        {
                                                            case "1": //Error en la función
                                                                ErrConti += 1;
                                                                break;
                                                            case "-3"://No se encontró el Tercero en la tabla de proveedores
                                                                Utils.Informa = "Lo siento pero en este momento no se le puede" + "\r";
                                                                Utils.Informa += "registrar el pago y realizar la CONTABILIDAD porque" + "\r";
                                                                Utils.Informa += "la cuenta contable crédito " + CCon + " no esta registrada en SOFTLAND." + "\r";
                                                                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                                ErrConti += 1;
                                                                break;
                                                            case "-4":
                                                                Utils.Informa = "Lo siento pero en este momento no se le puede" + "\r";
                                                                Utils.Informa += "registrar el pago y realizar la CONTABILIDAD porque" + "\r";
                                                                Utils.Informa += "porque el centro de costo del crédito " + CCostoCre + " no esta registrado en SOFTLAND." + "\r";
                                                                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                                ErrConti += 1;
                                                                break;
                                                            default:
                                                                break;
                                                        }
                                                    }//Final   if(canti > 0 && ValorUni > 0)
                                                }


                                                if(TolDebiCaja <= 0)
                                                {
                                                    Utils.Informa = "Lo siento pero el valor del pago no puede ser" + "\r";
                                                    Utils.Informa += "una cifra menor o igual a cero, favor revisar" + "\r";
                                                    Utils.Informa += "los valores registrados en el detalle." + "\r";
                                                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                    return;
                                                }

                                                if(ErrConti > 0)
                                                {
                                                    SiguePro = 0;
                                                    return;
                                                }
                                                else
                                                {
                                                    if(SiguePro == 0)
                                                    {
                                                        return;
                                                    }
                                                    else
                                                    {
                                                        SiguePro = 1;
                                                        InformaST = "Se hace el registro contable en SOFTLAND.";
                                                    }
                                                }
                                            }
                                            break;
                                    }//Fin FunValCtaD
                                }
                                else
                                {
                                    Utils.Informa = "Lo siento pero el valor del pago no puede ser" + "\r";
                                    Utils.Informa += "registrar el pago y realizar la CONTABILIDAD porque" + "\r";
                                    Utils.Informa += "los datos del Nit no concuerdan:." + "\r";
                                    Utils.Informa += "En SOFTLAND: " + FunTerceST + " y en SIIGHOS PLUS: " + FunProveDos +"\r";
                                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }//Final de FunProveDos = FunTerceST

                                break;
                        }

                    break;
                    case "-1": //Errro en la funcion
                        return;
                    default:

                        //Tiene sistema de contabiliad aún no adaptado a  SIIGHOS PLUS
                        InformaST = "";

                        break;   
                }

                Utils.Informa = "¿Usted desea expedir un recibo de caja a nombre" + "\r";
                Utils.Informa += "de " + NomReci + ".?" +  "\r";
                Utils.Informa += "Por valor neto de: " + NetPag +  "\r";
                Utils.Informa += "Forma de pago: " + FormPa + "\r";
                Utils.Informa += InformaST;

                var res = MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (res == DialogResult.Yes)
                {
                    //Proceda a buscar el consecutivo de caja

                    UsReci = lblCodigoUser.Text;

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


                    //Procedemos a guardar los datos de recibo de pago a la tabla principal

                    QPaga = "Pago total";


                    X = "4";  //'No afecta a ningún documento cruce
                    Y = "0"; //'Número de documento cruce.
                    Z = "1"; //' Paga NETO

                    SqlReciCaja = "SELECT * FROM [BDCAJASQL].[dbo].[Datos recibos de caja] ";
                    SqlReciCaja = SqlReciCaja + "WHERE ReciboCaja = '" + FunReciNum + "' ";
                    SqlReciCaja = SqlReciCaja + "ORDER BY ReciboCaja";

                    int proce = 0;

                    using (SqlConnection connection = new SqlConnection(Conexion.conexionSQL))
                    {
                        SqlCommand command = new SqlCommand(SqlReciCaja, connection);
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
                        "AnuladoRecibo," +
                        "ObserCaja" +
                        ")" +
                        "VALUES" +
                        "(" +
                        "'" + FunReciNum + "'," +
                        "'" + CodCa + "'," +
                        "'" + HisPa + "'," +
                        "'" + CboRegimUsua.SelectedValue.ToString() + "'," +
                        "'" + TD + "'," +
                        "'" + NitCC + "'," +
                        "'" + CardiNi + "'," +
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
                        "'" + false + "'," +
                        "'" + TxtObservaCaja.Text + "'" +
                        ")";

                        bool estaRegis = Conexion.SqlInsert(Utils.SqlDatos);

                        //Siga a grabar el detalle


                        Utils.SqlDatos = "INSERT [BDCAJASQL].[dbo].[Datos detalles recibos de caja] (ReciboNum,CuentaContable,DetaPagoCaja,CentroCosto,CantidadCaja,PorcenPago,ValorUnitaCaja,NatuMovi,DebiCaja,TipDocConta,NumDocConta,SucurConta,NitDosConta) ";
                        Utils.SqlDatos += "VALUES (@ReciboNum,@CuentaContable,@DetaPagoCaja,@CentroCosto,@CantidadCaja,@PorcenPago,@ValorUnitaCaja,@NatuMovi,@DebiCaja,@TipDocConta,@NumDocConta,@SucurConta,@NitDosConta)";



                        List<SqlParameter> parameters = new List<SqlParameter>();

                        //Grabamos primero el débito

                        if (NetPag > 0)
                        {
                            ComDes = "Ingresos generales de caja";
                            parameters = new List<SqlParameter>
                                                {
                                                    new SqlParameter("@ReciboNum", SqlDbType.VarChar){ Value = FunReciNum},
                                                    new SqlParameter("@CuentaContable", SqlDbType.VarChar){ Value = Cuencaja},
                                                    new SqlParameter("@DetaPagoCaja", SqlDbType.VarChar){ Value = ComDes},
                                                    new SqlParameter("@CentroCosto", SqlDbType.VarChar){ Value = CenCaja},
                                                    new SqlParameter("@CantidadCaja", SqlDbType.VarChar){ Value = 1},
                                                    new SqlParameter("@PorcenPago", SqlDbType.VarChar){ Value = 100},
                                                    new SqlParameter("@ValorUnitaCaja", SqlDbType.VarChar){ Value = 0},
                                                    new SqlParameter("@NatuMovi", SqlDbType.VarChar){ Value = "D"},
                                                    new SqlParameter("@DebiCaja", SqlDbType.VarChar){ Value = NetPag},
                                                    new SqlParameter("@TipDocConta", SqlDbType.VarChar){ Value = TipDocDeb},
                                                    new SqlParameter("@NumDocConta", SqlDbType.VarChar){ Value = NitDebitar},
                                                    new SqlParameter("@SucurConta", SqlDbType.VarChar){ Value = SucurDeb},
                                                    new SqlParameter("@NitDosConta", SqlDbType.VarChar){ Value = NitDosDebi}, //Se empieza a grabar a partir del 13 de julio de 2016
                                                };

                            estaRegis = Conexion.SqlInsert(Utils.SqlDatos, parameters);
                        }


                        if (GridDetalleRecibos.Rows.Count > 0)
                        {

                            decimal valorNeto = 0;
                            decimal valorUnitaCaja = 0;
                            string valorneto = "";

                            Utils.SqlDatos = "INSERT [BDCAJASQL].[dbo].[Datos detalles recibos de caja] (ReciboNum,CuentaContable,CodServi,DetaPagoCaja,CentroCosto,CantidadCaja,PorcenPago,ValorUnitaCaja,NatuMovi,CrediCaja,TipDocConta,NumDocConta,SucurConta,NitDosConta) ";
                            Utils.SqlDatos += "VALUES (@ReciboNum,@CuentaContable,@CodServi,@DetaPagoCaja,@CentroCosto,@CantidadCaja,@PorcenPago,@ValorUnitaCaja,@NatuMovi,@CrediCaja,@TipDocConta,@NumDocConta,@SucurConta,@NitDosConta)";



                            foreach (DataGridViewRow row in GridDetalleRecibos.Rows)
                            { 
                           
                                if(row.Cells["CodigoServi"].Value != null)
                                {

                                    string centroCosto = row.Cells["CentroCuenta"].Value.ToString();
                                    valorNeto = Convert.ToDecimal(row.Cells["ValorNeto1"].Value);

                                    if (valorNeto > 0)
                                    {

                                        valorUnitaCaja = Convert.ToDecimal(row.Cells["ValorNeto1"].Value) / Convert.ToDecimal(row.Cells["CantiSer1"].Value);

                                        parameters = new List<SqlParameter>
                                        {
                                            new SqlParameter("@ReciboNum", SqlDbType.VarChar){ Value = FunReciNum},
                                            new SqlParameter("@CuentaContable", SqlDbType.VarChar){ Value = row.Cells["CuentaContable1"].Value.ToString() },
                                            new SqlParameter("@CodServi", SqlDbType.VarChar){ Value = row.Cells["CodigoServi"].Value.ToString()},
                                            new SqlParameter("@DetaPagoCaja", SqlDbType.VarChar){ Value = row.Cells["NombreServi1"].Value.ToString()},
                                            new SqlParameter("@CentroCosto", SqlDbType.VarChar){ Value = row.Cells["CentroCuenta"].Value.ToString()}, //REVISAR
                                            new SqlParameter("@CantidadCaja", SqlDbType.VarChar){ Value = row.Cells["CantiSer1"].Value.ToString()},
                                            new SqlParameter("@PorcenPago", SqlDbType.VarChar){ Value = row.Cells["PorcentajePago1"].Value.ToString()},
                                            new SqlParameter("@ValorUnitaCaja", SqlDbType.VarChar){ Value = valorUnitaCaja},
                                            new SqlParameter("@NatuMovi", SqlDbType.VarChar){ Value = "C"},
                                            new SqlParameter("@CrediCaja", SqlDbType.VarChar){ Value = row.Cells["ValorNeto1"].Value.ToString()}, //EZA A APLICAR DESDE EL 01 DE MARZO DE 2019
                                            new SqlParameter("@TipDocConta", SqlDbType.VarChar){ Value = row.Cells["TipoDocDeTer"].Value.ToString()},
                                            new SqlParameter("@NumDocConta", SqlDbType.VarChar){ Value = NDDigVer},
                                            new SqlParameter("@SucurConta", SqlDbType.VarChar){ Value = SucTerPaga},
                                            new SqlParameter("@NitDosConta", SqlDbType.VarChar){ Value = FunProveDos}, //Se empieza a grabar a partir del 13 de julio de 2016
                                        };

                                        estaRegis = Conexion.SqlInsert(Utils.SqlDatos, parameters);

                                        TolDebiCaja += Convert.ToDecimal(row.Cells["ValorNeto1"].Value);
                                        RG += 1;

                                    }    
                                }
                            }
                        }



                        GridDetalleRecibos.Rows.Clear();
                        
                        TxtObservaCaja.Clear();

                        //Proceda a imprimir el recibo

                        Utils.Condicion = "[Datos recibos de caja].ReciboCaja = '" + FunReciNum + "'";

                        switch (FunConta)
                        {
                            case "1": //Contabilidad SOFTLAND


                                FunConSoft = ContabiReciCajaST(FunReciNum, PreDoc, CodDocuMov);

                                switch (FunConSoft)
                                {
                                    case -1: //Erroe en la funcion
                                        break;
                                    case -3: //Dificilmente entra por aquí

                                        Utils.Informa = "Lo siento pero el recibo de caja No. " + FunReciNum + "\r";
                                        Utils.Informa += "no pudo ser contabilizado en SOFTLAND, " + "\r";
                                        Utils.Informa += "porque no se encontró en la base de datos." + "\r";
                                        MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        break;
                                    case 1: //No existe el detalle del recibo de caja

                                        Utils.Informa = "Lo siento pero el recibo de caja No. " + FunReciNum + "\r";
                                        Utils.Informa += "no pudo ser contabilizado en SOFTLAND, " + "\r";
                                        Utils.Informa += "porque no se encontró el detalle en la base de datos." + "\r";
                                        MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        break;
                                    case 2: //El débito no es igual al crédito

                                        Utils.Informa = "Lo siento pero el recibo de caja No. " + FunReciNum + "\r";
                                        Utils.Informa += "no pudo ser contabilizado en SOFTLAND, " + "\r";
                                        Utils.Informa += "porque el débito no es igual al crédito." + "\r";
                                        MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        break;
                                    case 3: //el recibo ya estaba registrado

                                        Utils.Informa = "Lo siento pero el recibo de caja No. " + FunReciNum + "\r";
                                        Utils.Informa += "no pudo ser contabilizado en SOFTLAND, " + "\r";
                                        Utils.Informa += "porque el débito no es igual al crédito.." + "\r";
                                        MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        break;
                                    default:

                                        //Se contabilizó satisfactoriamente

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

                                        Utils.SqlDatos = infoCajaSql;
                                        Utils.infNombreInforme = "Informe recibos de cajas";

                                        FrmReciboDeCajas frmReciboDeCajas = new FrmReciboDeCajas();
                                        frmReciboDeCajas.ShowDialog();

                                        Utils.Informa = "El recibo de caja No. " + FunReciNum + "\r";
                                        Utils.Informa += "se contabilizó satisfactoriamente en SOFTLAND." + "\r";
                                        MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        break;
                                }

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

                                Utils.SqlDatos = infoCajaSql;
                                Utils.infNombreInforme = "Informe recibos de cajas";

                                FrmReciboDeCajas frmReciboDeCajas2 = new FrmReciboDeCajas();
                                frmReciboDeCajas2.ShowDialog();

                                break;

                        }//Final FunConta
                    }

                }//if(res == DialogResult.Yes)
            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "hacer click sobre el botón registrar" + "\r";
                Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Utils.Titulo01 = "Control para eliminar datos";
                Utils.Informa = "¿Desea borrar todos los procedimientos o servicios registrados?";
                var res = MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if(res == DialogResult.Yes)
                {
                    GridDetalleRecibos.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "hacer click sobre el botón Borrar" + "\r";
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

                                    Utils.Informa = "¿Como quiere la presentacion" + "\r";
                                    Utils.Informa += "del recibo de caja?" + "\r";
                                    Utils.Informa += "Sí = SENCILLO" + "\r";
                                    Utils.Informa += "No = DOBLE PARTIDA" + "\r";
                                    var res = MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                                    if (res == DialogResult.Yes)
                                    {

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
                                    }
                                    else
                                    {
                                        if (res == DialogResult.No)
                                        {

                                            infoCajaSql = " SELECT [Datos recibos de caja].ReciboCaja, [Datos recibos de caja].HistorPaciente, (Trim([Apellido1] + ' ' + [Apellido2]) + ' ' + Trim([Nombre1] + ' ' + [Nombre2])) AS Paciente,  " +
                                            " [Datos recibos de caja].TipoDocu, [Datos recibos de caja].NumDocu, [Datos recibos de caja].SucuDocu, [Datos proveedores].RazonSol, [Datos recibos de caja].DocumNumero, " +
                                            " [Datos recibos de caja].EntidadDocumen, [Datos recibos de caja].FechaPagoCaja, [Datos recibos de caja].CodRegis, [Datos detalles recibos de caja].CuentaContable, " +
                                            " [Datos detalles recibos de caja].CentroCosto, [Datos detalles recibos de caja].DetaPagoCaja, [Datos ctas contables IPS].NomCConIPS, Sum([Datos detalles recibos de caja].DebiCaja) AS SumaDeDebiCaja, " +
                                            " Sum([Datos detalles recibos de caja].CrediCaja) AS SumaDeCrediCaja, Sum(([DebiCaja] -[CrediCaja])) AS SaldoReal, Sum(([CantidadCaja] *[ValorUnitaCaja])) AS VT, [Datos recibos de caja].DocuCruce, " +
                                            " [Datos recibos de caja].AnuladoRecibo, [Datos recibos de caja].FechAnulado, [Datos recibos de caja].CodiAnul, [Datos recibos de caja].RazonAnula FROM " +
                                            " [GEOGRAXPSQL].[dbo].[Datos ctas contables IPS] INNER JOIN ([GEOGRAXPSQL].[dbo].[Datos proveedores] INNER JOIN (([ACDATOXPSQL].[dbo].[Datos del Paciente] INNER JOIN [BDCAJASQL].[dbo].[Datos recibos de caja] ON[Datos del Paciente].HistorPaci = [Datos recibos de caja].HistorPaciente) " +
                                            " INNER JOIN[BDCAJASQL].[dbo].[Datos detalles recibos de caja] ON[Datos recibos de caja].ReciboCaja = [Datos detalles recibos de caja].ReciboNum) ON([Datos proveedores].TipoDocu = [Datos recibos de caja].TipoDocu) AND([Datos proveedores].IdenProve = [Datos recibos de caja].NumDocu) AND([Datos proveedores].SucurProv = [Datos recibos de caja].SucuDocu))" +
                                            " ON[Datos ctas contables IPS].CueContaIPS = [Datos detalles recibos de caja].CuentaContable WHERE " + Utils.Condicion + " GROUP BY[Datos recibos de caja].ReciboCaja, [Datos recibos de caja].HistorPaciente, (Trim([Apellido1] + ' ' + [Apellido2]) + ' ' + Trim([Nombre1] + ' ' + [Nombre2])), [Datos recibos de caja].TipoDocu, [Datos recibos de caja].NumDocu, [Datos recibos de caja].SucuDocu," +
                                            " [Datos proveedores].RazonSol, [Datos recibos de caja].DocumNumero, [Datos recibos de caja].EntidadDocumen, [Datos recibos de caja].FechaPagoCaja, [Datos recibos de caja].CodRegis, [Datos detalles recibos de caja].CuentaContable, [Datos detalles recibos de caja].CentroCosto, [Datos detalles recibos de caja].DetaPagoCaja, [Datos ctas contables IPS].NomCConIPS, " +
                                            " [Datos recibos de caja].DocuCruce,  " +
                                            " [Datos recibos de caja].AnuladoRecibo, [Datos recibos de caja].FechAnulado, [Datos recibos de caja].CodiAnul, [Datos recibos de caja].RazonAnula ";

                                            NomInfoCa = "Informe recibos de cajas contabilidad";

                                        }
                                        else
                                        {
                                            if (res == DialogResult.Cancel)
                                            {
                                                return;
                                            }
                                        }
                                    }

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
