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
    public partial class FrmPagosAFacturas : Form
    {
        public FrmPagosAFacturas()
        {
            InitializeComponent();
        }

        #region Funciones

        private bool Validaciones()
        {
            try
            {
                bool resultadoVal = true;

                if (string.IsNullOrWhiteSpace(LblCodCajAct.Text))
                {
                    Utils.Informa = "Lo siento pero mientras no se tenga" + "\r";
                    Utils.Informa += "definida la identificación de la caja," + "\r";
                    Utils.Informa += "no se puede realizar este proceso." + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    resultadoVal = false;
                    return resultadoVal;
                }

                if (string.IsNullOrWhiteSpace(TxtFacturaNo.Text))
                {
                    Utils.Informa = "Lo siento pero usted no ha digitado un número de factura válido" + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    resultadoVal = false;
                    return resultadoVal;
                }


                if (CboCuentaContable.SelectedIndex == -1)
                {
                    Utils.Informa = "Lo siento pero usted no ha digitado el número de cuenta contable del Tercero" + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    resultadoVal = false;
                    return resultadoVal;
                }

                //Revisamos si seleccionó un tipo de documento correcto

                if (CboTipDocFac.SelectedIndex == -1)
                {
                    Utils.Informa = "Lo siento pero usted no ha seleccionado" + "\r";
                    Utils.Informa += "el tipo de documento de identificación" + "\r";
                    Utils.Informa += "del tercero que cancela la factura." + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    resultadoVal = false;
                    return resultadoVal;
                }

                if (string.IsNullOrWhiteSpace(TxtNitCC.Text))
                {
                    Utils.Informa = "Lo siento pero usted no ha digitado" + "\r";
                    Utils.Informa += "el número de identificación válido" + "\r";
                    Utils.Informa += "para expedir el recibo de caja." + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    resultadoVal = false;
                    return resultadoVal;
                }

                if (string.IsNullOrWhiteSpace(TxtCardiRecibo.Text))
                {
                    Utils.Informa = "Lo siento pero usted no ha digitado" + "\r";
                    Utils.Informa += "el código de la sucursal válido" + "\r";
                    Utils.Informa += "para expedir el recibo de caja." + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    resultadoVal = false;
                    return resultadoVal;
                }

                if (string.IsNullOrWhiteSpace(TxtValorPagos.Text) || Convert.ToDouble(TxtValorPagos.Text) <= 0)
                {
                    Utils.Informa = "Lo siento pero usted no digitado el valor del pago o el valor del pago no puede ser menor o igual cero " + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    resultadoVal = false;
                    return resultadoVal;
                }



                if (string.IsNullOrWhiteSpace(TxtNomPaci.Text))
                {
                    Utils.Informa = "Lo siento el número de factura digitado no" + "\r";
                    Utils.Informa += "tiene datos relacionales en el sistema." + "\r";
                    Utils.Informa += "Por favor corrija el número." + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    resultadoVal = false;
                    return resultadoVal;
                }


                return resultadoVal;

            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "en la funcion Validaciones" + "\r";
                Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
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

                                    ValDebitos = ValDebitos + Convert.ToDouble(TabDetaCaja["DebiCaja"]);
                                    VCreditos = VCreditos + Convert.ToDouble(TabDetaCaja["CrediCaja"]);

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
        private string ConseReciCaja(int Actualizo, string US, string CCj)
        {
            try
            {
                //Esta función permite devolver el consecutivo de recibos de caja

                //'*************************** A partir del 24 de septiembre de 2014 se modifica ***************************
                //'*****************Para invocar esta función debe estar abierta la base de datos de caja ********************

                string Convertido = "";
                string SqlConseCaja = "SELECT * FROM [BDCAJASQL].[dbo].[Datos cajas y consecutivos] ";
                SqlConseCaja += "WHERE CodCaja= '" + CCj + "' ";
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

                    CboTipDocFac.SelectedValue = Utils.TipDocPre;
                    TxtNitCC.Text = Utils.NumDocPre;
                    TxtCardiRecibo.Text = Utils.SucurPre;
                    CboCuentaContable.SelectedValue = Utils.CuentaContable;

                    LblCodCajAct.Text = Utils.CodCaja;
                    LblNomCajAct.Text = Utils.NombgPre;

                    TxtCenCajaD.Text = Utils.CenCosCaja;
                    TxtCtaConD.Text = Utils.CuenConta;

                    string SqlDocConta = "SELECT [Datos documentos contables].CodModu, [Datos documentos contables].PreDocu, ";
                    SqlDocConta = SqlDocConta + "[Datos documentos contables].NumDocu ";
                    SqlDocConta = SqlDocConta + "FROM [BDADMINSIG].[dbo].[Datos documentos contables] ";
                    SqlDocConta = SqlDocConta + "WHERE ((([Datos documentos contables].CodModu) = '01')) ";
                    SqlDocConta = SqlDocConta + "ORDER BY [Datos documentos contables].CodModu;";

                    using (SqlConnection connection = new SqlConnection(Conexion.conexionSQL))
                    {
                        SqlCommand command = new SqlCommand(SqlDocConta, connection);
                        command.Connection.Open();
                        SqlDataReader DrDocuConta = command.ExecuteReader();

                        if (DrDocuConta.HasRows == false)
                        {
                            TxtCodDoc.Text = "0";
                            TxtPreDoc.Text = "0";
                        }
                        else
                        {
                            DrDocuConta.Read();
                            TxtCodDoc.Text = DrDocuConta["NumDocu"].ToString();
                            TxtPreDoc.Text = DrDocuConta["PreDocu"].ToString();
                        }
                    }

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
        private void BuscarProve()
        {
            try
            {
                string SucurTer, SqlEmpTer, TDT = "", CNT = "";
                int ContiMos;

                if (string.IsNullOrWhiteSpace(TxtNitCC.Text))
                {
                    return;
                }

                CNT = TxtNitCC.Text;

                //Revisamos si ya seleccionó el tipo de documento

                if (CboTipDocFac.SelectedIndex == -1)
                {
                    return;
                }

               

                if(CboTipDocFac.SelectedValue.ToString() == "NI")
                {
                    TDT = "NIT";
                }
                else
                {
                    TDT = CboTipDocFac.SelectedValue.ToString();
                }


                //Revisamos si se digitó la sucursal

                if (string.IsNullOrWhiteSpace(TxtCardiRecibo.Text))
                {
                    return;
                }


                SucurTer = TxtCardiRecibo.Text;

                //Proceda a buscarlo en la base de datos

                SqlEmpTer = "SELECT RazonSol, SucurProv ";
                SqlEmpTer = SqlEmpTer + "FROM [GEOGRAXPSQL].[dbo].[Datos proveedores] ";
                SqlEmpTer = SqlEmpTer + "WHERE TipoDocu ='" + TDT + "' AND IdenProve ='" + CNT + "' AND SucurProv ='" + SucurTer + "' ";
                SqlEmpTer = SqlEmpTer + "ORDER BY TipoDocu ";



                using (SqlConnection connection = new SqlConnection(Conexion.conexionSQL))
                {

                    SqlCommand command = new SqlCommand(SqlEmpTer, connection);
                    command.Connection.Open();
                    SqlDataReader TabEmpTer = command.ExecuteReader();

                    if (TabEmpTer.HasRows == false)
                    {
                        ContiMos = 1;
                    }
                    else
                    {
                        TabEmpTer.Read();

                        TxtNombreTercero.Text = TabEmpTer["RazonSol"].ToString();
                        TxtCardiRecibo.Text = TabEmpTer["SucurProv"].ToString();
                        ContiMos = 0;
                    }

                }


                if (ContiMos == 1)
                {
                    Utils.Titulo01 = "Control de ejecucion";
                    Utils.Informa = "Documento de identificación digitado" + "\r";
                    Utils.Informa += "no existe en la base de datos, por" + "\r";
                    Utils.Informa += "tanto no se puede registrar nada." + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "despues de actualizar el combo de tipo de documento" + "\r";
                Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarCombobox()
        {
            try
            {
                this.CboCuentaContable.DataSource = null;
                this.CboCuentaContable.Items.Clear();


                Utils.SqlDatos = "SELECT [Datos ctas contables IPS].CueContaIPS, [Datos ctas contables IPS].NomCConIPS" +
                " FROM [GEOGRAXPSQL].[dbo].[Datos ctas contables IPS]" +
                "  WHERE ((([Datos ctas contables IPS].CueContaIPS) <> '0000000') AND((Left([CueContaIPS], 2)) = '13'" +
                " Or (Left([CueContaIPS], 2)) = '14') AND(([Datos ctas contables IPS].Activa_NomCuenIPS) = 'True')) " +
                " ORDER BY [Datos ctas contables IPS].CueContaIPS, [Datos ctas contables IPS].NomCConIPS; ";

                DataSet dataSet = Conexion.SQLDataSet(Utils.SqlDatos);

                if (dataSet != null && dataSet.Tables.Count > 0)
                {
                    this.CboCuentaContable.DataSource = dataSet.Tables[0];
                    this.CboCuentaContable.ValueMember = "CueContaIPS";
                    this.CboCuentaContable.DisplayMember = "NomCConIPS";
                }

                this.CboRegimUsua.DataSource = null;
                this.CboRegimUsua.Items.Clear();


                Utils.SqlDatos = "SELECT [Datos tipos de usuarios].CodTipoUsuar, [Datos tipos de usuarios].NomTipo " +
                                " FROM [Datos tipos de usuarios] ORDER BY [Datos tipos de usuarios].NomTipo; ";

                DataSet dataSet2 = Conexion.SQLDataSet(Utils.SqlDatos);

                if (dataSet2 != null && dataSet2.Tables.Count > 0)
                {
                    this.CboRegimUsua.DataSource = dataSet2.Tables[0];
                    this.CboRegimUsua.ValueMember = "CodTipoUsuar";
                    this.CboRegimUsua.DisplayMember = "NomTipo";
                }

                this.CboTipDocFac.DataSource = null;
                this.CboTipDocFac.Items.Clear();


                Utils.SqlDatos = "SELECT [Datos documentos empresas].CodIdenti, " +
                                " [Datos documentos empresas].NomIdenti FROM " +
                                " [ACDATOXPSQL].[dbo].[Datos documentos empresas] ORDER BY[Datos documentos empresas].CodIdenti, [Datos documentos empresas].NomIdenti; ";

                DataSet dataSet3 = Conexion.SQLDataSet(Utils.SqlDatos);

                if (dataSet3 != null && dataSet3.Tables.Count > 0)
                {
                    this.CboTipDocFac.DataSource = dataSet3.Tables[0];
                    this.CboTipDocFac.ValueMember = "CodIdenti";
                    this.CboTipDocFac.DisplayMember = "NomIdenti";
                }


                this.CboLIstaBancos.DataSource = null;
                this.CboLIstaBancos.Items.Clear();


                Utils.SqlDatos = "SELECT [Datos de los bancos].CodiBanco, [Datos de los bancos].NomBanco,  " +
                                " [Datos de los bancos].TipNit, [Datos de los bancos].NitBanco,  " +
                                " [Datos de los bancos].SucurNit, [Datos de los bancos].TipoBanco FROM[GEOGRAXPSQL].[dbo].[Datos de los bancos] ORDER BY [Datos de los bancos].NomBanco; ";

                DataSet dataSet4 = Conexion.SQLDataSet(Utils.SqlDatos);

                if (dataSet4 != null && dataSet4.Tables.Count > 0)
                {
                    this.CboLIstaBancos.DataSource = dataSet4.Tables[0];
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

        #endregion

        #region RadioButtons

        private void RbEfect_CheckedChanged(object sender, EventArgs e)
        {
            CboLIstaBancos.Visible = false;
            TxtNumDocumentoP.Visible = false;
            TxtCenCajaD.Text = "111";
            TxtCtaConD.Text = "110501";
        }
        private void RbCheque_CheckedChanged(object sender, EventArgs e)
        {
            CboLIstaBancos.Visible = true;
            TxtNumDocumentoP.Visible = true;
            LblDocumentoPago.Text = "Cheque No.";
            TxtCenCajaD.Text = "111";
            TxtCtaConD.Text = "110501";
        }
        private void RbTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            CboLIstaBancos.Visible = true;
            TxtNumDocumentoP.Visible = true;

            LblDocumentoPago.Text = "Recibo No.";

            TxtCenCajaD.Text = "112";
            TxtCtaConD.Text = "112005";
        }
        private void RbBonos_CheckedChanged(object sender, EventArgs e)
        {
            CboLIstaBancos.Visible = false;
            TxtNumDocumentoP.Visible = false;

            TxtCenCajaD.Text = "112";
            TxtCtaConD.Text = "112005";
        }

        #endregion

        #region Botones
        private void BtnRegistraCaja_Click(object sender, EventArgs e)

        {
            try
            {

                string FR, NumEnti = "", SqlReciCaja = "", FunReciNum = "", SqlFacturas = "", ND01, SqlConsumos, BN01, Enti = "", CCon, Paci01, SqlTerceros, CCos, NCC, CarT, Estandatos, Paci02, FunTer, ForPa = "", UsReci, HisPa, Tipag = "", QPaga = "", DetaPago = "";
                string Para01, SqlCuenConta, Para02, Para03, Para04, Para05, Para06, SqlDatos, X, Y, Z = "", EnRutardatos, TM = "", T, ND, CodCa;
                string Cuencaja, InformaST = "", CenCaja, Cuencobro, RegUsu, SucTerCaj, CuenConsu, CCostoCre, NDDigVer, TipDocCaja = "", NumDocCaja = "";
                string SucCaja = "", NitDosCaja = "", AnVigen, MesPerio, CodEnti, FunConta, CodDocuMov = "", PreDoc = "", FunProveDos, FunTerceST, FunValCtaD;
                string CuentaCredito, CostoCredi;
                double PaReg, SF, SC, Por01 = 0, PagoCenCosto = 0, Salcuencobro, ValNet, ValFacDesc, PagReal, TolCopFac, TolNetFac;
                int FunCaja, SofTien, FunValiPer, FunConSoft, CanReg;
                bool estadoValid, evaluapago;
                Utils.Titulo01 = "Control para expedir recibos de caja";



                //Se hacen las validaciones
                estadoValid = Validaciones();


                //Si estadoValid llega falso se sale inmediatamente
                if (!estadoValid)
                {
                    return;
                }


                CodCa = LblCodCajAct.Text;
                T = CboTipDocFac.SelectedValue.ToString();
                if (T == "NI")
                {

                    T = "NIT";

                }
                ND = TxtNitCC.Text;
                FR = TxtFacturaNo.Text;
                CCon = CboCuentaContable.SelectedValue.ToString();
                SucTerCaj = TxtCardiRecibo.Text;
                PaReg = Convert.ToDouble(TxtValorPagos.Text);
                CanReg = 1;
                X = "1"; // Documento cruce es la factura
                Y = FR; //Número de la factura.
                RegUsu = CboRegimUsua.SelectedValue.ToString();

                AnVigen = DateTime.Now.Year.ToString();

                //Se hace para que del mes 1 al 9. Los devuelva con un 0 a la izquierda
                MesPerio = DateTime.Now.Month <= 9 ? "0" + DateTime.Now.Month.ToString() : DateTime.Now.Month.ToString();


                Paci01 = TxtNomPaci.Text;

                //Busque el nombre del tercero al cual le registra el pago (Recibo)

                SqlTerceros = "SELECT TipoDocu, IdenProve, SucurProv, RazonSol, DigVeri, IdenProveDos ";
                SqlTerceros = SqlTerceros + "FROM [GEOGRAXPSQL].[dbo].[Datos proveedores] ";
                SqlTerceros = SqlTerceros + "WHERE TipoDocu='" + T + "' AND IdenProve='" + ND + "'  AND SucurProv='" + SucTerCaj + "' ";
                SqlTerceros = SqlTerceros + "ORDER BY TipoDocu";


                using (SqlConnection connection = new SqlConnection(Conexion.conexionSQL))
                {
                    SqlCommand command = new SqlCommand(SqlTerceros, connection);
                    command.Connection.Open();
                    SqlDataReader TabTerceros = command.ExecuteReader();


                    if (TabTerceros.HasRows == false)
                    {
                        Utils.Informa = "Lo siento pero el documento de identificación" + "\r";
                        Utils.Informa += "del tercero, no se encuentra registrado en la" + "\r";
                        Utils.Informa += "base de datos, por lo tanto no se puede expedir" + "\r";
                        Utils.Informa += "el recibo de caja para el pago de la factura" + "\r";
                        MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        //Tome el nombre del tercero

                        TabTerceros.Read();

                        FunTer = TabTerceros["RazonSol"].ToString();

                        FunProveDos = TabTerceros["IdenProveDos"].ToString();

                        //************************ Como softland lleva el digito de verificación incluido en el nit, así se debe grabar en el detalle *****

                        if (string.IsNullOrWhiteSpace(TabTerceros["DigVeri"].ToString()) || TabTerceros["DigVeri"].ToString() == "")
                        {
                            NDDigVer = ND; //No lleva digito de verificación
                        }
                        else
                        {
                            NDDigVer = ND + "-" + TabTerceros["DigVeri"].ToString();
                        }
                    }
                }

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


                        ForPa = "Pago con tarjeta de credito " + CboLIstaBancos.Text;
                        Tipag = "TC";
                        Enti = CboLIstaBancos.Text;
                        NumEnti = TxtNumDocumentoP.Text;

                        break;

                    case 4:


                        ForPa = "Pago con bonos ";
                        Tipag = "BO";
                        Enti = null;
                        NumEnti = null;

                        break;
                    default:
                        break;
                }//Final de switch

                Cuencaja = TxtCtaConD.Text;
                CenCaja = TxtCenCajaD.Text;

                //Validamos la cuenta Débito, de la caja, haber si existe y si exige tercero

                SqlCuenConta = "SELECT [Datos ctas contables IPS].* ";
                SqlCuenConta = SqlCuenConta + "FROM [GEOGRAXPSQL].[dbo].[Datos ctas contables IPS] ";
                SqlCuenConta = SqlCuenConta + "WHERE  (CueContaIPS = N'" + Cuencaja + "')";


                using (SqlConnection connection = new SqlConnection(Conexion.conexionSQL))
                {
                    SqlCommand command = new SqlCommand(SqlCuenConta, connection);
                    command.Connection.Open();
                    SqlDataReader TabCuenConta = command.ExecuteReader();

                    if (TabCuenConta.HasRows == false)
                    {
                        Utils.Informa = "Lo siento pero este sistema no puede realizar el registro" + "\r";
                        Utils.Informa += "del pago, por que la cueta débito No. " + Cuencaja + "\r";
                        Utils.Informa += "no existe en el catalago de cuentas contables de la entidad." + "\r";
                        MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        TabCuenConta.Read();
                        //Revisamos su exige centro de costo

                        if (Convert.ToBoolean(TabCuenConta["RequieCentro"]) == true)
                        {
                            if (string.IsNullOrWhiteSpace(TxtCenCajaD.Text) || TxtCenCajaD.Text == "000")
                            {
                                Utils.Informa = "Lo siento pero usted no ha digitado el centro" + "\r";
                                Utils.Informa += "de costo de la cuenta contable a debitar, por" + "\r";
                                Utils.Informa += "lo tanto no se puede continuar con el proceso." + "\r";
                                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        else
                        {
                            CenCaja = "000";
                        }//Final de RequieCentro = True

                        //Revisamos si requiere tercero

                        int RequieNit = Convert.ToInt32(TabCuenConta["RequieNit"].ToString());


                        if (Convert.ToBoolean(RequieNit) == true)
                        {
                            //Que tipo de tercero, lo normal es que se asocia a la cuenta

                            if (TabCuenConta["SiterObliga"].ToString() == "1")
                            {
                                TipDocCaja = TabCuenConta["TipoDocCuen"].ToString();
                                NumDocCaja = TabCuenConta["NumDocCuen"].ToString();
                                SucCaja = TabCuenConta["SucurCuen"].ToString();
                                NitDosCaja = TabCuenConta["NitDosCuen"].ToString();
                            }
                            else
                            {
                                if (TabCuenConta["SiterObliga"].ToString() == "2")
                                {
                                    //Por tipo de pago puede cambiarse
                                    //ListaBancos

                                    Utils.SqlDatos = "SELECT [Datos de los bancos].CodiBanco, [Datos de los bancos].NomBanco, " +
                                    " [Datos de los bancos].TipNit, [Datos de los bancos].NitBanco, " +
                                    " [Datos de los bancos].SucurNit, [Datos de los bancos].TipoBanco " +
                                    " FROM [GEOGRAXPSQL].[dbo].[Datos de los bancos] WHERE CodiBanco = '" + CboLIstaBancos.SelectedValue.ToString() + "' ORDER BY [Datos de los bancos].NomBanco; ";

                                    using (SqlConnection connection2 = new SqlConnection(Conexion.conexionSQL))
                                    {

                                        SqlCommand command2 = new SqlCommand(Utils.SqlDatos, connection2);
                                        command2.Connection.Open();
                                        SqlDataReader TabBanco = command2.ExecuteReader();

                                        if (TabBanco.HasRows)
                                        {
                                            TabBanco.Read();

                                            TipDocCaja = TabBanco["TipNit"].ToString();
                                            NumDocCaja = TabBanco["NitBanco"].ToString();
                                            SucCaja = TabBanco["SucurNit"].ToString();

                                        }

                                    }
                                }
                                else
                                {
                                    Utils.Informa = "Lo siento pero el número del documento de" + "\r";
                                    Utils.Informa += "identificación del tercero no se encuentra" + "\r";
                                    Utils.Informa += "parametrizado en la cuenta contable " + "\r";
                                    Utils.Informa += "Por lo tanto no se puede continuar." + "\r";
                                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }//Final de TabCuenConta![SiterObliga] = "2"
                            }//Final de TabCuenConta![SiterObliga] = "1"


                            //Verificamos si el nit existe
                            SqlTerceros = "SELECT TipoDocu, IdenProve, SucurProv, RazonSol, DigVeri ";
                            SqlTerceros = SqlTerceros + "FROM [GEOGRAXPSQL].[dbo].[Datos proveedores] ";
                            SqlTerceros = SqlTerceros + "WHERE TipoDocu='" + TipDocCaja + "' AND IdenProve='" + NumDocCaja + "'  AND SucurProv='" + SucCaja + "' ";
                            SqlTerceros = SqlTerceros + "ORDER BY TipoDocu";


                            using (SqlConnection connection2 = new SqlConnection(Conexion.conexionSQL))
                            {
                                SqlCommand command2 = new SqlCommand(SqlTerceros, connection2);
                                command2.Connection.Open();
                                SqlDataReader TabTerceros = command2.ExecuteReader();

                                if (TabTerceros.HasRows == false)
                                {
                                    Utils.Informa = "Lo siento pero el documento de identificación del" + "\r";
                                    Utils.Informa += "tercero de la cuenta débito, no se encuentra registrado" + "\r";
                                    Utils.Informa += "en la base de datos, por lo tanto no se puede expedir" + "\r";
                                    Utils.Informa += "el recibo de caja para el pago de la factura." + "\r";
                                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                else
                                {
                                    TabTerceros.Read();

                                    //************************ Como softland lleva el digito de verificación incluido en el nit, así se debe grabar en el detalle *****

                                    if (string.IsNullOrWhiteSpace(TabTerceros["DigVeri"].ToString()) || TabTerceros["DigVeri"].ToString() == "")
                                    {
                                        //'El documento sigue siendo el mismo
                                    }
                                    else
                                    {
                                        NumDocCaja = NumDocCaja + "-" + TabTerceros["DigVeri"].ToString();
                                    }
                                }
                            }//TabTerceros

                        }
                        else
                        {
                            TipDocCaja = TabCuenConta["TipoDocCuen"].ToString();
                            NumDocCaja = TabCuenConta["NumDocCuen"].ToString();
                            SucCaja = TabCuenConta["SucurCuen"].ToString();
                            NitDosCaja = TabCuenConta["NitDosCuen"].ToString();
                        }//Final de TabCuenConta![RequieNit] = True
                    }
                }

                //Revisamos si la entidad tiene algún sistema contable

                CodEnti = LblCodEntiFac.Text;

                FunConta = TieneContabilidad(CodEnti);

                switch (FunConta)
                {
                    case "0": //No se tiene un sistema de contabilidad vinculado a SIIGHOS PLUS
                        InformaST = "";
                        break;
                    case "1"://NO esta abierta la instancia

                        CodDocuMov = TxtCodDoc.Text; //Codifo del documento del movimiento

                        PreDoc = TxtPreDoc.Text;

                        //Revisamos si el periodo contable existe de acuerdo a la fecha del documento

                        FunValiPer = ValidarPerioConta(AnVigen, MesPerio);

                        switch (FunValiPer)
                        {
                            case 0: //Error en la funcion
                                return;
                                break;
                            case 1: //No existe el periodo

                                Utils.Informa = "Lo siento pero a la factura No." + FR + "\r";
                                Utils.Informa += "no se le puede registrar el pago y realizar" + "\r";
                                Utils.Informa += "la CONTABILIDAD en SOFTLAND, porque los" + "\r";
                                Utils.Informa += "datos del periodo contable no estan registrados " + "\r";
                                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;

                                break;
                            case 3: //Periodo Cerrado

                                Utils.Informa = "Lo siento pero a la factura No." + FR + "\r";
                                Utils.Informa += "no se le puede registrar el pago y realizar" + "\r";
                                Utils.Informa += "la CONTABILIDAD en SOFTLAND, porque el" + "\r";
                                Utils.Informa += "periodo contable se encuentra cerrado. " + "\r";
                                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                                break;
                            default:
                                break;
                        }

                        //Validamos en softland el tercero

                        FunTerceST = ValidarTerceroSofTland(NDDigVer, SucTerCaj);

                        switch (FunTerceST)
                        {
                            case "-1":
                                return;
                                break;
                            case "-3":
                                Utils.Informa = "Lo siento pero a la factura No." + FR + "\r";
                                Utils.Informa += "no se le puede registrar el pago y realizar" + "\r";
                                Utils.Informa += "la CONTABILIDAD en SOFTLAND, porque " + "\r";
                                Utils.Informa += "los datos del tercero no estan registrados en SOFTLAND. " + "\r";
                                Utils.Informa += "Nit uno: " + NDDigVer + " Sucursal: " + SucTerCaj + " Nit Dos: " + FunProveDos + "\r";
                                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                                break;

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
                                            Utils.Informa = "Lo siento pero a la factura No." + FR + "\r";
                                            Utils.Informa += "no se le puede registrar el pago y realizar" + "\r";
                                            Utils.Informa += "la CONTABILIDAD en SOFTLAND, porque " + "\r";
                                            Utils.Informa += "la cuenta contable débito no esta registrada en SOFTLAND." + "\r";
                                            MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            return;
                                        case "-4":
                                            Utils.Informa = "Lo siento pero a la factura No." + FR + "\r";
                                            Utils.Informa += "no se le puede registrar el pago y realizar" + "\r";
                                            Utils.Informa += "la CONTABILIDAD en SOFTLAND, porque " + "\r";
                                            Utils.Informa += "el centro de costo del débito no esta registrado en SOFTLAND." + "\r";
                                            MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            return;
                                        default:


                                            //Validamos las cuentas contables

                                            CCostoCre = "000";
                                            FunValCtaD = ValidarCtaContaST(CCon, CCostoCre);

                                            switch (FunValCtaD)
                                            {
                                                case "-1": //Error en la funcion
                                                    return;
                                                case "-3": //No se encontró el Tercero en la tabla de proveedores
                                                    Utils.Informa = "Lo siento pero a la factura No." + FR + "\r";
                                                    Utils.Informa += "no se le puede registrar el pago y realizar" + "\r";
                                                    Utils.Informa += "la CONTABILIDAD en SOFTLAND, porque" + "\r";
                                                    Utils.Informa += "la cuenta contable crédito " + CCon + "  no esta registrada en SOFTLAND. " + "\r";
                                                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                    break;
                                                case "-4":
                                                    Utils.Informa = "Lo siento pero a la factura No." + FR + "\r";
                                                    Utils.Informa += "no se le puede registrar el pago y realizar" + "\r";
                                                    Utils.Informa += "la CONTABILIDAD en SOFTLAND, porque" + "\r";
                                                    Utils.Informa += "el centro de costo del crédito " + CCostoCre + " no esta registrado en SOFTLAND." + "\r";
                                                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                    break;

                                                default:

                                                    //A partir del 26 de febrero de 2019 se cargan CUENTAS CREDITOS (INGRESOS)

                                                    SqlConsumos = "SELECT [Datos registros de consumos].CoCentroCon, Sum((([Cantidad]*[ValorUnitario])-[Copagos])) AS TolNeto, ";
                                                    SqlConsumos += "SUM([Datos registros de consumos].Copagos) AS SumaDeCopagos, GEOGRAXPSQL.dbo.[Datos centros de costo].NomCentro, ";
                                                    SqlConsumos += "GEOGRAXPSQL.dbo.[Datos centros de costo].CuenContable ";
                                                    SqlConsumos += "FROM [ACDATOXPSQL].[dbo].[Datos de las facturas realizadas] INNER JOIN [ACDATOXPSQL].[dbo].[Datos registros de consumos] ON ";
                                                    SqlConsumos += "[Datos de las facturas realizadas].NumCuenFac = [Datos registros de consumos].CuenConsu INNER JOIN ";
                                                    SqlConsumos += "GEOGRAXPSQL.dbo.[Datos centros de costo] ON [Datos registros de consumos].CoCentroCon = ";
                                                    SqlConsumos += "GEOGRAXPSQL.dbo.[Datos centros de costo].CodiCentro ";
                                                    SqlConsumos += "WHERE ([Datos registros de consumos].PagaHoja = 'True') AND ([Datos registros de consumos].Cantidad <> 0) ";
                                                    SqlConsumos += "AND ([Datos registros de consumos].ValorUnitario <> 0) AND ";
                                                    SqlConsumos += "([Datos de las facturas realizadas].NumFactura = N'" + FR + "') ";
                                                    SqlConsumos += "GROUP BY [Datos registros de consumos].CoCentroCon, [Datos de las facturas realizadas].CuentaCobro, ";
                                                    SqlConsumos += "GEOGRAXPSQL.dbo.[Datos centros de costo].NomCentro, GEOGRAXPSQL.dbo.[Datos centros de costo].CuenContable";


                                                    using (SqlConnection connection2 = new SqlConnection(Conexion.conexionSQL))
                                                    {
                                                        SqlCommand command2 = new SqlCommand(SqlConsumos, connection2);
                                                        command2.Connection.Open();
                                                        SqlDataReader TabConsumos = command2.ExecuteReader();


                                                        if (TabConsumos.HasRows == false)
                                                        {
                                                            //No tiene registros la factura

                                                            Utils.Informa = "Lo siento pero al parecer la factura No. " + FR + "\r";
                                                            Utils.Informa += "no tiene registrado el detalle de servicios facturados," + "\r";
                                                            Utils.Informa += "por lo tanto no se le puede realizar el pago." + "\r";
                                                            MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                                        }
                                                        else
                                                        {
                                                            TolNetFac = 0;
                                                            TolCopFac = 0;


                                                            while (TabConsumos.Read())
                                                            {

                                                                CuentaCredito = TabConsumos["CuenContable"].ToString();
                                                                CostoCredi = TabConsumos["CoCentroCon"].ToString();
                                                                TolNetFac = TolNetFac + Convert.ToDouble(TabConsumos["TolNeto"].ToString());
                                                                TolCopFac = TolCopFac + Convert.ToDouble(TabConsumos["SumaDeCopagos"].ToString());

                                                                //Validamos las cuentas contables

                                                                FunValCtaD = ValidarCtaContaST(CuentaCredito, CostoCredi);

                                                                switch (FunValCtaD)
                                                                {
                                                                    case "-1"://Error en la funcion
                                                                        return;
                                                                    case "-3": //No se encontró el Tercero en la tabla de proveedores
                                                                        Utils.Informa = "Lo siento pero la factura de venta No." + FR + "\r";
                                                                        Utils.Informa += "no se puede PAGAR Y CONTABILIZAR en SOFTLAND," + "\r";
                                                                        Utils.Informa += "porque la cuenta contable crédito " + CuentaCredito + "\r";
                                                                        MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                                        return;
                                                                    case "-4": //No se encontró el Tercero en la tabla de proveedores
                                                                        Utils.Informa = "Lo siento pero la factura de venta No." + FR + "\r";
                                                                        Utils.Informa += "no se puede PAGAR Y CONTABILIZAR en SOFTLAND," + "\r";
                                                                        Utils.Informa += "porque el centro de costo del crédito " + CostoCredi + " no esta registrado en SOFTLAND." + "\r";
                                                                        MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                                        return;
                                                                    default:
                                                                        break;
                                                                }

                                                            }//While

                                                            if (TolNetFac < 0)
                                                            {
                                                                Utils.Informa = "Lo siento pero la factura de venta No." + FR + "\r";
                                                                Utils.Informa += "no se puede PAGAR Y CONTABILIZAR en SOFTLAND," + "\r";
                                                                Utils.Informa += "porque lo facturado es igual o menor a cero.";
                                                                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                                return;
                                                            }
                                                            else
                                                            {
                                                                InformaST = "Se hace el registro contable en SOFTLAND.";
                                                                SofTien = 1;
                                                            }

                                                        }//Fin  if(TabConsumos.HasRows == false)
                                                    }//Fin Using

                                                    break;
                                            }//Fin Select
                                            break;
                                    }//FinSelect





                                }//If FunProveDOs == FunTercerST
                                else
                                {
                                    Utils.Informa = "Lo siento pero la factura de venta No." + FR + "\r";
                                    Utils.Informa += "no se le puede registrar el pago y realizar" + "\r";
                                    Utils.Informa += "la CONTABILIDAD en SOFTLAND, porque";
                                    Utils.Informa += "los datos del Nit no concuerdan:.";
                                    Utils.Informa += "En SOFTLAND: " + FunTerceST + " Y en SIIGHOS PLUS" + FunProveDos;
                                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                                break;
                        }//Ens Select

                        break;

                    case "-1": //Error en la funcion
                        return;
                    case "-2":
                        return;
                    default:
                        //Tiene sistema de contabiliad aún no adaptado a  SIIGHOS PLUS
                        InformaST = "";
                        break;
                }



                SF = Convert.ToDouble(TxtSaldoFac.Text);
                SC = Convert.ToDouble(TxtCopago1.Text) - Convert.ToDouble(TxtCanceCopago1.Text);
                HisPa = TxtHistoNumPaciente1.Text;

                UsReci = lblCodigoUser.Text;

                //Haga la pregunta

                switch (Convert.ToInt32(CboCancelaPor.SelectedIndex))
                {
                    case 1: //Valor Neto
                        Z = "1";


                        if (PaReg == SF)
                        {
                            Utils.Informa = "¿Usted desea cancelar el valor neto" + "\r";
                            Utils.Informa += "de la factura No. " + FR + "\r";
                            Utils.Informa += "La suma de " + PaReg + "\r";
                            Utils.Informa += "Forma de pago  " + ForPa + "?" + "\r";
                            Utils.Informa += InformaST;
                            DetaPago = "Pago total a la factura No.: " + FR;
                            Por01 = 100;
                        }
                        else
                        {
                            Utils.Informa = "¿Usted desea abonar al valor neto" + "\r";
                            Utils.Informa += "de la factura No. " + FR + "\r";
                            Utils.Informa += "La suma de " + PaReg + "\r";
                            Utils.Informa += "Forma de pago  " + ForPa + "?" + "\r";
                            Utils.Informa += InformaST;
                            DetaPago = "Abono a la factura No.: " + FR;
                            Por01 = (PaReg * 100) / SF;
                        }

                        QPaga = "Pago Total";

                        break;
                    case 2: //Valor copago:

                        Z = "2";

                        if (SC == PaReg)
                        {
                            Utils.Informa = "Usted desea cancelar al valor del copago" + "\r";
                            Utils.Informa += "de la factura No. " + FR + "\r";
                            Utils.Informa += "La suma de " + PaReg + "\r";
                            Utils.Informa += "Forma de pago  " + ForPa + "?" + "\r";
                            DetaPago = "Pago total al copago de la factura No." + FR;
                            Por01 = 100;
                        }
                        else
                        {
                            Utils.Informa = "¿Usted desea abonar al valor del copago" + "\r";
                            Utils.Informa += "de la factura No. " + FR + "\r";
                            Utils.Informa += "La suma de " + PaReg + "\r";
                            Utils.Informa += "Forma de pago  " + ForPa + "?" + "\r";
                            DetaPago = "Abono al copago de la factura No.: " + FR;
                            Por01 = (PaReg * 100) / SF;
                        }
                        QPaga = "Copago";
                        break;
                    default:
                        break;
                }


                var res = MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                if (res == DialogResult.Yes)
                {
                    //Volvemos a buscar el númro de la factura



                    SqlFacturas = "SELECT * FROM [ACDATOXPSQL].[dbo].[Datos de las facturas realizadas] ";
                    SqlFacturas = SqlFacturas + "WHERE NumFactura= '" + FR + "' ";
                    SqlFacturas = SqlFacturas + "ORDER BY NumFactura";

                    using (SqlConnection connection2 = new SqlConnection(Conexion.conexionSQL))
                    {
                        SqlCommand command2 = new SqlCommand(SqlFacturas, connection2);
                        command2.Connection.Open();
                        SqlDataReader TabFacturas = command2.ExecuteReader();

                        if (TabFacturas.HasRows == false)
                        {
                            //No se encontró el número de factura
                            Utils.Informa = "Lo siento pero el número de factura no fue posible encontrarla en este sistema" + "\r";
                            MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;

                        }
                        else
                        {
                            //Revisemos que no vaya a acancelar una factura anulada
                            TabFacturas.Read();

                            if (Convert.ToBoolean(TabFacturas["AnuladaFac"]) == true)
                            {
                                Utils.Informa = "Lo siento pero la factura " + FR + "\r";
                                Utils.Informa += "se encuentra anulada." + "\r";
                                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            else
                            {
                                ValNet = (Convert.ToDouble(TabFacturas["ValorFac"]) + Convert.ToDouble(TabFacturas["NotaDebito"]) + Convert.ToDouble(TabFacturas["Copago"]));
                                ValFacDesc = (Convert.ToDouble(TabFacturas["Copago"]) + Convert.ToDouble(TabFacturas["NotaCredito"]) + Convert.ToDouble(TabFacturas["DesVarios"]) + Convert.ToDouble(TabFacturas["Retencion"]) + Convert.ToDouble(TabFacturas["DesTramite"]) + Convert.ToDouble(TabFacturas["OtrosDescuentos"]));
                                PagReal = Convert.ToDouble(TabFacturas["PagoFac"]) + Convert.ToDouble(TabFacturas["CanceCopago"]) + Convert.ToDouble(TabFacturas["PagoConDepos"]);

                                CarT = TabFacturas["Cartercero"].ToString();
                                //Verificamos el saldo de la factura

                                SF = (ValNet - (ValFacDesc + PagReal));


                                Cuencobro = TabFacturas["CuentaCobro"].ToString();
                                CuenConsu = TabFacturas["NumCuenFac"].ToString();


                                //Buscamos el centro de costo de mayor peso en el ingreso (***** Nace el 26 de Septiembre de 2014 ****)

                                SqlConsumos = "SELECT [Datos registros de consumos].CoCentroCon,";
                                SqlConsumos = SqlConsumos + "SUM([Datos registros de consumos].Cantidad * [Datos registros de consumos].ValorUnitario) As TolDetalle ";
                                SqlConsumos = SqlConsumos + "FROM [ACDATOXPSQL].[dbo].[Datos registros de consumos] ";
                                SqlConsumos = SqlConsumos + "WHERE ([Datos registros de consumos].PagaHoja = 'True') ";
                                SqlConsumos = SqlConsumos + "GROUP BY [Datos registros de consumos].CoCentroCon, [Datos registros de consumos].CuenConsu ";
                                SqlConsumos = SqlConsumos + "HAVING ([Datos registros de consumos].CuenConsu = N'" + CuenConsu + "') AND (SUM([Datos registros de consumos].Cantidad) > 0)";
                                SqlConsumos = SqlConsumos + "ORDER BY TolDetalle desc";




                                using (SqlConnection connection3 = new SqlConnection(Conexion.conexionSQL))
                                {
                                    SqlCommand command3 = new SqlCommand(SqlConsumos, connection3);
                                    command3.Connection.Open();
                                    SqlDataReader TabConsumos = command3.ExecuteReader();

                                    if (TabConsumos.HasRows == false)
                                    {
                                        CCostoCre = "000";
                                    }
                                    else
                                    {
                                        TabConsumos.Read();
                                        CCostoCre = TabConsumos["CoCentroCon"].ToString();
                                    }
                                }

                                if (Z == "1")
                                {
                                    if (Cuencobro != "000000" || Convert.ToBoolean(TabFacturas["SiCobro"]) == true)
                                    {
                                        Utils.Informa = "Lo siento pero la factura " + FR + "\r";
                                        Utils.Informa += "se encuentra en relacion de cobro.!" + "\r";
                                        Utils.Informa += "Por favor registrela por la opción " + "\r";
                                        Utils.Informa += "de pagos a cuentas de cobro. " + "\r";
                                        MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        evaluapago = false;
                                    }
                                    else
                                    {
                                        if (RegUsu == "4")
                                        {
                                            if (SF == Convert.ToDouble(TxtValorPagos.Text))
                                            {
                                                evaluapago = true;
                                            }
                                            else
                                            {
                                                Utils.Informa = "Lo siento pero el valor a pagar de la factura" + "\r";
                                                Utils.Informa += "no es igual al valor del saldo.!" + "\r";
                                                Utils.Informa += "Por favor verifique la operacion, o genere " + "\r";
                                                Utils.Informa += "documento cruce, pagaré o efectivo.  " + "\r";
                                                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                evaluapago = false;
                                            }
                                        }
                                        else
                                        {
                                            evaluapago = true;
                                        }
                                    }
                                }
                                else
                                {
                                    //Verificamos saldo del copago
                                    SC = Convert.ToDouble(TabFacturas["Copago"]) - Convert.ToDouble(TabFacturas["CanceCopago"]);

                                    if (SC == PaReg)
                                    {
                                        evaluapago = true;
                                    }
                                    else
                                    {
                                        Utils.Informa = "Lo siento pero el valor a pagar no es" + "\r";
                                        Utils.Informa += "igual al valor del copago de la factura.!" + "\r";
                                        Utils.Informa += "Por favor verifique la operacion, o genere  " + "\r";
                                        Utils.Informa += "documento cruce, pagaré o efectivo.  " + "\r";
                                        MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        evaluapago = false;
                                    }

                                }


                                //Procedemos a buscar el consecutivo de recibos de caja

                                if (evaluapago == true)
                                {


                                    FunReciNum = ConseReciCaja(1, UsReci, CodCa);


                                    switch (FunReciNum)
                                    {
                                        case "-3": //Consecutivo fuera de rango

                                            Utils.Informa = "Lo siento pero el  número  consecutivo de" + "\r";
                                            Utils.Informa += "recibos de caja llegó al limite aceptado," + "\r";
                                            Utils.Informa += "favor comunicarse con el area de sistemas  " + "\r";
                                            MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            evaluapago = false;
                                            break;
                                        case "-2": //Fecha menor a la última generada

                                            Utils.Informa = "Lo siento pero la fecha del sistema es menor" + "\r";
                                            Utils.Informa += "a la fecha del último recibo generado. " + "\r";
                                            Utils.Informa += "Favor comunicarse con el area de sistemas " + "\r";
                                            MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            evaluapago = false;
                                            break;
                                        case "-1": //Error en la función

                                            evaluapago = false;

                                            break;
                                        case "0": //No se encontró el registro de contadores

                                            Utils.Informa = "Lo siento pero no  fue  posible  encontrar" + "\r";
                                            Utils.Informa += "el registro único de la tabla contadores. " + "\r";
                                            Utils.Informa += "Favor comunicarse con el area de sistemas " + "\r";
                                            MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            evaluapago = false;
                                            break;
                                        default:

                                            //Puede seguir el proceso

                                            break;
                                    }

                                    //Proceda a grabar los datos del recibo de caja

                                    if (evaluapago)
                                    {

                                        SqlReciCaja = "SELECT * FROM [BDCAJASQL].[dbo].[Datos recibos de caja] ";
                                        SqlReciCaja = SqlReciCaja + "WHERE ReciboCaja = '" + FunReciNum + "' ";
                                        SqlReciCaja = SqlReciCaja + "ORDER BY ReciboCaja";


                                        int proce = 0;

                                        using (SqlConnection connection3 = new SqlConnection(Conexion.conexionSQL))
                                        {
                                            SqlCommand command3 = new SqlCommand(SqlReciCaja, connection3);
                                            command3.Connection.Open();
                                            SqlDataReader TabReciCaja = command3.ExecuteReader();


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
                                            "CardiNitCC," +
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
                                            "'" + T + "'," +
                                            "'" + ND + "'," +
                                            "'" + SucTerCaj + "'," +
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
                                            "'" + false + "'," +
                                            "'" + TxtObservaCaja.Text + "'" +
                                            ")";

                                            bool estaRegis = Conexion.SqlInsert(Utils.SqlDatos);

                                            //Siga a grabar el detalle


                                            Utils.SqlDatos = "INSERT [BDCAJASQL].[dbo].[Datos detalles recibos de caja] (ReciboNum,CuentaContable,DetaPagoCaja,CentroCosto,CantidadCaja,PorcenPago,ValorUnitaCaja,NatuMovi,DebiCaja,TipDocConta,NumDocConta,SucurConta,NitDosConta) ";
                                            Utils.SqlDatos += "VALUES (@ReciboNum,@CuentaContable,@DetaPagoCaja,@CentroCosto,@CantidadCaja,@PorcenPago,@ValorUnitaCaja,@NatuMovi,@DebiCaja,@TipDocConta,@NumDocConta,@SucurConta,@NitDosConta)";



                                            List<SqlParameter> parameters = new List<SqlParameter>();

                                            //Grabe el dèbito

                                            parameters = new List<SqlParameter>
                                            {
                                                new SqlParameter("@ReciboNum", SqlDbType.VarChar){ Value = FunReciNum},
                                                new SqlParameter("@CuentaContable", SqlDbType.VarChar){ Value = Cuencaja},
                                                new SqlParameter("@DetaPagoCaja", SqlDbType.VarChar){ Value = DetaPago},
                                                new SqlParameter("@CentroCosto", SqlDbType.VarChar){ Value = CenCaja},
                                                new SqlParameter("@CantidadCaja", SqlDbType.VarChar){ Value = CanReg},
                                                new SqlParameter("@PorcenPago", SqlDbType.VarChar){ Value = Por01},
                                                new SqlParameter("@ValorUnitaCaja", SqlDbType.VarChar){ Value = 0},
                                                new SqlParameter("@NatuMovi", SqlDbType.VarChar){ Value = "D"},
                                                new SqlParameter("@DebiCaja", SqlDbType.VarChar){ Value = PaReg},
                                                new SqlParameter("@TipDocConta", SqlDbType.VarChar){ Value = TipDocCaja},
                                                new SqlParameter("@NumDocConta", SqlDbType.VarChar){ Value = NumDocCaja},
                                                new SqlParameter("@SucurConta", SqlDbType.VarChar){ Value = SucCaja},
                                                new SqlParameter("@NitDosConta", SqlDbType.VarChar){ Value = NitDosCaja}, //Se empieza a grabar a partir del 13 de julio de 2016
                                            };

                                            estaRegis = Conexion.SqlInsert(Utils.SqlDatos, parameters);


                                            //Grabe el credito

                                            Utils.SqlDatos = "INSERT [BDCAJASQL].[dbo].[Datos detalles recibos de caja] (ReciboNum,CuentaContable,DetaPagoCaja,CentroCosto,CantidadCaja,PorcenPago,ValorUnitaCaja,NatuMovi,DebiCaja,TipDocConta,NumDocConta,SucurConta,NitDosConta) ";
                                            Utils.SqlDatos += "VALUES (@ReciboNum,@CuentaContable,@DetaPagoCaja,@CentroCosto,@CantidadCaja,@PorcenPago,@ValorUnitaCaja,@NatuMovi,@DebiCaja,@TipDocConta,@NumDocConta,@SucurConta,@NitDosConta)";

                                            parameters = new List<SqlParameter>
                                            {
                                                new SqlParameter("@ReciboNum", SqlDbType.VarChar){ Value = FunReciNum},
                                                new SqlParameter("@CuentaContable", SqlDbType.VarChar){ Value = CCon},
                                                new SqlParameter("@DetaPagoCaja", SqlDbType.VarChar){ Value = DetaPago},
                                                new SqlParameter("@CentroCosto", SqlDbType.VarChar){ Value = CCostoCre},
                                                new SqlParameter("@CantidadCaja", SqlDbType.VarChar){ Value = CanReg},
                                                new SqlParameter("@PorcenPago", SqlDbType.VarChar){ Value = Por01},
                                                new SqlParameter("@ValorUnitaCaja", SqlDbType.VarChar){ Value = PaReg},
                                                new SqlParameter("@CrediCaja", SqlDbType.VarChar){ Value = PaReg},
                                                new SqlParameter("@NatuMovi", SqlDbType.VarChar){ Value = "C"},
                                                new SqlParameter("@DebiCaja", SqlDbType.VarChar){ Value = 0},
                                                new SqlParameter("@TipDocConta", SqlDbType.VarChar){ Value = T},
                                                new SqlParameter("@NumDocConta", SqlDbType.VarChar){ Value = NDDigVer},
                                                new SqlParameter("@SucurConta", SqlDbType.VarChar){ Value = SucTerCaj},
                                                new SqlParameter("@NitDosConta", SqlDbType.VarChar){ Value = FunProveDos}, //Se empieza a grabar a partir del 13 de julio de 2016
                                            };

                                            estaRegis = Conexion.SqlInsert(Utils.SqlDatos, parameters);

                                            //Se vuelve a debitar la cuenta del registro de copagos


                                            Utils.SqlDatos = "INSERT [BDCAJASQL].[dbo].[Datos detalles recibos de caja] (ReciboNum,CuentaContable,DetaPagoCaja,CentroCosto,CantidadCaja,PorcenPago,ValorUnitaCaja,NatuMovi,DebiCaja,TipDocConta,NumDocConta,SucurConta,NitDosConta) ";
                                            Utils.SqlDatos += "VALUES (@ReciboNum,@CuentaContable,@DetaPagoCaja,@CentroCosto,@CantidadCaja,@PorcenPago,@ValorUnitaCaja,@NatuMovi,@DebiCaja,@TipDocConta,@NumDocConta,@SucurConta,@NitDosConta)";

                                            parameters = new List<SqlParameter>
                                            {
                                                new SqlParameter("@ReciboNum", SqlDbType.VarChar){ Value = FunReciNum},
                                                new SqlParameter("@CuentaContable", SqlDbType.VarChar){ Value = CCon},
                                                new SqlParameter("@DetaPagoCaja", SqlDbType.VarChar){ Value = DetaPago},
                                                new SqlParameter("@CentroCosto", SqlDbType.VarChar){ Value = CCostoCre},
                                                new SqlParameter("@CantidadCaja", SqlDbType.VarChar){ Value = CanReg},
                                                new SqlParameter("@PorcenPago", SqlDbType.VarChar){ Value = Por01},
                                                new SqlParameter("@ValorUnitaCaja", SqlDbType.VarChar){ Value = 0},
                                                new SqlParameter("@CrediCaja", SqlDbType.VarChar){ Value = PaReg},
                                                new SqlParameter("@NatuMovi", SqlDbType.VarChar){ Value = "D"},
                                                new SqlParameter("@DebiCaja", SqlDbType.VarChar){ Value = PaReg},
                                                new SqlParameter("@TipDocConta", SqlDbType.VarChar){ Value = T},
                                                new SqlParameter("@NumDocConta", SqlDbType.VarChar){ Value = NDDigVer},
                                                new SqlParameter("@SucurConta", SqlDbType.VarChar){ Value = SucTerCaj},
                                                new SqlParameter("@NitDosConta", SqlDbType.VarChar){ Value = FunProveDos}, //Se empieza a grabar a partir del 13 de julio de 2016
                                            };

                                            estaRegis = Conexion.SqlInsert(Utils.SqlDatos, parameters);


                                            //A PARTIR DEL 26 DE FEBRERO DE 2019 SE GRABA EL CREDITO

                                            SqlConsumos = "SELECT [Datos registros de consumos].CoCentroCon, Sum((([Cantidad]*[ValorUnitario])-[Copagos])) AS TolNeto, ";
                                            SqlConsumos += "SUM([Datos registros de consumos].Copagos) AS SumaDeCopagos, GEOGRAXPSQL.dbo.[Datos centros de costo].NomCentro, ";
                                            SqlConsumos += "GEOGRAXPSQL.dbo.[Datos centros de costo].CuenContable ";
                                            SqlConsumos += "FROM [ACDATOXPSQL].[dbo].[Datos de las facturas realizadas] INNER JOIN [ACDATOXPSQL].[dbo].[Datos registros de consumos] ON ";
                                            SqlConsumos += "[Datos de las facturas realizadas].NumCuenFac = [Datos registros de consumos].CuenConsu INNER JOIN ";
                                            SqlConsumos += "GEOGRAXPSQL.dbo.[Datos centros de costo] ON [Datos registros de consumos].CoCentroCon = ";
                                            SqlConsumos += "GEOGRAXPSQL.dbo.[Datos centros de costo].CodiCentro ";
                                            SqlConsumos += "WHERE ([Datos registros de consumos].PagaHoja = 'True') AND ([Datos registros de consumos].Cantidad <> 0) ";
                                            SqlConsumos += "AND ([Datos registros de consumos].ValorUnitario <> 0) AND ";
                                            SqlConsumos += "([Datos de las facturas realizadas].NumFactura = N'" + FR + "') ";
                                            SqlConsumos += "GROUP BY [Datos registros de consumos].CoCentroCon, [Datos de las facturas realizadas].CuentaCobro, ";
                                            SqlConsumos += "GEOGRAXPSQL.dbo.[Datos centros de costo].NomCentro, GEOGRAXPSQL.dbo.[Datos centros de costo].CuenContable";


                                            DataTable dt = Conexion.SQLDataTable(SqlConsumos);

                                            if (dt.Rows.Count <= 0)
                                            {
                                                //NO tiene registros la factura

                                                Utils.Informa = "Lo siento pero al parecer la factura No. " + FR + "\r";
                                                Utils.Informa += "no tiene registrado el detalle de servicios facturados," + "\r";
                                                Utils.Informa += "por lo tanto no se le puede realizar el pago." + "\r";
                                                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                return;
                                            }
                                            else
                                            {
                                                TolNetFac = 0;
                                                TolCopFac = 0;
                                                PagoCenCosto = 0;
                                                foreach (DataRow TabConsumos in dt.Rows)
                                                {


                                                    CuentaCredito = TabConsumos["CuenContable"].ToString();
                                                    CostoCredi = TabConsumos["CoCentroCon"].ToString();
                                                    TolNetFac = TolNetFac + Convert.ToDouble(TabConsumos["TolNeto"]);
                                                    TolCopFac = TolCopFac + Convert.ToDouble(TabConsumos["SumaDeCopagos"]);


                                                    switch (Convert.ToInt32(CboCancelaPor.SelectedIndex))
                                                    {
                                                        case 1: //Valor Neto

                                                            PagoCenCosto = Convert.ToDouble(TabConsumos["TolNeto"]) * (Por01 / 100);
                                                            PaReg = TolNetFac * (Por01 / 100); //Para que afecte el pago de factura bien

                                                            break;
                                                        case 2: //Valor copago

                                                            PagoCenCosto = Convert.ToDouble(TabConsumos["SumaDeCopagos"]) * (Por01 / 100);
                                                            PaReg = TolCopFac * (Por01 / 100); //Para que afecte el pago de factura bien

                                                            break;
                                                        default:
                                                            break;
                                                    }

                                                    if (PaReg > 0)
                                                    {

                                                        Utils.SqlDatos = "INSERT INTO [BDCAJASQL].[dbo].[Datos detalles recibos de caja] " +
                                                        "(" +
                                                        "ReciboNum," +
                                                        "CuentaContable," +
                                                        "DetaPagoCaja," +
                                                        "CentroCosto," +
                                                        "CantidadCaja," +
                                                        "PorcenPago," +
                                                        "ValorUnitaCaja," +
                                                        "NatuMovi," +
                                                        "DebiCaja," +
                                                        "CrediCaja," +
                                                        "TipDocConta," +
                                                        "NumDocConta," +
                                                        "SucurConta," +
                                                        "NitDosConta" +
                                                        ")" +
                                                        "VALUES" +
                                                        "(" +
                                                        "'" + FunReciNum + "'," +
                                                        "'" + CuentaCredito + "'," +
                                                        "'" + TabConsumos["NomCentro"].ToString() + "'," +
                                                        "'" + CostoCredi + "'," +
                                                        "'" + CanReg + "'," +
                                                        "'" + Por01 + "'," +
                                                        "'" + 0 + "'," +
                                                        "'" + "C" + "'," +
                                                        "'" + 0 + "'," +
                                                        "'" + PagoCenCosto + "'," +
                                                        "'" + T + "'," +
                                                        "'" + NDDigVer + "'," +
                                                        "'" + SucTerCaj + "'," +
                                                        "'" + FunProveDos + "'" +
                                                        ")";

                                                        estaRegis = Conexion.SqlInsert(Utils.SqlDatos);

                                                    }
                                                }
                                            }

                                            //Haga registro del pago a la factura


                                            if (PaReg > 0)
                                            {
                                                switch (Convert.ToInt32(CboCancelaPor.SelectedIndex))
                                                {
                                                    case 1: //Valor Neto

                                                        TM = "1"; //Paga al valor neto


                                                        Utils.SqlDatos = "UPDATE [ACDATOXPSQL].[dbo].[Datos de las facturas realizadas] SET " +
                                                        "PagoFac = '" + Convert.ToDouble(TabFacturas["PagoFac"]) + PaReg + "'," +
                                                        $"FecCanFac = {Conexion.ValidarFechaNula(DateTime.Now.ToString("yyyy-MM-dd"))}";

                                                        break;


                                                    case 2: //Valor copago

                                                        TM = "9"; //Paga al valor del copago

                                                        Utils.SqlDatos = "UPDATE [ACDATOXPSQL].[dbo].[Datos de las facturas realizadas]  SET " +
                                                        "CanceCopago = '" + Convert.ToDouble(TabFacturas["CanceCopago"]) + PaReg + "'," +
                                                        $"FecCanCopa = {Conexion.ValidarFechaNula(DateTime.Now.ToString("yyyy-MM-dd"))}";


                                                        break;
                                                    default:
                                                        break;
                                                }

                                                Utils.SqlDatos += $"FecModi = {Conexion.ValidarFechaNula(DateTime.Now.ToString("yyyy-MM-dd"))}";
                                                Utils.SqlDatos += "CodiModi = '" + UsReci + "'";
                                                Utils.SqlDatos += "WHERE NumFactura = '" + TabFacturas["NumFactura"].ToString() + "'";

                                                bool estaAct = Conexion.SQLUpdate(Utils.SqlDatos);


                                            }//Final de PaReg > 0

                                            //Proceda a realizar el movimiento de la factura

                                            Utils.SqlDatos = "INSERT INTO [ACDATOXPSQL].[dbo].[Datos movimientos facturas] " +
                                            "(" +
                                            "FactuNum," +
                                            "FecMovi," +
                                            "ValMovi," +
                                            "TipoMovi," +
                                            "SigNo," +
                                            "Documento," +
                                            "CheConsig," +
                                            "CoBanco," +
                                            "FecConsig," +
                                            "FecRegis," +
                                            "CodRegis" +
                                            ")" +
                                            "VALUES" +
                                            "(" +
                                            "'" + FR + "'," +
                                           $"{Conexion.ValidarFechaNula(DateTime.Now.ToString("yyyy-MM-dd"))}" +
                                            "'" + PaReg + "'," +
                                            "'" + TM + "'," +
                                            "'" + "-" + "'," +
                                            "'" + FunReciNum + "'," +
                                            "'" + NumEnti + "'," +
                                            "'" + CboLIstaBancos.SelectedValue.ToString() + "'," +
                                            $"{Conexion.ValidarFechaNula(DateTime.Now.ToString("yyyy-MM-dd"))}" +
                                            $"{Conexion.ValidarFechaNula(DateTime.Now.ToString("yyyy-MM-dd"))}" +
                                            "'" + UsReci + "'" +
                                            ")";

                                            estaRegis = Conexion.SqlInsert(Utils.SqlDatos);


                                            Para01 = FunReciNum;

                                            //Proceda a imprimir el recibo

                                            Para05 = " [ACDATOXPSQL].[dbo].[Datos recibos de caja].[ReciboCaja] = " + Para01;

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


                                                            Utils.Informa = "El recibo de caja No. " + FunReciNum + "\r";
                                                            Utils.Informa += "se contabilizó satisfactoriamente en SOFTLAND." + "\r";
                                                            MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Information);



                                                            break;
                                                    }

                                                    break;
                                                default:


                                                    //"Informe recibos de cajas"


                                                    break;
                                            }

                                        }
                                        else
                                        {
                                            //El recibo de caja generado ya existe
                                            Utils.Informa = "Lo siento pero el número del recibo de caja" + "\r";
                                            Utils.Informa += "generado por el sistema ya existe, por tanto" + "\r";
                                            Utils.Informa += "no se puede volver a asignar, favor comunicarse" + "\r";
                                            Utils.Informa += "con el administrador del sistema." + "\r";
                                            MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }
                                    }
                                }
                            }

                        }//TabFacturas.HasRows
                    }//Using
                }//Pregunta
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
        private void BtnCopiaRecibos_Click(object sender, EventArgs e)
        {
            try
            {
                int FunCaja = 0, ConTiPro = 0;
                string ReciCaja = "", EnRutardatos = "", Para02 = "", SqlReciCaja = "", Para01 = "", Tipofactura = "", NomInfoCa = "";
                string infoCajaSql = "";
                Utils.Titulo01 = "Expedir copias de un recibo registrado";


                if (Convert.ToInt32(TxtReciCaja.Text) == 0)
                {
                    Utils.Informa = "Por favor digite el número" + "\r";
                    Utils.Informa += "del recibo de caja, al cual" + "\r";
                    Utils.Informa += "le desea sacar una copia." + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TxtReciCaja.Select();
                    return;
                }
                else
                {
                    ReciCaja = TxtReciCaja.Text;
                }


                if (string.IsNullOrWhiteSpace(TxtReciCaja.Text))
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
                Utils.Informa += "en el boton copia de recibos" + "\r";
                Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void BtnBuscarTercer_Click(object sender, EventArgs e)
        {

            FrmBuscarTerceros frmBuscarTerceros = new FrmBuscarTerceros();
            frmBuscarTerceros.ShowDialog();

            CboTipDocFac.SelectedValue = Utils.TipDocFac;
            TxtNitCC.Text = Utils.NitCC;

        }

        #endregion

        #region ComboBox
        private void CboCuentaContable_KeyPress(object sender, KeyPressEventArgs e)
        {
            CboCuentaContable.DroppedDown = false;
        }
        private void CboTipDocFac_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscarProve();
        }
        #endregion

        #region Texbox


        private void CargarFactura()
        {
            try
            {

                string FB, SqlDatos, SqlFacturas, SqlReciCaja, CarFac = "", SqlEmpTer = "";

                double ValFacTol = 0, ValDesFac = 0, ValPagosFac = 0;

                Utils.Titulo01 = "Control para mostrar datos";

                FB = TxtFacturaNo.Text;


                string sqlFactura = "SELECT [Datos de las facturas realizadas].NumCuenFac, [Datos cuentas de consumos].HistoNum,  " +
                " [Datos empresas y terceros].TipoDocu, [Datos empresas y terceros].NumDocu, " +
                "  [Datos empresas y terceros].NomAdmin, [Datos de las facturas realizadas].NumFactura, " +
                "  [Datos de las facturas realizadas].FechaFac, (RTrim([Apellido1] + ' ' + [Apellido2]) + ' ' + RTrim([Nombre1] + ' ' + [Nombre2])) AS NomPaci, [Datos de las facturas realizadas].ValorTotal,  " +
                "  [Datos de las facturas realizadas].ValorFac, [Datos de las facturas realizadas].Copago, [Datos de las facturas realizadas].PorcTercero, [Datos de las facturas realizadas].NotaCredito, " +
                "  [Datos de las facturas realizadas].PagoFac, [Datos de las facturas realizadas].CanceCopago, [Datos de las facturas realizadas].PagoConDepos, [Datos de las facturas realizadas].NotaDebito, " +
                "  [Datos de las facturas realizadas].DesVarios, [Datos de las facturas realizadas].Retencion, [Datos de las facturas realizadas].DesTramite, [Datos de las facturas realizadas].OtrosDescuentos,  " +
                "  [Datos de las facturas realizadas].AnuladaFac FROM[Datos empresas y terceros] INNER JOIN([Datos del Paciente] INNER JOIN ([Datos cuentas de consumos] INNER JOIN [Datos de las facturas realizadas] " +
                "  ON [Datos cuentas de consumos].CuenNum = [Datos de las facturas realizadas].NumCuenFac) ON[Datos del Paciente].HistorPaci = [Datos cuentas de consumos].HistoNum) " +
                "  ON [Datos empresas y terceros].CarAdmin = [Datos de las facturas realizadas].Cartercero " +
                " WHERE ((([Datos de las facturas realizadas].AnuladaFac) = 'False')) AND [Datos de las facturas realizadas].NumFactura = '" + FB + "' ; ";

                using (SqlConnection connection2 = new SqlConnection(Conexion.conexionSQL))
                {

                    SqlCommand command2 = new SqlCommand(sqlFactura, connection2);
                    command2.Connection.Open();
                    SqlDataReader TabCaja = command2.ExecuteReader();

                    if (TabCaja.HasRows)
                    {
                        TabCaja.Read();
                        TxtTipoDocEnti.Text = TabCaja["TipoDocu"].ToString();
                        TxtNumeroTerceroFac.Text = TabCaja["NumDocu"].ToString();
                        TxtNombreTercero2.Text = TabCaja["NomAdmin"].ToString();
                        DtFechaFac.Value = Convert.ToDateTime(TabCaja["FechaFac"]);
                        TxtHistoNumPaciente1.Text = TabCaja["HistoNum"].ToString();
                        TxtNomPaci.Text = TabCaja["NomPaci"].ToString();
                        TxtNúmeroCuentaFac.Text = TabCaja["NumCuenFac"].ToString();

                        TxtValorTotal.Text = TabCaja["ValorTotal"].ToString();
                        TxtValorFac1.Text = TabCaja["ValorFac"].ToString();

                        TxtCopago1.Text = TabCaja["Copago"].ToString();
                        TxtNotaDebito1.Text = TabCaja["NotaDebito"].ToString();
                        TxtGranTotalFac.Text = Convert.ToString(Convert.ToDouble(TabCaja["ValorFac"]) + Convert.ToDouble(TabCaja["Copago"]) + Convert.ToDouble(TabCaja["NotaDebito"]));


                        TxtPorcenTercero.Text = TabCaja["PorcTercero"].ToString();
                        TxtPorceCopago.Text = Convert.ToString(100 - Convert.ToDouble(TabCaja["PorcTercero"]));
                        TxtPorceDebito.Text = Convert.ToString(((Convert.ToDouble(TabCaja["NotaDebito"]) * 100) / Convert.ToDouble(TabCaja["ValorTotal"])));


                        TxtPorceGran.Text = Convert.ToString(Convert.ToDouble(TxtPorcenTercero.Text) + Convert.ToDouble(TxtPorceCopago.Text) + Convert.ToDouble(TxtPorceDebito.Text));
                        TxtPagoFac.Text = TabCaja["PagoFac"].ToString();

                        TxtCanceCopago1.Text = TabCaja["CanceCopago"].ToString();
                        TxtPagoConDepósito.Text = TabCaja["PagoConDepos"].ToString();

                        TxtTotalPagosReal.Text = Convert.ToString(Convert.ToDouble(TabCaja["PagoFac"]) + Convert.ToDouble(TabCaja["CanceCopago"]) + Convert.ToDouble(TabCaja["PagoConDepos"]));

                        Double Saldo = ((Convert.ToDouble(TxtGranTotalFac.Text) - Convert.ToDouble(TabCaja["Copago"])) - (Convert.ToDouble(TabCaja["NotaCredito"]) + Convert.ToDouble(TabCaja["DesVarios"]) + Convert.ToDouble(TabCaja["Retencion"]) + Convert.ToDouble(TabCaja["DesTramite"]) + Convert.ToDouble(TabCaja["OtrosDescuentos"]))) - (Convert.ToDouble(TxtTotalPagosReal.Text));

                        TxtSaldoFac.Text = Saldo.ToString();

                        TxtNotaCredito1.Text = TabCaja["NotaCredito"].ToString();
                        TxtDescuentoVarios.Text = TabCaja["DesVarios"].ToString();
                        TxtRetención.Text = TabCaja["Retencion"].ToString();
                        TxtDescuentoTramite.Text = TabCaja["DesTramite"].ToString();
                        TxtOtrosDescuentos.Text = TabCaja["OtrosDescuentos"].ToString();


                    }



                }

                //Procedemos a buscar la factura en la base de datos

                SqlFacturas = "SELECT * FROM [ACDATOXPSQL].[dbo].[Datos de las facturas realizadas] ";
                SqlFacturas = SqlFacturas + "WHERE NumFactura='" + FB + "' ";
                SqlFacturas = SqlFacturas + "ORDER BY NumFactura";


                using (SqlConnection connection = new SqlConnection(Conexion.conexionSQL))
                {

                    SqlCommand command = new SqlCommand(SqlFacturas, connection);
                    command.Connection.Open();
                    SqlDataReader TabFacturas = command.ExecuteReader();


                    if (TabFacturas.HasRows == false)
                    {
                        Utils.Informa = "Lo siento pero el número de factura";
                        Utils.Informa += "digitado no existe en este sistema";
                        Utils.Informa += "Por favor corrija el número o pulse";
                        Utils.Informa += "la tecla [ESC] para continuar.";
                        MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        //Revisamos si la factura está anulada o no

                        TabFacturas.Read();


                        if (Convert.ToBoolean(TabFacturas["AnuladaFac"]) == true)
                        {
                            Utils.Informa = "Lo siento pero el número de factura ";
                            Utils.Informa += "digitado se encuentra anulado en este sistema ";
                            Utils.Informa += "Por favor corrija el número o pulse ";
                            Utils.Informa += "la tecla [ESC] para continuar.";
                            MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            //Con base al cardinal de la factura, buscamos algunos datos de la empresa


                            CarFac = TabFacturas["Cartercero"].ToString();

                            //Implementada el 08/09/2021 en villavieja con el fin de evidenciar el recibo de caja
                            SqlReciCaja = "SELECT * FROM [BDCAJASQL].[dbo].[Datos recibos de caja] ";
                            SqlReciCaja = SqlReciCaja + "WHERE DocuCruce = '" + FB + "' ";

                            using (SqlConnection connection2 = new SqlConnection(Conexion.conexionSQL))
                            {

                                SqlCommand command2 = new SqlCommand(SqlReciCaja, connection2);
                                command2.Connection.Open();
                                SqlDataReader TabReciCaja = command2.ExecuteReader();

                                if (TabReciCaja.HasRows == false)
                                {
                                    TxtReciCaja.Clear();
                                }
                                else
                                {
                                    TabReciCaja.Read();

                                    TxtReciCaja.Text = TabReciCaja["ReciboCaja"].ToString();
                                }

                            }


                            SqlEmpTer = "SELECT * FROM [ACDATOXPSQL].[dbo].[Datos empresas y terceros] ";
                            SqlEmpTer = SqlEmpTer + "WHERE CarAdmin = '" + CarFac + "' ";
                            SqlEmpTer = SqlEmpTer + "ORDER BY CarAdmin";


                            using (SqlConnection connection3 = new SqlConnection(Conexion.conexionSQL))
                            {

                                SqlCommand command3 = new SqlCommand(SqlEmpTer, connection3);
                                command3.Connection.Open();
                                SqlDataReader TabEmpTer = command3.ExecuteReader();

                                if (TabEmpTer.HasRows == false)
                                {
                                    Utils.Informa = "Lo siento pero se ha presentado un error";
                                    Utils.Informa += "fatal en el sistema, porque el cardinal";
                                    Utils.Informa += "de la factura no se pudo encontrar en la";
                                    Utils.Informa += "tabla de empresas y terceros.";
                                    Utils.Informa += "Por favor corrija el número o pulse";
                                    Utils.Informa += "la tecla [ESC] para continuar.";
                                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                else
                                {
                                    TabEmpTer.Read();
                                    //Muestre algunos datos

                                    if (Convert.ToInt32(TabFacturas["Copago"]) == 0)
                                    {
                                        //Necesariamente va ha cancelar es una factura por el valor neto
                                        //hace el metodo de cancelación neto
                                        CboCancelaPor.SelectedIndex = 1;
                                    }
                                    else
                                    {
                                        CboCancelaPor.SelectedIndex = 2;
                                    }


                                    switch (CboCancelaPor.SelectedIndex)
                                    {
                                        case 1://Valor neto


                                            CboCuentaContable.SelectedValue = TabEmpTer["CueContDeudaRad"].ToString();


                                            if (TabEmpTer["TipoDocu"].ToString() == "NIT")
                                            {
                                                CboTipDocFac.SelectedValue = "NI";
                                            }
                                            else
                                            {
                                                CboTipDocFac.SelectedValue = TabEmpTer["TipoDocu"].ToString();
                                            }


                                            TxtNitCC.Text = TabEmpTer["NumDocu"].ToString();
                                            TxtCardiRecibo.Text = TabEmpTer["SucuDoc"].ToString();
                                            CboRegimUsua.SelectedValue = TabEmpTer["RegimenAdmin"].ToString();
                                            TxtNombreTercero.Text = TabEmpTer["NomAdmin"].ToString();

                                            ValFacTol = (Convert.ToDouble(TabFacturas["ValorFac"]) + Convert.ToDouble(TabFacturas["Copago"]) + Convert.ToDouble(TabFacturas["NotaDebito"]));
                                            ValDesFac = (Convert.ToDouble(TabFacturas["NotaCredito"]) + Convert.ToDouble(TabFacturas["DesVarios"]) + Convert.ToDouble(TabFacturas["Retencion"]) + Convert.ToDouble(TabFacturas["DesTramite"]) + Convert.ToDouble(TabFacturas["OtrosDescuentos"]));
                                            ValPagosFac = Convert.ToDouble(TabFacturas["PagoFac"]) + Convert.ToDouble(TabFacturas["CanceCopago"]) + Convert.ToDouble(TabFacturas["PagoConDepos"]);

                                            double totalPagos = (ValFacTol - (ValDesFac + ValPagosFac));

                                            TxtValorPagos.Text = totalPagos.ToString();



                                            break;
                                        case 2: //Valor copago

                                            CboCuentaContable.SelectedValue = TabEmpTer["CueContDeudaRad"].ToString();


                                            if (Utils.tipoDocEmp == "NIT")
                                            {
                                                CboTipDocFac.SelectedValue = "NI";
                                            }
                                            else
                                            {
                                                CboTipDocFac.SelectedValue = Utils.tipoDocEmp;
                                            }

                                            TxtNitCC.Text = Utils.NumDocPre;
                                            TxtCardiRecibo.Text = Utils.SucurPre;

                                            CboRegimUsua.SelectedValue = TabEmpTer["RegimenAdmin"].ToString();

                                            double ValorTotal = (Convert.ToDouble(TabFacturas["Copago"]) + Convert.ToDouble(TabFacturas["ValorOtros"])) - (Convert.ToDouble(TabFacturas["CanceCopago"]) + Convert.ToDouble(TabFacturas["PagoConDepos"]));

                                            TxtValorPagos.Text = ValorTotal.ToString();

                                            TxtNombreTercero.Text = "PARTICULAR";


                                            break;

                                        default:
                                            break;
                                    }
                                }
                            }
                        }//Factura Anulada
                    }//TabFacturas
                }//Using

            }
            catch (Exception)
            {

                throw;
            }
        }
        private void TxtValorPagos_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string VN01 = "", Fraser = "";

                Utils.Titulo01 = "Control de ejecución";
                if (Convert.ToDouble(TxtValorPagos.Text) < 0)
                {
                    Utils.Informa = "lo siento pero el valor a registrar" + "\r";
                    Utils.Informa += "no puede ser menor a cero (0)." + "\r";
                    Utils.Informa += "Por favor corrija el valor o pulse" + "\r";
                    Utils.Informa += "la tecla [ESC] para continuar." + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(TxtValorPagos.Text))
                {
                    return;
                }

                switch (Convert.ToInt32(CboCancelaPor.SelectedIndex))
                {
                    case 1: //Valor Neto
                        VN01 = TxtSaldoFac.Text;
                        Fraser = "el valor del pago";
                        break;
                    case 2:
                        VN01 = TxtCanceCopago1.Text;
                        Fraser = "el valor del copago";
                        break;
                    default:
                        break;
                }

                if (string.IsNullOrEmpty(VN01))
                {
                    Utils.Informa = "Lo siento el número de factura digitado no" + "\r";
                    Utils.Informa = Utils.Informa + "tiene datos relacionales en el sistema." + "\r";
                    Utils.Informa = Utils.Informa + "Por favor corrija el número o pulse" + "\r";
                    Utils.Informa = Utils.Informa + "la tecla [ESC] para continuar.";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    if (Convert.ToDouble(TxtValorPagos.Text) > Convert.ToDouble(VN01))
                    {
                        Utils.Informa = "Lo siento pero " + Fraser + " nunca " + "\r";
                        Utils.Informa = Utils.Informa + "puede ser mayor al saldo de la factura." + "\r";
                        Utils.Informa = Utils.Informa + "Por favor corrija el valor o pulse" + "\r";
                        Utils.Informa = Utils.Informa + "la tecla [ESC] para continuar.";
                        MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }



            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "al actualizar el valor del pago" + "\r";
                Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void TxtFacturaNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((int)e.KeyChar == (int)Keys.Enter)
                {
                    if (string.IsNullOrWhiteSpace(TxtFacturaNo.Text) == false)
                    {

                        CargarFactura();

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

        private void TxtNitCC_TextChanged(object sender, EventArgs e)
        {
            BuscarProve();
        }
        #endregion


        private void CargarGridFacturas()
        {
            try
            {
                string sqlFactura = "SELECT NumFactura, FechaFac, ValorTotal FROM [ACDATOXPSQL].[dbo].[Datos de las facturas realizadas] " +
                " WHERE ((([Datos de las facturas realizadas].AnuladaFac) = 'False')) AND [Datos de las facturas realizadas].PagoFac = 0 AND [Datos de las facturas realizadas].CodiRegis = '" + Utils.codUsuario + "'; ";


                DataSet dataSet = Conexion.SQLDataSet(sqlFactura);

                if(dataSet.Tables[0].Rows.Count > 0)
                {
                    DataGridFacturas.DataSource = dataSet.Tables[0];
                }

            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "en la funcion CargarGridFacturas" + "\r";
                Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        int FormaPago = 1;
        private void FrmPagosAFacturas_Load(object sender, EventArgs e)
        {
            try
            {
                CargarCombobox();
                CargarDatosUser();
                CargarGridFacturas();

            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "al abrir el formulario pago a facturas" + "\r";
                Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCrucedepositos_Click(object sender, EventArgs e)
        {
            try
            {
                Utils.Titulo01 = "Control para depositos";

                if (string.IsNullOrWhiteSpace(TxtFacturaNo.Text))
                {
                    Utils.Informa = "Aun no ha registrado el número" + "\r";
                    Utils.Informa += "de factura a consultar." + "\r";
                    Utils.Informa += "Por favor registrelo para continuar." + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TxtFacturaNo.Select();
                    return;
                }

                string HisCruce = TxtHistoNumPaciente1.Text;

                string SqlDepoPaci = "SELECT [Datos depositos a usuarios].HisDepo ";
                SqlDepoPaci += "FROM [BDCAJASQL].[dbo].[Datos depositos a usuarios] ";
                SqlDepoPaci += "WHERE (([Datos depositos a usuarios].HisDepo) = '" + HisCruce + "' )";
                SqlDepoPaci += "ORDER BY [Datos depositos a usuarios].HisDepo;";

                using (SqlConnection connection = new SqlConnection(Conexion.conexionSQL))
                {
                    SqlCommand command = new SqlCommand(SqlDepoPaci, connection);
                    command.Connection.Open();
                    SqlDataReader TabDepoPaci = command.ExecuteReader();


                    if (TabDepoPaci.HasRows == false)
                    {
                        Utils.Informa = "El  paciente  no  tiene" + "\r";
                        Utils.Informa += "depositos registrados" + "\r";
                        MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {

                        Utils.Histocruce = TxtHistoNumPaciente1.Text;
                        Utils.FacturDepo = TxtFacturaNo.Text;
                        Utils.TipoPago = CboCancelaPor.SelectedValue.ToString(); // NETO O COPAGO
                        Utils.RegimenUsu = CboRegimUsua.SelectedValue.ToString(); //Identifica el regimen del usuario
                        FrmCruceDepositos frmCruceDepositos = new FrmCruceDepositos();
                        frmCruceDepositos.ShowDialog();

                    }
                }
            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "al presionar el boton cruce de depositos" + "\r";
                Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timerGridFacturas_Tick(object sender, EventArgs e)
        {
            CargarGridFacturas();
        }

        private void DataGridFacturas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if(DataGridFacturas.SelectedRows.Count > 0)
            {
                string NumFactura = DataGridFacturas.SelectedCells[0].Value.ToString();
                TxtFacturaNo.Text = NumFactura;
                CargarFactura();
            }


        }
    }
}
