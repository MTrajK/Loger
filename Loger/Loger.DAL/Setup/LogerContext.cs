using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loger.Common.Data;

namespace Loger.DAL.Setup
{
    // This is the main class that coordinates Entity Framework functionality for a given data model
    public class LogerContext : DbContext, ILogerContext
    {

        // with :base() is calling base constructor (constructor from DbContext class)
        // EFConfig.ConnectionString is argument from UI project, web.config, which i got from Application.Start();
        public LogerContext() : base(EFConfig.ConnectionString)
        {

        }
        
        // All Tables from my database
        //public DbSet< Name > Names { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Follow> Follows { get; set; }

        // Getters
        public DbSet<User> GetUsers()
        {
            return Users;
        }

        public DbSet<Photo> GetPhotos()
        {
            return Photos;
        }

        public DbSet<Like> GetLikes()
        {
            return Likes;
        }

        public DbSet<Comment> GetComments()
        {
            return Comments;
        }

        public DbSet<Follow> GetFollows()
        {
            return Follows;
        }

        // SaveChanges method
        public int Save()
        {
            return SaveChanges();
        }

        // This will be call when model for database is creating
        // Also names for database tables will be same as names of classes
        // This is to prevent pluarlizatons of names
        // Example: if i have class for model named "User" without this EF will make table "Users"
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Photo>()
                .HasRequired(p => p.User)
                .WithMany(u => u.Photos)
                .HasForeignKey(p => p.UserID)
                .WillCascadeOnDelete(false);
            
            modelBuilder.Entity<Follow>()
                .HasRequired(f => f.UserFollowing)
                .WithMany(u => u.Followings)
                .HasForeignKey(f => f.UserFollowingID)
                .WillCascadeOnDelete(false);
              
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
           // modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();  // because i have several one to many relations
        }

    }
}
