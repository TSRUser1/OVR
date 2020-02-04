using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;

namespace OVR
{
    /// <summary>
    /// Interaction logic for ParticipantReport.xaml
    /// </summary>
    public partial class ParticipantReport : Page
    {
        public ParticipantReport()
        {
            InitializeComponent();
        }
        SqlConnection sqlcon = new SqlConnection(@"Data Source = LAPTOP-74F5FNT3\SQLEXPRESS; Initial Catalog=TSR; Integrated Security=true;");
        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
           
        }
        private DataTable GetData()
        {
            DataTable dt = new DataTable();
            using (SqlConnection sq = sqlcon)
            {
                string query = "SELECT * FROM [TSR_Participant] where Fullname != ''";
                SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                SqlDataAdapter adp = new SqlDataAdapter(sqlcmd);
                adp.Fill(dt);
            }
            return dt;
        }
    }
}
