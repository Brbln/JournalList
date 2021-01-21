using JournalList.DataAccess.Abstract;
using JournalList.Entities.Concrete;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Text;

namespace JournalList.DataAccess.Concrete.ADONET
{
    public class AdoJournalDal : IJournalDal
    {
        public int JournalId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsMonthly { get; set; }
        public List<AdoJournalDal> Listesi { get; set; }
        public AdoJournalDal()
        {

        }

        public AdoJournalDal(int journalId, string name, int price, bool isMonthly)
        {
            JournalId = journalId;
            Name = name;
            Price = price;
            IsMonthly = isMonthly;
        }
        public override string ToString()
        {
            return $"{JournalId,-10} {Name,-10} {Price,-10} {IsMonthly,-10}";
        }

        public void Add(Journal entity)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Journals(Name, Price, IsMonthly) VALUE (@Name, @Price,@IsMonthly)");
            cmd.Parameters.AddWithValue("@Name", entity.Name);
            cmd.Parameters.AddWithValue("@Price", entity.Price);
            cmd.Parameters.AddWithValue("@IsMonthly", entity.IsMonthly);
            VTYS.SqlExecuteNonQuery(cmd);
        }

        public void Delete(Journal entity)
        {

            using (SqlCommand cmd =
                new SqlCommand("DELETE FROM Journals where JournalId = @JournalId"))
            {
                cmd.Parameters.AddWithValue("JournalId", entity.JournalId);
                VTYS.SqlExecuteNonQuery(cmd);
            }

        }

        public Journal Get(Expression<Func<Journal, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Journal> GetAll(Expression<Func<Journal, bool>> filter = null)
        {
            var journalList = new List<Journal>();
            SqlCommand cmd = new SqlCommand("Select * from Journals");

            SqlDataReader reader = VTYS.SqlExecuteReader(cmd);
            while (reader.Read())
            {
                Journal journal = new Journal
                {
                    JournalId = Convert.ToInt32(reader[0]),
                    Name = reader[1].ToString(),
                    Price = decimal.Parse(reader[3].ToString())
                };

                journalList.Add(journal);
            }
            return journalList;
        }

        public void Update(Journal entity)
        {
            using (SqlCommand cmd =
               new SqlCommand("UPDATE Journals set Name = @Name, Price = @Price, IsMonthly = @IsMonthly where JournalId = @JournalId"))
            {
                cmd.Parameters.AddWithValue("JournalId", entity.JournalId);
                cmd.Parameters.AddWithValue("Name", entity.Name);
                cmd.Parameters.AddWithValue("Price", entity.Price);
                cmd.Parameters.AddWithValue("IsMonthly", entity.IsMonthly);
                VTYS.SqlExecuteNonQuery(cmd);
            }
        }

    }
}

