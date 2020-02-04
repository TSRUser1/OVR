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
using System.Data;

namespace OVR
{
    /// <summary>
    /// Interaction logic for ExportData1.xaml
    /// </summary>
    public partial class ExportData1 : Page
    {
        public ExportData1()
        {
            InitializeComponent();
        }
        SqlConnection sqlcon = new SqlConnection(@"Data Source = LAPTOP-74F5FNT3\SQLEXPRESS; Initial Catalog=TSR; Integrated Security=true;");
        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            string query2 = "SELECT * FROM [TSR_Contigent]";
            SqlCommand sqlcmd = new SqlCommand(query2, sqlcon);
            sqlcmd.ExecuteNonQuery();

            SqlDataAdapter dataadapter = new SqlDataAdapter(sqlcmd);
            ////DataTable

        }
    }
}
