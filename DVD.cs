using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DVDSystemAPI.Controllers
{
    public class DVD
    {
        private String title;
        private String genre;
        private String duration;
        private String rating;
        private string cost;
        private string status;

    public DVD(String title, String genre, String duration, String rating, String cost)
        {
            this.title = title;
            this.genre = genre;
            this.duration = duration;
            this.rating = rating;
            this.cost = cost;
            this.status = "A";
        } // end constructor 
    
    } /// end class 
}
