using MVC.BLL.Interfaces;
using MVC.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MVC.PL.Models;

namespace MVC.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentController(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            IEnumerable<DepartmentViewModel> mappeddepartments;

            var departments = _unitOfWork.DepartmentRepository.GetAll();
            mappeddepartments = _mapper.Map<IEnumerable<DepartmentViewModel>>(departments);
            return View(mappeddepartments);
        }
        //Get
        public IActionResult Create()
        {
            return View();
        }
        //Post
        [HttpPost]
        public IActionResult Create(DepartmentViewModel departmentVM)
        {
            if(ModelState.IsValid)
            {
                var department = _mapper.Map<Department>(departmentVM);
                _unitOfWork.DepartmentRepository.Add(department);
                return RedirectToAction("Index");
            }
            return View(departmentVM);
        }

        public IActionResult Details(int? id)
        {
            if (id is null)
                return NotFound();

            var department = _unitOfWork.DepartmentRepository.GetById(id);
            var mappeddepartments = _mapper.Map<DepartmentViewModel>(department);

            if (department is null)
                return NotFound(); 
            return View(mappeddepartments);
        }

        public IActionResult Update(int? id)
        {
            if (id is null)
                return NotFound();

            var department = _unitOfWork.DepartmentRepository.GetById(id);
            var mappeddepartments = _mapper.Map<DepartmentViewModel>(department);

            if (department is null)
                return NotFound();

            return View(mappeddepartments);
        }

        [HttpPost]
        public IActionResult Update(int id, DepartmentViewModel departmentVM)
        {
            
            if (id != departmentVM.Id)
                return NotFound();

            try
            {
                if (ModelState.IsValid)
                {
                    var department = _mapper.Map<Department>(departmentVM);
                    _unitOfWork.DepartmentRepository.Update(department);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return View(departmentVM);
        }

        public IActionResult Delete(int? id)
        {
            if (id is null)
                return NotFound();

            var department = _unitOfWork.DepartmentRepository.GetById(id);
            _mapper.Map<DepartmentViewModel>(department);

            if (department is null)
                return NotFound();

            _unitOfWork.DepartmentRepository.Delete(department);

            return RedirectToAction("Index");
        }

    }
}
