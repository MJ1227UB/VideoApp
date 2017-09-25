using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using VideoAppDAL.Entities;

namespace VideoAppDAL.Context
{
    public class VideoAppContext : DbContext
    {
        private static readonly string DBConnectionPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DBstring.txt");
        private static readonly string ConnectionString = File.ReadAllText(DBConnectionPath);
        static DbContextOptions<VideoAppContext> options = new DbContextOptionsBuilder<VideoAppContext>()
            .UseInMemoryDatabase("TheDB").Options;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}