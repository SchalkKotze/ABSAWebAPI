using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABSA.Core.Service.Models
{
    public partial class PhoneBookView
    {
        public long? id { get; set; }
        public string phonebookname { get; set; }
        [Column("id:1", TypeName = "INT")]
        public long? id_1 { get; set; }
        [Column(TypeName = "INT")]
        public long? phonebookid { get; set; }
        public string name { get; set; }
        public string phonenumber { get; set; }
    }
}
