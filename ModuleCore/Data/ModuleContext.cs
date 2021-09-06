using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModuleCore.Models;

namespace ModuleCore.Data
{

    public class ModuleContext : DbContext
    {
        public ModuleContext(DbContextOptions<ModuleContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        //public DbSet<Student> Students { get; set; }
        // public DbSet<Post> Posts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("UserData");
        }
    }
}
