using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SBAccountClient.Data;
using SBAccountClient.Models;

namespace SBAccountClient.Controllers
{
    public class AccountsController : Controller
    {
        private readonly SBAccountClientContext _context;

        public AccountsController(SBAccountClientContext context)
        {
            _context = context;
        }

        // GET: Accounts
        public async Task<ActionResult> Index()
        {
            string Baseurl = "http://localhost:29788/";
            var ProdInfo = new List<Account>();
            //HttpClient cl = new HttpClient();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/Accounts");
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api                     
                    var ProdResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    ProdInfo = JsonConvert.DeserializeObject<List<Account>>(ProdResponse);

                }
                //returning the employee list to view  
                return View(ProdInfo);
            }
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Account a)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(a), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("http://localhost:29788/api/Accounts", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var obj = JsonConvert.DeserializeObject<Account>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            Account sba = new Account();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:29788/api/Accounts/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    sba = JsonConvert.DeserializeObject<Account>(apiResponse);
                }
            }
            return View(sba);
        }
        public async Task<ActionResult> Delete(int id)
        {
            Account a = new Account();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:29788/api/Accounts/" +  id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    a = JsonConvert.DeserializeObject<Account>(apiResponse);
                }
            }
            return View(a);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(Account a)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("http://localhost:29788/api/Accounts/" + a.AccountNumber))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Edit(double AccountNumber)
        {
            Account a = new Account();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:29788/api/Accounts" +  AccountNumber))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    a = JsonConvert.DeserializeObject<Account>(apiResponse);
                }
            }
            return View(a);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(Account a)
        {
            Account b = new Account();
            using (var httpClient = new HttpClient())
            {
                StringContent content1 = new StringContent(JsonConvert.SerializeObject(a), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PutAsync("http://localhost:29788/api/Accounts" + a.AccountNumber, content1))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    b= JsonConvert.DeserializeObject<Account>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }
    }
}
