namespace DocumentReader
{
    using Model;
    using System;
    using System.Configuration;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Text;
    using System.Windows.Forms;
    using Z.Dapper.Plus;

    /// <summary>
    /// Defines the <see cref="My" />
    /// </summary>
    internal class My
    {
        /// <summary>
        /// Defines the ConnectionFactory
        /// </summary>
        public static Func<DbConnection> ConnectionFactory = () => new SqlConnection(ConnectionString.Connection);       
            
        
        /// <summary>
        /// Initializes static members of the <see cref="My"/> class.
        /// </summary>
        static My()
        {
            DapperPlusManager.Entity<CsvFile>().Table("TEMP_TABLE").Map(x => new
            {
                CustomerName = x.Customer,
                ProductName = x.Product,
                Quantity = x.Quantity,
                DateOfOrder = x.Date
            });
        }

        /// <summary>
        /// Defines the <see cref="ConnectionString" />
        /// </summary>
        public static class ConnectionString
        {
            /// <summary>
            /// Defines the Connection
            /// </summary>
            public static string Connection = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
        }

        /// <summary>
        /// Defines the <see cref="SqlText" />
        /// </summary>
        public static class SqlText
        {
            /// <summary>
            /// Defines the Product_Select
            /// </summary>
            public static string Product_Select = @"
                                            SELECT Customer.name AS[Customer], product.name AS [Product], Quantity, [Date]
                                                FROM Orders
                                                inner join  Product WITH (NOLOCK) ON ProductId = Product.id
                                                INNER JOIN  Customer WITH(NOLOCK) ON CustomerId = Customer.id;";
                        
        }

        /// <summary>
        /// Defines the <see cref="Database" />
        /// </summary>
        ///
        public static class Result
        {
            /// <summary>
            /// The Show
            /// </summary>
            /// <param name="clock">The <see cref="Stopwatch"/></param>
            public static void Show(Stopwatch clock)
            {
                MessageBox.Show("Data Saved to Database"+ Environment.NewLine + $"Elapsed Milliseconds: {clock.Elapsed.TotalMilliseconds}");
            }
        }

        /// <summary>
        /// Defines the <see cref="Database" />
        /// </summary>
        public static class Database
        {
            /// <summary>
            /// The Reset
            /// </summary>
            public static void Reset()
            {
                using (var connection = ConnectionFactory())
                {
                    connection.Open();
                    {
                        var command = connection.CreateCommand();

                        command.CommandText = @"
                                                -- DELETE all data
                                                DELETE FROM Orders
                                                DELETE FROM Product
                                                DELETE FROM Customer
                                                DELETE FROM TEMP_TABLE

                                                -- RESEED Identity
                                                DBCC CHECKIDENT (Orders, RESEED, 0)
                                                DBCC CHECKIDENT (Product, RESEED, 0)
                                                DBCC CHECKIDENT (Customer, RESEED, 0)

                                                ";
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
