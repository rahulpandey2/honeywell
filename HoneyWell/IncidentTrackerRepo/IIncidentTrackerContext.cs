using IncidentTrackerModal;
using System;
using System.Collections.Generic;
using System.Text;

namespace IncidentTrackerRepo
{
    public interface IIncidentTrackerContext
    {
        List<IncidentTracker> GetIncidentTrackers();
        IncidentTracker GetIncident(int incidentTrackerId);
        IncidentTracker Create(IncidentTracker incidentTracker);
        IncidentTracker Update(IncidentTracker incidentTracker);
        bool Delete(int incidentTrackerId);
    }
}
