﻿using NTUB.BookStore.site.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NTUB.BookStore.site.Models.Core.Interfaces
{
	public interface IMemberRepository
	{
		bool IsExist(string account);
		bool IsExist(string account,int excludeId);
		void Create(MemberEntity entity);

		MemberEntity Load(int memberId);
		MemberEntity Load(string account);

		void ActiveRegister(int memberId);	
		void Update(MemberEntity entity);
	}
}