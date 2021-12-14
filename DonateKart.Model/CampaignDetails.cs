using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonateKart.Model
{
    public class CampaignDetails
    {
        public int Id { get; set; }
        public string title { get; set; }
        public float totalAmount { get; set; }
        public decimal backersCount { get; set; }
        public float procuredAmount { get; set; }
        public DateTime endDate { get; set; }
    }
}
