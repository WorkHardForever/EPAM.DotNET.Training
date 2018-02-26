using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class DataReaderMultiple : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		// Create the Command and the Connection.
        string connectionString = WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString; 
		var connection = new SqlConnection(connectionString);
		const string sql = @"SELECT TOP 5 EmployeeID, FirstName, LastName FROM Employees;" +
		                   "SELECT TOP 5 ContactName, ContactTitle FROM Customers;" +
		                   "SELECT TOP 5 SupplierID, CompanyName, ContactName FROM Suppliers";

        var command = new SqlCommand(sql, connection);

		// Open the Connection and get the DataReader.
		connection.Open();
		SqlDataReader reader = command.ExecuteReader();

		// Cycle through the records and all the rowsets,
		// and build the HTML string.
        var htmlStr = new StringBuilder("");
		int i = 0;
		do
		{
			htmlStr.Append("<h2>Rowset: ");
			htmlStr.Append(i.ToString());
			htmlStr.Append("</h2>");

			while (reader.Read())
			{
				htmlStr.Append("<li>");
				// Get all the fields in this row.
				for (int field = 0; field < reader.FieldCount; field++)
				{
					htmlStr.Append(reader.GetName(field));
					htmlStr.Append(": ");
					htmlStr.Append(reader.GetValue(field));
					htmlStr.Append("&nbsp;&nbsp;&nbsp;");
                    //(reader["NumberOfHires"] == DBNull.Value) !!!
				}
				htmlStr.Append("</li>");
			}
			htmlStr.Append("<br><br>");
			i++;
		} while (reader.NextResult());


		// Close the DataReader and the Connection.
		reader.Close();
		connection.Close();

		// Show the generated HTML code on the page.
		HtmlContent.Text = htmlStr.ToString();
    }
}
