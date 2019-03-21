using System;
using System.Collections.Generic;

namespace EntityFrameworkCoreDatabaseFirst.Models
{
    public partial class Team : IIdentity
    {
        public Team()
        {
            Footballer = new HashSet<Footballer>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Footballer> Footballer { get; set; }

        public override string ToString() => $"Team name: {Name}, Id: {Id}";
    }
}
