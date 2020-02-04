using ExcelDataReader;
using OVR.DataClass;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Z.Dapper.Plus;

namespace OVR
{
    /// <summary>
    /// Interaction logic for ImportData.xaml
    /// </summary>
    public partial class ImportData : Page
    {
        SqlConnection sqlcon = null;
        public ImportData()
        {
            var x = ConfigurationManager.AppSettings["connectionString"];

            sqlcon = new SqlConnection(x);
            InitializeComponent();
        }

        private void CboSheet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataTable dt = tableCollection[CboSheet.SelectedItem.ToString()];

            //dataGrid.ItemsSource = dt.DefaultView;
            if(dt != null)
            {
                List<Country> country = new List<Country>();
                for(int i = 0; i<dt.Rows.Count; i++)
                {
                    Country countrys = new Country();
                    countrys.CountryID = dt.Rows[i]["CountryID"].ToString();
                    countrys.CountryName = dt.Rows[i]["CountryName"].ToString();
                    countrys.SportCode = dt.Rows[i]["SportCode"].ToString();
                    countrys.IconFilePath = dt.Rows[i]["IconFilePath"].ToString();
                    countrys.IsActive = "1";
                    countrys.CreatedBy = "0";
                    countrys.CreatedDateTime = DateTime.Now;
                    countrys.ModifiedBy = "0";
                    countrys.ModifiedDateTime = DateTime.Now;
                    country.Add(countrys);
                }
                dataGrid.ItemsSource = country;
            }
           
        }
        DataTableCollection tableCollection;
        private void btnUpload_Click(object sender, RoutedEventArgs e)
        {
            //using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel 97-2003 Workbook|*.xls|Excel Workbook|*.xlsx" })
            using (OpenFileDialog openFileDialog=new OpenFileDialog() {Filter = "Excel 97-2003 Workbook|*.xls|Excel Workbook|*.xlsx"})
            {
                if(openFileDialog.ShowDialog()== DialogResult.OK)
                {
                    txtfilename.Text = openFileDialog.FileName;
                    using(var stream = File.Open(openFileDialog.FileName, FileMode.Open,FileAccess.Read))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable=(_) =>new ExcelDataTableConfiguration() { UseHeaderRow = true}

                            });
                            tableCollection = result.Tables;
                            CboSheet.Items.Clear();
                            foreach (DataTable table in tableCollection)
                                CboSheet.Items.Add(table.TableName);
                        }
                    }
                }
            }
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DapperPlusManager.Entity<Country>().Table("Country");
                List<Country> country = dataGrid.ItemsSource as List<Country>;
                if(country != null)
                {
                    using (IDbConnection db = sqlcon)
                    {
                        db.Open();
                        db.BulkInsert(country);
                        db.Close();
                        System.Windows.MessageBox.Show("Data Import Into Database Successfully");
                        MainWindow win = new MainWindow();
                        win.Show();//Open previouse page
                        Window sc = (Window)this.Parent;
                        sc.Close();

                    }
                }
            }
            catch(Exception ex)
            {

                System.Windows.MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.Show();//Open previouse page
            Window contigent = (Window)this.Parent;
            contigent.Close();
        }
    }
}
