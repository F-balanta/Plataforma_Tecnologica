using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

using PlatecBackend.Persistence;

namespace PlatecBackend.Application.Actions.BlogPost.Queries
{
    public class GetCount
    {
        public class QueryGetCountBlogPosts : IRequest<decimal>
        {
            public string? Tittle { get; set; }
        }
        
        public class QueryGetCountBlogPostsHandler : IRequestHandler<QueryGetCountBlogPosts, decimal>
        {
            private readonly Context _context;

            private readonly IMapper _mapper;

            public QueryGetCountBlogPostsHandler(Context context)
            {
                _context = context;
            }
            public async Task<decimal> Handle(QueryGetCountBlogPosts request, CancellationToken cancellationToken)
            {
                if(string.IsNullOrEmpty(request.Tittle))
                    return await _context.BlogPosts.CountAsync(cancellationToken: cancellationToken);
                else
                    return await _context.BlogPosts.Where(x => x.Tittle == request.Tittle).CountAsync(cancellationToken: cancellationToken);
            }
        }
    }
}
