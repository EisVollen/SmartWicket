using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using SmartWicket.ObjectModel.Core;

namespace SmartWicket.Infrastruture.DbContext
{
    /// <summary>
    /// Класс связи с бд
    /// </summary>
    public partial class SmartWicketEntities : System.Data.Entity.DbContext
    {
        public SmartWicketEntities()
            : base("name=SmartWicketEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<Visitor> Visitors { get; set; }
        public virtual DbSet<Visit> Visits { get; set; }
    }
}
