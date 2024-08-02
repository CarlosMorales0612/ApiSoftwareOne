using Application.Dtos;
using Application.Interfaces;
using Application.Services;
using Application.Validators;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.UpdateTask
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand,MyEntityDto>
    {
        private readonly ITaskService _taskService;

        public UpdateTaskCommandHandler(ITaskService taskService)
        {
           _taskService = taskService;
        }

        public async Task<MyEntityDto> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            return await _taskService.UpdateMyEntityAsync(request.title, request.myEntityDto);
        }
    }
}
