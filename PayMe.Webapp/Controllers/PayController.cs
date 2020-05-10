using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PayMe.Entity;
using PayMe.Services;
using PayMe.Webapp.Models;
using RotativaCore;

namespace PayMe.Webapp.Controllers
{
    public class PayController : Controller
    {
        private readonly IPayService _pay;
        private readonly IEmployeeService _employee;
        private readonly ITaxService _tax;
        private readonly IKiwiSaverService _kiwisaver;
        private decimal overtimeHours;
        private decimal overtimeEarnings;
        private decimal contractedEarnings;
        private decimal unionFee;
        private decimal totalEarnings;
        private decimal totalDeduction;
        private decimal studentLoanRepay;
        private decimal taxCount;
        private decimal kiwiSave;

        public PayController(IPayService pay, IEmployeeService employee, ITaxService tax, IKiwiSaverService kiwiSaver)
        {
            _pay = pay;
            _employee = employee;
            _tax = tax;
            _kiwisaver = kiwiSaver;
        }
        public IActionResult Index()
        {
            var payRecord = _pay.GetAll().Select(pay => new PayIndexViewModel()
            {
                Id = pay.Id,
                EmployeeId = pay.EmployeeId,
                Employee = pay.Employee,
                PayDate = pay.PayDate,
                TotalDeduction = pay.TotalDeduction,
                FullName = pay.FullName,
                NetPayment = pay.NetPayment,
                PayMonth = pay.PayMonth,
                Year = _pay.GetTaxYearById(pay.TaxYearId).YearOfTax,
                TaxYearId = pay.TaxYearId,
                TotalEarnings = pay.TotalEarnings

            });
            return View(payRecord);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.employees = _employee.EmployeeList();
            ViewBag.taxYears = _pay.GetAllTaxYears();
            var model = new PayCreateViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken] // prevents cross site request forgery attack

        public async Task<IActionResult> Create(PayCreateViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                ViewBag.employees = _employee.EmployeeList();
                ViewBag.taxYears = _pay.GetAllTaxYears();
                return View();
            }
            var payRecord = new PaymentRecord()
            {
                Id = model.Id,
                EmployeeId = model.EmployeeId,
                Employee = model.Employee,
                PayDate = model.PayDate,
                ContractedHours = model.ContractedHours,
                HourlyRate = model.HourlyRate,
                HoursWorked = model.HoursWorked,
                PayMonth = model.PayMonth,
                TaxYearId = model.TaxYearId,
                TaxCode = model.TaxCode,

                FullName = _employee.GetEmployeeById(model.EmployeeId).FullName,
                Nino = _employee.GetEmployeeById(model.EmployeeId).PersonalInfoEmployee.NSN,

                OverTimeHours = overtimeHours = _pay.OverTimeHours(model.HoursWorked, model.ContractedHours),
                ContractedEarnings = contractedEarnings = _pay.ContractualEarnings(model.HoursWorked, model.ContractedHours, model.HourlyRate),
                OverTimeEarnings = overtimeEarnings = _pay.OverTimeEarnings(_pay.OverTimeRate(model.HourlyRate), overtimeHours),
                TotalEarnings = totalEarnings = _pay.TotalEarnings(overtimeEarnings, contractedEarnings),
                StudentLoanRepay = studentLoanRepay = _employee.StudentLoanRepay(model.EmployeeId, totalEarnings),
                UnionFee = unionFee = _employee.UnionFees(model.EmployeeId),
                KiwiSaver = kiwiSave = _kiwisaver.KiwiSaverDeduction(totalEarnings),
                Tax = taxCount = _tax.TaxAmount(totalEarnings),
                TotalDeduction = totalDeduction = _pay.TotalDeductions(taxCount, kiwiSave, studentLoanRepay, unionFee),
                NetPayment = _pay.NetPay(totalEarnings, totalDeduction)
                               

            };
            await _pay.CreateAsync(payRecord);
            return RedirectToAction(nameof(Index));


        }

        public IActionResult Detail(int id)
        {
            var paymentRecord = _pay.GetById(id);
            if (paymentRecord == null)
            {
                return NotFound();
            }
            var model = new PayDetailViewModel()
            {
                Id = paymentRecord.Id,
                PayDate = paymentRecord.PayDate,
                FullName = paymentRecord.FullName,
                UnionFee = paymentRecord.UnionFee,
                ContractedEarnings = paymentRecord.ContractedEarnings,
                TotalDeduction = paymentRecord.TotalDeduction,
                ContractedHours = paymentRecord.ContractedHours,
                Employee = paymentRecord.Employee,
                EmployeeId = paymentRecord.EmployeeId,
                HourlyRate = paymentRecord.HourlyRate,
                HoursWorked = paymentRecord.HoursWorked,
                KiwiSaver = paymentRecord.KiwiSaver,
                NetPayment = paymentRecord.NetPayment,
                StudentLoanRepay = paymentRecord.StudentLoanRepay,
                Nino = paymentRecord.Nino,
                OverTimeEarnings = paymentRecord.OverTimeEarnings,
                OverTimeHours = paymentRecord.OverTimeHours,
                OverTimeRate = _pay.OverTimeRate(paymentRecord.HourlyRate),
                PayMonth=paymentRecord.PayMonth,
                Tax=paymentRecord.Tax,
                Year=_pay.GetTaxYearById(paymentRecord.TaxYearId).YearOfTax,
                TaxYear = paymentRecord.TaxYear,
                TaxCode=paymentRecord.TaxCode,
                TaxYearId=paymentRecord.TaxYearId,
                TotalEarnings=paymentRecord.TotalEarnings
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult PaySlip(int id)
        {
            var paymentRecord = _pay.GetById(id);
            if (paymentRecord == null)
            {
                return NotFound();
            }
            var model = new PayDetailViewModel()
            {
                Id = paymentRecord.Id,
                PayDate = paymentRecord.PayDate,
                FullName = paymentRecord.FullName,
                UnionFee = paymentRecord.UnionFee,
                ContractedEarnings = paymentRecord.ContractedEarnings,
                TotalDeduction = paymentRecord.TotalDeduction,
                ContractedHours = paymentRecord.ContractedHours,
                Employee = paymentRecord.Employee,
                EmployeeId = paymentRecord.EmployeeId,
                HourlyRate = paymentRecord.HourlyRate,
                HoursWorked = paymentRecord.HoursWorked,
                KiwiSaver = paymentRecord.KiwiSaver,
                NetPayment = paymentRecord.NetPayment,
                StudentLoanRepay = paymentRecord.StudentLoanRepay,
                Nino = paymentRecord.Nino,
                OverTimeEarnings = paymentRecord.OverTimeEarnings,
                OverTimeHours = paymentRecord.OverTimeHours,
                OverTimeRate = _pay.OverTimeRate(paymentRecord.HourlyRate),
                PayMonth = paymentRecord.PayMonth,
                Tax = paymentRecord.Tax,
                Year = _pay.GetTaxYearById(paymentRecord.TaxYearId).YearOfTax,
                TaxYear = paymentRecord.TaxYear,
                TaxCode = paymentRecord.TaxCode,
                TaxYearId = paymentRecord.TaxYearId,
                TotalEarnings = paymentRecord.TotalEarnings
            };
            return View(model);
        }

        public IActionResult GeneratePDF(int id)
        {
            var payslip = new ActionAsPdf("Payslip", new { id = id })
            {
                FileName = "payslip.pdf",

            };
            return payslip;
        }
    }
}