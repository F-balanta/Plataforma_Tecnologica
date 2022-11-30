using AutoMapper;
using PlatecBackend.Application.AutoMapper.DTO;
using PlatecBackend.Domain;

namespace PlatecBackend.Application.AutoMapper.Configuration
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<BlogPost, BlogPostDto>().ForMember(x => x.Comments, y => y.MapFrom(z => z.PostComment)).ReverseMap();
            CreateMap<PostComment, PostCommentDto>().ReverseMap();
        }
    }
}
