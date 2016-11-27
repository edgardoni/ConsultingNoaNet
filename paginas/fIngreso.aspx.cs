using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class paginas_fIngreso : System.Web.UI.Page
{
    negocio negocio = new negocio();

    protected void Page_Load(object sender, EventArgs e)
    {
      try
        {
            dsConsulting.AG_UsersDataTable usuario = negocio.getUsuario(TextBox1.Text, TextBox2.Text);
            bool logueoCorrecto = false;

            if (usuario != null)
                if (usuario.Rows.Count != 0)
                {
                    dsConsulting.AG_UsersRow rowUsuario = usuario[0];

                    //if (TextBox2.Text == rowUsuario.Column1)
                    //{
                    Session["idUsuario"] = usuario.Rows[0]["IDUser"].ToString();
                    Session["user"] = TextBox1.Text;
                    logueoCorrecto = true;
                    negocio.ActualizarDocumentosAbiertos();
                    Response.Redirect("fBusquedas.aspx");
                    //Response.Redirect("fBusquedasODS.aspx");

                    MostrarAJAXMessage(this, usuario.Rows[0]["IDUser"].ToString() + TextBox1.Text);
                    //}
                }
        }
        catch (Exception ex)
        {
            
        }
        
  }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            dsConsulting.AG_UsersDataTable usuario = negocio.getUsuario(TextBox1.Text, TextBox2.Text);
            bool logueoCorrecto = false;

            if (usuario != null)
                if (usuario.Rows.Count != 0)
                {
                    dsConsulting.AG_UsersRow rowUsuario = usuario[0];

                    //if (TextBox2.Text == rowUsuario.Password)
                    //{
                        Session["idUsuario"] = usuario.Rows[0]["IDUser"].ToString();
                        Session["user"] = TextBox1.Text;
                        logueoCorrecto = true;
                        negocio.ActualizarDocumentosAbiertos();
			Response.Redirect("fBusquedas.aspx");
                        MostrarAJAXMessage(this,usuario.Rows[0]["IDUser"].ToString() + TextBox1.Text);
                    //}
                }

            if (!logueoCorrecto)
            {
                MostrarAJAXMessage(this, "Datos incorrectos ingrese nuevamente por favor");
                TextBox1.Text = "";
                TextBox2.Text = "";
            }
        }
        catch (Exception ex)
        {
            MostrarAJAXMessage(this, ex.Message + ex.Source);
        }

    }
    #region[Funcion Cliente de Mensajes]
    static public void MostrarAJAXMessage(Control page, string msg)
    {
        string myScript = String.Format("alert('" + msg + "');", msg);
        ScriptManager.RegisterStartupScript(page, page.GetType(),
        "MyScript", myScript, true);
    }
    #endregion

}
