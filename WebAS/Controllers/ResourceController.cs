using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAS.Resources;

namespace WebAS.Controllers
{
    [Authorize]
    public class ResourceController : Controller
    {
        // GET: Resource
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetResources()
        {
            return Json(new Dictionary<string, string> {
                {"ApplicationName", Resource.ApplicationName},
                {"Create", Resource.Create},
                {"Edit", Resource.Edit},
                {"Details", Resource.Details},
                {"Delete", Resource.Delete},
                {"LabelLocationId", ModelResource.LocationId},
                {"LabelLatitude", ModelResource.Latitude},
                {"LabelLongitude", ModelResource.Longitude},
                {"LabelAltitude", ModelResource.Altitude},
                {"LabelTitle", ModelResource.Title},
                {"LabelDescription", ModelResource.Description},
                {"ActionLink, CreateNew", ViewResource.ActionLinkCreateNew}
                    
            }, JsonRequestBehavior.AllowGet);
        }
    }
}