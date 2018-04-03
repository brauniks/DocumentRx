using Dapper;
using DocumentReader.DAL;
using DocumentReader.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocumentReader.BLL
{
   public class DocumentSaverBL
    {
        private IFile[] file { get; set; }
        public DocumentSaverBL(IFile[] _file)
        {
            this.file = _file;
        }
        public void SaveFile()
        {
            My.Database.Reset();
            var fileModel = new DataParse();

            var saveFileToDatabaseDAL = new SaveOrderDAL();
            saveFileToDatabaseDAL.SaveCustomerItems(fileModel.GetCostumerDistinct(this.file));
            saveFileToDatabaseDAL.SaveProductItems(fileModel.GeProductDistinct(this.file));
            saveFileToDatabaseDAL.SaveAsync((CsvFile[])this.file);
        }
    }
}
