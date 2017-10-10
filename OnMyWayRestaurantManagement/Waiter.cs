namespace OnMyWayRestaurantManagement
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Waiter
    {
        public int WaiterId { get; set; }

        [StringLength(50)]
        public string WaiterName { get; set; }

        [StringLength(50)]
        public string WaiterFirstname { get; set; }

        public int? HandeledTables { get; set; }

        public double? MoneyEarned { get; set; }

        [StringLength(10)]
        public string Gender { get; set; }

        public string Stats
        {
            get
            {
                return String.Format("Statistics about waiter/waitress:\nNumber of handeled tables: {0}          Amount of money earned: {1}€", this.HandeledTables, this.MoneyEarned);
            }
        }
    }
}
