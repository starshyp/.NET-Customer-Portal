using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RocketElevatorsCustomerPortal.Models
{
    public class Customer
    {
        public long id { get; set; }
        public string CompanyName { get; set; }
        public string NameOfContact { get; set; }
        public string CompanyContactPhone { get; set; }
        public string EmailOfTheCompany { get; set; }
        public string CompanyDescription { get; set; }
        public string NameOfServiceTechAuthority { get; set; }
        public string TechAuhtorityPhone { get; set; }
        public string TechManagerServiceEmail { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public long user_id { get; set; }
        public long address_id { get; set; }
    }
}