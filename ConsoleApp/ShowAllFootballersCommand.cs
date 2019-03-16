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
            Console.WriteLine("Footballer:");
            foreach(Footballer footballer in unitOfWork.Footballer.GetAll())
            {
                Console.WriteLine(footballer);
            }
        }
    }
}
