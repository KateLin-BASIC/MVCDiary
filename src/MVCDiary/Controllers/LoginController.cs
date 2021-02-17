using System;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;

namespace MVCDiary.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            if (Convert.ToBoolean(Session["isAuthed"]) == true)
            {
                ViewBag.WelcomeMessage = "환영합니다, root";
                ViewBag.OtherMessage = "무엇을 도와드릴까요?";
            }
            else
            {
                ViewBag.WelcomeMessage = "정상적으로 인증되지 않은 사용자입니다.";
                ViewBag.OtherMessage = "로그인 페이지로 돌아가십시오.";
            }

            return View(new Models.UserData());
        }

        [HttpPost]
        public ActionResult Index(Models.UserData User)
        {
            if (User.Name == "root" && SHA256Hash(User.Password) == "")
            {
                Session["isAuthed"] = true;

                ViewBag.WelcomeMessage = "환영합니다, root";
                ViewBag.OtherMessage = "무엇을 도와드릴까요?";
            }

            return View(new Models.UserData());
        }

        public string SHA256Hash(string data)
        {
            SHA256 sha = new SHA256Managed();
            byte[] hash = sha.ComputeHash(Encoding.ASCII.GetBytes(data));
            StringBuilder stringBuilder = new StringBuilder();
            foreach (byte b in hash)
            {
                stringBuilder.AppendFormat("{0:x2}", b);
            }
            return stringBuilder.ToString();
        }
    }
}