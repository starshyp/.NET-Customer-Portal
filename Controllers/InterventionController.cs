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

// reference https://www.yogihosting.com/aspnet-core-consume-api/

namespace RocketElevatorsCustomerPortal.Controllers
{
    public class InterventionController : Controller
    {
        public async Task<IActionResult> IndexAsync()
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.Buildings = await GetBuildings();
            mymodel.Batteries = await GetBatteries();
            mymodel.Columns = await GetColumns();
            mymodel.Elevators = await GetElevators();
            return View(mymodel);
        }
        //// GET: /<controller>/
        //public async Task<IActionResult> Index()
        //{
        //    List<Reservation> reservationList = new List<Reservation>();
        //    using (var httpClient = new HttpClient())
        //    {
        //        //HTTP GET request to the API
        //        using (var response = await httpClient.GetAsync("https://localhost:44324/api/Reservation"))
        //        {
        //            //data returned by the API is fetched from the code
        //            string apiResponse = await response.Content.ReadAsStringAsync();
        //            //Deserialize the JSON to a List type object
        //            reservationList = JsonConvert.DeserializeObject<List<Reservation>>(apiResponse);
        //        }
        //    }
        //    return View(reservationList);
        //}

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
        ////CUSTOMER LOGGED IN
        //public async Task<IEnumerable<Customer>> FetchCustomer()
        //{
        //    using (var httpClient = new HttpClient())
        //    {
        //        //HTTP GET request to the API
        //        using (var response = await httpClient.GetAsync("https://rocketapis.azurewebsites.net/api/customer"))
        //        {
        //            //data returned by the API is fetched from the code
        //            string apiResponse = await response.Content.ReadAsStringAsync();
        //            //Deserialize the JSON to a List type object
        //            Customer customer = JsonConvert.DeserializeObject<Customer>(apiResponse);

        //        }
        //    }
        //    return customer;
        //}
    }
}