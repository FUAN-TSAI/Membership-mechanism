using System;
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

	public class EmailHelper
	{
		public void SendForgetPasswordEmail(string url, string name, string email)
		{
			string subject = "[重設密碼通知]";
			string body = $@"Hi {name},
<br />
請點擊此連結 [<a href='{url}' target='_blank'>我要重設密碼</a>], 以進行重設密碼, 如果您沒有提出申請, 請忽略本信, 謝謝";

			string from = "g01.webapp@gmail.com";
			string to = email;

			SendFromGmail(from, to, subject, body);
		}

		public void SendConfirmRegisterEmail(string url, string name, string email)
		{
			string subject = "[新會員確認信]";
			string body = $@"Hi {name},
<br />
請點擊此連結 [<a href='{url}' target='_blank'>的確是我申請會員</a>], 如果您沒有提出申請, 請忽略本信, 謝謝";

			string from = "g01.webapp@gmail.com";
			string to = email;

			SendFromGmail(from, to, subject, body);
		}

		public virtual void SendFromGmail(string from, string to, string subject, string body)
		{
			// ref https://dotblogs.com.tw/chichiblog/2018/04/20/122816
			string smtpAccount = from;
			string smtpPassword = "請在這裡填入密碼,或從web.config裡讀取";

			string SmtpServer = "smtp.gmail.com";
			int SmtpPort = 587;

			MailMessage mms = new MailMessage();
			mms.From = new MailAddress(smtpAccount);
			mms.Subject = subject;
			mms.Body = body;
			mms.IsBodyHtml = true;
			mms.SubjectEncoding = Encoding.UTF8;
			mms.To.Add(new MailAddress(to));


			using (SmtpClient client = new SmtpClient(SmtpServer, SmtpPort))
			{
				client.EnableSsl = true;
				client.Credentials = new NetworkCredential(smtpAccount, smtpPassword);//寄信帳密
				client.Send(mms); //寄出信件
			}
		}
	}
}