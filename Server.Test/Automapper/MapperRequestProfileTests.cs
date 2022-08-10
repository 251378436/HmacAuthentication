using AutoFixture;
using AutoMapper;
using Server.Automapper;
using Server.Models.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Test.Automapper
{
    [TestClass]
    public class MapperRequestProfileTests
    {
        private readonly IMapper _mapper;
        public MapperRequestProfileTests()
        {
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<MapperRequestProfile>()).CreateMapper();
        }

        [TestMethod]
        public void AutoMapper_Configuration_IsValid()
        {
            //var request = new Fixture().Create<MapperRequest>();
            //var resposne = _mapper.Map<MapperRequest, MapperResponse>(request);

            _mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }
    }
}
