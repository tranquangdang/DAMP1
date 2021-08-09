using System.Web.Mvc;

namespace QuanLyTiemChung.Areas.QLTCWebsite
{
    public class QLTCWebsiteAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "QLTCWebsite";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "QLTCWebsite_default",
                "QLTCWebsite/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}