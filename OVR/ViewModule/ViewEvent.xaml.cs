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
    /// Interaction logic for ViewEvent.xaml
    /// </summary>
    public partial class ViewEvent : Page
    {
        SqlConnection sqlcon = null;
        public ViewEvent()
        {
            InitializeComponent();
            var x = ConfigurationManager.AppSettings["connectionString"];
            sqlcon = new SqlConnection(x);
            fill_comboboxEventName();
        }
        string name = "";

        void fill_comboboxEventName()
        {
            sqlcon.Open();
            string query = "SELECT * FROM [TSR_Event] where EventName != ''";
            SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
            SqlDataReader dr = sqlcmd.ExecuteReader();
            while (dr.Read())
            {
                name = dr.GetString(1);
                cboEventCode.Items.Add(name);
            }
            sqlcon.Close();
        }
        int gender = 3;
        int eventtype = 0;
        //SqlConnection sqlcon = new SqlConnection(@"Data Source = LAPTOP-74F5FNT3\SQLEXPRESS; Initial Catalog=TSR; Integrated Security=true;");
        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            
            sqlcon.Open();
            string query = "SELECT * FROM [TSR_EVENT] where Eventname = @etc";
            string query1 = "SELECT * FROM [TSR_SPORT] where sportid = @sid";
            SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
            sqlcmd.CommandType = System.Data.CommandType.Text;
            sqlcmd.Parameters.AddWithValue("@etc", cboEventCode.Text);
            SqlDataReader dr = sqlcmd.ExecuteReader();
            while (dr.Read())
            {
                    lblEventName.Content = dr.GetString(1);
                    lblEventCode.Content = dr.GetString(2);
                    gender = dr.GetInt32(4);
                    eventtype = dr.GetInt32(3); 

            }
           

            dr.Close();

            SqlCommand sqlcmd1 = new SqlCommand(query1, sqlcon);
            sqlcmd1.CommandType = System.Data.CommandType.Text;
            sqlcmd1.Parameters.AddWithValue("@sid", eventtype);
            SqlDataReader dr1 = sqlcmd1.ExecuteReader();
            while (dr1.Read())
            {
                lblEventType.Content = dr1.GetString(3);
            }

            dr1.Close();
            sqlcon.Close();
            if (gender == 0)
            {
                lblGender.Content = "Male";
            }
            else if(gender == 1)
            {
                lblGender.Content = "Female";
            } else
            {
                lblGender.Content = "";
            }

            lblEC.Visibility = Visibility.Visible;
            lblEN.Visibility = Visibility.Visible;
            lblET.Visibility = Visibility.Visible;
            lblG.Visibility = Visibility.Visible;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.Show();//Open previouse page
            Window ve = (Window)this.Parent;
            ve.Close();
        }
    }
}
