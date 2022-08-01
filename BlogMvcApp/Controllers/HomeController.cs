using BlogMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogMvcApp.Controllers
{
    public class HomeController : Controller
    {
        private BlogContext blogContext = new BlogContext();
        public ActionResult Index()
        {
            var blogs = blogContext.Blogs
                .Select(a => new BlogModel()
                {
                    Id = a.Id,
                    Title = a.Title.Length>100 ? a.Title.Substring(0,100) + "..." : a.Title,
                    Description = a.Description,
                    AddBlogDate = a.AddBlogDate,
                    IsAddHome = a.IsAddHome,
                    IsApproval = a.IsApproval,
                    Image = a.Image                    
                })
                .Where(i => i.IsApproval == true && i.IsAddHome == true);
            return View(blogs.ToList());
        }
    }
}