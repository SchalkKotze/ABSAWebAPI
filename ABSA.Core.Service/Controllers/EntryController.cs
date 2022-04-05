using Microsoft.AspNetCore.Mvc;
using ABSA.Core.Service.Services;
using ABSA.Core.Service.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;

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
            try 
            { 
                var multipleTransactions = _service.Entry_GetAll();
                return Ok(multipleTransactions);
         
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("api/Entries/{entryID}")]
        public IActionResult Entry_Get(int entryID)
        {
            try
            {

                var singleTransactions = _service.Entry_Get(entryID);
                return Ok(singleTransactions);
            }            
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Route("api/Entries_Add")]
        [HttpPost]
        public IActionResult Entry_Add([FromBody] entry _entry)
        {
            try
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
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Route("api/Entries_Edit")]
        [HttpPost]
        public IActionResult Entries_Edit([FromBody] entry _entryPass)
        {
            try
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
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}


