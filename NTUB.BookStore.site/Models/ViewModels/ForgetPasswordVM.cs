using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NTUB.BookStore.site.Models.ViewModels
{
	public class ForgetPasswordVM
	{
        [Display(Name = "帳號")]
        [Required]
        [StringLength(30)]
        public string Account { get; set; }

        [Display(Name = "信箱")]
        [Required]
        [StringLength(256)]
        [EmailAddress]
        public string Email { get; set; }
    }
}