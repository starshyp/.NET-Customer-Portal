using System;
namespace RocketElevatorsCustomerPortal.Models
{
    public class Battery
    {
        public long id { get; set; }
        public string BType { get; set; }
        public string Status { get; set; }
        public DateTime DateOfCommissioning { get; set; }
        public DateTime DateOfLastInspection { get; set; }
        public string CertificateOfOperations { get; set; }
        public string Info { get; set; }
        public string Notes { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public long building_id { get; set; }
        public long employee_id { get; set; }
    }
}
