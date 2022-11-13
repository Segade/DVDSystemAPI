using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using Microsoft.Extensions.Configuration;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DVDSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DVDController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public DVDController(IConfiguration configuration)
        {
            _configuration = configuration;

        } // end dvd controller configuration 


        // GET: api/<DVDController>
        [HttpGet]
         
        public JsonResult get()
        {
            string query = @"SELECT * FROM DVDs";

            DataTable mytable = new DataTable();
            String sqlDataSource = _configuration.GetConnectionString("appcon");
            MySqlDataReader myresult;

            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();

                using (MySqlCommand mycommand = new MySqlCommand(query, mycon))
                {
                    myresult = mycommand.ExecuteReader();
                    mytable.Load(myresult);
                    myresult.Close();
                    mycon.Close();
                } // end using my sql 
            } // end using 
            return new JsonResult(mytable);
        } // end get 



        // GET api/<DVDController>/5
         [HttpGet("{title}")]
        public JsonResult Get(String title)
        {
            string query = @"SELECT * FROM DVDs WHERE Title LIKE '" + title + "%'";

            DataTable mytable = new DataTable();
            String sqlDataSource = _configuration.GetConnectionString("appcon");
            MySqlDataReader myresult;

            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();

                using (MySqlCommand mycommand = new MySqlCommand(query, mycon))
                {
                    myresult = mycommand.ExecuteReader();
                    mytable.Load(myresult);
                    myresult.Close();
                    mycon.Close();
                } // end using my sql 
            } // end using 
            return new JsonResult(mytable);

        } // end get with argument

        // POST api/<DVDController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DVDController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DVDController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    } // end class 
}
