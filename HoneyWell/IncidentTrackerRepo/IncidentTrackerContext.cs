using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using IncidentTrackerModal;
using System.Linq;

namespace IncidentTrackerRepo
{
    public class IncidentTrackerContext : IIncidentTrackerContext
    {
        private readonly IConfiguration _configuration;
        private Context GetNewContext()
        {
            return new Context(_configuration);
        }
        public IncidentTrackerContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<IncidentTracker> GetIncidentTrackers()
        {
            using (Context context = GetNewContext())
            {
                return context.IncidentTracker.ToList();
            }
        }

        public IncidentTracker GetIncident(int incidentTrackerId)
        {
            using (Context context = GetNewContext())
            {
                return context.IncidentTracker.FirstOrDefault(x => x.IncidentTrackerId == incidentTrackerId);
            }
        }

        public IncidentTracker Create(IncidentTracker incidentTracker)
        {
            using (Context context = GetNewContext())
            {
                context.IncidentTracker.Add(incidentTracker);
                context.SaveChanges();
                return context.IncidentTracker.FirstOrDefault(x => x.IncidentTrackerId == incidentTracker.IncidentTrackerId);
            }
        }

        public IncidentTracker Update(IncidentTracker incidentTracker)
        {
            using (Context context = GetNewContext())
            {
                context.IncidentTracker.Update(incidentTracker);
                context.SaveChanges();
                return context.IncidentTracker.FirstOrDefault(x => x.IncidentTrackerId == incidentTracker.IncidentTrackerId);
            }
        }

        public bool Delete(int incidentTrackerId)
        {
            try
            {
                using (Context context = GetNewContext())
                {
                    context.IncidentTracker.Remove(new IncidentTracker() { IncidentTrackerId = incidentTrackerId });
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
