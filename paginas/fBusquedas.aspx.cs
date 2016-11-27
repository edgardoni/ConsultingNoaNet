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
using System.Text.RegularExpressions;
using System.IO;

public partial class paginas_fBusquedas : System.Web.UI.Page
{
    negocio negocio = new negocio();
    DataTable datos = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Session["gridSeleccion"] = 0;

                /**************recupera los tipos de documentos para este usuario*******************/
                DataTable document = negocio.getTiposDocumentos(Convert.ToInt16(Session["idUsuario"]));

                if (document != null)
                    if (document.Rows.Count != 0)
                    {
                        Session["document"] = document;

                        DropDownList1.DataValueField = "IDDocumentType";
                        DropDownList1.DataTextField = "documentName";

                        DropDownList1.DataSource = document;
                        DropDownList1.DataBind();
                    }
                /**************recupera las consultas guardadas para este usuario*******************/
                DataTable consultas = negocio.getConsultas(Convert.ToInt16(Session["idUsuario"]));
                Session["consultaRecuperada"] = consultas;
                //----------genero los datos para cargar el dropdownlist----------------
                DataRow fila;
                DataTable datosDrop = new DataTable();
                datosDrop.Columns.Add("queryName");
                datosDrop.Columns.Add("IDQuery");


                if (consultas != null)
                {
                    fila = datosDrop.NewRow();
                    fila["queryName"] = "Seleccionar";
                    fila["IDQuery"] = "0";
                    datosDrop.Rows.Add(fila);
                    datosDrop.AcceptChanges();

                    for (int i = 0; i < consultas.Rows.Count; i++)
                    {
                        fila = datosDrop.NewRow();
                        fila["queryName"] = consultas.Rows[i]["queryName"];
                        fila["IDQuery"] = consultas.Rows[i]["IDQuery"];
                        datosDrop.Rows.Add(fila);
                        datosDrop.AcceptChanges();

                    }
                }

                //----------------------------------------------------------------------
                if (datosDrop != null)
                    if (datosDrop.Rows.Count != 0)
                    {
                        DropDownList3.DataValueField = "IDQuery";
                        DropDownList3.DataTextField = "queryName";

                        DropDownList3.DataSource = datosDrop;
                        DropDownList3.DataBind();
                    }

            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            this.GridView2.DataSource = null;
            this.GridView2.DataBind();

