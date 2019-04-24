using podil.Models;
using podil.ViewModels;
using System;
using System.Collections.Generic;
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

        public ActionResult Upload(Photo photo, HttpPostedFileBase photoFile)
        {
            string photoFileExtension = Path.GetExtension(photoFile.FileName);
            string photoFileName = Convert.ToString(Guid.NewGuid()) + photoFileExtension;
            string photoFullPath = Path.Combine(GetPhotoFolderPath().FullName, photoFileName);
            photoFile.SaveAs(photoFullPath);

            photo.ApplicationUserId = User.Identity.GetUserId();
            photo.FileName = photoFileName;

            Context.Photos.Add(photo);
            Context.SaveChanges();

            return RedirectToAction("Index");
        }

        private DirectoryInfo GetPhotoFolderPath()
        {
            try
            {
                return Directory.CreateDirectory(Server.MapPath(PhotosFolderPath));
            }
            catch
            {
                throw;
            }
        }
    }
}