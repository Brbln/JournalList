using JournalList.Business.Absract;
using JournalList.DataAccess.Abstract;
using JournalList.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace JournalList.Business.Concrete
{
    public class JournalManager : IJournalService
    {
        private IJournalDal _journal;

        public JournalManager(IJournalDal journal)
        {
            _journal = journal;
        }

        public void Add(Journal entity)
        {
            _journal.Add(entity);
        }

        public void Delete(Journal entity)
        {
            _journal.Delete(entity);
        }

        public Journal Get(Expression<Func<Journal, bool>> filter)
        {
            return _journal.Get(filter);
        }

        public List<Journal> GetAll(Expression<Func<Journal, bool>> filter = null)
        {
            return _journal.GetAll(filter);
        }

        public void Update(Journal entity)
        {
            _journal.Update(entity);
        }
    }
}
