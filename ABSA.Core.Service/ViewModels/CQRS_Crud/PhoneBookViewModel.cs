

using System.ComponentModel.DataAnnotations;


namespace ABSA.Core.Service.ViewModels
{
    public class PhoneBookViewModel 
    {
        [Key]
        public long id { get; set; }
        [Required]
        public string phonebookname { get; set; }

    }
}
