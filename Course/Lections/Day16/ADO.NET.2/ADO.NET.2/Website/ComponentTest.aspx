<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ComponentTest.aspx.cs" Inherits="ComponentTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>
            Employees</h2>
        <asp:Literal runat="server" ID="HtmlContent" />
        <br />
        <br />
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetEmployees"
            TypeName="DatabaseComponent.EmployeeDB">
        </asp:ObjectDataSource>
    </div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="ObjectDataSource1">
        <Columns>
            <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" 
                SortExpression="EmployeeID" />
            <asp:BoundField DataField="TitleOfCourtesy" HeaderText="TitleOfCourtesy" 
                SortExpression="TitleOfCourtesy" />
            <asp:BoundField DataField="FirstName" HeaderText="FirstName" 
                SortExpression="FirstName" />
            <asp:BoundField DataField="LastName" HeaderText="LastName" 
                SortExpression="LastName" />
        </Columns>
    </asp:GridView>
    </form>
</body>
</html>
