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



        private string TotalPorFormaPagoUsa(string FP, int Anul, string CodRegis)
        {
            try
            {

                string Total = "";

                string sqlDatos = "SELECT[Datos recibos de caja].TipoPagoCaja, Sum(([CantidadCaja] *[ValorUnitaCaja])) AS TolRecib, [Datos recibos de caja].CodRegis " +
                                   " FROM[BDCAJASQL].[dbo].[Datos recibos de caja] INNER JOIN[BDCAJASQL].[dbo].[Datos detalles recibos de caja] ON[Datos recibos de caja].ReciboCaja = [Datos detalles recibos de caja].ReciboNum " +
                                   $" WHERE ((([Datos recibos de caja].FechaPagoCaja) >= CONVERT(DATETIME, '{Utils.FechaInicial}', 102) And ([Datos recibos de caja].FechaPagoCaja) <= CONVERT(DATETIME, '{Utils.FechaFinal}', 102) ) and " +
                                    " ([Datos recibos de caja].AnuladoRecibo) = " + Anul + ")  " +
                                   " GROUP BY[Datos recibos de caja].TipoPagoCaja, [Datos recibos de caja].CodRegis " +
                                   " HAVING((([Datos recibos de caja].TipoPagoCaja) =  '" + FP + "') AND " +
                                   " (([Datos recibos de caja].CodRegis) = '" + CodRegis + "'));";



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
                Utils.Informa += "en la funcion TotalPorFormaPagoUsa" + "\r";
                Utils.Informa += "Error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
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
                ReportDataSource dsPagare = null;
                ReportDataSource dsCuotas = null;
                ReportDataSource dsProveedores = null;
                ReportDataSource dsProveedoresCode = null;

                ReportParameter[] parameters = null;
                System.Data.DataSet infoSql;

                string TotalEfec = "", TotalTarjetas = "", TotalCheque = "", TotalBonos = "";

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
                    case "Informe recibos por digitadores":

                        Utils.SqlDatos = "SELECT [Datos detalles recibos de caja].ReciboNum, (RTrim([Nombre1] + ' ' + [Nombre2]) + ' ' + (RTrim([Apellido1] + ' ' + [Apellido2]))) AS Paciente," +
                        " [Datos proveedores].RazonSol, Sum(([CantidadCaja] *[ValorUnitaCaja])) AS TolReci, [Datos recibos de caja].FechaPagoCaja, [Datos recibos de caja].CodRegis," +
                        " [Datos recibos de caja].AnuladoRecibo, RTrim([NombreUsa] + ' ' + [Apellido1Usa] + ' ' + [Apellido2Usa]) AS Cajero, [Datos recibos de caja].TipoPago, [Datos recibos de caja].CodiAnul" +
                        " FROM [GEOGRAXPSQL].[dbo].[Datos proveedores] INNER JOIN(([DATUSIIGXPSQL].[dbo].[Datos usuarios de los aplicativos] RIGHT JOIN ([ACDATOXPSQL].[dbo].[Datos del Paciente] RIGHT JOIN [BDCAJASQL].[dbo].[Datos recibos de caja]" +
                        " ON [Datos del Paciente].HistorPaci = [Datos recibos de caja].HistorPaciente) ON[Datos usuarios de los aplicativos].CodigoUsa = [Datos recibos de caja].CodRegis) " +
                        " INNER JOIN[BDCAJASQL].[dbo].[Datos detalles recibos de caja] ON[Datos recibos de caja].ReciboCaja = [Datos detalles recibos de caja].ReciboNum) ON([Datos proveedores].TipoDocu = [Datos recibos de caja].TipoDocu)" +
                        " AND ([Datos proveedores].IdenProve = [Datos recibos de caja].NumDocu) AND([Datos proveedores].SucurProv = [Datos recibos de caja].SucuDocu)" +
                        $" WHERE [Datos recibos de caja].FechaPagoCaja >= CONVERT(DATETIME, '{Utils.FechaInicial}', 102) And  [Datos recibos de caja].FechaPagoCaja <= CONVERT(DATETIME, '{Utils.FechaFinal}', 102) AND [Datos recibos de caja].[AnuladoRecibo] = '{Utils.Anulado}' AND [Datos recibos de caja].[CodRegis] = '{Utils.CodRegis}'" +
                        " GROUP BY[Datos detalles recibos de caja].ReciboNum, " +
                        " (RTrim([Nombre1] + ' ' + [Nombre2]) + ' ' + (RTrim([Apellido1] + ' ' + [Apellido2]))), [Datos proveedores].RazonSol, [Datos recibos de caja].FechaPagoCaja, [Datos recibos de caja].CodRegis," +
                        " [Datos recibos de caja].AnuladoRecibo, RTrim([NombreUsa] + ' ' + [Apellido1Usa] + ' ' + [Apellido2Usa]), " +
                        " [Datos recibos de caja].TipoPago, [Datos recibos de caja].CodiAnul ORDER BY[Datos recibos de caja].FechaPagoCaja, [Datos recibos de caja].CodRegis;";

                        infoSql = Conexion.SQLDataSet(Utils.SqlDatos);
                        dsDetalle = new ReportDataSource("dsDetalle", infoSql.Tables[0]);
                        parameters = new ReportParameter[6];

                        TotalEfec = TotalPorFormaPagoUsa("EF", Utils.Anulado, Utils.CodRegis);
                        TotalTarjetas = TotalPorFormaPagoUsa("TC", Utils.Anulado, Utils.CodRegis);
                        TotalCheque = TotalPorFormaPagoUsa("CH", Utils.Anulado, Utils.CodRegis);
                        TotalBonos = TotalPorFormaPagoUsa("BO", Utils.Anulado, Utils.CodRegis);

                        parameters[0] = new ReportParameter("Fecha01", Utils.FechaInicial);
                        parameters[1] = new ReportParameter("Fecha02", Utils.FechaFinal);
                        parameters[2] = new ReportParameter("TotalEfec", TotalEfec);
                        parameters[3] = new ReportParameter("TotalTarjetas", TotalTarjetas);
                        parameters[4] = new ReportParameter("TotalCheque", TotalCheque);
                        parameters[5] = new ReportParameter("TotalBonos", TotalBonos);



                        break;

                    case "Informe recaudos por cuentas":

                        Utils.SqlDatos = "SELECT [Datos detalles recibos de caja].CuentaContable, [Datos ctas contables IPS].NomCConIPS, Sum(([CantidadCaja]*[ValorUnitaCaja])) AS TolReci,  " +
                        " [Datos recibos de caja].AnuladoRecibo, Sum([Datos detalles recibos de caja].DebiCaja) AS SumaDeDebiCaja FROM[GEOGRAXPSQL].[dbo].[Datos ctas contables IPS] " +
                        " INNER JOIN ([BDCAJASQL].[dbo].[Datos recibos de caja] INNER JOIN [BDCAJASQL].[dbo].[Datos detalles recibos de caja] ON[Datos recibos de caja].ReciboCaja = [Datos detalles recibos de caja].ReciboNum) " +
                        " ON [Datos ctas contables IPS].CueContaIPS = [Datos detalles recibos de caja].CuentaContable " +
                        $" WHERE [Datos recibos de caja].FechaPagoCaja >= CONVERT(DATETIME, '{Utils.FechaInicial}', 102) And  [Datos recibos de caja].FechaPagoCaja <= CONVERT(DATETIME, '{Utils.FechaFinal}', 102) AND [Datos recibos de caja].[AnuladoRecibo] = '{Utils.Anulado}' " +
                        " GROUP BY[Datos detalles recibos de caja].CuentaContable, [Datos ctas contables IPS].NomCConIPS, " +
                        " [Datos recibos de caja].AnuladoRecibo ORDER BY[Datos detalles recibos de caja].CuentaContable; ";
                        
                        infoSql = Conexion.SQLDataSet(Utils.SqlDatos);
                        dsDetalle = new ReportDataSource("dsDetalle", infoSql.Tables[0]);

                        parameters = new ReportParameter[2];

                        parameters[0] = new ReportParameter("Fecha01", Utils.FechaInicial);
                        parameters[1] = new ReportParameter("Fecha02", Utils.FechaFinal);


                        break;
                    case "Informe recibos por servicios":

                        Utils.SqlDatos = "SELECT [Datos detalles recibos de caja].ReciboNum, [Datos proveedores].RazonSol, Sum(([CantidadCaja]*[ValorUnitaCaja])) AS TolReci, " +
                        " [Datos recibos de caja].FechaPagoCaja, [Datos recibos de caja].AnuladoRecibo, [Datos detalles recibos de caja].CodServi,  " +
                        " [Datos catalogo de servicios].NomServicio FROM[GEOGRAXPSQL].[dbo].[Datos proveedores] RIGHT JOIN([ACDATOXPSQL].[dbo].[Datos catalogo de servicios] " +
                        " INNER JOIN ([BDCAJASQL].[dbo].[Datos recibos de caja] INNER JOIN [BDCAJASQL].[dbo].[Datos detalles recibos de caja] ON[Datos recibos de caja].ReciboCaja = [Datos detalles recibos de caja].ReciboNum) " +
                        " ON [Datos catalogo de servicios].CodInterno = [Datos detalles recibos de caja].CodServi) ON([Datos proveedores].TipoDocu = [Datos recibos de caja].TipoDocu)  " +
                        " AND ([Datos proveedores].IdenProve = [Datos recibos de caja].NumDocu) AND([Datos proveedores].SucurProv = [Datos recibos de caja].SucuDocu) " +
                        $" WHERE [Datos recibos de caja].FechaPagoCaja >= CONVERT(DATETIME, '{Utils.FechaInicial}', 102) And  [Datos recibos de caja].FechaPagoCaja <= CONVERT(DATETIME, '{Utils.FechaFinal}', 102) AND [Datos recibos de caja].[AnuladoRecibo] = '{Utils.Anulado}' AND [Datos detalles recibos de caja].CodServi ='{Utils.CodiServi}'   " +
                        " GROUP BY[Datos detalles recibos de caja].ReciboNum, [Datos proveedores].RazonSol, [Datos recibos de caja].FechaPagoCaja, [Datos recibos de caja].AnuladoRecibo, " +
                        " [Datos detalles recibos de caja].CodServi, [Datos catalogo de servicios].NomServicio; ";

                        infoSql = Conexion.SQLDataSet(Utils.SqlDatos);
                        dsDetalle = new ReportDataSource("dsDetalle", infoSql.Tables[0]);

                        parameters = new ReportParameter[2];

                        parameters[0] = new ReportParameter("Fecha01", Utils.FechaInicial);
                        parameters[1] = new ReportParameter("Fecha02", Utils.FechaFinal);


                        break;
                    case "Informe resumen caja":


                        Utils.SqlDatos = "SELECT [Datos detalles recibos de caja].CuentaContable, [Datos ctas contables IPS].NomCConIPS, " +
                        " [Datos detalles recibos de caja].CentroCosto, [Datos centros de costo].NomCentro, [Datos detalles recibos de caja].CodServi, " +
                        " [Datos catalogo de servicios].NomServicio, Sum(([CantidadCaja] *[ValorUnitaCaja])) AS TolCaja, Sum([Datos detalles recibos de caja].DebiCaja) AS SumaDeDebiCaja, " +
                        " [Datos recibos de caja].AnuladoRecibo, [Datos recibos de caja].CodRegis, RTrim([NombreUsa] + ' ' + [Apellido1Usa] + ' ' + [Apellido2Usa]) AS Digitador, " +
                        " [Datos recibos de caja].CodiAnul FROM[GEOGRAXPSQL].[dbo].[Datos ctas contables IPS] INNER JOIN([DATUSIIGXPSQL].[dbo].[Datos usuarios de los aplicativos] " +
                        " INNER JOIN ([BDCAJASQL].[dbo].[Datos recibos de caja] INNER JOIN ([ACDATOXPSQL].[dbo].[Datos catalogo de servicios] RIGHT JOIN ([ACDATOXPSQL].[dbo].[Datos centros de costo] " +
                        " INNER JOIN [BDCAJASQL].[dbo].[Datos detalles recibos de caja] ON[Datos centros de costo].CodiCentro = [Datos detalles recibos de caja].CentroCosto) " +
                        " ON[Datos catalogo de servicios].CodInterno = [Datos detalles recibos de caja].CodServi) ON[Datos recibos de caja].ReciboCaja = [Datos detalles recibos de caja].ReciboNum) " +
                        " ON[Datos usuarios de los aplicativos].CodigoUsa = [Datos recibos de caja].CodRegis) ON[Datos ctas contables IPS].CueContaIPS = [Datos detalles recibos de caja].CuentaContable " +
                        $" WHERE [Datos recibos de caja].FechaPagoCaja >= CONVERT(DATETIME, '{Utils.FechaInicial}', 102) And  [Datos recibos de caja].FechaPagoCaja <= CONVERT(DATETIME, '{Utils.FechaFinal}', 102) AND [Datos recibos de caja].[AnuladoRecibo] = '{Utils.Anulado}' AND [Datos recibos de caja].[CodRegis] = '{Utils.CodRegis}'  " +
                        " GROUP BY[Datos detalles recibos de caja].CuentaContable, " +
                        " [Datos ctas contables IPS].NomCConIPS, [Datos detalles recibos de caja].CentroCosto, [Datos centros de costo].NomCentro, [Datos detalles recibos de caja].CodServi, " +
                        " [Datos catalogo de servicios].NomServicio, [Datos recibos de caja].AnuladoRecibo, " +
                        " [Datos recibos de caja].CodRegis, RTrim([NombreUsa] + ' ' + [Apellido1Usa] + ' ' + [Apellido2Usa]), [Datos recibos de caja].CodiAnul; ";

                        infoSql = Conexion.SQLDataSet(Utils.SqlDatos);
                        dsDetalle = new ReportDataSource("dsDetalle", infoSql.Tables[0]);

                        parameters = new ReportParameter[2];

                        parameters[0] = new ReportParameter("Fecha01", Utils.FechaInicial);
                        parameters[1] = new ReportParameter("Fecha02", Utils.FechaFinal);

                        break;
                    case "Formato de los pagares":

                        string TDR = "", NDR = "", SCR = "", TDC = "", NDC = "", SCC = "", SumLetPaga = "", CodRegisPa = "", SqlDigitador = "";
                        decimal ValTolPaga = 0, ValCuota = 0;
                        int NoCodeu = 0;
                        parameters = new ReportParameter[12];


                        Utils.SqlDatos = "SELECT * FROM  [BDCAJASQL].[dbo].[Datos registro de pagares] WHERE NumPaga = '"+ Utils.NumPagaGlo + "'";

                        infoSql = Conexion.SQLDataSet(Utils.SqlDatos);
                        dsPagare = new ReportDataSource("dsPagare", infoSql.Tables[0]);


                        using (SqlConnection connection = new SqlConnection(Conexion.conexionSQL))
                        {
                            SqlCommand command = new SqlCommand(Utils.SqlDatos, connection);
                            command.Connection.Open();
                            SqlDataReader TabRegPaga = command.ExecuteReader();

                            if (TabRegPaga.HasRows == false)
                            {
                                Utils.Titulo01 = "Contro de ejecución";
                                Utils.Informa = "Lo siento pero el número del pagaré digitado no" + "\r";
                                Utils.Informa += "se encuentra registrado en estee sistema, por lo" + "\r";
                                Utils.Informa += "tanto no se puede mostrar el formato." + "\r";
                                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            else
                            {
                                TabRegPaga.Read();
                                TDR = TabRegPaga["TDRespon"].ToString();
                                NDR = TabRegPaga["NumTerPaga"].ToString();
                                SCR = TabRegPaga["SucRespon"].ToString();

                                CodRegisPa = TabRegPaga["CodRegis"].ToString();

                                ValTolPaga = Convert.ToDecimal(TabRegPaga["ValorPaga"].ToString());
                                SumLetPaga = Conversores.NumeroALetras(ValTolPaga);

                                parameters[0] = new ReportParameter("SumLetPaga", SumLetPaga);

                                parameters[1] = new ReportParameter("ValCuoP", "");
                                parameters[2] = new ReportParameter("Fec1", "");
                                parameters[3] = new ReportParameter("FecCuota1", "");
                                parameters[4] = new ReportParameter("ValCuota1", "");
                                parameters[5] = new ReportParameter("Fec2", "");
                                parameters[6] = new ReportParameter("ValCuota2", "");
                                parameters[7] = new ReportParameter("Fec3", "");
                                parameters[8] = new ReportParameter("ValCuota3", "");
                                parameters[9] = new ReportParameter("Fec4", "");
                                parameters[10] = new ReportParameter("ValCuota4","");
                                parameters[11] = new ReportParameter("NomCajero", "");

                                if (!string.IsNullOrWhiteSpace(TabRegPaga["TDCodeudor"].ToString()) && !string.IsNullOrWhiteSpace(TabRegPaga["CodeuPaga"].ToString()) && !string.IsNullOrWhiteSpace(TabRegPaga["SucCodeu"].ToString()))
                                {
                                    TDC = TabRegPaga["TDCodeudor"].ToString();
                                    NDC = TabRegPaga["CodeuPaga"].ToString();
                                    SCC = TabRegPaga["SucCodeu"].ToString();
                                    NoCodeu = 1;
                                }
                                else
                                {
                                    NoCodeu = 0;
                                }

                                Utils.SqlDatos = "SELECT * FROM  [BDCAJASQL].[dbo].[Datos registro cuotas pagares]  WHERE NumPaga = '" + Utils.NumPagaGlo + "'";

                                infoSql = Conexion.SQLDataSet(Utils.SqlDatos);
                                dsCuotas = new ReportDataSource("dsCuotas", infoSql.Tables[0]);

                                using (SqlConnection connection2 = new SqlConnection(Conexion.conexionSQL))
                                {
                                    SqlCommand command2 = new SqlCommand(Utils.SqlDatos, connection2);
                                    command2.Connection.Open();
                                    SqlDataReader TabCuoPaga = command2.ExecuteReader();

                                    if (TabCuoPaga.HasRows)
                                    {
                                        while (TabCuoPaga.Read())
                                        {
                                            switch (TabCuoPaga["CuoPaga"].ToString())
                                            {
                                                case "1":

                                                    ValCuota = Convert.ToDecimal(TabCuoPaga["ValCuota"]);

                                                    parameters[1] = new ReportParameter("ValCuoP", TabCuoPaga["ValCuota"].ToString());
                                                    parameters[2] = new ReportParameter("Fec1", TabCuoPaga["FecVenCuota"].ToString());
                                                    parameters[3] = new ReportParameter("FecCuota1", TabCuoPaga["FecVenCuota"].ToString());
                                                    parameters[4] = new ReportParameter("ValCuota1", Conversores.NumeroALetras(ValCuota));

                                                    break;
                                                case "2":

                                                    ValCuota = Convert.ToDecimal(TabCuoPaga["ValCuota"]);
                                                    parameters[5] = new ReportParameter("Fec2", TabCuoPaga["FecVenCuota"].ToString());
                                                    parameters[6] = new ReportParameter("ValCuota2", Conversores.NumeroALetras(ValCuota));


                                                    break;
                                                case "3":

                                                    ValCuota = Convert.ToDecimal(TabCuoPaga["ValCuota"]);
                                                    parameters[7] = new ReportParameter("Fec3", TabCuoPaga["FecVenCuota"].ToString());
                                                    parameters[8] = new ReportParameter("ValCuota3", Conversores.NumeroALetras(ValCuota));

                                                    break;
                                                case "4":

                                                    ValCuota = Convert.ToDecimal(TabCuoPaga["ValCuota"]);
                                                    parameters[9] = new ReportParameter("Fec4", TabCuoPaga["FecVenCuota"].ToString());
                                                    parameters[10] = new ReportParameter("ValCuota4", Conversores.NumeroALetras(ValCuota));

                                                    break;
                                            }
                                        }
                                    }
                                }

                                Utils.SqlDatos = "SELECT RazonSol, SucurProv, TipoDocu, DireProve, CityProve, DptoProve, TelProve1 " +
                                " FROM[GEOGRAXPSQL].[dbo].[Datos proveedores] " +
                                " WHERE TipoDocu = '" + TDR + "' AND IdenProve = '" + NDR + "' AND SucurProv = '" + SCR + "' " +
                                " ORDER BY TipoDocu, IdenProve, SucurProv ";

                                infoSql = Conexion.SQLDataSet(Utils.SqlDatos);
                                dsProveedores = new ReportDataSource("dsProveedores", infoSql.Tables[0]);

                                if(NoCodeu == 1)
                                {

                                }

                                Utils.SqlDatos = "SELECT RazonSol, SucurProv, TipoDocu, DireProve, CityProve, DptoProve, TelProve1 " +
                                " FROM [GEOGRAXPSQL].[dbo].[Datos proveedores] " +
                                " WHERE TipoDocu = '" + TDC + "' AND IdenProve = '" + NDC + "' AND SucurProv = '" + SCC + "' " +
                                " ORDER BY TipoDocu, IdenProve, SucurProv ";

                                infoSql = Conexion.SQLDataSet(Utils.SqlDatos);

                                dsProveedoresCode = new ReportDataSource("dsProveedoresCode", infoSql.Tables[0]);

                               


                                SqlDigitador = "SELECT CodigoUsa, TipoDocUsa, IdentificUsa, NombreUsa, Apellido1Usa, Apellido2Usa ";
                                SqlDigitador += "FROM [DATUSIIGXPSQL].[dbo].[Datos usuarios de los aplicativos]";
                                SqlDigitador += "WHERE CodigoUsa = '" + CodRegisPa + "'";


                                using (SqlConnection connection3 = new SqlConnection(Conexion.conexionSQL))
                                {
                                    SqlCommand command3 = new SqlCommand(SqlDigitador, connection3);
                                    command3.Connection.Open();
                                    SqlDataReader TabDigitador = command3.ExecuteReader();

                                    if (TabDigitador.HasRows)
                                    {
                                        TabDigitador.Read();

                                        string NomCajero = TabDigitador["NombreUsa"].ToString() + " " + TabDigitador["Apellido1Usa"].ToString() + " " + TabDigitador["Apellido2Usa"].ToString();

                                        parameters[11] = new ReportParameter("NomCajero", NomCajero);
                                    }
                                    else
                                    {
                                        parameters[11] = new ReportParameter("NomCajero", "USUARIO DIGITADOR NO REGISTRADO");
                                    }

                                }      
                            }
                        }
                            break;
                    default:
                        break;

                }

                //TODO LOS DATA SET NO SE ESTAN ENVIANDO TODOS

                this.reportViewer1.LocalReport.DataSources.Clear();

                this.reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;

                this.reportViewer1.LocalReport.EnableExternalImages = true;

                this.reportViewer1.LocalReport.DataSources.Add(dsEmpresa);
      
         
                if (Utils.infNombreInforme == "Formato de los pagares")
                {
                    this.reportViewer1.LocalReport.DataSources.Add(dsPagare);
                    this.reportViewer1.LocalReport.DataSources.Add(dsCuotas);
                    this.reportViewer1.LocalReport.DataSources.Add(dsProveedores);
                    this.reportViewer1.LocalReport.DataSources.Add(dsProveedoresCode);
                }
                else
                {
                    this.reportViewer1.LocalReport.DataSources.Add(dsDetalle);
                }

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
