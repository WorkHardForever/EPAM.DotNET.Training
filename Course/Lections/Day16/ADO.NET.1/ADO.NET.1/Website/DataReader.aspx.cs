using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Web.Configuration;

public partial class DataReader : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		// Create the Command and the Connection.
		string connectionString = 
            WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;

		var connection = new SqlConnection(connectionString);
        const string sql = "SELECT Employees.LastName, " +
                           "Employees.FirstName, " +
                           "Employees.Address, " +
                           "Employees.BirthDate" +
                           " FROM Employees";
        var command = new SqlCommand(sql, connection);

		// Open the Connection and get the DataReader.
		connection.Open();
        SqlDataReader reader = command.ExecuteReader();

		// Cycle through the records, and build the HTML string.
        var htmlStr = new StringBuilder("");
        while (reader.Read())
        {
            htmlStr.Append("<li>");
            htmlStr.Append(reader["LastName"]);
            htmlStr.Append(" <b>");
            htmlStr.Append(reader["FirstName"]);
            htmlStr.Append("</b>, ");
            htmlStr.Append(reader["Address"]);
            htmlStr.Append(" - employee from ");
            htmlStr.Append(reader["BirthDate"]);
            htmlStr.Append("</li>");
        }

        //GridViewEmployees.DataSource = reader;
        //GridViewEmployees.DataBind();

         //Close the DataReader and the Connection.
		reader.Close();
		connection.Close();

		// Show the generated HTML code on the page.
        HtmlContent.Text = htmlStr.ToString();
    } 
}
