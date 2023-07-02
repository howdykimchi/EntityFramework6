using EntityFramework6.Models;
using EntityFramework6.Properties;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework6.Database
{
    internal class MyDbContext : DbContext
    {
        public MyDbContext() : base(Settings.Default.MyConnectionString)
        {
        }

        //DbSet
        public DbSet<School> Schools { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
