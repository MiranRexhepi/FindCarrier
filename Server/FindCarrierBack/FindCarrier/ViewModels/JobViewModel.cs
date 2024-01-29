using System.Collections.Generic;

namespace FindCarrier.Models.ViewModels
{
    public class JobViewModel
    {
        public string JobName { get; set; }
        public string Position { get; set; }
        public string CompanyName { get; set; }
        public bool IsDeleted { get; set; }
        public string Place { get; set; }
        public string Deadline { get; set; }
        public List<JobViewModel> Job { get; set; }
    }
}