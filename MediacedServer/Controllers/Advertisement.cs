using MediacedServer.Model;
using MediacedServer.Prefs;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace MediacedServer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdvertisementController : ControllerBase
    {
        [HttpGet]
        public string GetList()
        {
            Database db = new Database();
            List<Advertisement> advs = new List<Advertisement>();

            SqlConnection conn = new SqlConnection(db.connectionString);
            conn.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM [Mediaced].[dbo].[advertisements]", conn);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Advertisement adv = new Advertisement((int)reader["id"], (string)reader["firstname"],
                                                        (string)reader["lastname"], (string)reader["patronimic"],
                                                        (string)reader["phonenumber"], (string)reader["email"], (int)reader["age"],
                                                        (string)reader["advtext"], Convert.ToSingle(reader["priceusd"]),
                                                        Convert.ToSingle(reader["courseusd"]), Convert.ToSingle(reader["pricebyn"]));

                    advs.Add(adv);
                }
            }


            conn.Close();

            string output = JsonConvert.SerializeObject(advs, Formatting.None);

            HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");

            return output;
        }

        [HttpPost]
        public StatusCodeResult addAdvertisement([FromForm] Advertisement advertisement)
        {
            // HttpContext.Response.Headers.Add("Content-Type", "application/json");

            Database db = new Database();
            SqlConnection conn = new SqlConnection(db.connectionString);
            conn.Open();

            String sqlQuery = $@"INSERT INTO [Mediaced].[dbo].[advertisements]
           ([id]
           ,[firstname]
           ,[lastname]
           ,[patronimic]
           ,[phonenumber]
           ,[email]
           ,[age]
           ,[priceusd]
           ,[courseusd]
           ,[pricebyn]
           ,[advtext])
     VALUES
           ({advertisement.id}
           ,'{advertisement.firstName}'
           ,'{advertisement.lastName}'
           ,'{advertisement.patronimic}'
           ,'{advertisement.phoneNumber}'
           ,'{advertisement.email}'
           ,{advertisement.age}
           ,{advertisement.priceUSD.ToString().Replace(",", ".")}
           ,{advertisement.courseOfUSD.ToString().Replace(",", ".")}
           ,{advertisement.priceBYN.ToString().Replace(",", ".")}
           ,'{advertisement.advText}')";

            SqlCommand command = new SqlCommand(sqlQuery, conn);
            try
            {
                command.ExecuteNonQuery();
                return StatusCode(200);

            }
            catch
            {
                return StatusCode(500);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
