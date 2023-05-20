using Demo.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Demo.DAL.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        //Seeding Data

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { 
                Id=Guid.NewGuid().ToString() , 
                Name="Admin" , 
                NormalizedName="admin" , 
                ConcurrencyStamp= Guid.NewGuid().ToString()
                } ,
                  new IdentityRole()
                  {
                      Id = Guid.NewGuid().ToString(),
                      Name = "User",
                      NormalizedName = "user",
                      ConcurrencyStamp = Guid.NewGuid().ToString()
                  }

                );

            base.OnModelCreating(builder);
        }

    }

}
