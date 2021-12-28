using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NTUB.BookStore.site.Models.DTOs
{
	public class UpdateProfileRequest
	{
		public string CurrentUserAccount { get; set; }
		public string Account { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }
    }
}