using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace OVR.Service
{
    public class PageRenderService
    {
        public void RenderPages(object page, List<TabItem> tabItems, TabControl tabControl)
        {
            int count = tabItems.Count + 1;
            var pageObject = page as Page;
            string uniqueName = pageObject.Name + "_" + Guid.NewGuid().ToString().Replace("-", "");
            TabItem tabitem = new TabItem { Header = pageObject.Name + " " + count, Name = uniqueName };
            Frame tabFrame = new Frame { Content = pageObject };
            tabitem.Content = tabFrame;
            tabitem.HeaderTemplate = tabControl.FindResource("TabHeader") as DataTemplate;
            tabControl.Items.Add(tabitem);
            tabControl.SelectedItem = tabitem;
            tabItems.Insert(count - 1, tabitem);
        }
    }
}
