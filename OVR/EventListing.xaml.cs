using ExcelDataReader;
using OVR.DataClass;
using OVR.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using Z.Dapper.Plus;

namespace OVR
{
    /// <summary>
    /// Interaction logic for EventListing.xaml
    /// </summary>
    public partial class EventListing : Page
    {
        DatabaseService databaseService = new DatabaseService();
       
        DataTable eventDataTable = new DataTable();
        public EventListing()
        {
            InitializeComponent();
            this.LoadCurrentEvent();
        }

        private void LoadCurrentEvent()
        {

            var startupEvent = " Select e.EventName, e.EventCode, s.SportName, case e.GenderId when 0 then 'Female' else 'Male' end as Gender," +
                                "case e.IsActive when 0 then 'Inactive' else 'Active' end as Status from TSR_Event e join TSR_Sport s on e.SportID = s.SportID";

            eventDataTable = databaseService.ExecuteSelectQuery(startupEvent);

            if (eventDataTable != null)
            {
                List<EventsList> events = new List<EventsList>();
                for (int i = 0; i < eventDataTable.Rows.Count; i++)
                {
                    events.Add(new EventsList
                    {
                        EventName = eventDataTable.Rows[i]["EventName"].ToString(),
                        EventCode = eventDataTable.Rows[i]["EventCode"].ToString(),
                        SportName = eventDataTable.Rows[i]["SportName"].ToString(),
                        Gender = eventDataTable.Rows[i]["Gender"].ToString(),
                        Status = eventDataTable.Rows[i]["Status"].ToString()
                    });
                }
                if (dataGrid.Items.Count > 0)
                {
                    dataGrid.ItemsSource = null;
                }
                dataGrid.ItemsSource = events;
            }

        }

        private void btnSearchEvent_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEventNameSearch.Text))
            {
                var startupEvent = " Select e.EventName, e.EventCode, s.SportName, case e.GenderId when 0 then 'Female' else 'Male' end as Gender," +
                                "case e.IsActive when 0 then 'Inactive' else 'Active' end as Status from TSR_Event e join TSR_Sport s on e.SportID = s.SportID "+
                                "where s.sportname like'%'+@sportName+'%' or e.EventName like '%'+@sportName+'%'";
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                sqlParameters.Add(new SqlParameter
                {
                   ParameterName ="sportName",
                   Value = txtEventNameSearch.Text
                });

                var searchedEventDataTable = databaseService.ExecuteSelectQueryWithOptions(startupEvent, sqlParameters);
                if (searchedEventDataTable != null)
                {
                    dataGrid.ItemsSource= null;
                    List<EventsList> events = new List<EventsList>();
                    for (int i = 0; i < searchedEventDataTable.Rows.Count; i++)
                    {
                        events.Add(new EventsList
                        {
                            EventName = searchedEventDataTable.Rows[i]["EventName"].ToString(),
                            EventCode = searchedEventDataTable.Rows[i]["EventCode"].ToString(),
                            SportName = searchedEventDataTable.Rows[i]["SportName"].ToString(),
                            Gender = searchedEventDataTable.Rows[i]["Gender"].ToString(),
                            Status = searchedEventDataTable.Rows[i]["Status"].ToString()
                        });
                    }
                    dataGrid.ItemsSource = events;
                }
            }
            else
            {
                this.LoadCurrentEvent();
            }
           
        }

        private void btnNewEvent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Event eventPage = new Event();
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
