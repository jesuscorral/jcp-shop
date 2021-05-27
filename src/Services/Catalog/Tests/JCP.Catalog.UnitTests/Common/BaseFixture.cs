using AutoMapper;
using JCP.Catalog.Application.Mappers;
using System;

namespace JCP.Catalog.UnitTests.Common
{
    // This class is only executed one time before execute any test
    public class BaseFixture : IDisposable
    {
        protected static IMapper _mapper;

        public BaseFixture()
        {
            // Setup here
            if (_mapper == null)
            {
                var mapperConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new CatalogItemsMapper());
                });

                var mapper = mapperConfig.CreateMapper();
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }
        }

        public void Dispose()
        {
            // Cleanup here
        }
    }
}