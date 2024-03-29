﻿using NTUB.BookStore.site.Models.DTOs;
using NTUB.BookStore.site.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NTUB.BookStore.site.Models.ViewModels
{
	public class EditProfileVM
	{
        public int Id { get; set; }

        [Display(Name = "帳號")]
        [Required]
        [StringLength(30)]
        public string Account { get; set; }

        [Display(Name = "姓名")]
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Display(Name = "信箱")]
        [Required]
        [StringLength(256)]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "電話")]
        [StringLength(10)]
        public string Mobile { get; set; }
    }

	public static class MemberEntityExts
	{
		public static EditProfileVM ToEditProfileVM(this MemberEntity source)
		{
            return new EditProfileVM
            {
                Id = source.Id,
                Account = source.Account,
                Name = source.Name,
                Email = source.Email,
                Mobile = source.Mobile,
            };
		}

        public static UpdateProfileRequest ToRequest(this EditProfileVM source, string currentUserAccount)
        {
            return new UpdateProfileRequest
            {
                CurrentUserAccount = currentUserAccount,
                Account = source.Account,
                Email = source.Email,
                Name = source.Name,
                Mobile = source.Mobile,
            };
        }
    }

	
}