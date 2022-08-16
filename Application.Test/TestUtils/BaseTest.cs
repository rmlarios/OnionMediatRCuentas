using System;
using System.Collections.Generic;
using System.Text;
using ApplicationC.Interfaces.Repositories;
using ApplicationC.Mappings;
using AutoMapper;
using Persistence.Context;

namespace Application.Test.TestUtils
{
    public class BaseTest : IDisposable
    {
        protected readonly ApplicationDbContext context;
        protected readonly RepositoryResolverTest repositoryResolver;
        protected readonly IMapper mapper;

        public BaseTest()
        {
            context = TestContextFactory.Create();
            repositoryResolver = new RepositoryResolverTest(context);

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapProfile>();
            });

            mapper = configurationProvider.CreateMapper();
        }
        public void Dispose()
        {
           TestContextFactory.Destroy(context);
        }
    }
}
