using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlogMvcApp.Models;

namespace BlogMvcApp.Controllers
{
    public class BlogController : Controller
    {
        private BlogContext db = new BlogContext();

        // GET: Blog
        public ActionResult Index()
        {
            var blogs = db.Blogs.Include(b => b.Category);
            return View(blogs.ToList());
        }

        public ActionResult List(int? id, string q)
        {
            var blogs = db.Blogs
              .Where(i => i.IsApproval == true)
              .Select(a => new BlogModel()
              {
                  Id = a.Id,
                  Title = a.Title.Length > 100 ? a.Title.Substring(0, 100) + "..." : a.Title,
                  Description = a.Description,
                  AddBlogDate = a.AddBlogDate,
                  IsAddHome = a.IsAddHome,
                  IsApproval = a.IsApproval,
                  Image = a.Image,
                  CategoryId = a.CategoryId
              }).AsQueryable();

            if (string.IsNullOrEmpty(q) == false)
            {
                blogs = blogs.Where(i => i.Title.Contains(q)  || i.Description.Contains(q));
            }  

            if (id !=null)
            {
                blogs = blogs.Where(i => i.CategoryId == id);
            }
            
            return View(blogs.ToList());
        }

        // GET: Blog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Blog/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName");
            return View();
        }

        // POST: Blog/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Description,Image,Contents,CategoryId")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                blog.AddBlogDate = DateTime.Now;
                db.Blogs.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", blog.CategoryId);
            return View(blog);
        }

        // GET: Blog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", blog.CategoryId);
            return View(blog);
        }

        // POST: Blog/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,Image,Contents,IsApproval,IsAddHome,CategoryId")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                var entity = db.Blogs.Find(blog.Id);
                if (entity != null)
                {
                    entity.Id = blog.Id;
                    entity.Title = blog.Title;
                    entity.Description = blog.Description;
                    entity.Contents = entity.Contents;
                    entity.Image = blog.Image;
                    entity.IsApproval = blog.IsApproval;
                    entity.IsAddHome = blog.IsAddHome;
                    entity.CategoryId = blog.CategoryId;

                    TempData["Blog"] = entity;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", blog.CategoryId);
            return View(blog);
        }

        // GET: Blog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Blogs.Find(id);
            db.Blogs.Remove(blog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
