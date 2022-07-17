
using EFSqlite.Context;
using EFSqlite.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFSqlite.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DemoController : ControllerBase
    {
        // private BlogRepository blogRepository = new BlogRepository();
        public BlogRepository blogRep;
        public DemoController()
        {
            blogRep = new BlogRepository();
        }

        //
        // GET: /HelloWorld/Welcome/

        [HttpGet("list")]
        public List<Blog> list()
        {
            Console.WriteLine("Get Blogs");
            blogRep.CreateBlog();
            return blogRep.ReadBlogs();
        }

        [HttpGet("test")]
        public string test()
        {
            return "test";
        }
    }
}