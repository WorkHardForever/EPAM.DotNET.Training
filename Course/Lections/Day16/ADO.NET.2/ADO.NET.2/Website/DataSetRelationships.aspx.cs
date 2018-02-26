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
using System.Text;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class DataSetRelationships : System.Web.UI.Page
{

	protected void Page_Load(object sender, System.EventArgs e)
	{
		// Create the Connection, DataAdapter, and DataSet.
        string connectionString = WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
		var con = new SqlConnection(connectionString);

		const string sqlCategories = "SELECT CategoryID, CategoryName FROM Categories";
		const string sqlProducts = "SELECT ProductName, CategoryID FROM Products";

		var da = new SqlDataAdapter(sqlCategories, con);
		var ds = new DataSet();

		try
		{
			con.Open();

			// Fill the DataSet with the Categories table.
			da.Fill(ds, "Categories");

			// Change the command text and retrieve the Products table.
			// You could also use another DataAdapter object for this task.
			da.SelectCommand.CommandText = sqlProducts;
			da.Fill(ds, "Products");
		}
		finally
		{
			con.Close();
		}

		// Define the relationship between Categories and Products.
		var relation = new DataRelation("CategoriesProducts",
			ds.Tables["Categories"].Columns["CategoryID"],
			ds.Tables["Products"].Columns["CategoryID"]);
		// Add the relationship to the DataSet.
		ds.Relations.Add(relation);

		// Loop through the category records and build the HTML string.
		var htmlStr = new StringBuilder("");
		foreach (DataRow row in ds.Tables["Categories"].Rows)
		{
			htmlStr.Append("<b>");
			htmlStr.Append(row["CategoryName"].ToString());
			htmlStr.Append("</b><ul>");

            // Get the children (products) for this parent (category).
            DataRow[] childRows = row.GetChildRows(relation);
            // Loop through all the products in this category.
            foreach (DataRow childRow in childRows)
            {
                htmlStr.Append("<li>");
                htmlStr.Append(childRow["ProductName"].ToString());
                htmlStr.Append("</li>");
            }
			htmlStr.Append("</ul>");
		}

		// Show the generated HTML code.
		HtmlContent.Text = htmlStr.ToString();
	}

}