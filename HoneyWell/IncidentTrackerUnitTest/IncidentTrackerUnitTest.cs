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
                Description = $"Created by Unit Test {Helper.GenerateName(30)}"
            }); ;
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
                Description = $"Created by Unit Test {Helper.GenerateName(30)}"
            });


            service.Delete(incidentTracker.IncidentTrackerId);
            IncidentTracker incidentTracker1 = service.GetIncident(incidentTracker.IncidentTrackerId);
            Assert.IsNull(incidentTracker1);

        }
        [TestMethod]
        public void UpdateIncident()
        {
            IService service = serviceProvider.GetService<IService>();
            IncidentTracker incidentTracker = service.Create(new IncidentTracker()
            {
                IncidentId = Helper.GenerateName(10),
                CreateAt = DateTime.Now,
                Severity = Severity.High,
                Status = Status.Completed,
                Description = $"Created by Unit Test {Helper.GenerateName(30)}"
            });

            IncidentTracker incidentTracker1 = service.GetIncident(incidentTracker.IncidentTrackerId);
            incidentTracker1.Status = Status.Failed;
            incidentTracker1.Severity = Severity.Low;
            service.Update(incidentTracker1);
            IncidentTracker incidentTracker2 = service.GetIncident(incidentTracker.IncidentTrackerId);
            Assert.AreEqual(incidentTracker2.Status, incidentTracker1.Status);
            Assert.AreEqual(incidentTracker2.Severity, incidentTracker1.Severity);
        }
    }

}
