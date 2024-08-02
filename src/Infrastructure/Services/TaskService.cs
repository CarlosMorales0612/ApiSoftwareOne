using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Application.Dtos;
using MediatR;
using Application.Validators;
using Azure.Core;

namespace Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRepository _repository;

        public TaskService(IUnitOfWork unitOfWork, IMapper mapper, IRepository repository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<MyEntityDto> CreateMyEntityAsync(MyEntityDto entityDTO)
            //genera un Guid Id
        {
            var validator = new TaskValidation();
            var validationResult = await validator.ValidateAsync(entityDTO);

            if (!validationResult.IsValid)
            {
                throw new Exceptions.ValidationException(validationResult.Errors);
            }


            var entity = _mapper.Map<TaskEntity>(entityDTO);
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<MyEntityDto>(entity);
        }

   

        public async Task<IEnumerable<MyEntityDto>> GetAllMyEntitiesAsync()
        {
            var getAllTasks = await _repository.GetAllAsync();
            var tasksEntityDto = _mapper.Map<IEnumerable<MyEntityDto>>(getAllTasks);
            return tasksEntityDto;
        }



        public async Task<MyEntityDto> GetMyEntityAsync(string title)
        {
            var entity = await _repository.GetByTitleAsync(title);
            var entityDto = _mapper.Map<MyEntityDto>(entity);
            return entityDto;
        }


        public async Task<MyEntityDto> UpdateMyEntityAsync(string title, MyEntityDto entityDto)
        {

            var updateTask = await _repository.GetByTitleAsync(title);
            if (updateTask == null)
            {
                throw new Exception("Entity not found");
            }

            updateTask.Title = entityDto.TitleTask;
            updateTask.Description = entityDto.DescriptionTask;
            updateTask.Completed = entityDto.CompletedTask;

            var entityUpdate = _mapper.Map<MyEntityDto>(updateTask);

            var validator = new TaskValidation();
            var validationResult = await validator.ValidateAsync(entityUpdate);
            if (!validationResult.IsValid)
            {
                throw new Exceptions.ValidationException(validationResult.Errors);
            }

            await _repository.UpdateAsync(title, updateTask);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<MyEntityDto>(entityDto);
        }

        public async Task<string> DeleteMyEntityAsync(string title)
        {
            var entityDelete = await _repository.GetByTitleAsync(title);
            if (entityDelete == null)
            {
                throw new Exception("Entity not found");
            }
            await _repository.DeleteAsync(entityDelete);
            await _unitOfWork.CommitAsync();
            return "Task deleted successfully: " + title;
            
            

        }

    }
    }




