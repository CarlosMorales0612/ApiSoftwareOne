using Application.Dtos;
using Application.Interfaces;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetTasks
{
    public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, IEnumerable<MyEntityDto>>
    {
        private readonly ITaskService _taskService;

            public GetAllTasksQueryHandler(ITaskService taskService)
        { 
            _taskService = taskService;
        }
        public async Task<IEnumerable<MyEntityDto>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            return await _taskService.GetAllMyEntitiesAsync();
        }
    }
    
}
