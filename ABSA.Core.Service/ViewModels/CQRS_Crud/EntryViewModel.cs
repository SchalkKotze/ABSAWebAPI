
using System.ComponentModel.DataAnnotations;


namespace ABSA.Core.Service.ViewModels
{
    public class EntryViewModel
    {
        [Key]
        public long id { get; set; }
        public long phonebookid { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string phonenumber { get; set; }

    }
}
