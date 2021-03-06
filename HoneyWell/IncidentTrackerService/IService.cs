using System;
using System.Collections.Generic;
using System.Text;
using IncidentTrackerModal;

namespace IncidentTrackerService
{
    public interface IService
    {
        List<IncidentTracker> GetIncidentTrackers();
        IncidentTracker GetIncident(int incidentTrackerId);
        IncidentTracker Create(IncidentTracker incidentTracker);
        IncidentTracker Update(IncidentTracker incidentTracker);
        bool Delete(int incidentTrackerId);
    }
}
