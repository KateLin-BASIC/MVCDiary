using MySql.Data.MySqlClient;
using PagedList;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace MVCDiary.Controllers
{
    public class PostController : Controller
    {
        public ActionResult Index(int? page)
        {
            List<Models.DiaryData> diaryData = new List<Models.DiaryData>();

            using (var sCon = new MySqlConnection(ConfigurationManager.AppSettings["connectionString"]))
            {
                sCon.Open();

                var sqlCom = new MySqlCommand();
                sqlCom.Connection = sCon;
                sqlCom.CommandText = "SELECT * FROM data ORDER BY _id DESC;";
                sqlCom.CommandType = CommandType.Text;

                using (MySqlDataReader reader = sqlCom.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        diaryData.Add(new Models.DiaryData()
                        {
                            Id = Convert.ToInt32(reader["_id"]),
                            Title = reader["title"].ToString(),
                            Description = reader["description"].ToString(),
                            Html = reader["html"].ToString(),
                            Date = reader["date"].ToString()
                        });
                    }

                    var posts = diaryData.AsQueryable();

                    var pageNumber = page ?? 1;
                    var postsData = posts.ToPagedList(pageNumber, 10);

                    ViewBag.postsData = postsData;
                }

                sCon.Close();
            }

            return View();
        }
    }
}