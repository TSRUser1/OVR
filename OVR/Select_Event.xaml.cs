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
    /// Interaction logic for Select_Event.xaml
    /// </summary>
    public partial class Select_Event : Page
    {
        SqlConnection sqlcon = null;
        public Select_Event()
        {
            InitializeComponent();
            var x = ConfigurationManager.AppSettings["connectionString"];
            sqlcon = new SqlConnection(x);
            fill_comboboxEvent();
            fill_comboboxSchedule();
        }
        int eventid = 0;
        int scheduleid = 0;
        void fill_comboboxEvent()
        {
            sqlcon.Open();
            string query = "SELECT * FROM [TSR_Event]";
            SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
            SqlDataReader dr = sqlcmd.ExecuteReader();
            while (dr.Read())
            {
                string name = dr.GetString(1);
                eventid = dr.GetInt32(0);
                cboEventName.Items.Add(name);

            }
            sqlcon.Close();
        }

        void fill_comboboxSchedule()
        {
            sqlcon.Open();
            string query = "SELECT * FROM [TSR_Schedule]";
            SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
            SqlDataReader dr = sqlcmd.ExecuteReader();
            while (dr.Read())
            {
                string name = dr.GetString(2);
                scheduleid = dr.GetInt32(0);
                cboScheduleName.Items.Add(name);

            }
            sqlcon.Close();
        }
        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
           // DateTime today = DateTime.Today;
            sqlcon.Open();

            string query1 = "UPDATE [TSR_Schedule] set eventid = @eid where Scheduleid = @spid";
            SqlCommand sqlcmd1 = new SqlCommand(query1, sqlcon);
            sqlcmd1.CommandType = System.Data.CommandType.Text;
            sqlcmd1.Parameters.AddWithValue("@eid", eventid);
            sqlcmd1.Parameters.AddWithValue("@spid", scheduleid);
            sqlcmd1.ExecuteNonQuery();
            MessageBox.Show("Save Successfully", "System");
            MainWindow win = new MainWindow();
            win.Show();//Open previouse page
            Window sc = (Window)this.Parent;
            sc.Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            Window se = (Window)this.Parent;
            se.Close();
        }
    }
}
