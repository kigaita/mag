using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using UwbItContest.Web.Models;

namespace UwbItContest.Web.DAL
{
    public class UwbContestContext : DbContext
    {
        public UwbContestContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder
                .Entity<Team>()
                .HasKey(t => t.Id);

            modelBuilder
                .Entity<Team>()
                .Property(t => t.TeamName)
                .HasMaxLength(15)
                .IsUnicode()
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}