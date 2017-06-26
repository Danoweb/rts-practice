using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PracticeCarriers.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;

namespace PracticeCarriers.DAL
{
    public class CarriersContext : DbContext
    {

        public CarriersContext() : base("CarriersContext")
        {
            
        }

        public DbSet<Carriers> Carriers { get; set; }
        public DbSet<States> States { get; set; }

        //USE THE DB BUILDER TO SET THE PRIMARY KEY FIELDS
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //SET PRIMARY KEY FOR CARRIERS TO CARRIERID
            modelBuilder.Entity<Carriers>().HasKey(x => x.CarrierID);
            //SET PRIMARY KEY FOR STATES TO STATEID
            modelBuilder.Entity<States>().HasKey(x => x.StateID);

            //USE "Soft-Deletes" METHODOLOGY
            modelBuilder.Entity<Carriers>()
                .Map(m => m.Requires("Active").HasValue(true))
                .Ignore(i => i.Active);

            //APPLY CHANGES
            base.OnModelCreating(modelBuilder);
        }//END METHOD ONMODELCREATING

        //OVERRIDE SAVE CHANGES TO HANDLE SOFT DELETE FUNCTIONALITY
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(w => w.State == EntityState.Deleted ))
            {
                SoftDelete(entry);
            }//END FOREACH ENTRY IN CHANGETRACKER.ENTRIES


            return base.SaveChanges();
        }

        
        private void SoftDelete(DbEntityEntry entry)
        {
            //Type entryEntityType = entry.Entity.GetType();
            //BUILD OUR SQL AND EXECUTE PREPARED STATEMENT
            string softDeleteSql = "Update Carriers SET Active = 0 WHERE CarrierID = @carrierid";

            Database.ExecuteSqlCommand(softDeleteSql, new SqlParameter("@carrierid", entry.OriginalValues["CarrierID"]) );

            //STOP THE HARD DELETE FROM HAPPENING
            entry.State = EntityState.Detached;

        }//END FUNCTION SOFTDELETE

    }//END CLASS CARRIERSCONTEXT
}