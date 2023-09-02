using crudMvc.Context;
using crudMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace crudMvc.Controllers
{
    public class PostController : Controller
    {
        private readonly PostContext context;
        public PostController(PostContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var post = context.Posts.ToList();
            return View(post);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Post model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            context.Posts.Add(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var post = context.Posts.Find(id);
            if (post == null)
            {
                return NotFound(); 
            }

            context.Posts.Remove(post);
            context.SaveChanges();

            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Detail(int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var post = context.Posts.Find(id);
            if (post == null)
            {
                return NotFound();
            }



            return View(post);
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(int id, Post model)
        {
            var post=context.Posts.FirstOrDefault(x=>x.Id==id);
            if (post == null)
            {
                return BadRequest();
            }
            post.Id = model.Id;
            post.Image=model.Image;
            post.Title=model.Title;
            post.Body=model.Body;
            context.Posts.Update(post);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}
