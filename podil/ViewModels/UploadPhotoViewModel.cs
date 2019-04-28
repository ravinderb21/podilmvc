using podil.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace podil.ViewModels
{
    public class UploadPhotoViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        public string FileName { get; set; }

        [Required]
        [Display(Name = "Category Type")]
        public byte CategoryTypeId { get; set; }

        public DateTime DateAdded { get; set; }

        public string ApplicationUserId { get; set; }

        public IEnumerable<CategoryType> CategoryTypes { get; set; }

        [Required]
        [Display(Name = "Photo")]
        [FileExtensions(ErrorMessage = "Please upload a photo.")]
        public HttpPostedFileBase PhotoFile { get; set; }

        public UploadPhotoViewModel()
        {
            Id = 0;
        }

        public UploadPhotoViewModel(Photo photo)
        {
            Id = photo.Id;
            Description = photo.Description;
            FileName = photo.FileName;
            CategoryTypeId = photo.CategoryTypeId;
            DateAdded = photo.DateAdded;
            ApplicationUserId = photo.ApplicationUserId;
        }
    }
}