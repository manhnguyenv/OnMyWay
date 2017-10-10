namespace OnMyWayRestaurantManagement
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TableSelected")]
    public partial class TableSelected
    {
        public int Id { get; set; }

        public int? TableId { get; set; }
    }
}
