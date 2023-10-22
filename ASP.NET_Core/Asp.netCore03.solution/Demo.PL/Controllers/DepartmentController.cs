using Demo.BLL.Interfaces;
using Demo.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork UOW;

        //private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IUnitOfWork UOW/*IDepartmentRepository departmentRepository*/)
        {
            this.UOW = UOW;
        }

        // /Department/Index
        public async Task<IActionResult> Index(string searchText)
        {
            if (string.IsNullOrEmpty(searchText))
                return View(await UOW.DepartmentRepo.GetAllAsync());

            return View(UOW.DepartmentRepo.SearchByName(searchText));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Department d)
        {
            if (ModelState.IsValid)
            {
                UOW.DepartmentRepo.Create(d);
                await UOW.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(d);
        }

        public async Task<IActionResult> Details(int? Id, string viewName = "Details")
        {
            if (Id is null)
                return BadRequest(nameof(Id));

            var department = await UOW.DepartmentRepo.GetByIdAsync(Id.Value);
            if (department is null)
                return NotFound();
            return View(viewName, department);
        }

        public async Task<IActionResult> Update(int? Id)
        {
            ///if (Id is null)
            ///    return BadRequest(nameof(Id));
            ///
            ///var department = _departmentRepository.GetById(Id.Value);
            ///if (department is null)
            ///    return NotFound();
            ///return View(department);

            return await Details(Id, "Update");
        }

        ///[ValidateAntiForgeryToken]// to throw error once a foregin source try to access 
        [HttpPost]
        public async Task<IActionResult> Update([FromRoute] int id, Department d)
        {
            if (id != d.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                try
                {
                    UOW.DepartmentRepo.Update(d);
                    await UOW.CompleteAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e)
                {
                    ModelState.AddModelError(string.Empty, e.Message);

                }
            }
            return View(d);
        }

        public async Task<IActionResult> Delete(int Id)
        {
            return await Details(Id, "Delete");
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute] int id, Department d)
        {
            if (id != d.Id)
                return BadRequest();

            try
            {
                UOW.DepartmentRepo.Delete(d);
                await UOW.CompleteAsync();
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
