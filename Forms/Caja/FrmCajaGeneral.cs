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
                " FROM[ACDATOXPSQL].[dbo].[Datos documentos empresas] " +
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

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

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

        private void TxtHistoriaNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((int)e.KeyChar == (int)Keys.Enter)
                {
                    if (string.IsNullOrWhiteSpace(TxtHistoriaNumero.Text) == false)
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
                Utils.Titulo01 = "Control para buscar datos";

                if (string.IsNullOrWhiteSpace(TxtNitNumero.Text))
                {
                    return;
                }

                string CNT = TxtNitNumero.Text;



                //Revisamos si ya selecciono el tipo de documento

                if(cboTipDoTer.SelectedIndex == -1)
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
                " FROM [Datos proveedores] " +
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

 
    }
}
