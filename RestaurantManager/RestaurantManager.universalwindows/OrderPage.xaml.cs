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
    /// An empty page that can be used on its own or navigated to within a Frame.
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
        {// need to check for nulls!
            String OrderItem = this.MenuList.SelectedItem.ToString();
            DataManager dm = App.Current.Resources["DataManager"] as DataManager;
            dm.CurrentlySelectedMenuItems.Add(OrderItem);
            this.OrderItems.ItemsSource = dm.CurrentlySelectedMenuItems;
        }
    }
}
