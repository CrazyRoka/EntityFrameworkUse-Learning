using EntityFrameworkCoreDatabaseFirst.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkCoreUse.DAL
{
    public class TeamRepository : IRepository<Team>
    {
        private TeamContext context;

        public TeamRepository(TeamContext context) => this.context = context;

        public void Create(Team team)
        {
            context.Team.Add(team);
        }

        public void Delete(int id)
        {
            Team team = context.Team.Find(id);
            context.Team.Remove(team);
        }

        public Team Get(int id)
        {
            return context.Team.Find(id);
        }

        public IEnumerable<Team> GetAll()
        {
            return context.Team.ToList();
        }

        public IEnumerable<Team> GetAllWithFootballers()
        {
            return context.Team.Include(t => t.Footballer).ToList();
        }

        public void Update(Team team)
        {
            var old = context.Team.Find(team.TeamId);
            context.Entry(old).CurrentValues.SetValues(team);
        }
    }
}
