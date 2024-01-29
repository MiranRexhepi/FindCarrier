using FindCarrier.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindCarrier.Services.IServices
{
    public interface IApplicationService
    {
        Task<UniversityApplication> ApplyToUniversity(string universityName, string studentName);
    }
}
