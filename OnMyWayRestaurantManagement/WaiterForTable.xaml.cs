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
    /// Interaction logic for WaiterForTable.xaml
    /// </summary>
    public partial class WaiterForTable : UserControl
    {
        public WaiterForTable()
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

        public void ShowWaiters()
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

            AvailableWaitersListView.ItemsSource = waiters;
        }

        private void ValidWaiter(object sender, RoutedEventArgs e)
        {
            OnMyWayDatabase OnMyWayDb = new OnMyWayDatabase();
            var TableSelectedQuery = (from t in OnMyWayDb.TableSelecteds
                                      where t.Id == 1
                                      select t).FirstOrDefault();
            if (TableSelectedQuery.TableId != 0)
            {
                Waiter Awaiter = new Waiter();
                int TableWaiter = new int();
                Awaiter = (Waiter)AvailableWaitersListView.SelectedItems[0];
                TableWaiter = Awaiter.WaiterId;
                var GetSelectedTableQuery = (from t in OnMyWayDb.Tables
                                             where t.TableId == TableSelectedQuery.TableId
                                             select t).FirstOrDefault();
                GetSelectedTableQuery.TableWaiter = TableWaiter;
                var GetWaiterQuery = (from w in OnMyWayDb.Waiters
                                      where w.WaiterId == TableWaiter
                                      select w).FirstOrDefault();
                GetWaiterQuery.HandeledTables++;
                GetSelectedTableQuery.TableWaiter = TableWaiter;
                OnMyWayDb.SaveChanges();
                PushMsg("Assigned  Waiter", GetWaiterQuery.WaiterFirstname + " have been assigned to table: " + TableSelectedQuery.TableId);
            }
            else
            {
                PushMsg("No Table Selected", "Please select a table for the order.");
            }
        }

        private void RefreshWaiterList(object sender, RoutedEventArgs e)
        {
            ShowWaiters();
        }
    }
}
