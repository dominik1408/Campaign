using Campaign.Entities;
using Campaign.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Campaign.Service
{
    public interface ICampaignService
    {
        Task<CampaignEntity> GetById(int id);
        Task<IEnumerable<CampaignEntity>> GetAll();
        Task Create(CampaignModel campaignModel);
        Task Remove(int id);
        Task Update(CampaignModel campaignModel);
    }
}
