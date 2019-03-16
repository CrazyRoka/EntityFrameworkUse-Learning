using EntityFrameworkCoreDatabaseFirst.Models;
using EntityFrameworkCoreUse.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFrameworkCoreUse.DAL
{
    public class FootballerRepository : IRepository<Footballer>
    {
        private readonly TeamContext context;

        public FootballerRepository(TeamContext context) => this.context = context;

        public void Create(Footballer footballer)
        {
            context.Footballer.Add(footballer);
        }

        public void Delete(int id)
        {
            Footballer footballer = context.Footballer.Find(id);
            context.Footballer.Remove(footballer);
        }

        public Footballer Get(int id)
        {
            return context.Footballer.Find(id);
        }

        public IEnumerable<Footballer> GetAll()
        {
            return context.Footballer.ToList();
        }

        public void Update(Footballer footballer)
        {
            context.Entry(footballer).State = EntityState.Modified;
        }
    }
}
