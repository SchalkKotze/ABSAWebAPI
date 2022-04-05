using System;
using System.Collections.Generic;
using System.Linq;
using ABSA.Core.Service.ViewModels;
using ABSA.Core.Service.Models;
using AutoMapper;

namespace ABSA.Core.Service.Services
{
    public class PhoneBookService : IPhoneBookService
    {
        private ABSAPhoneBookDbContext _phoneBookdb;
        private readonly IMapper _mapper;

        public PhoneBookService(IMapper mapper, ABSAPhoneBookDbContext context)
        {
            _mapper = mapper;
            _phoneBookdb = context;
        }

        public List<PhoneBookViewModel> PhoneBook_GetAll()
        {
            try 
            { 
                var data = _phoneBookdb.phonebook.ToList();

                return (List<PhoneBookViewModel>)_mapper.Map<IList<phonebook>,IList<PhoneBookViewModel>>(data);
            }
            catch
            {
                return new List<PhoneBookViewModel>();
            }

}
        public PhoneBookViewModel PhoneBook_Get(int PhoneBookID)
        {
            try
            {
                var data = _phoneBookdb.phonebook
                            .Where(w => w.id == PhoneBookID).FirstOrDefault();
            
                return _mapper.Map<PhoneBookViewModel>(data);
            }
            catch
            {
                return new PhoneBookViewModel();
            }

        }
        public long PhoneBook_Add(phonebook PhoneBook)
        {
            try
            {               
                if (!String.IsNullOrEmpty(PhoneBook.phonebookname))
                {
                    _phoneBookdb.Add(PhoneBook);

                    var result = _phoneBookdb.SaveChanges();
                    long id = PhoneBook.id;

                    return id;
                }
                else
                    return -1;
            }
            catch 
            {
                return -1;
            }
        }
        public long PhoneBook_Edit(phonebook PhoneBook)
        {
            try
            {
                phonebook _PhoneBookEdit = _phoneBookdb.phonebook
                    .Where(w => w.id == PhoneBook.id).FirstOrDefault();

                _PhoneBookEdit.phonebookname = PhoneBook.phonebookname;
                
                _phoneBookdb.SaveChanges();

                long id = _PhoneBookEdit.id;

                return id;
            }
            catch 
            {
                return -1;
            }
        }
    }
}