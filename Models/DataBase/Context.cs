using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Web_3_6.Models.DataBase.Classes;

namespace Web_3_6.Models.DataBase
{
    public class Context: DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Issue> issues { get; set; }
        public DbSet<Comment> comments { get; set; }

        public Context(DbContextOptions<Context> options) 
            :base(options)
        {
            //Database.EnsureCreated();   // создаем базу данных при первом обращении
        }

    }
}
