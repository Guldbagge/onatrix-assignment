//using Microsoft.AspNetCore.Mvc;
//using onatrix_assignment.Data;
//using onatrix_assignment.Models;
//using System.ComponentModel.DataAnnotations;
//using Umbraco.Cms.Core.Cache;
//using Umbraco.Cms.Core.Logging;
//using Umbraco.Cms.Core.Routing;
//using Umbraco.Cms.Core.Services;
//using Umbraco.Cms.Core.Web;
//using Umbraco.Cms.Infrastructure.Persistence;
//using Umbraco.Cms.Web.Website.Controllers;

//namespace onatrix_assignment.Controllers
//{
//    public class WeHelpSurfaceController : SurfaceController
//    {
//        private readonly DataContext _dbContext;

//        public WeHelpSurfaceController(
//            IUmbracoContextAccessor umbracoContextAccessor,
//            IUmbracoDatabaseFactory databaseFactory,
//            ServiceContext services,
//            AppCaches appCaches,
//            IProfilingLogger profilingLogger,
//            IPublishedUrlProvider publishedUrlProvider,
//            DataContext dbContext)
//            : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
//        {
//            _dbContext = dbContext;
//        }

//        [HttpPost]
//        public IActionResult HandleSubmit(string email)
//        {
//            if (string.IsNullOrWhiteSpace(email) || !new EmailAddressAttribute().IsValid(email))
//            {
//                // Return with error
//                ViewData["error_email"] = "You must enter a valid e-mail address.";
//                return CurrentUmbracoPage();
//            }

//            var weHelpEntry = new WeHelpModel
//            {
//                Email = email,
//                SubmittedDate = DateTime.Now
//            };

//            _dbContext.WeHelpModels.Add(weHelpEntry);
//            _dbContext.SaveChanges();

//			TempData["success"] = "Your e-mail has been submitted successfully.";
//            return RedirectToCurrentUmbracoPage();
//        }
//    }
//}

using Microsoft.AspNetCore.Mvc;
using onatrix_assignment.Data;
using onatrix_assignment.Models;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;

namespace onatrix_assignment.Controllers
{
	public class WeHelpSurfaceController : SurfaceController
	{
		private readonly DataContext _dbContext;

		public WeHelpSurfaceController(
			IUmbracoContextAccessor umbracoContextAccessor,
			IUmbracoDatabaseFactory databaseFactory,
			ServiceContext services,
			AppCaches appCaches,
			IProfilingLogger profilingLogger,
			IPublishedUrlProvider publishedUrlProvider,
			DataContext dbContext)
			: base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
		{
			_dbContext = dbContext;
		}

		[HttpPost]
		public IActionResult HandleSubmit(WeHelpModel form)
		{
			if (!ModelState.IsValid)
			{
				ViewData["error_email"] = "You must enter a valid e-mail address.";

				ViewData["error_email"] = string.IsNullOrEmpty(form.Email);


				return CurrentUmbracoPage();
			}

			var weHelpEntry = new WeHelpModel
			{
				Email = form.Email,
				SubmittedDate = DateTime.Now
			};

			_dbContext.WeHelpModels.Add(weHelpEntry);
			_dbContext.SaveChanges();

			TempData["success"] = "Your e-mail has been submitted successfully.";
			return RedirectToCurrentUmbracoPage();
		}
	}
}
