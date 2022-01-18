using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OBCAJASQL.Class;
using System.Data.SqlClient;

namespace OBCAJASQL.Report
{
    public partial class FrmReportFacturaSaldo : Form
    {
        public FrmReportFacturaSaldo()
        {
            InitializeComponent();
        }

        private void FrmReportFacturaSaldo_Load(object sender, EventArgs e)
        {
            try
            {


                string InfoEmpresaData = "SELECT * FROM [BDADMINSIG].[dbo].[Datos informacion de la empresa] WHERE [CodUnico] = '" + Utils.codUnicoEmpresa + "'";

                System.Data.DataSet InfoEmpresa = Conexion.SQLDataSet(InfoEmpresaData);

                ReportDataSource dsEmpresa = new ReportDataSource("dsEmpresa", InfoEmpresa.Tables[0]);


                string consulta = "SELECT [Datos de las facturas realizadas].NumFactura,  " +
                " (RTrim([NombreUsa] + ' ' + [Apellido1Usa]) + ' ' + isNull((Rtrim([Apellido2Usa])),'')) AS Facturador, " +
                " [Datos de las facturas realizadas].Cartercero, (Rtrim([Nombre1] + ' ' + isNull([Nombre2], '')) +' ' + (RTrim([Apellido1] + ' ' + isNull([Apellido2], '')))) AS Paciente, " +
                " [Datos de las facturas realizadas].FechaFac, [Datos de las facturas realizadas].ValorTotal, [Datos de las facturas realizadas].Copago, " +
                " ([PagoFac] +[CanceCopago]) AS ValorCancelado, ([ValorTotal]-([PagoFac] +[CanceCopago])) AS Saldo, RTrim([NomAdmin] +' ' + isNull([ProgrAmin],'')) AS Entidad, " +
                " [Datos de las facturas realizadas].AnuladaFac, case when[AnuladaFac] = 0 then 'Vigentes' ELSE 'Anuladas' END AS TerAnul " +
                " FROM([ACDATOXPSQL].[dbo].[Datos empresas y terceros] " +
                " INNER JOIN (([ACDATOXPSQL].[dbo].[Datos del Paciente] INNER JOIN [ACDATOXPSQL].[dbo].[Datos cuentas de consumos] ON [Datos del Paciente].HistorPaci = [Datos cuentas de consumos].HistoNum) " +
                " INNER JOIN [ACDATOXPSQL].[dbo].[Datos de las facturas realizadas] ON[Datos cuentas de consumos].CuenNum = [Datos de las facturas realizadas].NumCuenFac)  " +
                " ON [Datos empresas y terceros].CarAdmin = [Datos de las facturas realizadas].Cartercero) INNER JOIN [DATUSIIGXPSQL].[dbo].[Datos usuarios de los aplicativos] " +
                " ON [Datos de las facturas realizadas].CodiRegis = [DATUSIIGXPSQL].[dbo].[Datos usuarios de los aplicativos].CodigoUsa WHERE ([PagoFac] +[CanceCopago]) = 0 and " +
                " "+ Utils.condicion +" " +
                " ORDER BY [Datos de las facturas realizadas].NumFactura; ";


                System.Data.DataSet InfoFactura = Conexion.SQLDataSet(consulta);

                ReportDataSource dsDetalle = new ReportDataSource("dsDetalle", InfoFactura.Tables[0]);


                this.reportViewer1.LocalReport.DataSources.Clear();

                this.reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;

                this.reportViewer1.LocalReport.EnableExternalImages = true;

                ReportParameter[] parameters = new ReportParameter[2];


                parameters[0] = new ReportParameter("FecInicial", Utils.FecInicial);
                parameters[1] = new ReportParameter("FecFinal", Utils.FecFinal);

                this.reportViewer1.LocalReport.DataSources.Add(dsEmpresa);
                this.reportViewer1.LocalReport.DataSources.Add(dsDetalle);

                string reporte = "OBCAJASQL.Report.Rdlc." + Utils.infNombreInforme + ".rdlc";

                this.reportViewer1.LocalReport.ReportEmbeddedResource = reporte;

                this.reportViewer1.LocalReport.SetParameters(parameters);

                this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);

                this.reportViewer1.ZoomMode = ZoomMode.Percent;

                this.reportViewer1.ZoomPercent = 100;

                this.reportViewer1.RefreshReport();

            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "al cargar el reporte Facturas con saldo" + "\r";
                Utils.Informa += "Error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
