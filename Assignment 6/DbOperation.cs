using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Assignment_6
{
    public class DbOperation
    {
        public SqlConnection con = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();

        public DbOperation()
        {
            con.ConnectionString = "Data Source=NTP-LAP-880;Initial Catalog=Employee;Integrated Security=True;Pooling=False";
            cmd.Connection = con;
        }

        //Sql Connection open function
        public SqlConnection Getcon()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

        //Connection closed function
        public void dbclose()
        {
            con.Close();
        }

        //Execute Non Query common function
        public int Executenonquery(String Sql)
        {
            Getcon();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = Sql; //query is sql 
            int i = cmd.ExecuteNonQuery();
            return i;

        }

        //Execute Non Scalar Common Function
        public object Executescalar(String sql)
        {
            Getcon();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            object ob = cmd.ExecuteScalar();
            return ob;

        }
        //Execute Reader Common Function
        public SqlDataReader Executereader(String sql)
        {
            Getcon();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;

        }
        //Data set
        /*Disconnected Architecture*/
        public DataSet Executedataset(String sql)
        {

            cmd.CommandType = CommandType.Text;//set cmd type text or store procedure or xml like wise
            cmd.CommandText = sql;//pass sql cmd to cmd text
            SqlDataAdapter da = new SqlDataAdapter(cmd);//create adapter cls b/z dsiconnected architecture
            DataSet ds = new DataSet();//create dataset
            da.Fill(ds);//fill data to dataset using adapter object
            return ds;//return dataset

        }

        //Data Table

        public DataTable Executedatatable(String sql)
        {

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }

        public void FillGrid(String sql, GridView dv)
        {
            dv.DataSource = Executedataset(sql);
            dv.DataBind();
        }

        /*public void Fillddl(String sql,DropDownList ddl,String txt,String val)
         {
        ddl.DataTextField=txt;
        ddl.DataValueField=val;
        ddl.DataSource=Executedataset(sql);
        ddl.DataBind();
         }*/


    }
}
