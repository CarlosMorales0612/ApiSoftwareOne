using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Moq;
using Application.Services;
using System.Threading.Tasks;
using Application.Dtos;

namespace CleanArquitectu.UnitTest
{
    public class CreateTask
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IRepository> _repositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly ITaskService _service; // Reemplaza con el nombre real de tu servicio

        public CreateTask()
        {
            _mapperMock = new Mock<IMapper>();
            _repositoryMock = new Mock<IRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();

            _service = new TaskService(_unitOfWorkMock.Object,_mapperMock.Object,_repositoryMock.Object);
        }

        [Fact]
        public async System.Threading.Tasks.Task CreateMyEntityAsync_Should_Create_Entity_And_Return_Dto()
        {
            // Arrange
            var entityDto = new MyEntityDto {
                TitleTask="Hola Mundo",
                DescriptionTask="Es un Hola Mundo",
            };
            var entity = new TaskEntity {
                Title = "Hola Mundo",
                Description = "Es un Hola Mundo",
            };

            _mapperMock.Setup(m => m.Map<MyEntityDto, TaskEntity>(It.IsAny<MyEntityDto>()))
                       .Returns(entity);

            _repositoryMock.Setup(r => r.AddAsync(It.IsAny<TaskEntity>()))
                           .Returns(System.Threading.Tasks.Task.CompletedTask);

            _unitOfWorkMock.Setup(u => u.CommitAsync())
                           .Returns(System.Threading.Tasks.Task.CompletedTask);

            _mapperMock.Setup(m => m.Map<TaskEntity, MyEntityDto>(It.IsAny<TaskEntity>()))
                       .Returns(entityDto);

            // Act
            var result = await _service.CreateMyEntityAsync(entityDto);

            // Assert
            _mapperMock.Verify(m => m.Map<MyEntityDto, TaskEntity>(entityDto), Times.Once);
            _repositoryMock.Verify(r => r.AddAsync(entity), Times.Once);
            _unitOfWorkMock.Verify(u => u.CommitAsync(), Times.Once);
            _mapperMock.Verify(m => m.Map<TaskEntity, MyEntityDto>(entity), Times.Once);

            Assert.Equal(entityDto, result);

        }
    }
}