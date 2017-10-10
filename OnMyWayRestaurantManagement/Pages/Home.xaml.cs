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

namespace OnMyWayRestaurantManagement.Pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    /// 



    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();
            ShowTables();
        }
        
        List<Table> TableList = new List<Table>();
        ImageBrush EatingTable = new ImageBrush { ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/OnMyWayRestaurantManagement;component/Images/EatingTable.png", UriKind.Absolute)) };
        ImageBrush EmptyTable = new ImageBrush { ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/OnMyWayRestaurantManagement;component/Images/EmptyTable.png", UriKind.Absolute)) };
        ImageBrush ModelTable = new ImageBrush { ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/OnMyWayRestaurantManagement;component/Images/ModelTable.png", UriKind.Absolute)) };
        OnMyWayDatabase OnMyWayDb = new OnMyWayDatabase();

        public void ShowTables()
        {
            TableMapCanvas.Children.Clear();
            OnMyWayDb = new OnMyWayDatabase();
            TableList = new List<Table>();
            var GetTablesQuery = from t in OnMyWayDb.Tables
                                 orderby t.TableId
                                 select t;
            foreach (Table table in GetTablesQuery)
            {
                TableList.Add(table);
                CreateNewTable(table.TablePositionX, table.TablePositionY, table.TableId, false);
            }
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
        
        public void CreateNewTable(double PosX = 666, double PosY = 350, int TableId = 0, bool Add = true)
        {
            Table NewTable = new Table();
            OnMyWayDb = new OnMyWayDatabase();
            NewTable.TableStatus = "Empty";
            NewTable.table.Fill = EmptyTable;
            var GetSentTable = (from t in TableList
                                where t.TableId == TableId
                                select t).FirstOrDefault();
            if (GetSentTable != null)
            {
                if (GetSentTable.TableStatus.Contains("Eating"))
                {
                    NewTable.table.Fill = EatingTable;
                }
            }
            NewTable.TablePositionX = PosX;
            NewTable.TablePositionY = PosY;
            Point TablePosition = NewTable.table.TranslatePoint(new Point(0, 0), TableMapCanvas);
            Canvas.SetLeft(NewTable.table, NewTable.TablePositionX);
            Canvas.SetTop(NewTable.table, NewTable.TablePositionY);
            var TableSelectedQuery = (from t in OnMyWayDb.TableSelecteds
                                 where t.Id == 1
                                 select t).FirstOrDefault();
            MouseButtonEventHandler mouseUp = (sender, args) =>
            {
                var UITableElement = (UIElement)sender;
                BBCodeBlock GoToTableOrder = new BBCodeBlock();
                GoToTableOrder.LinkNavigator.Navigate(new Uri("/TableOrder.xaml", UriKind.Relative), this);
               
                TableSelectedQuery.TableId = TableId;
                OnMyWayDb.SaveChanges();
                UITableElement.ReleaseMouseCapture();
            };
            MouseEventHandler mouseMove = (sender, args) =>
            {
                TableInfo.IsExpanded = true;
                var TableToUpdate = (from t in TableList
                                     where t.TableId == TableId
                                     select t).FirstOrDefault();
                TablePosition = NewTable.table.TranslatePoint(new Point(0, 0), TableMapCanvas);
                XPosition.Text = "Pos.X: " + TablePosition.X; YPosition.Text = "Pos.Y: " + TablePosition.Y;

                if (TableToUpdate != null) { 
                    TableIdTextBlock.Text = TableId.ToString(); TableStatus.Text = TableToUpdate.TableStatus; TableToUpdate.TablePositionX = TablePosition.X; TableToUpdate.TablePositionY = TablePosition.Y;
                    var TableCurWaiter = (from w in OnMyWayDb.Waiters
                                         where w.WaiterId == TableToUpdate.TableWaiter
                                         select w).FirstOrDefault();
                    if (TableCurWaiter != null)
                    {
                        TableWaiterTextBlock.Text = TableCurWaiter.WaiterName + " " + TableCurWaiter.WaiterFirstname;
                    }
                }
            };
            Action<UIElement> Interact = (UITableElement) =>
            {
                UITableElement.MouseMove += mouseMove;
                UITableElement.MouseUp += mouseUp;
            };
            Interact(NewTable.table);
            TableMapCanvas.Children.Add(NewTable.table);
            if (Add) { TableList.Add(NewTable); }
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

        private void RefreshHomeMap(object sender, RoutedEventArgs e)
        {
            ShowTables();
        }
    }
}
