using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationC.Interfaces;
using ApplicationC.Interfaces.Repositories;
using Castle.DynamicProxy;
using Domain;
using ImpromptuInterface;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repositories;

namespace Application.Test.TestUtils
{
    public class RepositoryResolverTest
    {
        private readonly List<IGenericRepository<Base>> _customMocks;
        private static ApplicationDbContext _context;

        public RepositoryResolverTest(ApplicationDbContext context)
        {
            _customMocks = new List<IGenericRepository<Base>>();
            _context = context;
        }
        public RepositoryResolverTest(ApplicationDbContext context, params IGenericRepository<Base>[] customMocks)
        {
            _context = context;
            _customMocks = customMocks.ToList();
        }

        //public TR Resolve<TR,T>() where TR : IGenericRepository<T> where T : class
        //{
        //    var customMock = _customMocks.FirstOrDefault(c => c.GetType().GetInterfaces().Any(t => t == typeof(TR)));
        //    if (customMock != null)
        //    {
        //        return (TR)customMock;
        //    }

        //    return ResolveInMemoryMock(typeof(TR));
        //}

        internal T ResolveInMemoryMock<T>() where T : class
        {
            Type repoType = typeof(T);
            var implementedType = repoType.GetInterfaces().FirstOrDefault(t => t.Name.StartsWith("IGenericRepository") && t.GenericTypeArguments.Length == 1);
            if (implementedType == null)
                throw new Exception($"No existe implementación para: {repoType}");

            var genericArgs = implementedType.GenericTypeArguments;

            var repoImpl = typeof(GenericRepository<>);
            var repoImplGeneric = repoImpl.MakeGenericType(genericArgs);

            var proxy = new ProxyGenerator();
            var proxyObject = proxy.CreateClassProxy(repoImplGeneric, constructorArguments: new object[] {_context});
            return proxyObject.ActLike<T>();
        }
    }
}