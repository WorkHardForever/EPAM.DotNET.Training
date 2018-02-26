<%@ Page language="c#" Inherits="DataViewSort" CodeFile="DataViewSort.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title>DataViewSort</title>
    </head>
	<body>		
		<form method="post" runat="server" ID="Form1">
		<div>
			<b><u>Original order</u></b><br />
			<br />
			<asp:GridView runat="server" ID="Datagrid1" HeaderStyle-Font-Bold="true" />
			<br />
			<b><u>Sort = "LastName"</u></b><br />
			<br />
			<asp:GridView runat="server" ID="Datagrid2" HeaderStyle-Font-Bold="true" />
			<br />
			<b><u>Sort = "FirstName"</u></b><br />
			<br />
			<asp:GridView runat="server" ID="Datagrid3" HeaderStyle-Font-Bold="true" />
		</div>
		</form>
	</body>
</html>
