using Campaign.Models;
using Campaign.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Campaign.Controllers
{
    public class CampaignController : Controller
    {
        private readonly ICampaignService _service;

        public CampaignController(ICampaignService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var campaigns = await _service.GetAll();
            return View(campaigns);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CampaignModel campaignModel)
        {
            if (!ModelState.IsValid) return View(campaignModel);
            await _service.Create(campaignModel);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            var campaign = await _service.GetById(id);
            if (campaign == null) return View("Error");
            var entity = new CampaignModel()
            {
                CampaignId = campaign.CampaignId,
                CampaignName =campaign.CampaignName,
                Keywords = campaign.Keywords,
                BidAmonut = campaign.BidAmonut,
                CampaignFund = campaign.CampaignFund,
                Status = campaign.Status,
                Town = campaign.Town,
                Radius = campaign.Radius
            };
            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, CampaignModel campaignModel)
        {
            if (id != campaignModel.CampaignId) return View("Error");
            if (!ModelState.IsValid) return View(campaignModel);
            await _service.Update(campaignModel);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var campaign = await _service.GetById(id);
            if (campaign == null) return View("Error");
            await _service.Remove(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
