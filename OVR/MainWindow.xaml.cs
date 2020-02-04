using OVR.ViewModule;
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
using System.Configuration;

namespace OVR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //SqlConnection sqlcon = x;
        //SqlConnection sqlcon = new SqlConnection(@"Data Source = LAPTOP-74F5FNT3\SQLEXPRESS; Initial Catalog=TSR; Integrated Security=true;");
        SqlConnection sqlcon = null;
        public MainWindow()
        {
            var x = ConfigurationManager.AppSettings["connectionString"];

            sqlcon = new SqlConnection(x);

            InitializeComponent();
            DataContext = new MyDataContext();
        }

        public MainWindow(string countryname, string countryshortname, string isocode2, string isocode3, string ctryflag)
        {

            InitializeComponent();
            DataContext = new MyDataContext();
            Contigent cg = new Contigent(countryname, countryshortname, isocode2, isocode3, ctryflag);
            this.Content = cg;
        }

        private void MnuNew_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                sqlcon.Open();
                MessageBox.Show("Connect Successfully", "Connect successfully", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                /// If you want the program to exit completely
                /// Environment.Exit(0);
            }
        }

        private void MnuClose_Click(object sender, RoutedEventArgs e)
        {
          
            if(sqlcon.State == System.Data.ConnectionState.Open)
            {
                sqlcon.Close();
                MessageBox.Show("Disconnect Successfully", "Disconnect successfully", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }else
            {
                MessageBox.Show("Warning", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                /// If you want the program to exit completely
                /// Environment.Exit(0);
            }
        }
        private void MnuContigents_Click(object sender, RoutedEventArgs e)
        {
            Contigent cg = new Contigent();
            this.Content = cg;

        }
     
        
        private void MnuEvents_Click(object sender, RoutedEventArgs e)
        {
            Event ev = new Event();
            this.Content = ev;

        }

        private void MnuViewEvents_Click(object sender, RoutedEventArgs e)
        {
            ViewEvent ve = new ViewEvent();
            this.Content = ve;

        }
        private void MnuSchedule_Click(object sender, RoutedEventArgs e)
        {
            Scheduler sh = new Scheduler();
            this.Content = sh;

        }
        private void MnuVenues_Click(object sender, RoutedEventArgs e)
        {
            Venues vn = new Venues();
            this.Content = vn;

        }
        private void MnuViewVenues_Click(object sender, RoutedEventArgs e)
        {
            ViewVenues vv = new ViewVenues();
            this.Content = vv;

        }

        private void MnuParticpant_Click(object sender, RoutedEventArgs e)
        {
            Participant pp = new Participant();
                this.Content = pp;
        }

        private void MnuViewContigent_Click(object sender, RoutedEventArgs e)
        {
            ViewContigent vc = new ViewContigent();
            this.Content = vc;
        }
        
        private void MnuImportData_Click(object sender, RoutedEventArgs e)
        {
            ImportData id = new ImportData();
            this.Content = id;
        }
        private void MnuExportData_Click(object sender, RoutedEventArgs e)
        {
            ExportData ed = new ExportData();
            this.Content = ed;
        }

        private void MnuSelectEvent_Click(object sender, RoutedEventArgs e)
        {
            Select_Event se = new Select_Event();
            this.Content = se;
        }

        private void MnuImportDataParticipant_Click(object sender, RoutedEventArgs e)
        {
            ImportParticipant ip = new ImportParticipant();
            this.Content = ip;
        } 
    }
}
