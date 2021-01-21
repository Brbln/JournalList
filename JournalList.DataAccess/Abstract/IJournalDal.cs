using JournalList.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace JournalList.DataAccess.Abstract
{
    public interface IJournalDal : IEntityRepository<Journal>
    {
    }
}
