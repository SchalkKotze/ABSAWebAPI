using System;
using System.Collections.Generic;
using System.Linq;
using ABSA.Core.Service.ViewModels;
using ABSA.Core.Service.Models;
using AutoMapper;

namespace ABSA.Core.Service.Services
{
    public class EntryService : IEntryService
    {
        private ABSAPhoneBookDbContext _entrydb;
        private readonly IMapper _mapper;

        public EntryService(IMapper mapper, ABSAPhoneBookDbContext context)
        {
            _mapper = mapper;
            _entrydb = context;
        }

        public List<EntryViewModel> Entry_GetAll()
        {
            try
            {
                var data = _entrydb.entry.ToList();
                return (List<EntryViewModel>)_mapper.Map<IList<entry>, IList<EntryViewModel>>(data);
            }
            catch
            {
                return new List<EntryViewModel>();
            }
        }
        public EntryViewModel Entry_Get(int EntryID)
        {
            try 
            {  
                var data = _entrydb.entry
                    .Where(w => w.id == EntryID ).FirstOrDefault();

                return _mapper.Map<EntryViewModel>(data);
            }
            catch
            {
                return new EntryViewModel();
            }
}
        public long Entry_Add(entry Entry)
        {
            try
            {
                _entrydb.Add(Entry);
                _entrydb.SaveChanges();

                long id = Entry.id;

                return id;
            }
            catch 
            {
                return -1;
            }
        }

        public long Entry_Edit(entry Entry)
        {
            try
            {
                entry _EntryEdit = _entrydb.entry
                    .Where(w => w.id == Entry.id).FirstOrDefault();

                _EntryEdit.name = Entry.name;
                _EntryEdit.phonenumber = Entry.phonenumber;

                _entrydb.SaveChanges();

                long id = _EntryEdit.id;

                return id;
            }
            catch 
            {
                return -1;
            }
        }
    }
}