namespace OnMyWayRestaurantManagement
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class OnMyWayDatabase : DbContext
    {
        public OnMyWayDatabase()
            : base("name=OnMyWayDatabase")
        {
        }

        public virtual DbSet<Dishe> Dishes { get; set; }
        public virtual DbSet<Table> Tables { get; set; }
        public virtual DbSet<TableSelected> TableSelecteds { get; set; }
        public virtual DbSet<Waiter> Waiters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Table>()
                .Property(e => e.TableStatus)
                .IsFixedLength();

            modelBuilder.Entity<Waiter>()
                .Property(e => e.Gender)
                .IsFixedLength();
        }
    }
}
