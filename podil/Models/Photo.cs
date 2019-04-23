using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace podil.Models
{
    public class Photo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CategoryType CategoryType { get; set; }

        public byte CategoryTypeId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public string ApplicationUserId { get; set; }

    }
}