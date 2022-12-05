using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_6
{
    public partial class Department : System.Web.UI.Page
    {
        BAL.DeptBAL objdpttbl = new BAL.DeptBAL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Add_Click(object sender, EventArgs e)
        {
            objdpttbl.DeptName = txtdepartment.Text;
            int i = objdpttbl.insertdepartment();
            if (i == 1)
            {
                Response.Write("<script>alert('Inserted Successfully');</script>");
            }
            else
            {
                Response.Write("<script>alert('Insertion Failed');</script>");
            }
        }
    }
}