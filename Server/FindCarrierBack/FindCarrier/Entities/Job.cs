using FindCarrier.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FindCarrier.Domain.Entities
{
    [Table("Jobs")]
    public class Job
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string JobPosition { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime Deadline { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        [Required]
        [ForeignKey("JobType")]
        public int JobTypeId { get; set; }

        public virtual JobType JobType { get; set; }    

        [Required]
        [ForeignKey("Company")]
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}