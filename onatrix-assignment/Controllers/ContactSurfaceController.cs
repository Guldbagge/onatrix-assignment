﻿using Microsoft.AspNetCore.Mvc;
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
    public class ContactSurfaceController : SurfaceController
    {
        private readonly DataContext _dbContext;

        public ContactSurfaceController(
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
        public IActionResult HandleSubmit(ContactFormModel form)
        {
            if (!ModelState.IsValid)
            {
                ViewData["name"] = form.Name;
                ViewData["email"] = form.Email;
                ViewData["dropdown"] = form.Dropdown;
                ViewData["phone"] = form.Phone;

                ViewData["error_name"] = string.IsNullOrEmpty(form.Name);
                ViewData["error_email"] = string.IsNullOrEmpty(form.Email);
                ViewData["error_dropdown"] = string.IsNullOrEmpty(form.Dropdown);
                ViewData["error_phone"] = string.IsNullOrEmpty(form.Phone);

                return CurrentUmbracoPage();
            }

            var contactFormEntry = new ContactFormEntry
            {
                Name = form.Name,
                Email = form.Email,
                Dropdown = form.Dropdown,
                Phone = form.Phone,
                SubmittedDate = DateTime.Now
            };

            _dbContext.ContactFormEntries.Add(contactFormEntry);
            _dbContext.SaveChanges();

            TempData["success"] = "Form submitted successfully.";
            return RedirectToCurrentUmbracoPage();
        }
    }
}





//using Microsoft.AspNetCore.Mvc;
//using onatrix_assignment.Models;
//using Umbraco.Cms.Core.Cache;
//using Umbraco.Cms.Core.Logging;
//using Umbraco.Cms.Core.Routing;
//using Umbraco.Cms.Core.Services;
//using Umbraco.Cms.Core.Web;
//using Umbraco.Cms.Infrastructure.Persistence;
//using Umbraco.Cms.Web.Website.Controllers;

//namespace onatrix_assignment.Controllers
//{
//    public class ContactSurfaceController : SurfaceController
//    {
//        public ContactSurfaceController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider) : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
//        {
//        }

//        public IActionResult HandleSubmit(ContactFormModel form)
//        {
//            if (!ModelState.IsValid)
//            {
//                ViewData["name"] = form.Name;
//                ViewData["email"] = form.Email;
//                ViewData["dropdown"] = form.Dropdown;
//                ViewData["phone"] = form.Phone;

//                ViewData["error_name"] = string.IsNullOrEmpty(form.Name);
//                ViewData["error_email"] = string.IsNullOrEmpty(form.Email);
//                ViewData["error_dropdown"] = string.IsNullOrEmpty(form.Dropdown);
//                ViewData["error_phone"] = string.IsNullOrEmpty(form.Phone);

//                return CurrentUmbracoPage();
//            }

//            TempData["success"] = "Form submitted successfully.";
//            return RedirectToCurrentUmbracoPage();
//        }


//    }
//}
