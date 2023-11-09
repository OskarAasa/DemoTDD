using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LogErrorWebApi.Models;

namespace LogErrorWebApi.Data
{
    public class LogErrorWebApiContext : DbContext
    {
        public LogErrorWebApiContext (DbContextOptions<LogErrorWebApiContext> options)
            : base(options)
        {
        }

        public DbSet<LogErrorWebApi.Models.ErrorReport> ErrorReport { get; set; } = default!;
    }
}
