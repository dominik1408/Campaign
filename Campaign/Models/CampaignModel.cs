using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Campaign.Models
{
    public class CampaignModel
    {
        [Key]
        public int CampaignId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Campaign name")]
        public string CampaignName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Keywords")]
        public string Keywords { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Bid amount")]
        public double BidAmonut { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Campaign fund")]
        public double CampaignFund { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Status")]
        public bool Status { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Town")]
        public string Town { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Radius (km)")]
        public double Radius { get; set; }
    }
}
