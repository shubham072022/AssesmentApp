using AutoMapper;
using Todo.Application.Common.Mappings;

namespace Todo.UnitTest.Mocks
{
    public class BaseMockContext
    {
        protected readonly IMapper mapper;
        public BaseMockContext()
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            mapper = mapperConfig.CreateMapper();
        }
    }
}
