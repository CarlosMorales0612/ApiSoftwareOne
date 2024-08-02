using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Application.Dtos;

namespace Application.Services
{
    public interface ITaskService
    {
        Task<MyEntityDto> GetMyEntityAsync(string title);
        Task<IEnumerable<MyEntityDto>> GetAllMyEntitiesAsync();
        Task<MyEntityDto> CreateMyEntityAsync(MyEntityDto entity);
        Task<MyEntityDto> UpdateMyEntityAsync(string title, MyEntityDto updateEntityDto);
        Task<string> DeleteMyEntityAsync(string title);
    }
    //define operaciones de negocio sin depender
    //directamente de cómo se accede a los datos.
}
