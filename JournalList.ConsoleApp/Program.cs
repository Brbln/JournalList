using JournalList.Business.Absract;
using JournalList.Business.Concrete;
using JournalList.Business.CrossCuttingConcerns.DependencyResolvers.Ninject;
using JournalList.DataAccess.Concrete.ADONET;
using JournalList.DataAccess.Concrete.EntityFramework;
using JournalList.Entities.Concrete;
using System;
using System.Linq;

namespace JournalList.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new JournalListContext())
            {
                Ekle(context);
            }
            var journalService = InstanceFactory.Get<IJournalService>();
            var list = journalService.GetAll();
            foreach (var j in list)
            {
                Console.WriteLine(j);
            }
            Console.WriteLine();

            //var bookManager = new JournalManager(new AdoJournalDal());
            //bookManager.GetAll().ForEach(b => Console.WriteLine(b));
            //Console.ReadLine();
            //Console.ReadKey();
        }

        private static void Guncelle(JournalListContext context)
        {
            //update
            var update = context.Journals.Where(w => w.Name == "Journal").FirstOrDefault();
            update.Name = "Dergi3";
            update.Price = (decimal)15.4;
            context.SaveChanges();
        }

        private static void Sil(JournalListContext context)
        {
            //delete
            var s = context.Journals.Where(w => w.Name == "Journal").FirstOrDefault();
            context.Journals.Remove(s);
            context.SaveChanges();
        }

        private static void Ekle(JournalListContext context)
        {
            var journal = new Journal()
            {
                Name = "Jour",
                Price = (decimal)21.1,
                IsMonthly=true
            };
            context.Journals.Add(journal);
            context.SaveChanges();
        }
    }
}
