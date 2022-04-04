using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABSA.Core.Service.Models
{
    public partial class phonebook
    {
        [Key]
        public long id { get; set; }
        [Required,StringLength(100,MinimumLength=5)]
        
        public string phonebookname { get; set; }
    }
}
