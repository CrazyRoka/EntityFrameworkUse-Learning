using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCoreDatabaseFirst.Models;
using EntityFrameworkCoreUse.DAL;

namespace EntityFrameworkCoreUse.ConsoleApp
{
    class ShowAllTeamCommand : ICommand
    {
        public string Description => "Show all Team";

        public void Execute(UnitOfWork unitOfWork)
        {
            Console.WriteLine("Teams:");
            PrintTeam(unitOfWork);
        }

        private void PrintTeam(UnitOfWork unitOfWork)
        {
            foreach (Team team in unitOfWork.Team.GetAllWithFootballers())
            {
                Console.WriteLine(team);
                Console.WriteLine($"Team consists of {team.Footballer.Count} players:");
                PrintFootballers(team);
                Console.WriteLine();
            }
        }
        
        private void PrintFootballers(Team team)
        {
            foreach (Footballer footballer in team.Footballer)
            {
                Console.WriteLine(footballer);
            }
        }
    }
}
