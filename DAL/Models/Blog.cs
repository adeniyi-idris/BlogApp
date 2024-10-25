using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }

        [Required(ErrorMessage ="Title is required")]
        [StringLength(30, MinimumLength =4)]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage ="Drop a rating")]
        public int Rating { get; set; } 

        //public string? Image {  get; set; }

        public List<Post> Post{ get; set; }
    }
}

