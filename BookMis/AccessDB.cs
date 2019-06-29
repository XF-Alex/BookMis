using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace BookMis
{
    class DataBase
    {

    }

    public class AccessDB
    {
        public AccessDB()
        {
            ///
        }

        public static string GetConnStr()
        {
            return "Data Source=DESKTOP-E4641QF;Initial Catalog=s2017130918;Integrated Security=True";
        }

        public static SqlConnection GetConnection()
        {
            SqlConnection scn = new SqlConnection();
            scn.ConnectionString = GetConnStr();
            return scn;
        }

        public static DataSet GetDataSet(string SQL,string NickName)
        {
            SqlConnection scn = new SqlConnection();
            scn.ConnectionString = GetConnStr();
            scn.Open();
            SqlDataAdapter da = new SqlDataAdapter(SQL, scn);
            DataSet ds = new DataSet();
            da.Fill(ds,NickName);
            scn.Close();
            return ds;
        }

        public static DataTable GetDataTable(string SQL)
        {
            SqlConnection scn = new SqlConnection();
            scn.ConnectionString = GetConnStr();
            scn.Open();
            SqlDataAdapter da = new SqlDataAdapter(SQL, scn);
            DataSet ds = new DataSet();
            da.Fill(ds, "tmp");
            scn.Close();
            return ds.Tables[0];
        }

        public static string GetFieldValue(string SQL)
        {
            SqlConnection scn = new SqlConnection();
            scn.ConnectionString = GetConnStr();
            scn.Open();
            SqlCommand scm = scn.CreateCommand();
            scm.CommandText = SQL;
            SqlDataReader sdr = scm.ExecuteReader();
            string tmp = "";
            if (sdr.Read())
            {
                if (sdr.IsDBNull(0))
                    tmp = "";
                else
                    tmp = sdr.GetValue(0).ToString();
            }
            sdr.Close();
            scn.Close();
            return tmp.Trim();
        }

        public static string ExecSQL(string SQL)
        {
            SqlConnection scn = new SqlConnection();
            scn.ConnectionString = GetConnStr();
            scn.Open();
            SqlCommand scm = scn.CreateCommand();
            scm.Connection = scn;
            scm.CommandText = SQL;
            int t = scm.ExecuteNonQuery();
            scn.Close();
            return t.ToString();
        }
    }
}
