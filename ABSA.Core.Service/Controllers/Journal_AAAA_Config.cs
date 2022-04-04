using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog;
using ABSA.Core.Models;
using AutoMapper;

namespace ABSA.Core.Service.Controllers
{
    public partial class Journal_AAAA_Config : ControllerBase
    {

        private ABSA.Core.Logic.Journal_AAAA_Config journalBusinessLogic = new Logic.Journal_AAAA_Config();
        private readonly IMapper _mapper;

        public Journal_AAAA_Config(IMapper mapper)
        {
            _mapper = mapper;
        }

        [Route("Journal/JournalConfig_Get/{KeyName}")]
        [HttpGet]
        public IActionResult JournalConfig_Get(string KeyName)
        {
            try
            {
                DB_Context _Journaldb = new DB_Context();
                using (_Journaldb)
                {                  
                    var jnl_Config = journalBusinessLogic.JournalConfig_Get(KeyName, _Journaldb);

                    string responseText = JsonConvert.SerializeObject(jnl_Config, Formatting.Indented, new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                        NullValueHandling = NullValueHandling.Ignore
                    }
                    );

                    return Ok(responseText);
                }
            }
            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }
    }
}

