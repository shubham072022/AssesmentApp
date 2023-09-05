using AutoMapper;
using Microsoft.Office.Interop.Excel;
using Todo.Application.Common.Mappings;

namespace Todo.UnitTest.Mocks
{
    public class BaseMockContext
    {
        private readonly IMapper _mapper;
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
