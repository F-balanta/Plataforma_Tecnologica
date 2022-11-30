using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlatecBackend.Application.Actions.BlogPost.Queries;
using PlatecBackend.Application.AutoMapper.DTO;

namespace ApiRest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogPostsController : ControllerBase
    {
        private readonly IMediator _mediator;

        private const int _records = 5;

        public BlogPostsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<BlogPostDto>>> BlogPostList([FromQuery] int? page, [FromQuery] string? tittle)
        {
            int _page = page ?? 1;
            decimal total_records = await _mediator.Send(new GetCount.QueryGetCountBlogPosts{Tittle = tittle});
            int total_pages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(total_records / _records)));
            
            var blogs = await _mediator.Send(new GetAll.QueryGetAllBlogPosts{Page = _page, Records = _records, Tittle = tittle});
            return Ok(new
            {
                pages = total_pages,
                records = blogs,
                current_page = _page
            });
        }
    }
}
