﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace NTUB.BookStore.site.Models.Infrastructures
{
	public static class HashUtility
	{
		public static string ToSHA256(string plainText, string salt)
		{
			//ref https://docs.microsoft.com/zh-tw/dotnet/api/system.security.cryptography.sha256?view=net-6.0

			using (SHA256 mySHA256 = SHA256.Create())
			{
				var passwordBytes = Encoding.UTF8.GetBytes(plainText + salt);
				var hash = mySHA256.ComputeHash(passwordBytes);
				StringBuilder sb = new StringBuilder();
				foreach (var b in hash)
				{
					sb.Append(b.ToString("X2"));
				}
				return sb.ToString();
			}
		}
	}
}