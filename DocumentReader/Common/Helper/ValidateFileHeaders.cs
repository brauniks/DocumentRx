using DocumentReader.BLL;
using DocumentReader.Model;
using FileHelpers.Detection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentReader.Common.Helper
{
   static class ValidateFileHeaders
    {
        public static bool Validate(RecordFormatInfo[] fileFormat, Type t)
        {
            if (fileFormat.Count() == 0)
            {
                return false;
            }
            var z = new CsvFile().GetColumnNames();
            if (t == typeof(CsvFileReader))
            {
                for (int i = 0; i < fileFormat.First().ClassBuilder.Fields.Count(); i++)
                {
                    var fieldFromCsv = ((FileHelpers.Dynamic.DelimitedClassBuilder)fileFormat[0].ClassBuilder).Fields[i].FieldName.ToString();
                    var fieldFromCsvDomain = z.ElementAt(i).Name;
                    if (fieldFromCsv != fieldFromCsvDomain)
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
