using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
namespace EFSqlite.Context
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        public string DbPath { get; set; }
        public BloggingContext()
        {
            string path = "./Db";
            DbPath = System.IO.Path.Join(path, "blogging.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
           => options.UseSqlite($"Data Source={DbPath}");
    }

    public class Blog
    {
        public int BlogId { get; set; } = 0;
        public string Url { get; set; } = "";
        public string newTest { get; set; } = "";
        public List<Post> Posts { get; set; } = new List<Post>();
    }

    public class Post
    {
        public int PostId { get; set; } = 0;
        public string Title { get; set; } = "";
        public string Content { get; set; } = "";

        public int BlogId { get; set; } = 0;
        public Blog Blog { get; set; } = new Blog();
    }
}

