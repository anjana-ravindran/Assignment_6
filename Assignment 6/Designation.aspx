<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Designation.aspx.cs" Inherits="Assignment_6.Designation" %>

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
                    <td colspan="2" style="text-align:center"><b><h1>DESIGNATION</h1></b></td>
                </tr>
                <tr>
                    <td><b>Designation Name</b></td>
                    <td>
                      <asp:TextBox ID="txtdesignation" runat="server" required=""></asp:TextBox>
                        <br />
                          <br />
                    </td>
                </tr>
                 <tr>
                    <td><b>Department Name</b></td>
                    <td>
                       <asp:DropDownList ID="ddldepartment" runat="server" Height="16px" Width="166px" ></asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" InitialValue="0" ForeColor="Red" ControlToValidate="ddldepartment"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:center">
                          <br />
                        <asp:Button ID="btn_Add" runat="server" Text="Add" OnClick="btn_Add_Click" />
                          <br />
                          <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:center">

                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Designation_id" Width="511px" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowDataBound="GridView1_RowDataBound">
                            <Columns>
                                <asp:TemplateField  HeaderText="SI. No.">
                                 <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                 </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Designation_Name" HeaderText="Designation Name" />
                               
                            <asp:TemplateField HeaderText="Department Name">
                                <EditItemTemplate>
                                     <asp:DropDownList ID="dropdownDeptName" runat="server" AutoPostBack="true" EnableViewState="true" ></asp:DropDownList>
                                </EditItemTemplate>
                                 <ItemTemplate>
                                        <asp:Label ID="label1" runat="server" Text='<%#Eval("Department_Name") %>'></asp:Label>
                                 </ItemTemplate>
                            </asp:TemplateField>
                                <asp:CommandField HeaderText="Edit" ShowEditButton="True" />
                                <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                                <asp:HyperLinkField DataNavigateUrlFields="Designation_id" DataNavigateUrlFormatString="Designation_id.aspx?id={0}" HeaderText="View More" Text="Go" />
                            </Columns>
                        </asp:GridView>
                        <tr>
                        <th colspan="2">
                            <br />
                            <b ><a href="../Department.aspx" style="color:cornflowerblue">Add Department</a></b></th>
                       </tr>

                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
