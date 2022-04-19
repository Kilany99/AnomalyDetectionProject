using Microsoft.EntityFrameworkCore;
using AnomalyDetectionProject.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AnomalyDetectionProject.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Models.Action> Actions { get; set; }
        public DbSet<Camera> cameras { get; set; }
        public DbSet<PostedData> postedDatas { get; set; }
        public DbSet<AdminModel> Admins { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-P944USQ\SQLEXPRESS01;Initial Catalog=RAISDB;Integrated Security=True;");
        }
        


    }
}