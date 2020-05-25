using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WSApp.Entities
{
    public class Scores
    {  
        [Key]
        public int id { get; set; }
        public int score { get; set; }
        public String user_username { get; set; }
        [ForeignKey("user_username")]
        public Users User { get; set; }


    }

}
