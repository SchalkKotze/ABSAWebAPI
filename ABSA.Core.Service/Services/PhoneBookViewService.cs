using System;
using System.Collections.Generic;
using System.Linq;
using ABSA.Core.Service.ViewModels;
using ABSA.Core.Service.Models;
using AutoMapper;

namespace ABSA.Core.Service.Services
{
    public class PhoneBookViewService : IPhoneBookViewService
    {
        private ABSAPhoneBookDbContext _PhoneBookViewdb;

        private readonly IMapper _mapper;

        public PhoneBookViewService(IMapper mapper , ABSAPhoneBookDbContext context)
        {
            _mapper = mapper;
            _PhoneBookViewdb = context; 
        }


        public List<ViewPhoneBookViewModel> PhoneBook_Search(string SearchString)
        {
            var filterData = _PhoneBookViewdb.PhoneBookView.AsQueryable();

            if (!String.IsNullOrEmpty(SearchString))
            {
               filterData = filterData.Where(w => w.name.Contains(SearchString) || w.phonenumber.Contains(SearchString));
            }
            
            return (List<ViewPhoneBookViewModel>)_mapper.Map<IList<PhoneBookView>, IList<ViewPhoneBookViewModel>>(filterData.ToList());

        }
}
       
    
}