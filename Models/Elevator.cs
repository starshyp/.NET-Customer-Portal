using System;
namespace RocketElevatorsCustomerPortal.Models
{
    public class Elevator
    {
        public long id { get; set; }
        public string SerialNumber { get; set; }
        public string Model { get; set; }
        public string ElevatorType { get; set; }
        public string Status { get; set; }
        public DateTime DateOfCommissioning { get; set; }
        public DateTime DateOfLastInspection { get; set; }
        public string CertificateOfInspection { get; set; }
        public string Info { get; set; }
        public string Notes { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int column_id { get; set; }
    }
}
