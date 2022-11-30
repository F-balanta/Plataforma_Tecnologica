using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PlatecBackend.Application.AutoMapper.DTO;
using PlatecBackend.Persistence;

namespace PlatecBackend.Application.Actions.BlogPost.Queries
{
    public class GetAll
    {
        public class QueryGetAllBlogPosts : IRequest<List<BlogPostDto>>
        {
            public int Records { get; set; }
            public int Page { get; set; }
            
            public string? Tittle { get; set; }
        }
        
        public class QueryGetAllBlogPostsHandler : IRequestHandler<QueryGetAllBlogPosts, List<BlogPostDto>>
        {
            private readonly Context _context;

            private readonly IMapper _mapper;

            public QueryGetAllBlogPostsHandler(Context context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;

            }
            public async Task<List<BlogPostDto>> Handle(QueryGetAllBlogPosts request, CancellationToken cancellationToken)
            {
                var blogPosts = new List<Domain.BlogPost>();
                if(string.IsNullOrEmpty(request.Tittle))
                    blogPosts = await _context.BlogPosts.Skip((request.Page - 1) * request.Records).Take(request.Records).Include(x => x.PostComment).ToListAsync(cancellationToken: cancellationToken);
                else
                    blogPosts = await _context.BlogPosts.Where(x => x.Tittle == request.Tittle).Skip((request.Page - 1) * request.Records).Take(request.Records).Include(x => x.PostComment).ToListAsync(cancellationToken: cancellationToken);
                
                var blogPostsDto = _mapper.Map<List<BlogPostDto>>(blogPosts);
                return blogPostsDto;
            }
        }
    }
}
