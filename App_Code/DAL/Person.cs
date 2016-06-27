using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Text;
/// <summary>
/// Summary description for Person
/// </summary>
namespace ChadCarter.CodeSample.DAL
{
    public class Person<T> where T : ChadCarter.CodeSample.Base.Person
    {
        #region Fields_Properties
        protected string conn_String = WebConfigurationManager.ConnectionStrings["code_sample"].ToString();
        StringBuilder errorMessages = new StringBuilder();
        #endregion

        #region Constructors
        public Person() { }
        #endregion

        #region Methods
        public List<T> SelectAllPeople()
        {
            using (SqlConnection conn = new SqlConnection(conn_String))
            {
                SqlDataReader reader;
                string ptype = "Nothing";
                if (typeof(T) == typeof(ChadCarter.CodeSample.BLL.Customer))
                {
                    ptype = "cust";
                }
                else if (typeof(T) == typeof(ChadCarter.CodeSample.BLL.Employee))
                {
                    ptype = "emp";
                }
                if (ptype == "Nothing") { throw new ArgumentNullException("Person_Type"); }
                SqlCommand cmd = new SqlCommand("dbo.usp_person_select_all_active", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@type", ptype);
                try
                {
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    return convertPeople(reader);
                }
                catch (SqlException ex)
                {
                    for (int i = 0; i < ex.Errors.Count; i++)
                    {
                        errorMessages.Append("Index #" + i + "\n" + "Message: " + ex.Errors[i].Message + "\n" +
                            "Line Number: " + ex.Errors[i].LineNumber + "\n" + "Source: " + ex.Errors[i].Source + "\n" +
                            "Procedure: " + ex.Errors[i].Procedure);
                    }
                    System.Diagnostics.Debug.WriteLine(errorMessages.ToString());
                    return null;
                }
            }
        }
        public int UpsertPerson(int pid, string first_nm, string last_nm, string address, string city, int state, int zip)
        {
            string ptype = "Nothing";
            if (typeof(T) == typeof(ChadCarter.CodeSample.BLL.Customer))
            {
                ptype = "cust";
            }
            else if (typeof(T) == typeof(ChadCarter.CodeSample.BLL.Employee))
            {
                ptype = "emp";
            }
            if (ptype == "Nothing") { throw new ArgumentNullException("Person_Type"); }
            using (SqlConnection conn = new SqlConnection(conn_String))
            {
                SqlCommand cmd = new SqlCommand("dbo.usp_person_upsert", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@type", ptype);
                cmd.Parameters.AddWithValue("@id", pid);
                cmd.Parameters.AddWithValue("@first_nm", first_nm);
                cmd.Parameters.AddWithValue("@last_nm", last_nm);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@city", city);
                cmd.Parameters.AddWithValue("@state", state);
                cmd.Parameters.AddWithValue("@zip", zip);
                try
                {
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (SqlException ex)
                {
                    for (int i = 0; i < ex.Errors.Count; i++)
                    {
                        errorMessages.Append("Index #" + i + "\n" + "Message: " + ex.Errors[i].Message + "\n" +
                            "Line Number: " + ex.Errors[i].LineNumber + "\n" + "Source: " + ex.Errors[i].Source + "\n" +
                            "Procedure: " + ex.Errors[i].Procedure);
                    }
                    System.Diagnostics.Debug.WriteLine(errorMessages.ToString());
                    return 0;
                }
            }
        }
        public int DeletePerson(int pid)
        {
            string ptype = "Nothing";
            if (typeof(T) == typeof(ChadCarter.CodeSample.BLL.Customer))
            {
                ptype = "cust";
            }
            else if (typeof(T) == typeof(ChadCarter.CodeSample.BLL.Employee))
            {
                ptype = "emp";
            }
            if (ptype == "Nothing") { throw new ArgumentNullException("Person_Type"); }
            using (SqlConnection conn = new SqlConnection(conn_String))
            {
                SqlCommand cmd = new SqlCommand("dbo.usp_person_delete", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@type", ptype);
                cmd.Parameters.AddWithValue("@id", pid);
                try
                {
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (SqlException ex)
                {
                    for (int i = 0; i < ex.Errors.Count; i++)
                    {
                        errorMessages.Append("Index #" + i + "\n" + "Message: " + ex.Errors[i].Message + "\n" +
                            "Line Number: " + ex.Errors[i].LineNumber + "\n" + "Source: " + ex.Errors[i].Source + "\n" +
                            "Procedure: " + ex.Errors[i].Procedure);
                    }
                    System.Diagnostics.Debug.WriteLine(errorMessages.ToString());
                    return 0;
                }
            }
        }
        #endregion

        #region Helpers
        protected List<T> convertPeople(SqlDataReader reader)
        {
            var list = new List<T>();
            
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    list.Add((T)Activator.CreateInstance(typeof(T), Convert.ToInt32(reader["id"]),
                        reader["first_nm"].ToString(), reader["last_nm"].ToString(), reader["address"].ToString(),
                        reader["city"].ToString(), Convert.ToInt32(reader["state"]), reader["state_short"].ToString(), 
                        reader["state_long"].ToString(), Convert.ToInt32(reader["zip"]), reader["ptype"].ToString()));
                }
            }
            return list;
        }
        #endregion
    }
}