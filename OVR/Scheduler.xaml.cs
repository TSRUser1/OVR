using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for Scheduler.xaml
    /// </summary>
    public partial class Scheduler : Page
    {
        SqlConnection sqlcon = null;
        public Scheduler()
        {
            InitializeComponent();
            var x = ConfigurationManager.AppSettings["connectionString"];
            sqlcon = new SqlConnection(x);

            this.Name = "Scheduler";

            //fillmonth();
            //fillyear();
            //fillday();
            todaydate();
            setvenue();
            setLocation();
        }
        string year = "";
        string month = "";
        string day = "";
        string location = "";
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void setLocation()
        {
            sqlcon.Open();
            string query = "SELECT * FROM [TSR_Venue] where VenueName != ''";
            SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
            SqlDataReader dr = sqlcmd.ExecuteReader();
            while (dr.Read())
            {
                location = dr.GetString(2);
                cboLocation.Items.Add(location);
            }
            sqlcon.Close();
        }
        private void todaydate()
        {
            DateTime today = DateTime.Today;
            dp1.Text = today.ToString();
            year = dp1.Text.Substring(0, 4);
            month = dp1.Text.Substring(5, 2);
            day = dp1.Text.Substring(8, 2);
        }
        string name = "";
        private void setvenue()
        {
            sqlcon.Open();
            string query = "SELECT * FROM [TSR_Venue] where VenueName != ''";
            SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
            SqlDataReader dr = sqlcmd.ExecuteReader();
            while (dr.Read())
            {
                name = dr.GetString(1);
                cboVenue.Items.Add(name);
            }
            sqlcon.Close();
        }

        //void fillyear()
        //{
        //    int minYear = 1905;
        //    int currentYear = int.Parse(DateTime.Today.Year.ToString());
        //    int diff = currentYear - minYear;
        //    for (int i = minYear; i <= currentYear; i++)
        //    {
        //        cboyear.Items.Add(i);
        //    }
        //}
        //void fillmonth()
        //{
        //    for (int i = 1; i <= 12; i++)
        //    {
        //        cbomonth.Items.Add(i);
        //    }
        //}
        //void fillday()
        //{
        //    for (int i = 1; i <= 31; i++)
        //    {
        //        cboday.Items.Add(i);
        //    }
        //}

        // SqlConnection sqlcon = new SqlConnection(@"Data Source = LAPTOP-74F5FNT3\SQLEXPRESS; Initial Catalog=TSR; Integrated Security=true;");
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.Show();//Open previouse page
            Window sh = (Window)this.Parent;
            sh.Close();
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            DateTime today = DateTime.Today;

            if (txtScheduleName.Text == "")
            {
                MessageBox.Show("Schedule Name Cannot Be Empty!", "Error");
            }
            else if (dp1.Text == "")
            {
                MessageBox.Show("Schedule Day Cannot Be Empty!", "Error");
            }
       
            else if (cboVenue.Text == "")
            {
                MessageBox.Show("Venue Cannot Be Empty!", "Error");
            }
            else if (cboLocation.Text == "")
            {
                MessageBox.Show("Location Cannot Be Empty!", "Error");
            }
            else if (txtRoundName.Text == "")
            {
                MessageBox.Show("Round Name Cannot Be Empty!", "Error");
            }
            else if (txtMatchNo.Text == "")
            {
                MessageBox.Show("Match No Cannot Be Empty!", "Error");
            }
            else if (txtTotalParticipant.Text == "")
            {
                MessageBox.Show("Match No Cannot Be Empty!", "Error");
            }
            else if (txtCompetitionStage.Text == "")
            {
                MessageBox.Show("Competition Stage Cannot Be Empty!", "Error");
            }
            else
            {
                sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand("SP_I_InsertSchedule", sqlcon);
                sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@sn", txtScheduleName.Text);
                sqlcmd.Parameters.AddWithValue("@date_d", day);
                sqlcmd.Parameters.AddWithValue("@date_m", month);
                sqlcmd.Parameters.AddWithValue("@date_y", year);
                sqlcmd.Parameters.AddWithValue("@rn", txtRoundName.Text);
                sqlcmd.Parameters.AddWithValue("@vn", cboVenue.Text);
                sqlcmd.Parameters.AddWithValue("@mn", txtMatchNo.Text);
                sqlcmd.Parameters.AddWithValue("@cs", txtCompetitionStage.Text);
                sqlcmd.Parameters.AddWithValue("@tp", txtTotalParticipant.Text);
                sqlcmd.Parameters.AddWithValue("@lc", cboLocation.Text);
                sqlcmd.ExecuteNonQuery();

                MessageBox.Show("Save Successfully", "System");
                //SqlDataReader dr = sqlcmd.ExecuteReader();
                MainWindow win = new MainWindow();
                win.Show();//Open previouse page
                Window sc = (Window)this.Parent;
                sc.Close();
            }


        }

      
    }
}
