using AutoMapper;
using Todo.Application.Common.Mappings;
using Todo.Domain.Entities;

namespace Todo.Application.Dtos
{
    public class TodoDTO : IMapFrom<TodoM>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<TodoM, TodoDTO>()
                .ForMember(x => x.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(x => x.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(x => x.IsCompleted, opt => opt.MapFrom(s => s.IsCompleted));
        }
    }
}
