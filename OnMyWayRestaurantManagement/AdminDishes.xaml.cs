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
    /// Interaction logic for AdminDishes.xaml
    /// </summary>
    public partial class AdminDishes : UserControl
    {
        public AdminDishes()
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
            
            DishesDataGrid.ItemsSource = dishes;
        }

        private void EventDeleteDishes(object sender, RoutedEventArgs e)
        {
            OnMyWayDatabase OnMyWayDb = new OnMyWayDatabase();
            Dishe Adishe = new Dishe();
            bool CanCommit = false;
            for (int i = 0; i < DishesDataGrid.SelectedItems.Count; i++)
            {
                if (CanCommit == false) CanCommit = true;
                Adishe = (Dishe)DishesDataGrid.SelectedItems[i];
                var GetDishesQuery = from d in OnMyWayDb.Dishes
                                     where d.DisheId == Adishe.DisheId
                                     select d;
                foreach (Dishe dishe in GetDishesQuery)
                {
                    OnMyWayDb.Dishes.Remove(dishe);
                }
                
            }
            if (CanCommit == true)
            {
                OnMyWayDb.SaveChanges();
                PushMsg("Dishe Deleted", "Selected dishes was successfully Deleted.");
                ShowDishes();
            }
        }

        private void EventAddDishe(object sender, RoutedEventArgs e)
        {
            NewDishe NewDisheMUI = new NewDishe();
            NewDisheMUI.Owner = Window.GetWindow(this);
            NewDisheMUI.Owner.IsEnabled = false;
            NewDisheMUI.Show();
        }

        private void EventUpdateDishes(object sender, RoutedEventArgs e)
        {
            OnMyWayDatabase OnMyWayDb = new OnMyWayDatabase();
            Dishe Adishe = new Dishe();
            bool CanCommit = false;
            for (int i = 0; i < DishesDataGrid.Items.Count; i++)
            {
                if (CanCommit == false) CanCommit = true;
                Adishe = (Dishe)DishesDataGrid.Items[i];
                var GetDishesQuery = (from d in OnMyWayDb.Dishes
                                     where d.DisheId == Adishe.DisheId
                                     select d).FirstOrDefault();
                GetDishesQuery.DisheName = Adishe.DisheName;
                GetDishesQuery.DisheDescription = Adishe.DisheDescription;
                GetDishesQuery.DishePrice = Adishe.DishePrice;
            }
            if (CanCommit == true)
            {
                OnMyWayDb.SaveChanges();
                PushMsg("Dishes Saved", "All changes to dishes have been saved.");
                ShowDishes();
            }
        }

        private void ShowDishes(object sender, RoutedEventArgs e)
        {
            ShowDishes();
        }
    }
}
