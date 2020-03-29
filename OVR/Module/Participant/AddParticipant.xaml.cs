using System;
using System.Collections.Generic;
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
using System.Text.RegularExpressions;
using System.Configuration;

namespace OVR
{
    /// <summary>
    /// Interaction logic for Participant.xaml
    /// </summary>
    public partial class AddParticipant : Page
    {
        SqlConnection sqlcon = null;
        public AddParticipant()
        {
            InitializeComponent();
            var x = ConfigurationManager.AppSettings["connectionString"];
            sqlcon = new SqlConnection(x);
            fillmonth();
            fillyear();
            fillday();
        }
        int genId = 0;
        string country = "";
        int countryID = 0;
       // SqlConnection sqlcon = new SqlConnection(@"Data Source = LAPTOP-74F5FNT3\SQLEXPRESS; Initial Catalog=TSR; Integrated Security=true;");
        void fillyear()
        {
            int minYear = 1905;
            int currentYear = int.Parse(DateTime.Today.Year.ToString());
            int diff = currentYear - minYear;
            for(int i = minYear; i <= currentYear; i++)
            {
                cboyear.Items.Add(i);
            }
        }
        void fillmonth()
        {
            for (int i = 1; i <= 12; i++)
            {
                cbomonth.Items.Add(i);
            }
        }
        void fillday()
        {
            for (int i = 1; i <= 31; i++)
            {
                cboday.Items.Add(i);
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.Show();//Open previouse page
            Window pp = (Window)this.Parent;
            pp.Close();
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (cboGender.Text == "F")
            {
                genId = 1;
            }
            else
            {
                genId = 0;
            }

            if(txtAccreditationN.Text == "")
            {
                MessageBox.Show("Accreditation Number Cannot Be Empty","Error Message");
            } else if(txtPartName.Text == "")
            {
                MessageBox.Show("Full Name Cannot Be Empty", "Error Message");
            } else if (txtFamName.Text == "")
            {
                MessageBox.Show("Family Name Cannot Be Empty", "Error Message");
            }
            else if (txtGivName.Text == "")
            {
                MessageBox.Show("Given Name Cannot Be Empty", "Error Message");
            }
            else if (txtIpcNo.Text == "")
            {
                MessageBox.Show("IPC No Cannot Be Empty", "Error Message");
            }
            else if (txtWeight.Text == "") 
            {
                MessageBox.Show("Weight Cannot Be Empty", "Error Message");
            }
            else if (txtHeight.Text == "")
            {
                MessageBox.Show("Height Cannot Be Empty", "Error Message");
            }
            else if (txtCountry.Text == "")
            {
                MessageBox.Show("Country Cannot Be Empty", "Error Message");
            }
            else if (cboday.Text == "")
            {
                MessageBox.Show("Date Cannot Be Empty", "Error Message");
            }
            else if (cbomonth.Text == "")
            {
                MessageBox.Show("Month Cannot Be Empty", "Error Message");
            }
            else if (cboyear.Text == "")
            {
                MessageBox.Show("Year Cannot Be Empty", "Error Message");
            }



            if (txtCountry.Text != "")
            {
                
                sqlcon.Open();
                string query = "SELECT * FROM [TSR_Contigent] where CountryName = @cn";
                 SqlCommand sqlcmd1 = new SqlCommand(query, sqlcon);
                sqlcmd1.CommandType = System.Data.CommandType.Text;
                sqlcmd1.Parameters.AddWithValue("@cn", txtCountry.Text);
                SqlDataReader dr = sqlcmd1.ExecuteReader();
                if(dr != null)
                {
                    while (dr.Read())
                    {
                        countryID = dr.GetInt32(0);
                        country = dr.GetString(1);
                    }
                    if (country != "")
                    {
                        txtCountry.Text = Convert.ToString(country);
                    }
                    else
                    {
                        string s = txtCountry.Text;
                        string final = s.Substring(0, 2);
                        SqlCommand sqlcmd2 = new SqlCommand("SP_I_InsertContigent", sqlcon);
                        sqlcmd2.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlcmd2.Parameters.AddWithValue("@countryname", txtCountry.Text);
                        sqlcmd2.Parameters.AddWithValue("@countrynameshort", final);
                        sqlcmd2.Parameters.AddWithValue("@isocode2", "");
                        sqlcmd2.Parameters.AddWithValue("@isocode3", "");
                        sqlcmd2.Parameters.AddWithValue("@flagimagefilepath", "");
                        sqlcmd2.Parameters.AddWithValue("@iconfilepath", "");
                        sqlcmd2.Parameters.AddWithValue("@smalliconfilepath", "");
                        sqlcmd2.Parameters.AddWithValue("@regionid", 0);
                        dr.Close();
                        sqlcmd2.ExecuteNonQuery();

                        SqlCommand sqlcmd3 = new SqlCommand(query, sqlcon);
                        sqlcmd3.CommandType = System.Data.CommandType.Text;
                        sqlcmd3.Parameters.AddWithValue("@cn", txtCountry.Text);
                        SqlDataReader dr1 = sqlcmd3.ExecuteReader();
                        while (dr1.Read())
                        {
                            countryID = dr1.GetInt32(0);
                            country = dr1.GetString(1);
                        }
                    }
                   
                }

                sqlcon.Close();

            }

            DateTime today = DateTime.Today;
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand("SP_I_InsertParticipant", sqlcon);
            sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@accreditation_no", txtAccreditationN.Text);
            sqlcmd.Parameters.AddWithValue("@fullname", txtPartName.Text);
            sqlcmd.Parameters.AddWithValue("@familyname",txtFamName.Text);
            sqlcmd.Parameters.AddWithValue("@givenname",txtGivName.Text);
            sqlcmd.Parameters.AddWithValue("@ipcno",txtIpcNo.Text);
            sqlcmd.Parameters.AddWithValue("@weight",Int32.Parse(txtWeight.Text));
            sqlcmd.Parameters.AddWithValue("@height", Int32.Parse(txtHeight.Text));
            sqlcmd.Parameters.AddWithValue("@countryid", countryID);
            sqlcmd.Parameters.AddWithValue("@passport",txtPassport.Text);
            sqlcmd.Parameters.AddWithValue("@date_d", cboday.Text);
            sqlcmd.Parameters.AddWithValue("@date_m", cbomonth.Text);
            sqlcmd.Parameters.AddWithValue("@date_y", cboyear.Text);
            sqlcmd.Parameters.AddWithValue("@GenderID", genId);
            //sqlcmd.Parameters.AddWithValue("@td", txtWeight);
            //sqlcmd.Parameters.AddWithValue("@td", txtHeight);
            
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
