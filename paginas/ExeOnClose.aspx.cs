using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class paginas_ExeOnClose : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //.... Actualiza el estado de algun documento ........................
        negocio Sql_ = new negocio();
        Sql_.ActualizarEstadoDocument(Convert.ToString(Session["table"]), Convert.ToInt32(Session["idExport"]), false);
        //....................................................................
        
        //....................................................................
        Response.Clear();
        Response.Write(string.Empty); //As you are not expecting any response
        Response.End();
        //....................................................................
    }
}