using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NTUB.BookStore.site.Models.Entities
{
	public class RegisterEntity
	{
		public string Name { get; set; }
		public string Email { get; set; }
		public string ConfirmCode { get; set; }

	}
}