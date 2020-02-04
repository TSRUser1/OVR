using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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

namespace OVR
{
    /// <summary>
    /// Interaction logic for Contigent1.xaml
    /// </summary>
    public partial class Contigent : Page
    {

        SqlConnection sqlcon = null;
        public Contigent()
        {
            InitializeComponent();
            var x = ConfigurationManager.AppSettings["connectionString"];
            sqlcon = new SqlConnection(x);
            DataContext = new MyDataContext();
        }

        public Contigent(string countryname, string countryshortname, string isocode2, string isocode3, string ctryflag)
        {
            InitializeComponent();
            txtcountryName.Text = countryname;
            txtcountryNameShort.Text = countryshortname;
            txtcountryFlag.Text = ctryflag;

        }
        //SqlConnection sqlcon = new SqlConnection(@"Data Source = LAPTOP-74F5FNT3\SQLEXPRESS; Initial Catalog=TSR; Integrated Security=true;");
        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            DateTime today = DateTime.Today;
           
            if(txtcountryName.Text == "")
            {
                MessageBox.Show("Country Name Cannot Be Empty!", "Error");
            }
           else  if (txtcountryNameShort.Text == "")
            {
                MessageBox.Show("Country Name Short Cannot Be Empty!", "Error");
            }
            else if(txtcountryFlag.Text == "")
            {
                MessageBox.Show("Country Flag Cannot Be Empty!", "Error");
            }
            else
            {
                sqlcon.Open();
                string query = "INSERT INTO [dbo].[TSR_Contigent] ([CountryName],[CountryNameShort],[ISOCode2],[ISOCode3],[FlagImageFilePath],[IsActive],[CreatedDateTime],[CreatedBy],[ModifiedDateTime],[ModifiedBy]) VALUES (@ctn, @cns, @is2,@is3,@ctf,1,@cdt,'1',@cdt,'1')";

               SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
               sqlcmd.CommandType = System.Data.CommandType.Text;
                sqlcmd.Parameters.AddWithValue("@ctn", txtcountryName.Text);
                sqlcmd.Parameters.AddWithValue("@cns", txtcountryNameShort.Text);
                sqlcmd.Parameters.AddWithValue("@ctf", txtcountryFlag.Text);
                sqlcmd.Parameters.AddWithValue("@cdt", today);
                sqlcmd.ExecuteNonQuery();
                //SqlDataReader dr = sqlcmd.ExecuteReader();
                MainWindow win = new MainWindow();
                win.Show();//Open previouse page
                Window contigent = (Window)this.Parent;
                contigent.Close();

            }
            
        }
        private void BtnUpload_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                imgPhoto.Source = new BitmapImage(new Uri(op.FileName));
                txtcountryFlag.Text = op.FileName.ToString();
                txtcountryFlag.IsEnabled = false;
            }

        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.Show();//Open previouse page
            Window contigent = (Window)this.Parent;
            contigent.Close();

        }
    }
}
