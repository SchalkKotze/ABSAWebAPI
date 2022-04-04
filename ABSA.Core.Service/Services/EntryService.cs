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
          
            var data = _entrydb.entry.ToList();

            return (List<EntryViewModel>)_mapper.Map<IList<entry>, IList<EntryViewModel>>(data);

        }
        public EntryViewModel Entry_Get(int EntryID)
        {
        
            var data = _entrydb.entry
                .Where(w => w.id == EntryID ).FirstOrDefault();

            return _mapper.Map<EntryViewModel>(data);

        }
        public long Entry_Add(entry Entry)
        {
            try
            {
                entry _EntryAdd = new entry();

                _EntryAdd.name = Entry.name;
                _EntryAdd.phonenumber = Entry.phonenumber;
                _EntryAdd.phonebookid = Entry.phonebookid;

                _entrydb.Add(_EntryAdd);

                _entrydb.SaveChanges();

                long id = _EntryAdd.id;

                return id;
            }
            catch {
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