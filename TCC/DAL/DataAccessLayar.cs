using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TCC.DAL
{
    class DataAccessLayar
    {
        SqlConnection sqlconnection;

        public DataAccessLayar()
        {
            sqlconnection = new SqlConnection(@"Server=(localdb)\ProjectsV13;Database=TCC1;Integrated Security=true");

        }
        public void Open()
        {
            if(sqlconnection.State != ConnectionState.Open)
            {
                sqlconnection.Open();
            }
        }

        public void Close()
        {
            if(sqlconnection.State == ConnectionState.Open)
            {
                sqlconnection.Close();
            }
        }

        public DataTable SelectData(string Stored_Procedure, SqlParameter[]param)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = Stored_Procedure;
            if(param!=null)
            {
                for(int i=0; i<param.Length; i++)
                {
                    sqlcmd.Parameters.Add(param[i]);
                }
            }
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public void ExecuteCommand(string Stored_Procedure, SqlParameter[] param)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = Stored_Procedure;
            if(param!=null)
            {
                for(int i=0;i<param.Length;i++)
                {
                    sqlcmd.Parameters.Add(param[i]);
                }
            }
            sqlcmd.ExecuteNonQuery();
            
        }
    }
}
