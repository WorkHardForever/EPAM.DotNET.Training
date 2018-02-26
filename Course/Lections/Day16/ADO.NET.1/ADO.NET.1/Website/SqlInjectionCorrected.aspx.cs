using System;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class SqlInjectionCorrected : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

	protected void cmdGetRecords_Click(object sender, System.EventArgs e)
	{
        string connectionString = 
            WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString; 
		var connection = new SqlConnection(connectionString);
		string sql =
			"SELECT Orders.CustomerID, Orders.OrderID, COUNT(UnitPrice) AS Items, " +
			"SUM(UnitPrice * Quantity) AS Total FROM Orders " +
			"INNER JOIN [Order Details] " +
			"ON Orders.OrderID = [Order Details].OrderID " +
			"WHERE Orders.CustomerID = @CustID " +
			"GROUP BY Orders.OrderID, Orders.CustomerID";
		var command = new SqlCommand(sql, connection);
		command.Parameters.AddWithValue("@CustID", txtID.Text);

		connection.Open();
		SqlDataReader reader = command.ExecuteReader();
		GridView1.DataSource = reader;
		GridView1.DataBind();
		reader.Close();
		connection.Close();
	}
}
