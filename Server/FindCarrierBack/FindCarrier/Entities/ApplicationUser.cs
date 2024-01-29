using Microsoft.AspNetCore.Identity;

namespace FindCarrier.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public int UserId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
