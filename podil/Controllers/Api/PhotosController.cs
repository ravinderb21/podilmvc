using podil.Helpers;
using podil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace podil.Controllers.Api
{
    public class PhotosController : ApiController
    {
        private readonly ApplicationDbContext Context;

        public PhotosController()
        {
            Context = new ApplicationDbContext();
        }

        // Get /api/photos
        [HttpGet]
        public IEnumerable<Photo> GetPhotos()
        {
            return Context.Photos.ToList();
        }

        // Get /api/photo/{id}
        [HttpGet]
        public Photo GetPhoto(int id)
        {
            var photo = Context.Photos.SingleOrDefault(p => p.Id == id);

            if (photo == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return photo;
        }

        // Post /api/photos
        [HttpPost]
        public Photo CreatePhoto(Photo photo)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            Context.Photos.Add(photo);
            Context.SaveChanges();

            return photo;
        }

        // Put /api/photos/{id}
        [HttpPut]
        public void UpdatePhoto(int id, Photo photo)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var photoInDb = Context.Photos.SingleOrDefault(p => p.Id == id);

            if (photoInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            photoInDb.Description = photo.Description;
            photoInDb.CategoryTypeId = photo.CategoryTypeId;
            photoInDb.FileName = photo.FileName;

            Context.SaveChanges();
        }

        //DELETE /api/photos/{id}
        [HttpDelete]
        public void DeletePhoto(int id)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var photoInDb = Context.Photos.SingleOrDefault(p => p.Id == id);


            if (photoInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            FileHandler.DeletePhotoFile(photoInDb.FileName);

            Context.Photos.Remove(photoInDb);
            Context.SaveChanges();
        }
    }
}
