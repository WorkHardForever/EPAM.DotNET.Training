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

public partial class DataViewFilter : System.Web.UI.Page
{

	protected void Page_Load(object sender, System.EventArgs e)
	{
		// Create the Connection, DataAdapter, and DataSet.
        string connectionString = WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
		var con = new SqlConnection(connectionString);
		const string sqlProducts = "SELECT ProductID, ProductName, UnitsInStock, UnitsOnOrder, Discontinued FROM Products";

		var da = new SqlDataAdapter(sqlProducts, con);
		var ds = new DataSet();

		// Fill the DataSet
		da.Fill(ds, "Products");

		// Filter for the Chocolade product.
		var view1 = new DataView(ds.Tables["Products"])
		                {
		                    RowFilter = "ProductName = 'Chocolade'"
		                };
	    Datagrid1.DataSource = view1;

		// Filter for products that aren't on order or in stock.
		var view2 = new DataView(ds.Tables["Products"])
		                {
		                    RowFilter = "UnitsInStock = 0 AND UnitsOnOrder = 0"
		                };
	    Datagrid2.DataSource = view2;

		// Filter for products starting with the letter P.
		var view3 = new DataView(ds.Tables["Products"])
		                {
		                    RowFilter = "ProductName LIKE 'P%'"
		                };
	    Datagrid3.DataSource = view3;

		// Bind all the data-bound controls on the page.
		// Alternatively, you could call the DataBind() method
		// of each grid separately
		this.DataBind();

	}

}
