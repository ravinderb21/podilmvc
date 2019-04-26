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
        public Photo Photo { get; set; }

        public IEnumerable<CategoryType> CategoryTypes { get; set; }

        [Required]
        [Display(Name = "Photo")]
        [FileExtensions(ErrorMessage = "Please upload a photo.")]
        public HttpPostedFileBase PhotoFile { get; set; }
    }
}