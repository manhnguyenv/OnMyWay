using FirstFloor.ModernUI.Windows.Controls;
using System;
using System.Collections.Generic;
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

namespace OnMyWayRestaurantManagement
{
    /// <summary>
    /// Interaction logic for AdminWaiters.xaml
    /// </summary>
    public partial class AdminWaiters : UserControl
    {
        public AdminWaiters()
        {
            InitializeComponent();
            ShowWaiters();
        }

        private void PushMsg(string MsgTitle, string Msg)
        {
            var ErrorDialog = new ModernDialog
            {
                Title = MsgTitle,
                Content = Msg
            };
            ErrorDialog.Buttons = new Button[] { ErrorDialog.OkButton };
            ErrorDialog.ShowDialog();
        }

        private void ShowWaiters()
        {
            OnMyWayDatabase OnMyWayDb = new OnMyWayDatabase();
            var GetWaitersQuery = from w in OnMyWayDb.Waiters
                                 orderby w.WaiterId
                                 select w;
            List<Waiter> waiters = new List<Waiter>();
            foreach (Waiter waiter in GetWaitersQuery)
            {
                waiters.Add(new Waiter() { WaiterId = waiter.WaiterId, WaiterName = waiter.WaiterName, WaiterFirstname = waiter.WaiterFirstname, Gender = waiter.Gender, HandeledTables = waiter.HandeledTables, MoneyEarned = waiter.MoneyEarned });
            }

            WaitersDataGrid.ItemsSource = waiters;
        }

        private void EventDeleteWaiters(object sender, RoutedEventArgs e)
        {
            OnMyWayDatabase OnMyWayDb = new OnMyWayDatabase();
            Waiter Awaiter = new Waiter();
            bool CanCommit = false;
            for (int i = 0; i < WaitersDataGrid.SelectedItems.Count; i++)
            {
                if (CanCommit == false) CanCommit = true;
                Awaiter = (Waiter)WaitersDataGrid.SelectedItems[i];
                var GetWaitersQuery = from w in OnMyWayDb.Waiters
                                      where w.WaiterId == Awaiter.WaiterId
                                     select w;
                foreach (Waiter waiter in GetWaitersQuery)
                {
                    OnMyWayDb.Waiters.Remove(waiter);
                }

            }
            if (CanCommit == true)
            {
                OnMyWayDb.SaveChanges();
                PushMsg("Waiter Deleted", "Selected waiters was successfully Deleted.");
                ShowWaiters();
            }
        }

        private void EventAddWaiter(object sender, RoutedEventArgs e)
        {
            NewWaiter NewWaiterMUI = new NewWaiter();
            NewWaiterMUI.Owner = Window.GetWindow(this);
            NewWaiterMUI.Owner.IsEnabled = false;
            NewWaiterMUI.Show();
        }

        private void EventUpdateWaiters(object sender, RoutedEventArgs e)
        {
            OnMyWayDatabase OnMyWayDb = new OnMyWayDatabase();
            Waiter Awaiter = new Waiter();
            bool CanCommit = false;
            for (int i = 0; i < WaitersDataGrid.Items.Count; i++)
            {
                if (CanCommit == false) CanCommit = true;
                Awaiter = (Waiter)WaitersDataGrid.Items[i];
                var GetWaitersQuery = (from w in OnMyWayDb.Waiters
                                      where w.WaiterId == Awaiter.WaiterId
                                      select w).FirstOrDefault();
                GetWaitersQuery.WaiterName = Awaiter.WaiterName;
                GetWaitersQuery.WaiterFirstname = Awaiter.WaiterFirstname;
                GetWaitersQuery.Gender = Awaiter.Gender;
            }
            if (CanCommit == true)
            {
                OnMyWayDb.SaveChanges();
                PushMsg("Waiters Saved", "All changes to waiters have been saved.");
                ShowWaiters();
            }
        }

        private void ShowWaiters(object sender, RoutedEventArgs e)
        {
            ShowWaiters();
        }
    }
}
