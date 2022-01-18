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
namespace OBCAJASQL.Forms.Caja
{
    public partial class FrmBuscarPacientes : Form
    {
        public FrmBuscarPacientes()
        {
            InitializeComponent();
        }

        #region Funciones
        private void CargarCombos()
        {
            try
            {
                this.CboTiposDocu.DataSource = null;
                this.CboTiposDocu.Items.Clear();


                Utils.SqlDatos = "SELECT [Datos tipos de documentos].CodIdenti, [Datos tipos de documentos].NomIdenti " +
                                " FROM [BDCAJASQL].[dbo].[Datos tipos de documentos] ORDER BY [Datos tipos de documentos].CodIdenti";

                DataSet dataSet = Conexion.SQLDataSet(Utils.SqlDatos);

                if (dataSet != null && dataSet.Tables.Count > 0)
                {
                    this.CboTiposDocu.DataSource = dataSet.Tables[0];
                    this.CboTiposDocu.ValueMember = "CodIdenti";
                    this.CboTiposDocu.DisplayMember = "NomIdenti";
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


        private void BtnMostrarTer_Click(object sender, EventArgs e)
        {
            try
            {
                int CuantosCriterios = 0, ActivarCasi = 0;
                string DoIden = "", TipDocm = "", NomPa = "", NomPa2 = "", Apel1 = "", Apel2 = "", SqlDatos = "", ParaWhere = "";

                Utils.Titulo01 = "Control para iniciar busqueda";

                //Verificar que por lo menos se haya digitado alguna de las variables de criterios

                if (string.IsNullOrWhiteSpace(TxtDocumentoIden.Text) == false)
                {
                    DoIden = TxtDocumentoIden.Text;
                    TipDocm = CboTiposDocu.SelectedValue.ToString();
                    CuantosCriterios += 1;
                }

                if (string.IsNullOrWhiteSpace(TxtNombresP.Text) == false)
                {
                    NomPa = TxtNombresP.Text;
                    CuantosCriterios += 1;
                }

                if (string.IsNullOrWhiteSpace(TxtNombres2.Text) == false)
                {
                    NomPa2 = TxtNombres2.Text;
                    CuantosCriterios += 1;
                }

                if (string.IsNullOrWhiteSpace(TxtApellido01.Text) == false)
                {
                    Apel1 = TxtApellido01.Text;
                    CuantosCriterios += 1;
                }

                if (string.IsNullOrWhiteSpace(TxtApellido02.Text) == false)
                {
                    Apel2 = TxtApellido02.Text;
                    CuantosCriterios += 1;
                }

                if (CuantosCriterios <= 0)
                {
                    Utils.Informa = "Lo siento pero usted aún no digitado" + "\r";
                    Utils.Informa += "ningún criterio de busqueda que le permita " + "\r";
                    Utils.Informa += "realizar la busqueda de pacientes" + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                SqlDatos = "SELECT [Datos del Paciente].HistorPaci, ";
                SqlDatos += "[Datos del Paciente].TipoIden, ";
                SqlDatos += "[Datos del Paciente].NumIden, Rtrim([Datos del Paciente].Nombre1) + ' ' + Rtrim([Datos del Paciente].Nombre2) as NomCompl, ";
                SqlDatos += "[Datos del Paciente].Apellido1, ";
                SqlDatos += "[Datos del Paciente].Apellido2, [Datos del Paciente].FechaNaci, ";
                SqlDatos += "[Datos del Paciente].EstadoCivil, [Datos del Paciente].Sexo, ";
                SqlDatos += "[Datos del Paciente].TipoUsar, [Datos del Paciente].TipoAfiliado ";

                SqlDatos += "FROM [ACDATOXPSQL].[dbo].[Datos del Paciente] ";


                if (checkVerificación0.Checked)
                {
                    ParaWhere = "[Datos del Paciente].TipoIden = " + TipDocm + " ";
                    ParaWhere += "and [Datos del Paciente].NumIden = " + DoIden + " ";
                    ActivarCasi += 1;
                }
                //EL AND
                if (checkVerificación1.Checked)
                {
                    //Busca solo por el primer nombre

                    ParaWhere = string.IsNullOrWhiteSpace(ParaWhere) ? ParaWhere += " [Datos del Paciente].Nombre1 Like '%" + NomPa + "%' " : ParaWhere += " AND [Datos del Paciente].Nombre1 Like '%" + NomPa + "%' ";

                    ActivarCasi += 1;
                }

                if (checkVerificación2.Checked)
                {
                    //Busca solo por el segundo nombre
                    ParaWhere += string.IsNullOrWhiteSpace(ParaWhere) ? " [Datos del Paciente].Nombre2 Like '%" + NomPa2 + "%' " : " AND [Datos del Paciente].Nombre2 Like '%" + NomPa2 + "%' ";
                    ActivarCasi += 1;
                }



                if (checkVerificación3.Checked)
                {
                    //Busca solo APELLIDO 1 Apellido1 
                    ParaWhere += string.IsNullOrWhiteSpace(ParaWhere) ? " [Datos del Paciente].Apellido1 Like '%" + Apel1 + "%' " : " AND [Datos del Paciente].Apellido1 Like '%" + Apel1 + "%' ";
                    ActivarCasi += 1;
                }


                if (checkVerificación4.Checked)
                {
                    //Busca solo por el SEGUNDO APELLIDO Apellido2 Apel2
                    ParaWhere += string.IsNullOrWhiteSpace(ParaWhere) ? " [Datos del Paciente].Apellido2 Like '%" + Apel2 + "%' " : " AND [Datos del Paciente].Apellido2 Like '%" + Apel2 + "%' ";
                    ActivarCasi += 1;
                }


                if (ActivarCasi > 0)
                {
                    ParaWhere = "WHERE " + ParaWhere;
                    SqlDatos += ParaWhere;
                }
                else
                {
                    Utils.Informa = "Lo siento pero usted debe activar al" + "\r";
                    Utils.Informa += "menos uno (1) de los criterios digitados" + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


                DataSet dataSet = Conexion.SQLDataSet(SqlDatos);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    Utils.Titulo01 = "Control de ejecución";
                    Utils.Informa = "Lo siento pero se ha encontrado ningún paciente con los criterios" + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    DgListaPacientesencontrados.DataSource = dataSet.Tables[0];
                }

            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "al abrir el formulario buscar pacientes" + "\r";
                Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmBuscarPacientes_Load(object sender, EventArgs e)
        {
            try
            {
                CargarCombos();
            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "al dar click en buscar pacientes" + "\r";
                Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEligeTercero_Click(object sender, EventArgs e)
        {
            try
            {
                string His01 = "";

                if (DgListaPacientesencontrados.SelectedRows.Count > 0)
                {
                    His01 = DgListaPacientesencontrados.SelectedCells[0].Value.ToString();
                }
                else
                {
                    Utils.Informa = " Primerammente se debe seleccionar un paciente de la lista" + "\r";
                    MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Utils.HistoriaNumero = His01;

                this.Dispose();

            }
            catch (Exception ex)
            {
                Utils.Titulo01 = "Control de errores de ejecución";
                Utils.Informa = "Lo siento pero se ha presentado un error" + "\r";
                Utils.Informa += "de hacer click sobre el botón de elegir" + "\r";
                Utils.Informa += "Mensaje del error: " + ex.Message + " - " + ex.StackTrace;
                MessageBox.Show(Utils.Informa, Utils.Titulo01, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
