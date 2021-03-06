using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using IncidentTrackerService;
using IncidentTrackerModal;

namespace Service.test
{
    [TestClass]
    public class IncidentTrackerUnitTest : BaseTest
    {

        [TestMethod]
        public void GetAllIncidents()
        {
            IService service = serviceProvider.GetService<IService>();
            List<IncidentTracker> incidentTrackers = service.GetIncidentTrackers();
            Assert.IsTrue(incidentTrackers.Count > 0);
        }
        [TestMethod]
        public void CreateIncidents()
        {
            //arrange

            IService service = serviceProvider.GetService<IService>();
            //act
            IncidentTracker incidentTracker = service.Create(new IncidentTracker()
            {
                IncidentId = Helper.GenerateName(10),
                CreateAt = DateTime.Now,
                Severity = Severity.High,
                Status = Status.Completed,
                Description = Helper.GenerateName(30)
            });
            ;
            //assert
            Assert.IsTrue(incidentTracker.IncidentTrackerId > 0);
        }
        [TestMethod]
        public void DeleteIncident()
        {
            IService service = serviceProvider.GetService<IService>();
            IncidentTracker incidentTracker = service.Create(new IncidentTracker()
            {
                IncidentId = Helper.GenerateName(10),
                CreateAt = DateTime.Now,
                Severity = Severity.High,
                Status = Status.Completed,
                Description = Helper.GenerateName(30)
            });


            service.Delete(incidentTracker.IncidentTrackerId);
            IncidentTracker incidentTracker1 = service.GetIncident(incidentTracker.IncidentTrackerId);
            Assert.IsNull(incidentTracker1);

        }
      
    }
}
