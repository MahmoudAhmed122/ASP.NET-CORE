using AutoMapper;
using Demo.BLL.Interfaces;
using Demo.BLL.Repositories;
using Demo.DAL.Entities;
using Demo.Pl.Consts;
using Demo.Pl.Helper;
using Demo.Pl.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Pl.Controllers
{
    [Authorize]

    public class EmployeesController : Controller
    {

   
        public IMapper mapper { get; }
        public IUnitOfWork UnitOfWork { get; }

        public EmployeesController(IMapper mapper , IUnitOfWork unitOfWork)
        {
   
            this.mapper = mapper;
            UnitOfWork = unitOfWork;
        }


        public async Task<IActionResult> Index(string searchValue)
        {
            if (string.IsNullOrEmpty(searchValue)){      
            var employees = await UnitOfWork.employeeRepository.GetAll();
            var employeesViewModel = mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(employees);
                return View(employeesViewModel);
            }

            var SearchedEmployees = await UnitOfWork.employeeRepository.SearchByEmplyeeName(searchValue);
            var SearchedEmployeesViewModel = mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(SearchedEmployees);


            return View(SearchedEmployeesViewModel);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Departments = await UnitOfWork.departmentRepository.GetAll();
            return View("Form");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {  // Server Side Validation
                employeeViewModel.ImageName = DocumentSettings.UploadFile(employeeViewModel.Image, "images");
                var employee = mapper.Map<EmployeeViewModel, Employee>(employeeViewModel);
                await UnitOfWork.employeeRepository.Add(employee);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Departments = await UnitOfWork.departmentRepository.GetAll();

            return View("Form", employeeViewModel);

        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var employee = await UnitOfWork.employeeRepository.Get(id);
            if (employee is null)

                return NotFound();
            ViewBag.Departments = await UnitOfWork.departmentRepository.GetAll();
            var employeeViewModel =mapper.Map<Employee, EmployeeViewModel>(employee);

            return View(employeeViewModel);

        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var employee = await UnitOfWork.employeeRepository.Get(id);
            if (employee is null)

                return NotFound();
            ViewBag.Departments = await UnitOfWork.departmentRepository.GetAll();
            var employeeViewModel = mapper.Map<Employee, EmployeeViewModel>(employee);

            return View("Form", employeeViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EmployeeViewModel employeeViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Departments = await UnitOfWork.departmentRepository.GetAll();

                return View("Form", employeeViewModel);
            }
            employeeViewModel.ImageName = DocumentSettings.UploadFile(employeeViewModel.Image, "images");

            var employee = mapper.Map<EmployeeViewModel, Employee>(employeeViewModel);

            await UnitOfWork.employeeRepository.Update(employee);
            return RedirectToAction(nameof(Index), employeeViewModel);
        }
        [Authorize(Roles = Role.Admin)]

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            var employee = await UnitOfWork.employeeRepository.Get(id);
            if (employee is null)
                return NotFound();
            var employeeViewModel = mapper.Map<Employee, EmployeeViewModel>(employee);
            ViewBag.Departments = await UnitOfWork.departmentRepository.GetAll();

            return View(employeeViewModel);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(EmployeeViewModel employeeViewModel)
        {
         
            var employee = mapper.Map<EmployeeViewModel, Employee>(employeeViewModel);


            if (employeeViewModel.ImageName != null)
            {
                DocumentSettings.DeleteFile(employeeViewModel.ImageName, "images");

            }
            await UnitOfWork.employeeRepository.Delete(employee);
            return RedirectToAction(nameof(Index));
        }
    }
}
