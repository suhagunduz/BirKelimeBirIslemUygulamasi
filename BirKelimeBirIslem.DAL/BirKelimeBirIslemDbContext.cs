using BirKelimeBirIslem.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirKelimeBirIslem.DAL
{
    class BirKelimeBirIslemDbContext:DbContext
    {
        public BirKelimeBirIslemDbContext() : base("Server=(localdb)\\YZM3101; Database=YZM2122; uid=kelime; pwd=Remember1")
             
        {
          //  System.Data.SqlClient.SqlConnection baglan = new System.Data.SqlClient.SqlConnection(@"Data Source=(localdb)\YZM3101;Initial Catalog=YZM2122;Integrated Security=True");
        }

        public DbSet<KelimeModel> Kelimeler { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new KelimeMapping());
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
