using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Cms.Core.Logging; 
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
        private readonly IProfilingLogger _logger; 

        public SearchController(
          IUmbracoContextAccessor umbracoContextAccessor,
          IUmbracoDatabaseFactory databaseFactory,
          ServiceContext services,

          AppCaches appCaches,
          IProfilingLogger logger, 
          IPublishedUrlProvider publishedUrlProvider,
          IPublishedContentQuery contentQuery)
          : base(umbracoContextAccessor, databaseFactory, services, appCaches, logger, publishedUrlProvider)
        {
            _contentQuery = contentQuery;
            _logger = logger; 
        }

        [HttpGet("search")]
        public IActionResult Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return View("SearchResults", null);
            }

            var lowerQuery = query.ToLower(); 

            var results = _contentQuery
                .ContentAtRoot()
                .DescendantsOrSelf<IPublishedContent>()
                .Where(x => x.Name.ToLower().Contains(lowerQuery)) 
                .ToList();

            return View("SearchResults", results);
        }

    }
}
