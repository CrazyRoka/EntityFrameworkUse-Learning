using EntityFrameworkCoreUse.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCoreUse.ConsoleApp
{
    interface ICommand
    {
        string Description { get; }
        void Execute(UnitOfWork unitOfWork);
    }
}
