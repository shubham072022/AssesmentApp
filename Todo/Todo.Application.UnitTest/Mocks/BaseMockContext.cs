using AutoMapper;
using Todo.Application.Common.Mappings;

namespace Todo.Application.UnitTest.Mocks
{
    public class BaseMockContext
    {
        protected readonly IMapper _mapper;
        public BaseMockContext()
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }
    }
}
