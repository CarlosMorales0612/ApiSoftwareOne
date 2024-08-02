using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Data.Configuration
{
    public class DbContextConfigurer : DbContext
    {
        public DbContextConfigurer(DbContextOptions<DbContextConfigurer> options) :
            base(options)
        {
        }

        public DbSet<TaskEntity> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }
            modelBuilder.Entity<TaskEntity>().ToTable("Tasks").HasKey(x => x.TaskId); 

            base.OnModelCreating(modelBuilder);
        }
     
    }

        
    
}
