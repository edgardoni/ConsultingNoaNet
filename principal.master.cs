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

public partial class principal1 : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        string user = Session["user"].ToString();
        Response.Redirect("http://localhost:1547/indexingweb2/Default.aspx?user=" + user);
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        string user = Session["user"].ToString();
        Response.Redirect("http://localhost:1547/indexingweb2/Default.aspx?user=" + user);
    }
}
