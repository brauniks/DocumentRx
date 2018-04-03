using DocumentReader.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentReader.BLL
{
    public class DataParse
    {
        public IList<Customer> GetCostumerDistinct(IFile[] file)
        {
            if (file is CsvFile[])
            {
                return ((CsvFile[])file).GroupBy(a => a.Customer).Select(p => new Customer() { Name = p.Key }).ToList();                
            }
            else return null;
        }

        public IList<Product> GeProductDistinct(IFile[] file)
        {
            if (file is CsvFile[])
            {
                return ((CsvFile[])file).GroupBy(a => a.Product).Select(p => new Product() { Name = p.Key }).ToList();
            }
            else return null;
        }
        
    }
}
