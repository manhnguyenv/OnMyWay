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
    /// Interaction logic for NewWaiterForm.xaml
    /// </summary>
    public partial class NewWaiterForm : UserControl
    {
        public NewWaiterForm()
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

        private void AddWaiter(object sender, RoutedEventArgs e)
        {
            Waiter NewWaiter = new Waiter();
            bool CanCommit = false;
            if (WaiterNameTextBox.Text.Length != 0)
            {
                NewWaiter.WaiterName = WaiterNameTextBox.Text;
                if (WaiterFirstnameTextBox.Text.Length != 0)
                {
                    NewWaiter.WaiterFirstname = WaiterFirstnameTextBox.Text;
                    if (WaiterGenderTextBox.Text.Length != 0)
                    {
                        if (WaiterGenderTextBox.Text == "Male" || WaiterGenderTextBox.Text == "male" || WaiterGenderTextBox.Text == "M" || WaiterGenderTextBox.Text == "m" ||
                            WaiterGenderTextBox.Text == "Femele" || WaiterGenderTextBox.Text == "female" || WaiterGenderTextBox.Text == "F" || WaiterGenderTextBox.Text == "f")
                        {
                            if ((WaiterGenderTextBox.Text == "Male" || WaiterGenderTextBox.Text == "male" || WaiterGenderTextBox.Text == "M" || WaiterGenderTextBox.Text == "m"))
                            {
                                NewWaiter.Gender = "Male";
                                CanCommit = true;
                            }
                            if ((WaiterGenderTextBox.Text == "Femele" || WaiterGenderTextBox.Text == "female" || WaiterGenderTextBox.Text == "F" || WaiterGenderTextBox.Text == "f"))
                            {
                                NewWaiter.Gender = "Female";
                                CanCommit = true;
                            }
                        }
                        else
                        {
                            PushMsg("Gender Error", "Invalid gender input.\n\nPlease Specify the waiters gender:\nMale - male - M - m for \"Male Gender\".\nFemale - female - F - f for \"Female Gender\".");
                        }
                    }
                    else { PushMsg("Gender Error", "Waiter needs a gender!"); }
                }
                else { PushMsg("Firstname Error", "Waiter needs a firstname!"); }
            }
            else { PushMsg("Name Error", "Waiter needs a name!"); }
            if (CanCommit == true)
            {
                NewWaiter.HandeledTables = 0;
                NewWaiter.MoneyEarned = 0;
                OnMyWayDatabase OnMyWayDb = new OnMyWayDatabase();
                OnMyWayDb.Waiters.Add(NewWaiter);
                OnMyWayDb.SaveChanges();
                PushMsg("Waiter Added", "Waiter was successfully added.\n\nPlease refresh Admin Panel to view changes.");
            }
        }
    }
}
