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

public partial class DataViewSort : System.Web.UI.Page
{

	protected void Page_Load(object sender, System.EventArgs e)
	{
		// Create the Connection, DataAdapter, and DataSet.
        string connectionString = 
            WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
		var connection = new SqlConnection(connectionString);
		const string sqlEmployee = "SELECT TOP 5 EmployeeID, TitleOfCourtesy, LastName, FirstName FROM Employees";

        var da = new SqlDataAdapter(sqlEmployee, connection);
		var ds = new DataSet();

		// Fill the DataSet
		da.Fill(ds, "Employees");

		// Bind the original data to #1.
		Datagrid1.DataSource = ds.Tables["Employees"];

		// Sort by last name and bind it to #2.
		var view2 = new DataView(ds.Tables["Employees"])
		                {
		                    Sort = "LastName"
		                };
	    Datagrid2.DataSource = view2;

		// Sort by first name and bind it to #3.
		var view3 = new DataView(ds.Tables["Employees"])
		                     {
		                         Sort = "FirstName"
		                     };
	    Datagrid3.DataSource = view3;

		// Bind all the data-bound controls on the page.
		// Alternatively, you could call the DataBind() method
		// of each grid separately
		this.DataBind();

	}
}