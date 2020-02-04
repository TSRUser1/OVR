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
    /// Interaction logic for Event.xaml
    /// </summary>
    public partial class Event : Page
    {
        SqlConnection sqlcon = null;
        public Event()
        {
            InitializeComponent();
            var x = ConfigurationManager.AppSettings["connectionString"];
            sqlcon = new SqlConnection(x);
            fill_combobox();
        }
        //SqlConnection sqlcon = new SqlConnection(@"Data Source = LAPTOP-74F5FNT3\SQLEXPRESS; Initial Catalog=TSR; Integrated Security=true;");
        void fill_combobox()
        {
            sqlcon.Open();
            string query = "SELECT * FROM [TSR_SPORT]";
            SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
            SqlDataReader dr = sqlcmd.ExecuteReader();
            while(dr.Read())
            {
                string name = dr.GetString(3);
                cboEventType.Items.Add(name);
               
            }
            sqlcon.Close();
        }
        int sportID = 0;
        private void BtnSubmit_click(object sender, RoutedEventArgs e)
        {
            DateTime today = DateTime.Today;
            int genId = 0;
           

            if (txtEventName.Text == "")
            {
                MessageBox.Show("Event Name Cannot Be Empty!", "Error");
            }
            else if (txtEventCode.Text == "")
            {
                MessageBox.Show("Event Code Cannot Be Empty!", "Error");
            }
            else if(cboEventType.Text == "")
            {
                MessageBox.Show("Event Type Code Cannot Be Empty!", "Error");
            }
            else if (cboGender.Text == "")
            {
                MessageBox.Show("Please Select Your Gender", "Error");
            }
            else
            {
                if (cboGender.Text == "Female")
                {
                    genId = 1;
                }
                else
                {
                    genId = 0;
                }

                sqlcon.Open();
                string query = "SELECT * FROM [TSR_SPORT] where sportName = @spid";
                SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.CommandType = System.Data.CommandType.Text;
                sqlcmd.Parameters.AddWithValue("@spid", cboEventType.Text);
                SqlDataReader dr = sqlcmd.ExecuteReader();
                while (dr.Read())
                {
                    sportID = dr.GetInt32(0);
                }
                dr.Close();
                string query1 = "INSERT INTO [dbo].[TSR_Event] ([EventName],[EventCode],[SportID],[GenderID],[IsActive],[CreatedDateTime],[CreatedBy],[ModifiedDateTime],[ModifiedBy]) VALUES (@etn, @etc, @sid,@gid,1,@cdt,'1',@cdt,'1')";

                SqlCommand sqlcmd1 = new SqlCommand(query1, sqlcon);
                sqlcmd1.CommandType = System.Data.CommandType.Text;
                sqlcmd1.Parameters.AddWithValue("@etn", txtEventName.Text);
                sqlcmd1.Parameters.AddWithValue("@etc", txtEventCode.Text);
                sqlcmd1.Parameters.AddWithValue("@sid", sportID);
                sqlcmd1.Parameters.AddWithValue("@gid", genId);
                sqlcmd1.Parameters.AddWithValue("@cdt", today);
                sqlcmd1.ExecuteNonQuery();
                //SqlDataReader dr = sqlcmd.ExecuteReader();
                MessageBox.Show("Save Successfully","System");
                MainWindow win = new MainWindow();
                win.Show();//Open previouse page
                Window ev = (Window)this.Parent;
                ev.Close();

            }
        }
        private void BtnCancel_click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.Show();//Open previouse page
            Window ev = (Window)this.Parent;
            ev.Close();

        }
    }
}
