using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCoreUse.DAL;

namespace EntityFrameworkCoreUse.ConsoleApp
{
    class DeleteFootballerCommand : ICommand
    {
        public string Description => "Delete footballer";

        public void Execute(UnitOfWork unitOfWork)
        {
            int id = ReadFootballerId();
            DeleteFootballer(unitOfWork, id);
        }

        private int ReadFootballerId()
        {
            Console.Write("Enter team id: ");
            return int.Parse(Console.ReadLine().Trim());
        }

        private void DeleteFootballer(UnitOfWork unitOfWork, int id)
        {
            unitOfWork.Footballer.Delete(id);
            unitOfWork.Save();
            Console.WriteLine($"Footballer with id {id} was deleted");
        }
    }
}
