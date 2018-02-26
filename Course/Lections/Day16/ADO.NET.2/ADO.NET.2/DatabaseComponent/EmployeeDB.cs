using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;

namespace DatabaseComponent
{
    public class EmployeeDB
    {
        private readonly string _connectionString;

        public EmployeeDB()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
        }

        public EmployeeDB(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public int InsertEmployee(EmployeeDetails employee)
        {
            var sqlConnection = new SqlConnection(_connectionString);
            var sqlCommand = new SqlCommand("InsertEmployee", sqlConnection)
                                 {
                                     CommandType = CommandType.StoredProcedure
                                 };

            sqlCommand.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.NVarChar, 10));
            sqlCommand.Parameters["@FirstName"].Value = employee.FirstName;
            sqlCommand.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar, 20));
            sqlCommand.Parameters["@LastName"].Value = employee.LastName;
            sqlCommand.Parameters.Add(new SqlParameter("@TitleOfCourtesy", SqlDbType.NVarChar, 25));
            sqlCommand.Parameters["@TitleOfCourtesy"].Value = employee.TitleOfCourtesy;
            sqlCommand.Parameters.Add(new SqlParameter("@EmployeeID", SqlDbType.Int, 4));
            sqlCommand.Parameters["@EmployeeID"].Direction = ParameterDirection.Output;

            using (sqlConnection)
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                return (int)sqlCommand.Parameters["@EmployeeID"].Value;
            }

            #region try/catch/finally
            //try 
            //{
            //    sqlConnection.Open();
            //    sqlCommand.ExecuteNonQuery();
            //    return (int)sqlCommand.Parameters["@EmployeeID"].Value;
            //}
            //catch (SqlException err) 
            //{
            //    // Replace the error with something less specific.
            //    // You could also log the error now.
            //    throw new ApplicationException("Data error.");
            //}
            //finally 
            //{
            //    sqlConnection.Close();			
            //} 
            #endregion
        }

        public void UpdateEmployee(EmployeeDetails employee)
        {
            var sqlConnection = new SqlConnection(_connectionString);
            var sqlCommand = new SqlCommand("UpdateEmployee", sqlConnection)
                                        {
                                            CommandType = CommandType.StoredProcedure
                                        };

            sqlCommand.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.NVarChar, 10));
            sqlCommand.Parameters["@FirstName"].Value = employee.FirstName;
            sqlCommand.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar, 20));
            sqlCommand.Parameters["@LastName"].Value = employee.LastName;
            sqlCommand.Parameters.Add(new SqlParameter("@TitleOfCourtesy", SqlDbType.NVarChar, 25));
            sqlCommand.Parameters["@TitleOfCourtesy"].Value = employee.TitleOfCourtesy;
            sqlCommand.Parameters.Add(new SqlParameter("@EmployeeID", SqlDbType.Int, 4));
            sqlCommand.Parameters["@EmployeeID"].Value = employee.EmployeeID;

            using (sqlConnection)
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }

            #region try/catch/finally
            //try
            //{
            //    sqlConnection.Open();
            //    sqlCommand.ExecuteNonQuery();
            //}
            //catch (SqlException err)
            //{
            //    // Replace the error with something less specific.
            //    // You could also log the error now.
            //    throw new ApplicationException("Data error.");
            //}
            //finally
            //{
            //    sqlConnection.Close();
            //} 
            #endregion
        }

        public void UpdateEmployee(int employeeId, string firstName, string lastName, string titleOfCourtesy)
        {
            var sqlConnection = new SqlConnection(_connectionString);
            var sqlCommand = new SqlCommand("UpdateEmployee", sqlConnection)
                                        {
                                            CommandType = CommandType.StoredProcedure
                                        };

            sqlCommand.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.NVarChar, 10));
            sqlCommand.Parameters["@FirstName"].Value = firstName;
            sqlCommand.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar, 20));
            sqlCommand.Parameters["@LastName"].Value = lastName;
            sqlCommand.Parameters.Add(new SqlParameter("@TitleOfCourtesy", SqlDbType.NVarChar, 25));
            sqlCommand.Parameters["@TitleOfCourtesy"].Value = titleOfCourtesy;
            sqlCommand.Parameters.Add(new SqlParameter("@EmployeeID", SqlDbType.Int, 4));
            sqlCommand.Parameters["@EmployeeID"].Value = employeeId;

            using (sqlConnection)
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }

            #region try/catch/finally
            //try
            //{
            //    sqlConnection.Open();
            //    sqlCommand.ExecuteNonQuery();
            //}
            //catch (SqlException err)
            //{
            //    // Replace the error with something less specific.
            //    // You could also log the error now.
            //    throw new ApplicationException("Data error.");
            //}
            //finally
            //{
            //    sqlConnection.Close();
            //} 
            #endregion
        }

        public void DeleteEmployee(int employeeId)
        {
            SqlConnection sqlConnection = new SqlConnection(_connectionString);
            SqlCommand sqlCommand = new SqlCommand("DeleteEmployee", sqlConnection)
                                        {
                                            CommandType = CommandType.StoredProcedure
                                        };

            sqlCommand.Parameters.Add(new SqlParameter("@EmployeeID", SqlDbType.Int, 4));
            sqlCommand.Parameters["@EmployeeID"].Value = employeeId;

            using (sqlConnection)
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }

            #region try/catch/finally
            //try
            //{
            //    sqlConnection.Open();
            //    sqlCommand.ExecuteNonQuery();
            //}
            //catch (SqlException err)
            //{
            //    // Replace the error with something less specific.
            //    // You could also log the error now.
            //    throw new ApplicationException("Data error.");
            //}
            //finally
            //{
            //    sqlConnection.Close();
            //} 
            #endregion
        }

        public EmployeeDetails GetEmployee(int employeeId)
        {
            var sqlConnection = new SqlConnection(_connectionString);
            var sqlCommand = new SqlCommand("GetEmployee", sqlConnection)
                                        {
                                            CommandType = CommandType.StoredProcedure
                                        };

            sqlCommand.Parameters.Add(new SqlParameter("@EmployeeID", SqlDbType.Int, 4));
            sqlCommand.Parameters["@EmployeeID"].Value = employeeId;

            using (sqlConnection)
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader(CommandBehavior.SingleRow);

                // Get the first row.
                if (!reader.HasRows) return null;
                reader.Read();
                var employee = new EmployeeDetails
                                        {
                                            EmployeeID = (int)reader["EmployeeID"],
                                            FirstName = (string)reader["FirstName"],
                                            LastName = (string)reader["LastName"],
                                            TitleOfCourtesy = (string)reader["TitleOfCourtesy"]
                                        };
                reader.Close();
                return employee;
            }

            #region try/catch/finally
            //try
            //{
            //    sqlConnection.Open();
            //    SqlDataReader reader = sqlCommand.ExecuteReader(CommandBehavior.SingleRow);

            //    // Get the first row.
            //    reader.Read();
            //    EmployeeDetails emp = new EmployeeDetails(
            //        (int)reader["EmployeeID"], (string)reader["FirstName"],
            //        (string)reader["LastName"], (string)reader["TitleOfCourtesy"]);
            //    reader.Close();
            //    return emp;
            //}
            //catch (SqlException err)
            //{
            //    // Replace the error with something less specific.
            //    // You could also log the error now.
            //    throw new ApplicationException("Data error.");
            //}
            //finally
            //{
            //    sqlConnection.Close();
            //} 
            #endregion
        }

        public IList<EmployeeDetails> GetEmployees()
        {
            var sqlConnection = new SqlConnection(_connectionString);
            var sqlCommand = new SqlCommand("GetAllEmployees", sqlConnection)
                                        {
                                            CommandType = CommandType.StoredProcedure
                                        };

            // Create a collection for all the employee records.
            var employees = new List<EmployeeDetails>();

            using (sqlConnection)
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    var emp = new EmployeeDetails
                                  {
                                      EmployeeID = (int)reader["EmployeeID"],
                                      FirstName = (string)reader["FirstName"],
                                      LastName = (string)reader["LastName"],
                                      TitleOfCourtesy = (string)reader["TitleOfCourtesy"]
                                  };
                    employees.Add(emp);
                }
                reader.Close();

                return employees;
            }

            #region try/catch/finally
            //try
            //{
            //    sqlConnection.Open();
            //    SqlDataReader reader = sqlCommand.ExecuteReader();

            //    while (reader.Read())
            //    {
            //        EmployeeDetails emp = new EmployeeDetails(
            //            (int)reader["EmployeeID"], (string)reader["FirstName"],
            //            (string)reader["LastName"], (string)reader["TitleOfCourtesy"]);
            //        employees.Add(emp);
            //    }
            //    reader.Close();

            //    return employees;
            //}
            //catch (SqlException err)
            //{
            //    // Replace the error with something less specific.
            //    // You could also log the error now.
            //    throw new ApplicationException("Data error.");
            //}
            //finally
            //{
            //    sqlConnection.Close();
            //} 
            #endregion
        }

        public int CountEmployees()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var sqlCommand = new SqlCommand("CountEmployees", sqlConnection)
                                            {
                                                CommandType = CommandType.StoredProcedure
                                            };
                sqlConnection.Open();
                return (int)sqlCommand.ExecuteScalar();
            }

            #region try/catch/finally
            //try
            //{
            //    sqlConnection.Open();
            //    return (int)sqlCommand.ExecuteScalar();
            //}
            //catch (SqlException err)
            //{
            //    // Replace the error with something less specific.
            //    // You could also log the error now.
            //    throw new ApplicationException("Data error.");
            //}
            //finally
            //{
            //    sqlConnection.Close();
            //} 
            #endregion
        }
    }
}
