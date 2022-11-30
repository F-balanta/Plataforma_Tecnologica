using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PlatecBackend.Application.AutoMapper.DTO;
using PlatecBackend.Persistence;

namespace PlatecBackend.Application.Actions.PostComment.Queries
{
    public class GetAll
    {
        public class QueryGetAllPostComments : IRequest<List<PostCommentDto>>
        {
        }

        public class QueryGetAllPostCommentsHandler : IRequestHandler<QueryGetAllPostComments, List<PostCommentDto>>
        {
            private readonly Context _context;

            private readonly IMapper _mapper;

            public QueryGetAllPostCommentsHandler(Context context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;

            }
            public async Task<List<PostCommentDto>> Handle(QueryGetAllPostComments request, CancellationToken cancellationToken)
            {
                var postComments = await _context.PostComments.ToListAsync(cancellationToken: cancellationToken);
                var postCommentsDto = _mapper.Map<List<PostCommentDto>>(postComments);
                return postCommentsDto;
            }
        }
    }
}
