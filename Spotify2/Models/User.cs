using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spotify2.Models
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string FirebaseId { get; set; }

        public string UserName { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string ProfilePicUrl { get; set; }

        public DateTime Birthday { get; set; }
            
            }
}
