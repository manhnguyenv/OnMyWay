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
    /// Interaction logic for TableOrder.xaml
    /// </summary>
    /// 

    public partial class TableOrder : UserControl
    {
        public TableOrder()
        {
            InitializeComponent();
        }

        public void SetterButtonGoToAdminPanel()
        {
            if (ButtonGoToAdminPanel.IsEnabled == true)
            {
                ButtonGoToAdminPanel.IsEnabled = false;
            }
            else { ButtonGoToAdminPanel.IsEnabled = true; }
        }
        private void EventGoToAdminPanel(object sender, RoutedEventArgs e)
        {
            var AdminPanelUI = new AdminPanel();
            AdminPanelUI.Owner = Window.GetWindow(this);
            AdminPanelUI.Owner.IsEnabled = false;
            AdminPanelUI.Show();
        }
    }
}
