using Microsoft.AspNetCore.Mvc.Rendering;
using PayMe.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayMe.Services
{
   public interface IEmployeeService
    {
        Task CreateAsync(Employee newEmployee);
        Employee GetEmployeeById(int employeeId);
        Task UpdateAsync(int employeeId);
        Task UpdateAsync(Employee employee);
        Task Delete(int employeeId);
        IEnumerable<Employee> GetAll();
        IEnumerable<SelectListItem> EmployeeList();
        decimal UnionFees(int employeeId);
        decimal StudentLoanRepay(int employeeId, decimal totalAmount);


    }
}
