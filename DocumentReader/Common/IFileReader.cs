using DocumentReader.Model;

namespace DocumentReader.BLL
{
    public interface IFileReader
    {
       string filePath { get; set; }
       IFile[] ReadData();
    }
}
