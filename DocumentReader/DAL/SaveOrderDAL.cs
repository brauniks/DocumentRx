using Dapper;
using DocumentReader.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Z.Dapper.Plus;

namespace DocumentReader.DAL
{
    public class SaveOrderDAL
    {
        public void SaveProductItems(IList<Product> products)
        {           
            using (var connection = My.ConnectionFactory())
            {
                connection.Open();
                connection.BulkInsert(products);
            }
        }

        public void SaveCustomerItems(IList<Customer> customers)
        {            
            using (var connection = My.ConnectionFactory())
            {
                connection.Open();
                connection.BulkInsert(customers);
            }
        }

        public  void SaveAsync(CsvFile[] dataToMakeOrder)
        {
            Task.Run(() => SaveOrdersItems(dataToMakeOrder));
        }
        public void SaveOrdersItems(CsvFile[] dataToMakeOrder)
        {
            using (var connection = My.ConnectionFactory())
            {
                connection.Open();
                connection.BulkInsert(dataToMakeOrder);
                connection.Execute(@"INSERT INTO Orders (Quantity, CustomerId, ProductId, [Date])
												SELECT  Quantity,Customer.Id  ,Product.Id ,DateOfOrder
												FROM TEMP_TABLE
												INNER JOIN Product WITH (NOLOCK) ON ProductName = Product.Name
												INNER JOIN  Customer WITH (NOLOCK) ON CustomerName = Customer.Name;");
            }

        }
    }
}
