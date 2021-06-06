using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductClient.Data;
using ProductClient.Models;

namespace ProductClient.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductClientContext _context;

        public ProductController(ProductClientContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<ActionResult> Index()
        {
            string Baseurl = "http://localhost:16748/";
            var ProdInfo = new List<Product>();
            //HttpClient cl = new HttpClient();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/Blogs");
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api                     
                    var ProdResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    ProdInfo = JsonConvert.DeserializeObject<List<Product>>(ProdResponse);

                }
                //returning the employee list to view  
                return View(ProdInfo);
            }
        }

        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Product p)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(p), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("http://localhost:16748/api/Blogs/", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var obj = JsonConvert.DeserializeObject<Product>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Details(int id)
        {
            Product p = new Product();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:16748/api/Blogs/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    p = JsonConvert.DeserializeObject<Product>(apiResponse);
                }
            }
            return View(p);
        }

        public async Task<ActionResult> Delete(int id)
        {
            Product p = new Product();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:16748/api/Blogs/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    p = JsonConvert.DeserializeObject<Product>(apiResponse);
                }
            }
            return View(p);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(Product p)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("http://localhost:16748/api/Blogs/" + p.BlogId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Edit(int id)
        {
            Product p = new Product();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:16748/api/Blogs/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    p = JsonConvert.DeserializeObject<Product>(apiResponse);
                }
            }
            return View(p);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(Product p)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content1 = new StringContent(JsonConvert.SerializeObject(p), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PutAsync("http://localhost:16748/api/Blogs/"+ p.BlogId, content1))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    p = JsonConvert.DeserializeObject<Product>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }

    }
}
    


