namespace PlatecBackend.Domain
{
    public class PostComment
    {
        public Guid? Id { get; set; }

        public Guid? BlogPostId { get; set; }

        public string? UserFullName { get; set; }

        public string? Comment { get; set; }

        public BlogPost? BlogPost { get; set; }

    }
}
