using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace podil.Models
{
    public class Photo
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        [StringLength(255)]
        public string FileName { get; set; }

        [Display(Name = "Category")]
        public CategoryType CategoryType { get; set; }

        [Required]
        [Display(Name = "Category Type")]
        public byte CategoryTypeId { get; set; }

        public DateTime DateAdded { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public string ApplicationUserId { get; set; }

    }
}