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
using Microsoft.Reporting.WinForms;

namespace OBCAJASQL.Report
{
    public partial class FrmReciboDeCajas : Form
    {
        public FrmReciboDeCajas()
        {
            InitializeComponent();
        }

        private void FrmReciboDeCajas_Load(object sender, EventArgs e)
        {

            string InfoEmpresaData = "SELECT * FROM [BDADMINSIG].[dbo].[Datos informacion de la empresa] WHERE [CodUnico] = '" + Utils.codUnicoEmpresa + "'";

            System.Data.DataSet InfoEmpresa = Conexion.SQLDataSet(InfoEmpresaData);

            ReportDataSource dsEmpresa = new ReportDataSource("dsEmpresa", InfoEmpresa.Tables[0]);

            decimal valorTotal = 0;
            string valorTotalLetras = "";
            string anulPor = "";

            //La consilta viene por desde el formulario

            System.Data.DataSet infoCaja = Conexion.SQLDataSet(Utils.SqlDatos);

            ReportDataSource dsCaja = new ReportDataSource("dsDetalle", infoCaja.Tables[0]);

            using (SqlConnection connection = new SqlConnection(Conexion.conexionSQL))
            {
                SqlCommand command = new SqlCommand(Utils.SqlDatos, connection);
                command.Connection.Open();
                SqlDataReader TabCaja = command.ExecuteReader();

                if (TabCaja.HasRows)
                {
                    TabCaja.Read();

                    valorTotalLetras = Conversores.NumeroALetras(valorTotal);

                    bool anul = Convert.ToBoolean(TabCaja["AnuladoRecibo"]);
                    string CodiAnul = TabCaja["CodiAnul"].ToString();

                    if (anul)
                    {
                        //Si estan anulada buscamos al usuario quien realizo dicho proceso

                        Utils.SqlDatos = "SELECT (NombreUsa + ' ' + Apellido1Usa) as NombreUser FROM [DATUSIIGXPSQL].[dbo].[Datos usuarios de los aplicativos] WHERE CodigoUsa = '" + CodiAnul + "'";

                        using (SqlConnection connection2 = new SqlConnection(Conexion.conexionSQL))
                        {
                            SqlCommand command2 = new SqlCommand(Utils.SqlDatos, connection2);
                            command2.Connection.Open();
                            SqlDataReader TabUsuario = command2.ExecuteReader();

                            if (TabUsuario.HasRows)
                            {
                                TabUsuario.Read();
                                anulPor = TabUsuario["NombreUser"].ToString();
                            }
                        }
                    }
                }
            }


            Utils.SqlDatos = "SELECT SUM([CantidadCaja]*[ValorUnitaCaja]) as ValorTotal FROM [GEOGRAXPSQL].[dbo].[Datos proveedores] INNER JOIN (([ACDATOXPSQL].[dbo].[Datos del Paciente]   " +
            " INNER JOIN[BDCAJASQL].[dbo].[Datos recibos de caja] ON [Datos del Paciente].HistorPaci = [Datos recibos de caja].HistorPaciente)  INNER JOIN[BDCAJASQL].[dbo].[Datos detalles recibos de caja] " +
            " ON [Datos recibos de caja].ReciboCaja = [Datos detalles recibos de caja].ReciboNum)  ON ([Datos proveedores].TipoDocu = [Datos recibos de caja].TipoDocu) AND ([Datos proveedores].IdenProve = [Datos recibos de caja].NumDocu)   " +
            " AND ([Datos proveedores].SucurProv = [Datos recibos de caja].SucuDocu) WHERE ((([Datos detalles recibos de caja].ValorUnitaCaja) > 0)) " +
            " AND" + Utils.Condicion + " ";


            using (SqlConnection connection = new SqlConnection(Conexion.conexionSQL))
            {
                SqlCommand command = new SqlCommand(Utils.SqlDatos, connection);
                command.Connection.Open();
                SqlDataReader TabValorTolCaja = command.ExecuteReader();

                if (TabValorTolCaja.HasRows)
                {
                    TabValorTolCaja.Read();
                    valorTotal = Convert.ToDecimal(TabValorTolCaja["ValorTotal"]);

                    valorTotalLetras = Conversores.NumeroALetras(valorTotal);

                }

            }



            this.reportViewer1.LocalReport.DataSources.Clear();

            this.reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;

            this.reportViewer1.LocalReport.EnableExternalImages = true;

            ReportParameter[] parameters = new ReportParameter[2];

            parameters[0] = new ReportParameter("NumeroLetras", valorTotalLetras);

            parameters[1] = new ReportParameter("ResponAnul", anulPor);

            this.reportViewer1.LocalReport.DataSources.Add(dsEmpresa);

            this.reportViewer1.LocalReport.DataSources.Add(dsCaja);

            string reporte = "OBCAJASQL.Report.Rdlc." + Utils.infNombreInforme + ".rdlc";

            this.reportViewer1.LocalReport.ReportEmbeddedResource = reporte;

            this.reportViewer1.LocalReport.SetParameters(parameters);

            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);

            this.reportViewer1.ZoomMode = ZoomMode.Percent;

            this.reportViewer1.ZoomPercent = 100;

            this.reportViewer1.RefreshReport();

        }
    }
}
