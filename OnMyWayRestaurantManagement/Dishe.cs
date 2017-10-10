namespace OnMyWayRestaurantManagement
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Dishe
    {
        [Key]
        public int DisheId { get; set; }

        [StringLength(50)]
        public string DisheName { get; set; }

        [StringLength(250)]
        public string DisheDescription { get; set; }

        public double DishePrice { get; set; }
    }
}
