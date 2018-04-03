using DocumentReader.Common.Converters;
using FileHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DocumentReader.Model
{
    [DelimitedRecord("|")]
    [IgnoreFirst]
    public class CsvFile : IFile
    {
        public string Customer { get; set; }
        public string Product { get; set; }
        public string Quantity { get; set; }

        [FieldConverter(typeof(DateConverter))]
        public string Date { get; set; }

        public PropertyInfo[] GetColumnNames()
        {
            return this.GetType().GetProperties();
        }
    }
}
