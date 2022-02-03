using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OBCAJASQL.Forms.Administracion.Auditoria;
using System.Data.OleDb;
using System.Data.SqlClient;
using OBCAJASQL.Class;
using OBCAJASQL.Forms.Caja;
using OBCAJASQL.Forms.Caja.Reportes;
using OBCAJASQL.Forms.Pagares;

namespace OBCAJASQL.Forms
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                Utils.BaseDeDatosPrincipal = "ACDATOXPSQL";

                Conexion.conexionACCESS = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\SIIGHOSPLUS\LogPlus.LogSip;Jet OLEDB:Database Password=SIIGHOS33";

                Utils.SqlDatos = "SELECT * FROM [Local registro del usuario]";

                OleDbDataReader dr = Conexion.AccessDataReaderOLEDB(Utils.SqlDatos);

                if (dr.HasRows)
                {
                    dr.Read();

                    // Se procede a validar las credenciales de acceso al Servidor SQL Server
                    // Y verificar el tipo de cliente de SQL Server

                    Conexion.servidor = dr["NomServi"].ToString();
                    Conexion.username = dr["NomUsar"].ToString();
                    Conexion.password = dr["PassWusa"].ToString();

                    Conexion.conexionSQL = "Server=" + Conexion.servidor + "; " +
                                           "Initial Catalog=" + Utils.BaseDeDatosPrincipal + ";" +
                                           "User ID=" + Conexion.username + "; " +
                                           "Password=" + Conexion.password;


                    Utils.codUsuario = dr["CodigUsar"].ToString();
                    Utils.nomUsuario = dr["NombreUsar"].ToString();
                    Utils.nivelPermiso = dr["NivelPermiso"].ToString();
                    Utils.codUnicoEmpresa = dr["CodRegEn"].ToString(); // CodEnti
                    Utils.CodAplicacion = dr["CodApli"].ToString();
                    Utils.CodEspecialidad = dr["CodEspecialidad"].ToString();
                    Utils.CodigoMedico = dr["CodigoMedico"].ToString();

                    Utils.CenCosCaja = dr["CenCosCaja"].ToString();
                    Utils.CuenConta = dr["CuenConta"].ToString();
                    Utils.CuentaContable = dr["CuenConaCoPa"].ToString();

                    Utils.TipoDocDebi = dr["TipoDocumEmp"].ToString();
                    Utils.NumDocDebi = dr["NitCCEmpresa"].ToString();
                    Utils.SucuCtaDebi = dr["SucurEmpre"].ToString();
                    Utils.DigiVerDebi = dr["DigVerEm"].ToString();
                    Utils.NumDocDebiDos = dr["NitCCEmpreDos"].ToString();

                    Utils.NumHisPrede = dr["NumHisPrede"].ToString();
                    Utils.TipDocPre = dr["TipDocPre"].ToString();
                    Utils.NumDocPre = dr["NumDocPre"].ToString();
                    Utils.SucurPre = dr["SucurPre"].ToString();

                    this.lblFecha.Text = DateTime.Now.ToString("dddd dd 'de' MMMM 'de' yyyy") + "   -";
                    this.lblCodUsuario.Text = Utils.codUsuario;
                    this.lblNomUsuario.Text = Utils.nomUsuario;

                    Utils.SqlDatos = @"SELECT CodiMinSalud, NitCCEmpresa,CatEmpresa, NomEmpresa,LogoEmpresa, TipoDocEmp, TelPrin " +
                                   "FROM [BDADMINSIG].[dbo].[Datos informacion de la empresa] " +
                                   "WHERE CodUnico = @codUnicoEmpresa";

                    List<SqlParameter> parameters = new List<SqlParameter>
                    {
                        new SqlParameter("@codUnicoEmpresa", SqlDbType.VarChar, 2) { Value = Utils.codUnicoEmpresa }
                    };

                    SqlDataReader Sqldr = Conexion.SQLDataReader(Utils.SqlDatos, parameters);

                    if (Sqldr.HasRows)
                    {
                        Sqldr.Read();
                        Utils.codMinSalud = Sqldr["CodiMinSalud"].ToString();
                        Utils.nitEmpresa = Sqldr["NitCCEmpresa"].ToString();
                        Utils.nomEmpresa = Sqldr["NomEmpresa"].ToString();
                        Utils.CateEmpresa = Sqldr["CatEmpresa"].ToString();
                        Utils.tipoDocEmp = Sqldr["TipoDocEmp"].ToString();
                        Utils.TelEmpresa = Sqldr["TelPrin"].ToString();
                    }


                    Sqldr.Close();
                }
                else
                {
                    this.Close();
                }


                //Buscamos la caja predeterminada

                Conexion.conexionACCESS = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\SIIGHOSPLUS\INICAJA.SIG;Jet OLEDB:Database Password=SIIGHOS33";

                string SqlCajaPret = "SELECT [Datos caja predeterminada].CodCaja, [Datos caja predeterminada].ActiCaja ";
                SqlCajaPret = SqlCajaPret + "FROM [Datos caja predeterminada] ";
                SqlCajaPret = SqlCajaPret + "WHERE ((([Datos caja predeterminada].ActiCaja) = '1')) ";

                OleDbDataReader dr2 = Conexion.AccessDataReaderOLEDB(SqlCajaPret);

                if (dr2.HasRows)
                {
                    dr2.Read();

                    Utils.CodCaja = dr2["CodCaja"].ToString();

                    //Procedemos a buscar el nombre de la Caja preterminada, haber si existe en las bases de datos del programa

                    string SqlCaja = "SELECT [Datos cajas y consecutivos].* ";
                    SqlCaja = SqlCaja + "FROM [BDCAJASQL].[dbo].[Datos cajas y consecutivos] ";
                    SqlCaja = SqlCaja + "WHERE ((([Datos cajas y consecutivos].CodCaja) = '" + Utils.CodCaja + "' )) ";


                    SqlDataReader TabCaja = Conexion.SQLDataReader(SqlCaja);

                    if (TabCaja.HasRows == false)
                    {
                        Utils.Informa = "Lo siento pero el código " + Utils.CodCaja + " asignado a la" + "\r";
                        Utils.Informa += "Caja prederminada, en esta estación de trabajo" + "\r";
                        Utils.Informa += "no existe en la base de datos de nombres de Cajas," + "\r";
                        Utils.Informa += "por lo tanto no se puede abrir este módulo." + "\r";
                        MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        TabCaja.Read();

                        //Muestre el nombre de la Caja

                        Utils.NombgPre = TabCaja["NomCaja"].ToString();

                    }

                    if (Conexion.sqlConnection.State == ConnectionState.Open) Conexion.sqlConnection.Close();


                }
                else
                {
                    Utils.Informa = "Lo siento pero la identificación de las cajas" + "\r";
                    Utils.Informa += "predeterminadas, no existe un registro que" + "\r";
                    Utils.Informa += "pueda definir cual es la caja con la cual" + "\r";
                    Utils.Informa += "se inicia este aplicativo." + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                dr2.Close();

                string cadena = Utils.nomEmpresa;

                string[] parte = cadena.Split(' ');

                int cantidad = parte.Length;

                LblNombreEmpresa.Text = "";

                if (cantidad > 4)
                {

                    int parImpar = cantidad % 2;

                    int mitadSalto = parImpar == 0 ? cantidad / 2 : (cantidad + 1) / 2;

                    for (int i = 0; i < parte.Length; i++)
                    {
                        if (i == mitadSalto)
                        {
                            LblNombreEmpresa.Text += "\r";
                        }

                        LblNombreEmpresa.Text = LblNombreEmpresa.Text + parte[i] + " ";

                    }

                    LblNombreEmpresa.Text += "\r" + Utils.CateEmpresa;


                }
                else
                {
                    LblNombreEmpresa.Text = Utils.nomEmpresa + "\r" + Utils.CateEmpresa;
                }




                dr.Close();
            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "al abrir el formulario principal" + "\r";
                Utils.Informa += "Error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void facturasConSaldoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReportesFacturaConSaldo frmReportesFacturaConSaldo = new FrmReportesFacturaConSaldo();
            frmReportesFacturaConSaldo.ShowDialog();
        }

        private void ingresosGeneralesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FrmCajaGeneral frmCajaGeneral = new FrmCajaGeneral();
            frmCajaGeneral.ShowDialog();

        }

        private void pagosAFacturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPagosAFacturas frmPagosAFacturas = new FrmPagosAFacturas();
            frmPagosAFacturas.ShowDialog();
        }

        private void depositosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCajaDepositos frmCajaDepositos = new FrmCajaDepositos();
            frmCajaDepositos.ShowDialog();
        }

        private void ingresosDeCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReporteIngresosPorCaja frmReporteIngresosPorCaja = new FrmReporteIngresosPorCaja();
            frmReporteIngresosPorCaja.ShowDialog();
        }

        private void reportesGeneralesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReportesGenerales frmReportesGenerales = new FrmReportesGenerales();
            frmReportesGenerales.ShowDialog();
        }

        private void crucesPorDesositosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCruceDepositos frmCruceDepositos = new FrmCruceDepositos();
            frmCruceDepositos.ShowDialog();
        }

        private void ingresarPagaresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRegistroPagares frmRegistroPagares = new FrmRegistroPagares();
            frmRegistroPagares.ShowDialog();
        }
    }
}
