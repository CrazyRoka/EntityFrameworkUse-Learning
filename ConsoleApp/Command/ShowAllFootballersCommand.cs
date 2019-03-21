using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCoreDatabaseFirst.Models;
using EntityFrameworkCoreUse.DAL;

namespace EntityFrameworkCoreUse.ConsoleApp
{
    class ShowAllFootballerCommand : ICommand
    {
        public string Description => "Show all Footballer";

        public void Execute(UnitOfWork unitOfWork)
        {
            Console.WriteLine("Footballers:");
            var footballers = unitOfWork.Footballer.GetAll();
            foreach (var footballer in footballers)
            {
                Console.WriteLine(footballer);
            }
        }
    }
}
