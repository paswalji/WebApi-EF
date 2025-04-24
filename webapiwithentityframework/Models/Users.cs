using System.ComponentModel.DataAnnotations;

namespace webapiwithentityframework.Models
{
    public class Users
   {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
    }
}
