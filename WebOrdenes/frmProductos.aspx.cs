using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace WebOrdenes
{
    public partial class frmProductos : System.Web.UI.Page
    {
        LBLLogicaNegocio.clsLogica SQLLogica = new LBLLogicaNegocio.clsLogica();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                CargaGrid("");
            }
        }
        public bool Valida(out string MSM)
        {
            bool verifica = true;
            MSM = null;
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                verifica = false;
                MSM = "ERROR: Ingrese el NOMBRE del PRODUCTO, revise.";
                txtNombre.Focus();
            }
            else
            {
                if (string.IsNullOrEmpty(txtPrecio.Text))
                {
                    verifica = false;
                    MSM = "ERROR: Ingrese el PRECIO del PRODUCTO, revise.";
                    txtPrecio.Focus();
                }
            }
            return verifica;

        }
        public void CargaGrid(string condiciones)
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

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string MSM = null;
            if (Valida(out MSM))
            { 
            lblAlertas.Text = "";
            int SPID_ = int.Parse(lblID.Text);
            string SPNOM_ = txtNombre.Text;
            string SPDES_ = txtDescripcion.Text;
            decimal SPPrecio = decimal.Parse(txtPrecio.Text.Replace(".", ","));
            string SPTransaccion = "INSERT";
            if(SPID_>0)
            {
                SPTransaccion = "UPDATE";
            }
            string respuesta = null;
            SQLLogica.SP_PRODUCTOS(SPID_, SPNOM_, SPDES_, SPPrecio, SPTransaccion, out respuesta);
            lblAlertas.Text = respuesta;
            if(respuesta== "Procesado Correctamente")
            {
                CargaGrid("");
                btnGuardar.Enabled = false;
            }
            }else
            {
                lblAlertas.Text = MSM;
            }
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargaGrid(" WHERE UPPER(CONCAT([Nombre],[Descripcion])) like'%" + txtBuscar.Text.ToUpper()+"%'");
        }

        protected void btnEditarGW_Click(object sender, EventArgs e)
        {
            GridViewRow grRow = (GridViewRow)(((LinkButton)sender).Parent.Parent);
            lblID.Text= grwProductos.DataKeys[grRow.RowIndex].Value.ToString();
            DataTable dtProd= dsProductos(" WHERE [Id_producto] = " + lblID.Text);
            txtNombre.Text = dtProd.Rows[0]["Nombre"].ToString();
            txtDescripcion.Text = dtProd.Rows[0]["Descripcion"].ToString();
            txtPrecio.Text = dtProd.Rows[0]["Precio"].ToString().Replace(",",".");
            btnGuardar.Text = "Actualizar";
            btnGuardar.Enabled = true;
            dtProd.Dispose();
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            btnGuardar.Text = "Guardar";
            lblID.Text = "0";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "0";
            btnGuardar.Enabled = true;
        }

        protected void btnEliminarGW_Click(object sender, EventArgs e)
        {
            GridViewRow grRow = (GridViewRow)(((LinkButton)sender).Parent.Parent);
            lblID.Text = grwProductos.DataKeys[grRow.RowIndex].Value.ToString();
            lblAlertas.Text = "";
            int SPID_ = int.Parse(lblID.Text);
            string SPNOM_ = "";
            string SPDES_ = "";
            decimal SPPrecio = 0;
            string SPTransaccion = "DELETE";
            string respuesta = null;
            SQLLogica.SP_PRODUCTOS(SPID_, SPNOM_, SPDES_, SPPrecio, SPTransaccion, out respuesta);
            lblAlertas.Text = respuesta;
            if (respuesta == "Procesado Correctamente")
            {
                CargaGrid("");              
            }
        }
    }
}