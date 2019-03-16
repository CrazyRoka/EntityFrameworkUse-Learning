using EntityFrameworkCoreDatabaseFirst.Models;
using EntityFrameworkCoreUse.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCoreUse.ConsoleApp
{
    class AddTeamCommand : ICommand
    {
        public string Description => "Add team";

        public void Execute(UnitOfWork unitOfWork)
        {
            var name = ReadName();
            var team = new Team { Name = name };
            CreateTeam(unitOfWork, team);
        }

        private string ReadName()
        {
            Console.Write("Enter name: ");
            return Console.ReadLine().Trim();
        }

        private void CreateTeam(UnitOfWork unitOfWork, Team team)
        {
            unitOfWork.Team.Create(team);
            unitOfWork.Save();
            Console.WriteLine("Team successfully created!");
        }
    }
}
