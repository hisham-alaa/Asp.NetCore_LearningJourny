using Demo.BLL.Interfaces;
using Demo.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Demo.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        //private readonly IDepartmentRepository departmentRepository;

        public EmployeeController(IEmployeeRepository employeeRepository /*,IDepartmentRepository departmentRepository*/)
        {
            _employeeRepository = employeeRepository;
            //this.departmentRepository = departmentRepository;
        }

        public IActionResult Index()
        {
            //ViewBag.Msg = "Hello world from employee";
            var AllEmployees = _employeeRepository.GetAll();

            return View(AllEmployees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            //ViewData["Department"] = departmentRepository.GetAll();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee e)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.Create(e);
                return RedirectToAction(nameof(Index));
            }
            return View(e);
        }

        public IActionResult Details(int? Id, string viewName = "Details")
        {
            //TempData["curruntAction"] = viewName;
            //ViewData["Department"] = departmentRepository.GetAll();

            if (Id is null)
                return BadRequest(nameof(Id));

            var employee = _employeeRepository.GetById(Id.Value);
            if (employee is null)
                return NotFound();
            return View(viewName, employee);
        }

        public IActionResult Update(int? Id)
        {
            //ViewData["Department"] = departmentRepository.GetAll();

            return Details(Id, "Update");
        }

        ///[ValidateAntiForgeryToken]// to throw error once a foregin source try to access 
        [HttpPost]
        public IActionResult Update([FromRoute] int id, Employee e)
        {
            if (id != e.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                try
                {
                    _employeeRepository.Update(e);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);

                }
            }
            return View(e);
        }

        public IActionResult Delete(int Id)
        {
            //ViewData["Department"] = departmentRepository.GetAll();

            return Details(Id, "Delete");
        }

        [HttpPost]
        public IActionResult Delete([FromRoute] int id, Employee e)
        {
            if (id != e.Id)
                return BadRequest();

            try
            {
                _employeeRepository.Delete(e);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(e);
        }

    }
}
