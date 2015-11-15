using System;
using System.IO;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Com.Framework.Data;
using Com.Framework.DataAccess.Mapping;

using EntityState = System.Data.Entity.EntityState;


namespace Com.Framework.DataAccess
{
    public class DataContext : DbContext
    {
        //public DbSet<Organisation> Organisations { get; set; }

        public DbSet<Premise> Premises { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<User> Users { get; set; }


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

        public System.Data.Entity.DbSet<Com.Framework.Data.Image> Images { get; set; }

        public System.Data.Entity.DbSet<Com.Framework.Data.Email> Emails { get; set; }

        public System.Data.Entity.DbSet<Com.Framework.Data.EmployeeGroup> EmployeeGroups { get; set; }

        public System.Data.Entity.DbSet<Com.Framework.Data.TerminalCredential> TerminalCredentials { get; set; }
    }

    public class DataContextInitialiser : DropCreateDatabaseAlways<DataContext>
    {
        protected override void Seed(DataContext context)
        {

            //Premise p = new Premise
            //{
            //    Name = "Test Premise",
            //    CountryCode = "UK"
            //};

            //Organisation o = new Organisation
            //{
            //    Name = "Test Organisation",
            //    Code = "TO"

            //};
            //context.Organisations.Add(o);

            // Seed with test premise
            Premise p = new Premise
            {
                Name = "Test Premise",
                Description = "This is the test premise"
            };
            context.Premises.Add(p);

            // Seed with default profile image
            //MemoryStream ms = new MemoryStream();
            //System.Drawing.Image.FromFile(Properties.Resources.PremiseDefault_02).Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

            Image i = new Image
            {
                ImageType = ImageType.Default,
                Data = (byte[])new System.Drawing.ImageConverter().ConvertTo(Properties.Resources.PremiseDefault_02, typeof(byte[]))
            };
            context.Images.Add(i);




            //p = context.Premises.FirstOrDefault(i => i.Name == "Test Premise");

            //Employee e = new Employee
            //{
            //    Premise = p,
            //    Title = "Mr",
            //    FirstName = "Adam",
            //    LastName = "Hancock",
            //    MiddleNames = "Stephen",
            //    UserName = "ahancock1",
            //    Gender = Gender.Male,
            //    BirthDate = new DateTime(1990, 1, 10),
            //    Email = new Email("a.hancock@hotmail.co.uk"),
            //    EmployeeGroup = new EmployeeGroup("Software Developer"),
            //    EmployeeNumber = 1.ToString("00000000"),
            //    EmploymnentBasis = EmploymentType.FullTime,
            //    PhoneNumbers = new List<PhoneNumber>
            //    {
            //        new PhoneNumber("44", "771246589")
            //        {
            //            PhoneType = PhoneType.Mobile
            //        }
            //    },
            //    StartDate = DateTime.Now,
            //    HiredDate = DateTime.Now
            //};
            //context.Organisations.Add(o);
        }
    }
}
