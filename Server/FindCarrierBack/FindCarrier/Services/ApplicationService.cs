using FindCarrier.Domain.Entities;
using FindCarrier.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindCarrier.Services.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IExternalUniversityService _universityService;
        private readonly INotificationService _notificationService;

        public ApplicationService(IExternalUniversityService universityService, INotificationService notificationService)
        {
            _universityService = universityService;
            _notificationService = notificationService;
        }

        public async Task<UniversityApplication> ApplyToUniversity(string universityName, string studentName)
        {
            var applicationStatus = await _universityService.SendApplication(universityName, studentName);

            var universityApplication = new UniversityApplication
            {
                UniversityName = universityName,
                StudentName = studentName,
                ApplicationStatus = applicationStatus
            };

            _notificationService.NotifyApplicationStatus(studentName, universityName, applicationStatus);

            return universityApplication;
        }
    }
}
