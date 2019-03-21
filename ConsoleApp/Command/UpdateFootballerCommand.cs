using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCoreDatabaseFirst.Models;
using EntityFrameworkCoreUse.DAL;

namespace EntityFrameworkCoreUse.ConsoleApp
{
    class UpdateFootballerCommand : ICommand
    {
        public string Description => "Update footballer";

        public void Execute(UnitOfWork unitOfWork)
        {
            int id = ReadId();
            int teamId = ReadTeamId();
            var newFirstName = ReadFirstName();
            var newLasttName = ReadLastName();
            var footballer = new Footballer
            {
                Id = id,
                FirstName = newFirstName,
                LastName = newLasttName,
                TeamId = teamId
            };

            UpdateFootballer(unitOfWork, footballer);
        }

        private string ReadFirstName()
        {
            Console.Write("Enter first name: ");
            return Console.ReadLine().Trim();
        }

        private string ReadLastName()
        {
            Console.Write("Enter last name: ");
            return Console.ReadLine().Trim();
        }

        private int ReadId()
        {
            Console.Write("Enter id: ");
            return int.Parse(Console.ReadLine().Trim());
        }

        private int ReadTeamId()
        {
            Console.Write("Enter team id: ");
            return int.Parse(Console.ReadLine().Trim());
        }

        private void UpdateFootballer(UnitOfWork unitOfWork, Footballer footballer)
        {
            unitOfWork.Footballer.Update(footballer);
            unitOfWork.Save();
            Console.WriteLine($"Footballer with id {footballer.Id} was updated");
        }
    }
}
