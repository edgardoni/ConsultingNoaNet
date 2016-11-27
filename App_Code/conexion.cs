using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

//namespace Lotes.ClasesDAO
//{
//}
 class conexion
{
    static public DataSet storeGenerico(string store_, System.Collections.Generic.Dictionary<string, object> parametros)
    {
        try
        {
            string conexion_ = ConfigurationManager.ConnectionStrings["RepProduccionConnectionString"].ConnectionString;

            SqlDataAdapter daGenerico = new SqlDataAdapter();

            DataSet dsGenerico = new DataSet();

            SqlCommand cmOrden;

            using (SqlConnection cConexion = new SqlConnection(conexion_))
            {


                cmOrden = cConexion.CreateCommand();

                cmOrden.Connection = cConexion;

                cmOrden.CommandType = CommandType.StoredProcedure;

                cmOrden.CommandText = store_;

                if (parametros != null && parametros.Count > 0)
                {
                    foreach (System.Collections.Generic.KeyValuePair<string, object> parametro in parametros)
                    {
                        cmOrden.Parameters.AddWithValue(parametro.Key.ToString(), parametro.Value);
                    }
                }

                cmOrden.Connection.Open();

                daGenerico.SelectCommand = cmOrden;

                daGenerico.Fill(dsGenerico);

                return dsGenerico;

            }
        }
        catch (Exception ex)
        {
            return null;
        }
    }



}
