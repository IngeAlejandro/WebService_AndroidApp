using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WSApp.Entities
{
    public class Users
    {
        [Key]
        public String username { get; set; }
        public String password { get; set; }
        public String country { get; set; }

    }
}
