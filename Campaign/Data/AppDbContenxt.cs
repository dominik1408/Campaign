using Campaign.Entities;
using Campaign.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Campaign.Data
{
    public class AppDbContenxt:DbContext
    {
        public AppDbContenxt(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CampaignEntity> Campaigns { get; set; }
    }
}
