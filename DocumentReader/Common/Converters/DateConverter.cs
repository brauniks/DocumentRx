using FileHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentReader.Common.Converters
{
    public class DateConverter : ConverterBase
    {
        public override object StringToField(string from)
        {
            DateTime formattedDate ;

            var isFormmatted = DateTime.TryParse(from, out formattedDate);
            if (isFormmatted)
            {
                return formattedDate.ToString("dd/MM/yyyy");
            }
            else
            {
             return   from;
            }
        }
        
    }
}
