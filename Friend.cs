using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DVDSystemAPI
{
    public class Friend
    {
        private string firstname { get; set; }
        private string lastname { get; set; }
        private string location { get; set; }
        private DateTime dateOfHire { get; set; }

        public Friend()
        {
        }
        public Friend(string firstname, string lastname, string location, DateTime dateOfHire)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.location = location;
            this.dateOfHire = dateOfHire;
        }
    }
} //
