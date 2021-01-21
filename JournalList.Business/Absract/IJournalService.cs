using JournalList.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace JournalList.Business.Absract
{
    public interface IJournalService
    {
        List<Journal> GetAll(Expression<Func<Journal, bool>> filter = null);
        Journal Get(Expression<Func<Journal, bool>> filter);
        void Add(Journal entity);
        void Update(Journal entity);
        void Delete(Journal entity);

    }
}
