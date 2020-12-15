using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBLConexion
{
   public partial class clsConexion
    {
        static string CadenaDeConexion = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\AlexisPaguanquizaASP\WebOrdenes\WebOrdenes\App_Data\BDOrdenes.mdf;" +
                                          "Integrated Security = True;";
        public static SqlConnection abreConexion()
        {
            SqlConnection conn = new SqlConnection(CadenaDeConexion);
            return conn;
        }
        public static SqlCommand generaComandos()
        {
            SqlCommand Comando = new SqlCommand();
            return Comando;

        }
        public static SqlDataAdapter generaBusqueda()
        {
            SqlDataAdapter da = new SqlDataAdapter();
            return da;
        }
    }
}
