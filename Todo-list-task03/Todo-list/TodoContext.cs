using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Todo_list
{
    public class TodoContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }

        public string DbPath { get; }

        public TodoContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "blogging.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=todo.db");
        }
    }
}
