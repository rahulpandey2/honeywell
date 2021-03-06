using IncidentTrackerModal;
using System;
using System.Collections.Generic;
using IncidentTrackerRepo;

namespace IncidentTrackerService
{
    public class Service : IService
    {
        private readonly IIncidentTrackerContext _incidentTrackerContext;
        public Service(IIncidentTrackerContext incidentTrackerContext)
        {
            _incidentTrackerContext = incidentTrackerContext;
        }
        public IncidentTracker Create(IncidentTracker incidentTracker)
        {
            return _incidentTrackerContext.Create(incidentTracker);
        }

        public bool Delete(int incidentTrackerId)
        {
            return _incidentTrackerContext.Delete(incidentTrackerId);
        }

        public IncidentTracker GetIncident(int incidentTrackerId)
        {
            return _incidentTrackerContext.GetIncident(incidentTrackerId);
        }

        public List<IncidentTracker> GetIncidentTrackers()
        {
            return _incidentTrackerContext.GetIncidentTrackers();
        }

        public IncidentTracker Update(IncidentTracker incidentTracker)
        {
            return _incidentTrackerContext.Update(incidentTracker);
        }
    }
}
