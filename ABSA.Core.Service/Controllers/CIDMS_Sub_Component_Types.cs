
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
//using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Sebata.Business.Assets.Core.Models;

namespace Sebata.Business.Assets.Core.Service.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    public partial class AssetController : ControllerBase
    {

        [Route("Assets/GetAll_CIDMS_SubComponentTypes")]
        [HttpGet]
        public IActionResult GetAll_CIDMS_SubComponentTypes(int pageSize = 100, int skip = 0)
        {
            try
            {
                assetBusinessLogic = new Sebata.Business.Assets.Core.Logic.Business();
                var CIDMS_SubComponent_Type = assetBusinessLogic.GetAll_CIDMS_SubComponentTypes();                

                string responseText = JsonConvert.SerializeObject(CIDMS_SubComponent_Type, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }
                );              

                return Ok(responseText);
            }
            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }
        
        [Route("Assets/Get_CIDMS_SubComponentType/{subComponentId}")]
        [HttpGet]
        public IActionResult Get_CIDMS_SubComponentType(int? subComponentId= null)
        {
            try
            {
                assetBusinessLogic = new Sebata.Business.Assets.Core.Logic.Business();
                var CIDMS_SubComponent_Type = assetBusinessLogic.Get_CIDMS_SubComponentType(subComponentId);

                string responseText = JsonConvert.SerializeObject(CIDMS_SubComponent_Type, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }
                );

                return Ok(responseText);
            }
            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }


    }
}