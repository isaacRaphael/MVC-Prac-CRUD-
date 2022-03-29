using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rocky2.Models
{
    public class Category
    {   [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }
        [Required]
        [DisplayName("Display order")]
        [Range(1,int.MaxValue, ErrorMessage ="Display Order must be greater than 0")]
        public int DisplayOrder { get; set; }
       

    }
}
