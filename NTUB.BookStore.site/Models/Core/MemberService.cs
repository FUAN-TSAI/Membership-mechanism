using NTUB.BookStore.site.Models.Core.Interfaces;
using NTUB.BookStore.site.Models.Entities;
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
	}
}