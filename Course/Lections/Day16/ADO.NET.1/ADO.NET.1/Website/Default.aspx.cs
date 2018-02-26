using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
        var connection = new SqlConnection(connectionString);
        try
        {
            connection.Open();
            Label1.Text = "<b>Server Version:</b> " + connection.ServerVersion;// Версия сервера 
            Label2.Text += "<br /><b>Connection Is:</b> " + connection.State.ToString();// Состояние соединения 
        }
        catch (Exception err)
        //InvalidOperationException, если соединение открыто или недостает информации в строке подключения
        //SqlException (OracleException, OleDbException и OdbcException)
        {
            // Обработать ошибку, отобразив соответствующую информацию. 
            Label1.Text = "Error reading the database. " + err.Message;
            // Возникла ошибка при чтении базы данных 
        }
        finally
        {
            //В любом случае убедиться, что соединение правильно закрыто. 
            // Даже если оно не было открыто успешно, вызов Close () не приводит к ошибке. 
            connection.Close();
            Label2.Text += "<br /><b>Now Connection Is:</b> " + connection.State.ToString();
        }

        //using (var connection = new SqlConnection(connectionString))
        //{
        //    connection.Open();
        //    Label1.Text = "<b>Server Version:</b> " + connection.ServerVersion; // Версия сервера 
        //    Label2.Text += "<br /><b>Connection Is:</b> " + connection.State.ToString(); // Состояние соединения 
        //}

    }
}