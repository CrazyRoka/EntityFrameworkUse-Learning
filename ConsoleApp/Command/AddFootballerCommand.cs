using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCoreDatabaseFirst.Models;
using EntityFrameworkCoreUse.DAL;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCoreUse.ConsoleApp
{
    class AddFootballerCommand : ICommand
    {
        public string Description => "Add footballer";

        public void Execute(UnitOfWork unitOfWork)
        {
            try
            {
                var firstName = ReadFirstName();
                var lastName = ReadLastName();
                int teamId = ReadTeamId();
                var footballer = new Footballer { FirstName = firstName, LastName = lastName, TeamId = teamId };
                CreateFootballer(unitOfWork, footballer);
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

        private string ReadFirstName()
        {
            Console.Write("Enter first name: ");
            string name = Console.ReadLine().Trim();
            if (name.Length < 1) throw new ArgumentException("First Name is too short");
            if (name.Length > 30) throw new ArgumentException("First Name is too long");
            return name;
        }

        private string ReadLastName()
        {
            Console.Write("Enter last name: ");
            string name = Console.ReadLine().Trim();
            if (name.Length < 1) throw new ArgumentException("Last Name is too short");
            if (name.Length > 30) throw new ArgumentException("Last Name is too long");
            return name;
        }

        private int ReadTeamId()
        {
            Console.Write("Enter team id: ");
            if (int.TryParse(Console.ReadLine().Trim(), out int id))
            {
                return id;
            }
            throw new ArgumentException("Team id is invaldi. Enter number please");
        }

        private void CreateFootballer(UnitOfWork unitOfWork, Footballer footballer)
        {
            unitOfWork.Footballer.Create(footballer);
            unitOfWork.Save();
            Console.WriteLine("Footballer successfully created!");
        }
    }
}
