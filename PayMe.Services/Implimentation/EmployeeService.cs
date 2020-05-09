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
        private decimal studentLoanAmount = 0m;
        private decimal unionFee = 0m;

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
        public IEnumerable<Employee> GetAll() => _context.Employees;
        public Employee GetEmployeeById(int employeeId) => _context.Employees.Where(x => x.Id == employeeId).FirstOrDefault();
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
        public decimal StudentLoanRepay(int employeeId, decimal totalAmount)
        {
            var employee = GetEmployeeById(employeeId);
            if (employee.StudentLoan == StudentLoan.Yes)
            {
                if (totalAmount > 2000 && totalAmount < 4000)
                {
                    studentLoanAmount = 40m;
                }
                else if (totalAmount >= 4000 && totalAmount < 8000)
                {
                    studentLoanAmount = 100m;
                }
                return studentLoanAmount = 0;

            }
            return studentLoanAmount;

        }
        public decimal UnionFees(int employeeId)
        {
            var employee = GetEmployeeById(employeeId);
            if (employee.UnionMember == UnionMember.Yes)
            {
                unionFee = 100m;
            }
            return unionFee;
        }
    }
}
