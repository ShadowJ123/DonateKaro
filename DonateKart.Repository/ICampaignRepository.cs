using DonateKart.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonateKart.Repository
{
    public interface ICampaignRepository
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        Task<GetEmployeeDetail> GetDetails(int N);
    }
}
