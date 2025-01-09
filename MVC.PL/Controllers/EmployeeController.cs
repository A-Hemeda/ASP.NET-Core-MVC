using MVC.BLL.Interfaces;
using MVC.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using MVC.PL.Models;
using AutoMapper;
using MVC.PL.Helper;
using MVC.BLL.Repositories;

namespace MVC.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeController(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IActionResult Index(string SearchValue ="")
        {
            IEnumerable<Employee> employees;
            IEnumerable<EmployeeViewModel> mappedemployees;
            if (string.IsNullOrEmpty(SearchValue))
            {
                employees = _unitOfWork.EmployeeRepository.GetAll();
                mappedemployees = _mapper.Map<IEnumerable<EmployeeViewModel>>(employees);
            }
            else
            {
                employees = _unitOfWork.EmployeeRepository.Search(SearchValue);
                mappedemployees = _mapper.Map<IEnumerable<EmployeeViewModel>>(employees);
            }
            return View(mappedemployees);
        }

        public IActionResult Create()
        {
            ViewBag.Departments = _unitOfWork.DepartmentRepository.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeVM)
        {
            //ModelState["Department"].ValidationState = ModelValidationState.Valid;
            //employee.Department = _unitOfWork.DepartmentRepository.GetById(employee.DepartmentId);
            if (ModelState.IsValid)
            {
                var employee = _mapper.Map<Employee>(employeeVM);
                employee.ImageUrl = Documentsettings.UploudFile(employeeVM.Image, "Images");
                _unitOfWork.EmployeeRepository.Add(employee);
                return RedirectToAction("Index");
            }
            ViewBag.Departments = _unitOfWork.DepartmentRepository.GetAll();

            return View(employeeVM);
        }

        public IActionResult Details(int? id)
        {
            if (id is null)
                return NotFound();

            var employee = _unitOfWork.EmployeeRepository.GetById(id);
            var mappeddeemployee = _mapper.Map<EmployeeViewModel>(employee);

            if (employee is null)
                return NotFound();
            return View(mappeddeemployee);
        }



        #region update
        [HttpGet]
        public IActionResult Update(int? id)
        {

            ViewBag.departments = _unitOfWork.DepartmentRepository.GetAll();

            if (id is null)
                return NotFound();


            var employee = _unitOfWork.EmployeeRepository.GetById(id);
            var mappedEmployee = _mapper.Map<Employee, EmployeeViewModel>(employee);
            if (employee == null)
                return NotFound();


            return View(mappedEmployee);
        }
        [HttpPost]
        public IActionResult Update(int id, EmployeeViewModel employeeVM)
        {

            Department department = _unitOfWork.DepartmentRepository.GetById(employeeVM.DepartmentId);

            if (id != employeeVM.Id)
                return NotFound();

            try
            {
                Employee employee = _mapper.Map<EmployeeViewModel, Employee>(employeeVM);

                if (employeeVM.Image == null)
                {
                    employee.ImageUrl = employeeVM.ImageUrl;
                }

                else
                {
                    Documentsettings.DeleteFile("Images", employeeVM.ImageUrl);
                    employee.ImageUrl = Documentsettings.UploudFile(employeeVM.Image, "Images");
                }


                employee.Department = department;

                _unitOfWork.EmployeeRepository.Update(employee);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return (View(employeeVM));
        }


        
            #endregion
        public IActionResult Delete(int? id)
        {
            if (id is null)
                return NotFound();

            var employee = _unitOfWork.EmployeeRepository.GetById(id);
            var mappedemployee =_mapper.Map<EmployeeViewModel>(employee);
            if (mappedemployee.ImageUrl != null)
                Documentsettings.DeleteFile("Images", mappedemployee.ImageUrl);
            if (mappedemployee is null)
                return NotFound();

            _unitOfWork.EmployeeRepository.Delete(employee);

            return RedirectToAction("Index");
        }

        
    }
}
