using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABSA.Core.Service.Models
{
    public partial class entry
    {
        [Key]
        [Column(TypeName = "INT")]
        public long id { get; set; }
        [Column(TypeName = "INT")]
        public long phonebookid { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string phonenumber { get; set; }
    }
}
