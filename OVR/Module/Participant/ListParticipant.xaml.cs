using ExcelDataReader;
using OVR.DataClass;
using OVR.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using Z.Dapper.Plus;

namespace OVR
{
    /// <summary>
    /// Interaction logic for EventListing.xaml
    /// </summary>
    public partial class ListParticipant : Page
    {
        DatabaseService databaseService = new DatabaseService();

        public ListParticipant()
        {
            InitializeComponent();
            this.LoadEventComboBox();
            this.LoadSportComboBox();
            this.LoadCurrentEvent();
        }

        private void LoadCurrentEvent()
        {

            var startupEvent = " Select e.EventName, e.EventCode, s.SportName, case e.GenderId when 0 then 'Female' else 'Male' end as Gender," +
                                "case e.IsActive when 0 then 'Inactive' else 'Active' end as Status from TSR_Event e join TSR_Sport s on e.SportID = s.SportID";

            var eventDataTable = databaseService.ExecuteSelectWithDapper(startupEvent);

            if (eventDataTable != null)
            {
                List<EventsList> events = eventDataTable.Select(c => new EventsList
                {
                    Gender = c.Gender,
                    EventName = c.EventName,
                    Status = c.Status,
                    EventCode = c.EventCode,
                    SportName = c.SportName
                }).ToList();

                dataGrid.ItemsSource = events;
            }

        }

        private void LoadSportComboBox()
        {
            var sportQuery = "Select SportId, SportName from TSR_Sport";
            var sportLookup = databaseService.ExecuteSelectQuery(sportQuery);

            if (sportLookup != null)
            {
                DataSet ds = new DataSet();
                ds.Tables.Add(sportLookup);
                ComboSport.ItemsSource = ds.Tables[0].DefaultView;
                ComboSport.DisplayMemberPath = "SportName";
                ComboEvent.SelectedValuePath = "SportId";
            }
        }

        private void LoadEventComboBox()
        {
            var eventQuery = " Select EventId, EventName from TSR_Event where IsActive = 1";
            var eventLookup = databaseService.ExecuteSelectQuery(eventQuery);

            if (eventLookup != null)
            {
                DataSet ds = new DataSet();
                ds.Tables.Add(eventLookup);
                ComboEvent.ItemsSource = ds.Tables[0].DefaultView;
                ComboEvent.DisplayMemberPath = "EventName";
                ComboEvent.SelectedValuePath = "EventId";
            }
        }

        private void btnSearchParticipant_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEventNameSearch.Text))
            {
                var startupEvent = " Select e.EventName, e.EventCode, s.SportName, case e.GenderId when 0 then 'Female' else 'Male' end as Gender," +
                                "case e.IsActive when 0 then 'Inactive' else 'Active' end as Status from TSR_Event e join TSR_Sport s on e.SportID = s.SportID " +
                                "where s.sportname like'%'+@SportName+'%' or e.EventName like '%'+@SportName+'%'";

                var sqlParam = new {SportName = txtEventNameSearch.Text};
                

                var searchedEventDataTable = databaseService.ExecuteSelectWithOptionDapper(startupEvent, sqlParam);
                if (searchedEventDataTable != null)
                {
                    dataGrid.ItemsSource = null;
                    List<EventsList> events = searchedEventDataTable.Select(c => new EventsList
                    {
                        Gender = c.Gender,
                        EventName = c.EventName,
                        Status = c.Status,
                        EventCode = c.EventCode,
                        SportName = c.SportName
                    }).ToList();

                    dataGrid.ItemsSource = events;
                }
            }
            else
            {
                this.LoadCurrentEvent();
            }

        }

        private void btnNewParticipant_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddParticipant eventPage = new AddParticipant();
                var win = new Window();
                win.Content = eventPage;
                win.Show();
            }
            catch (Exception ex)
            {

                System.Windows.MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.Show();//Open previouse page
            Window contigent = (Window)this.Parent;
            contigent.Close();
        }
    }
}
