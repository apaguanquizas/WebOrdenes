using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebOrdenes
{
    public partial class frmOrdenConsulta : System.Web.UI.Page
    {
        LBLLogicaNegocio.clsLogica SQLLogica = new LBLLogicaNegocio.clsLogica();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargaGrid("");
            }
        }
        public void CargaGridDetalle(string idOrden)
        {
            DataTable dtOrdenDet = new DataTable();
            dtOrdenDet = SQLLogica.SQLBuscarOrdenesDetalle(" WHERE id_orden="+idOrden+"").Tables[0];
            grwProductos.DataSource = dtOrdenDet;
            grwProductos.DataBind();
            dtOrdenDet.Dispose();
        }
        public void CargaGrid(string condiciones)
        {
            DataTable dtOrden = new DataTable();
            dtOrden = SQLLogica.SQLBuscarOrdenes(condiciones).Tables[0];
            grwOrdenes.DataSource = dtOrden;
            grwOrdenes.DataBind();
            dtOrden.Dispose();
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargaGrid(" WHERE UPPER(CONCAT([numero_orden],[observacion_orden],[Identificacion],[nombres])) like'%" + txtBuscar.Text.ToUpper() + "%'");
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("/frmOrdenes");
        }

        protected void btnVerDetalle_Click(object sender, EventArgs e)
        {
            GridViewRow grRow = (GridViewRow)(((LinkButton)sender).Parent.Parent);
            string idOrden = grwOrdenes.DataKeys[grRow.RowIndex].Value.ToString();
            CargaGridDetalle(idOrden);
            popupItem.Show();
        }
    }
}