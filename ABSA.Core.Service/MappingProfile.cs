using AutoMapper;
using ABSA.Core.Service.Models;
using ABSA.Core.Service.ViewModels;

namespace ABSA.Core.Service
{
    class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<phonebook, PhoneBookViewModel>().ReverseMap();
            CreateMap<entry, EntryViewModel>().ReverseMap();
            CreateMap<PhoneBookView, ViewPhoneBookViewModel>().ReverseMap();
        }
    }
}
