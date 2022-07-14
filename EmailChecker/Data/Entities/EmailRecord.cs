using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email_Validator.Data.Entities
{
    public class EmailRecord
    {
        public int Id { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public DateTime Created { get; set; }
    }
}