            if (DropDownList1.SelectedValue == "0")
            {
                DDIndices.DataSource = null;
                DDIndices.DataBind();
                DDIndices.Items.Clear();
                DDReglas.DataSource = null;
                DDReglas.DataBind();
                DDReglas.Items.Clear();

                TextBox1.Text = "";

            }
            datos = negocio.getIndices(Convert.ToInt16(DropDownList1.SelectedValue));
            if (datos != null)
                if (datos.Rows.Count != 0)
                {
                    Session["datosDDIndices"] = datos;
                    DDIndices.DataSource = datos;
                    DDIndices.DataValueField = "IDField";// "IDField";
                    DDIndices.DataTextField = "FieldName";

                    DDIndices.DataBind();

                }
        }
        catch (Exception ex)
        {
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)//Agregar consulta
    {
        try
        {
            //GridView2.Columns.Clear();

            filtrosGridView.Enabled = true;
            Regex regex;
            //creo la regla de validacion para el valor del filtro
            switch (Session["validacionFiltro"].ToString())
            {
                case "numeros":
                    regex = new Regex("^[0-9]"); // sin el $ no machea los dni > 9 caracteres.

                    if (!regex.IsMatch(TextBox1.Text.Trim()))
                    {
                        MostrarAJAXMessage(Page, "Formato incorrecto, se esperaban numeros.");
                        return;
                    }
                    break;
            }
            DataTable document = (DataTable)Session["document"];
            for (int i = 0; i < document.Rows.Count; i++)
            {
                if (document.Rows[i]["IDDocumentType"].ToString() != "")
                {
                    if (Convert.ToInt16(document.Rows[i]["IDDocumentType"]) == Convert.ToInt16(DropDownList1.SelectedValue))
                    {
                        Session["table"] = document.Rows[i]["ExportTable"].ToString();
                        break;
                    }
                }
            }


            string filtro = "", cadenaMostrar = "", condicion = "";
            string indice = DDIndices.SelectedItem.Text;
            string regla = DDReglas.SelectedValue;

            switch (regla)
            {
                case "like":
                    filtro = indice + " " + regla + " rtrim('%" + TextBox1.Text + "%') ";
                    cadenaMostrar = indice + " sea " + DDReglas.SelectedItem + " a  '" + TextBox1.Text + "'  ";
                    break;
                case "igual":
                    filtro = indice + " like rtrim('" + TextBox1.Text + "') ";
                    cadenaMostrar = indice + " sea " + DDReglas.SelectedItem + " a  '" + TextBox1.Text + "'  ";

                    break;
                case "distinto":
                    filtro = indice + " " + regla + " rtrim('" + TextBox1.Text + "') ";
                    cadenaMostrar = indice + " sea " + DDReglas.SelectedItem + " de  '" + TextBox1.Text + "'  ";
                    break;
                case "=":
                case "<":
                case ">":
                case ">=":
                case "<=":
                case "!=":
                    switch (regla)
                    {
                        case "=": condicion = "igual"; break;
                        case "<": condicion = "menor"; break;
                        case ">": condicion = "mayor"; break;
                        case ">=": condicion = "mayor igual"; break;
                        case "<=": condicion = "menor igual"; break;
                        case "!=": condicion = "distinto"; break;

                    }
                    filtro = indice + " " + regla + " " + TextBox1.Text + " ";
                    cadenaMostrar = indice + " sea " + DDReglas.SelectedItem + "  '" + TextBox1.Text + "'  ";

                    break;
            }

            DataTable filtros = new DataTable();
            DataRow fila;
            int existe = 0;
            if (Session["dtfiltro"] != null)
            {
                filtros = (DataTable)Session["dtfiltro"];
                /**********Busco dentro del dt si la consulta ya existe**********/
                for (int i = 0; i < filtros.Rows.Count; i++)
                {
                    if (filtros.Rows[i]["filtro"].ToString().Trim() == filtro.Trim()) existe = 1;
                }
                if (existe == 0)
                {
                    fila = filtros.NewRow();
                    fila["filtro"] = filtro;
                    fila["id"] = filtros.Rows.Count;
                    fila["mostrar"] = cadenaMostrar;

                    filtros.Rows.Add(fila);
                    filtros.AcceptChanges();

                    Session["dtfiltro"] = filtros;

                    filtrosGridView.DataSource = filtros;
                    filtrosGridView.DataBind();
                }
                else
                    return;
                /****************************************************************/

            }
            else
            {
                filtros.Columns.Add("id");
                filtros.Columns.Add("filtro");
                filtros.Columns.Add("mostrar");

                fila = filtros.NewRow();
                fila["filtro"] = filtro;
                fila["id"] = filtros.Rows.Count;
                fila["mostrar"] = cadenaMostrar;

                filtros.Rows.Add(fila);
                filtros.AcceptChanges();

                Session["dtfiltro"] = filtros;

                filtrosGridView.DataSource = filtros;
                filtrosGridView.DataBind();
            }

            if (filtros.Rows.Count >= 6) Panel3.ScrollBars = ScrollBars.Vertical;
            else Panel3.ScrollBars = ScrollBars.None;
        }
        catch (Exception ex)
        {
        }
    }
    protected void DDIndices_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            TextBox1.Text = "";
            string IDFieldType = "";
            Session["DDindice"] = DDIndices.SelectedValue.ToString();
            DataTable datos = (DataTable)Session["datosDDIndices"];
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                if (Convert.ToInt16(DDIndices.SelectedValue) == Convert.ToInt16(datos.Rows[i]["IDField"]))
                {
                    IDFieldType = datos.Rows[i]["IDFieldType"].ToString();
                    break;
                }
            }


            DataTable dt = new DataTable();
            dt.Columns.Add("0");
            dt.Columns.Add("1");
            switch (Convert.ToInt16(IDFieldType))
            {
                case 18:
                case 19:
                case 20:
                    dt.Rows.Add(CreateRow("igual a", "=", dt));
                    dt.Rows.Add(CreateRow("mayor a", ">", dt));
                    dt.Rows.Add(CreateRow("menor a", "<", dt));
                    dt.Rows.Add(CreateRow("mayor o igual a", ">=", dt));
                    dt.Rows.Add(CreateRow("menor o igual a", "<=", dt));
                    dt.Rows.Add(CreateRow("distinto a", "!=", dt));


                    DDReglas.DataSource = dt;
                    DDReglas.DataValueField = "0";
                    DDReglas.DataTextField = "1";

                    DDReglas.DataBind();
                    Session["validacionFiltro"] = "numeros";

                    break;
                case 17:
                    dt.Rows.Add(CreateRow("parecido", "like", dt));
                    dt.Rows.Add(CreateRow("igual", "igual", dt));
                    dt.Rows.Add(CreateRow("distinto", "!=", dt));

                    DDReglas.DataSource = dt;
                    DDReglas.DataValueField = "0";
                    DDReglas.DataTextField = "1";

                    DDReglas.DataBind();
                    Session["validacionFiltro"] = "letras";

                    break;

            }
        }
        catch (Exception ex)
        {
        }
    }
    DataRow CreateRow(String Text, String Value, DataTable dt)
    {
        DataRow dr = dt.NewRow();
        dr[1] = Text;
        dr[0] = Value;
        return dr;

    }
    protected void filtrosGridView_SelectedIndexChanged(object sender, EventArgs e)//quitar filtros
    {
        try
        {
            datos = (DataTable)Session["dtfiltro"];
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                if (Convert.ToInt16(datos.Rows[i]["id"]) == Convert.ToInt16(filtrosGridView.DataKeys[filtrosGridView.SelectedIndex][0]))
                {
                    datos.Rows[i].Delete();
                    datos.AcceptChanges();
                    break;
                }
            }
            Session["dtfiltro"] = datos;
            filtrosGridView.DataSource = datos;
            filtrosGridView.DataBind();
            if (datos.Rows.Count < 6) Panel3.ScrollBars = ScrollBars.None;


        }
        catch (Exception ex)
        {
        }

    }

    protected void ImageButton6_Click(object sender, ImageClickEventArgs e)//primero
    {
        Session["navigator"] = "primero";
        GridView2_SelectedIndexChanged(null, null);

    }
    protected void ImageButton8_Click(object sender, ImageClickEventArgs e)//anterior
    {
        Session["navigator"] = "anterior";
        GridView2_SelectedIndexChanged(null, null);

    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)//siguiente
    {
        Session["navigator"] = "siguiente";
        GridView2_SelectedIndexChanged(null, null);
    }
    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)//ultimo
    {
        Session["navigator"] = "ultimo";
        GridView2_SelectedIndexChanged(null, null);

    }

    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(Session["gridSeleccion"]) == 1)//esto es para cuando se selecciona otra pagina no entre en toda la logica del selecindexchange
        {
            try
            {
                if (sender == null)
                {
                    int indice = 0;
                    switch (Session["navigator"].ToString())
                    {
                        case "primero":
                            indice = 0;
                            break;
                        case "anterior":
                            indice = Convert.ToInt16(Session["indiceGr"]) - 1;
                            break;
                        case "siguiente":
                            indice = Convert.ToInt16(Session["indiceGr"]) + 1;
                            break;
                        case "ultimo":
                            indice = GridView2.Rows.Count - 1;
                            break;
                    }
                    Session["idExport"] = GridView2.DataKeys[indice][0].ToString();
                    Session["FileNAme"] = GridView2.DataKeys[indice][1].ToString();
                    TextBox1.Text = Convert.ToString(indice + 1);
                    //TextBox6.Text = GridView2.Rows.Count.ToString();
                    Session["indiceGr"] = indice;
                }
                else
                {
                    //TextBox5.Text = Convert.ToString(GridView2.SelectedIndex + 1);
                    //TextBox6.Text = GridView2.Rows.Count.ToString(); 
                    Session["idExport"] = GridView2.DataKeys[GridView2.SelectedIndex][0].ToString();
                    Session["FileNAme"] = GridView2.DataKeys[GridView2.SelectedIndex][1].ToString();
                    Session["indiceGr"] = GridView2.SelectedIndex;

                    //ver error de fecha
                    //Boolean Veri = VerificarOpenFirma(Convert.ToInt32(Session["idExport"]), Convert.ToString(Session["table"]));
                    Boolean Veri = true;

                    //Obtener los valores de la base de datos como ser archivo a firmar, con que certificado, etc
                    dsConsultingTableAdapters.AG_DigitalSignTableAdapter taDigitalSign = new dsConsultingTableAdapters.AG_DigitalSignTableAdapter();
                    dsConsulting.AG_DigitalSignDataTable dtDigitalSign = new dsConsulting.AG_DigitalSignDataTable();
                    int id_UsuarioActual = Convert.ToInt32(Session["idUsuario"].ToString());
                    taDigitalSign.FillDigitalSignByIdUsuario(dtDigitalSign, id_UsuarioActual);

                    if (dtDigitalSign.Rows.Count > 0)
                    {

                        dsConsulting.AG_DigitalSignRow drDigitalSign = dtDigitalSign[0];

                        //Guardar parametros en sesiones para leerlas por el applet
                        Session["certificado"] = drDigitalSign.idCertificado;
                        Session["motivo"] = drDigitalSign.DicReason;
                        Session["ubicacion"] = drDigitalSign.DicLocation;
                        Session["contacto"] = drDigitalSign.DicContact;
                        Session["fullPathFileInServer"] = Session["FileNAme"].ToString(); //La ruta del archivo en el file system del servidor
                        Session["pathImagenFirma"] = "";

                        if (File.Exists(drDigitalSign.ImageSign.ToString()))
                        {
                            FileInfo fiImagen = new FileInfo(drDigitalSign.ImageSign.ToString());
                            Session["pathImagenFirma"] = copyFileToTmpFolder(drDigitalSign.ImageSign, "/docsTmp/" + fiImagen.Name); //
                        }

                        if (File.Exists(Session["FileNAme"].ToString()))
                        {

                            if (Veri == true)
                            {
                                FileInfo fiPDF = new FileInfo(Session["FileNAme"].ToString());
                                Session["pathPDF"] = copyFileToTmpFolder(Session["FileNAme"].ToString(), "/docsTmp/" + fiPDF.Name);  //La ruta del archivo en el sitio web
                                Response.Redirect("fFirmaDigital.aspx");

                            }
                            else
                            {
                                MostrarAJAXMessage(this, "El Documento se encuentra actualmente abierto. Intente mas tarde");
                            }
                        }
                        else
                        {
                            MostrarAJAXMessage(this, "No se econtro el documento.");
                        }
                    }

                    else
                    {
                        MostrarAJAXMessage(this, "No se encontro la firma. Configure una firma para este usuario antes de seguir.");
                    }
                }
            }
            catch (Exception ex)
            {

                MostrarAJAXMessage(this, ex.Message.ToString());
            }
            //string scriptStr = "window.open('fPdf.aspx','','width=385,height=350,top=0,left=0,resizable=yes');";
            //ScriptManager.RegisterStartupScript(((Control)sender), typeof(string), "", scriptStr, true);
            Session["gridSeleccion"] = 0;//esto es para cuando se selecciona otra pagina no entre en toda la logica del selecindexchange
        }
    }
    /// <summary>
    /// Copia un archivo del servidor a una catpeta en el sitio para que pueda ser descargado por el applet
    /// </summary>
    /// <param name="localFile">Documento en el servidor donde esta el IIS de la app.</param>
    /// <param name="serverPathFile">Camino virtual del archivo en el sitio. ej: /docsTmp/Factura0087.pdf</param>
    /// <returns>Return = Path -> La copia fue correcta; Return = Error -> Error</returns>
    private String copyFileToTmpFolder(String localFile, String serverPathFile)
    {
        String path = "";
        try
        {
            String fileInIIS = Server.MapPath("../" + serverPathFile);
            System.IO.File.Copy(localFile, fileInIIS, true);
            System.IO.FileInfo fi = new System.IO.FileInfo(fileInIIS);
            path = Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath + serverPathFile;
        }
        catch (Exception e)
        {
            throw e;
        }
        return path;
    }
    protected void ImageButton14_Click(object sender, ImageClickEventArgs e)//Buscar por filtro
    {
        try
        {
            string exportTable = Session["table"].ToString();
            
            string consulta = "";
            string selectQuery = " IDExport, FileName ";
            int idDocumentType = int.Parse(exportTable.Substring(exportTable.Length - 4));


            var indices = negocio.getIndices(idDocumentType);

            for (int i = 1; i < indices.Rows.Count; i++)
            {
                selectQuery += ", " + indices.Rows[i]["FieldName"];
            }


            if (Convert.ToInt16(Session["gridSeleccion"]) == 0)//esto es cuando se lista todos no hace falta generar filtros
            {
                string filtro = "";
                datos = (DataTable)Session["dtfiltro"];
                for (int i = 0; i < datos.Rows.Count; i++)
                {
                    if (filtro == "")
                        filtro = datos.Rows[i]["filtro"].ToString();
                    else
                        filtro = filtro + " and " + datos.Rows[i]["filtro"].ToString();
                }
                consulta = "select " + selectQuery + " from " + exportTable + " where  " + filtro + "";
            }
            else
                consulta = "select " + selectQuery + " from " + exportTable + " ";

            datos = new DataTable();
            datos = negocio.Documentos(consulta);
            Session["consulta"] = consulta;
            //for (int i = 2; i < 12; i++)
            //{
            //        datos.Columns.RemoveAt(2);
            //        datos.AcceptChanges();
            //}


            /**************** Remover las Columnas de Estado y Fecha de FirmaPDF ***********************/
            
            //datos.Columns.RemoveAt(datos.Columns.Count-1);
            //datos.AcceptChanges();

            //datos.Columns.RemoveAt(datos.Columns.Count - 1);
            //datos.AcceptChanges();

            Session["dtDocumentos"] = datos;

            /*************************************************************/
            BoundField lobColumnBound;//= new BoundField();
            if (datos != null)
                if (datos.Rows.Count != 0)
                {
                    //GridView2.Columns.Clear();

                    int cantidadColumnas = GridView2.Columns.Count;

                    //for (int j = 1; j < cantidadColumnas; j++)
                    //{
                    //    lobColumnBound = (BoundField)GridView2.Columns[1];
                    //    GridView2.Columns.Remove(lobColumnBound);
                    //}

                    GridView2.DataSource = datos;
                    if (datos.Rows.Count > 4) Panel4.ScrollBars = ScrollBars.Vertical;


                    for (int i = 0; i < datos.Columns.Count; i++)
                    {
                        lobColumnBound = new BoundField();
                        lobColumnBound.DataField = datos.Columns[i].ColumnName;  // del Origen de datos
                        lobColumnBound.HeaderText = datos.Columns[i].ColumnName;
                        GridView2.Columns.Add(lobColumnBound);
                    }

                    //columnFirma
                    //ButtonField btnField = new ButtonField();
                    //btnField.HeaderText = "Firma";
                    //btnField.CommandName = "Select";
                    //GridView2.Columns.Add(btnField);

                    GridView2.DataBind();
                    Session["navigator"] = "primero";
                    Session["gridSeleccion"] = 0;
                }
                else
                    MostrarAJAXMessage(this, "No se encontraron registros para el conjunto de filtros que indico...");

        }
        catch (Exception ex)
        {
        }

    }
    protected void ImageButton11_Click(object sender, ImageClickEventArgs e)//guardar la consulta
    {
        try
        {
            if (Convert.ToString(Session["consulta"]) != "")
            {
                if (TextBox3.Text != "")
                {
                    negocio.guardarConsulta(TextBox3.Text, Session["consulta"].ToString(), Convert.ToInt16(Session["idUsuario"]));
                    MostrarAJAXMessage(this, "La consulta fue guardada sastifactoriamente...");
                }
                else
                {
                    MostrarAJAXMessage(this, "Escriba un nombre para la consulta actual...");
                    return;
                }
            }
            else
                MostrarAJAXMessage(this, "Genere una consulta para poder guardarla...");

        }
        catch (Exception ex)
        {
        }
    }
    protected void ImageButton15_Click(object sender, ImageClickEventArgs e)//Ejecutar Consulta
    {
        try
        {
            //GridView2.Columns.Clear();

            string filtro = "";
            int posWhere = 0;
            DataRow fila;
            datos = (DataTable)Session["consultaRecuperada"];
            if (datos != null)
                if (datos.Rows.Count != 0)
                {

                    filtro = datos.Rows[DropDownList3.SelectedIndex - 1]["queryStatement"].ToString();

                    /*******************Ejecuto la consulta******************************/
                    datos = negocio.Documentos(filtro);
                    for (int i = 2; i < 13; i++)
                    {
                        datos.Columns.RemoveAt(2);
                        datos.AcceptChanges();
                    }
                    Session["dtDocumentos"] = datos;

                    /*************************************************************/
                    BoundField lobColumnBound;//= new BoundField();
                    int cantidadColumnas = GridView2.Columns.Count;
                    if (datos != null)
                        if (datos.Rows.Count != 0)
                        {

                            //for (int j = 1; j < cantidadColumnas; j++)
                            //{
                            //    lobColumnBound = (BoundField)GridView2.Columns[1];
                            //    GridView2.Columns.Remove(lobColumnBound);
                            //}
                            GridView2.DataSource = datos;
                            if (datos.Rows.Count > 4) Panel4.ScrollBars = ScrollBars.Vertical;

                            for (int i = 2; i < datos.Columns.Count; i++)
                            {
                                lobColumnBound = new BoundField();
                                lobColumnBound.DataField = datos.Columns[i].ColumnName;  // del Origen de datos
                                lobColumnBound.HeaderText = datos.Columns[i].ColumnName;
                                GridView2.Columns.Add(lobColumnBound);
                            }
                            GridView2.DataBind();
                            Session["navigator"] = "primero";
                            //TextBox6.Text = GridView2.Rows.Count.ToString();
                        }



                    posWhere = filtro.IndexOf("where");
                    filtro = filtro.Substring(posWhere + 6);
                    /*******desarmos y cargo los filtros para mostrar como esta la consulta**********/
                    filtro = filtro.Replace(" and ", " , ");
                    string[] arregloFiltro = filtro.Split(',');
                    string mostrarFiltro = "", operacion = "";
                    int find = 0, findRtrim = 0, findOper = 0;

                    DataTable dtfiltros = new DataTable();
                    dtfiltros.Columns.Add("id");
                    dtfiltros.Columns.Add("mostrar");
                    if (arregloFiltro.Length != 0)
                    {
                        for (int i = 0; i < arregloFiltro.Length; i++)
                        {
                            //transformo las sentencias por text legible para el usuario
                            findRtrim = arregloFiltro[i].IndexOf("rtrim");//si lo encuentra sig q es una cadena
                            if (findRtrim != -1)
                            {
                                mostrarFiltro = "";
                                find = arregloFiltro[i].IndexOf("%");//si existe este carcater es parecido sio igual
                                if (find != 0)//encontro un %
                                    mostrarFiltro = arregloFiltro[i].Replace("like", "parecido a");
                                else
                                    mostrarFiltro = arregloFiltro[i].Replace("like", "igual a");

                                mostrarFiltro = mostrarFiltro.Replace("rtrim", " ");
                                mostrarFiltro = mostrarFiltro.Replace("(", "");
                                mostrarFiltro = mostrarFiltro.Replace(")", "");
                                mostrarFiltro = mostrarFiltro.Replace("%", "");
                            }
                            else
                            {
                                findOper = arregloFiltro[i].IndexOf("=");
                                if (findOper != -1) mostrarFiltro = arregloFiltro[i].Replace("=", " igual que");
                                findOper = arregloFiltro[i].IndexOf("<");
                                if (findOper != -1) mostrarFiltro = arregloFiltro[i].Replace("<", "menor que");
                                findOper = arregloFiltro[i].IndexOf(">");
                                if (findOper != -1) mostrarFiltro = arregloFiltro[i].Replace(">", "mayor que");
                                findOper = arregloFiltro[i].IndexOf(">=");
                                if (findOper != -1) mostrarFiltro = arregloFiltro[i].Replace(">=", "mayor igual que");
                                findOper = arregloFiltro[i].IndexOf("<=");
                                if (findOper != -1) mostrarFiltro = arregloFiltro[i].Replace("<=", "menor igual que");
                                findOper = arregloFiltro[i].IndexOf("!=");
                                if (findOper != -1) mostrarFiltro = arregloFiltro[i].Replace("!=", "distinto que");


                            }
                            fila = dtfiltros.NewRow();
                            fila["mostrar"] = mostrarFiltro;
                            fila["id"] = "1";
                            dtfiltros.Rows.Add(fila);
                            dtfiltros.AcceptChanges();
                        }

                        filtrosGridView.DataSource = dtfiltros;
                        filtrosGridView.DataBind();
                        filtrosGridView.Enabled = false;
                    }


                }

        }
        catch (Exception ex)
        {
        }
    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {

            //TRAE EL TOTAL DE PAGINAS
            datos = (DataTable)Session["dtDocumentos"];

            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    LinkButton link = new LinkButton();
            //    link.Text = "Firmar";
            //    link.CommandArgument = datos.Rows[e.Row.RowIndex][1].ToString();
            //    link.Click += new EventHandler(GridView2_SelectedIndexChanged);
            //    e.Row.Cells[4].Controls.Add(link);
            //}

            if (e.Row.RowType == DataControlRowType.Pager && GridView2.DataSource != null)
            {
                //TextBox text4 = (TextBox)e.Row.FindControl("TextBox4");
                //TextBox text5 = (TextBox)e.Row.FindControl("TextBox5");
                //TextBox _TotalPags = (TextBox)e.Row.FindControl("TextBox6");
                //_TotalPags.Text = datos.Rows.Count.ToString();// datos.Rows.Count.ToString();
                //text4.Text = GridView2.PageCount.ToString();
                //text5.Text = Convert.ToString(GridView2.PageIndex + 1);

                ////LLENA LA LISTA CON EL NUMERO DE PAGINAS
                //DropDownList list = e.Row.FindControl("paginasDropDownList");
                //for (int i = 1; i <= Convert.ToInt32(GridViewDatos.PageCount); i++)
                //{
                //    list.Items.Add(i.ToString());
                //}
                //list.SelectedValue = GridViewDatos.PageIndex + 1;
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
    {
        Session["gridSeleccion"] = 1;

    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        GridView2.DataSource = (DataTable)Session["dtDocumentos"];
        GridView2.DataBind();
    }
    protected void ImageButton13_Click(object sender, ImageClickEventArgs e)//listar todos
    {
        try
        {
            if (this.GridView2.Rows.Count == 0)
            {

                if (Session["document"] != null)
                {
                    if (DropDownList1.SelectedValue != "0")
                    {
                        DataTable document = (DataTable)Session["document"];
                        for (int i = 0; i < document.Rows.Count; i++)
                        {
                            if (Convert.ToInt16(document.Rows[i]["IDDocumentType"]) == Convert.ToInt16(DropDownList1.SelectedValue))
                            {
                                Session["table"] = document.Rows[i]["ExportTable"].ToString();
                                break;
                            }
                        }
                        Session["gridSeleccion"] = 1;//esto es cuando se lista todos no hace falta generar filtros
                        ImageButton14_Click(null, null);
                    }
                    else
                    {
                        MostrarAJAXMessage(this, "Seleccione un tipo de documento para poder realizar la busqueda");
                    }

                }
                else
                {
                    MostrarAJAXMessage(this, "Seleccione un tipo de documento para poder realizar la busqueda");
                }

            }
            else
                return;
        }
        catch (Exception ex)
        {
        }

    }
    protected void ImageButton12_Click(object sender, ImageClickEventArgs e)//limpiar todo
    {
        try
        {
            //GridView2.Columns.Clear();
            filtrosGridView.DataSource = null;
            filtrosGridView.DataBind();
            GridView2.DataSource = null;
            GridView2.DataBind();
            DropDownList1.SelectedValue = "0";
            DropDownList1_SelectedIndexChanged(null, null);
            Session["dtfiltro"] = null;
            Session["consulta"] = null;
            Panel3.ScrollBars = ScrollBars.None;
        }
        catch (Exception ex)
        {
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

    protected void ImageButtonVolver_Click(object sender, ImageClickEventArgs e)
    {
        this.Response.Redirect("fIngreso.aspx");
    }

    protected Boolean VerificarOpenFirma(int IdExport, string Tabla)
    {
        Boolean salida = false;

        DataTable Dt = new DataTable();
        string Consulta = "Select * from " + Tabla + " Where IDExport = " + IdExport;
        Dt = negocio.Documentos(Consulta);

        if (Dt.Rows.Count > 0)
        {

            if (Convert.ToBoolean(Dt.Rows[0]["Estado"]) == false)
            {

                negocio sql_ = new negocio();
                sql_.ActualizarEstadoDocument(Convert.ToString(Tabla), Convert.ToInt32(IdExport), true);
                salida = true;

            }

        }
        else
        {
            salida = false;
        }

        return salida;

    }

}
