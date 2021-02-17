using System;
using System.Web.Mvc;

namespace MVCDiary.Controllers
{
    public class ApiController : Controller
    {
        public ActionResult Index()
        {
            if (Convert.ToBoolean(Session["isAuthed"]) == false)
            {
                HttpContext.Response.StatusCode = 401;
                return Content("Unauthorized");
            }
            else
            {
                HttpContext.Response.StatusCode = 404;
                return Content("Not Found");
            }
        }

        public ActionResult logout()
        {
            if (Convert.ToBoolean(Session["isAuthed"]) == false)
            {
                HttpContext.Response.StatusCode = 401;
                return Content("Unauthorized");
            }
            else
            {
                if (HttpContext.Request.HttpMethod == "POST")
                {
                    Session["isAuthed"] = false;
                    return Content("OK");
                }
                else
                {
                    HttpContext.Response.StatusCode = 401;
                    return Content("Unauthorized");
                }
            }
        }
    }
}