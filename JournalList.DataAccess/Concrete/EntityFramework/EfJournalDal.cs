using JournalList.DataAccess.Abstract;
using JournalList.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace JournalList.DataAccess.Concrete.EntityFramework
{
    public class EfJournalDal :
        EfRepositoryBase<Journal, JournalListContext>, IJournalDal
    {

    }
}
