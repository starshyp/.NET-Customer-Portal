using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System.Net.Http;
using Newtonsoft.Json;
using RocketElevatorsCustomerPortal.Models;
using System.Dynamic;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace RocketElevatorsCustomerPortal.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        public async Task<IActionResult> IndexAsync()
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.Batteries = await GetBatteries();
            mymodel.Columns = await GetColumns();
            mymodel.Elevators = await GetElevators();
            mymodel.Customer = await GetAccount();
            mymodel.Address = await GetAddress();
            mymodel.Building = await GetBuildings();
            return View(mymodel);
        }
        
        // Customers
        public async Task<IEnumerable<Customer>> GetAccount()
        {
            List<Customer> customerList = new List<Customer>();
            using (var httpClient = new HttpClient())
            {
                //HTTP GET request to the API
                using (var response = await httpClient.GetAsync("https://rocketapis.azurewebsites.net/api/customer"))
                {
                    //data returned by the API is fetched from the code
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    //Deserialize the JSON to a List type object
                    customerList = JsonConvert.DeserializeObject<List<Customer>>(apiResponse);
                }
            }
            return customerList;
        }

        // Address
        public async Task<IEnumerable<Address>> GetAddress()
        {
            List<Address> addressList = new List<Address>();
            using (var httpClient = new HttpClient())
            {
                //HTTP GET request to the API
                using (var response = await httpClient.GetAsync("https://rocketapis.azurewebsites.net/api/address"))
                {
                    //data returned by the API is fetched from the code
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    //Deserialize the JSON to a List type object
                    addressList = JsonConvert.DeserializeObject<List<Address>>(apiResponse);
                }
            }
            return addressList;
        }
        
        // BUILDINGS
        public async Task<IEnumerable<Building>> GetBuildings()
        {
            List<Building> buildingList = new List<Building>();
            using (var httpClient = new HttpClient())
            {
                //HTTP GET request to the API
                using (var response = await httpClient.GetAsync("https://rocketapis.azurewebsites.net/api/building"))
                {
                    //data returned by the API is fetched from the code
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    //Deserialize the JSON to a List type object
                    buildingList = JsonConvert.DeserializeObject<List<Building>>(apiResponse);
                }
            }
            return buildingList;
        }

        // BATTERIES
        public async Task<IEnumerable<Battery>> GetBatteries()
        {
            List<Battery> batteryList = new List<Battery>();
            using (var httpClient = new HttpClient())
            {
                //HTTP GET request to the API
                using (var response = await httpClient.GetAsync("https://rocketapis.azurewebsites.net/api/batteries"))
                {
                    //data returned by the API is fetched from the code
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    //Deserialize the JSON to a List type object
                    batteryList = JsonConvert.DeserializeObject<List<Battery>>(apiResponse);
                }
            }
            return batteryList;
        }

        // COLUMNS
        public async Task<IEnumerable<Column>> GetColumns()
        {
            List<Column> columnList = new List<Column>();
            using (var httpClient = new HttpClient())
            {
                //HTTP GET request to the API
                using (var response = await httpClient.GetAsync("https://rocketapis.azurewebsites.net/api/columns"))
                {
                    //data returned by the API is fetched from the code
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    //Deserialize the JSON to a List type object
                    columnList = JsonConvert.DeserializeObject<List<Column>>(apiResponse);
                }
            }
            return columnList;
        }

        // ELEVATORS
        public async Task<IEnumerable<Elevator>> GetElevators()
        {
            List<Elevator> elevatorList = new List<Elevator>();
            using (var httpClient = new HttpClient())
            {
                //HTTP GET request to the API
                using (var response = await httpClient.GetAsync("https://rocketapis.azurewebsites.net/api/elevators"))
                {
                    //data returned by the API is fetched from the code
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    //Deserialize the JSON to a List type object
                    elevatorList = JsonConvert.DeserializeObject<List<Elevator>>(apiResponse);
                }
            }
            return elevatorList;
        }

        //Update Contact Info
         // public async Task<Customer> ModifyContactInfo(int id)
         public async Task<IActionResult> ModifyContactInfo(int id)
        {
            Customer customer = new Customer();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://rocketapis.azurewebsites.net/api/customer/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    customer = JsonConvert.DeserializeObject<Customer>(apiResponse);
                }
            }
            return View(customer);
        }
        
        // [HttpPost]
        // public async Task<Customer> ModifyContactInfo(Customer customer)
        // public async Task<IActionResult> ModifyContactInfo(Customer customer)
        // {
        //     Customer modifyCustomer = new Customer();
        //     using (var httpClient = new HttpClient())
        //     {
        //         var content = new MultipartFormDataContent();
        //         content.Add(new StringContent(customer.id.ToString()), "id");
        //         content.Add(new StringContent(customer.CompanyName), "CompanyName");
        //         content.Add(new StringContent(customer.NameOfContact), "NameOfContact");
        //         content.Add(new StringContent(customer.CompanyContactPhone), "CompanyContactPhone");
        //         content.Add(new StringContent(customer.EmailOfTheCompany), "EmailOfTheCompany");
        //         content.Add(new StringContent(customer.CompanyDescription), "CompanyDescription");
        //         content.Add(new StringContent(customer.NameOfServiceTechAuthority), "NameOfServiceTechAuthority");
        //         content.Add(new StringContent(customer.TechAuhtorityPhone), "TechAuhtorityPhone");
        //         content.Add(new StringContent(customer.TechManagerServiceEmail), "TechManagerServiceEmail");
        //
        //         using (var response = await httpClient.PutAsync("https://rocketapis.azurewebsites.net/api/customer", content))
        //         {
        //             string apiResponse = await response.Content.ReadAsStringAsync();
        //             ViewBag.Result = "Success";
        //             modifyCustomer = JsonConvert.DeserializeObject<Customer>(apiResponse);
        //         }
        //     }
        //     return View(modifyCustomer);
        // }

        // TESTING V2
        // public async Task<IActionResult> ModifyContactInfo(Customer customer)
        // {
        //     Customer modifyCustomer = new Customer();
        //     HttpClient client = new HttpClient();
        //     client.BaseAddress = new Uri("https://rocketapis.azurewebsites.net");
        //     client.DefaultRequestHeaders
        //         .Accept
        //         .Add(new MediaTypeWithQualityHeaderValue("application/json")); //ACCEPT header
        //
        //     HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "api/customer");
        //     Console.WriteLine(request);
        //     request.Content = new StringContent("{\"companyName\",\"nameOfContact\"}",
        //         Encoding.UTF8,
        //         "application/json"); //CONTENT-TYPE header
        //
        //     client.SendAsync(request)
        //         .ContinueWith(responseTask => { Console.WriteLine("Response: {0}", responseTask.Result); });
        //     
        //     return View(modifyCustomer);
        // }

        //Update Address Info
          public async Task<IActionResult> ModifyAddressInfo(int id)
        {
            Address address = new Address();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://rocketapis.azurewebsites.net/api/address/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    address = JsonConvert.DeserializeObject<Address>(apiResponse);
                }
            }
            return View(address);
        }
          
        //
        // [HttpPost]
        // public async Task<IActionResult> ModifyAddressInfo(Address address)
        // {
        //     Address modifyAddress = new Address();
        //     using (var httpClient = new HttpClient())
        //     {
        //         var content = new MultipartFormDataContent();
        //         content.Add(new StringContent(address.id.ToString()), "id");
        //         content.Add(new StringContent(address.TypeOfAddress), "TypeOfAddress");
        //         content.Add(new StringContent(address.Status), "Status");
        //         content.Add(new StringContent(address.Entity), "Entity");
        //         content.Add(new StringContent(address.NumberAndStreet), "NumberAndStreet");
        //         content.Add(new StringContent(address.Apt), "Apt");
        //         content.Add(new StringContent(address.City), "City");
        //         content.Add(new StringContent(address.PostalCode), "PostalCode");
        //         content.Add(new StringContent(address.Country), "Country");
        //         content.Add(new StringContent(address.Notes), "Notes");
        //
        //         using (var response = await httpClient.PutAsync("https://rocketapis.azurewebsites.net/api/address", content))
        //         {
        //             string apiResponse = await response.Content.ReadAsStringAsync();
        //             ViewBag.Result = "Success";
        //             modifyAddress = JsonConvert.DeserializeObject<Address>(apiResponse);
        //         }
        //     }
        //     return View(modifyAddress);
        // }
        
        public LocalRedirectResult LocalRedirect()  
        {  
            return LocalRedirect("/Intervention/Index");  
        }  

        
    }
}