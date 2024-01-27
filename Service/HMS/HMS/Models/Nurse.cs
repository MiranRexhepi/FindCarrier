using System;

namespace HMS.Models
{
    public class Nurse
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string NrTel { get; set; }
        public string Role { get; set; }
        //public DateTime DataCreated { get; set; }
    }
}