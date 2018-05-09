using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using System.Collections;

namespace finalProject
{
    public static class DAL
    {
        #region Private Members

        private static string appName = "finalProject";
        //public static string ConnSTR = "Data Source='XXX.XXX.XXX';Initial Catalog='database name';User ID='user name';Password='pass'";
        private static string ConnSTR = @"Data Source='DESKTOP-M4GSS92\PROJECTP';Initial Catalog='Project';Integrated Security=True;";
        static List<SqlParameter> BuildParameters(Hashtable prms)
        {
            List<SqlParameter> sqlparams = new List<SqlParameter>();
            SqlParameter[] res = new SqlParameter[prms.Count];
            foreach (object key in prms.Keys)
            {
                SqlParameter p = new SqlParameter(key.ToString(), prms[key].ToString());
                sqlparams.Add(p);
            }
            return sqlparams;
        }

        #endregion

        #region Public Members

        public static void AddDebugRowToDB(string className, string method, string msg)
        {
            RunBatch("insert into [dbo].[tbl_Trivia_Debug] (class, method, msg) values('" + className + "','" + method + "',N'" + msg.Replace("'", "''") + "')", "Trivia2017->DAL.cs->AddDebugRowToDB()");
        }

        public static void ReportError(string className, string Method, string ex, string trace, string extradata)
        {

            SqlConnection cn = new SqlConnection(ConnSTR);
            SqlCommand cmd = null;
            try
            {
                //clsMail.SendMail("nimrod.rotner@gmail.com", "Trivia DAL Error", "N'" + className + "',N'" + Method + "',N'" + ex + "',N'" + trace + "',N'" + extradata + "'");
                cn.Open();
                cmd = new SqlCommand("insert into tbl_Exceptions(AppName,ClassName,Method,ExceptionDescription,ExceptionTrace,ExtraData)" +
                                        " values('" + appName + "',N'" + className + "',N'" + Method + "',N'" + ex + "',N'" + trace + "',N'" + extradata + "')", cn);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            catch
            {
            }
            finally
            {
                cn.Close();
                GC.Collect();
            }
        }


        public static DataSet GetData(string sp_name, Hashtable prms, string CalledBy)
        {
            SqlConnection cn = new SqlConnection(ConnSTR);
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            DataSet ds = new DataSet();
            try
            {
                cn.Open();
                cmd = new SqlCommand(sp_name, cn);
                cmd.CommandType = CommandType.StoredProcedure;

                List<SqlParameter> p_arr = BuildParameters(prms);
                foreach (SqlParameter p in p_arr)
                    cmd.Parameters.Add(p);

                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                ReportError("DAL", "GetData()", ex.Message, ex.StackTrace, "Prcedure: " + sp_name + " Called By: " + CalledBy);
                ds.Dispose();
                return null;
            }
            finally
            {
                cn.Close();
                //cmd.Dispose();
                GC.Collect();
            }
        }
        public static DataSet GetData(string query, string CalledBy)
        {
            SqlConnection cn = new SqlConnection(ConnSTR);
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            DataSet ds = new DataSet();
            try
            {
                cn.Open();
                cmd = new SqlCommand(query, cn);
                cmd.CommandType = CommandType.Text;

                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                ReportError("DAL", "GetData()", ex.Message, ex.StackTrace, "Query: " + query + " Called By: " + CalledBy);
                return null;
            }
            finally
            {
                cn.Close();
                GC.Collect();
            }
        }
        public static bool RunBatch(string sp_name, Hashtable prms, string CalledBy)
        {
            //if (sp_name == "sp_Trivia_UserBoughtCredits")
            //{
            //    AddDebugRowToDB("DAL.cs", "RunBatch", "sp_Trivia_UserBoughtCredits is about to start");
            //}
            SqlConnection cn = new SqlConnection(ConnSTR);
            SqlCommand cmd = null;
            try
            {
                cn.Open();
                cmd = new SqlCommand(sp_name, cn);
                cmd.CommandType = CommandType.StoredProcedure;

                List<SqlParameter> p_arr = BuildParameters(prms);
                foreach (SqlParameter p in p_arr)
                    cmd.Parameters.Add(p);

                cmd.ExecuteNonQuery();
                //if(sp_name== "sp_Trivia_UserBoughtCredits")
                //{
                //    AddDebugRowToDB("DAL.cs", "RunBatch", "sp_Trivia_UserBoughtCredits succesfully finished");
                //}
                return true;
            }
            catch (Exception ex)
            {
                AddDebugRowToDB("DAL.cs", "RunBatch", "Exception: " + ex.Message);
                ReportError("DAL", "RunBatch()", ex.Message, ex.StackTrace, "Prcedure: " + sp_name + " Called By: " + CalledBy);
                return false;
            }
            finally
            {
                cn.Close();
                cmd.Dispose();
                GC.Collect();
            }
        }
        public static bool RunBatch(string sql, string CalledBy)
        {
            //if(sql.StartsWith("update [dbo].[tbl_Trivia_Paypal_responses]"))
            //{
            //    AddDebugRowToDB("DAL.cs", "RunBatch()", sql);
            //}
            SqlConnection cn = new SqlConnection(ConnSTR);
            SqlCommand cmd = null;
            try
            {
                cn.Open();
                cmd = new SqlCommand(sql, cn);
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                AddDebugRowToDB("DAL", "RunBatch()", "Exception: " + ex.Message);
                ReportError("DAL", "RunBatch(sql)", ex.Message, ex.StackTrace, "Query: " + sql + " Called By: " + CalledBy);
                return false;
            }
            finally
            {
                cn.Close();
                cmd.Dispose();
                GC.Collect();
            }
        }
        public static bool RunBatch(string sp_name, Hashtable prms, ref Hashtable outputParams, SqlDbType outputType, string CalledBy)
        {
            SqlConnection cn = new SqlConnection(ConnSTR);
            SqlCommand cmd = null;
            try
            {
                cn.Open();
                cmd = new SqlCommand(sp_name, cn);
                cmd.CommandType = CommandType.StoredProcedure;

                List<SqlParameter> p_arr = BuildParameters(prms);
                foreach (SqlParameter p in p_arr)
                    cmd.Parameters.Add(p);

                List<SqlParameter> p_arr_output = BuildParameters(outputParams);
                foreach (SqlParameter p in p_arr_output)
                {
                    p.Direction = ParameterDirection.Output;
                    p.SqlDbType = outputType;
                    if (outputType == SqlDbType.VarChar)
                    {
                        p.Size = 50;
                    }
                    cmd.Parameters.Add(p);
                }

                cmd.ExecuteNonQuery();

                foreach (SqlParameter ouputParam in cmd.Parameters)
                {
                    if (ouputParam.Direction == ParameterDirection.Output)
                        outputParams[ouputParam.ParameterName] = ouputParam.Value;
                }

                return true;
            }
            catch (Exception ex)
            {
                ReportError("DAL", "RunBatch()", ex.Message, ex.StackTrace, "Prcedure: " + sp_name + " Called By: " + CalledBy);
                return false;
            }
            finally
            {
                cn.Close();
                cmd.Dispose();
                GC.Collect();
            }
        }
        //public static Hashtable RunBatch(string sp_name, Hashtable prms, ref Hashtable outputParams, SqlDbType outputType, string CalledBy)
        //{
        //    SqlConnection cn = new SqlConnection(ConnSTR);
        //    SqlCommand cmd = null;
        //    try
        //    {
        //        cn.Open();
        //        cmd = new SqlCommand(sp_name, cn);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        List<SqlParameter> p_arr = BuildParameters(prms);
        //        foreach (SqlParameter p in p_arr)
        //            cmd.Parameters.Add(p);

        //        List<SqlParameter> p_arr_output = BuildParameters(outputParams);
        //        foreach (SqlParameter p in p_arr_output)
        //        {
        //            p.Direction = ParameterDirection.Output;
        //            p.SqlDbType = outputType;
        //            if (outputType == SqlDbType.VarChar)
        //            {
        //                p.Size = 50;
        //            }
        //            cmd.Parameters.Add(p);
        //        }

        //        cmd.ExecuteNonQuery();

        //        Hashtable res = new Hashtable();
        //        foreach (SqlParameter ouputParam in cmd.Parameters)
        //        {
        //            if (ouputParam.Direction == ParameterDirection.Output)
        //                res.Add(ouputParam.ParameterName, ouputParam.Value);
        //        }

        //        return res;
        //    }
        //    catch (Exception ex)
        //    {
        //        ReportError("DAL", "RunBatch()", ex.Message, ex.StackTrace, "Prcedure: " + sp_name + " Called By: " + CalledBy);
        //        return null;
        //    }
        //    finally
        //    {
        //        cn.Close();
        //        cmd.Dispose();
        //        GC.Collect();
        //    }
        //}

        public static void WriteLogToDB(string subject, string description)
        {
            string currDateSTR = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + " " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
            RunBatch("insert into tbl_AppLOGS(appName,subject,logDesc,insertDate) values('" + appName + "','" + subject + "','" + description + "','" + currDateSTR + "')", "DAL->WriteLogToDB()");
        }
        #endregion


    }
}
