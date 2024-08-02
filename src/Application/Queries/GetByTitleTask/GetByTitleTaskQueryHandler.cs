using Application.Dtos;
using Application.Interfaces;
using Application.Services;
using Application.Validators;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetByTitleTask
{
    public class GetByTitleTaskQueryHandler : IRequestHandler<GetByTitleTaskQuery, MyEntityDto>
    {

        private readonly ITaskService _taskService;


        public GetByTitleTaskQueryHandler (ITaskService taskService)
        {
           _taskService = taskService;
        }

        public async Task<MyEntityDto> Handle(GetByTitleTaskQuery request, CancellationToken cancellationToken)
        {

            return await _taskService.GetMyEntityAsync(request.title);
        }
    }
}
