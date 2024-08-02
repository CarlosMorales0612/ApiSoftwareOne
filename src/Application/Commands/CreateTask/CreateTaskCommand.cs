using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Commands.CreateTask
{
    public record CreateTaskCommand(MyEntityDto EntityDto) : IRequest<MyEntityDto>
    {
    }
}
