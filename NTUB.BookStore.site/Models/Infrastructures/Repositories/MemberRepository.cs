using NTUB.BookStore.site.Models.Core.Interfaces;
using NTUB.BookStore.site.Models.EFModels;
using NTUB.BookStore.site.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NTUB.BookStore.site.Models.Infrastructures.Repositories
{
	public class MemberRepository : IMemberRepository
	{
		private AppDbContext db = new AppDbContext();

		public void ActiveRegister(int memberId)
		{
			var member = db.Members.Find(memberId); //Load(memberId)
			member.IsConfirmed = true;
			member.ConfirmCode = null;
			db.SaveChanges();
		}

		/// <summary>
		/// 不會更新密碼欄位(更新密碼另外寫)
		/// </summary>
		/// <param name="entity"></param>
		public void Update(MemberEntity entity)
		{
			var member = db.Members.Find(entity.Id);

			member.Account = entity.Account;
			member.Email = entity.Email;
			member.Name = entity.Name;
			member.Mobile = entity.Mobile;
			member.IsConfirmed = entity.IsConfirmed;
			member.ConfirmCode = entity.ConfirmCode;

			db.SaveChanges();
		}
		public void Create(MemberEntity entity)
		{
			Member member = new Member
			{
				Account = entity.Account,
				Password = entity.EncryptedPassword, //entity.
				Email = entity.Email,
				Name = entity.Name,
				Mobile = entity.Mobile,
				IsConfirmed = entity.IsConfirmed,
				ConfirmCode = entity.ConfirmCode
			};
			db.Members.Add(member);
			db.SaveChanges();
		}

		public bool IsExist(string account)
		{
			var entity =db.Members.SingleOrDefault(x =>x.Account == account);
			if(entity == null)
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		public bool IsExist(string account, int excludeId)
		{
			var entity = db.Members.SingleOrDefault(x => x.Id!=excludeId&& x.Account == account);
			return entity != null; //帳號別人已使用過，已經存在
		}

		public MemberEntity Load(int memberId)
		{
			return db.Members
				.SingleOrDefault(x =>x.Id == memberId)
				.ToEntity();

			//Member entity = db.Members.SingleOrDefault(x =>x.Id == memberId);
			//MemberEntity result = new MemberEntity
			//{
			//	Id = entity.Id,
			//	Account = entity.Account,
			//	Password = entity.Password,
			//	Email = entity.Email,
			//	Name = entity.Name,
			//	Mobile = entity.Mobile,
			//	IsConfirmed = entity.IsConfirmed,
			//	ConfirmCode = entity.ConfirmCode
			//};
			//return result;
		}

		public MemberEntity Load(string account)
		{
			return db.Members
				.SingleOrDefault(x => x.Account == account)
				.ToEntity();
		}

		
	}

	

}