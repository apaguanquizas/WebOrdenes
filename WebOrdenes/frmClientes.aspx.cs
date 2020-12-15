using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebOrdenes
{
    public partial class frmClientes : System.Web.UI.Page
    {
        LBLLogicaNegocio.clsLogica SQLLogica = new LBLLogicaNegocio.clsLogica();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargaGrid("");
            }
        }
        public bool Valida(out string MSM)
        {
            bool verifica = true;
            MSM = null;
            if (string.IsNullOrEmpty(txtIdentificacion.Text))
            {
                verifica = false;
                MSM = "ERROR: Ingrese la Identifcación del CLIENTE, revise.";
                txtIdentificacion.Focus();
            }            
            else
            {
                if (string.IsNullOrEmpty(txtNombre.Text))
                {
                    verifica = false;
                    MSM = "ERROR: Ingrese el NOMBRE del CLIENTE, revise.";
                    txtNombre.Focus();
                }
                else
                {
                    if (string.IsNullOrEmpty(txtApellido.Text))
                    {
                        verifica = false;
                        MSM = "ERROR: Ingrese el APELLIDO del CLIENTE, revise.";
                        txtApellido.Focus();
                    }
                }
            }
            return verifica;

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

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string MSM = null;
            if (Valida(out MSM))
            {
                lblAlertas.Text = "";
                int SPID_ = int.Parse(lblID.Text);
                string SPIDE_ = txtIdentificacion.Text;
                string SPNOM_ = txtNombre.Text;
                string SPAPE_ = txtApellido.Text;                
                string SPTransaccion = "INSERT";
                if (SPID_ > 0)
                {
                    SPTransaccion = "UPDATE";
                }
                string respuesta = null;
                SQLLogica.SP_CLIENTES(SPID_, SPIDE_, SPNOM_, SPAPE_, SPTransaccion, out respuesta);
                lblAlertas.Text = respuesta;
                if (respuesta == "Procesado Correctamente")
                {
                    CargaGrid("");
                    btnGuardar.Enabled = false;
                }
            }
            else
            {
                lblAlertas.Text = MSM;
            }
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargaGrid(" WHERE UPPER(CONCAT([Identificacion],[Nombres],[Apellidos])) like'%" + txtBuscar.Text.ToUpper() + "%'");
        }

        protected void btnEditarGW_Click(object sender, EventArgs e)
        {
            GridViewRow grRow = (GridViewRow)(((LinkButton)sender).Parent.Parent);
            lblID.Text = grwClientes.DataKeys[grRow.RowIndex].Value.ToString();
            DataTable dtCli = dsClientes(" WHERE [Id_cliente] = " + lblID.Text);
            txtIdentificacion.Text = dtCli.Rows[0]["Identificacion"].ToString();
            txtNombre.Text = dtCli.Rows[0]["Nombres"].ToString();
            txtApellido.Text = dtCli.Rows[0]["Apellidos"].ToString();            
            btnGuardar.Text = "Actualizar";
            btnGuardar.Enabled = true;
            dtCli.Dispose();
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            btnGuardar.Text = "Guardar";
            lblID.Text = "0";
            txtIdentificacion.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";           
            btnGuardar.Enabled = true;
        }
        protected void btnEliminarGW_Click(object sender, EventArgs e)
        {
            GridViewRow grRow = (GridViewRow)(((LinkButton)sender).Parent.Parent);
            lblID.Text = grwClientes.DataKeys[grRow.RowIndex].Value.ToString();
            lblAlertas.Text = "";
            int SPID_ = int.Parse(lblID.Text);
            string SPIDE_ = "";
            string SPNOM_ = "";            
            string SPAPE_ = "";
            string SPTransaccion = "DELETE";
            string respuesta = null;
            SQLLogica.SP_CLIENTES(SPID_, SPIDE_, SPNOM_, SPAPE_, SPTransaccion, out respuesta);
            lblAlertas.Text = respuesta;
            if (respuesta == "Procesado Correctamente")
            {
                CargaGrid("");
            }
        }
    }
}