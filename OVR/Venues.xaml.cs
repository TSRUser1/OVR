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
    /// Interaction logic for Venues.xaml
    /// </summary>
    public partial class Venues : Page
    {
        SqlConnection sqlcon = null;
        public Venues()
        {
            this.Name = "Venues";
            InitializeComponent();
            var x = ConfigurationManager.AppSettings["connectionString"];
            sqlcon = new SqlConnection(x);
            fill_combobox();
            fill_comboboxState();
        }
       // SqlConnection sqlcon = new SqlConnection(@"Data Source = LAPTOP-74F5FNT3\SQLEXPRESS; Initial Catalog=TSR; Integrated Security=true;");
        void fill_combobox()
        {
            sqlcon.Open();
            string query = "SELECT * FROM [TSR_Contigent] where CountryName != ''";
            SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
            SqlDataReader dr = sqlcmd.ExecuteReader();
            while (dr.Read())
            {
                string name = dr.GetString(1);
                cboVenueCountry.Items.Add(name);

            }
            sqlcon.Close();
        }

        void fill_comboboxState()
        {
            sqlcon.Open();
            string query = "SELECT * FROM [TSR_State] where StateName != ''";
            SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
            SqlDataReader dr = sqlcmd.ExecuteReader();
            while (dr.Read())
            {
                string name = dr.GetString(2);
                cboVenueState.Items.Add(name);

            }
            sqlcon.Close();
        }
        int country = 0;
        int state = 0;
        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            DateTime today = DateTime.Today;
            sqlcon.Open();

            string query1 = "SELECT * FROM [TSR_Contigent] where countryName = @spid";
            SqlCommand sqlcmd1 = new SqlCommand(query1, sqlcon);
            sqlcmd1.CommandType = System.Data.CommandType.Text;
            sqlcmd1.Parameters.AddWithValue("@spid", cboVenueCountry.Text);
            SqlDataReader dr1 = sqlcmd1.ExecuteReader();
            while (dr1.Read())
            {
                country = dr1.GetInt32(0);
            }
            dr1.Close();

            string query2 = "SELECT * FROM [TSR_State] where Statename = @spid";
            SqlCommand sqlcmd2 = new SqlCommand(query2, sqlcon);
            sqlcmd2.CommandType = System.Data.CommandType.Text;
            sqlcmd2.Parameters.AddWithValue("@spid", cboVenueState.Text);
            SqlDataReader dr2 = sqlcmd2.ExecuteReader();
            while (dr2.Read())
            {
                state = dr2.GetInt32(0);
            }
            dr2.Close();

            string query = "INSERT INTO [dbo].[TSR_Venue] ([VenueName],[Location],[Country],[State],[IsActive],[CreatedDateTime],[CreatedBy],[ModifiedDateTime],[ModifiedBy]) "
                + "VALUES (@vn, @lct, @vc,@vs,'1',@td,'1',@td,'1')";

            SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
            sqlcmd.CommandType = System.Data.CommandType.Text;
            sqlcmd.Parameters.AddWithValue("@vn", txtVName.Text);
            sqlcmd.Parameters.AddWithValue("@lct", txtLocation.Text);
            sqlcmd.Parameters.AddWithValue("@vc", country);
            sqlcmd.Parameters.AddWithValue("@vs", state);
            sqlcmd.Parameters.AddWithValue("@td", today);
            sqlcmd.ExecuteNonQuery();
            MessageBox.Show("Save Successfully", "System");
            //SqlDataReader dr = sqlcmd.ExecuteReader();
            MainWindow win = new MainWindow();
            win.Show();//Open previouse page
            Window sc = (Window)this.Parent;
            sc.Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.Show();//Open previouse page
            Window vn = (Window)this.Parent;
            vn.Close();
        }
    }
}
