using DocumentReader.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentReader.BLL
{
   public class DocumentReaderBL
    {
        IFileReader reader;
        IFile file;
        public DocumentReaderBL(IFileReader _reader, IFile _file)
        {
            this.reader = _reader;
            this.file = _file;
        }

        public IFile[] ReadFile()
        {
            return this.reader.ReadData();
        }
    }
}
