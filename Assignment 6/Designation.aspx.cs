using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_6
{
    public partial class Designation : System.Web.UI.Page
    {
        BAL.DesignationBAL objdesignationbal = new BAL.DesignationBAL();
        BAL.DeptBAL objdeptbal = new BAL.DeptBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddldepartment.DataSource = objdeptbal.viewDept();
                ddldepartment.DataTextField = "Department_Name";
                ddldepartment.DataValueField = "Department_Id";
                ddldepartment.DataBind();
                ddldepartment.Items.Insert(0, new ListItem("--Select--", "0"));


                GridView1.DataSource = objdesignationbal.viewDesignation();
                GridView1.DataBind();


            }

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            TextBox designation = (TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0];
            string deptment = (GridView1.Rows[e.RowIndex].FindControl("dropdownDeptName") as DropDownList).SelectedItem.Value;
            objdesignationbal.DesignationName = designation.Text;
            objdesignationbal.DepartmentId = Convert.ToInt32(deptment);
            objdesignationbal.DesignationId = id;
            int i = objdesignationbal.updateDesignation();
            GridView1.EditIndex = -1;
            GridView1.DataSource = objdesignationbal.viewDesignation();
            GridView1.DataBind();

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridView1.DataSource = objdesignationbal.viewDesignation();
            GridView1.DataBind();

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            objdesignationbal.DesignationId = id;
            int i = objdesignationbal.deleteDesignation();
            GridView1.EditIndex = -1;
            GridView1.DataSource = objdesignationbal.viewDesignation();
            GridView1.DataBind();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridView1.DataSource = objdesignationbal.viewDesignation();
            GridView1.DataBind();

        }

        protected void btn_Add_Click(object sender, EventArgs e)
        {
            objdesignationbal.DesignationName = txtdesignation.Text;
            objdesignationbal.DepartmentId = Convert.ToInt32(ddldepartment.SelectedValue);
            int i = objdesignationbal.insertDesignation();
            GridView1.DataSource = objdesignationbal.viewDesignation();
            GridView1.DataBind();
            if (i == 1)
            {
                Response.Write("<script>alert('Inserted Successfully');</script>");
            }
            else
            {
                Response.Write("<script>alert('Inserted Failed');</script>");
            }

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                DropDownList dropDown = new DropDownList();
                dropDown = (DropDownList)e.Row.FindControl("dropdownDeptName");
                if (dropDown != null)
                {
                    dropDown.DataSource = objdeptbal.viewDept();
                    dropDown.DataTextField = "Department_Name";
                    dropDown.DataValueField = "Department_Id";
                    dropDown.DataBind();
                    dropDown.Items.Insert(0, new ListItem("--Select--", "0"));
                    ((DropDownList)e.Row.FindControl("dropdownDeptName")).SelectedValue = DataBinder.Eval(e.Row.DataItem, "Designation_id").ToString();
                }
            }

        }
    }
}