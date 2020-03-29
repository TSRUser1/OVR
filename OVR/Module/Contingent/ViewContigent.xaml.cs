using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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


namespace OVR.ViewModule
{
    /// <summary>
    /// Interaction logic for ViewContigent.xaml
    /// </summary>
    public partial class ViewContigent : Page
    {
        SqlConnection sqlcon = null;
        public ViewContigent()
        {

            InitializeComponent();
            var x = ConfigurationManager.AppSettings["connectionString"];
            sqlcon = new SqlConnection(x);
                  fill_comboboxEventName();
        }
       //SqlConnection sqlcon = new SqlConnection(@"Data Source = LAPTOP-74F5FNT3\SQLEXPRESS; Initial Catalog=TSR; Integrated Security=true;");
        string countryname = "";
        string countryshortname = "";
        string isocode2 = "";
        string isocode3 = "";
        string ctryflag = "";
        string name = "";
        void fill_comboboxEventName()
        {
            sqlcon.Open();
            string query = "SELECT * FROM [TSR_Contigent] where CountryName != ''";
            SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
            SqlDataReader dr = sqlcmd.ExecuteReader();
            while (dr.Read())
            {
               name = dr.GetString(1);
               cboctryname.Items.Add(name);
            }
            sqlcon.Close();
        }
        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            sqlcon.Open();
            //string query = "SELECT * FROM [TSR_Venue] where VenueName = @etc";
            //string query1 = "SELECT * FROM [TSR_State] where StateId = @sid";
            string query2 = "SELECT * FROM [TSR_Contigent] where CountryName = @cid";
            SqlCommand sqlcmd = new SqlCommand(query2, sqlcon);
            sqlcmd.CommandType = System.Data.CommandType.Text;
            sqlcmd.Parameters.AddWithValue("@cid", cboctryname.Text);
            SqlDataReader dr = sqlcmd.ExecuteReader();
            while (dr.Read())
            {
                lblCtryname.Content = dr.GetString(1);
                lblCtrynameshort.Content = dr.GetString(2);
                lblIsocode2.Content = dr.GetString(3);
                lblIsocode3.Content = dr.GetString(4);
                lblCtryflag.Content = dr.GetString(5);
                //lblVenuesName.Content = dr.GetString(1);
                //lblLocation.Content = dr.GetString(2);
                //state = dr.GetInt32(4);
                //country = dr.GetInt32(3);
                lblCtryflag.Visibility = Visibility.Hidden;
            }
            dr.Close();

            //SqlCommand sqlcmd1 = new SqlCommand(query1, sqlcon);
            //sqlcmd1.CommandType = System.Data.CommandType.Text;
            //sqlcmd1.Parameters.AddWithValue("@sid", state);
            //SqlDataReader dr1 = sqlcmd1.ExecuteReader();
            // while (dr1.Read())
            //   {
            // lblState.Content = dr1.GetString(2);
            // }

            //  dr1.Close();

            //SqlCommand sqlcmd2 = new SqlCommand(query2, sqlcon);
            //sqlcmd2.CommandType = System.Data.CommandType.Text;
            //sqlcmd2.Parameters.AddWithValue("@cid", country);
            //SqlDataReader dr2 = sqlcmd2.ExecuteReader();
            //while (dr2.Read())
            //{
            //  //  lblCountry.Content = dr2.GetString(1);
            //}

            //dr2.Close();
            sqlcon.Close();
            lblcon.Visibility = Visibility.Visible;
            lblcons.Visibility = Visibility.Visible;
            lbliso2.Visibility = Visibility.Visible;
            lbliso3.Visibility = Visibility.Visible;
            //lblctryf.Visibility = Visibility.Visible;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.Show();//Open previouse page
            Window vc = (Window)this.Parent;
            vc.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Initialization.  
                //OpenFileDialog browseDialog = new OpenFileDialog();
                DataTable datatable = new DataTable();


                sqlcon.Open();
                string query1 = "SELECT * FROM [Country]";
                SqlCommand sqlcmd1 = new SqlCommand(query1, sqlcon);

                sqlcmd1.ExecuteNonQuery();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlcmd1);
                DataTable dt2 = new DataTable("Country");
                dataAdapter.Fill(dt2);
                //grdLoad.ItemsSource = dt2.DefaultView;
                sqlcon.Close();

            }
            catch (Exception ex)
            {
                // Info.  
                System.Windows.MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.Write(ex);
            }
        }

        //private void btnUpdate_Click(object sender, RoutedEventArgs e)
        //{

        //    countryname = lblCtryname.Content.ToString();
        //    countryshortname = lblCtrynameshort.Content.ToString();
        //    isocode2 = lblIsocode2.Content.ToString();
        //    isocode3 = lblIsocode3.Content.ToString();
        //    ctryflag = lblCtryflag.Content.ToString();
        //    MainWindow win = new MainWindow(countryname, countryshortname, isocode2, isocode3, ctryflag);
        //    win.Show();//Open previouse page
        //    Window vv = (Window)this.Parent;
        //    vv.Close();
        //}


    } 
}
