using AlvinLaulana.HrApp.DataAccess;
using AlvinLaulana.HrApp.DataAccess.Entities;
using AlvinLaulana.HrApp.ViewModels;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace AlvinLaulana.HrApp.Services;

public interface IEmployeeService
{
	Task<EmployeeViewModel> GetEmployeeByIdAsync(int id);

	Task<IEnumerable<EmployeeViewModel>> GetAllEmployeesAsync();

	Task<bool> AddEmployeeAsync(EmployeeViewModel employee);

	Task<bool> UpdateEmployeeAsync(EmployeeViewModel employee);

	Task<bool> DeleteEmployeeAsync(int id);
}

public class EmployeeService(HrDbContext dbContext) : IEmployeeService
{
	public async Task<EmployeeViewModel> GetEmployeeByIdAsync(int id)
	{
		var employee = await dbContext.Employees.FindAsync(id);
		return employee.Adapt<EmployeeViewModel>();
	}
	
	public async Task<IEnumerable<EmployeeViewModel>> GetAllEmployeesAsync()
	{
		return await dbContext.Employees
			.OrderBy(x => x.FullName)
			.ProjectToType<EmployeeViewModel>()
			.ToListAsync();
	}
	
	public async Task<bool> AddEmployeeAsync(EmployeeViewModel model)
	{
		var employee = model.Adapt<Employee>();
		await dbContext.Employees.AddAsync(employee);
		return await dbContext.SaveChangesAsync() > 0;
	}

	public async Task<bool> UpdateEmployeeAsync(EmployeeViewModel model)
	{
		var employee = model.Adapt<Employee>();
		dbContext.Employees.Update(employee);
		return await dbContext.SaveChangesAsync() > 0;
	}

	public async Task<bool> DeleteEmployeeAsync(int id)
	{
		var employee = await dbContext.Employees.FindAsync(id);

		if (employee != null)
		{
			dbContext.Employees.Remove(employee);
			return await dbContext.SaveChangesAsync() > 0;
		}

		return false;
	}
}