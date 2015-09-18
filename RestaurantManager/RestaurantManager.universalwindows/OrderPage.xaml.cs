using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using RestaurantManager.Models;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace RestaurantManager.universalwindows
{
    /// <summary>
    /// Order page - used to add menu items to order and create orders.
    /// Used by service staff (waiters/waitresses).
    /// </summary>
    public sealed partial class OrderPage : Page
    {
        public OrderPage()
        {
            this.InitializeComponent();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void AddToOrderButton_Click(object sender, RoutedEventArgs e)
        {
            // get reference to data source
            DataManager dm = App.Current.Resources["DataManager"] as DataManager;

            // add each selected menu item to the currently selected items
            foreach (Object OrderItem in this.MenuList.SelectedItems) {
                dm.CurrentlySelectedMenuItems.Add(OrderItem.ToString());
            }

            // remove selections
            this.MenuList.SelectedIndex = -1;
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            // get reference to data source
            DataManager dm = App.Current.Resources["DataManager"] as DataManager;

            // convert currently selected items to a single string
            String Order = String.Join(", ", dm.CurrentlySelectedMenuItems);

            // add to orders
            dm.OrderItems.Add(Order);

            // clear currently selected items
            dm.CurrentlySelectedMenuItems.Clear();
        }
    }
}
