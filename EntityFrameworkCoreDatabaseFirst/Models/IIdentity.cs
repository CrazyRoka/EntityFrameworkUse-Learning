using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCoreDatabaseFirst.Models
{
    public interface IIdentity
    {
        int Id { get; set; }
    }
}
