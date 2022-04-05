using Microsoft.AspNetCore.Mvc;
using ABSA.Core.Service.Services;
using ABSA.Core.Service.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;

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
            try
            {
                var multipleTransactions = _service.PhoneBook_GetAll();
                return Ok(multipleTransactions);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("api/PhoneBook/{phoneBookID}")]
        public IActionResult PhoneBook_Get(int phoneBookID)
        {
            try
            {
                var singleTransactions = _service.PhoneBook_Get(phoneBookID);
                return Ok(singleTransactions);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Route("api/PhoneBook_Add")]
        [HttpPost]
        public IActionResult PhoneBook_Add([FromBody] phonebook _PhoneBook)
        {
            try 
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
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        
        [Route("api/PhoneBook_Edit")]
        [HttpPost]
        public IActionResult PhoneBook_Edit([FromBody] phonebook _PhoneBook)
        {
            try
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
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

