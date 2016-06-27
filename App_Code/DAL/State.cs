using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace ChadCarter.CodeSample.DAL
{
    /// <summary>
    /// Summary description for State
    /// </summary>
    // Chad Was here...
    public class State
    {
        #region Fields_Properties
        protected string conn_String = WebConfigurationManager.ConnectionStrings["code_sample"].ToString(); 
        #endregion
        #region Methods
        public List<ChadCarter.CodeSample.BLL.State> SelectAllState()
        {
            using (SqlConnection conn = new SqlConnection(conn_String))
            {
                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand("dbo.usp_state_select_all", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    return convertState(reader);
                }
                catch (Exception ex)
                {
                    // Error Routine Here
                    return null;
                }
            }
        } 
        #endregion
        #region Helpers
        public List<ChadCarter.CodeSample.BLL.State> convertState(SqlDataReader reader)
        {
            var list = new List<ChadCarter.CodeSample.BLL.State>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    list.Add(new ChadCarter.CodeSample.BLL.State(Convert.ToInt32(reader["state_id"]),
                        reader["state_short"].ToString(), reader["state_long"].ToString()));
                }
            }
            return list;
        }
        #endregion
    }
}