using System.Web;
using System.Web.Mvc;

namespace _11_CS_Numbers
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
