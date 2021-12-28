using NTUB.BookStore.site.Models.DTOs;
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

        [Required]
        [StringLength(30)]
        public string Account { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [StringLength(256)]
        public string Email { get; set; }

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