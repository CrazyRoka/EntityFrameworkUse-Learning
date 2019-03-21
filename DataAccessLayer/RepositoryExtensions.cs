using EntityFrameworkCoreDatabaseFirst.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFrameworkCoreUse.DAL
{
    static class RepositoryExtensions
    {
        public static void DetachLocal<T>(this DbContext context, T t)
            where T : class, IIdentity
        {
            var local = context.Set<T>()
                .Local
                .FirstOrDefault(entry => entry.Id.Equals(t.Id));
            if(local != null)
            {
                context.Entry(local).State = EntityState.Detached;
            }
        }
    }
}
