<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SqlInjectionCorrected.aspx.cs" Inherits="SqlInjectionCorrected" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
   <div>
    Enter Customer ID: 
    <br />
    <asp:TextBox id="txtID" runat="server">ALFKI' OR '1'='1</asp:TextBox>
    <br />
	<asp:Button id="cmdGetRecords" 
	  runat="server" Text="Get Records" OnClick="cmdGetRecords_Click"></asp:Button>
	<br /><br />
	<asp:GridView id="GridView1" 
	  runat="server" Width="392px" Height="123px" Font-Names="Verdana" Font-Size="X-Small"></asp:GridView>
    </div>
    </form>
</body>
</html>
