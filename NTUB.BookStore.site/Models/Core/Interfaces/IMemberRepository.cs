using NTUB.BookStore.site.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NTUB.BookStore.site.Models.Core.Interfaces
{
	public interface IMemberRepository
	{
		bool IsExist(string account);

		void Create(MemberEntity entity);

		MemberEntity Load(int memberId);

		void ActiveRegister(int memberId);	
	}
}