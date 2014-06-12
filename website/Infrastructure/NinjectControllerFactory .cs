using System;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using domain.Entities;
using domain.Abstract;
using domain.Concrete;

namespace website.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null
                ? null
                : (IController)ninjectKernel.Get(controllerType);
        }
        private void AddBindings()
        {
            ninjectKernel.Bind<IBookRepository>().To<BookRepository>();
        }
    }
}
