using DonateKart.Model;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DonateKart.Repository
{
    public class CampaignRepository: ICampaignRepository
    {
        private readonly IConfiguration _config;
        public CampaignRepository(IConfiguration config)
        {
            _config = config;
        }
        public async Task<GetCampaignResponse> GetCampaign()
        {
            try
            {
                string apiURL = @"https://testapi.donatekart.com/api/campaign";
                var getCampaignResponse = new GetCampaignResponse();

                using (WebClient webClient = new WebClient())
                {
                    var json = webClient.DownloadString(apiURL);
                    var deserializeJson = JsonConvert.DeserializeObject(json);

                    List<CampaignDetails> response = ((JArray)deserializeJson).Select(x => new CampaignDetails
                    {
                        Id = (int)x["id"],
                        title = (string)x["title"],
                        totalAmount = (int)x["totalAmount"],
                        backersCount = (decimal)x["backersCount"],
                        endDate = (DateTime)x["endDate"]
                    }).OrderByDescending(x => x.totalAmount).ToList();
                    getCampaignResponse.campaigndetailsList = response;
                }
                return getCampaignResponse;
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
                string apiURL = @"https://testapi.donatekart.com/api/campaign";
                var getActiveCampaignResponse = new GetActiveCampaignResponse();
                using (WebClient webClient = new WebClient())
                {
                    var json = webClient.DownloadString(apiURL);
                    var deserializeJson = JsonConvert.DeserializeObject(json);

                    List<Campaign> response = ((JArray)deserializeJson).Where(
                        data => (DateTime)data["endDate"] >= DateTime.UtcNow.Date &&
                         ((DateTime)data["created"]).Date >= DateTime.UtcNow.Date.AddDays(-30)
                        ).Select(x => new Campaign
                        {
                            Id = (int)x["id"],
                            title = (string)x["title"],
                            totalAmount = (decimal)x["totalAmount"],
                            backersCount = (decimal)x["backersCount"],
                            endDate = (DateTime)x["endDate"],
                            created = (DateTime)x["created"]
                        }).OrderBy(x => x.totalAmount).ToList();
                    getActiveCampaignResponse.campaigns = response;
                }
                return getActiveCampaignResponse;
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
                string apiURL = @"https://testapi.donatekart.com/api/campaign";
                var getCampaignResponse = new GetCampaignResponse();
                using (WebClient webClient = new WebClient())
                {
                    var json = webClient.DownloadString(apiURL);
                    var deserializeJson = JsonConvert.DeserializeObject(json);

                    List<CampaignDetails> response = ((JArray)deserializeJson).Where(
                        data => (DateTime)data["endDate"] < DateTime.UtcNow.Date ||
                         (float)data["procuredAmount"] >= (float)data["totalAmount"]
                        ).Select(x => new CampaignDetails
                        {
                            Id = (int)x["id"],
                            title = (string)x["title"],
                            totalAmount = (float)x["totalAmount"],
                            backersCount = (decimal)x["backersCount"],
                            endDate = (DateTime)x["endDate"],
                            procuredAmount = (float)x["procuredAmount"]
                        }).OrderBy(x => x.totalAmount).ToList();
                    getCampaignResponse.campaigndetailsList = response;
                }
                return getCampaignResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<GetEmployeeDetail> GetDetails(int N)
        {
            try
            {
                var getEmployeeDetail = new GetEmployeeDetail();
                var query = @"select * from Employee order by Payment limit Desc limit @N,1";
                using (SqlConnection sourceConnection =
                    new SqlConnection(_config.GetSection("ConnectionStrings:SqlConnection").Value))
                {
                    using (SqlCommand commandSourceData = new SqlCommand(query, sourceConnection))
                    {
                        sourceConnection.Open();
                        using (SqlDataReader reader = commandSourceData.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var response = reader;
                            }
                        }
                        sourceConnection.Close();
                    } 
                }

                return getEmployeeDetail;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
