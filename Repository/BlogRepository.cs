using System;
using System.Linq;
using EFSqlite.Context;
using Microsoft.EntityFrameworkCore;

namespace EFSqlite.Repository
{
    public class BlogRepository
    {
        private BloggingContext db = new BloggingContext();
        public BlogRepository()
        {
            // Note: This sample requires the database to be created before running.
            Console.WriteLine($"Database path: {db.DbPath}.");
        }

        public void CreateBlog()
        {
            // Create
            Console.WriteLine("Inserting a new blog");
            db.Add(new Blog { Url = "http://blogs.msdn.com/adonet", newTest = "new data" });
            db.SaveChanges();
        }

        public List<Blog> ReadBlogs()
        {
            // Read
            Console.WriteLine("Querying for a blog");
            var blogs = db.Blogs;
            foreach (var item in blogs)
            {
                Console.WriteLine(item.newTest);
                Console.WriteLine(item.Url);
            }
            return blogs.ToList();

        }

        public int UpdateBlog(Blog blog)
        {
            // Update
            Console.WriteLine("Updating the blog and adding a post");
            blog.Url = "https://devblogs.microsoft.com/dotnet";
            blog.Posts.Add(
                new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" });
            return db.SaveChanges();
        }

        public int DeleteBlog(Blog blog)
        {
            // Delete
            Console.WriteLine("Delete the blog");
            db.Remove(blog);
            return db.SaveChanges();
        }

    }
}

