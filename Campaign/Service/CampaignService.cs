using Campaign.Data;
using Campaign.Entities;
using Campaign.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Campaign.Service
{
    public class CampaignService:ICampaignService
    {
        private readonly AppDbContenxt _dbContext;

        public CampaignService(AppDbContenxt dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CampaignEntity> GetById(int id)
        {
            var campaign = await _dbContext.Campaigns.FirstOrDefaultAsync(e => e.CampaignId == id);
            return campaign;
        }
        public async Task<IEnumerable<CampaignEntity>> GetAll()
        {
            var campaigns = await _dbContext.Campaigns.ToListAsync();
            return campaigns;
        }

        public async Task Create(CampaignModel campaignModel)
        {
            var campaign = new CampaignEntity()
            {
                CampaignName = campaignModel.CampaignName,
                Keywords = campaignModel.Keywords,
                BidAmonut = campaignModel.BidAmonut,
                CampaignFund = campaignModel.CampaignFund,
                Status = campaignModel.Status,
                Town = campaignModel.Town,
                Radius = campaignModel.Radius
               
            };
            await _dbContext.Campaigns.AddAsync(campaign);
            await _dbContext.SaveChangesAsync();
        }


        public async Task Remove(int id)
        {
            var campaign = await _dbContext.Campaigns.FirstOrDefaultAsync(d => d.CampaignId == id);
            _dbContext.Campaigns.Remove(campaign);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(CampaignModel campaignModel)
        {
            var campaign = await _dbContext.Campaigns.FirstOrDefaultAsync(d => d.CampaignId == campaignModel.CampaignId);
            if (campaign != null)
            {
                campaign.CampaignName = campaignModel.CampaignName,
                campaign.Keywords = campaignModel.Keywords,
                campaign.BidAmonut = campaignModel.BidAmonut,
                campaign.CampaignFund = campaignModel.CampaignFund,
                campaign.Status = campaignModel.Status,
                campaign.Town = campaignModel.Town,
                campaign.Radius = campaignModel.Radius
            }
            await _dbContext.SaveChangesAsync();
        }
    }
}
