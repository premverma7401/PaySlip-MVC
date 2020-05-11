using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PayMe.Entity;
using PayMe.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayMe.Services.Implimentation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;
       
        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Employee newEmployee)
        {
            await _context.Employees.AddAsync(newEmployee);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int employeeId)
        {
            var employee = GetEmployeeById(employeeId);
            _context.Remove(employee);
            await _context.SaveChangesAsync();
        }
        public IEnumerable<Employee> GetAll() => _context.Employees.Include(emp=>emp.PersonalInfoEmployee).Include(emp=>emp.PayInfoEmployee);
        public Employee GetEmployeeById(int employeeId) => _context.Employees.Include(emp=>emp.PayInfoEmployee).Include(emp=>emp.PersonalInfoEmployee).Where(x => x.Id == employeeId).FirstOrDefault();
        public async Task UpdateAsync(int employeeId)
        {
            var employee = GetEmployeeById(employeeId);
            _context.Update(employee);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Employee employee)
        {
            _context.Update(employee);
            await _context.SaveChangesAsync();
        }
       

        public IEnumerable<SelectListItem> EmployeeList()
        {
            var allEmployees = _context.Employees.Select(emp => new SelectListItem
            {
                Text = emp.FullName,
                Value = emp.Id.ToString()
            });
            return allEmployees;
        }
    }
}
