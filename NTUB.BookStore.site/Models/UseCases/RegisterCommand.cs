using NTUB.BookStore.site.Models.Core;
using NTUB.BookStore.site.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NTUB.BookStore.site.Models.UseCases
{
	public class RegisterCommand
	{
		public RegisterResponse Execute(RegisterVM model)
		{
			var service = new MemberService();

			RegisterRequest request = model.ToRequest();

			RegisterResponse response = service.CreateNewMember(request);

			if(response.IsSuccess == true)
			{
				//todo send email
			}
			return response;
		}
	
	}
}