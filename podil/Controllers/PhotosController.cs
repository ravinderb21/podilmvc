using podil.Models;
using podil.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.IO;
using System.Web.Configuration;

namespace podil.Controllers
{
    [Authorize]
    public class PhotosController : Controller
    {
        private readonly ApplicationDbContext Context;

        private readonly string PhotosFolderPath = WebConfigurationManager.AppSettings["PhotosFolderPath"];

        public PhotosController()
        {
            Context = new ApplicationDbContext();
        }
        // GET: Photos
        public ActionResult Index()
        {
            string appUserId = User.Identity.GetUserId();

            var photos = Context.Photos
                .Include(p => p.CategoryType)
                .Where(p => p.ApplicationUserId.Contains(appUserId)).ToList();

            return View(photos);
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

        public ActionResult Upload(Photo photo, HttpPostedFileBase photoFile)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new UploadPhotoViewModel
                {
                    Photo = photo
                };
                return View(viewModel);
            }
            string photoFileExtension = Path.GetExtension(photoFile.FileName);
            string photoFileName = Convert.ToString(Guid.NewGuid()) + photoFileExtension;
            string photoFullPath = Path.Combine(GetPhotoFolderPath().FullName, photoFileName);
            photoFile.SaveAs(photoFullPath);

            photo.ApplicationUserId = User.Identity.GetUserId();
            photo.FileName = photoFileName;

            Context.Photos.Add(photo);
            Context.SaveChanges();

            return RedirectToAction("Show", photo.Id);
        }

        public ActionResult Show(int id)
        {
            if (id == 0)
            {
                return HttpNotFound();
            }
            var photo = Context.Photos
                .Include(p => p.CategoryType)
                .First(p => p.Id == id);

            return View("Show", photo);
        }

        private DirectoryInfo GetPhotoFolderPath()
        {
            try
            {
                return Directory.CreateDirectory(System.Web.Hosting.HostingEnvironment.MapPath(PhotosFolderPath));
            }
            catch
            {
                throw;
            }
        }
    }
}