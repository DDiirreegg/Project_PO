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
        //public DbSet<Post> Posts { get; set; }

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
        public int IdBill { get; set; }
        public string SumBill { get; set; }
        public string Tips { get; set; }
    }

    //public class Blog
    //{
    //    public long Id { get; set; }
    //    public string Url { get; set; }

    //    public List<Post> Posts { get; } = new();
    //}

    //public class Post
    //{
    //    public long Id { get; set; }
    //    public string Title { get; set; }
    //    public string Content { get; set; }

    //    public long BlogId { get; set; }
    //    public Blog Blog { get; set; }
    //}
}
