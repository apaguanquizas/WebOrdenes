using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace WebOrdenes
{
    public partial class frmOrdenes : System.Web.UI.Page
    {
        LBLLogicaNegocio.clsLogica SQLLogica = new LBLLogicaNegocio.clsLogica();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                lblNumeroPedido.Text = SQLLogica.SQLSECUENCIAL();
            }
        }
        public bool ValidaNull(out string MSM)
        {
            bool verifica = true;
            MSM = null;
            if (string.IsNullOrEmpty(txtIdentificacion.Text))
            {
                verifica = false;
                MSM = "ERROR: Ingrese un Nro. de IDENTIFICACIÓN, revise.";
                txtIdentificacion.Focus();
            }
            else
            {
                if (grwDetalle.Rows.Count == 0)
                {
                    verifica = false;
                    MSM = "ERROR: Ingrese un PRODUCTO, revise.";
                    grwDetalle.Focus();
                }                
            }
            return verifica;
        }
        public void CalculadoraGrid()
        {
            try
            {
                decimal dtTotal = 0;
                if (grwDetalle.Rows.Count > 0)
                {
                    foreach (GridViewRow gridDetalleCal in this.grwDetalle.Rows)
                    {
                       if (string.IsNullOrEmpty(((TextBox)gridDetalleCal.Cells[2].Controls[1]).Text))//CANTIDAD VACIA
                        {
                            ((TextBox)gridDetalleCal.Cells[2].Controls[1]).Text = "0";
                        }
                        if (string.IsNullOrEmpty(((TextBox)gridDetalleCal.Cells[3].Controls[1]).Text))//DESCUENTO VACIO
                        {
                            ((TextBox)gridDetalleCal.Cells[3].Controls[1]).Text = "0";
                        }
                       decimal dtPrecioPVP = decimal.Parse(((TextBox)gridDetalleCal.Cells[3].Controls[1]).Text.Replace(".", ","));
                       decimal dtCantidad = decimal.Parse(((TextBox)gridDetalleCal.Cells[2].Controls[1]).Text.Replace(".", ","));
                       decimal dtCostoTotal = dtCantidad * dtPrecioPVP;
                       
                       dtTotal += dtCostoTotal;
                       ((Label)gridDetalleCal.Cells[4].Controls[1]).Text = dtCostoTotal.ToString();                        
                    }
                  }
                lblTotal.Text = dtTotal.ToString();
            }
            catch (Exception E)
            {
                Session["lblSessionError"] = E.GetBaseException();
                Response.Redirect("../frmError.aspx");
            }
        }
        public bool ValidaFilasDuplicada(string id, out int fila)
        {
            bool Respuesta = true;
            int contador = -1;
            foreach (GridViewRow gridDetalle in this.grwDetalle.Rows)
            {
                contador++;
                string pkid = grwDetalle.DataKeys[gridDetalle.RowIndex].Value.ToString();
                if (id == pkid)
                {
                    Respuesta = false;
                    break;
                }
                else
                {
                    Respuesta = true;
                }

            }
            fila = contador;
            return Respuesta;
        }
        public void NuevaFila(string ID_, string PRODUCTO, decimal CANTIDAD, decimal PVP)
        {
            try
            {
                DataTable dt = new DataTable("dtDetalle");
                dt.Columns.Add("Id_producto");
                dt.Columns.Add("Nombre");
                dt.Columns.Add("cantidad");
                dt.Columns.Add("pvp");
                dt.Columns.Add("total");
                UniqueConstraint PrimaryKey = new UniqueConstraint(dt.Columns["Id_producto"], true);
                dt.Constraints.Add(PrimaryKey);               
                foreach (GridViewRow gridDetalle in this.grwDetalle.Rows)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = grwDetalle.DataKeys[gridDetalle.RowIndex].Value.ToString();
                    dr[1] = ((Label)gridDetalle.Cells[1].Controls[1]).Text;//PRODUCTO
                    dr[2] = ((TextBox)gridDetalle.Cells[2].Controls[1]).Text;//Cantidad;
                    dr[3] = ((TextBox)gridDetalle.Cells[3].Controls[1]).Text;//PRECIO; 
                    dt.Rows.Add(dr);
                }
                 DataRow drVacio = dt.NewRow();
                 drVacio[0] = ID_;
                 drVacio[1] = PRODUCTO;
                 drVacio[2] = CANTIDAD.ToString().Replace(",", ".");
                 drVacio[3] = PVP.ToString().Replace(",", ".");                           
                 dt.Rows.Add(drVacio);
                 grwDetalle.DataSource = dt;
                 grwDetalle.DataBind();
                 dt.Dispose();
                 }
                 catch (Exception E)
                 {
                    lblAlertas.Text = E.GetBaseException().ToString();
                 }
         }               
        public void CargaGridProducto(string condiciones)
        {
            DataTable dtProd = new DataTable();
            dtProd = dsProductos(condiciones);
            grwProductos.DataSource = dtProd;
            grwProductos.DataBind();
            dtProd.Dispose();
        }
        public DataTable dsProductos(string condiciones)
        {
            DataTable dtProd = new DataTable();
            dtProd = SQLLogica.SQLBuscarProductos(condiciones).Tables[0];
            dtProd.Dispose();
            return dtProd;
        }
        public void CargaGrid(string condiciones)
        {
            DataTable dtCli = new DataTable();
            dtCli = dsClientes(condiciones);
            grwClientes.DataSource = dtCli;
            grwClientes.DataBind();
            dtCli.Dispose();
        }
        public DataTable dsClientes(string condiciones)
        {
            DataTable dtCli = new DataTable();
            dtCli = SQLLogica.SQLBuscarClientes(condiciones).Tables[0];
            dtCli.Dispose();
            return dtCli;
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            lblNumeroPedido.Text = SQLLogica.SQLSECUENCIAL();
            Response.Redirect("frmOrdenes");
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string respuesta = null;
            string MSM = null;
            if (ValidaNull(out MSM) == true)
            {
                try
                {
                    int Id_cliente = int.Parse(lblIDCliente.Text);
                    int numero_orden = int.Parse(lblNumeroPedido.Text);
                    string observacion_orden = txtObservacion.Text;
                    decimal total_orden = decimal.Parse(lblTotal.Text);
                    #region Detalle de la Orden
                    DataTable dtDetalle = new DataTable();
                    dtDetalle.Columns.Add("id_detorden");
                    dtDetalle.Columns.Add("Id_producto");
                    dtDetalle.Columns.Add("Nombre");
                    dtDetalle.Columns.Add("cantidad");
                    dtDetalle.Columns.Add("pvp");
                    dtDetalle.Columns.Add("total");
                    UniqueConstraint PrimaryKey = new UniqueConstraint(dtDetalle.Columns["id_detorden"], true);
                    dtDetalle.Constraints.Add(PrimaryKey);
                    int IDDET = SQLLogica.SQLIdDetalle();
                    foreach (GridViewRow gridDetalle in this.grwDetalle.Rows)
                    {
                        DataRow dr = dtDetalle.NewRow();
                        dr[0] = IDDET;
                        dr[1] = grwDetalle.DataKeys[gridDetalle.RowIndex].Value.ToString();
                        dr[2] = ((Label)gridDetalle.Cells[1].Controls[1]).Text;//PRODUCTO
                        dr[3] = ((TextBox)gridDetalle.Cells[2].Controls[1]).Text.Replace(",",".");//Cantidad;
                        dr[4] = ((TextBox)gridDetalle.Cells[3].Controls[1]).Text.Replace(",", ".");//PRECIO; 
                        dtDetalle.Rows.Add(dr);
                        IDDET++;
                    }
                    #endregion
                    SQLLogica.InsertarOrdenCabDet(Id_cliente, numero_orden, observacion_orden, total_orden, dtDetalle, out respuesta);
                    if (respuesta == "Procesado Correctamente")
                    {
                        btnGuardar.Visible = false;                       
                    }
                    lblAlertas.Text = respuesta;
                    dtDetalle.Dispose();
                }
                catch (Exception E)
                {
                    lblAlertas.Text = respuesta + E.GetBaseException();

                }               
            }
            else
            {
                lblAlertas.Text = MSM;
            }
        }
        protected void btnBuscarClientes_Click(object sender, EventArgs e)
        {
            PopupCliente.Show();
        }

        protected void btnAgregarProductos_Click(object sender, EventArgs e)
        {
            popupItem.Show();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargaGrid(" WHERE UPPER(CONCAT([Identificacion],[Nombres],[Apellidos])) like'%" + txtBuscar.Text.ToUpper() + "%'");
            PopupCliente.Show();
        }

        protected void btnBuscarProd_Click(object sender, EventArgs e)
        {
            CargaGridProducto(" WHERE UPPER(CONCAT([Nombre],[Descripcion])) like'%" + txtBuscar.Text.ToUpper() + "%'");
            popupItem.Show();
        }

        protected void txtIdentificacion_TextChanged(object sender, EventArgs e)
        {
          DataTable dtCli= dsClientes(" WHERE Identificacion='"+txtIdentificacion.Text+"'");
          lblNombres.Text = "";
            if(dtCli.Rows.Count>0)
            {
                lblIDCliente.Text = dtCli.Rows[0]["Id_cliente"].ToString();
                lblNombres.Text = dtCli.Rows[0]["Nombres"].ToString()+" "+dtCli.Rows[0]["Apellidos"].ToString();
                txtObservacion.Focus();
            }
            else
            {
                lblAlertas.Text = "ALERTA: Cliente no existe, revise.";
            }
        }

        protected void btnSleccionarGWCli_Click(object sender, EventArgs e)
        {
            GridViewRow grRow = (GridViewRow)(((LinkButton)sender).Parent.Parent);
            lblIDCliente.Text = grwClientes.DataKeys[grRow.RowIndex].Value.ToString();
            DataTable dtCli = dsClientes(" WHERE [Id_cliente] = " + lblIDCliente.Text);
            txtIdentificacion.Text = dtCli.Rows[0]["Identificacion"].ToString();
            lblNombres.Text = dtCli.Rows[0]["Nombres"].ToString() + " " + dtCli.Rows[0]["Apellidos"].ToString();
            txtObservacion.Focus();
            dtCli.Dispose();
        }

        protected void btnSeleccionarGWPr_Click(object sender, EventArgs e)
        {
            lblAlertas.Text = "";
            GridViewRow gridExamenesGrid = (GridViewRow)(((LinkButton)sender).Parent.Parent);
            string ID_PRO = grwProductos.DataKeys[gridExamenesGrid.RowIndex].Value.ToString();
            try
            {
                int FilaAfectacion = 0;
                bool DumplicaItem = ValidaFilasDuplicada(ID_PRO, out FilaAfectacion);
                DataTable dsItemsDetalle = dsProductos(" WHERE Id_producto=" + ID_PRO + "");
                if (DumplicaItem == true)
                {
                    string dtPRODUCTO = dsItemsDetalle.Rows[0]["Nombre"].ToString() +" "+dsItemsDetalle.Rows[0]["Descripcion"].ToString();
                    decimal dtPRECIO = decimal.Parse(dsItemsDetalle.Rows[0]["Precio"].ToString());
                    NuevaFila(ID_PRO, dtPRODUCTO, 1, dtPRECIO);
                }
                else
                {
                    decimal CantidadFila = decimal.Parse(((TextBox)grwDetalle.Rows[FilaAfectacion].Cells[2].Controls[1]).Text.Replace('.', ','));
                    decimal cantidadRow = CantidadFila + 1;
                    ((TextBox)grwDetalle.Rows[FilaAfectacion].Cells[2].Controls[1]).Text = cantidadRow.ToString();
                }
                dsItemsDetalle.Dispose();
            }
            catch (Exception E)
            {
                lblAlertas.Text = E.GetBaseException().ToString();              
            }
            finally
            {
                CalculadoraGrid();
                popupItem.Show();
            }
            popupItem.Show();
        }

        protected void btnEliminaGWDet_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewRow gridDetalleDelete = (GridViewRow)(((LinkButton)sender).Parent.Parent);
                DataTable dt = new DataTable("dtVacioDetalle");
                dt.Columns.Add("Id_producto");
                dt.Columns.Add("Nombre");
                dt.Columns.Add("cantidad");
                dt.Columns.Add("pvp");
                dt.Columns.Add("total");
                UniqueConstraint PrimaryKey = new UniqueConstraint(dt.Columns["Id_producto"], true);
                dt.Constraints.Add(PrimaryKey);
                if (grwDetalle.Rows.Count > 0)
                   {
                     foreach (GridViewRow gridDetalle in this.grwDetalle.Rows)
                      {
                         DataRow dr = dt.NewRow();
                         dr[0] = grwDetalle.DataKeys[gridDetalle.RowIndex].Value.ToString();
                         dr[1] = ((Label)gridDetalle.Cells[1].Controls[1]).Text;//PRODUCTO
                         dr[2] = ((TextBox)gridDetalle.Cells[2].Controls[1]).Text;//Cantidad;
                         dr[3] = ((TextBox)gridDetalle.Cells[3].Controls[1]).Text;//PRECIO; 
                         dt.Rows.Add(dr);                            
                      }
                dt.Rows[gridDetalleDelete.RowIndex].Delete();
                dt.AcceptChanges();
                grwDetalle.DataSource = dt;
                grwDetalle.DataBind();
                dt.Dispose();
                 }
            }
            catch (Exception E)
            {
                lblAlertas.Text = E.GetBaseException().ToString() ;
            }finally
            {
                CalculadoraGrid();
            }
        }
        protected void txtCantidadGW_TextChanged(object sender, EventArgs e)
        {
            CalculadoraGrid();
            GridViewRow gridDetalleSel = (GridViewRow)(((TextBox)sender).Parent.Parent);
            ((TextBox)gridDetalleSel.Cells[2].Controls[1]).Focus();
        }
        protected void txtPrecioGW_TextChanged(object sender, EventArgs e)
        {
            CalculadoraGrid();
            GridViewRow gridDetalleSel = (GridViewRow)(((TextBox)sender).Parent.Parent);
            ((TextBox)gridDetalleSel.Cells[3].Controls[1]).Focus();
        }
    }
}