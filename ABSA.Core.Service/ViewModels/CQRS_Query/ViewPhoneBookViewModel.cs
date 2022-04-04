using System.ComponentModel.DataAnnotations;

namespace ABSA.Core.Service.ViewModels
{
    public class ViewPhoneBookViewModel
    {
        [Key]
        public long id { get; set; }
        [Required]
        public string phonebookname { get; set; }
        public long entryid { get; set; }
        public long phonebookid { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string phonenumber { get; set; }
    }

}
