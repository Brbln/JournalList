using JournalList.Business.Absract;
using JournalList.Business.Concrete;
using JournalList.DataAccess.Abstract;
using JournalList.DataAccess.Concrete.EntityFramework;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace JournalList.Business.CrossCuttingConcerns.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IJournalService>().To<JournalManager>().InSingletonScope();
            Bind<IJournalDal>().To<EfJournalDal>().InSingletonScope();
        }
    }
}
