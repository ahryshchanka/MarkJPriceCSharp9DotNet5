using MarkJPriceCSharp9DotNet5.Ch17_0.Models;
using Microsoft.AspNetCore.Mvc;
using Piranha;
using Piranha.AspNetCore.Services;
using Piranha.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MarkJPriceCSharp9DotNet5.Ch17_0.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class CmsController : Controller
    {
        private readonly IApi _api;
        private readonly IModelLoader _loader;

        public CmsController(IApi api, IModelLoader loader)
        {
            _api = api;
            _loader = loader;
        }

        [Route("archive")]
        public async Task<IActionResult> Archive(Guid id, int? year = null, int? month = null, int? page = null, Guid? category = null, Guid? tag = null, bool draft = false)
        {
            try
            {
                var model = await _loader.GetPageAsync<StandardArchive>(id, HttpContext.User, draft);
                model.Archive = await _api.Archives.GetByIdAsync<PostInfo>(id, page, category, tag, year, month);

                return View(model);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
        }

        [Route("page")]
        public async Task<IActionResult> Page(Guid id, bool draft = false)
        {
            try
            {
                var model = await _loader.GetPageAsync<StandardPage>(id, HttpContext.User, draft);

                return View(model);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
        }

        [Route("post")]
        public async Task<IActionResult> Post(Guid id, bool draft = false)
        {
            try
            {
                var model = await _loader.GetPostAsync<StandardPost>(id, HttpContext.User, draft);

                if (model.IsCommentsOpen)
                {
                    model.Comments = await _api.Posts.GetAllCommentsAsync(model.Id);
                }

                return View(model);
            }
            catch
            {
                return Unauthorized();
            }
        }

        [HttpPost]
        [Route("post/comment")]
        public async Task<IActionResult> SavePostComment(SaveCommentModel commentModel)
        {
            try
            {
                var model = await _loader.GetPostAsync<StandardPost>(commentModel.Id, HttpContext.User);

                var comment = new Comment
                {
                    IpAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                    UserAgent =
                        Request.Headers.ContainsKey("User-Agent") ? Request.Headers["User-Agent"].ToString() : "",
                    Author = commentModel.CommentAuthor,
                    Email = commentModel.CommentEmail,
                    Url = commentModel.CommentUrl,
                    Body = commentModel.CommentBody
                };
                await _api.Posts.SaveCommentAndVerifyAsync(commentModel.Id, comment);

                return Redirect(model.Permalink + "#comments");
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
        }

        [Route("catalog")]
        public async Task<IActionResult> Catalog(Guid id)
        {
            var catalog = await _api.Pages.GetByIdAsync<CatalogPage>(id);
            var sitemap = await _api.Sites.GetSitemapAsync();

            var model = new CatalogViewModel
            {
                CatalogPage = catalog,
                Categories = sitemap
                    .Where(x => x.Id == catalog.Id)
                    .SelectMany(x => x.Items)
                    .Select(x =>
                    {
                        var page = _api.Pages.GetByIdAsync<CategoryPage>(x.Id).Result;

                        return new CategoryItem
                        {
                            Title = page.Title,
                            Description = page.CategoryDetail.Description,
                            PageUrl = page.Permalink,
                            ImageUrl = page.CategoryDetail.CategoryImage.Resize(_api, 200)
                        };
                    })
            };

            return View(model);
        }

        [Route("catalog-category")]
        public async Task<IActionResult> Category(Guid id)
        {
            var model = await _api.Pages.GetByIdAsync<CategoryPage>(id);
            return View(model);
        }
    }
}