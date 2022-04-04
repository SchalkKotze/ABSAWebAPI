using System.Collections.Generic;
using ABSA.Core.Service.ViewModels;
using ABSA.Core.Service.Models;

namespace ABSA.Core.Service.Services
{
    public interface IEntryService
    {
        List<EntryViewModel> Entry_GetAll();
        EntryViewModel Entry_Get(int EntryID);
        long Entry_Add(entry Entry);
        long Entry_Edit(entry Entry);
    }
}
