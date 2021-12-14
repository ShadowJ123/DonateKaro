using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DonateKart.Model;
using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using DonateKar.Services;

namespace DonateKar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignsController : ControllerBase
    {
        private readonly ICampaignService _campaignService;
        public CampaignsController(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }
        /// <summary>
        /// Get Campaign
        /// </summary>
        /// <returns></returns>
        // GET: api/Campaigns
        [HttpGet]
        [ProducesResponseType(typeof(GetCampaignResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetCampaign()
        {
            try
            {
                var reponse = await _campaignService.GetCampaign();
                if (reponse.campaigndetailsList.Count() == 0)
                {
                    return NotFound(reponse);
                }
                return Ok(reponse);
            } catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Get Active Campaign
        /// </summary>
        /// <returns></returns>
        // GET: api/Campaigns
        [HttpGet("GetActiveCampaign")]
        [ProducesResponseType(typeof(GetActiveCampaignResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetActiveCampaign()
        {
            try
            {
                var reponse = await _campaignService.GetCampaign();
                if (reponse.campaigndetailsList.Count() == 0)
                {
                    return NotFound(reponse);
                }
                return Ok(reponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetClosedCampaign")]
        [ProducesResponseType(typeof(GetCampaignResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetClosedCampaign()
        {
            try
            {
                var reponse = await _campaignService.GetClosedCampaign();
                if (reponse.campaigndetailsList.Count() == 0)
                {
                    return NotFound(reponse);
                }
                return Ok(reponse);
                //string apiURL = @"https://testapi.donatekart.com/api/campaign";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("{N}")]
        [ProducesResponseType(typeof(GetEmployeeDetail), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetPaidEmployee(int N)
        {
            try
            {
                var getEmployeeDetail = new GetEmployeeDetail();
                var query = @"select * from Employee order by Payment limit Desc limit N-1,1";
               // getEmployeeDetail=
                return Ok(getEmployeeDetail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
