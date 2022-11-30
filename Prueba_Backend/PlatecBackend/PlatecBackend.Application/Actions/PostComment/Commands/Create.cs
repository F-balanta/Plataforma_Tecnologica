using MediatR;
using PlatecBackend.Persistence;

namespace PlatecBackend.Application.Actions.PostComment.Commands
{
    public class Create
    {
        public class CommandCreatePostComment : IRequest
        {
            public Guid? BlogPostId { get; set; }

            public string? UserFullName { get; set; }

            public string? Comment { get; set; }
        }
        
        public class CommandCreatePostCommentHandler : IRequestHandler<CommandCreatePostComment>
        {
            private readonly Context _context;

            public CommandCreatePostCommentHandler(Context context)
            {
                _context = context;
            }
            
            public async Task<Unit> Handle(CommandCreatePostComment request, CancellationToken cancellationToken)
            {
                
                var blog = _context.BlogPosts.FirstOrDefault(x => x.Id == request.BlogPostId);
                
                if (blog == null)
                    throw new Exception("No existe el blog");
                
                var postComment = new Domain.PostComment
                {
                    Id = Guid.NewGuid(),
                    Comment = request.Comment,
                    BlogPostId = request.BlogPostId,
                    UserFullName = request.UserFullName,
                    BlogPost = blog
                };
               

                _context.PostComments.Add(postComment);

                var value = await _context.SaveChangesAsync(cancellationToken);
                if (value > 0)
                    return Unit.Value;
                throw new Exception("Error al crear el tablero");
            }
        }
    }
}
