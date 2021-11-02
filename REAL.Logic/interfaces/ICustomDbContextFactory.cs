using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace REAL.Logic.interfaces
{
    public interface ICustomDbContextFactory<out T> where T : DbContext
    {
        T CreateDbContext(string connectionString);
    }
}
