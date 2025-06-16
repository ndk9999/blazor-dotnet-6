using System.ComponentModel.DataAnnotations;

namespace AlvinLaulana.HrApp.ViewModels;

public class EmployeeViewModel
{
	public int Id { get; set; }

	public string DisplayId => $"EMP{Id.ToString().PadLeft(5, '0')}";

	[Required] public string FullName { get; set; }

	[Required] public string Department { get; set; }

	[Required] public DateTime DateOfBirth { get; set; }

	[Required] public int Age { get; set; }

	[Required] public string PhoneNumber { get; set; }
}