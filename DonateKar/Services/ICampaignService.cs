using DonateKart.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonateKar.Services
{
    public interface ICampaignService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<GetCampaignResponse> GetCampaign();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<GetActiveCampaignResponse> GetActiveCampaign();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<GetCampaignResponse> GetClosedCampaign();
    }
}
