using Application.Dtos;
using Application.Interfaces;
using Application.Validators;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Application.Commands.CreateTask;
using Application.Commands.UpdateTask;
using Application.Commands.DeleteTask;
using Application.Queries.GetTasks;
using Application.Queries.GetByTitleTask;


namespace Task.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase 
    {
        private readonly IMediator _mediator;

        public TaskController(IMediator mediator)
        {
         
            _mediator = mediator;
           

        }
          /// <summary>
          /// Gest the list of all tasks
          /// </summary>
          /// <returns>Return</returns>
          /// <reponse code="200">Returns the list of all tasks</reponse>
          /// <response code="500">If an error occurred while creating the task.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MyEntityDto>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            var entities = new GetAllTasksQuery();
            var result = await _mediator.Send(entities);
            return Ok(result);
        }
        /// <summary>
        /// Get task by title
        /// </summary>
        /// <param name="title"></param>
        /// <returns>Return</returns>
        /// <reponse code="200">Returns the list of all tasks</reponse>
        /// <response code="500">If an error occurred while creating the task.</response>
        [HttpGet("{title}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MyEntityDto>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByTitle(string title)
        {
           var entity = new GetByTitleTaskQuery(title);
            var result = await _mediator.Send(entity);
            return Ok(result);
        }
        //Deserialización => FromBody => DTO
        /// <summary>
        /// Create a new task
        /// </summary>
        /// <param name="entityDTO"></param>
        /// <returns> Returns the create task </returns>
        /// <response code="200">Returns the newly created task</response>
        /// <response code="400">If the request is invalid or validation fails.</response>
        /// <response code="500">If an error occurred while creating the task.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MyEntityDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type =typeof(MyEntityDto))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(MyEntityDto))]
        public async Task<IActionResult> CreateTask([FromBody] MyEntityDto entityDTO)
        {
            var command = new CreateTaskCommand(entityDTO);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Update an existing task
        /// </summary>
        /// <param name="title"></param>
        /// <param name="entityDTO"></param>
        /// <returns> Returns the Update task </returns>
        /// <response code="200">Returns the newly update task</response>
        /// <response code="400">If the request is invalid or validation fails.</response>
        /// <response code="500">If an error occurred while update the task.</response>
        [HttpPut("{title}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MyEntityDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(MyEntityDto))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(MyEntityDto))]
        public async Task<IActionResult> UpdateTask(string title, [FromBody] MyEntityDto entityDTO)
        {
            var command = new UpdateTaskCommand(title,entityDTO);
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        /// <summary>
        /// Delete a task
        /// </summary>
        /// <param name="title"></param>
        /// <returns>Return</returns>
        /// <reponse code="200">Returns the list of all tasks</reponse>
        /// <response code="500">If an error occurred while delete the task.</response>
        [HttpDelete("{title}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteTask(string title)
        {
           var command = new DeleteTaskCommand(title);
            var result = await _mediator.Send(command);
            return Ok(new { result });
        }

    }
}
