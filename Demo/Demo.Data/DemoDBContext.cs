using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Model;


namespace Demo.Data
{
    public class DemoDBContext : DbContext
    {
        public virtual DbSet<DemoModel> Demoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<DemoDBContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}
