using System;
using System.Collections.Generic;
using System.Text;
using ApplicationC.Interfaces.Repositories;
using AutoMapper;
using Xunit;

namespace Application.Test.TestUtils
{
    public class CommonTestFixture
    {
        public CommonTestFixture()
        {
            
        }
        [CollectionDefinition("CommonTestCollection")]
        public class CommonTestCollection : ICollectionFixture<CommonTestFixture>{}
    }
}
