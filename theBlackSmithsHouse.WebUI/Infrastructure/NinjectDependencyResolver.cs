using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Ninject;
using Moq;
using theBlackSmithsHouse.Domain.Abstract;
using theBlackSmithsHouse.Domain.Entities;
using theBlackSmithsHouse.Domain.Concrete;

namespace theBlackSmithsHouse.WebUI.Infrastructure
{
    public class NinjectDependencyResolver:IDependencyResolver
    {
        private IKernel mykernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            mykernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type myserviceType)
        {
            return mykernel.TryGet(myserviceType);
        }

        public IEnumerable<object> GetServices(Type myserviceType)
        {
            return mykernel.GetAll(myserviceType);
        }

        private void AddBindings()
        {
            // put bindings here
            mykernel.Bind<IProductRepository>().To<EFProductRepository>();
        }
    }
}