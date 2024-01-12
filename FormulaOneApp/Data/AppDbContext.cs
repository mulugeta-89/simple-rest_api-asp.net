﻿using FormulaOneApp.Models;
using Microsoft.EntityFrameworkCore;

//using Microsoft.EntityFrameworkCore;

namespace FormulaOneApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
        }
    }
}
