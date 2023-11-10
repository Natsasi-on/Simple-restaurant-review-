using Lab3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Lab3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            string xmlFilePath = Path.GetFullPath("Data/restaurant_reviews.xml");

            //create empty object 
            //we use restaurantData again in foreach so we should declare it here so it outside using 
            //it about the scope
            restaurant_reviews restaurantData;

            XmlSerializer serializor = new XmlSerializer(typeof(restaurant_reviews));

            using (FileStream fs = new FileStream(xmlFilePath, FileMode.Open))
            {
                restaurantData = (restaurant_reviews)serializor.Deserialize(fs);
            }

            var restaurantList = new List<RestaurantOverviewViewModel>();

            var id = 0;
            foreach(var restaurant in restaurantData.restaurant)
            {
                var restaurantViewModel = new RestaurantOverviewViewModel
                {
                   Id = id++,
                    Name = restaurant.restaurant_name,
                    FoodType = restaurant.food_type,
                    Rating = (decimal)restaurant.rating.Value,          
                    Cost = (decimal)restaurant.cost.Value,                 
                    City = restaurant.address.city,
                    ProvinceState = restaurant.address.province.ToString()
                };
                restaurantList.Add(restaurantViewModel);
            }

           
            return View(restaurantList);
        }

        public ActionResult Edit(int id)
        {

            //load xml to object
            string xmlFilePath = Path.GetFullPath("Data/restaurant_reviews.xml");
            restaurant_reviews restaurantData;
            XmlSerializer serializor = new XmlSerializer(typeof(restaurant_reviews));
            using (FileStream fs = new FileStream(xmlFilePath, FileMode.Open))
            {
                restaurantData = (restaurant_reviews)serializor.Deserialize(fs);
            }

            ///////////////////////////////////////

            var restaurant = restaurantData.restaurant[id];

            var restaurantEditViewModel = new RestaurantEditViewModel
            {

                Name = restaurant.restaurant_name,
                StreetAddress = restaurant.address.street,
                City = restaurant.address.city,
                ProvinceState = restaurant.address.province,
                PostalZipCode = restaurant.address.postal_code,
                Summary = restaurant.summary,
                Rating = (decimal)restaurant.rating.Value,

            };
            return View(restaurantEditViewModel);

        }
        [HttpPost]
        public IActionResult Edit(RestaurantEditViewModel rsVM)
        {
            if (ModelState.IsValid)
            {
                string xmlFilePath = Path.GetFullPath("Data/restaurant_reviews.xml");
                restaurant_reviews restaurantData;
                XmlSerializer serializor = new XmlSerializer(typeof(restaurant_reviews));
                using (FileStream fs = new FileStream(xmlFilePath, FileMode.Open))
                {
                    restaurantData = (restaurant_reviews)serializor.Deserialize(fs);
                }

                var restaurant = restaurantData.restaurant[rsVM.Id];

                restaurant.restaurant_name = rsVM.Name;
                restaurant.address.street = rsVM.StreetAddress;
                restaurant.address.city = rsVM.City;
                restaurant.address.province = rsVM.ProvinceState;
                restaurant.address.postal_code = rsVM.PostalZipCode;
                restaurant.summary = rsVM.Summary;
                restaurant.rating.Value = (byte)rsVM.Rating;

                using (FileStream fs =new FileStream(xmlFilePath, FileMode.Create))
                {
                    serializor.Serialize(fs, restaurantData);
                }

            }
            return RedirectToAction("Index");

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}