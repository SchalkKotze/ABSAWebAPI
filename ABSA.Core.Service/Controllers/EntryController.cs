using Microsoft.AspNetCore.Mvc;
using ABSA.Core.Service.Services;
using ABSA.Core.Service.Models;
using AutoMapper;

namespace ABSA.Core.Service.Controllers
{
    public class EntryController : ControllerBase
    {
        private readonly IEntryService _service;

        public EntryController(IMapper mapper,ABSAPhoneBookDbContext context)
        {
            this._service = new Services.EntryService(mapper,context);
        }

        [HttpGet("api/Entries")]
        public IActionResult Entry_GetAll()
        {
            var multipleTransactions = _service.Entry_GetAll();
            return Ok(multipleTransactions);
        }

        [HttpGet("api/Entries/{entryID}")]
        public IActionResult Entry_Get(int entryID)
        {
            var singleTransactions = _service.Entry_Get(entryID);
            return Ok(singleTransactions);
        }

        [Route("api/Entries_Add")]
        [HttpPost]
        public IActionResult Entry_Add([FromBody] entry _entry)
        {
            var entryID = _service.Entry_Add(_entry);

            if (entryID > 0)
            {
                return Ok(entryID);
            }
            else
            {
                return Conflict(entryID);
            }
        }

        [Route("api/Entries_Edit")]
        [HttpPost]
        public IActionResult Entries_Edit([FromBody] entry _entryPass)
        {
            var entryID = _service.Entry_Edit(_entryPass);

            if (entryID > 0)
            {
                return Ok(entryID);
            }
            else
            {
                return Conflict(entryID);
            }
        }
    }
}


