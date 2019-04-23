using podil.Models;
using podil.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace podil.Controllers
{
    [Authorize]
    public class PhotosController : Controller
    {
        private readonly ApplicationDbContext Context;

        public PhotosController()
        {
            Context = new ApplicationDbContext();
        }
        // GET: Photos
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            var categoryTypes = Context.CategoryTypes.ToList();

            var uploadPhotoViewModel = new UploadPhotoViewModel
            {
                CategoryTypes = categoryTypes
            };

            return View(uploadPhotoViewModel);
        }

        public ActionResult Upload(Photo photo)
        {
            photo.ApplicationUserId = User.Identity.GetUserId();

            Context.Photos.Add(photo);
            Context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}