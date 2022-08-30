using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using CMSNews.Models.Models;

namespace CMSNews.Models.ViewModels
{
    public class NewsGroupViewModel
    {
        [Display(Name="کد گروه خبری")]
        public int NewsGroupId { get; set; }
        [Required]
        [MaxLength(200)]
        [Display(Name = "عنوان گروه خبری")]
        public string NewsGroupTitle { get; set; }
        [MaxLength(100)]
        [Display(Name = "تصویر")]
        public string ImageName { get; set; }

        public virtual ICollection<News> News { get; set; }
    }
}