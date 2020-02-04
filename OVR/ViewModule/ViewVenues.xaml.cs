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

namespace OVR.ViewModule
{
    /// <summary>
    /// Interaction logic for ViewVenues.xaml
    /// </summary>
    public partial class ViewVenues : Page
    {
        SqlConnection sqlcon = null;
        public ViewVenues()
        {
            InitializeComponent();
            var x = ConfigurationManager.AppSettings["connectionString"];
            sqlcon = new SqlConnection(x);
            fill_comboboxVenueName();
        }
        //SqlConnection sqlcon = new SqlConnection(@"Data Source = LAPTOP-74F5FNT3\SQLEXPRESS; Initial Catalog=TSR; Integrated Security=true;");
        int state = 0;
        int country = 0;
        string name = "";

        void fill_comboboxVenueName()
        {
            sqlcon.Open();
            string query = "SELECT * FROM [TSR_Venue] where VenueName != ''";
            SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
            SqlDataReader dr = sqlcmd.ExecuteReader();
            while (dr.Read())
            {
                name = dr.GetString(1);
                cboVenueName.Items.Add(name);
            }
            sqlcon.Close();
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            sqlcon.Open();
            string query = "SELECT * FROM [TSR_Venue] where VenueName = @etc";
            string query1 = "SELECT * FROM [TSR_State] where StateId = @sid";
            string query2 = "SELECT * FROM [TSR_Contigent] where CountryId = @cid";
            SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
            sqlcmd.CommandType = System.Data.CommandType.Text;
            sqlcmd.Parameters.AddWithValue("@etc", cboVenueName.Text);
            SqlDataReader dr = sqlcmd.ExecuteReader();
            while (dr.Read())
            {
                lblVenuesName.Content = dr.GetString(1);
                lblLocation.Content = dr.GetString(2);
                state = dr.GetInt32(4);
                country = dr.GetInt32(3);
            }
            dr.Close();

            SqlCommand sqlcmd1 = new SqlCommand(query1, sqlcon);
            sqlcmd1.CommandType = System.Data.CommandType.Text;
            sqlcmd1.Parameters.AddWithValue("@sid", state);
            SqlDataReader dr1 = sqlcmd1.ExecuteReader();
            while (dr1.Read())
            {
                lblState.Content = dr1.GetString(2);
            }

            dr1.Close();

            SqlCommand sqlcmd2 = new SqlCommand(query2, sqlcon);
            sqlcmd2.CommandType = System.Data.CommandType.Text;
            sqlcmd2.Parameters.AddWithValue("@cid", country);
            SqlDataReader dr2 = sqlcmd2.ExecuteReader();
            while (dr2.Read())
            {
                lblCountry.Content = dr2.GetString(1);
            }

            dr2.Close();
            sqlcon.Close();
            lblct.Visibility = Visibility.Visible;
            lbllc.Visibility = Visibility.Visible;
            lblst.Visibility = Visibility.Visible;
            lblvn.Visibility = Visibility.Visible;

        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.Show();//Open previouse page
            Window vv = (Window)this.Parent;
            vv.Close();
        }
    }
}
