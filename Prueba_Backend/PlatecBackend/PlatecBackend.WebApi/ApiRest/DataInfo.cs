using PlatecBackend.Domain;
using PlatecBackend.Persistence;

namespace ApiRest
{
    public class DataInfo
    {
        public static void SeedData(WebApplication app)
        {
            var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetService<Context>();
            var blogList = new List<BlogPost>
            {
                new() { Id = Guid.Parse("183def02-7b8b-4b8d-9eda-7e6f43012970"), Tittle = "DD", PublishDate = DateTime.Now },
                new() { Id = Guid.Parse("34078ebc-6526-4519-b580-52cdc55f153a"), Tittle = "XX", PublishDate = DateTime.Now },
                new() { Id = Guid.Parse("dac3537f-ba91-4394-b696-34c0471140b4"), Tittle = "dsad", PublishDate = DateTime.Now },
                new() { Id = Guid.Parse("3202f9a1-cc02-4c29-be95-8fd7c10c02ac"), Tittle = "3213", PublishDate = DateTime.Now },
                new() { Id = Guid.Parse("07ad7f7b-7da8-4d93-80bb-ffee40d11ae8"), Tittle = "4343", PublishDate = DateTime.Now },
                new() { Id = Guid.Parse("b57df863-93de-45ac-9943-e23f22296d71"), Tittle = "54545544", PublishDate = DateTime.Now }
            };
            
            db.BlogPosts.AddRange(blogList);
            
            var postComment = new PostComment
            {
                Id = Guid.NewGuid(),
                Comment = "Está genial!!!",
                UserFullName = "Juan Felipe Balanta Rentería",
                BlogPostId = Guid.Parse("183def02-7b8b-4b8d-9eda-7e6f43012970"),
                BlogPost = db.BlogPosts.FirstOrDefault(x => x.Tittle == "DD")
            };

            db.PostComments.Add(postComment);

            db.SaveChangesAsync();
        }
    }
}
