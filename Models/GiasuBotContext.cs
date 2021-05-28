using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GiasuBotAPI.Models
{
    public class GiasuBotContext : DbContext
    {
        public GiasuBotContext() : base("name=DefaultConnection")
        {
        }
        public DbSet<Lop1> Lop1 { get; set; }
        public DbSet<Lop2> Lop2 { get; set; }
        public DbSet<Lop3> Lop3 { get; set; }
        public DbSet<Lop4> Lop4 { get; set; }
        public DbSet<Lop5> Lop5 { get; set; }
        public DbSet<Lop6> Lop6 { get; set; }
        public DbSet<Lop7> Lop7 { get; set; }
        public DbSet<Lop8> Lop8 { get; set; }
        public DbSet<Lop9> Lop9 { get; set; }
        public DbSet<Lop10> Lop10 { get; set; }
        public DbSet<Lop11> Lop11 { get; set; }
        public DbSet<Lop12> Lop12 { get; set; }
    }
}