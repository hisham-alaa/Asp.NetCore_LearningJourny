using Demo.BLL.Interfaces;
using Demo.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Demo.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        // /Department/Index
        public IActionResult Index()
        {
            var AllDepartments = _departmentRepository.GetAll();

            return View(AllDepartments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department d)
        {
            if (ModelState.IsValid)
            {
                _departmentRepository.Create(d);
                return RedirectToAction(nameof(Index));
            }
            return View(d);
        }

        public IActionResult Details(int? Id, string viewName = "Details")
        {
            if (Id is null)
                return BadRequest(nameof(Id));

            var department = _departmentRepository.GetById(Id.Value);
            if (department is null)
                return NotFound();
            return View(viewName, department);
        }

        public IActionResult Update(int? Id)
        {
            ///if (Id is null)
            ///    return BadRequest(nameof(Id));
            ///
            ///var department = _departmentRepository.GetById(Id.Value);
            ///if (department is null)
            ///    return NotFound();
            ///return View(department);

            return Details(Id, "Update");
        }

        ///[ValidateAntiForgeryToken]// to throw error once a foregin source try to access 
        [HttpPost]
        public IActionResult Update([FromRoute] int id, Department d)
        {
            if (id != d.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                try
                {
                    _departmentRepository.Update(d);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e)
                {
                    ModelState.AddModelError(string.Empty, e.Message);

                }
            }
            return View(d);
        }

        public IActionResult Delete(int Id)
        {
            return Details(Id, "Delete");
        }

        [HttpPost]
        public IActionResult Delete([FromRoute] int id, Department d)
        {
            if (id != d.Id)
                return BadRequest();

            try
            {
                _departmentRepository.Delete(d);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
            }
            return View(d);
        }

    }
}
