using System.Collections.Generic;
using ABSA.Core.Service.ViewModels;
using ABSA.Core.Service.Models;

namespace ABSA.Core.Service.Services
{
    public interface IPhoneBookService
    {
        List<PhoneBookViewModel> PhoneBook_GetAll();
        PhoneBookViewModel PhoneBook_Get(int PhoneBookID);
        long PhoneBook_Add(phonebook PhoneBook);
        long PhoneBook_Edit(phonebook PhoneBook);
    }
}
