using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Configuration
{
    public class DbContextFactory : IDesignTimeDbContextFactory<DbContextConfigurer>
    {
        public DbContextConfigurer CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DbContextConfigurer>();
            optionsBuilder.UseSqlServer(
                 "Server=.\\SQLEXPRESS;Database=GestionTasks;Trusted_Connection=True;TrustServerCertificate=true;");
            return new DbContextConfigurer(optionsBuilder.Options);
            
        }
    }
}
