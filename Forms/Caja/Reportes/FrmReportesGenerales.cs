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

namespace OBCAJASQL.Forms.Caja.Reportes
{
    public partial class FrmReportesGenerales : Form
    {
        public FrmReportesGenerales()
        {
            InitializeComponent();
        }


        #region radioButton


        private void RdDigitadoresRecibos_CheckedChanged(object sender, EventArgs e)
        {
            MarInfo = 1;
            CboDigiNom.Visible = true;
            LblDigitador.Visible = true;
            CboNomServi.Visible = false;
            LblNombreDelServicio.Visible = false;
        }

        private void RdCuentasContables_CheckedChanged(object sender, EventArgs e)
        {
            MarInfo = 2;
            CboDigiNom.Visible = false;
            LblDigitador.Visible = false;
            CboNomServi.Visible = false;
            LblNombreDelServicio.Visible = false;
        }

        private void RdServicios_CheckedChanged(object sender, EventArgs e)
        {
            MarInfo = 3;
            CboDigiNom.Visible = false;
            LblDigitador.Visible = false;
            CboNomServi.Visible = true;
            LblNombreDelServicio.Visible = true;
        }

        private void RdResume_CheckedChanged(object sender, EventArgs e)
        {
            MarInfo = 4;
            CboDigiNom.Visible = true;
            LblDigitador.Visible = true;
            CboNomServi.Visible = false;
            LblNombreDelServicio.Visible = false;
        }

        private void CboDigiNom_KeyPress(object sender, KeyPressEventArgs e)
        {
            CboDigiNom.DroppedDown = false;
        }

        private void CboNomServi_KeyPress(object sender, KeyPressEventArgs e)
        {
            CboNomServi.DroppedDown = false;
        }

        private void RdValidados_CheckedChanged(object sender, EventArgs e)
        {
            MarVigenAnul = 1;
        }

        private void RdAnulados_CheckedChanged(object sender, EventArgs e)
        {
            MarVigenAnul = 0;
        }

        #endregion

        private void CargarComboBox()
        {
            try
            {
                this.CboDigiNom.DataSource = null;
                this.CboDigiNom.Items.Clear();


                Utils.SqlDatos = "SELECT [Datos usuarios de los aplicativos].CodigoUsa, Trim([NombreUsa] + ' ' + [Apellido1Usa] + ' ' + [Apellido2Usa]) AS NomUsar, " +
                                " [Datos usuarios de los aplicativos].CodiDepen, [Datos usuarios de los aplicativos].DepenUsar " +
                                " FROM [DATUSIIGXPSQL].[dbo].[Datos usuarios de los aplicativos] ORDER BY Trim([NombreUsa] + ' ' + [Apellido1Usa] + ' ' + [Apellido2Usa]); ";

                DataSet dataSet = Conexion.SQLDataSet(Utils.SqlDatos);

                if (dataSet != null && dataSet.Tables.Count > 0)
                {
                    this.CboDigiNom.DataSource = dataSet.Tables[0];
                    this.CboDigiNom.ValueMember = "CodigoUsa";
                    this.CboDigiNom.DisplayMember = "NomUsar";
                }

                Utils.SqlDatos = "SELECT [Datos catalogo de servicios].CodInterno, [Datos catalogo de servicios].NomServicio,  " +
                                " [Datos catalogo de servicios].GrupoServi " +
                                " FROM [ACDATOXPSQL].[dbo].[Datos catalogo de servicios] " +
                                " WHERE ((([Datos catalogo de servicios].GrupoServi) = '99')) " +
                                " ORDER BY [Datos catalogo de servicios].NomServicio; ";

                DataSet dataSet2 = Conexion.SQLDataSet(Utils.SqlDatos);

                if (dataSet2 != null && dataSet2.Tables.Count > 0)
                {
                    this.CboNomServi.DataSource = dataSet2.Tables[0];
                    this.CboNomServi.ValueMember = "CodInterno";
                    this.CboNomServi.DisplayMember = "NomServicio";
                }



            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "en la funcion CargarComboBox" + "\r";
                Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
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


                    LblCodCajAct.Text = Utils.CodCaja;
                    LblNomCajAct.Text = Utils.NombgPre;

   


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

        int MarInfo = 1;
        int MarVigenAnul = 1;

        private void FrmReportesGenerales_Load(object sender, EventArgs e)
        {
            try
            {
                CargarDatosUser();
                CargarComboBox();
            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "al abrir formulario de reporte genelares" + "\r";
                Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void BtnMostrar_Click(object sender, EventArgs e)
        {
            try
            {

                Utils.SqlDatos = "Control para mostrar datos";


                if (string.IsNullOrWhiteSpace(LblCodCajAct.Text))
                {
                    Utils.Informa = "Lo siento pero mientras no se tenga";
                    Utils.Informa += "definida la identificación de la caja,";
                    Utils.Informa += "no se puede realizar este proceso.";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                





            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "despues de hacer click en mostrar" + "\r";
                Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
