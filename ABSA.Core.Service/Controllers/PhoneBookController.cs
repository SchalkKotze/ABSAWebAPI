using Microsoft.AspNetCore.Mvc;
using ABSA.Core.Service.Services;
using ABSA.Core.Service.Models;
using AutoMapper;

namespace ABSA.Core.Service.Controllers
{
    public class PhoneBookController : ControllerBase
    {        
        private readonly IPhoneBookService _service;        

        public PhoneBookController(IMapper mapper,ABSAPhoneBookDbContext context)
        {
            this._service = new Services.PhoneBookService(mapper,context);
        }

        [HttpGet("api/PhoneBook")]
        public IActionResult PhoneBook_GetAll()
        {
            var multipleTransactions = _service.PhoneBook_GetAll();
            return Ok(multipleTransactions);
        }

        [HttpGet("api/PhoneBook/{phoneBookID}")]
        public IActionResult PhoneBook_Get(int phoneBookID)
        {
            var singleTransactions = _service.PhoneBook_Get(phoneBookID);
            return Ok(singleTransactions);
        }
        [Route("api/PhoneBook_Add")]
        [HttpPost]
        public IActionResult PhoneBook_Add([FromBody] phonebook _PhoneBook)
        {            
                var phoneID = _service.PhoneBook_Add(_PhoneBook);

                if (phoneID > 0)
                {
                    return Ok(phoneID);
                }
                else
                {
                    return Conflict(phoneID);
                }            
        }
        [Route("api/PhoneBook_Edit")]
        [HttpPost]
        public IActionResult PhoneBook_Edit([FromBody] phonebook _PhoneBook)
        {
            var phoneID = _service.PhoneBook_Edit(_PhoneBook);

            if (phoneID > 0)
            {
                return Ok(phoneID);
            }
            else
            {
                return Conflict(phoneID);
            }
        }
    }
}

