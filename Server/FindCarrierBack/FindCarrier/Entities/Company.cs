using FindCarrier.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FindCarrier.Entities
{
    public class Company
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string Website { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }

        public virtual ICollection<User> Users { get; set; }    
    }
}