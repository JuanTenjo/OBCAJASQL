using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBCAJASQL.Class
{
    class Utils
    {
        public static string codUsuario { get; set; }

        public static string nomUsuario { get; set; }
        public static string nivelPermiso { get; set; }
        public static string codUnicoEmpresa { get; set; }
        public static string CodEnti { get; set; }
        public static string CodEspecialidad { get; set; }

        public static string CodigoMedico { get; set; }
        public static string CodAplicacion { get; set; }

        public static string codMinSalud { get; set; }

        public static string tipoDocEmp { get; set; }
        public static string nitEmpresa { get; set; }
        public static string nomEmpresa { get; set; }
        public static string CateEmpresa { get; set; }
        public static string TelEmpresa { get; set; }


        public static string Titulo01 { get; set; }
        public static string Informa { get; set; }
        public static string SqlDatos { get; set; }

        public static string SqlUpdate { get; set; }

        public static string infNombreInforme { get; set; }

        public static string CarAdmin { get; set; }

        public static string CodRips { get; set; }
        public static string NomTerc { get; set; }


        //Para abrir la conexion principal de la base de datos 

        public static string BaseDeDatosPrincipal { get; set; }

        //Reporte de factura con saldo
        public static string condicion { get; set; }
        public static string FecInicial { get; set; }
        public static string FecFinal { get; set; }

        //Formulario Caja General

        public static string NombgPre { get; set; }
        public static string CodCaja { get; set; }
        public static string CenCosCaja { get; set; }
        public static string CuenConta { get; set; }
        public static string CuentaContable { get; set; }
        public static string TipoDocDebi { get; set; }
        public static string NumDocDebi { get; set; }
        public static string SucuCtaDebi { get; set; }
        public static string DigiVerDebi { get; set; }
        public static string NumDocDebiDos { get; set; }
        public static string NumHisPrede { get; set; }
        public static string TipDocPre { get; set; }
        public static string NumDocPre { get; set; }
        public static string SucurPre { get; set; }

        //Busqeuda por tecero

        public static string TipDocFac { get; set; }
        public static string NitCC { get; set; }
        public static string SucurTer { get; set; }

        //Reporte Recibo de Caja
        public static string Condicion { get; set; }

        //Cruce Depositos

        public static string Histocruce { get; set; }
        public static string FacturDepo { get; set; }
        public static string TipoPago { get; set; }
        public static string RegimenUsu { get; set; }

        //Ingresos Generarles

        public static string HistoriaNumero { get; set; }
        public static string NombrePaciente { get; set; }

        public static string CodigoServi { get; set; }


        //Formulario InputBox

        public static string ReciboCaja { get; set; }
        public static string TextoInputBox { get; set; }
        public static string ValueInput { get; set; }

        //Informes

        public static string FechaInicial { get; set; }
        public static string FechaFinal { get; set; }
        public static int Anulado { get; set; }
        public static string CodRegis { get; set; }
        public static string CodiServi { get; set; }
        

    }
}
