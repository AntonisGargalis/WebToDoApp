using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebToDoApp.Data.Repo;
using WebToDoApp.Data.Repo.IRepo;
using WebToDoApp.Models;

namespace WebToDoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }        

        public IActionResult Index()
        {
            List<ToDo> objToDoList = _unitOfWork.ToDo.GetAll().ToList();
            return View(objToDoList); 
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
                TempData["success"] = "Category updated successfully";
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
