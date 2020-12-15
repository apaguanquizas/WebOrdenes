using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace LBLLogicaNegocio
{
    public class clsLogica
    {
        LBLDatos.clsDatos SQLDatos = new LBLDatos.clsDatos();
        #region Sentencia de Busquedas SQL 
        public DataSet SQLBuscarProductos(string condiciones)
        {
            return SQLDatos.SQLBuscarProductos(condiciones);
        }
        #endregion
        #region SP_PRODUCTOS
        public void SP_PRODUCTOS(int SPID_, string SPNOM_, string SPDES_, decimal SPPrecio, string SPTransaccion, out string respuesta)
        {
            SQLDatos.SP_PRODUCTOS(SPID_, SPNOM_, SPDES_, SPPrecio, SPTransaccion, out respuesta);
        }
        #endregion
        #region Sentencia de Busquedas SQL 
        public DataSet SQLBuscarClientes(string condiciones)
        {
            return SQLDatos.SQLBuscarClientes(condiciones);
        }
        #endregion
        #region SP_CLIENTES
        public void SP_CLIENTES(int SPID_, string SPIDE_, string SPNOM_, string SPAPE_, string SPTransaccion, out string respuesta)
        {
            SQLDatos.SP_CLIENTES(SPID_, SPIDE_, SPNOM_, SPAPE_, SPTransaccion, out respuesta);
        }
        #endregion
        #region Sentencia de Busquedas SQL 
        public string SQLSECUENCIAL()
        {
            return SQLDatos.SQLSECUENCIAL();
        }
        #endregion
        #region INSERTAR LA ORDEN
        public void InsertarOrdenCabDet( int Id_cliente, int numero_orden, string observacion_orden, decimal total_orden,DataTable dtDetalle, out string respuesta)
        {
             SQLDatos.INSERT_ORDENCABECERADETALLE(Id_cliente, numero_orden, observacion_orden, total_orden, dtDetalle, out respuesta);               
        }
        #endregion
        #region Secuencial de la orden de pedido
        public int SQLIdDetalle()
        {
            return SQLDatos.SQLIdDetalle();
        }
        #endregion
        #region Sentencia de Busquedas Cabecera 
        public DataSet SQLBuscarOrdenes(string condiciones)
        {
            return SQLDatos.SQLBuscarOrdenes(condiciones);
        }
        #endregion
        #region Sentencia de Busquedas SQL detalle
        public DataSet SQLBuscarOrdenesDetalle(string condiciones)
        {
            return SQLDatos.SQLBuscarOrdenesDetalle(condiciones);
        }
        #endregion
    }
}