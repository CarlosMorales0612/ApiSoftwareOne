using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class Repository : IRepository
    {

        private readonly DbContextConfigurer _context;

        public Repository(DbContextConfigurer context)
        {
            _context = context;
        }


        public async Task AddAsync(TaskEntity entity)
        {
            await _context.Tasks.AddAsync(entity);
            await _context.SaveChangesAsync();   
        }

        public async Task<IEnumerable<TaskEntity>> GetAllAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<TaskEntity> GetByTitleAsync(string title)
        {
            return await _context.Tasks.FirstOrDefaultAsync(x => x.Title == title);
        }

        public async Task<string> UpdateAsync(string title, TaskEntity entity)
        {
            _context.Tasks.Update(entity);
            await _context.SaveChangesAsync();
            return entity.Title;
        }

        public async Task<string> DeleteAsync(TaskEntity entity)
        {
           var result= _context.Remove(entity);
            await _context.SaveChangesAsync();
            return "Delete";
        }

    }
}
