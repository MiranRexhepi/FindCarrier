namespace HMS.Models
{
    public interface IAppointmentDatabaseSettings
    {
        string AppointmentHMSCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
