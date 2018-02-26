using System;
using System.Data.Common;
using System.Diagnostics;
using System.Text;
using System.Web.Configuration;

public partial class ProviderAgnosticCode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Get the factory.
        string factory = WebConfigurationManager.AppSettings["factory"];
        //DbProviderFactory provider = DbProviderFactories.GetFactory(factory);
        DbProviderFactory provider = DbProviderFactories.GetFactory("System.Data.SqlClient");//SqlClientFactory
        
        // Use this factory to create a connection.
        DbConnection connection = provider.CreateConnection();
        
        connection.ConnectionString =
            WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;

        // Create the command.
        DbCommand command = provider.CreateCommand();
        command.CommandText = WebConfigurationManager.AppSettings["employeeQuery"];
        command.Connection = connection;

        // Open the Connection and get the DataReader.
        connection.Open();
        Debug.WriteLine(connection.Database);
        Debug.WriteLine(connection.ServerVersion);
        Debug.WriteLine(connection.ConnectionString);
        Debug.WriteLine(connection.ConnectionTimeout);
        //Debug.WriteLine(WebConfigurationManager.ConnectionStrings["ConnectionString"].ProviderName);

        DbDataReader reader = command.ExecuteReader();

        // Cycle through the records, and build the HTML string.
        var htmlStr = new StringBuilder("");
        while (reader.Read())
        {
            htmlStr.Append("<li>");
            htmlStr.Append(reader["TitleOfCourtesy"]);
            htmlStr.Append(" <b>");
            htmlStr.Append(reader.GetString(1));
            htmlStr.Append("</b>, ");
            htmlStr.Append(reader.GetString(2));
            htmlStr.Append("</li>");
        }

        // Close the DataReader and the Connection.
        reader.Close();
        connection.Close();

        // Show the generated HTML code on the page.
        HtmlContent.Text = htmlStr.ToString();
    }
}