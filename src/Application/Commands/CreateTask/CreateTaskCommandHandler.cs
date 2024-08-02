using Application.Dtos;
using Application.Interfaces;
using MediatR;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Domain.Entities;
using Application.Validators;
using Application.Services;

namespace Application.Commands.CreateTask
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, MyEntityDto>
    {
        private readonly ITaskService _taskService;


        public CreateTaskCommandHandler(ITaskService taskService)
        {
            _taskService = taskService;
        }


        public async Task<MyEntityDto> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            return await _taskService.CreateMyEntityAsync(request.EntityDto);
        }
    }
}
