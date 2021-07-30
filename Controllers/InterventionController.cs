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
using Microsoft.AspNetCore.Authorization;

// reference https://www.yogihosting.com/aspnet-core-consume-api/

namespace RocketElevatorsCustomerPortal.Controllers
{
    [Authorize]
    public class InterventionController : Controller
    {
        public async Task<IActionResult> IndexAsync()
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.Buildings = await GetBuildings();
            mymodel.Batteries = await GetBatteries();
            mymodel.Columns = await GetColumns();
            mymodel.Elevators = await GetElevators();
            // mymodel.Customer = FetchCustomer(string email);
            return View(mymodel);
        }

        // CUSTOMERS
        //public async Task<IActionResult> Index()
        //{
        //    List<Customer> customerList = new List<Customer>();
        //    using (var httpClient = new HttpClient())
        //    {
        //        //HTTP GET request to the API
        //        using (var response = await httpClient.GetAsync("https://rocketapis.azurewebsites.net/api/interventions/pending"))
        //        {
        //            //data returned by the API is fetched from the code
        //            string apiResponse = await response.Content.ReadAsStringAsync();
        //            //Deserialize the JSON to a List type object
        //            customerList = JsonConvert.DeserializeObject<List<Customer>>(apiResponse);
        //        }
        //    }
        //    return View(customerList);
        //}

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
        
        //CUSTOMER LOGGED IN
        // public async Task<IEnumerable<Customer>> FetchCustomer(string email)
        public Customer FetchCustomer([FromRoute] string email)
        {
            using (var httpClient = new HttpClient())
            {
                //HTTP GET request to the API
                var result = httpClient.GetAsync("https://rocketapis.azurewebsites.net/api/customer/" + email)
                    .Result;
               //data returned by the API is fetched from the code
                    string apiResult = result.Content.ReadAsStringAsync().Result;
                    //Deserialize the JSON to a List type object
                    Customer customer = JsonConvert.DeserializeObject<Customer>(apiResult);
                    return customer;
            }
        }

    }
}