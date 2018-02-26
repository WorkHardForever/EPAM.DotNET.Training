using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class CalculatedColumn : System.Web.UI.Page
{

    protected void Page_Load(object sender, System.EventArgs e)
    {
        // Create the Connection, DataAdapter, and DataSet.
        string connectionString =
            WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
        var connection = new SqlConnection(connectionString);

        const string sqlCategories = "SELECT CategoryID, CategoryName FROM Categories";
        const string sqlProducts = "SELECT ProductName, CategoryID, UnitPrice FROM Products";
        //var command = new SqlCommand(sqlCategories, connection);
        //var dataAdapter = new SqlDataAdapter { SelectCommand = command };
        var dataAdapter = new SqlDataAdapter(sqlCategories, connection);
        var dataSet = new DataSet();

        try
        {
            connection.Open();

            // Fill the DataSet with the Categories table.
            dataAdapter.Fill(dataSet, "Categories");

            // Change the command text and retrieve the Products table.
            // You could also use another DataAdapter object for this task.
            dataAdapter.SelectCommand.CommandText = sqlProducts;
            //DataTable 
            dataAdapter.Fill(dataSet, "Products");
        }
        finally
        {
            connection.Close();
        }

        // Define the relationship between Categories and Products.
        var relation = new DataRelation(
            "CategoryProducts", dataSet.Tables["Categories"].Columns["CategoryID"],
            dataSet.Tables["Products"].Columns["CategoryID"]);

        // Add the relationship to the DataSet.
        dataSet.Relations.Add(relation);

        // Create the calculated columns.
        var count = new DataColumn(
            "Products (#)", typeof(int),
            "COUNT(Child(CategoryProducts).CategoryID)");
        var max = new DataColumn(
            "Most Expensive Product", typeof(decimal),
            "MAX(Child(CategoryProducts).UnitPrice)");
        var min = new DataColumn(
            "Least Expensive Product", typeof(decimal),
            "MIN(Child(CategoryProducts).UnitPrice)");

        // Add the columns.
        dataSet.Tables["Categories"].Columns.Add(count);
        dataSet.Tables["Categories"].Columns.Add(max);
        dataSet.Tables["Categories"].Columns.Add(min);
        
        // Show the data.
        GridView1.DataSource = dataSet.Tables["Categories"];
        GridView1.DataBind();
    }
}