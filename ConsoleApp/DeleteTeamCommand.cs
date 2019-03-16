using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCoreUse.DAL;

namespace EntityFrameworkCoreUse.ConsoleApp
{
    class DeleteTeamCommand : ICommand
    {
        public string Description => "Delete team";

        public void Execute(UnitOfWork unitOfWork)
        {
            int id = ReadTeamId();
            DeleteTeam(unitOfWork, id);
        }

        private int ReadTeamId()
        {
            Console.Write("Enter team id: ");
            return int.Parse(Console.ReadLine().Trim());
        }

        private void DeleteTeam(UnitOfWork unitOfWork, int id)
        {
            unitOfWork.Team.Delete(id);
            unitOfWork.Save();
            Console.WriteLine($"Team with id {id} was deleted");
        }
    }
}
