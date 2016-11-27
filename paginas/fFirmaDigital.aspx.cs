﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class paginas_fFirmaDigital : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
            String urlUploadFilePage = Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath + "/paginas/fGuardarPDF.aspx";

        Literal1.Text = "<applet code=\"Aplika_Indexing\" archive=\"../FirmaApplet.jar\" width=\"800\" height=\"550\" >";
        Literal1.Text += "<param name=\"pathImagenFirma\" value=\"" + Session["pathImagenFirma"].ToString() + "\" id=\"param1\" />";
        Literal1.Text += "<param name=\"certificado\" value=\"" + Session["certificado"].ToString() + "\" id=\"param1\" />";
        Literal1.Text += "<param name=\"motivo\" value=\"" + Session["motivo"].ToString() + "\" id=\"param1\" />";
        Literal1.Text += "<param name=\"ubicacion\" value=\"" + Session["ubicacion"].ToString() + "\" id=\"param1\" />";
        Literal1.Text += "<param name=\"contacto\" value=\"" + Session["contacto"].ToString() + "\" id=\"param1\" />";
        Literal1.Text += "<param name=\"pathPDF\" value=\"" + Session["pathPDF"].ToString() + "\" id=\"param1\" />";
        Literal1.Text += "<param name=\"fullPathFileInServer\" value=\"" + Session["fullPathFileInServer"].ToString() + "\" id=\"param1\" />";
        Literal1.Text += "<param name=\"UrlUploadFilePage\" value=\"" + urlUploadFilePage + "\" id=\"param1\" />";
        Literal1.Text += "</applet>";
    }
    protected void ImageButtonVolver_Click(object sender, ImageClickEventArgs e)
    {
        negocio Sql_ = new negocio();
        Sql_.ActualizarEstadoDocument(Convert.ToString (Session["table"]),Convert.ToInt32(Session["idExport"]), false);
        this.Response.Redirect("fBusquedas.aspx");
        
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        negocio Sql_ = new negocio();
        Sql_.ActualizarEstadoDocument(Convert.ToString(Session["table"]), Convert.ToInt32(Session["idExport"]), false);
        this.Response.Redirect("fBusquedas.aspx");
    }
}