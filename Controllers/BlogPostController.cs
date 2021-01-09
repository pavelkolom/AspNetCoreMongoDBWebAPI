using BlogPostApi.Models;
using BlogPostApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlogPostApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly BlogPostService _blogPostService;

        public BlogPostController(BlogPostService blogPostService)
        {
      _blogPostService = blogPostService;
        }

        [HttpGet]
        public ActionResult<List<BlogPost>> Get() =>
            _blogPostService.Get();

        [HttpGet("{id:length(24)}", Name = "GetBook")]
        public ActionResult<BlogPost> Get(string id)
        {
            var book = _blogPostService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public ActionResult<BlogPost> Create(BlogPost book)
        {
      _blogPostService.Create(book);

            return CreatedAtRoute("GetBook", new { id = book.Id.ToString() }, book);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, BlogPost bookIn)
        {
            var book = _blogPostService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

      _blogPostService.Update(id, bookIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var blogPost = _blogPostService.Get(id);

            if (blogPost == null)
            {
                return NotFound();
            }

      _blogPostService.Remove(blogPost.Id);

            return NoContent();
        }
    }
}
