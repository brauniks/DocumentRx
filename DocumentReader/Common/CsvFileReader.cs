namespace DocumentReader.BLL
{
    using Common.Helper;
    using global::DocumentReader.Model;
    using FileHelpers;
    using System;
    using System.IO;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="CsvFileReader" />
    /// </summary>
    public class CsvFileReader : IFileReader
    {
        /// <summary>
        /// Gets or sets the filePath
        /// </summary>
        public string filePath { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CsvFileReader"/> class.
        /// </summary>
        /// <param name="CsvFileReader">The <see cref="string"/></param>
        public CsvFileReader(string CsvFileReader)
        {
            this.filePath = CsvFileReader;
        }

        /// <summary>
        /// The ReadData
        /// </summary>
        /// <returns>The <see cref="IFile[]"/></returns>
        public IFile[] ReadData()
        {
            try
            {
                var engine = new FileHelperEngine<CsvFile>();

                var detector = new FileHelpers.Detection.SmartFormatDetector();
                var formats = detector.DetectFileFormat(filePath);
                if (ValidateFileHeaders.Validate(formats, this.GetType()))
                {
                    return engine.ReadFile(filePath);
                } 
                else
                {
                    MessageBox.Show("Nieprawidłowy plik .csv" + Environment.NewLine + filePath);
                    return null;
                }
            }
            catch (IOException ex)
            {
                throw ex;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
