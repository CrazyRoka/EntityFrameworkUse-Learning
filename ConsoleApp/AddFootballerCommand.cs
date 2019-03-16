using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCoreDatabaseFirst.Models;
using EntityFrameworkCoreUse.DAL;

namespace EntityFrameworkCoreUse.ConsoleApp
{
    class AddFootballerCommand : ICommand
    {
        public string Description => "Add footballer";

        public void Execute(UnitOfWork unitOfWork)
        {
            var firstName = ReadFirstName();
            var lastName = ReadLastName();
            int teamId = ReadTeamId();
            var footballer = new Footballer { FirstName = firstName, LastName = lastName, TeamId = teamId };
            CreateFootballer(unitOfWork, footballer);
        }

        private string ReadFirstName()
        {
            Console.Write("Enter first name: ");
            return Console.ReadLine().Trim();
        }

        private string ReadLastName()
        {
            Console.Write("Enter second name: ");
            return Console.ReadLine().Trim();
        }

        private int ReadTeamId()
        {
            Console.Write("Enter team id: ");
            return int.Parse(Console.ReadLine().Trim());
        }

        private void CreateFootballer(UnitOfWork unitOfWork, Footballer footballer)
        {
            unitOfWork.Footballer.Create(footballer);
            unitOfWork.Save();
            Console.WriteLine("Team successfully created!");
        }
    }
}
