using Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.DeleteTask
{
    public record DeleteTaskCommand(string title) : IRequest<string>
    {
        
    }

}