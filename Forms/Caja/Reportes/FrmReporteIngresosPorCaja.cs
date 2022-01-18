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

namespace OBCAJASQL.Forms.Caja.Reportes
{
    public partial class FrmReporteIngresosPorCaja : Form
    {
        public FrmReporteIngresosPorCaja()
        {
            InitializeComponent();
        }

         
        #region RadioButton

        private void RdUsuarios_CheckedChanged(object sender, EventArgs e)
        {
            MarRecibosPor = 1;
        }

        private void RdEntidades_CheckedChanged(object sender, EventArgs e)
        {
            MarRecibosPor = 2;
        }

        private void RdRegimen_CheckedChanged(object sender, EventArgs e)
        {
            MarRecibosPor = 3;
        }

        private void RdPacientes_CheckedChanged(object sender, EventArgs e)
        {
            MarRecibosPor = 4;
        }

        private void RdTodos_CheckedChanged(object sender, EventArgs e)
        {
            MarRecibosPor = 6;
        }

        private void RdRegimenCosto_CheckedChanged(object sender, EventArgs e)
        {
            MarRecibosPor = 5;
        }

        private void RdValidados_CheckedChanged(object sender, EventArgs e)
        {
            MarVigenAnul = 1;
        }

        private void RdAnulados_CheckedChanged(object sender, EventArgs e)
        {
            MarVigenAnul = 2;
        }
        #endregion


        int MarRecibosPor = 1;
        int MarVigenAnul = 1;
        private void FrmReporteIngresosPorCaja_Load(object sender, EventArgs e)
        {

        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void BtnMostrar_Click(object sender, EventArgs e)
        {
            try
            {
                Utils.Titulo01 = "Control para mostrar recibos de caja";

                //Proceda a grabar el rango de fechas
                string Para03 = "", Para04 = "", HisMues = "", Para06 = "";

                string F01 = Convert.ToString(DtFecInicial.Value.ToString("yyyy-MM-dd"));
                string F0F = Convert.ToString(DtFecFinal.Value.ToString("yyyy-MM-dd"));

                Utils.FechaInicial = F01;
                Utils.FechaFinal = F0F;
                Utils.Anulado = 0;


                switch (MarVigenAnul)
                {
                    case 1: //Validos

                        Para03 = "[BDCAJASQL].[dbo].[Datos recibos de caja].[AnuladoRecibo] = 0";
                        Utils.Anulado = 0;
                        break;
                    case 2://Anulados

                        Para03 = "[BDCAJASQL].[dbo].[Datos recibos de caja].[AnuladoRecibo] = 1";
                        Utils.Anulado = 1;
                        break;
                    default:
                        break;
                }

                //Cual informe expide
                FrmReportes frmReportes = new FrmReportes();

                switch (MarRecibosPor)
                {
                    case 1: //Por usuarios


                        Utils.infNombreInforme = "Informe de caja por usuarios";
                                        
                        frmReportes.ShowDialog();                

                        break;
                    case 2: //Por Entidades


                        Utils.infNombreInforme = "Informe de caja por entidades";

                        frmReportes.ShowDialog();


                        break;
                    case 3: //Por Regimen


                        Utils.infNombreInforme = "Informe de caja por regimen";
                        frmReportes.ShowDialog();


                        break;
                    case 4: //Por Pacientes

                        Utils.TextoInputBox = "Digite por favor el número de historia del paciente";

                        FrmInputBox frmInputBox = new FrmInputBox();
                        frmInputBox.ShowDialog();

                        HisMues = Utils.ValueInput;

                      
                        Para06 = "[BDCAJASQL].[dbo].[Datos recibos de caja].[HistorPaciente] = '" + HisMues + "'";

                        Utils.condicion = Para06;

                        Utils.infNombreInforme = "Informe de caja por pacientes";

                        frmReportes.ShowDialog();


                        break;
                    case 5: //Por regimen y por centro de costo

                        Utils.infNombreInforme = "Informe de caja por regimen costos";

                        frmReportes.ShowDialog();


                        break;
                    case 6: //Mostrar todos los recibos

                        Utils.infNombreInforme = "Informe de caja por todos";

                        frmReportes.ShowDialog();

                        break;

                    default:
                        break;
                }








            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "al presionar el boton mostrar" + "\r";
                Utils.Informa += "Error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
