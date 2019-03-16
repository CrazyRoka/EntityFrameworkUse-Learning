using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCoreDatabaseFirst.Models;
using EntityFrameworkCoreUse.DAL;

namespace EntityFrameworkCoreUse.ConsoleApp
{
    class UpdateTeamCommand : ICommand
    {
        public string Description => "Update team";

        public void Execute(UnitOfWork unitOfWork)
        {
            int teamId = ReadTeamId();
            var newName = ReadName();
            var team = new Team { Name = newName, TeamId = teamId };
            UpdateTeam(unitOfWork, team);
        }

        private string ReadName()
        {
            Console.Write("Enter name: ");
            return Console.ReadLine().Trim();
        }

        private int ReadTeamId()
        {
            Console.Write("Enter team id: ");
            return int.Parse(Console.ReadLine().Trim());
        }

        private void UpdateTeam(UnitOfWork unitOfWork, Team team)
        {
            unitOfWork.Team.Update(team);
            unitOfWork.Save();
            Console.WriteLine($"Team with id {team.TeamId} was updated");
        }
    }
}
