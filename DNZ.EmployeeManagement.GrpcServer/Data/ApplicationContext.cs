using DNZ.EmployeeManagement.GrpcServer.Domain;
using Microsoft.EntityFrameworkCore;


namespace DNZ.EmployeeManagement.GrpcServer.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
