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
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class SqlInjection : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void cmdGetRecords_Click(object sender, EventArgs e)
    {
        string connectionString =
            WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
        var connection = new SqlConnection(connectionString);
        string sql =
            "SELECT Orders.CustomerID, Orders.OrderID, COUNT(UnitPrice) AS Items, " +
            "SUM(UnitPrice * Quantity) AS Total FROM Orders " +
            "INNER JOIN [Order Details] " +
            "ON Orders.OrderID = [Order Details].OrderID " +
            "WHERE Orders.CustomerID = '" + txtID.Text + "' " +
            "GROUP BY Orders.OrderID, Orders.CustomerID";
        //ALFKI' OR '1'='1 
        //Этот оператор вернет все записи о заказах. Даже если заказ не был 
        //выдан  заказчиком ALFKI, все равно условие 1=1 истинно для всех строк. 
        //В результате вместо вывода специфической информации о текущем заказчике 
        //злоумышленнику передается вся  информация
        
        var command = new SqlCommand(sql, connection);
        
        //можно предпринять более  изощренную атаку внедрением SQL, 
        //удалив все строки в таблице Customers: 
        //ALFKI'; DELETE * FROM Customers-- 
        //; - Oracle, # - MySQL
        
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        GridView1.DataSource = reader;
        GridView1.DataBind();
        reader.Close();
        connection.Close();
    }
}
