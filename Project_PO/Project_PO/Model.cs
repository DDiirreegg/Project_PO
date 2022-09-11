using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Project_PO
{
    public static class ProjectConfig
    {
        public static readonly string CONNECTION_STRING = "Data Source=localhost;Initial Catalog=Project;Integrated Security=True";
    }

    public class ProjectContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Menu> Menus { get; set; }
        

        public string ConnectionString { get; }

        public ProjectContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(this.ConnectionString);
        }
    }

    [Table("Users")]
    public class User
    {
        [Key]
        [Column("idk")]
        public int IdK { get; set; }
        [Column("login")]
        public string Login { get; set; }
        public string pass { get; set; }
        public string namek { get; set; }
        public string snamek { get; set; }
    }

    [Table("Reservations")]
    public class Reservation
    {
        [Key]
        public int idr { get; set; }
        public int idt { get; set; }
        public DateTime day{ get; set; }
        public TimeSpan time { get; set; }
        public int namber { get; set; }
        public int idk { get; set; }
    }

    [Table("Bills")]
    public class Bill
    {
        [Key]
        public int idbill { get; set; }
        public string sumbill { get; set; }
        public string tips { get; set; }
    }
    [Table("Menus")]
    public class MenU
    {
        [Key]
        public int iddish { get; set; }
        public string namedish { get; set; }
        public int costdish { get; set; }   
        public string description { get; set; }

    }
}
