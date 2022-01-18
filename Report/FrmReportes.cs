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
    public partial class FrmReportes : Form
    {
        public FrmReportes()
        {
            InitializeComponent();
        }


        private string TotalPorFormaPago(string FP, int Anul)
        {
            try
            {
                string Total = "";

                string sqlDatos = "SELECT[Datos recibos de caja].TipoPagoCaja, Sum(([CantidadCaja] *[ValorUnitaCaja])) AS TolRecib " +
                                " FROM [BDCAJASQL].[dbo].[Datos recibos de caja] INNER JOIN[BDCAJASQL].[dbo].[Datos detalles recibos de caja] ON[Datos recibos de caja].ReciboCaja = [Datos detalles recibos de caja].ReciboNum " +
                                $" WHERE ((([Datos recibos de caja].FechaPagoCaja) >= CONVERT(DATETIME, '{Utils.FechaInicial}', 102) And ([Datos recibos de caja].FechaPagoCaja) <= CONVERT(DATETIME, '{Utils.FechaFinal}', 102) ) and " +
                                " ([Datos recibos de caja].AnuladoRecibo) = " + Anul + ")  " +
                                " GROUP BY[Datos recibos de caja].TipoPagoCaja " +
                                " HAVING (([Datos recibos de caja].TipoPagoCaja) = '" + FP + "'); ";



                using (SqlConnection connection = new SqlConnection(Conexion.conexionSQL))
                {
                    SqlCommand command = new SqlCommand(sqlDatos, connection);
                    command.Connection.Open();
                    SqlDataReader TabTotales = command.ExecuteReader();

                    if (TabTotales.HasRows)
                    {
                        TabTotales.Read();
                        Total = TabTotales["TolRecib"].ToString();
                    }
                    else
                    {
                        Total = "";
                    }
                }

                return Total;

            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "en la funcion TotalPorFormaPago" + "\r";
                Utils.Informa += "Error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }


        private void FrmReportes_Load(object sender, EventArgs e)
        {
            try
            {

                ReportDataSource dsDetalle = null;
                ReportParameter[] parameters = null;
                System.Data.DataSet infoSql;

                string InfoEmpresaData = "SELECT * FROM [BDADMINSIG].[dbo].[Datos informacion de la empresa] WHERE [CodUnico] = '" + Utils.codUnicoEmpresa + "'";

                System.Data.DataSet InfoEmpresa = Conexion.SQLDataSet(InfoEmpresaData);

                ReportDataSource dsEmpresa = new ReportDataSource("dsEmpresa", InfoEmpresa.Tables[0]);

                switch (Utils.infNombreInforme)
                {
                    case "Informe de caja por usuarios":


                        Utils.SqlDatos = $"SELECT [Datos detalles recibos de caja].ReciboNum,  (RTrim([Nombre1] + ' ' + ISNULL([Nombre2],'')) + ' ' + (RTrim([Apellido1] + ' ' + ISNULL([Apellido2],'')))) AS Paciente,   [Datos proveedores].RazonSol, Sum(([CantidadCaja] *[ValorUnitaCaja])) AS TolReci,  [Datos recibos de caja].FechaPagoCaja, [Datos recibos de caja].CodRegis,  [Datos recibos de caja].AnuladoRecibo, RTRIM([NombreUsa] + ' ' + ISNULL([Apellido1Usa],'') +' ' + ISNULL([Apellido2Usa],'')) AS RegistradoPor,  (SELECT Sum(([CantidadCaja] *[ValorUnitaCaja])) AS TolRecib  FROM [BDCAJASQL].[dbo].[Datos recibos de caja] as C INNER JOIN[BDCAJASQL].[dbo].[Datos detalles recibos de caja] ON c.ReciboCaja = [Datos detalles recibos de caja].ReciboNum  WHERE (c.FechaPagoCaja >= CONVERT(DATETIME, '{Utils.FechaInicial}', 102) And c.FechaPagoCaja <= CONVERT(DATETIME, '{Utils.FechaFinal}', 102)   and  c.AnuladoRecibo = '{Utils.Anulado}')  AND c.TipoPagoCaja = 'EF'  AND C.CodRegis = [Datos recibos de caja].CodRegis  ) AS TolEfec,  (SELECT Sum(([CantidadCaja] *[ValorUnitaCaja])) AS TolRecib  FROM [BDCAJASQL].[dbo].[Datos recibos de caja] as C INNER JOIN[BDCAJASQL].[dbo].[Datos detalles recibos de caja] ON c.ReciboCaja = [Datos detalles recibos de caja].ReciboNum  WHERE (c.FechaPagoCaja >= CONVERT(DATETIME, '{Utils.FechaInicial}', 102) And c.FechaPagoCaja <= CONVERT(DATETIME, '{Utils.FechaFinal}', 102)   and  c.AnuladoRecibo = '{Utils.Anulado}')  AND c.TipoPagoCaja = 'TC'  AND C.CodRegis = [Datos recibos de caja].CodRegis  ) AS TolTC,  (SELECT Sum(([CantidadCaja] *[ValorUnitaCaja])) AS TolRecib  FROM[BDCAJASQL].[dbo].[Datos recibos de caja] as C INNER JOIN[BDCAJASQL].[dbo].[Datos detalles recibos de caja] ON c.ReciboCaja = [Datos detalles recibos de caja].ReciboNum  WHERE (c.FechaPagoCaja >= CONVERT(DATETIME, '{Utils.FechaInicial}', 102) And c.FechaPagoCaja <= CONVERT(DATETIME, '{Utils.FechaFinal}', 102)   and  c.AnuladoRecibo = '{Utils.Anulado}')  AND c.TipoPagoCaja = 'CH'  AND C.CodRegis = [Datos recibos de caja].CodRegis  ) AS TolCH,  (SELECT Sum(([CantidadCaja] *[ValorUnitaCaja])) AS TolRecib  FROM[BDCAJASQL].[dbo].[Datos recibos de caja] as C INNER JOIN[BDCAJASQL].[dbo].[Datos detalles recibos de caja] ON c.ReciboCaja = [Datos detalles recibos de caja].ReciboNum  WHERE (c.FechaPagoCaja >= CONVERT(DATETIME, '{Utils.FechaInicial}', 102) And c.FechaPagoCaja <= CONVERT(DATETIME, '{Utils.FechaFinal}', 102)   and  c.AnuladoRecibo = '{Utils.Anulado}')  AND c.TipoPagoCaja = 'BO'  AND C.CodRegis = [Datos recibos de caja].CodRegis  ) AS TolBO  FROM [DATUSIIGXPSQL].[dbo].[Datos usuarios de los aplicativos] RIGHT JOIN([GEOGRAXPSQL].[dbo].[Datos proveedores] INNER JOIN  ([ACDATOXPSQL].[dbo].[Datos del Paciente] INNER JOIN ([BDCAJASQL].[dbo].[Datos recibos de caja] INNER JOIN [BDCAJASQL].[dbo].[Datos detalles recibos de caja]  ON [Datos recibos de caja].ReciboCaja = [Datos detalles recibos de caja].ReciboNum)  ON[Datos del Paciente].HistorPaci = [Datos recibos de caja].HistorPaciente)   ON([Datos proveedores].TipoDocu = [Datos recibos de caja].TipoDocu)  AND([Datos proveedores].IdenProve = [Datos recibos de caja].NumDocu) AND([Datos proveedores].SucurProv = [Datos recibos de caja].SucuDocu))   ON[Datos usuarios de los aplicativos].CodigoUsa = [Datos recibos de caja].CodRegis  WHERE [BDCAJASQL].[dbo].[Datos recibos de caja].[FechaPagoCaja] >= CONVERT(DATETIME, '{Utils.FechaInicial}', 102)  and [BDCAJASQL].[dbo].[Datos recibos de caja].[FechaPagoCaja] <= CONVERT(DATETIME, '{Utils.FechaFinal}', 102)  and [BDCAJASQL].[dbo].[Datos recibos de caja].[AnuladoRecibo] = '{Utils.Anulado}'  GROUP BY [Datos detalles recibos de caja].ReciboNum,  (RTrim([Nombre1] + ' ' + ISNULL([Nombre2], '')) +' ' + (RTrim([Apellido1] + ' ' + ISNULL([Apellido2], '')))), [Datos proveedores].RazonSol, [Datos recibos de caja].FechaPagoCaja,   [Datos recibos de caja].CodRegis, [Datos recibos de caja].AnuladoRecibo,  RTRIM([NombreUsa] + ' ' + ISNULL([Apellido1Usa],'') +' ' + ISNULL([Apellido2Usa],''))  order by RegistradoPor desc";

                        infoSql = Conexion.SQLDataSet(Utils.SqlDatos);
                        dsDetalle = new ReportDataSource("dsDetalle", infoSql.Tables[0]);
                        parameters = new ReportParameter[2];
                        parameters[0] = new ReportParameter("Fecha01", Utils.FechaInicial);
                        parameters[1] = new ReportParameter("Fecha02", Utils.FechaFinal);


                        break;

                    case "Informe de caja por entidades":


                        Utils.SqlDatos = $"SELECT [Datos detalles recibos de caja].ReciboNum,  (RTrim([Nombre1] + ' ' + [Nombre2]) + ' ' + (RTrim([Apellido1] + ' ' + [Apellido2]))) AS Paciente,  [Datos proveedores].RazonSol,  Sum(([CantidadCaja] * [ValorUnitaCaja])) AS TolReci, [Datos recibos de caja].FechaPagoCaja,  [Datos recibos de caja].AnuladoRecibo,  [Datos recibos de caja].TipoDocu, [Datos recibos de caja].NumDocu, ([Datos recibos de caja].[TipoDocu] + ': ' + [NumDocu]) AS Identifica,  [Datos recibos de caja].SucuDocu,  (SELECT Sum(([CantidadCaja] *[ValorUnitaCaja])) AS TolReci  FROM [BDCAJASQL].[dbo].[Datos recibos de caja] AS C INNER JOIN[BDCAJASQL].[dbo].[Datos detalles recibos de caja] AS D ON C.ReciboCaja = D.ReciboNum  WHERE (((C.FechaPagoCaja) >= CONVERT(DATETIME, '{Utils.FechaInicial}', 102) And  (C.FechaPagoCaja) <= CONVERT(DATETIME, '{Utils.FechaFinal}', 102)))   GROUP BY C.TipoDocu, C.NumDocu, C.SucuDocu, C.TipoPagoCaja, C.AnuladoRecibo  HAVING (((C.TipoDocu) = [Datos recibos de caja].[TipoDocu]) AND  ((C.NumDocu) = [Datos recibos de caja].[NumDocu]) AND ((C.SucuDocu) = [Datos recibos de caja].SucuDocu) AND  ((C.TipoPagoCaja) = 'EF ') AND((C.AnuladoRecibo) = [Datos recibos de caja].AnuladoRecibo)))  AS TolEfec,  (SELECT Sum(([CantidadCaja] *[ValorUnitaCaja])) AS TolReci  FROM [BDCAJASQL].[dbo].[Datos recibos de caja] AS C INNER JOIN[BDCAJASQL].[dbo].[Datos detalles recibos de caja] AS D ON C.ReciboCaja = D.ReciboNum  WHERE (((C.FechaPagoCaja) >= CONVERT(DATETIME, '{Utils.FechaInicial}', 102) And  (C.FechaPagoCaja) <= CONVERT(DATETIME, '{Utils.FechaFinal}', 102)))   GROUP BY C.TipoDocu, C.NumDocu, C.SucuDocu, C.TipoPagoCaja, C.AnuladoRecibo  HAVING(((C.TipoDocu) = [Datos recibos de caja].[TipoDocu]) AND  ((C.NumDocu) = [Datos recibos de caja].[NumDocu]) AND((C.SucuDocu) = [Datos recibos de caja].SucuDocu) AND  ((C.TipoPagoCaja) = 'TC ') AND((C.AnuladoRecibo) = [Datos recibos de caja].AnuladoRecibo)))  AS TolTC,  (SELECT Sum(([CantidadCaja] *[ValorUnitaCaja])) AS TolReci  FROM [BDCAJASQL].[dbo].[Datos recibos de caja] AS C INNER JOIN[BDCAJASQL].[dbo].[Datos detalles recibos de caja] AS D ON C.ReciboCaja = D.ReciboNum  WHERE (((C.FechaPagoCaja) >= CONVERT(DATETIME, '{Utils.FechaInicial}', 102) And  (C.FechaPagoCaja) <= CONVERT(DATETIME, '{Utils.FechaFinal}', 102)))   GROUP BY C.TipoDocu, C.NumDocu, C.SucuDocu, C.TipoPagoCaja, C.AnuladoRecibo  HAVING(((C.TipoDocu) = [Datos recibos de caja].[TipoDocu]) AND  ((C.NumDocu) = [Datos recibos de caja].[NumDocu]) AND((C.SucuDocu) = [Datos recibos de caja].SucuDocu) AND  ((C.TipoPagoCaja) = 'CH ') AND((C.AnuladoRecibo) = [Datos recibos de caja].AnuladoRecibo)))  AS TolCH,  (SELECT Sum(([CantidadCaja] *[ValorUnitaCaja])) AS TolReci  FROM [BDCAJASQL].[dbo].[Datos recibos de caja] AS C INNER JOIN[BDCAJASQL].[dbo].[Datos detalles recibos de caja] AS D ON C.ReciboCaja = D.ReciboNum  WHERE (((C.FechaPagoCaja) >= CONVERT(DATETIME, '{Utils.FechaInicial}', 102) And  (C.FechaPagoCaja) <= CONVERT(DATETIME, '{Utils.FechaFinal}', 102)))   GROUP BY C.TipoDocu, C.NumDocu, C.SucuDocu, C.TipoPagoCaja, C.AnuladoRecibo  HAVING(((C.TipoDocu) = [Datos recibos de caja].[TipoDocu]) AND  ((C.NumDocu) = [Datos recibos de caja].[NumDocu]) AND((C.SucuDocu) = [Datos recibos de caja].SucuDocu) AND  ((C.TipoPagoCaja) = 'BO ') AND((C.AnuladoRecibo) = [Datos recibos de caja].AnuladoRecibo)))  AS TolBO  FROM [GEOGRAXPSQL].[dbo].[Datos proveedores] INNER JOIN(([ACDATOXPSQL].[dbo].[Datos del Paciente] RIGHT JOIN [BDCAJASQL].[dbo].[Datos recibos de caja]  ON [Datos del Paciente].HistorPaci = [Datos recibos de caja].HistorPaciente) INNER JOIN[BDCAJASQL].[dbo].[Datos detalles recibos de caja]  ON [Datos recibos de caja].ReciboCaja = [Datos detalles recibos de caja].ReciboNum) ON([Datos proveedores].TipoDocu = [Datos recibos de caja].TipoDocu)   AND ([Datos proveedores].IdenProve = [Datos recibos de caja].NumDocu) AND([Datos proveedores].SucurProv = [Datos recibos de caja].SucuDocu)   WHERE [BDCAJASQL].[dbo].[Datos recibos de caja].[FechaPagoCaja] >= CONVERT(DATETIME, '{Utils.FechaInicial}', 102) and [BDCAJASQL].[dbo].[Datos recibos de caja].[FechaPagoCaja] <= CONVERT(DATETIME, '{Utils.FechaFinal}', 102)  and [BDCAJASQL].[dbo].[Datos recibos de caja].[AnuladoRecibo] = '{Utils.Anulado}'  GROUP BY[Datos detalles recibos de caja].ReciboNum, (RTrim([Nombre1] + ' ' + [Nombre2]) + ' ' + (Rtrim([Apellido1] + ' ' + [Apellido2]))),    [Datos proveedores].RazonSol, [Datos recibos de caja].FechaPagoCaja, [Datos recibos de caja].AnuladoRecibo, [Datos recibos de caja].TipoDocu,  [Datos recibos de caja].NumDocu,  ([Datos recibos de caja].[TipoDocu] + ': ' + [NumDocu]), [Datos recibos de caja].SucuDocu;";


                        infoSql = Conexion.SQLDataSet(Utils.SqlDatos);
                        dsDetalle = new ReportDataSource("dsDetalle", infoSql.Tables[0]);
                        parameters = new ReportParameter[2];
                        parameters[0] = new ReportParameter("Fecha01", Utils.FechaInicial);
                        parameters[1] = new ReportParameter("Fecha02", Utils.FechaFinal);



                        break;
                    case "Informe de caja por regimen":

                        Utils.SqlDatos = "SELECT [Datos detalles recibos de caja].ReciboNum, (Trim([Nombre1] + ' ' + [Nombre2]) + ' ' + (Trim([Apellido1] + ' ' + [Apellido2]))) AS Paciente,  " +
                        " [Datos proveedores].RazonSol, Sum(([CantidadCaja] *[ValorUnitaCaja])) AS TolReci, [Datos recibos de caja].FechaPagoCaja, [Datos recibos de caja].AnuladoRecibo, " +
                        " [Datos recibos de caja].TipoDocu, [Datos recibos de caja].NumDocu, [Datos recibos de caja].SucuDocu, [Datos del Paciente].TipoUsar, [Datos tipos de usuarios].NomTipo " +
                        " FROM [GEOGRAXPSQL].[dbo].[Datos proveedores] INNER JOIN(([ACDATOXPSQL].[dbo].[Datos tipos de usuarios] RIGHT JOIN ([ACDATOXPSQL].[dbo].[Datos del Paciente] RIGHT JOIN [BDCAJASQL].[dbo].[Datos recibos de caja] " +
                        " ON [Datos del Paciente].HistorPaci = [Datos recibos de caja].HistorPaciente) ON[Datos tipos de usuarios].CodTipoUsuar = [Datos del Paciente].TipoUsar)  " +
                        " INNER JOIN [BDCAJASQL].[dbo].[Datos detalles recibos de caja] ON[Datos recibos de caja].ReciboCaja = [Datos detalles recibos de caja].ReciboNum)  " +
                        " ON ([Datos proveedores].TipoDocu = [Datos recibos de caja].TipoDocu) AND ([Datos proveedores].IdenProve = [Datos recibos de caja].NumDocu)  " +
                        $" AND ([Datos proveedores].SucurProv = [Datos recibos de caja].SucuDocu) WHERE [Datos recibos de caja].FechaPagoCaja >= CONVERT(DATETIME, '{Utils.FechaInicial}', 102) And  [Datos recibos de caja].FechaPagoCaja <= CONVERT(DATETIME, '{Utils.FechaFinal}', 102) AND [Datos recibos de caja].[AnuladoRecibo] = '{Utils.Anulado}' GROUP BY [Datos detalles recibos de caja].ReciboNum, " +
                        " (Trim([Nombre1] + ' ' + [Nombre2]) + ' ' + (Trim([Apellido1] + ' ' + [Apellido2]))), [Datos proveedores].RazonSol, [Datos recibos de caja].FechaPagoCaja, " +
                        " [Datos recibos de caja].AnuladoRecibo, [Datos recibos de caja].TipoDocu, [Datos recibos de caja].NumDocu, " +
                        " [Datos recibos de caja].SucuDocu, [Datos del Paciente].TipoUsar, [Datos tipos de usuarios].NomTipo; ";

                        infoSql = Conexion.SQLDataSet(Utils.SqlDatos);
                        dsDetalle = new ReportDataSource("dsDetalle", infoSql.Tables[0]);
                        parameters = new ReportParameter[2];
                        parameters[0] = new ReportParameter("Fecha01", Utils.FechaInicial);
                        parameters[1] = new ReportParameter("Fecha02", Utils.FechaFinal);


                        break;
                    case "Informe de caja por pacientes":

                        Utils.SqlDatos = "SELECT [Datos detalles recibos de caja].ReciboNum, [Datos detalles recibos de caja].DetaPagoCaja, " +
                        " [Datos recibos de caja].HistorPaciente, (Trim([Nombre1] + ' ' + [Nombre2]) + ' ' + Trim([Apellido1] + ' ' + [Apellido2])) AS Paciente, " +
                        " [Datos recibos de caja].TipoPagoCaja, [Datos recibos de caja].FechaPagoCaja, [Datos recibos de caja].AnuladoRecibo, [Datos detalles recibos de caja].CantidadCaja, " +
                        " [Datos detalles recibos de caja].ValorUnitaCaja, ([CantidadCaja] *[ValorUnitaCaja]) AS TolRecibo FROM[ACDATOXPSQL].[dbo].[Datos del Paciente] RIGHT JOIN([BDCAJASQL].[dbo].[Datos recibos de caja] " +
                        " INNER JOIN [BDCAJASQL].[dbo].[Datos detalles recibos de caja] ON[Datos recibos de caja].ReciboCaja = [Datos detalles recibos de caja].ReciboNum) " +
                        $" ON [Datos del Paciente].HistorPaci = [Datos recibos de caja].HistorPaciente WHERE {Utils.condicion} and  [Datos detalles recibos de caja].NatuMovi = 'C' AND [Datos recibos de caja].FechaPagoCaja >= CONVERT(DATETIME, '{Utils.FechaInicial}', 102) And  [Datos recibos de caja].FechaPagoCaja <= CONVERT(DATETIME, '{Utils.FechaFinal}', 102) AND [Datos recibos de caja].[AnuladoRecibo] = '{Utils.Anulado}'  ";

                        infoSql = Conexion.SQLDataSet(Utils.SqlDatos);
                        dsDetalle = new ReportDataSource("dsDetalle", infoSql.Tables[0]);
                        parameters = new ReportParameter[2];
                        parameters[0] = new ReportParameter("Fecha01", Utils.FechaInicial);
                        parameters[1] = new ReportParameter("Fecha02", Utils.FechaFinal);


                        break;
                    case "Informe de caja por regimen costos":

                        Utils.SqlDatos = "SELECT [Datos tipos de usuarios].NomTipo, [Datos recibos de caja].FechaPagoCaja, [Datos recibos de caja].AnuladoRecibo,  " +
                        " [Datos detalles recibos de caja].CentroCosto, [Datos centros de costo].NomCentro, Sum(([CantidadCaja] *[ValorUnitaCaja])) AS TotalR, " +
                        " [Datos detalles recibos de caja].NatuMovi, [Datos recibos de caja].RegRecibe FROM[ACDATOXPSQL].[dbo].[Datos tipos de usuarios] RIGHT JOIN " +
                        " ([ACDATOXPSQL].[dbo].[Datos centros de costo] RIGHT JOIN ([BDCAJASQL].[dbo].[Datos recibos de caja] INNER JOIN [BDCAJASQL].[dbo].[Datos detalles recibos de caja] ON " +
                        " [Datos recibos de caja].ReciboCaja = [Datos detalles recibos de caja].ReciboNum) ON[Datos centros de costo].CodiCentro = [Datos detalles recibos de caja].CentroCosto) ON " +
                        $" [Datos tipos de usuarios].CodTipoUsuar = [Datos recibos de caja].RegRecibe WHERE [Datos recibos de caja].FechaPagoCaja >= CONVERT(DATETIME, '{Utils.FechaInicial}', 102) And  [Datos recibos de caja].FechaPagoCaja <= CONVERT(DATETIME, '{Utils.FechaFinal}', 102) AND [Datos recibos de caja].[AnuladoRecibo] = '{Utils.Anulado}' GROUP BY[Datos tipos de usuarios].NomTipo, [Datos recibos de caja].FechaPagoCaja,  " +
                        " [Datos recibos de caja].AnuladoRecibo, [Datos detalles recibos de caja].CentroCosto, [Datos centros de costo].NomCentro, [Datos detalles recibos de caja].NatuMovi,  " +
                        " [Datos recibos de caja].RegRecibe HAVING ((([Datos detalles recibos de caja].NatuMovi) = 'C')); ";


                        infoSql = Conexion.SQLDataSet(Utils.SqlDatos);
                        dsDetalle = new ReportDataSource("dsDetalle", infoSql.Tables[0]);
                        parameters = new ReportParameter[2];
                        parameters[0] = new ReportParameter("Fecha01", Utils.FechaInicial);
                        parameters[1] = new ReportParameter("Fecha02", Utils.FechaFinal);


                        break;
                    case "Informe de caja por todos":

                        string TotalEfec = "", TotalTarjetas = "", TotalCheque = "", TotalBonos = "";

                        Utils.SqlDatos = "SELECT [Datos detalles recibos de caja].ReciboNum, (Trim([Nombre1] + ' ' + [Nombre2]) + ' ' + (Trim([Apellido1] + ' ' + [Apellido2]))) AS Paciente,  " +
                        " [Datos proveedores].RazonSol, Sum(([CantidadCaja] *[ValorUnitaCaja])) AS TolReci, [Datos recibos de caja].FechaPagoCaja, [Datos recibos de caja].CodRegis,  " +
                        " [Datos recibos de caja].AnuladoRecibo FROM [GEOGRAXPSQL].[dbo].[Datos proveedores] INNER JOIN(([ACDATOXPSQL].[dbo].[Datos del Paciente] RIGHT JOIN [BDCAJASQL].[dbo].[Datos recibos de caja] " +
                        " ON [Datos del Paciente].HistorPaci = [Datos recibos de caja].HistorPaciente) INNER JOIN[BDCAJASQL].[dbo].[Datos detalles recibos de caja] " +
                        " ON[Datos recibos de caja].ReciboCaja = [Datos detalles recibos de caja].ReciboNum) ON([Datos proveedores].TipoDocu = [Datos recibos de caja].TipoDocu) " +
                        " AND ([Datos proveedores].IdenProve = [Datos recibos de caja].NumDocu) AND([Datos proveedores].SucurProv = [Datos recibos de caja].SucuDocu) " +
                        $" WHERE [Datos recibos de caja].FechaPagoCaja >= CONVERT(DATETIME, '{Utils.FechaInicial}', 102) And  [Datos recibos de caja].FechaPagoCaja <= CONVERT(DATETIME, '{Utils.FechaFinal}', 102) AND [Datos recibos de caja].[AnuladoRecibo] = '{Utils.Anulado}'  " +
                        " GROUP BY [Datos detalles recibos de caja].ReciboNum, (Trim([Nombre1] + ' ' + [Nombre2]) + ' ' + (Trim([Apellido1] + ' ' + [Apellido2]))),  " +
                        " [Datos proveedores].RazonSol, [Datos recibos de caja].FechaPagoCaja, " +
                        " [Datos recibos de caja].CodRegis, [Datos recibos de caja].AnuladoRecibo;";

                        infoSql = Conexion.SQLDataSet(Utils.SqlDatos);
                        dsDetalle = new ReportDataSource("dsDetalle", infoSql.Tables[0]);
                        parameters = new ReportParameter[6];

                        TotalEfec = TotalPorFormaPago("EF", Utils.Anulado);
                        TotalTarjetas = TotalPorFormaPago("TC", Utils.Anulado);
                        TotalCheque = TotalPorFormaPago("CH", Utils.Anulado);
                        TotalBonos = TotalPorFormaPago("BO", Utils.Anulado);

                        parameters[0] = new ReportParameter("Fecha01", Utils.FechaInicial);
                        parameters[1] = new ReportParameter("Fecha02", Utils.FechaFinal);
                        parameters[2] = new ReportParameter("TotalEfec", TotalEfec);
                        parameters[3] = new ReportParameter("TotalTarjetas", TotalTarjetas);
                        parameters[4] = new ReportParameter("TotalCheque", TotalCheque);
                        parameters[5] = new ReportParameter("TotalBonos", TotalBonos);

                        break;
                    default:
                        break;

                }

      

                this.reportViewer1.LocalReport.DataSources.Clear();

                this.reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;

                this.reportViewer1.LocalReport.EnableExternalImages = true;

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
                Utils.Informa += "al abrir fomrulario de reportes" + "\r";
                Utils.Informa += "Error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
