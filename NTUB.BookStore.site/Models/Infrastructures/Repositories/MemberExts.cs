using NTUB.BookStore.site.Models.EFModels;
using NTUB.BookStore.site.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NTUB.BookStore.site.Models.Infrastructures.Repositories
{
	public static class MemberExts    //寫成擴充方法
	{
		public static MemberEntity ToEntity(this Member entity)
		{
			if (entity == null) return null;

			return new MemberEntity
			{
				Id = entity.Id,
				Account = entity.Account,
				Password = entity.Password,
				Email = entity.Email,
				Name = entity.Name,
				Mobile = entity.Mobile,
				IsConfirmed = entity.IsConfirmed,
				ConfirmCode = entity.ConfirmCode
			};
		}
	}
}