using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using IncidentTrackerModal;
using Microsoft.Extensions.Configuration;

namespace IncidentTrackerRepo
{
    public class Context : DbContext
    {
        private readonly IConfiguration _configuration;
        public Context()
        {

        }
        public Context(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DBConnection"));
        }
        public DbSet<IncidentTracker> IncidentTracker { get; set; }
       
    }
}
