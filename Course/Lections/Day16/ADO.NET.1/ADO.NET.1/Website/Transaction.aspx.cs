using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Transaction : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string connectionString = 
            WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
        var connection = new SqlConnection(connectionString);
        var commandl = new SqlCommand("INSERT INTO Employees (LastName, FirstName)" +
                                      " VALUES ('Joe','Tester')", connection);
        var command2 = new SqlCommand("INSERT INTO Employees (LastName, FirstName) " +
                                      "VALUES ('Harry','Sullivan')", connection);

        SqlTransaction transaction = null;
        try
        {
            // Открыть соединение и создать транзакцию. 
            connection.Open();
            transaction = connection.BeginTransaction();
            // Включить в транзакцию две команды, 
            commandl.Transaction = transaction;
            command2.Transaction = transaction;
            
            // Выполнить обе команды, 
            commandl.ExecuteNonQuery();
            command2.ExecuteNonQuery();
            throw new ApplicationException(); 
            // Зафиксировать транзакцию. 
            //
            transaction.Commit();
            Label1.Text = "Транзакция успешно завершена.";
        }
        catch
        {
            // В случае ошибки отменить транзакцию. 
            if (transaction != null) transaction.Rollback();
            Label1.Text = "Отмена транзакции.";
        }
        finally
        {
            connection.Close();
        }
    }
}