using podil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace podil.ViewModels
{
    public class UserPhotosViewModel
    {
        public ApplicationUser ApplicationUser { get; set; }

        public IEnumerable<Photo> Photos { get; set; }
    }
}