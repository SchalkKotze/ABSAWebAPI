using Microsoft.AspNetCore.Mvc;
using ABSA.Core.Service.Services;
using ABSA.Core.Service.Models;
using AutoMapper;

namespace ABSA.Core.Service.Controllers
{
    public class PhoneBookViewController : ControllerBase
    {
        private readonly IPhoneBookViewService _service;

        public PhoneBookViewController(IMapper mapper , ABSAPhoneBookDbContext context)
        {
            this._service = new Services.PhoneBookViewService(mapper, context );
        }

        [HttpGet("api/PhoneBookView/")]
        public IActionResult PhoneBookView_Get()
        {
            var multipleRows = _service.PhoneBook_Search("");
            return Ok(multipleRows);
        }

        [HttpGet("api/PhoneBookView/{SearchString}")]
        public IActionResult PhoneBookView_Get(string SearchString)
        {
            var multipleRows = _service.PhoneBook_Search(SearchString);
            return Ok(multipleRows);
        }
       
    }
}
