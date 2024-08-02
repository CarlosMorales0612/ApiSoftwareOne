using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Application.Dtos;


namespace Application.Interfaces
{
   public interface IRepository
    {
        Task AddAsync(TaskEntity entity);
        Task<TaskEntity> GetByTitleAsync(string title);
        Task<IEnumerable<TaskEntity>> GetAllAsync();
        Task<string> UpdateAsync(string title, TaskEntity entity);
        Task<string> DeleteAsync(TaskEntity entity);
    }

    //define operaciones de acceso a datos sin especificar
    //cómo se implementan realmente
}
