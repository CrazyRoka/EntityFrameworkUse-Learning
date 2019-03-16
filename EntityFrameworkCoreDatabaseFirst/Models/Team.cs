using System;
using System.Collections.Generic;

namespace EntityFrameworkCoreDatabaseFirst.Models
{
    public partial class Team
    {
        public Team()
        {
            Footballer = new List<Footballer>();
        }

        public int TeamId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Footballer> Footballer { get; set; }

        public override string ToString() => $"Team name: {Name}, Id: {TeamId}";
    }
}
