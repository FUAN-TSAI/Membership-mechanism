using System.Web;
using System.Web.Mvc;

namespace WA練習五___會員機制
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
