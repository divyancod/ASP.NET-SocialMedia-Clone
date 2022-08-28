using System.Web.Mvc;

namespace BiasedSocialMedia.Web.Areas.BiasedAdmin
{
    public class BiasedAdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "BiasedAdmin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "BiasedAdmin_default",
                "BiasedAdmin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}