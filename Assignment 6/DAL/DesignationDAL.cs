using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Assignment_6.DAL
{
    public class DesignationDAL
    {
        public SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        public DesignationDAL()
        {
            string conn = ConfigurationManager.ConnectionStrings["rose"].ConnectionString;
            con = new SqlConnection(conn);
            cmd.Connection = con;
        }
        public SqlConnection Getcon()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }
        public int designationInsert(BAL.DesignationBAL obj)
        {
            string qry = "insert into tbl_Designation values('" + obj.DesignationName + "','"+obj.DepartmentId+"')";
            SqlCommand cmd = new SqlCommand(qry, Getcon());
            return cmd.ExecuteNonQuery();
        }


        public DataTable designationView()
        {
            string s = "select d.*,dept.* from tbl_Designation d inner join tbl_Department dept on d.Department_id=dept.Department_id";
            SqlCommand cmd = new SqlCommand(s, Getcon());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
        public int designationUpdate(BAL.DesignationBAL obj)
        {
            string s = "update tbl_Designation set Designation_Name='" + obj.DesignationName + "',Department_id='"+obj.DepartmentId+"' where Designation_id='" + obj.DesignationId + "'";
            SqlCommand cmd = new SqlCommand(s, Getcon());
            return cmd.ExecuteNonQuery();

        }
        public int designationDelete(BAL.DesignationBAL obj)
        {
            string s = "Delete from tbl_Designation where Designation_id='" + obj.DesignationId + "'";
            SqlCommand cmd = new SqlCommand(s, Getcon());
            return cmd.ExecuteNonQuery();

        }
    }
}