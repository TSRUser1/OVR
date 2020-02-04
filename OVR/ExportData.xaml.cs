using CSVLibraryAK.Resources.Constants;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CSVLibraryAK;
using Microsoft.Win32;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using ExcelLibrary.CompoundDocumentFormat;
using ExcelLibrary.BinaryFileFormat;
using ExcelLibrary.SpreadSheet;
using ExcelLibrary.BinaryDrawingFormat;
using System.Windows.Forms;
using ExcelDataReader;

namespace OVR
{
    /// <summary>
    /// Interaction logic for ExportData.xaml
    /// </summary>
    public partial class ExportData : Page
    {
        SqlConnection sqlcon = null;
        List<ExportDatatest> ExportDatatests = new List<ExportDatatest>();
       
        //string expfile = @"C:\Users\hp\Desktop\TEST.xls";
        private DataTable dataTableObj = new DataTable();
        public ExportData()
        {
            InitializeComponent();
            var x = ConfigurationManager.AppSettings["connectionString"];
            sqlcon = new SqlConnection(x);

        }
        string filenamevalue = "";
        
        private void BtnExpData_Click(object sender, RoutedEventArgs e)
        {

            grdLoad.SelectAllCells();
            grdLoad.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, grdLoad);
            grdLoad.UnselectAllCells();
            String result = (string)System.Windows.Clipboard.GetData(System.Windows.DataFormats.CommaSeparatedValue);
            File.AppendAllText(filenamevalue, result, UnicodeEncoding.UTF8);
            System.Windows.MessageBox.Show("Data Export Successfully");
            MainWindow win = new MainWindow();
            win.Show();//Open previouse page
            Window sc = (Window)this.Parent;
            sc.Close();

        }
        //DataTableCollection tableCollection;
        private void BtnBrowse_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Initialization.  
                //OpenFileDialog browseDialog = new OpenFileDialog();
                DataTable datatable = new DataTable();
                using (System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog() { Filter = "All files (*.*)|*.*|csv files (*.csv)|*.csv"})
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        txtfilename.Text = openFileDialog.FileName;
                        filenamevalue = txtfilename.Text;
                        //using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                        //{
                        //    using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                        //    {
                        //        DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                        //        {
                        //            ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }

                        //        });
                        //        tableCollection = result.Tables;
                        //        //CboSheet.Items.Clear();
                        //        //foreach (DataTable table in tableCollection)
                        //        //    CboSheet.Items.Add(table.TableName);
                        //    }
                        //}
                    }
                }


                sqlcon.Open();
                    string query1 = "SELECT * FROM [Country]";
                    SqlCommand sqlcmd1 = new SqlCommand(query1, sqlcon);

                    sqlcmd1.ExecuteNonQuery();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlcmd1);
                    DataTable dt2 = new DataTable("Country");
                    dataAdapter.Fill(dt2);
                     grdLoad.ItemsSource = dt2.DefaultView;
                sqlcon.Close();

            }
            catch (Exception ex)
            {
                // Info.  
                System.Windows.MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.Write(ex);
            }
        }


    
    }
}
