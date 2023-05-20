using AutoMapper;
using Demo.BLL.Interfaces;
using Demo.DAL.Entities;
using Demo.Pl.Consts;
using Demo.Pl.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Pl.Controllers
{
    [Authorize]
    public class DepartmentsController : Controller
    {
        public IUnitOfWork UnitOfWork { get; }
        public IMapper mapper { get; }

       public DepartmentsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index(string SearchValue)
        {
            if (string.IsNullOrEmpty(SearchValue)) {
             var departments = await UnitOfWork.departmentRepository.GetAll();
            var departmentsViewModel = mapper.Map<IEnumerable<Department> , IEnumerable<DepartmentViewModel>>(departments);
            return View(departmentsViewModel);

            }
           
            var SearchedDepartments=await UnitOfWork.departmentRepository.SearchByDepartmentName(SearchValue);
            var SearchedDepartmentsViewModel= mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentViewModel>>(SearchedDepartments);
            return View(SearchedDepartmentsViewModel);

        }
        public IActionResult Create()
        {

            return View("Form");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DepartmentViewModel departmentViewModel)
        {
            if (ModelState.IsValid)
            {  // Server Side Validation
                var department = mapper.Map<DepartmentViewModel, Department>(departmentViewModel);
                await UnitOfWork.departmentRepository.Add(department);
                return RedirectToAction(nameof(Index));
            }

            return View("Form", departmentViewModel);

        }
        public  async Task <IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var department = await UnitOfWork.departmentRepository.Get(id);
            if (department is null)

                return NotFound();
            var departmentViewModel = mapper.Map<Department, DepartmentViewModel>(department);

            return View(departmentViewModel);

        }
        public async Task <IActionResult> Edit(int? id) {

            if (id == null)
                return NotFound();

            var department = await UnitOfWork.departmentRepository.Get(id);
            if (department is null)

                return NotFound();
            var departmentViewModel = mapper.Map<Department, DepartmentViewModel>(department);

            return View("Form", departmentViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Edit(DepartmentViewModel departmentViewModel)
        {
            if (!ModelState.IsValid) {
                return View("Form", departmentViewModel);
            }
            var department = mapper.Map<DepartmentViewModel, Department>(departmentViewModel);

            await UnitOfWork.departmentRepository.Update(department);
            return RedirectToAction(nameof(Index) , departmentViewModel);     
        }
        public async Task<IActionResult> Delete(int? id) {
            if (id == null)
                return NotFound();
            var department = await UnitOfWork.departmentRepository.Get(id);
            if(department is null)
                return NotFound();
            var departmentViewModel = mapper.Map<Department, DepartmentViewModel>(department);

            return View(departmentViewModel);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DepartmentViewModel departmentViewModel) {
            var department = mapper.Map<DepartmentViewModel, Department>(departmentViewModel);


           await UnitOfWork.departmentRepository.Delete(department);
            return RedirectToAction(nameof(Index));
        }

    }
}
