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
using OVR.Service;
using OVR.DataClass;

namespace OVR
{
    /// <summary>
    /// Interaction logic for ExportData.xaml
    /// </summary>
    public partial class ExportData : Page
    {
        private string fileSelectedPath = "";
        private DatabaseService databaseService = new DatabaseService();
        private CsvGeneratorService csvGeneratorService = new CsvGeneratorService();
        public ExportData()
        {
            InitializeComponent();
            LoadGrid();

        }
        
        
        private void BtnExpData_Click(object sender, RoutedEventArgs e)
        {

            csvGeneratorService.WriteCsvFile(txtfilename.Text, grdLoad.Items);

        }
        //DataTableCollection tableCollection;
        private void BtnBrowse_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Initialization.  
                //OpenFileDialog browseDialog = new OpenFileDialog();
                DataTable datatable = new DataTable();
                using (FolderBrowserDialog openFileDialog = new FolderBrowserDialog())
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        fileSelectedPath = openFileDialog.SelectedPath;
                    }
                }
            }
            catch (Exception ex)
            {
                // Info.  
                System.Windows.MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.Write(ex);
            }
        }

        private void LoadGrid()
        {

            var startupEvent = " Select e.EventName, e.EventCode, s.SportName, case e.GenderId when 0 then 'Female' else 'Male' end as Gender," +
                                "case e.IsActive when 0 then 'Inactive' else 'Active' end as Status from TSR_Event e join TSR_Sport s on e.SportID = s.SportID ";

            var eventList = databaseService.ExecuteSelectWithDapper<EventsList>(startupEvent);

            grdLoad.ItemsSource = eventList;
        }
    
    }
}
