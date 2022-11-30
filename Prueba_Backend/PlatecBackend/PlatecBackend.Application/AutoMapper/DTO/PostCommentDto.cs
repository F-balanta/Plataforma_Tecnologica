namespace PlatecBackend.Application.AutoMapper.DTO
{
    public class PostCommentDto
    {
        public Guid? Id { get; set; }

        public Guid? BlogPostId { get; set; }

        public string? UserFullName { get; set; }

        public string? Comment { get; set; }
    }
}
