using EFCore1.Infra;
using EFCore1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;

namespace EFCore1.Controllers
{
    public class PostController : Controller
    {
        Context context = new Context();

        public ActionResult List(string message = "")
        {
            var models = this.context.Posts.ToList();

            if (!String.IsNullOrEmpty(message))
                ViewBag.Success = message;

            return View(models);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Post model)
        {
            if (!ModelState.IsValid)
                return View(model);

            context.Posts.Add(model, Microsoft.Data.Entity.GraphBehavior.SingleObject);
            context.SaveChanges();

            return RedirectToAction("List", new { message = "Post criado com sucesso!" });

        }

        public ActionResult Edit(int id)
        {
            var post = this.context.Posts.Where(x => x.Id == id).FirstOrDefault();
            return View(post);
        }

        [HttpPost]
        public ActionResult Edit(Post model)
        {
            if (!ModelState.IsValid)
                return View(model);

            context.Posts.Add(model);
            context.Entry<Post>(model).State = Microsoft.Data.Entity.EntityState.Modified;
            context.SaveChanges();

            return RedirectToAction("List", new { message = "Post editado com sucesso!" });

        }

        public ActionResult Delete(int id)
        {
            var post = this.context.Posts.Where(x => x.Id == id).FirstOrDefault();

            this.context.Posts.Remove(post);
            this.context.SaveChanges();

            return RedirectToAction("List", new { message = "Post excluído com sucesso" });
        }

    }
}