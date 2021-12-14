using System;

namespace DonateKart.Model
{
    public class Campaign
    {
        public int Id { get; set; }
        public string code { get; set; }
        public string title { get; set; }
        public bool featured { get; set; }
        public int priority { get; set; }
        public string campaignType { get; set; }
        public string shortDesc { get; set; }
        public string imageSrc { get; set; }
        public DateTime created { get; set; }
        public DateTime endDate { get; set; }
        public decimal totalAmount { get; set; }
        public decimal procuredAmount { get; set; }
        public decimal totalProcured { get; set; }
        public decimal backersCount { get; set; }
        public int categoryId { get; set; }
        public string location { get; set; }
        public string ngoCode { get; set; }
        public string ngoName { get; set; }
        public string Foundation { get; set; }
        public int daysLeft { get; set; }
        public decimal percentage { get; set; }
    }
}
