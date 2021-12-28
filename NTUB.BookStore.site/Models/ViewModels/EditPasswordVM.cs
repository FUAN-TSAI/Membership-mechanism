using NTUB.BookStore.site.Models.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NTUB.BookStore.site.Models.ViewModels
{
	public class EditPasswordVM
	{
		[Display(Name = "原始密碼")]
		[Required]
		[StringLength(70)]
		[DataType(DataType.Password)]
		public string OriginalPassward { get; set; }

		[Display(Name = "新密碼")]
		[Required]
		[StringLength(70)]
		[DataType(DataType.Password)]
		public string Passward { get; set; }

		[Display(Name = "確認新密碼")]
		[Required]
		[StringLength(70)]
		[Compare (nameof(Passward))]
		[DataType(DataType.Password)]
		public string ConfirmPassward { get; set; }
	}

	public static class EditPasswordVMExts
	{
		public static ChangePasswordRequest ToRequest(this EditPasswordVM source,string userAccount)
		{
			return new ChangePasswordRequest
			{
				CurrentUserAccount = userAccount,
				OriginalPassword = source.OriginalPassward,
				NewPassword = source.Passward
			};
		}
	}
}