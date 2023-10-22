using AutoMapper;
using Demo.BLL.Interfaces;
using Demo.BLL.Repositories;
using Demo.DAL.Models;
using Demo.PL.helpers;
using Demo.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork UOF;

        //private readonly IEmployeeRepository _employeeRepository;
        //private readonly IDepartmentRepository departmentRepository;

        public EmployeeController(IMapper mapper, IUnitOfWork UOF) /*IEmployeeRepository employeeRepository),IDepartmentRepository departmentRepository*/
        {
            this.mapper = mapper;
            this.UOF = UOF;
            //this.departmentRepository = departmentRepository;
        }

        public async Task<IActionResult> Index(string searchText)
        {
            //ViewBag.Msg = "Hello world from employee";
            var AllEmployees = string.IsNullOrEmpty(searchText) ?
                                await UOF.EmployeeRepo.GetAllAsync() :
                                UOF.EmployeeRepo.SearchByName(searchText);

            var AllEmpsVM = mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(AllEmployees);

            return View(AllEmpsVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            //ViewData["Department"] = departmentRepository.GetAll();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeViewModel employeeVM)
        {
            if (ModelState.IsValid)
            {
                employeeVM.ImageName = DocumentSettings.UploadFile(employeeVM.ImageFile, "Images");
                var mappedEmp = mapper.Map<EmployeeViewModel, Employee>(employeeVM);
                UOF.EmployeeRepo.Create(mappedEmp);
                await UOF.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeVM);
        }

        public async Task<IActionResult> Details(int? Id, string viewName = "Details")
        {
            //TempData["curruntAction"] = viewName;
            //ViewData["Department"] = departmentRepository.GetAll();

            if (Id is null)
                return BadRequest(nameof(Id));

            var employee = mapper.Map<Employee, EmployeeViewModel>(await UOF.EmployeeRepo.GetByIdAsync(Id.Value));

            if (employee is null)
                return NotFound();
            return View(viewName, employee);
        }

        public async Task<IActionResult> Update(int? Id)
        {
            //ViewData["Department"] = departmentRepository.GetAll();

            return await Details(Id, "Update");
        }

        ///[ValidateAntiForgeryToken]// to throw error once a foregin source try to access 
        [HttpPost]
        public async Task<IActionResult> Update([FromRoute] int id, EmployeeViewModel employeeVM)
        {
            if (id != employeeVM.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                var curImg = employeeVM.ImageName ?? "";
                employeeVM.ImageName = (employeeVM.ImageFile is null) ?
                                        curImg :
                                        DocumentSettings.UploadFile(employeeVM.ImageFile, "Images");

                var mappedEmp = mapper.Map<EmployeeViewModel, Employee>(employeeVM);

                try
                {
                    UOF.EmployeeRepo.Update(mappedEmp);
                    if (await UOF.CompleteAsync() > 0 && mappedEmp.ImageName != curImg)
                        DocumentSettings.DeleteFile(curImg, "Images");

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(employeeVM);
        }

        public async Task<IActionResult> Delete(int Id)
        {
            //ViewData["Department"] = departmentRepository.GetAll();

            return await Details(Id, "Delete");
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute] int id, EmployeeViewModel employeeVM)
        {
            try
            {
                var mappedEmp = mapper.Map<EmployeeViewModel, Employee>(employeeVM);
                UOF.EmployeeRepo.Delete(mappedEmp);
                var numAffected = await UOF.CompleteAsync();
                if (numAffected > 0 && !string.IsNullOrEmpty(mappedEmp.ImageName))
                    DocumentSettings.DeleteFile(mappedEmp.ImageName, "Images");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(employeeVM);
        }

    }
}
