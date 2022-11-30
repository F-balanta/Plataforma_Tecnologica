using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlatecBackend.Application.Actions.PostComment.Commands;
using PlatecBackend.Application.Actions.PostComment.Queries;
using PlatecBackend.Application.AutoMapper.DTO;

namespace ApiRest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostCommentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostCommentsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<PostCommentDto>>> PostCommentList() => await _mediator.Send(new GetAll.QueryGetAllPostComments());

        [HttpGet("blog/{id:guid}")]
        public async Task<ActionResult<List<PostCommentDto>>> PostCommentBydIdList(Guid id) => await _mediator.Send(new GetAllById.QueryGetAllPostCommentsById { BlogPostId = id });

        [HttpPost]
        public async Task<ActionResult<Unit>> CreatePostComment([FromBody] Create.CommandCreatePostComment data) => await _mediator.Send(data);
    }
}
