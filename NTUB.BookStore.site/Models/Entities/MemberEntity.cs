using NTUB.BookStore.site.Models.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NTUB.BookStore.site.Models.Entities
{
	public class MemberEntity
	{
        public int Id { get; set; }

         public string Account { get; set; }

        public string Password { get; set; }

		public string EncryptedPassword //編碼的密碼
		{
			get
			{
				string salt = "!@#$%%$#@SFGG";
				string result = HashUtility.ToSHA256(this.Password, salt);
				return result;
			}
		}

		public string Name { get; set; }

         public string Email { get; set; }

        public string Mobile { get; set; }

        public bool IsConfirmed { get; set; }

       public string ConfirmCode { get; set; }
    }
}