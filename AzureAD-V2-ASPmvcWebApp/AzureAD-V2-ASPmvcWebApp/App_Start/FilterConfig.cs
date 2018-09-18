using System.Web;
using System.Web.Mvc;

namespace AzureAD_V2_ASPmvcWebApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
