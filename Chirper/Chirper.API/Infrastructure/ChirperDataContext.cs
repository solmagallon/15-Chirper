﻿using Chirper.API.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Chirper.API.Infrastructure
{
    public class ChirperDataContext : IdentityDbContext<ChirperUser>
    {
        public ChirperDataContext() : base("Chirper")
        {
        }
        public IDbSet<Post> Posts { get; set;}
        public IDbSet<Comment> Comments { get; set; }
   
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configures the one to many relationship between Post and Comment
            modelBuilder.Entity<Post>()
             .HasMany(p => p.Comments)
             .WithRequired(c => c.Post)
             .HasForeignKey(c => c.PostId);

            //Configure a one to many relationship between a user and a post
            modelBuilder.Entity<ChirperUser>()
             .HasMany(u => u.Posts)
             .WithRequired(p => p.User)
             .HasForeignKey(p => p.UserId);

            //Configure a one to many relationship between a user and a comment
            modelBuilder.Entity<ChirperUser>()
             .HasMany(u => u.Comments)
             .WithRequired(c => c.User)
             .HasForeignKey(c => c.UserId)
             .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }

    }
}