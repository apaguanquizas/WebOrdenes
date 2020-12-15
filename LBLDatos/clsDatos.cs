using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LBLConexion;
namespace LBLDatos
{
    public class clsDatos
    {
        #region Area de Conexiones
        SqlConnection conn = clsConexion.abreConexion();
        SqlCommand comandos = clsConexion.generaComandos();
        SqlDataAdapter busquedas = clsConexion.generaBusqueda();
        #endregion
        #region Sentencia de Busquedas SQL 
        public DataSet SQLBuscarProductos(string condiciones)
        {
            string sqlBusqueda = "SELECT*FROM tblProductos " + condiciones + "";
            DataSet dsBusqueda = new DataSet();
            try
            {
                conn.Open();
                busquedas = new SqlDataAdapter(sqlBusqueda, conn);
                busquedas.Fill(dsBusqueda, "tblSQL");
                return dsBusqueda;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        #endregion
        #region SP_PRODUCTOS
        public void SP_PRODUCTOS(int SPID_, string SPNOM_, string SPDES_, decimal SPPrecio,string SPTransaccion,out string respuesta)
        {
            comandos = conn.CreateCommand();
            comandos.CommandText = "SP_PRODUCTOS";
            comandos.CommandType = CommandType.StoredProcedure;
            comandos.Parameters.Add("@SPID_",SqlDbType.Int).Value = SPID_;
            comandos.Parameters.Add("@SPNOM_", SqlDbType.NVarChar).Value = SPNOM_;
            comandos.Parameters.Add("@SPDES_", SqlDbType.NVarChar).Value = SPDES_;
            comandos.Parameters.Add("@SPPrecio", SqlDbType.Decimal).Value = SPPrecio;
            comandos.Parameters.Add("@SPTransaccion", SqlDbType.NVarChar).Value = SPTransaccion;
            conn.Open();
            SqlTransaction transaccion = conn.BeginTransaction(IsolationLevel.ReadCommitted);
            try
            {
                comandos.Transaction = transaccion;
                comandos.ExecuteNonQuery();
                respuesta = "Procesado Correctamente";
                transaccion.Commit();
            }
            catch (Exception e)
            {
                transaccion.Rollback();
                e.GetBaseException();
                respuesta = "Error: Al procesar la Solicitud: " + SPTransaccion + " " + e.GetBaseException();
            }
            finally
            {
                conn.Close();
            }

        }
        #endregion 
        #region Sentencia de Busquedas SQL 
        public DataSet SQLBuscarClientes(string condiciones)
        {
            string sqlBusqueda = "SELECT*FROM tblClientes " + condiciones + "";
            DataSet dsBusqueda = new DataSet();
            try
            {
                conn.Open();
                busquedas = new SqlDataAdapter(sqlBusqueda, conn);
                busquedas.Fill(dsBusqueda, "tblSQL");
                return dsBusqueda;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        #endregion
        #region SP_PRODUCTOS
        public void SP_CLIENTES(int SPID_,string SPIDE_, string SPNOM_, string SPAPE_,string SPTransaccion, out string respuesta)
        {
            comandos = conn.CreateCommand();
            comandos.CommandText = "SP_CLIENTES";
            comandos.CommandType = CommandType.StoredProcedure;
            comandos.Parameters.Add("@SPID_", SqlDbType.Int).Value = SPID_;
            comandos.Parameters.Add("@SPIDE_", SqlDbType.NVarChar).Value = SPIDE_;
            comandos.Parameters.Add("@SPNOM_", SqlDbType.NVarChar).Value = SPNOM_;
            comandos.Parameters.Add("@SPAPE_", SqlDbType.NVarChar).Value = SPAPE_;
            comandos.Parameters.Add("@SPTransaccion", SqlDbType.NVarChar).Value = SPTransaccion;
            conn.Open();
            SqlTransaction transaccion = conn.BeginTransaction(IsolationLevel.ReadCommitted);
            try
            {
                comandos.Transaction = transaccion;
                comandos.ExecuteNonQuery();
                respuesta = "Procesado Correctamente";
                transaccion.Commit();
            }
            catch (Exception e)
            {
                transaccion.Rollback();
                e.GetBaseException();
                respuesta = "Error: Al procesar la Solicitud: " + SPTransaccion + " " + e.GetBaseException();
            }
            finally
            {
                conn.Close();
            }

        }
        #endregion
        #region Secuencial de la orden de pedido
        public string SQLSECUENCIAL()
        {
            string SECUENCIAL = "0";
            string sqlBusqueda = "SELECT COUNT(*)+1 AS SECUENCIAL FROM [tblOrdenCabecera]";
            DataSet dsBusqueda = new DataSet();
            try
            {
                conn.Open();
                busquedas = new SqlDataAdapter(sqlBusqueda, conn);
                busquedas.Fill(dsBusqueda, "tblSQL");
                SECUENCIAL = dsBusqueda.Tables[0].Rows[0]["SECUENCIAL"].ToString();
                return SECUENCIAL;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        #endregion
        #region INSERTAR LA ORDEN
        public void INSERT_ORDENCABECERADETALLE(int Id_cliente,int numero_orden,string observacion_orden,decimal total_orden, DataTable dtDetalle, out string respuesta)
        {
           int id_orden = numero_orden;
           string comandInsrt = " INSERT INTO tblOrdenCabecera(id_orden,Id_cliente,numero_orden,observacion_orden,total_orden) " +
                                " VALUES ("+ id_orden + "," + Id_cliente + "," + numero_orden + ",'" + observacion_orden + "'," + total_orden.ToString().Replace(",",".") + ")";
            conn.Open();
            SqlTransaction transaccion = conn.BeginTransaction(IsolationLevel.ReadCommitted);
            try
            {
                /*INSERTO LA CABECERA*/
                comandos = new SqlCommand(comandInsrt, conn);
                comandos.Transaction = transaccion;
                comandos.Prepare();
                comandos.ExecuteNonQuery();
                /*INSERTO EL DETALLE*/
                for (int i = 0; dtDetalle.Rows.Count > i; i++)
                {
                    int id_detorden = int.Parse(dtDetalle.Rows[i]["id_detorden"].ToString());
                    int Id_producto = int.Parse(dtDetalle.Rows[i]["Id_producto"].ToString());
                    decimal cantidad_detorden = decimal.Parse(dtDetalle.Rows[i]["cantidad"].ToString().Replace(".", ","));
                    decimal precio_detorden = decimal.Parse(dtDetalle.Rows[i]["pvp"].ToString().Replace(".", ","));
                    string comandInsrtDet = " INSERT INTO [tblOrdenDetalle](id_detorden, id_orden, Id_producto, precio_detorden, cantidad_detorden)" +
                                  " VALUES (" + id_detorden + "," + id_orden + "," + Id_producto + "," + precio_detorden.ToString().Replace(",", ".") + "," + cantidad_detorden.ToString().Replace(",", ".") + ")";
                    comandos = new SqlCommand(comandInsrtDet, conn);
                    comandos.Transaction = transaccion;
                    comandos.Prepare();
                    comandos.ExecuteNonQuery();
                }
                respuesta = "Procesado Correctamente";
                transaccion.Commit();
            }
            catch (Exception e)
            {
                transaccion.Rollback();
                respuesta = "Error: Al Insertar: " + e.GetBaseException();
            }
            finally
            {
                conn.Close();
            }

        }
        #endregion
        #region Secuencial de la orden de pedido
        public int SQLIdDetalle()
        {
            int idDet = 0;
            string sqlBusqueda = "SELECT COUNT(*)+1 AS SECUENCIAL FROM [tblOrdenDetalle]";
            DataSet dsBusqueda = new DataSet();
            try
            {
                conn.Open();
                busquedas = new SqlDataAdapter(sqlBusqueda, conn);
                busquedas.Fill(dsBusqueda, "tblSQL");
                idDet = int.Parse(dsBusqueda.Tables[0].Rows[0]["SECUENCIAL"].ToString());
                return idDet;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion
        #region Sentencia de Busquedas SQL Cabecera
        public DataSet SQLBuscarOrdenes(string condiciones)
        {
            string sqlBusqueda = "SELECT*FROM vi_orden " + condiciones + "";
            DataSet dsBusqueda = new DataSet();
            try
            {
                conn.Open();
                busquedas = new SqlDataAdapter(sqlBusqueda, conn);
                busquedas.Fill(dsBusqueda, "tblSQL");
                return dsBusqueda;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        #endregion
        #region Sentencia de Busquedas SQL Detalle
        public DataSet SQLBuscarOrdenesDetalle(string condiciones)
        {
            string sqlBusqueda = "SELECT*FROM vi_ordendetalle " + condiciones + "";
            DataSet dsBusqueda = new DataSet();
            try
            {
                conn.Open();
                busquedas = new SqlDataAdapter(sqlBusqueda, conn);
                busquedas.Fill(dsBusqueda, "tblSQL");
                return dsBusqueda;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        #endregion
    }
}
