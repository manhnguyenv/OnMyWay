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
    /// Interaction logic for NewDisheForm.xaml
    /// </summary>
    public partial class NewDisheForm : UserControl
    {
        public NewDisheForm()
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

        private void AddDishe(object sender, RoutedEventArgs e)
        {
            Dishe NewDishe = new Dishe();
            bool CanCommit = false;
            if (DisheNameTextBox.Text.Length != 0 )
            {
                NewDishe.DisheName = DisheNameTextBox.Text;
                if (DisheDescriptionTextBox.Text.Length != 0)
                {
                    NewDishe.DisheDescription = DisheDescriptionTextBox.Text;
                    if (DishePriceTextBox.Text.Length != 0)
                    {
                        try
                        {
                            NewDishe.DishePrice = double.Parse(DishePriceTextBox.Text);
                            CanCommit = true;
                        }
                        catch
                        {
                            PushMsg("Price Error", "Invalid price input!");
                        }
                    }
                    else { PushMsg("Price Error", "Dishe needs a price!"); }
                }
                else { PushMsg("Description Error", "Dishe needs a description!"); }
            }
            else { PushMsg("Name Error", "Dishe needs a name!"); }
            if (CanCommit == true)
            {
                OnMyWayDatabase OnMyWayDb = new OnMyWayDatabase();
                OnMyWayDb.Dishes.Add(NewDishe);
                OnMyWayDb.SaveChanges();
                PushMsg("Dishe Added", "Dishe was successfully added.\n\nPlease refresh Admin Panel to view changes.");
            }
        }
    }
}
