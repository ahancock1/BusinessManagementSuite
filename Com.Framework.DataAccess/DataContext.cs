using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Com.Framework.Data;
using Com.Framework.DataAccess.Mapping;
using Com.Framework.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using EntityState = System.Data.Entity.EntityState;


namespace Com.Framework.DataAccess
{
    public partial class DataContext
    {
        public DbSet<Premise> Premises { get; set; }

        public DbSet<Employee> Employees { get; set; }

        //public DbSet<User> Users { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Email> Emails { get; set; }

        public DbSet<EmployeeGroup> EmployeeGroups { get; set; }

        public DbSet<TerminalCredential> TerminalCredentials { get; set; }

        //Identity
        public DbSet<AspNetUser> Users { get; set; }

        public DbSet<AspNetUserClaim> UserClaims { get; set; }

        public DbSet<AspNetUserLogin> UserLogins { get; set; }

        public DbSet<AspNetUserRole> UserRoles { get; set; }

    }

    public partial class DataContext : IdentityDbContext
    {
        public DataContext()
            : base("DataContext")
        {
            Database.SetInitializer(new DataContextInitialiser());

            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Create a model using attribute tags
            base.OnModelCreating(modelBuilder);

            // Add fluent API mappings
            modelBuilder.Configurations.Add(new UserMapping());

            //modelBuilder.Entity<AspNetUserLogin>().HasKey<string>(l => l.Id);
            //modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            //modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }

        public override int SaveChanges()
        {
            try
            {
                var entries = ChangeTracker.Entries().Where(e => e.Entity is IAuditableEntity &&
                                 (e.State == EntityState.Added || e.State == EntityState.Modified));

                foreach (var entry in entries)
                {
                    IAuditableEntity entity = entry.Entity as IAuditableEntity;
                    if (entity != null)
                    {
                        string identity = Thread.CurrentPrincipal.Identity.Name;
                        DateTime now = DateTime.UtcNow;

                        if (entry.State == EntityState.Added)
                        {
                            entity.CreatedBy = identity;
                            entity.CreatedDate = now;
                        }
                        else
                        {
                            base.Entry(entity).Property(e => e.CreatedBy).IsModified = false;
                            base.Entry(entity).Property(e => e.CreatedDate).IsModified = false;
                        }

                        entity.ModifiedBy = identity;
                        entity.ModifiedDate = now;
                    }
                }

                return base.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Class: {0}, Property: {1}, Error: {2}",
                            validationErrors.Entry.Entity.GetType().FullName,
                            validationError.PropertyName,
                            validationError.ErrorMessage);
                    }
                }

                throw;
            }
        }

    }

    public class DataContextInitialiser : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            GetPremises().ForEach(p => context.Premises.Add(p));

            GetImages().ForEach(i => context.Images.Add(i));

        }

        private List<Premise> GetPremises()
        {
            return new List<Premise>
            {
                new Premise
                {
                    Name = "Test Premise",
                    Description = "This is the test premise"
                }
            };
        }

        private List<Image> GetImages()
        {
            return new List<Image>
            {
                new Image
                {
                    ImageType = ImageType.Default,
                    Data = (byte[])new System.Drawing.ImageConverter().ConvertTo(Properties.Resources.PremiseDefault_02, typeof(byte[]))
                }
            };
        }
    }
}
