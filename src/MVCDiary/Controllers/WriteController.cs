using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Web.Mvc;

namespace MVCDiary.Controllers
{
    public class WriteController : Controller
    {
        public ActionResult Index()
        {
            if (Convert.ToBoolean(Session["isAuthed"]) == true)
            {
                return View();
            }
            else
            {
                return Redirect("/Login");
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(FormCollection formData)
        {
            using (var sCon = new MySqlConnection(ConfigurationManager.AppSettings["connectionString"]))
            {
                sCon.Open();

                var sqlCom = new MySqlCommand();
                sqlCom.Connection = sCon;
                sqlCom.CommandText = "INSERT INTO data(title, description, html, date) VALUES(@title, @description, @html, @date)";
                sqlCom.CommandType = CommandType.Text;
                sqlCom.Parameters.AddWithValue("@title", formData["title"]);
                sqlCom.Parameters.AddWithValue("@description", formData["description"]);
                sqlCom.Parameters.AddWithValue("@html", formData["text"]);
                sqlCom.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy.M.d HH:mm"));
                sqlCom.ExecuteNonQuery();

                sCon.Close();
            }

            return Redirect("/Post");
        }
    }
}