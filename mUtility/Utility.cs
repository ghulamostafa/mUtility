using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace mUtility
{
    class Utility
    {
        string SPConstr = "";

        /// <summary>
        /// Pass in the complete connection string for the database.
        /// </summary>
        /// <param name="connString"></param>
        public Utility(string connString)
        {
            SPConstr = connString;
        }

        #region Database Stored Procedure Related

        /// <summary>
        /// Used for calling a stored procedure for inserting or updating in the database
        /// </summary>
        /// <param name="_procedure">Stored Procedure name</param>
        /// <param name="_action">This is to what action to be performed</param>
        /// <param name="result">Output parameter result. Integer</param>
        /// <param name="message">Output parameter message. String</param>
        /// <param name="_paramaters">paramWithValues array</param>
        /// <returns></returns>
        public bool runProcedureInsert(string _procedure, string _action, ref int result, ref string message, params paramWithValues[] _paramaters)
        {
            using (SqlConnection con = new SqlConnection(SPConstr))
            {
                using (SqlCommand cmd = new SqlCommand(_procedure))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", _action);
                    cmd.Parameters.Add("@result", SqlDbType.BigInt).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@message", SqlDbType.NVarChar, 150).Direction = ParameterDirection.Output;

                    foreach (paramWithValues item in _paramaters)
                    {
                        if (item.DataType == "DataTable")
                            cmd.Parameters.AddWithValue(item.Param, item.theValueDT);
                        else
                            cmd.Parameters.AddWithValue(item.Param, item.theValue);
                    }

                    cmd.Connection = con;
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        //Get the result output here.
                        result = int.Parse(cmd.Parameters["@result"].Value.ToString());
                        message = cmd.Parameters["@message"].Value.ToString();
                        //If Succeeds
                        Console.WriteLine("No try error.");
                        return true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                        //If the result is -1 then there have been an exception at the code level not SQL.
                        result = -1;
                        message = e.ToString();
                        //Error to show
                        return false;
                    }
                    finally
                    {
                    }

                }
            }
        }

        /// <summary>
        /// Used for calling a stored procedure for inserting or updating in the database
        /// </summary>
        /// <param name="_procedure">Stored Procedure name</param>
        /// <param name="_action">This is to what action to be performed</param>
        /// <param name="result">Output parameter result. Integer</param>
        /// <param name="message">Output parameter message. String</param>
        /// <param name="additional">Output parameter additional to message. String</param>
        /// <param name="_paramaters">paramWithValues array</param>
        /// <returns></returns>
        public bool runProcedureInsert(string _procedure, string _action, ref int result, ref string message, ref string additional, params paramWithValues[] _paramaters)
        {
            using (SqlConnection con = new SqlConnection(SPConstr))
            {
                using (SqlCommand cmd = new SqlCommand(_procedure))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", _action);
                    cmd.Parameters.Add("@result", SqlDbType.BigInt).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@message", SqlDbType.NVarChar, 150).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@additional", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;

                    foreach (paramWithValues item in _paramaters)
                    {
                        if (item.DataType == "DataTable")
                            cmd.Parameters.AddWithValue(item.Param, item.theValueDT);
                        else
                            cmd.Parameters.AddWithValue(item.Param, item.theValue);
                    }

                    cmd.Connection = con;
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        //Get the result output here.
                        result = int.Parse(cmd.Parameters["@result"].Value.ToString());
                        message = cmd.Parameters["@message"].Value.ToString();
                        additional = cmd.Parameters["@additional"].Value.ToString();
                        //If Succeeds
                        Console.WriteLine("No try error.");
                        return true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                        //If the result is -1 then there have been an exception at the code level not SQL.
                        result = -1;
                        message = e.ToString();
                        //Error to show
                        return false;
                    }
                    finally
                    {
                    }

                }
            }
        }

        /// <summary>
        /// Used for calling a stored procedure for selecting from database
        /// </summary>
        /// <param name="_procedure">Stored Procedure name</param>
        /// <param name="_action">This is to what action to be performed</param>
        /// <param name="result">Output parameter result. Integer</param>
        /// <param name="message">Output parameter message. String</param>
        /// <param name="_ds">Dataset containing multiple tables as a result of multiple select queries from database</param>
        /// <param name="_paramaters">paramWithValues array</param>
        /// <returns></returns>
        public bool runProcedureSelect(string _procedure, string _action, ref int result, ref string message, ref DataSet _ds, params paramWithValues[] _parameters)
        {
            using (SqlConnection con = new SqlConnection(SPConstr))
            {
                using (SqlCommand cmd = new SqlCommand(_procedure))
                {
                    cmd.Parameters.AddWithValue("@Action", _action);
                    cmd.Parameters.Add("@result", SqlDbType.BigInt).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@message", SqlDbType.NVarChar, 150).Direction = ParameterDirection.Output;
                    foreach (paramWithValues param in _parameters)
                    {
                        if (param.DataType == "DataTable")
                            cmd.Parameters.AddWithValue(param.Param, param.theValueDT);
                        else
                            cmd.Parameters.AddWithValue(param.Param, param.theValue);
                    }
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        sda.Fill(_ds);

                        result = int.Parse(cmd.Parameters["@result"].Value.ToString());
                        message = (string)cmd.Parameters["@message"].Value;
                    }
                }
                con.Close();
                //For Closing the con connection.
            }
            return false;
        }

        /// <summary>
        /// Used for calling a stored procedure for selecting from database
        /// </summary>
        /// <param name="_procedure">Stored Procedure name</param>
        /// <param name="_action">This is to what action to be performed</param>
        /// <param name="result">Output parameter result. Integer</param>
        /// <param name="message">Output parameter message. String</param>
        /// <param name="_paramaters">paramWithValues array</param>
        /// <returns></returns>
        public bool runProcedureSelect(string _procedure, string _action, ref int result, ref string message, params paramWithValues[] _parameters)
        {
            using (SqlConnection con = new SqlConnection(SPConstr))
            {
                using (SqlCommand cmd = new SqlCommand(_procedure))
                {
                    cmd.Parameters.AddWithValue("@Action", _action);
                    cmd.Parameters.Add("@result", SqlDbType.BigInt).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@message", SqlDbType.NVarChar, 150).Direction = ParameterDirection.Output;
                    foreach (paramWithValues param in _parameters)
                    {
                        if (param.DataType == "DataTable")
                            cmd.Parameters.AddWithValue(param.Param, param.theValueDT);
                        else
                            cmd.Parameters.AddWithValue(param.Param, param.theValue);
                    }
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();

                        result = int.Parse(cmd.Parameters["@result"].Value.ToString());
                        message = (string)cmd.Parameters["@message"].Value;
                    }
                }
                con.Close();
                //For Closing the con connection.
            }
            return false;
        }

        /// <summary>
        /// This method is used for converting a ResponseClass object into an XML form string for Mobile Services
        /// </summary>
        /// <param name="resp">ResponseClass object to be converted into a string</param>
        /// <returns></returns>
        internal string RespToXMLString(ResponseClass resp)
        {
            string strXML = "";
            strXML += "<response>";
            strXML += "<result>" + resp.Result + "</result>";
            strXML += "<message>" + resp.Message + "</message>";
            strXML += "<strVal>" + resp.StrVal + "</strVal>";
            strXML += "<Ds>";
            // Run a loop to loop all the Records in all of the Tables in the given DS
            int tc = 0; //DataTable count
            int rc = 0; //Row Count
            foreach (DataTable dt in resp.Ds.Tables)
            {
                // Beginning of a Data Table
                strXML += "<DataTable" + tc + ">";

                //DataView dv = dt.AsDataView();
                //foreach (DataColumn dc in dv)
                //{
                //    strXML += "<" + dc.ColumnName + ">";
                //    strXML += "";
                //    strXML += "</" + dc.ColumnName + ">";
                //}

                foreach (DataRow dr in dt.Rows)
                {
                    strXML += "<Item>";
                    DataRowView drv = dt.DefaultView[dt.Rows.IndexOf(dr)];
                    foreach (DataColumn dc in drv.DataView.ToTable().Columns)
                    {
                        //Beginning and Ending of a Column tag.
                        strXML += "<" + dc.ColumnName + ">";
                        strXML += dr[dc.ColumnName].ToString();
                        strXML += "</" + dc.ColumnName + ">";
                    }
                    strXML += "</Item>";
                    rc++; //Increment of Row Count
                }
                // Closing of a Data Table
                strXML += "</DataTable" + tc + ">";
                rc = 0;
                tc++; //Increment of Table Count
            }
            strXML += "</Ds>";
            strXML += "</response>";
            return strXML;
        }

        #endregion
    }
}
