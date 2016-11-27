using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections.Specialized;
using System.Net;


public partial class paginas_fGuardarPDF : System.Web.UI.Page
{
    private void Page_Load(object sender, System.EventArgs e)
    {
        saveFilesInServerFolder();
    }

 

    private void saveFilesInServerFolder()
    {
        //Recuperar de los parametros el directorio donde seguardara el archivo.
        String fullPathFile = Request.Params["dest"];
        
        foreach (string key in Request.Files.Keys)
        {
            HttpPostedFile file = Request.Files.Get(key);
            file.SaveAs(fullPathFile);
        }
    }
}