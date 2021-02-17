using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Web.Mvc;

namespace MVCDiary.Controllers
{
    public class DiaryController : Controller
    {
        public ActionResult Index()
        {
            using (var sCon = new MySqlConnection(ConfigurationManager.AppSettings["connectionString"]))
            {
                sCon.Open();

                var sqlCom = new MySqlCommand();
                sqlCom.Connection = sCon;
                sqlCom.CommandText = "SELECT * FROM data WHERE _id=@id;";
                sqlCom.Parameters.AddWithValue("@id", Url.RequestContext.RouteData.Values["Id"]);
                sqlCom.CommandType = CommandType.Text;

                using (MySqlDataReader reader = sqlCom.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ViewBag.Title = reader["title"].ToString();
                        ViewBag.Description = reader["description"].ToString();
                        ViewBag.Html = reader["html"].ToString();
                        ViewBag.Date = reader["date"].ToString();

                        return View();
                    }
                }

                sCon.Close();
            }

            return new HttpNotFoundResult();
        }
    }
}