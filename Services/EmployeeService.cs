using Microsoft.EntityFrameworkCore;
using EmployeeManagement.DAL;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using System;
using EmployeeManagement.Services;

namespace EmployeeManagement.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeManagementCatalogContext _context;

        public EmployeeService(EmployeeManagementCatalogContext context) 
        {
            _context = context;
        }
        public async Task<IEnumerable<EmployeeViewModel>> GetAllEmployeeAsync()
        {
            return await _context.Employees
                .Select(p => new EmployeeViewModel
                {
                    EmployeeID = p.EmployeeID,
                    EmployeeName = p.EmployeeName,
                    EmployeeType=p.EmployeeType,
                    Gender = p.Gender,
                    Role = p.Role,
                    Skills = p.Skills,
                    Division = p.Division,
                })
                .ToListAsync();
        }

        
            public async Task<EmployeeViewModel> AddEmployeeAsync(EmployeeCreateViewModel employee)
            {
                var p = ToEntity(employee);
                await _context.AddAsync(p);
                await _context.SaveChangesAsync();
                return ToViewModel(p);
            }

        
          public async Task<EmployeeViewModel> GetEmployeeByIdAsync(int id)
            {
                var p = await _context.Employees
                    .FirstAsync(x => x.EmployeeID == id);

                var ans = new EmployeeViewModel
                {
                    EmployeeID = p.EmployeeID,
                    EmployeeName = p.EmployeeName,
                    EmployeeType = p.EmployeeType,
                    Gender = p.Gender,
                    Role = p.Role,
                    Skills = p.Skills,
                    Division = p.Division,
                };

                return ans;
            }

        public async Task<EmployeeViewModel> UpdateEmployeeAsync(int id, EmployeeUpdateViewModel employee
            )
        {
            var p = await FromId(id);

            p.EmployeeName = employee.EmployeeName;
            p.EmployeeType = employee.EmployeeType;
            p.Gender = employee.Gender;
            p.Role = employee.Role;
            p.Skills = employee.Skills;
            p.Division = employee.Division;

            await _context.SaveChangesAsync();

            return ToViewModel(p);
        }

        public async Task DeleteAsync(int id)
        {
            var p = await FromId(id);
            _context.Employees.Remove(p);
            await _context.SaveChangesAsync();
        }

        private Employee ToEntity(EmployeeCreateViewModel p)
        {
            return new Employee
            {
                
                EmployeeName = p.EmployeeName,
                EmployeeType = p.EmployeeType,
                Gender = p.Gender,
                Role = p.Role,
                Skills = p.Skills,
                Division = p.Division,
            };
        }
        private EmployeeViewModel ToViewModel(Employee p)
        {
            return new EmployeeViewModel
            {
                EmployeeID = p.EmployeeID,
                EmployeeName = p.EmployeeName,
                EmployeeType = p.EmployeeType,
                Gender = p.Gender,
                Role = p.Role,
                Skills = p.Skills,
                Division = p.Division,

            };
        }
        private async Task<Employee> FromId(int id)
        {
            return await _context.Employees.FirstAsync(p => p.EmployeeID == id);
        }

       
    }
}
