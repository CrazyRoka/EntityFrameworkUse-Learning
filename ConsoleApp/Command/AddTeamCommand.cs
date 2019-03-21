using EntityFrameworkCoreDatabaseFirst.Models;
using EntityFrameworkCoreUse.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace EntityFrameworkCoreUse.ConsoleApp
{
    class AddTeamCommand : ICommand
    {
        public string Description => "Add team";

        public void Execute(UnitOfWork unitOfWork)
        {

            try
            {
                var name = ReadName();
                var team = new Team { Name = name };
                CreateTeam(unitOfWork, team);
            }
            catch (Exception e) when (e is DbUpdateException || e is DbUpdateConcurrencyException)
            {
                Console.WriteLine(e.InnerException.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private string ReadName()
        {
            Console.Write("Enter team name: ");
            string name = Console.ReadLine().Trim();
            if (name.Length < 1) throw new ArgumentException("Name is too short");
            if (name.Length > 30) throw new ArgumentException("Name is too long");
            return name;
        }

        private void CreateTeam(UnitOfWork unitOfWork, Team team)
        {
            unitOfWork.Team.Create(team);
            unitOfWork.Save();
            Console.WriteLine("Team successfully created!");
        }
    }
}
