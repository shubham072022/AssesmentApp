using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Common.Wrapper.Abstract;
using Todo.Application.Features.TodoModule.Commands.CreateTodo;
using Todo.Application.Features.TodoModule.Commands.DeleteTodo;
using Todo.Application.Features.TodoModule.Commands.EditTodo;
using Todo.Application.Features.TodoModule.Queries.GetAllTodos;

namespace Todo.API.Controllers
{
    public class TodoController : ApiController
    {
        [HttpGet]
        [Route("")]
        public async Task<IResponse> GetAll()
        {
            return await Mediator.Send(new TodoGetAllQueryRequest());
        }

        [HttpPost]
        [Route("add")]
        public async Task<IResponse> Add(TodoCreateCommandRequest request)
        {
            return await Mediator.Send(request);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IResponse> Update(TodoEditCommandRequest request)
        {
            return await Mediator.Send(request);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IResponse> Delete(int id)
        {
            return await Mediator.Send(new TodoDeleteComandRequest(id));
        }
    }
}
