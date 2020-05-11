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
                Designation = employees.Designation,
                ImageUrl = employees.ImageUrl,
                City = employees.PersonalInfoEmployee.City,
                Gender = employees.PersonalInfoEmployee.Gender,
                DateJoined = employees.PayInfoEmployee.DateJoined
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
                Id = model.Id,
                EmpId = model.EmpId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                FullName = model.FullName,
                Email = model.Email,
                Designation = model.Designation,
                MiddleName = model.MiddleName,
                PayInfoEmployee = new PayInfoEmployee
                {
                    DateJoined = model.DateJoined,
                    PaymentMethod = model.PaymentMethod,
                    StudentLoan = model.StudentLoan,
                    UnionMember = model.UnionMember,
                    IRD = model.IRD,
                    ContractedHours = model.ContractedHours,
                    ContractType = model.ContractType,
                    KiwiSaver = model.KiwiSaver,
                    HourlyRate = model.HourlyRate,
                    OverTimeRate = model.OverTimeRate,
                    PayCycle = model.PayCycle,
                    TaxCode = model.TaxCode
                },
                PersonalInfoEmployee = new PersonalInfoEmployee
                {
                    DOB = model.DOB,
                    NSN = model.NSN,
                    PostCode = model.PostCode,
                    City = model.City,
                    Address = model.Address,
                    Gender = model.Gender,
                    Phone = model.Phone
                }
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
                MiddleName = employee.MiddleName,
                LastName = employee.LastName,
                Email = employee.Email,
                Designation = employee.Designation,

                DOB = employee.PersonalInfoEmployee.DOB,
                City = employee.PersonalInfoEmployee.City,
                Address = employee.PersonalInfoEmployee.Address,
                Phone = employee.PersonalInfoEmployee.Phone,
                NSN = employee.PersonalInfoEmployee.NSN,
                PostCode = employee.PersonalInfoEmployee.PostCode,
                Gender = employee.PersonalInfoEmployee.Gender,

                DateJoined = employee.PayInfoEmployee.DateJoined,
                PaymentMethod = employee.PayInfoEmployee.PaymentMethod,
                StudentLoan = employee.PayInfoEmployee.StudentLoan,
                UnionMember = employee.PayInfoEmployee.UnionMember,
                ContractedHours = employee.PayInfoEmployee.ContractedHours,
                IRD = employee.PayInfoEmployee.IRD,
                ContractType = employee.PayInfoEmployee.ContractType,
                KiwiSaver = employee.PayInfoEmployee.KiwiSaver,
                HourlyRate = employee.PayInfoEmployee.HourlyRate,
                OverTimeRate = employee.PayInfoEmployee.OverTimeRate,
                PayCycle = employee.PayInfoEmployee.PayCycle,
                TaxCode = employee.PayInfoEmployee.TaxCode
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
            employee.Designation = model.Designation;
            employee.MiddleName = model.MiddleName;

            employee.PersonalInfoEmployee.DOB = model.DOB;
            employee.PersonalInfoEmployee.Phone = model.Phone;
            employee.PersonalInfoEmployee.City = model.City;
            employee.PersonalInfoEmployee.Address = model.Address;
            employee.PersonalInfoEmployee.Gender = model.Gender;
            employee.PersonalInfoEmployee.NSN = model.NSN;
            employee.PersonalInfoEmployee.PostCode = model.PostCode;

            employee.PayInfoEmployee.DateJoined = model.DateJoined;
            employee.PayInfoEmployee.PaymentMethod = model.PaymentMethod;
            employee.PayInfoEmployee.StudentLoan = model.StudentLoan;
            employee.PayInfoEmployee.UnionMember = model.UnionMember;
            employee.PayInfoEmployee.HourlyRate = model.HourlyRate;
            employee.PayInfoEmployee.IRD = model.IRD;
            employee.PayInfoEmployee.KiwiSaver = model.KiwiSaver;
            employee.PayInfoEmployee.OverTimeRate = model.OverTimeRate;
            employee.PayInfoEmployee.PayCycle = model.PayCycle;
            employee.PayInfoEmployee.TaxCode = model.TaxCode;

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
                ImageUrl = employee.ImageUrl,
                Designation = employee.Designation,
                Email = employee.Email,

                Gender = employee.PersonalInfoEmployee.Gender,
                Address = employee.PersonalInfoEmployee.Address,
                City = employee.PersonalInfoEmployee.City,
                DOB = employee.PersonalInfoEmployee.DOB,
                NSN = employee.PersonalInfoEmployee.NSN,
                PostCode = employee.PersonalInfoEmployee.PostCode,
                Phone = employee.PersonalInfoEmployee.Phone,

                ContractType = employee.PayInfoEmployee.ContractType,
                ContractedHours = employee.PayInfoEmployee.ContractedHours,
                HourlyRate = employee.PayInfoEmployee.HourlyRate,
                OverTimeRate = employee.PayInfoEmployee.OverTimeRate,
                IRD = employee.PayInfoEmployee.IRD,
                DateJoined = employee.PayInfoEmployee.DateJoined,
                PaymentMethod = employee.PayInfoEmployee.PaymentMethod,
                KiwiSaver = employee.PayInfoEmployee.KiwiSaver,
                StudentLoan = employee.PayInfoEmployee.StudentLoan,
                UnionMember = employee.PayInfoEmployee.UnionMember,
                TaxCode = employee.PayInfoEmployee.TaxCode

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