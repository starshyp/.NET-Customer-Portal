using System;
namespace RocketElevatorsCustomerPortal.Models
{
    public class Column
    {
        public long id { get; set; }
        public string ColumnType { get; set; }
        public int NbOfFloorsServed { get; set; }
        public string Status { get; set; }
        public string Info { get; set; }
        public string Notes { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public long battery_id { get; set; }
    }
}
