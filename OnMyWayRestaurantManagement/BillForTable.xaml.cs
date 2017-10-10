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
    /// Interaction logic for BillForTable.xaml
    /// </summary>
    public partial class BillForTable : UserControl
    {
        public BillForTable()
        {
            InitializeComponent();
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
        double TotalPrice = 0;

        public void ShowDishes()
        {
            OnMyWayDatabase OnMyWayDb = new OnMyWayDatabase();
            var TableSelectedQuery = (from t in OnMyWayDb.TableSelecteds
                                      where t.Id == 1
                                      select t).FirstOrDefault();
            if (TableSelectedQuery.TableId != 0)
            {
                var GetTableSelected = (from t in OnMyWayDb.Tables
                                        where t.TableId == TableSelectedQuery.TableId
                                        select t).FirstOrDefault();
                if (GetTableSelected.DisheList != null)
                {
                    var DisheId = GetTableSelected.DisheList.Split(',');

                    List<Dishe> dishes = new List<Dishe>();
                    TotalPrice = 0;
                    foreach (var dishe in DisheId)
                    {
                        if (dishe != "")
                        {
                            int disheId = Convert.ToInt32(dishe);
                            var GetDishesQuery = (from d in OnMyWayDb.Dishes
                                                  where d.DisheId == disheId
                                                    select d).FirstOrDefault();
                            dishes.Add(new Dishe() { DisheId = GetDishesQuery.DisheId, DisheName = GetDishesQuery.DisheName, DisheDescription = GetDishesQuery.DisheDescription, DishePrice = GetDishesQuery.DishePrice });
                            TotalPrice += GetDishesQuery.DishePrice;
                        }
                    }
                    BillPaymentListView.ItemsSource = dishes;
                    Total.Text = TotalPrice.ToString();
                }
            }
            else
            {
                PushMsg("No Table Selected", "Please select a table for the order.");
            }
        }

        private void SubmitPayment(object sender, RoutedEventArgs e)
        {
            OnMyWayDatabase OnMyWayDb = new OnMyWayDatabase();
            var TableSelectedQuery = (from t in OnMyWayDb.TableSelecteds
                                      where t.Id == 1
                                      select t).FirstOrDefault();
            if (TableSelectedQuery.TableId != 0)
            {
                var GetTableSelected = (from t in OnMyWayDb.Tables
                                        where t.TableId == TableSelectedQuery.TableId
                                        select t).FirstOrDefault();
                var GetWaiterQuery = (from w in OnMyWayDb.Waiters
                                      where w.WaiterId == GetTableSelected.TableWaiter
                                      select w).FirstOrDefault();
                GetWaiterQuery.MoneyEarned += TotalPrice;
                GetTableSelected.TableStatus = "Empty";
                GetTableSelected.TableWaiter = 0;
                GetTableSelected.DisheList = "";
                OnMyWayDb.SaveChanges();
                PushMsg("Bill PAID", "Bill for table " + TableSelectedQuery.TableId + " has been paid.\nTable is now empty.");
            }
            else
            {
                PushMsg("No Table Selected", "Please select a table for the order.");
            }
        }

        private void RefreshBill(object sender, RoutedEventArgs e)
        {
            ShowDishes();
        }
    }
}
