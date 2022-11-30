namespace PlatecBackend.Application.AutoMapper.DTO
{
    public class BlogPostDto
    {
        public Guid? Id { get; set; }
        public string? Tittle { get; set; }
        public DateTime? PublishDate { get; set; }
        public List<PostCommentDto> Comments { get; set; }
    }
}
