using System.Collections.Generic;
using ABSA.Core.Service.ViewModels;
using ABSA.Core.Service.Models;

namespace ABSA.Core.Service.Services
{
    public interface IPhoneBookViewService
    {
        List<ViewPhoneBookViewModel> PhoneBook_Search(string SearchString);
    }
}
