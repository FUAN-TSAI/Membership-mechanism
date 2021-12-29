using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NTUB.BookStore.site.Models.ViewModels
{
	public class ResetPasswordVM
	{
		[Display(Name = "新密碼")]
		[Required]
		[StringLength(70)]
		[DataType(DataType.Password)]
		public string Passward { get; set; }

		[Display(Name = "確認新密碼")]
		[Required]
		[StringLength(70)]
		[Compare(nameof(Passward))]
		[DataType(DataType.Password)]
		public string ConfirmPassward { get; set; }
	}
}