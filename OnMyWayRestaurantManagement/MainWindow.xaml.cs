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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : ModernWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public Table TableSelected = new Table();
        protected override void OnClosed(EventArgs e)
        {
            OnMyWayDatabase OnMyWayDb = new OnMyWayDatabase();
            var TableSelectedQuery = (from t in OnMyWayDb.TableSelecteds
                                      where t.Id == 1
                                      select t).FirstOrDefault();
            TableSelectedQuery.TableId = 0;
            OnMyWayDb.SaveChanges();
            base.OnClosed(e);
            Application.Current.Shutdown();
        }
    }

}
