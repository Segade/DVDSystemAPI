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
    public class MemberController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public MemberController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        /*
        public static async Task Main(String[] args) {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                Database = "ivan",
                UserID = "root",
                Password = ""
                
            };
            using (var conn = new MySqlConnection(builder.ConnectionString))
            {
                Console.WriteLine("Opening connection");
                await conn.OpenAsync();
                if (conn.Ping())
                    Console.WriteLine("ping ok");
                else Console.WriteLine("no connection");
            }
            Console.WriteLine("hello");
         } 
        */

       

    // end main
    
        // GET: api/<MemberController>


        [HttpGet]
        public JsonResult Get()
        {
            String query = @"select * from members";
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

                }
            }
            return new JsonResult(mytable);
        } // end get 


        // GET api/<MemberController>/5
           [HttpGet("{email}")]

        public JsonResult Get(String email)
        {
            String query = @"select * from members where email like '%" + email + "%'";
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

                }
            }
            return new JsonResult(mytable);
        }  // end get id 

        // GET api/<MemberController>/5
        [HttpGet("{email}/{password}")]

public JsonResult Login(String email, String password)
        {
            String query = @"select * from members where email = '" + email + "' AND password = '" + password + "'";
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

                }
            }
            return new JsonResult(mytable);

        } // end log in

        // POST api/<MemberController>
        [HttpPost]
        public JsonResult Post(Member member)
        {

            //  Member aMmeber = new Member("padraic", "moriarty", "hello", "kjkjk", "88", "ejkj@jij", "hjhh", "hjhjhjh", "jijk", "jj");
            //  String[] myData = {"padraic", "moriarty", "hello", "kjkjk", "88", "ejkj@jij", "hjhh", "hjhjhjh", "jijk", "jj" };
            //string query = @"insert into members (Forename, Lastname, Password, Eircode, Phone, Email, DOB, CardDetails, ExpiredDate,CVV) values(@Forename, @Lastname, @Password, @Eircode, @Phone, @Email, @DOB, @CardDetails, @ExpiredDate, @CVV)";
            string fname = member.firstname;
            string lname = member.lastname;
            string pword = member.password;
            string ecode = member.eircode;
            string phone = member.phone;
            string email = member.email;
            string dob = member.dob;
            Console.WriteLine(value: fname);

            string query = @"insert into members (Forename, Lastname, Password, Eircode, Phone, Email, DOB) values(@Forename, @Lastname, @Password, @Eircode, @Phone, @Email, @DOB);";
            String sqlDataSource = _configuration.GetConnectionString("appcon");
            
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand mycommand = new MySqlCommand(query, mycon))
                {
                    /*                    foreach (String d in myData)
                                        {
                                            mycommand.Parameters.Add(d);
                                        }*/
                    mycommand.Parameters.AddWithValue("@Forename", fname);
                    mycommand.Parameters.AddWithValue("@Lastname", lname);
                    mycommand.Parameters.AddWithValue("@Password", pword);
                    mycommand.Parameters.AddWithValue("@Eircode", ecode);
                    mycommand.Parameters.AddWithValue("@Phone", phone);
                    mycommand.Parameters.AddWithValue("@Email", email);
                    mycommand.Parameters.AddWithValue("@DOB", dob);
                   /* mycommand.Parameters.AddWithValue("@CardDetails", member.cardDetails);
                    mycommand.Parameters.AddWithValue("@ExpireDate", member.expiredDate);
                    mycommand.Parameters.AddWithValue("@CVV", member.cvv);
                   */
                    
                }
                mycon.Close();
            }
            return new JsonResult("Post success");
        }  // end post 

        // PUT api/<MemberController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MemberController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
