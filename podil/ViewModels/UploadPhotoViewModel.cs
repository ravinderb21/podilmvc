using podil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace podil.ViewModels
{
    public class UploadPhotoViewModel
    {
        public Photo Photo { get; set; }

        public IEnumerable<CategoryType> CategoryTypes { get; set; }

        public HttpPostedFileBase PhotoFile { get; set; }
    }
}