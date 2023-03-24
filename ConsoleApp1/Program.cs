using System;
using System.Data.SqlClient;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=TARANG-PC;Initial Catalog=Tarang;Trusted_Connection=true;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // For Query1"
                    string query1 = "SELECT SUM(Amount) FROM tbl_Order WHERE OrderDate = '2023-01-02'";
                    SqlCommand command1 = new SqlCommand(query1, connection);
                    object result1 = command1.ExecuteScalar();
                    Console.WriteLine("Total order amount placed on '2023-01-02': " + result1);

                    // For Query2"
                    string query2 = "SELECT DISTINCT c.Country FROM tbl_Order o JOIN tbl_Customer c ON o.CustomerID = c.ID WHERE o.OrderDate = '2023-01-02'";
                    SqlCommand command2 = new SqlCommand(query2, connection);
                    SqlDataReader reader2 = command2.ExecuteReader();
                    Console.WriteLine("Countries from which orders were placed on '2023-01-02':");
                    while (reader2.Read())
                    {
                        Console.WriteLine(reader2.GetString(0));
                    }
                    reader2.Close();

                    // For Query 3"
                    string query3 = "SELECT c.Name FROM tbl_Order o JOIN tbl_Customer c ON o.CustomerID = c.ID WHERE o.OrderDate = '2023-01-02'";
                    SqlCommand command3 = new SqlCommand(query3, connection);
                    SqlDataReader reader3 = command3.ExecuteReader();
                    Console.WriteLine("Customers who placed orders on '2023-01-02':");
                    while (reader3.Read())
                    {
                        Console.WriteLine(reader3.GetString(0));
                    }
                    reader3.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadLine();
        }
    }
}
