﻿using Application.Dtos;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetByTitleTask
{
    public record GetByTitleTaskQuery(string title) : IRequest<MyEntityDto>
    {

    }
}
