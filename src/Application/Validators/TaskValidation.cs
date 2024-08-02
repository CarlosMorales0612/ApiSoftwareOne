using Application.Dtos;
using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class TaskValidation : AbstractValidator<MyEntityDto>
    {
        public TaskValidation() 
        {
            //Reglas de Validación
            RuleFor(v=> v.TitleTask)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("Title is required and cannot exceed 50 characters.");

            RuleFor(v => v.DescriptionTask)
                .NotEmpty()
                .MaximumLength(100)
                .WithMessage("Description is required and cannot exceed 100 characters.");
            RuleFor(v => v.CompletedTask)
                .NotNull()
                .WithMessage("Completed is required.");
        }

    }
}
