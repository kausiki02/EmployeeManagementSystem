using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;

namespace EmployeeManagement.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeViewModel>> GetAllEmployeesAsync();
        Task<EmployeeViewModel> GetEmployeeByIdAsync(int id);
        Task<EmployeeViewModel> AddEmployeeAsync(EmployeeCreateViewModel employee);

        Task<EmployeeViewModel> UpdateEmployeeAsync(int id, EmployeeUpdateViewModel employee);

        Task DeleteAsync(int id);
    }
}
