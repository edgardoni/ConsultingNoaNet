﻿using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Reflection;
using System.Collections;

/// <summary>
/// Descripción breve de negocio
/// </summary>
[System.ComponentModel.DataObject]

public class negocio
{
    public negocio()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }


    static public DataTable Documentos(string consulta)
    {
        try
        {
            string conexion_ = ConfigurationManager.ConnectionStrings["DB_IndexColegioConnectionString"].ConnectionString;

            SqlDataAdapter daGenerico = new SqlDataAdapter();

            DataSet dsGenerico = new DataSet();

            SqlCommand cmOrden;

            using (SqlConnection cConexion = new SqlConnection(conexion_))
            {


                cmOrden = cConexion.CreateCommand();

                cmOrden.Connection = cConexion;

                cmOrden.CommandType = CommandType.Text;

                cmOrden.CommandText = consulta;

                cmOrden.Connection.Open();

                daGenerico.SelectCommand = cmOrden;

                daGenerico.Fill(dsGenerico);

                return dsGenerico.Tables[0];

            }
        }
        catch (Exception ex)
        {
            return null;
        }
    }


    public dsConsulting.AG_UsersDataTable getUsuario(string usuario, string contrasenia)
    {
        try
        {
            //conexion conexion1 = new conexion();           
            //DataTable datos = conexion1.Documentos("select * from AG_Users");

            dsConsultingTableAdapters.AG_UsersTableAdapter ta = new dsConsultingTableAdapters.AG_UsersTableAdapter();
            dsConsulting.AG_UsersDataTable dt = new dsConsulting.AG_UsersDataTable();

            //ta.FillByUserName(dt, usuario, contrasenia, "adminnoanet");
            ta.FillByUserName(dt, usuario);
            return dt;

        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public DataTable getTiposDocumentos(int usuario)
    {
        try
        {
            dsConsultingTableAdapters.AG_Groups1TableAdapter ta = new dsConsultingTableAdapters.AG_Groups1TableAdapter();
            dsConsulting.AG_Groups1DataTable dt = new dsConsulting.AG_Groups1DataTable();
            DataRow fila;
            DataTable datos = new DataTable();
            datos.Columns.Add("documentName");
            datos.Columns.Add("IDDocumentType");
            datos.Columns.Add("ExportTable");
            ta.Fill(dt, usuario);
            if (dt != null)
            {
                fila = datos.NewRow();
                fila["documentName"] = "Seleccionar";
                fila["IDDocumentType"] = "0";
                fila["ExportTable"] = "0";
                datos.Rows.Add(fila);
                datos.AcceptChanges();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    fila = datos.NewRow();
                    fila["documentName"] = dt.Rows[i]["documentName"];
                    fila["IDDocumentType"] = dt.Rows[i]["IDDocumentType"];
                    fila["ExportTable"] = dt.Rows[i]["ExportTable"];
                    datos.Rows.Add(fila);
                    datos.AcceptChanges();

                }
            }
            return datos;


        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public DataTable getIndices(int IDDocumentType)
    {
        try
        {
            dsConsultingTableAdapters.AG_FieldsTableAdapter ta = new dsConsultingTableAdapters.AG_FieldsTableAdapter();
            dsConsulting.AG_FieldsDataTable dt = new dsConsulting.AG_FieldsDataTable();
            DataRow fila;
            DataTable datos = new DataTable();
            datos.Columns.Add("IDField");
            //datos.Columns.Add("IDDocumentType");
            datos.Columns.Add("FieldName");
            datos.Columns.Add("IDFieldType");


            ta.Fill(dt, IDDocumentType);
            if (dt != null)
            {
                fila = datos.NewRow();
                fila["IDField"] = "0";
                //fila["IDDocumentType"] = "0";
                fila["IDFieldType"] = "0";
                fila["FieldName"] = "Seleccionar";

                datos.Rows.Add(fila);
                datos.AcceptChanges();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    fila = datos.NewRow();
                    fila["IDField"] = dt.Rows[i]["IDField"];
                    //fila["IDDocumentType"] = dt.Rows[i]["IDDocumentType"];
                    fila["IDFieldType"] = dt.Rows[i]["IDFieldType"];
                    fila["FieldName"] = dt.Rows[i]["FieldName"];
                    datos.Rows.Add(fila);
                    datos.AcceptChanges();

                }
            }

            return datos;

        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public void guardarConsulta(string nombreConsulta, string consulta, int idUsuario)
    {
        try
        {
            dsConsultingTableAdapters.AG_QueryTableAdapter ta = new dsConsultingTableAdapters.AG_QueryTableAdapter();

            ta.Insert(nombreConsulta, consulta, idUsuario);
            //return dt;

        }
        catch (Exception ex)
        {
            // return null;
        }
    }

    public DataTable getConsultas(int idUsuario)
    {
        try
        {
            dsConsultingTableAdapters.AG_QueryTableAdapter ta = new dsConsultingTableAdapters.AG_QueryTableAdapter();
            dsConsulting.AG_QueryDataTable dt = new dsConsulting.AG_QueryDataTable();

            ta.FillBy(dt, idUsuario);



            return dt;

        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public void ActualizarEstadoDocument(string tabla, int idExport, Boolean estado)
    {
        try
        {
            string sCon = ConfigurationManager.ConnectionStrings["DB_IndexColegioConnectionString"].ConnectionString;
            string sel;

            sel = "UPDATE " + tabla +
                " SET [Estado] = @Estado, [FechaOpenFilePdf] = @FechaOpen WHERE IDExport = @IdExport";

            using (SqlConnection con = new SqlConnection(sCon))
            {
                SqlCommand cmd = new SqlCommand(sel, con);
                cmd.Parameters.AddWithValue("@Estado", estado);
                cmd.Parameters.AddWithValue("@FechaOpen", DateTime.Now.ToString());
                cmd.Parameters.AddWithValue("@IdExport", idExport);
                con.Open();
                int t = cmd.ExecuteNonQuery();
                con.Close();

            }
        }
        catch (Exception)
        {

            throw;
        }

    }

    public void ActualizarDocumentosAbiertos()
    {
        string sCon = ConfigurationManager.ConnectionStrings["DB_IndexColegioConnectionString"].ConnectionString;
        string sel;

        try
        {

            /*Obtener todas las Export Data */
            sel = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME like '%AG_ExportData%'";
            using (SqlConnection con = new SqlConnection(sCon))
            {
                SqlCommand cmd = new SqlCommand(sel, con);
                SqlDataAdapter da;
                System.Data.DataTable dt = new System.Data.DataTable();
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    ActualizarDocumentosTimer(dt);
                }

            }
        }
        catch (Exception)
        {

            throw;
        }
    }

    public void ActualizarDocumentosTimer(DataTable dt)
    {
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            try
            {
                string sCon = ConfigurationManager.ConnectionStrings["DB_IndexColegioConnectionString"].ConnectionString;
                string sel;

                sel = "SELECT IDExport FROM " + dt.Rows[i][0] + " WHERE DATEDIFF(SECOND,[FechaOpenFilePdf],GETDATE()) > 600 AND [Estado] = 1";

                using (SqlConnection con = new SqlConnection(sCon))
                {
                    SqlCommand cmd = new SqlCommand(sel, con);
                    SqlDataAdapter da;
                    System.Data.DataTable dt2 = new System.Data.DataTable();
                    da = new SqlDataAdapter(cmd);
                    da.Fill(dt2);

                    if (dt2.Rows.Count > 0)
                    {
                        for (int j = 0; j < dt2.Rows.Count; j++)
                        {
                            ActualizarEstadoDocument(dt.Rows[i][0].ToString(), Convert.ToInt32(dt2.Rows[j][0]), false);

                        }

                    }

                }


            }
            catch (Exception)
            {

                throw;
            }
        }

    }

}
