using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSApp.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WSApp.Contexts
{
    public class DBContext:DbContext
    {
        public DBContext(DbContextOptions<DBContext> options):base(options)
        {
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Scores> Scores { get; set; }

        public static implicit operator ControllerContext(DBContext v)
        {
            throw new NotImplementedException();
        }
    }
}
