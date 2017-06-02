using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject.Modules;
using Domain.Repositories;

namespace CygX1.AuthorAid.Windows.IocModules
{
    public class NinjectRuntimeModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository>().To<Repository>();
        }
    }
}
