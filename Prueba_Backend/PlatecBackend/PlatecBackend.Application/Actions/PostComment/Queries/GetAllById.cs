using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PlatecBackend.Application.AutoMapper.DTO;
using PlatecBackend.Persistence;

namespace PlatecBackend.Application.Actions.PostComment.Queries
{
    public class GetAllById
    {
        public class QueryGetAllPostCommentsById : IRequest<List<PostCommentDto>>
        {
            public Guid BlogPostId { get; set; }
        }
        
        public class QueryGetAllPostCommentsByIdHandler : IRequestHandler<QueryGetAllPostCommentsById, List<PostCommentDto>>
        {
            private readonly Context _context;

            private readonly IMapper _mapper;

            public QueryGetAllPostCommentsByIdHandler(Context context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;

            }
            public async Task<List<PostCommentDto>> Handle(QueryGetAllPostCommentsById request, CancellationToken cancellationToken)
            {
                var postComments = _context.PostComments.Where(x => x.BlogPostId == request.BlogPostId);
                var postCommentsDto = _mapper.Map<List<PostCommentDto>>(postComments);
                return postCommentsDto;
            }
        }
    }
}
