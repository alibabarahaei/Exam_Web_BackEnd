using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Web.DataLayer.Entities
{
    public class Customer
    {
        [Required]
        public int CustomerID { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string CustomerFamily { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }

    }
}
