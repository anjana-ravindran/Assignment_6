using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Assignment_6
{
    public partial class Designation_id : System.Web.UI.Page
    {
        DbOperation db = new DbOperation();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string did = Request.QueryString["id"].ToString();
                DataTable dt = db.Executedatatable("select Designation_Name,Department_Name from tbl_Designation d inner join tbl_Department dept on d.Department_id=dept.Department_id where Designation_id='"+did+"'");
                Label1.Text = dt.Rows[0]["Designation_Name"].ToString();
                Label2.Text = dt.Rows[0]["Department_Name"].ToString();
            }

        }
    }
}