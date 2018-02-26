<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProviderAgnosticCode.aspx.cs"
    Inherits="ProviderAgnosticCode" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>Employees</h2>
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
        <asp:Literal runat="server" ID="HtmlContent" />
    </div>
    </form>
</body>
</html>
