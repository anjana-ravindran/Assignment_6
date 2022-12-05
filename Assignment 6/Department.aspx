<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Department.aspx.cs" Inherits="Assignment_6.Department" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style type="text/css">
        .auto-style1
        {
            height:283px;
            width:446px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <table align="center" class="auto-style1">
                <tr>
                    <td colspan="2" style="text-align:center"><b><h1>DEPARTMENT</h1></b></td>
                </tr>
                <tr>
                    <td><b>Department Name</b></td>
                    <td>
                      <asp:TextBox ID="txtdepartment" runat="server" required=""></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:center">
                          <br />
                        <asp:Button ID="btn_Add" runat="server" Text="Add" OnClick="btn_Add_Click" />
                          <br />
                          <br />
                    </td>
                    <tr>
                        <th colspan="2"><b ><a href="../Designation.aspx" style="color:cornflowerblue">Go To Designation</a></b></th>
                    </tr>
                </tr>
             </table>
        </div>
    </form>
</body>
</html>
