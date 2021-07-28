using System;
namespace RocketElevatorsCustomerPortal.Models
{
    public class Building
    {
        public long id { get; set; }
        public string FullNameOfTheBuildingAdministrator { get; set; }
        public string EmailOfTheAdministratorOfTheBuilding { get; set; }
        public string PhoneNumberOfTheBuildingAdministrator { get; set; }
        public string FullNameOfTheTechContactForTheBuilding { get; set; }
        public string TechContactEmail { get; set; }
        public string TechContactPhone { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public long customer_id { get; set; }
        public long address_id { get; set; }
    }
}
