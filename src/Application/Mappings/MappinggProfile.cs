﻿using Application.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class MappinggProfile : Profile
    {
        public MappinggProfile()
        {
            CreateMap<TaskEntity, MyEntityDto>().ReverseMap();

        }
    }
}
