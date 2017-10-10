namespace OnMyWayRestaurantManagement
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Windows.Shapes;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows;
    using System.Windows.Input;

    public partial class Table
    {
        public int TableId { get; set; }

        [StringLength(10)]
        public string TableStatus { get; set; }

        public double TablePositionX { get; set; }

        public double TablePositionY { get; set; }

        public string DisheList { get; set; }

        public int TableWaiter { get; set; }

        public Rectangle table = new Rectangle() { RenderTransform = new TranslateTransform(0, 0), Width = 100, Height = 100 };

        List<Dishe> TableDishes = new List<Dishe>();
    }
}
