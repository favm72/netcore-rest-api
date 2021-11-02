using REAL.Logic.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REAL.API
{ 
    public class CustomDbContextFactory<T> : ICustomDbContextFactory<T> where T : DbContext
    {
        public T CreateDbContext(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<T>();
            optionsBuilder.UseSqlServer(connectionString);
            return System.Activator.CreateInstance(typeof(T), optionsBuilder.Options) as T;
        }
    }
}
