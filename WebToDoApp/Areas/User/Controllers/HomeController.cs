using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebToDoApp.Areas.User.Data.Repo.IRepo;
using WebToDoApp.Areas.User.Models;


namespace WebToDoApp.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration; // apsettings

        public HomeController(UserManager<IdentityUser> userManager, ILogger<HomeController> logger, IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _configuration = configuration; 
        }

        public IActionResult Index()
        {

            var userId = _userManager.GetUserId(User);
            if (User.Identity.IsAuthenticated)
            {
                
                List<ToDo> objToDoList  = _unitOfWork.ToDo.GetAll(u => u.UserId == userId).ToList(); 

                return View(objToDoList);
            }
            else
            {
                return View();
            }

        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ToDo obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ToDo.Add(obj); // add the object of new category to the database
                _unitOfWork.Save();       // save and update the changes
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");  // redirect to category list
            }
            return View();
        }

        public IActionResult Detail(int? id)
        {
            var accuWeatherApiKey = _configuration["ACCUWEATHER"];
            var googleMapsApiKey = _configuration["GOOGLE_MAPS"];

            // Pass values to the view using ViewBag
            ViewBag.AccuWeatherApiKey = accuWeatherApiKey;
            ViewBag.GoogleMapsApiKey = googleMapsApiKey;
            if (id == null || id == 0)
            {
                return NotFound();
            }
            ToDo? todoFromDv = _unitOfWork.ToDo.Get(u => u.Id == id);
            if (todoFromDv == null)
            {
                return NotFound();
            }
            return View(todoFromDv);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            ToDo? todoFromDv = _unitOfWork.ToDo.Get(u => u.Id == id);
            if (todoFromDv == null)
            {
                return NotFound();
            }
            return View(todoFromDv);
        }
        [HttpPost]
        public IActionResult Edit(ToDo obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ToDo.Update(obj); // add the object of new category to the database
                _unitOfWork.Save();       // save and update the changes
                TempData["success"] = "Activity updated successfully";
                return RedirectToAction("Index");  // redirect to category list
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            ToDo? todoFromDv = _unitOfWork.ToDo.Get(u => u.Id == id);
            if (todoFromDv == null)
            {
                return NotFound();
            }
            return View(todoFromDv);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            ToDo? obj = _unitOfWork.ToDo.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.ToDo.Remove(obj);
            _unitOfWork.Save();       // save and update the changes
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");  // redirect to category list
        }
        public IActionResult Privacy()
        {
            return View();
        }

    }
}
