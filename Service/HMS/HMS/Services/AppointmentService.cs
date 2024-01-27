using HMS.Models;
using System.Collections.Generic;
using MongoDB.Driver;
using System;

namespace HMS.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IMongoCollection<Appointment> _appointments;

        public AppointmentService(IAppointmentDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _appointments = database.GetCollection<Appointment>(settings.AppointmentHMSCollectionName);
        }
        public Appointment Create(Appointment appointment)
        {
            _appointments.InsertOne(appointment);
            return appointment;
        }

        public List<Appointment> Get()
        {
            return _appointments.Find(appointment => true).ToList();
        }

        public Appointment Get(string id)
        {
            return _appointments.Find(appointment => appointment.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _appointments.DeleteOne(appointment => appointment.Id == id);
        }

        public void Update(string id, Appointment appointment)
        {
            _appointments.ReplaceOne(appointment => appointment.Id == id, appointment);
        }
    }
}
//using HMS.Models;
//using System.Collections.Generic;
//using MongoDB.Driver;

//namespace HMS.Services
//{
//    public class AppointmentService : IAppointmentService
//    {
//        private readonly IMongoCollection<Appointment> _appointments;

//        public AppointmentService(IAppointmentDatabaseSettings settings, IMongoClient mongoClient)
//        {
//            if (string.IsNullOrEmpty(settings.DatabaseName) || settings.DatabaseName.Contains(".") || settings.DatabaseName.Contains("\0"))
//            {
//                throw new System.ArgumentException("Invalid database name provided.", "settings.DatabaseName");
//            }

//            var database = mongoClient.GetDatabase(settings.DatabaseName);
//            _appointments = database.GetCollection<Appointment>(settings.AppointmentHMSCollectionName);
//        }

//        public Appointment Create(Appointment appointment)
//        {
//            _appointments.InsertOne(appointment);
//            return appointment;
//        }

//        public List<Appointment> Get()
//        {
//            return _appointments.Find(appointment => true).ToList();
//        }

//        public Appointment Get(string id)
//        {
//            return _appointments.Find(appointment => appointment.Id == id).FirstOrDefault();
//        }

//        public void Remove(string id)
//        {
//            _appointments.DeleteOne(appointment => appointment.Id == id);
//        }

//        public void Update(string id, Appointment appointment)
//        {
//            _appointments.ReplaceOne(appointment => appointment.Id == id, appointment);
//        }
//    }
//}
