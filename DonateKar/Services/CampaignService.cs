using DonateKart.Model;
using DonateKart.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonateKar.Services
{
    public class CampaignService: ICampaignService
    {
        private readonly ICampaignRepository _campaignRepository;
        public CampaignService(ICampaignRepository campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<GetCampaignResponse> GetCampaign()
        {
            try
            {
                var response = await _campaignRepository.GetCampaign();
                return response;
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
        public async Task<GetActiveCampaignResponse> GetActiveCampaign()
        {
            try
            {
                var response = await _campaignRepository.GetActiveCampaign();
                return response;
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
        public async Task<GetCampaignResponse> GetClosedCampaign()
        {
            try
            {
                var response = await _campaignRepository.GetClosedCampaign();
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
