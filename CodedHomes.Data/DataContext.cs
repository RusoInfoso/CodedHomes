using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodedHomes.Models;
using System.Configuration;
using CodedHomes.Data.Configuration;

namespace CodedHomes.Data
{
    public class DataContext : DbContext
    {
        public DataContext() : base(nameOrConnectionString: DataContext.ConnectionString)
        {
        }

        static DataContext()
        {
            Database.SetInitializer(new CustomDatabaseInitializer());
        }

        public DbSet<Home> Homes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public static string ConnectionString
        {
            get
            {
                if(ConfigurationManager.AppSettings["ConnectionStringName"] != null)
                {
                    return ConfigurationManager.AppSettings["ConnectionStringName"].ToString();
                }

                return "DefaultConnection";
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new HomeConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());

            // Add ASP.NET WebPages SimpleSecurity tables
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new OAuthMembershipConfiguration());
            modelBuilder.Configurations.Add(new MembershipConfiguration());

            //base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            ApplyRules();

            return base.SaveChanges();
        }

        private void ApplyRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in this.ChangeTracker.Entries()
                        .Where(
                             e => e.Entity is IAuditInfo &&
                            ((e.State == EntityState.Added) ||
                            (e.State == EntityState.Modified))))
            {
                IAuditInfo e = (IAuditInfo)entry.Entity;

                // Второе условие На случай seed из Миграции - пока не придумал как по другому обойти
                if (entry.State == EntityState.Added || e.CreatedOn == DateTime.MinValue)
                {
                    e.CreatedOn = DateTime.Now;
                }
                
                e.ModifiedOn = DateTime.Now;
            }
        }
    }
}
