using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using AutoMapper;
using Application.Dto;
namespace applicationTestsUnit
{
    public class CreateTestUnit
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        private readonly ITaskService _taskService;

        public CreateTestUnit(IRepository repository, IMapper mapper, ITaskService taskService)
        {
            _repository = repository;
            _mapper = mapper;
            _taskService = taskService;
            
        }
        [Fact]
        public async Task CreateMyEntityAsync_ValidEntity_ReturnsCreatedEntity()
        {
            // Arrange
            var entityDto = new MyEntityDto
            {
                TitleTask = "Title",
                DescriptionTaks = "Description",
                CreationTaks = DateTime.UtcNow,
                CompletedTaks = false
            };

            //Act
            var result = await _taskService.CreateMyEntityAsync(entityDto);


            //Assert
            Assert.NotNull(result);
            Assert.Equal(entityDto.TitleTask, result.TitleTask);
            Assert.Equal(entityDto.DescriptionTaks, result.DescriptionTaks);

        }


    }
}
