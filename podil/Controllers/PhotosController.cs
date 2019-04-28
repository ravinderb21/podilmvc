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

            return View("UploadPhotoForm", uploadPhotoViewModel);
        }

        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return HttpNotFound();
            }

            var categoryTypes = Context.CategoryTypes.ToList();
            var photo = Context.Photos
                .Include(p => p.CategoryType)
                .FirstOrDefault(p => p.Id == id);

            var viewModel = new UploadPhotoViewModel(photo)
            {
                CategoryTypes = categoryTypes
            };

            return View("UploadPhotoForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Photo photo, HttpPostedFileBase photoFile)
        {
            if(!ModelState.IsValid)
            {
                var categoryTypes = Context.CategoryTypes.ToList();

                var viewModel = new UploadPhotoViewModel(photo)
                {
                    CategoryTypes = categoryTypes
                };
                return View(viewModel);
            }

            string photoFileName = string.Empty;
            if (photoFile != null)
            {
                // Delete old photo
                if (photo.Id != 0)
                {
                    DeletePhotoFile(photo.FileName);
                }

                // Save the new photo
                string photoFileExtension = Path.GetExtension(photoFile.FileName);
                photoFileName = Convert.ToString(Guid.NewGuid()) + photoFileExtension;
                photo.FileName = photoFileName;

                string photoFullPath = Path.Combine(GetPhotoFolderPath().FullName, photoFileName);
                photoFile.SaveAs(photoFullPath);
            }

            if (photo.Id != 0)
            {
                var photoInDb = Context.Photos.First(p => p.Id == photo.Id);
                photoInDb.CategoryTypeId = photo.CategoryTypeId;
                photoInDb.Description = photo.Description;
                if (!string.IsNullOrEmpty(photoFileName))
                {
                    photoInDb.FileName = photoFileName;
                }
                photo = photoInDb;
            }
            else
            {
                photo.ApplicationUserId = User.Identity.GetUserId();
                photo.DateAdded = DateTime.Now;
                Context.Photos.Add(photo);
            }
            Context.SaveChanges();

            return RedirectToAction("Show", new { id = photo.Id });
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

            return View(photo);
        }

        private void DeletePhotoFile(string fileName)
        { 
            string photoFullPath = Path.Combine(GetPhotoFolderPath().FullName, fileName);
            if (System.IO.File.Exists(photoFullPath))
            {
                System.IO.File.Delete(photoFullPath);
            }
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