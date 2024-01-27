using HMS.Models;
using System.Collections.Generic;

namespace HMS.Services
{
    public interface IAppointmentService
    {
        List<Appointment> Get();
        Appointment Get(string id);
        Appointment Create(Appointment appointment);
        void Update(string id, Appointment appointment);
        void Remove(string id);
    }
}
