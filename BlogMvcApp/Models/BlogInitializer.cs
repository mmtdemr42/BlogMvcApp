using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogMvcApp.Models
{
    public class BlogInitializer : DropCreateDatabaseIfModelChanges<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {
            List<Category> categories = new List<Category>()
            {
                new Category(){CategoryName="C#"},
                new Category(){CategoryName="Asp .Net Mvc"},
                new Category(){CategoryName="Asp .Net WebForm"},
                new Category(){CategoryName="Windows Form"},
            };

            foreach (var category in categories)
            {
                context.Categories.Add(category);
            }
            context.SaveChanges();

            List<Blog> blogs = new List<Blog>()
            {
                new Blog(){Title = "C# Delegate Hakkında", Description = "Bu gkusrsun içeriğinde c# 'a dair bir çok şey bulabileceksiniz. Bu kursun içerindeki videolar sizi adfım adım ileriye götürecek.", IsAddHome=false, IsApproval=true, Contents="İçerik bayağı önemli", AddBlogDate=DateTime.Now.AddDays(-10), Image="1.jpg", CategoryId=1 },
                new Blog(){Title = "C# Delegate Hakkında", Description = "Bu gkusrsun içeriğinde c# 'a dair bir çok şey bulabileceksiniz. Bu kursun içerindeki videolar sizi adfım adım ileriye götürecek.", IsAddHome=true, IsApproval=false, Contents="İçerik bayağı önemli", AddBlogDate=DateTime.Now.AddDays(10), Image="2.jpg", CategoryId=1 },
                new Blog(){Title = "C# Delegate Hakkında", Description = "Bu gkusrsun içeriğinde c# 'a dair bir çok şey bulabileceksiniz. Bu kursun içerindeki videolar sizi adfım adım ileriye götürecek.", IsAddHome=true, IsApproval=true, Contents="İçerik bayağı önemli", AddBlogDate=DateTime.Now.AddDays(-50), Image="3.jpg", CategoryId=1 },
                new Blog(){Title = "Asp .Net Mvc nedir?", Description = "Bu gkusrsun içeriğinde c# 'a dair bir çok şey bulabileceksiniz. Bu kursun içerindeki videolar sizi adfım adım ileriye götürecek.", IsAddHome=false, IsApproval=false, Contents="İçerik bayağı önemli", AddBlogDate=DateTime.Now.AddDays(70), Image="4.jpg", CategoryId=2 },
                new Blog(){Title = "Asp .Net Mvc Kullanımı nasıldır?", Description = "Bu gkusrsun içeriğinde c# 'a dair bir çok şey bulabileceksiniz. Bu kursun içerindeki videolar sizi adfım adım ileriye götürecek.", IsAddHome=true, IsApproval=false, Contents="İçerik bayağı önemli", AddBlogDate=DateTime.Now.AddDays(-20), Image="5.jpg", CategoryId=2 },
                new Blog(){Title = "Asp .Net Mvc Alanları?", Description = "Bu gkusrsun içeriğinde c# 'a dair bir çok şey bulabileceksiniz. Bu kursun içerindeki videolar sizi adfım adım ileriye götürecek.", IsAddHome=true, IsApproval=true, Contents="İçerik bayağı önemli", AddBlogDate=DateTime.Now.AddDays(-10), Image="6.jpg", CategoryId=2 },
                new Blog(){Title = "Asp .Net Mvc Bilgilendirme", Description = "Bu gkusrsun içeriğinde c# 'a dair bir çok şey bulabileceksiniz. Bu kursun içerindeki videolar sizi adfım adım ileriye götürecek.", IsAddHome=true, IsApproval=false, Contents="İçerik bayağı önemli", AddBlogDate=DateTime.Now.AddDays(-30), Image="7.jpg", CategoryId=2 },
                new Blog(){Title = "Asp .Net Mvc Hakkında", Description = "Bu gkusrsun içeriğinde c# 'a dair bir çok şey bulabileceksiniz. Bu kursun içerindeki videolar sizi adfım adım ileriye götürecek.", IsAddHome=true, IsApproval=false, Contents="İçerik bayağı önemli", AddBlogDate=DateTime.Now.AddDays(-10), Image="8.jpg", CategoryId=2 },
                new Blog(){Title = "Asp .Net WebForm Nedir?", Description = "Bu gkusrsun içeriğinde c# 'a dair bir çok şey bulabileceksiniz. Bu kursun içerindeki videolar sizi adfım adım ileriye götürecek.", IsAddHome=true, IsApproval=true, Contents="İçerik bayağı önemli", AddBlogDate=DateTime.Now.AddDays(10), Image="9.jpg", CategoryId=2 },
                new Blog(){Title = "Asp .Net WebForm Kullanıum Alanları", Description = "Bu gkusrsun içeriğinde c# 'a dair bir çok şey bulabileceksiniz. Bu kursun içerindeki videolar sizi adfım adım ileriye götürecek.", IsAddHome=true, IsApproval=false, Contents="İçerik bayağı önemli", AddBlogDate=DateTime.Now.AddDays(1), Image="10.jpg", CategoryId=3 },
                new Blog(){Title = "Asp .Net WebForm Hakkında", Description = "Bu gkusrsun içeriğinde c# 'a dair bir çok şey bulabileceksiniz. Bu kursun içerindeki videolar sizi adfım adım ileriye götürecek.", IsAddHome=false, IsApproval=false, Contents="İçerik bayağı önemli", AddBlogDate=DateTime.Now.AddDays(7), Image="11.jpg", CategoryId=3 },
                new Blog(){Title = "Windows Form Kullanım Alanları", Description = "Bu gkusrsun içeriğinde c# 'a dair bir çok şey bulabileceksiniz. Bu kursun içerindeki videolar sizi adfım adım ileriye götürecek.", IsAddHome=true, IsApproval=true, Contents="İçerik bayağı önemli", AddBlogDate=DateTime.Now.AddDays(8), Image="12.jpg", CategoryId=3 },
                new Blog(){Title = "Windows Form Nedir?", Description = "Bu gkusrsun içeriğinde Windows Form 'a dair bir çok şey bulabileceksiniz. Bu kursun içerindeki videolar sizi adfım adım ileriye götürecek.", IsAddHome=true, IsApproval=false, Contents="İçerik bayağı önemli", AddBlogDate=DateTime.Now.AddDays(3), Image="13.jpg", CategoryId=4 },
                new Blog(){Title = "C# Delegate Hakkında", Description = "Bu gkusrsun içeriğinde Windows Form 'a dair bir çok şey bulabileceksiniz. Bu kursun içerindeki videolar sizi adfım adım ileriye götürecek.", IsAddHome=false, IsApproval=true, Contents="İçerik bayağı önemli", AddBlogDate=DateTime.Now.AddDays(-2), Image="14.jpg", CategoryId=4 },
                new Blog(){Title = "Windows Form Önemli mi?", Description = "Bu gkusrsun içeriğinde Windows Form'a dair bir çok şey bulabileceksiniz. Bu kursun içerindeki videolar sizi adfım adım ileriye götürecek.", IsAddHome=true, IsApproval=false, Contents="İçerik bayağı önemli", AddBlogDate=DateTime.Now.AddDays(-3), Image="15.jpg", CategoryId=4 },
                new Blog(){Title = "Windows Form Hakkında", Description = "Bu gkusrsun içeriğinde Windows Form 'a dair bir çok şey bulabileceksiniz. Bu kursun içerindeki videolar sizi adfım adım ileriye götürecek.", IsAddHome=false, IsApproval=true, Contents="İçerik bayağı önemli", AddBlogDate=DateTime.Now.AddDays(7), Image="16.jpg", CategoryId=4 },
            };

            foreach (var blog in blogs)
            {
                context.Blogs.Add(blog);
            }
            context.SaveChanges();

            base.Seed(context);
        }
    }
}