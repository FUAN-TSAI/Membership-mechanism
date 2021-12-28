using NTUB.BookStore.site.Models.Core.Interfaces;
using NTUB.BookStore.site.Models.DTOs;
using NTUB.BookStore.site.Models.EFModels;
using NTUB.BookStore.site.Models.Entities;
using NTUB.BookStore.site.Models.Infrastructures;
using NTUB.BookStore.site.Models.Infrastructures.Repositories;
using NTUB.BookStore.site.Models.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NTUB.BookStore.site.Models.Core
{
	public class MemberService
	{
		private readonly IMemberRepository repository;
		public MemberService()
		{
			this.repository = new MemberRepository();
		}
		public MemberService(IMemberRepository repo)//如果要寫單元測試可用
		{
			this.repository = repo;
		}

		public RegisterResponse CreateNewMember(RegisterRequest request)
		{
			//todo判斷各欄位是否正確

			//判斷帳號是否存在
			if (repository.IsExist(request.Account))
			{
				return new RegisterResponse { IsSuccess = false, ErrorMessage = "帳號已經存在" };
			}

			//真正地建立一個會員
			string confirmCode = Guid.NewGuid().ToString("N");

			MemberEntity entity = new MemberEntity
			{
				Account = request.Account,
				Password = request.Password,
				Email = request.Email,
				Name = request.Name,
				Mobile = request.Mobile,
				IsConfirmed = false,
				ConfirmCode = confirmCode,
			};
			repository.Create(entity);

			return new RegisterResponse { IsSuccess = true, 
											Data = new RegisterEntity { 
													Name = request.Name, 
													Email = request.Email, 
													ConfirmCode = confirmCode } 
										};
		}

		public void ActiveRegister(int memberId,string confirnCode)
		{
			MemberEntity entity = repository.Load(memberId);
			if (entity == null) return;

			if (string.Compare(entity.ConfirmCode,confirnCode) != 0) return;

			repository.ActiveRegister(memberId);

		}

		public LoginResponse Login(string account,string password)
		{
			MemberEntity member = repository.Load(account);
			if(member == null)
			{
				return LoginResponse.Fail("帳密有誤");
			}
			if(member.IsConfirmed == false)
			{
				return LoginResponse.Fail("會員資格尚未確認");
			}
			string encryptedPwd = HashUtility.ToSHA256(password, MemberEntity.SALT);
			return (string.CompareOrdinal(member.Password, encryptedPwd) == 0)
				? LoginResponse.Success()
				: LoginResponse.Fail("帳密有誤");
		}

		public void UpdateProfile(UpdateProfileRequest request)
		{
			// todo 驗證傳入的屬性值是否正確

			//取得在db裡的原始紀錄
			MemberEntity entity = repository.Load(request.CurrentUserAccount);
			if (entity == null) throw new Exception("找不到要修改的會員紀錄");

			//判斷新帳號是否被別人使用過了
			bool isExists = repository.IsExist(request.Account, entity.Id);
			if (isExists) throw new Exception("帳號被別人使用了，無法變更");

			//更新紀錄
			entity.Name=request.Name;
			entity.Email=request.Email;
			entity.Mobile=request.Mobile;
			entity.Account=request.Account;

			repository.Update(entity);

		}
	}
}