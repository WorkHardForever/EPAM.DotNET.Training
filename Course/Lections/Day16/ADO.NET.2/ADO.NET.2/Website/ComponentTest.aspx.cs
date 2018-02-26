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
using DatabaseComponent;
using System.Text;
using System.Collections.Generic;

public partial class ComponentTest : System.Web.UI.Page
{
    // Create the database component.
	private readonly EmployeeDB db = new EmployeeDB();

	protected void Page_Load(object sender, System.EventArgs e)
	{
        WriteEmployeesList();

        int empID = db.InsertEmployee(new EmployeeDetails(0, "Mr.", "Bellinaso", "Marco"));
        HtmlContent.Text += "<br />Inserted 1 employee.<br />";

        WriteEmployeesList();

        db.DeleteEmployee(empID);
        HtmlContent.Text += "<br />Deleted 1 employee.<br />";

        WriteEmployeesList();
	}


	private void WriteEmployeesList()
	{
		StringBuilder htmlStr = new StringBuilder("");

		int numEmployees = db.CountEmployees();
		htmlStr.Append("<br>Total employees: <b>");
		htmlStr.Append(numEmployees.ToString());
		htmlStr.Append("</b><br><br>");

		IList<EmployeeDetails> employees = db.GetEmployees();
		foreach (EmployeeDetails emp in employees)
		{
			htmlStr.Append("<li>");
			htmlStr.Append(emp.EmployeeID);
			htmlStr.Append(" ");
			htmlStr.Append(emp.TitleOfCourtesy);
			htmlStr.Append(" <b>");
			htmlStr.Append(emp.FirstName);
			htmlStr.Append("</b>, ");
			htmlStr.Append(emp.LastName);
			htmlStr.Append("</li>");
		}
		htmlStr.Append("<br>");
		HtmlContent.Text += htmlStr.ToString();
	}
}
