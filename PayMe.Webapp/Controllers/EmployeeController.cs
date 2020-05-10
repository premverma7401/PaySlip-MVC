using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using PayMe.Entity;
using PayMe.Services;
using PayMe.Webapp.Models;

namespace PayMe.Webapp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employee;
        private readonly IWebHostEnvironment _hostingenvironment;

        public EmployeeController(IEmployeeService employee, IWebHostEnvironment hostingEnvironment)
        {
            _employee = employee;
            _hostingenvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            var employees = _employee.GetAll().Select(employees => new EmployeeIndexViewModel
            {
                Id = employees.Id,
                EmpNumber = employees.EmpId,
                FullName = employees.FullName,
                City = employees.PersonalInfoEmployee.City,
                DateJoined = employees.PayInfoEmployee.DateJoined,
                Designation = employees.Designation,
                Gender = employees.Gender,
                ImageUrl = employees.ImageUrl
            }).ToList();
            return View(employees);
        }
        [HttpGet]

        public IActionResult Create()
        {
            var model = new EmployeeCreateViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken] // prevents cross site request forgery attack
        public async Task<IActionResult> Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View();
            }
            var employee = new Employee
            {
               // Id = model.Id,
               // EmpId = model.EmpId,
               // FirstName = model.FirstName,
               // LastName = model.LastName,
               // FullName = model.FullName,
               // Email = model.Email,
               //DateJoined = model.DateJoined,
               // DOB = model.DOB,
               // PaymentMethod = model.PaymentMethod,
               // StudentLoan = model.StudentLoan,
               // UnionMember = model.UnionMember,
               // City = model.City,
               // Address = model.Address,
               // Gender = model.Gender,
               // Designation = model.Designation,
               // MiddleName = model.MiddleName,
               // NSN = model.NSN,
               // PostCode = model.PostCode

            };

            if (model.ImageUrl != null && model.ImageUrl.Length > 0)
            {
                var uploadFol = @"images/employee";
                var fileName = Path.GetFileNameWithoutExtension(model.ImageUrl.FileName);
                var extension = Path.GetExtension(model.ImageUrl.FileName);
                var webRootPath = _hostingenvironment.WebRootPath;
                fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extension;
                var path = Path.Combine(webRootPath, uploadFol, fileName);
                await model.ImageUrl.CopyToAsync(new FileStream(path, FileMode.Create));
                employee.ImageUrl = "/" + uploadFol + "/" + fileName;

            }
            await _employee.CreateAsync(employee);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var employee = _employee.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            var model = new EmployeeEditViewModel()
            {
                Id = employee.Id,
                EmpId = employee.EmpId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                DateJoined = employee.PayInfoEmployee.DateJoined,
                DOB = employee.PersonalInfoEmployee.DOB,
                PaymentMethod = employee.PayInfoEmployee.PaymentMethod,
                StudentLoan = employee.PayInfoEmployee.StudentLoan,
                UnionMember = employee.PayInfoEmployee.UnionMember,
                City = employee.PersonalInfoEmployee.City,
                Address = employee.PersonalInfoEmployee.Address,
                Gender = employee.Gender,
                Phone = employee.PersonalInfoEmployee.Phone,
                Designation = employee.Designation,
                MiddleName = employee.MiddleName,
                NSN = employee.PersonalInfoEmployee.NSN,
                PostCode = employee.PersonalInfoEmployee.PostCode
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // prevents cross site request forgery attack

        public async Task<IActionResult> Edit(EmployeeEditViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View();
            }
            var employee = _employee.GetEmployeeById(model.Id);
            if (employee == null)
            {
                return NotFound();
            }
            employee.Id = model.Id;
            employee.EmpId = model.EmpId;
            employee.FirstName = model.FirstName;
            employee.LastName = model.LastName;
            employee.Email = model.Email;
            employee.PayInfoEmployee.DateJoined = model.DateJoined;
            employee.PersonalInfoEmployee.DOB = model.DOB;
            employee.PayInfoEmployee.PaymentMethod = model.PaymentMethod;
            employee.PayInfoEmployee.StudentLoan = model.StudentLoan;
            employee.PersonalInfoEmployee.Phone = model.Phone;
            employee.PayInfoEmployee.UnionMember = model.UnionMember;
            employee.PersonalInfoEmployee.City = model.City;
            employee.PersonalInfoEmployee.Address = model.Address;
            employee.Gender = model.Gender;
            employee.Designation = model.Designation;
            employee.MiddleName = model.MiddleName;
            employee.PersonalInfoEmployee.NSN = model.NSN;
            employee.PersonalInfoEmployee.PostCode = model.PostCode;

            if (model.ImageUrl != null && model.ImageUrl.Length > 0)
            {
                var uploadFol = @"images/employee";
                var fileName = Path.GetFileNameWithoutExtension(model.ImageUrl.FileName);
                var extension = Path.GetExtension(model.ImageUrl.FileName);
                var webRootPath = _hostingenvironment.WebRootPath;
                fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extension;
                var path = Path.Combine(webRootPath, uploadFol, fileName);
                await model.ImageUrl.CopyToAsync(new FileStream(path, FileMode.Create));
                employee.ImageUrl = "/" + uploadFol + "/" + fileName;
            }
            await _employee.UpdateAsync(employee);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detail(int id)
        {
            var employee = _employee.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            EmployeeDetailViewModel model = new EmployeeDetailViewModel()
            {
                Id = employee.Id,
                EmpId = employee.EmpId,
                FullName = employee.FullName,
                City = employee.PersonalInfoEmployee.City,
                DateJoined = employee.PayInfoEmployee.DateJoined,
                Designation = employee.Designation,
                Gender = employee.Gender,
                ImageUrl = employee.ImageUrl,
                Address = employee.PersonalInfoEmployee.Address,
                DOB = employee.PersonalInfoEmployee.DOB,
                Email = employee.Email,
                NSN = employee.PersonalInfoEmployee.NSN,
                PaymentMethod = employee.PayInfoEmployee.PaymentMethod,
                Phone = employee.PersonalInfoEmployee.Phone,
                ContractType = employee.PayInfoEmployee.ContractType,
                ContractedHours = employee.PayInfoEmployee.ContractedHours,
                HourlyRate = employee.PayInfoEmployee.HourlyRate,
                OverTimeRate = employee.PayInfoEmployee.OverTimeRate,
                IRD = employee.PayInfoEmployee.IRD,
                KiwiSaver = employee.PayInfoEmployee.KiwiSaver,
                PostCode = employee.PersonalInfoEmployee.PostCode,
                StudentLoan =employee.PayInfoEmployee.StudentLoan,
                UnionMember = employee.PayInfoEmployee.UnionMember

            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var employee = _employee.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            var model = new EmployeeDeleteViewModel()
            {
                Id = employee.Id,
                FullName = employee.FullName
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // prevents cross site request forgery attack

        public async Task<IActionResult> Delete(EmployeeDeleteViewModel model)
        {
            await _employee.Delete(model.Id);
            return RedirectToAction(nameof(Index));
        }

    }
}