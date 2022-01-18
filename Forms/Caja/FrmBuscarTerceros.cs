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
    public partial class FrmBuscarTerceros : Form
    {
        public FrmBuscarTerceros()
        {
            InitializeComponent();
        }


        #region radioButon


        private void RbDocu_CheckedChanged(object sender, EventArgs e)
        {


            CboTpDoc.SelectedValue = "CC";
            TxtNitCCBuscar.Clear();
            TxtCompletoBuscar.Clear();
            TxtPrimerasBuscar.Clear();
            TxtCualquierBuscar.Clear();

            CboTpDoc.Visible = true;
            TxtNitCCBuscar.Visible = true;
            TxtSucuTer.Visible = true;

            TxtCompletoBuscar.Visible = false;
            TxtPrimerasBuscar.Visible = false;
            TxtCualquierBuscar.Visible = false;

            ParaBusTercero = 2;
        }

        private void RbName_CheckedChanged(object sender, EventArgs e)
        {

            TxtNitCCBuscar.Clear();
            TxtCompletoBuscar.Clear();
            TxtPrimerasBuscar.Clear();
            TxtCualquierBuscar.Clear();

            TxtSucuTer.Text = "000";

            CboTpDoc.Visible = false;
            TxtNitCCBuscar.Visible = false;
            TxtSucuTer.Visible = false;



            TxtCompletoBuscar.Visible = true;
            TxtCompletoBuscar.Select();

            TxtPrimerasBuscar.Visible = false;
            TxtCualquierBuscar.Visible = false;

            ParaBusTercero = 3;
        }

        private void RbPrimeName_CheckedChanged(object sender, EventArgs e)
        {
            TxtNitCCBuscar.Clear();
            TxtCompletoBuscar.Clear();
            TxtPrimerasBuscar.Clear();
            TxtCualquierBuscar.Clear();

            TxtSucuTer.Text = "000";

            CboTpDoc.Visible = false;
            TxtNitCCBuscar.Visible = false;
            TxtSucuTer.Visible = false;



            TxtCompletoBuscar.Visible = false;

            TxtPrimerasBuscar.Visible = true;
            TxtCualquierBuscar.Visible = false;

            TxtPrimerasBuscar.Select();

            ParaBusTercero = 4;
        }

        private void RbCualquier_CheckedChanged(object sender, EventArgs e)
        {

            TxtNitCCBuscar.Clear();
            TxtCompletoBuscar.Clear();
            TxtPrimerasBuscar.Clear();
            TxtCualquierBuscar.Clear();

            TxtSucuTer.Text = "000";

            CboTpDoc.Visible = false;
            TxtNitCCBuscar.Visible = false;
            TxtSucuTer.Visible = false;



            TxtCompletoBuscar.Visible = false;

            TxtPrimerasBuscar.Visible = false;
            TxtCualquierBuscar.Visible = true;

            TxtCualquierBuscar.Select();

            ParaBusTercero = 5;
        }


        #endregion

        #region Funciones
        private void CargarCombos()
        {
            try
            {
                this.CboTpDoc.DataSource = null;
                this.CboTpDoc.Items.Clear();


                Utils.SqlDatos = "SELECT [Datos tipos de documentos].CodIdenti, [Datos tipos de documentos].NomIdenti " +
                                " FROM [BDCAJASQL].[dbo].[Datos tipos de documentos] ORDER BY [Datos tipos de documentos].CodIdenti";

                DataSet dataSet = Conexion.SQLDataSet(Utils.SqlDatos);

                if (dataSet != null && dataSet.Tables.Count > 0)
                {
                    this.CboTpDoc.DataSource = dataSet.Tables[0];
                    this.CboTpDoc.ValueMember = "CodIdenti";
                    this.CboTpDoc.DisplayMember = "NomIdenti";
                }
            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "en la funcion CargarCombos" + "\r";
                Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Botones
            private void BtnSalir_Click(object sender, EventArgs e)
            {
                this.Dispose();
            }
        #endregion


        int ParaBusTercero = 1;
        private void FrmBuscarTerceros_Load(object sender, EventArgs e)
        {
            try
            {
                CargarCombos();

            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "al abrir el formulario buscar a teceros" + "\r";
                Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void BtnMostrarTer_Click(object sender, EventArgs e)
        {
            try
            {

                string Para01 = "", Para02 = "", Para03 = "", Para04 = "", SqlDatos = "";


                SqlDatos = SqlDatos + "SELECT [Datos proveedores].TipoDocu, [Datos proveedores].IdenProve,  ";
                SqlDatos = SqlDatos + "[Datos proveedores].SucurProv, [Datos proveedores].RazonSol ";
                SqlDatos = SqlDatos + "FROM  [GEOGRAXPSQL].[dbo].[Datos proveedores] ";

                Utils.Titulo01 = "Control de ejecución";

                switch (ParaBusTercero)
                {
                    case 1: //Muestra por el cardinal

                        break;
                    case 2: //Por nit o por cc

                        if (string.IsNullOrWhiteSpace(TxtNitCCBuscar.Text))
                        {
                            Utils.Informa = "o siento pero usted aún no ha digitado el número del Nit o CC del tercero a buscar";
                            MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            Para01 = TxtNitCCBuscar.Text;
                            Para03 = CboTpDoc.SelectedValue.ToString();
                            Para04 = TxtSucuTer.Text;

                            Utils.Informa = "¿Usted desea mostrar el terceros que identificado con el documento " + Para03 + ":" + Para01 + ".?";

                            Para02 = Para01;

                            SqlDatos += "WHERE [GEOGRAXPSQL].[dbo].[Datos proveedores].IdenProve = '" + Para02 + "' AND [GEOGRAXPSQL].[dbo].[Datos proveedores].TipoDocu = '" + Para03 + "' AND [GEOGRAXPSQL].[dbo].[Datos proveedores].SucurProv = '" + Para04 + "'";
                        }

                        break;
                    case 3: //Pro nombre completo

                        if (string.IsNullOrWhiteSpace(TxtCompletoBuscar.Text))
                        {
                            Utils.Informa = "Lo siento pero usted aún no ha digitado el nombre completo del tercero a buscar";
                            MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            Para01 = TxtCompletoBuscar.Text;

                            Utils.Informa = "¿Usted desea mostrar el terceros que tengan el nombre completo " + Para01 + ".?";

                            Para02 = Para01;

                            SqlDatos += "WHERE [GEOGRAXPSQL].[dbo].[Datos proveedores].RazonSol = '" + Para02 + "' ";

                        }


                        break;
                    case 4://Primetas letras del nombre

                        if (string.IsNullOrWhiteSpace(TxtPrimerasBuscar.Text))
                        {
                            Utils.Informa = "Lo siento pero usted aún no ha digitado las primeras letras del nombre del tercero a buscar";
                            return;
                        }
                        else
                        {
                            Para01 = TxtPrimerasBuscar.Text;
                            Utils.Informa = "¿Usted desea mostrar todos los terceros que cuyo nombre empiece por " + Para01 + ".?";
                            Para02 = Para01;
                            SqlDatos += "WHERE [GEOGRAXPSQL].[dbo].[Datos proveedores].RazonSol Like '" + Para02 + "%' ";
                        }


                        break;
                    case 5://Cualquier parte del nombre


                        if (string.IsNullOrWhiteSpace(TxtCualquierBuscar.Text))
                        {
                            Utils.Informa = "Lo siento pero usted aún no ha digitado parte del nombre del tercero a buscar";
                            return;
                        }
                        else
                        {
                            Para01 = TxtCualquierBuscar.Text;
                            Utils.Informa = "¿Usted desea mostrar todos los terceros que tengan incluido en el nombre la palabra " + Para01 + ".?";
                            Para02 = Para01;
                            SqlDatos += "WHERE [GEOGRAXPSQL].[dbo].[Datos proveedores].RazonSol Like '%" + Para02 + "%' ";
                        }
                        break;
                    default:
                        break;


                }

                var res = MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if(res == DialogResult.Yes)
                {

                    DataSet dataSet = Conexion.SQLDataSet(SqlDatos);

                    if (dataSet.Tables[0].Rows.Count == 0)
                    {
                        Utils.Titulo01 = "Control de ejecución";
                        Utils.Informa = "Lo siento pero se ha encontrado ningún tercero con los datos que ingreso" + "\r";
                        MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        DgListaTercerosEncontrados.DataSource = dataSet.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "al dar click en mostrar" + "\r";
                Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEligeTercero_Click(object sender, EventArgs e)
        {
            try
            {
                string Form01 = "", Sucur = "", Form02 = "", Form03 = "", NitCC = "", NumD01 = "", NomTer = "", Cardi01 = "", CenCue01 = "";

                Form01 = "Formulario caja ingresos generales";
                Form02 = "ario caja pagos a facturas";
                Form03 = "Formulario gestion terceros";

                if(DgListaTercerosEncontrados.SelectedRows.Count > 0)
                {
                    NitCC = DgListaTercerosEncontrados.SelectedCells[0].Value.ToString();   
                    NumD01 = DgListaTercerosEncontrados.SelectedCells[1].Value.ToString();
                    Sucur = DgListaTercerosEncontrados.SelectedCells[2].Value.ToString();
                }


                if (string.IsNullOrWhiteSpace(NitCC))
                {
                    Utils.Informa = "Primeramente se debe seleccionar un TERCERO de la lista" + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                if (string.IsNullOrWhiteSpace(NumD01))
                {
                    Utils.Informa = "Primeramente se debe seleccionar un TERCERO de la lista" + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

              

                Utils.TipDocFac = NitCC;
                Utils.NitCC = NumD01;
                Utils.SucurTer = Sucur;

                this.Dispose();

            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "al dar click en elegir" + "\r";
                Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
