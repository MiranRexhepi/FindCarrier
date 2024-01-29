using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindCarrier.Services.IServices
{
    public interface IExternalUniversityService
    {
        Task<string> SendApplication(string universityName, string studentName);
    }
}
