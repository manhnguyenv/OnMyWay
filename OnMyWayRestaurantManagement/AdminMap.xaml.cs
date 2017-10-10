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
    /// Interaction logic for AdminMap.xaml
    /// </summary>
    public partial class AdminMap : UserControl
    {
        public AdminMap()
        {
            InitializeComponent();
            ShowTables();
        }

        List<Table> TableList = new List<Table>();
        ImageBrush EatingTable = new ImageBrush { ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/OnMyWayRestaurantManagement;component/Images/EatingTable.png", UriKind.Absolute)) };
        ImageBrush EmptyTable = new ImageBrush { ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/OnMyWayRestaurantManagement;component/Images/EmptyTable.png", UriKind.Absolute)) };
        ImageBrush ModelTable = new ImageBrush { ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/OnMyWayRestaurantManagement;component/Images/ModelTable.png", UriKind.Absolute)) };

        public void ShowTables()
        {
            OnMyWayDatabase OnMyWayDb = new OnMyWayDatabase();
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

        private void AddNewTable(object sender, RoutedEventArgs e)
        {
            CreateNewTable();
        }
        public void CreateNewTable(double PosX = 666, double PosY = 350, int TableId = 0, bool Add = true)
        {
            Table NewTable = new Table();
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
            NewTable.TableStatus = "Empty";
            NewTable.TablePositionX = PosX;
            NewTable.TablePositionY = PosY;
            Point TablePosition = NewTable.table.TranslatePoint(new Point(0, 0), TableMapCanvas);
            Canvas.SetLeft(NewTable.table, NewTable.TablePositionX);
            Canvas.SetTop(NewTable.table, NewTable.TablePositionY);
            Nullable<Point> DragStartPosition = null;
            MouseButtonEventHandler mouseDown = (sender, args) =>
            {
                var UITableElement = (UIElement)sender;
                DragStartPosition = args.GetPosition(UITableElement);
                UITableElement.CaptureMouse();
            };
            MouseButtonEventHandler mouseUp = (sender, args) =>
            {
                TablePosition = NewTable.table.TranslatePoint(new Point(0, 0), TableMapCanvas);
                var UITableElement = (UIElement)sender;
                if (TablePosition.X <= 1)
                {
                    Canvas.SetLeft(UITableElement, 1);
                }
                if (TablePosition.X >= 1332)
                {
                    Canvas.SetLeft(UITableElement, 1332);
                }
                if (TablePosition.Y <= 1)
                {
                    Canvas.SetTop(UITableElement, 1);
                }
                if (TablePosition.Y >= 700)
                {
                    Canvas.SetTop(UITableElement, 700);
                }
                DragStartPosition = null;
                UITableElement.ReleaseMouseCapture();
            };
            MouseEventHandler mouseMove = (sender, args) =>
            {
                TableInfo.IsExpanded = true;
                var TableToUpdate = (from t in TableList
                                     where t.TableId == TableId
                                     select t).FirstOrDefault();
                if (TableId == 0)
                {
                    if (DragStartPosition != null && args.LeftButton == MouseButtonState.Pressed)
                    {
                        var UITableElement = (UIElement)sender;
                        var Position = args.GetPosition(TableMapCanvas);
                        Canvas.SetLeft(UITableElement, Position.X - DragStartPosition.Value.X);
                        Canvas.SetTop(UITableElement, Position.Y - DragStartPosition.Value.Y);
                    }
                }
                else
                {
                    if (TableToUpdate.TableId != 0)
                    {
                        if (!GetSentTable.TableStatus.Contains("Eating"))
                        {
                            if (DragStartPosition != null && args.LeftButton == MouseButtonState.Pressed)
                            {
                                var UITableElement = (UIElement)sender;
                                var Position = args.GetPosition(TableMapCanvas);
                                Canvas.SetLeft(UITableElement, Position.X - DragStartPosition.Value.X);
                                Canvas.SetTop(UITableElement, Position.Y - DragStartPosition.Value.Y);
                            }
                        }
                    }
                }
                
                TablePosition = NewTable.table.TranslatePoint(new Point(0, 0), TableMapCanvas);
                XPosition.Text = "Pos.X: " + TablePosition.X; YPosition.Text = "Pos.Y: " + TablePosition.Y;
                NewTable.TablePositionX = TablePosition.X;
                NewTable.TablePositionY = TablePosition.Y;
                if (TableToUpdate != null) { TableIdTextBlock.Text = TableId.ToString(); TableStatus.Text = TableToUpdate.TableStatus; TableToUpdate.TablePositionX = TablePosition.X; TableToUpdate.TablePositionY = TablePosition.Y; }
            };
            Action<UIElement> enableDrag = (UITableElement) =>
            {
                UITableElement.MouseDown += mouseDown;
                UITableElement.MouseMove += mouseMove;
                UITableElement.MouseUp += mouseUp;
            };
            enableDrag(NewTable.table);
            TableMapCanvas.Children.Add(NewTable.table);
            if (Add) { TableList.Add(NewTable); }
        }

        public void SaveTableChanges(object sender, RoutedEventArgs e)
        {
            OnMyWayDatabase OnMyWayDb = new OnMyWayDatabase();
            foreach (Table table in TableList)
            {
                var GetTableQuery = (from t in OnMyWayDb.Tables
                                     where t.TableId == table.TableId
                                     select t).FirstOrDefault();
                if (GetTableQuery != null)
                {
                    GetTableQuery.TablePositionX = table.TablePositionX;
                    GetTableQuery.TablePositionY = table.TablePositionY;
                }
                else { OnMyWayDb.Tables.Add(table); }
            }
            OnMyWayDb.SaveChanges();
            PushMsg("Tables Saved", "Changes to the restaurant laying out have been saved.");
        }
    }
}
