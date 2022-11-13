using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DVDSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendController : ControllerBase
    {
        private object friends;

        // GET: api/<FriendController>
        [HttpGet]
      /*  public string Get()
        {
            return "Hello World";
        }*/
        
        public List<Friend> Get()
        {
            List<Friend> friends = new List<Friend>();
            friends.Add(new Friend("Kindson", "Munonye", "Budapest", DateTime.Today));
            friends.Add(new Friend("Oleander", "Yuba", "Nigeria", DateTime.Today));
            friends.Add(new Friend("Saffron", "Lawrence", "Lagos", DateTime.Today));
            friends.Add(new Friend("Jadon", "Munonye", "Asaba", DateTime.Today));
            friends.Add(new Friend("Solace", "Okeke", "Oko", DateTime.Today));

            return friends;
        }
       
        
         // GET api/<FriendController>/5
        /* [HttpGet("{id}", Name = "Get")]
         public Friend Get(int id)
         {
             Friend friend = friends.Find(f => f.id == id);
             return friend;
         }
        */

        // POST api/<FriendController>
        [HttpPost]
        /*public List<Friend> Post([FromBody] Friend friend)
        {
            friends.Add(friend);
            return friends;
        }*/

        // PUT api/<FriendController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FriendController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
