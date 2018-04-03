namespace DocumentReader
{
    using DAL;
    using global::DocumentReader.BLL;
    using global::DocumentReader.Model;
    using System;
    using System.Diagnostics;
    using System.Windows.Forms;
    using static My;

    /// <summary>
    /// Defines the <see cref="Form1" />
    /// </summary>
    public partial class DocumentReader : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public DocumentReader()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The btn_Click
        /// </summary>
        /// <param name="sender">The <see cref="object"/></param>
        /// <param name="e">The <see cref="EventArgs"/></param>
        private void btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "CSV Files(*.csv) | *.csv";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                Stopwatch timer = new Stopwatch();
                timer.Start();
                try
                {
                    DocumentReaderBL fileReader = new DocumentReaderBL(new CsvFileReader(openFile.FileName), new CsvFile());
                    var data = fileReader.ReadFile();
                    this.dataGridView1.DataSource = data;
                    DocumentSaverBL fileSaver = new DocumentSaverBL(data);
                    fileSaver.SaveFile();

                    Result.Show(timer);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
               
            }
        }

        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }        
    }
}
