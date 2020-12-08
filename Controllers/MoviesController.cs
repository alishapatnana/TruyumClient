using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using truYumClient.Models;

namespace truYumClient.Controllers
{
    public class MoviesController : Controller
    {
        public async Task<ActionResult> IndexAsync()
        {
            if (HttpContext.Session.GetString("token") == null)
            {
               // _log4net.Error("token not found");

                return RedirectToAction("Login", "Login");

            }
            //_log4net.Info("Http get request initiated for organization details");
            List<Movies> menuItems = new List<Movies>();
            using (var client = new HttpClient())
            {
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
                using (var response = await client.GetAsync("https://localhost:44392/api/Movies"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    menuItems = JsonConvert.DeserializeObject<List<Movies>>(apiResponse);
                }
            }
            return View(menuItems);
        }

        public ActionResult Test()
        {
            return View();
        }

        // GET: MovieController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MovieController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MovieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Movies menuItem)
        {
            try
            {
                if (HttpContext.Session.GetString("token") == null)
                {
                    //_log4net.Info("token not found");

                    return RedirectToAction("Login", "Login");

                }
                //_log4net.Info("http post request initiaited for posting organization");
                using (var httpclinet = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(menuItem), Encoding.UTF8, "application/json");
                    using (var response = await httpclinet.PostAsync("https://localhost:44392/api/Movies", content))
                    {

                        string apiResponse = await response.Content.ReadAsStringAsync();
                        menuItem = JsonConvert.DeserializeObject<Movies>(apiResponse);
                    }
                }
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: MovieController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MovieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }

        // GET: MovieController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MovieController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }
    }
}
