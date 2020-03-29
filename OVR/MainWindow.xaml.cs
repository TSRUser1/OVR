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
using OVR.Service;

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

        public List<TabItem> _tabItems;
        PageRenderService pageRenderService = new PageRenderService();

        public MainWindow()
        {
            var x = ConfigurationManager.AppSettings["connectionString"];

            sqlcon = new SqlConnection(x);

            InitializeComponent();

            _tabItems = new List<TabItem>();

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

            if (sqlcon.State == System.Data.ConnectionState.Open)
            {
                sqlcon.Close();
                MessageBox.Show("Disconnect Successfully", "Disconnect successfully", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                MessageBox.Show("Warning", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                /// If you want the program to exit completely
                /// Environment.Exit(0);
            }
        }
        private void MnuContigents_Click(object sender, RoutedEventArgs e)
        {
            Contigent cg = new Contigent();
            pageRenderService.RenderPages(cg, _tabItems, tabDynamic);

        }


        private void MnuEvents_Click(object sender, RoutedEventArgs e)
        {
            ListEvent ev = new ListEvent();
            pageRenderService.RenderPages(ev, _tabItems, tabDynamic);

        }

        private void MnuViewEvents_Click(object sender, RoutedEventArgs e)
        {
            ListEvent ve = new ListEvent();
            pageRenderService.RenderPages(ve, _tabItems, tabDynamic);

        }
        private void MnuSchedule_Click(object sender, RoutedEventArgs e)
        {
            Scheduler sh = new Scheduler();
            pageRenderService.RenderPages(sh, _tabItems, tabDynamic);

        }
        private void MnuVenues_Click(object sender, RoutedEventArgs e)
        {

            Venues vn = new Venues();
            pageRenderService.RenderPages(vn, _tabItems, tabDynamic);
        }

        private void MnuViewVenues_Click(object sender, RoutedEventArgs e)
        {
            ViewVenues vv = new ViewVenues();
            pageRenderService.RenderPages(vv, _tabItems, tabDynamic);

        }

        private void MnuViewParticipant_Click(object sender, RoutedEventArgs e)
        {
            ListParticipant lp = new ListParticipant();
            pageRenderService.RenderPages(lp, _tabItems, tabDynamic);

        }

        private void MnuViewContigent_Click(object sender, RoutedEventArgs e)
        {
            ViewContigent vc = new ViewContigent();
            pageRenderService.RenderPages(vc, _tabItems, tabDynamic);
        }

        private void MnuImportData_Click(object sender, RoutedEventArgs e)
        {
            ImportData id = new ImportData();
            pageRenderService.RenderPages(id, _tabItems, tabDynamic);
        }
        private void MnuExportData_Click(object sender, RoutedEventArgs e)
        {
            ExportData ed = new ExportData();
            pageRenderService.RenderPages(ed, _tabItems, tabDynamic);
        }

        private void MnuSelectEvent_Click(object sender, RoutedEventArgs e)
        {
            Select_Event se = new Select_Event();
            pageRenderService.RenderPages(se, _tabItems, tabDynamic);
        }

        private void MnuImportDataParticipant_Click(object sender, RoutedEventArgs e)
        {
            ImportParticipant ip = new ImportParticipant();
            pageRenderService.RenderPages(ip, _tabItems, tabDynamic);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            string tabName = (sender as Button).CommandParameter.ToString();

            var item = tabDynamic.Items.Cast<TabItem>().Where(i => i.Name.Equals(tabName)).SingleOrDefault();

            TabItem tab = item as TabItem;

            if (tab != null)
            {
                if (MessageBox.Show(string.Format("Are you sure you want to remove the tab '{0}'?", tab.Header.ToString()),
                                   "Remove Tab", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    // get selected tab
                    TabItem selectedTab = tabDynamic.SelectedItem as TabItem;

                    _tabItems.Remove(tab);

                    if (_tabItems.Count > 0)
                    {
                        // clear tab control binding
                        tabDynamic.Items.Clear();
                        foreach (var tabItem in _tabItems)
                        {
                            tabDynamic.Items.Add(tabItem);
                        }

                        // select previously selected tab. if that is removed then select first tab
                        if (selectedTab == null || selectedTab.Equals(tab))
                        {
                            selectedTab = _tabItems[0];
                        }
                        tabDynamic.SelectedItem = selectedTab;
                    }
                    else
                    {
                        tabDynamic.Items.Clear();
                    }



                }
            }


        }
    }
}
