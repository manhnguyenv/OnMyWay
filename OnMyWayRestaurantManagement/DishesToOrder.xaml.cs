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
    /// Interaction logic for DishesToOrder.xaml
    /// </summary>
    public partial class DishesToOrder : UserControl
    {
        public DishesToOrder()
        {
            InitializeComponent();
            ShowDishes();
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

        public void ShowDishes()
        {
            OnMyWayDatabase OnMyWayDb = new OnMyWayDatabase();
            var GetDishesQuery = from d in OnMyWayDb.Dishes
                                 orderby d.DisheId
                                 select d;
            List<Dishe> dishes = new List<Dishe>();
            foreach (Dishe dishe in GetDishesQuery)
            {
                dishes.Add(new Dishe() { DisheId = dishe.DisheId, DisheName = dishe.DisheName, DisheDescription = dishe.DisheDescription, DishePrice = dishe.DishePrice });
            }
            
            AvailableDishesListView.ItemsSource = dishes;
        }

        private void SubmitOrder(object sender, RoutedEventArgs e)
        {
            OnMyWayDatabase OnMyWayDb = new OnMyWayDatabase();
            var TableSelectedQuery = (from t in OnMyWayDb.TableSelecteds
                                      where t.Id == 1
                                      select t).FirstOrDefault();
            if (TableSelectedQuery.TableId != 0)
            {
                Dishe Adishe = new Dishe();
                string OrderedDishes = "";
                for (int i = 0; i < AvailableDishesListView.SelectedItems.Count; i++)
                {
                    Adishe = (Dishe)AvailableDishesListView.SelectedItems[i];
                    OrderedDishes += Adishe.DisheId + ",";
                }
                var GetSelectedTableQuery = (from t in OnMyWayDb.Tables
                                             where t.TableId == TableSelectedQuery.TableId
                                             select t).FirstOrDefault();
                GetSelectedTableQuery.TableStatus = "Eating";
                GetSelectedTableQuery.DisheList = OrderedDishes;
                OnMyWayDb.SaveChanges();
                PushMsg("Ordered Dishes", "Selected dishes have been set for table: " + TableSelectedQuery.TableId);
            }
            else
            {
                PushMsg("No Table Selected", "Please select a table for the order.");
            }
        }

        private void RefreshDisheList(object sender, RoutedEventArgs e)
        {
            ShowDishes();
        }
    }
}
