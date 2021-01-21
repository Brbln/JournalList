using JournalList.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace JournalList.Entities.Concrete
{
    public class Journal : IEntity
    {
        public int JournalId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsMonthly { get; set; }

        public Journal()
        {

        }
        public Journal(int journalId, string name, decimal price, bool isMontly)
        {
            JournalId = journalId;
            Name = name;
            Price = price;
            IsMonthly = isMontly;
        }

        public override string ToString()
        {
            return $"{JournalId,-10} {Name,-10} {Price,-10} {IsMonthly,-10}";
        }

    }
}
