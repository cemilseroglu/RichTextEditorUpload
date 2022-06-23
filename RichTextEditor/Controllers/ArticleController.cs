using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using RichTextEditor.Models;
using System.IO;

namespace RichTextEditor.Controllers
{
    public class ArticleController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment hostingEnvironment;
        public ArticleController(AppDbContext db,IWebHostEnvironment hostingEnvironment)
        {
            _db = db;
            this.hostingEnvironment = hostingEnvironment;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ArticleList()
        {
            var articles = _db.Article.ToList();
            return View(articles);
        }

        [HttpPost]
        public ActionResult SaveCkeditor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveArticle(ArticleViewModel vm)
        {
            Article article = new Article();
            article.Title = vm.Title;
            article.Content = vm.Content;
            _db.Add(article);
            _db.SaveChanges();
            return RedirectToAction("ArticleList");
        }

        [HttpPost]
        public ActionResult UploadImage(List<IFormFile> files)
        {
            var filepath = "";
            foreach (IFormFile photo in Request.Form.Files)
            {
                string serverMapPath = Path.Combine(hostingEnvironment.WebRootPath, "Image", photo.FileName);
                using (var stream = new FileStream(serverMapPath, FileMode.Create))
                {
                    photo.CopyTo(stream);
                }
                filepath = "https://localhost:7177/" + "Image/" + photo.FileName;
            }

            return Json(new {url = filepath});
        }
    }
}
