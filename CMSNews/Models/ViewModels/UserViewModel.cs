using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using CMSNews.Models.Models;

namespace CMSNews.Models.ViewModels
{
    public class UserViewModel
    {
        [Display(Name ="کد کاربر")]
        public int UserId { get; set; }
        [Required]
        [MaxLength(15)]
        [Display(Name = "موبایل (نام کاربری)")]
        public string MobileNumber { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "رمز عبور")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "تاریخ ثبت کاربر")]
        public DateTime RegisterDate { get; set; }
        [Display(Name = "وضعیت کاربر")]
        public bool IsActive { get; set; }

        public virtual ICollection<News> Newses { get; set; }
    }
}