﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NTUB.BookStore.site.Models.ViewModels
{
	public class LoginVM
	{
        [Display(Name = "帳號")]
        [Required]
        public string Account { get; set; }

        [Display(Name = "密碼")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}