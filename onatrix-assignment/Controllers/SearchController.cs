using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Web.Common.Controllers;

using Umbraco.Cms.Core.Logging; // This line is already there
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Models.PublishedContent;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Website.Controllers;
using Umbraco.Cms.Core;


namespace onatrix_assignment.Controllers
{
    public class SearchController : SurfaceController
    {
        private readonly IPublishedContentQuery _contentQuery;
        private readonly IProfilingLogger _logger; // Use IProfilingLogger

        public SearchController(
          IUmbracoContextAccessor umbracoContextAccessor,
          IUmbracoDatabaseFactory databaseFactory,
          ServiceContext services,

          AppCaches appCaches,
          IProfilingLogger
     logger, // Inject IProfilingLogger
          IPublishedUrlProvider publishedUrlProvider,
          IPublishedContentQuery contentQuery)
          : base(umbracoContextAccessor, databaseFactory, services, appCaches, logger, publishedUrlProvider)
        {
            _contentQuery = contentQuery;
            _logger = logger; // Assign IProfilingLogger to a local variable
        }

        [HttpGet("search")]
  public IActionResult Search(string query)
  {
    if (string.IsNullOrWhiteSpace(query))
    {
      return View("SearchResults", null);
    }

    var results = _contentQuery
      .ContentAtRoot()
      .DescendantsOrSelf<IPublishedContent>()
      .Where(x => x.Name.Contains(query))
      .ToList();

    return View("SearchResults", results);
  }
}
}
