using EntityFrameworkCoreDatabaseFirst.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCoreUse.DAL
{
    public class UnitOfWork
    {
        private readonly TeamContext context;
        private TeamRepository teamRepository;
        private FootballerRepository footballerRepository;
        public UnitOfWork(TeamContext context) => this.context = context;

        public TeamRepository Team => teamRepository = teamRepository ?? new TeamRepository(context);

        public FootballerRepository Footballer =>
            footballerRepository = footballerRepository ?? new FootballerRepository(context);

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
