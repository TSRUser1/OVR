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
    /// Interaction logic for ImportParticipant.xaml
    /// </summary>
    public partial class ImportParticipant : Page
    {
        SqlConnection sqlcon = null;
        public ImportParticipant()
        {
            var x = ConfigurationManager.AppSettings["connectionString"];

            sqlcon = new SqlConnection(x);
            InitializeComponent();
        }

       
        DataTableCollection tableCollection;
        private void btnUpload_Click(object sender, RoutedEventArgs e)
        {
            //using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel 97-2003 Workbook|*.xls|Excel Workbook|*.xlsx" })
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel 97-2003 Workbook|*.xls|Excel Workbook|*.xlsx" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtfilename.Text = openFileDialog.FileName;
                    using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }

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

        private void CboSheet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataTable dt = tableCollection[CboSheet.SelectedItem.ToString()];

            //dataGrid.ItemsSource = dt.DefaultView;
            if (dt != null)
            {
                List<ParticipantData> participant = new List<ParticipantData>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ParticipantData participants = new ParticipantData();
                    participants.ParticipantID = Int32.Parse(dt.Rows[i]["ParticipantID"].ToString());
                    participants.AccreditationNumber = dt.Rows[i]["AccreditationNumber"].ToString();  
                    participants.FullName = dt.Rows[i]["FullName"].ToString();
                    participants.FamilyName = dt.Rows[i]["FamilyName"].ToString();
                    participants.GenderID = dt.Rows[i]["GenderID"].ToString(); ;
                    participants.CountryID = dt.Rows[i]["CountryID"].ToString();
                    participants.PassportNumber = dt.Rows[i]["PassportNumber"].ToString();
                    participants.DateOfBirth = Convert.ToDateTime(dt.Rows[i]["DateOfBirth"].ToString());
                    participants.Weight = dt.Rows[i]["Weight"].ToString();
                    participants.Height = dt.Rows[i]["Height"].ToString();
                    participants.IsActive = "1";
                    participants.CreatedBy = "0";
                    participants.CreatedDateTime = DateTime.Now;
                    participants.ModifiedBy = "0";
                    participants.ModifiedDateTime = DateTime.Now;
                    participants.GivenName = dt.Rows[i]["GivenName"].ToString();
                    participants.IPCNo = dt.Rows[i]["IPCNo"].ToString();
                    participants.CardPhotoPath = dt.Rows[i]["CardPhotoPath"].ToString();
                    participants.CardPhotoPathThumbnail = dt.Rows[i]["CardPhotoPathThumbnail"].ToString();
                    participants.CardPhotoPathExternal = dt.Rows[i]["CardPhotoPathExternal"].ToString();
                    participants.ExternalParticipantID = 0;
                    participant.Add(participants);

                }
                dgrid1.ItemsSource = participant;
            }

        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DapperPlusManager.Entity<ParticipantData>().Table("TSR_Participant");
                List<ParticipantData> particpant = dgrid1.ItemsSource as List<ParticipantData>;
                if (particpant != null)
                {
                    using (IDbConnection db = sqlcon)
                    {
                        db.Open();
                        db.BulkInsert(particpant);
                        db.Close();
                        System.Windows.MessageBox.Show("Data Import Into Database Successfully");
                        MainWindow win = new MainWindow();
                        win.Show();//Open previouse page
                        Window sc = (Window)this.Parent;
                        sc.Close();

                    }
                }
            }
            catch (Exception ex)
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
