using System;
using FindCarrier.Enums;

namespace FindCarrier.HttpRequests
{
    public class AddOrCreateJobRequest
    {
        public string JobPosition { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public JobTypes JobTypeId { get; set; }
        public int CompanyId { get; set; }
    }
}
