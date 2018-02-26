<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DataReader.aspx.cs" Inherits="DataReader" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <h2>Employees</h2>
	  <asp:Literal runat="server" ID="HtmlContent" />
      <%--  <asp:GridView ID="GridViewEmployees" runat="server">
        </asp:GridView>--%>
    </div>
    </form>
</body>
</html>
