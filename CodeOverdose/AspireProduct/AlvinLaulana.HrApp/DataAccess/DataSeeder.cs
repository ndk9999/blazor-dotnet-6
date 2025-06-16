using AlvinLaulana.HrApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace AlvinLaulana.HrApp.DataAccess;

public static class DataSeeder
{
	internal static void Seed(this ModelBuilder builder)
	{
		builder.Entity<Employee>().HasData(new List<Employee>
		{
			new Employee
			{
				Id = 1,
				FullName = "John Doe",
				Department = "IT",
				DateOfBirth = new DateTime(1990, 1, 1),
				Age = 33,
				PhoneNumber = "1234567890"
			},
			new Employee
			{
				Id = 2,
				FullName = "Jane Smith",
				Department = "HR",
				DateOfBirth = new DateTime(1985, 5, 15),
				Age = 38,
				PhoneNumber = "0987654321"
			},
			new Employee
			{
				Id = 3,
				FullName = "Alice Johnson",
				Department = "Finance",
				DateOfBirth = new DateTime(1992, 3, 20),
				Age = 31,
				PhoneNumber = "5551234567"
			},
			new Employee
			{
				Id = 7,
				FullName = "Bob Brown",
				Department = "Marketing",
				DateOfBirth = new DateTime(1988, 7, 10),
				Age = 35,
				PhoneNumber = "4449876543"
			},
			new Employee
			{
				Id = 11,
				FullName = "Charlie Davis",
				Department = "Sales",
				DateOfBirth = new DateTime(1995, 11, 25),
				Age = 28,
				PhoneNumber = "3334567890"
			},
			new Employee
			{
				Id = 4,
				FullName = "Diana Evans",
				Department = "IT",
				DateOfBirth = new DateTime(1991, 2, 5),
				Age = 32,
				PhoneNumber = "2223456789"
			},
			new Employee
			{
				Id = 6,
				FullName = "Ethan Green",
				Department = "HR",
				DateOfBirth = new DateTime(1987, 6, 30),
				Age = 36,
				PhoneNumber = "1112345678"
			},
			new Employee
			{
				Id = 5,
				FullName = "Fiona Harris",
				Department = "Finance",
				DateOfBirth = new DateTime(1993, 4, 18),
				Age = 30,
				PhoneNumber = "6661234567"
			},
			new Employee
			{
				Id = 8,
				FullName = "George King",
				Department = "Marketing",
				DateOfBirth = new DateTime(1989, 8, 12),
				Age = 34,
				PhoneNumber = "7779876543"
			},
			new Employee
			{
				Id = 9,
				FullName = "Hannah Lee",
				Department = "Sales",
				DateOfBirth = new DateTime(1994, 9, 22),
				Age = 29,
				PhoneNumber = "8884567890"
			},
			new Employee
			{
				Id = 12,
				FullName = "Ian Miller",
				Department = "IT",
				DateOfBirth = new DateTime(1990, 12, 1),
				Age = 32,
				PhoneNumber = "9993456789"
			},
			new Employee
			{
				Id = 10,
				FullName = "Julia Nelson",
				Department = "HR",
				DateOfBirth = new DateTime(1986, 10, 15),
				Age = 37,
				PhoneNumber = "0002345678"
			},
			new Employee
			{
				Id = 13,
				FullName = "Kevin Ortiz",
				Department = "Finance",
				DateOfBirth = new DateTime(1992, 3, 8),
				Age = 31,
				PhoneNumber = "1111234567"
			},
			new Employee
			{
				Id = 14,
				FullName = "Laura Perez",
				Department = "Marketing",
				DateOfBirth = new DateTime(1988, 7, 20),
				Age = 35,
				PhoneNumber = "2229876543"
			},
			new Employee
			{
				Id = 15,
				FullName = "Michael Roberts",
				Department = "Sales",
				DateOfBirth = new DateTime(1995, 11, 30),
				Age = 28,
				PhoneNumber = "3334567890"
			},
			new Employee
			{
				Id = 16,
				FullName = "Nina Scott",
				Department = "IT",
				DateOfBirth = new DateTime(1991, 2, 10),
				Age = 32,
				PhoneNumber = "4443456789"
			},
			new Employee
			{
				Id = 17,
				FullName = "Oscar Taylor",
				Department = "HR",
				DateOfBirth = new DateTime(1987, 6, 25),
				Age = 36,
				PhoneNumber = "5552345678"
			},
			new Employee
			{
				Id = 18,
				FullName = "Paula White",
				Department = "Finance",
				DateOfBirth = new DateTime(1993, 4, 20),
				Age = 30,
				PhoneNumber = "6661234567"
			},
			new Employee
			{
				Id = 19,
				FullName = "Quentin Young",
				Department = "Marketing",
				DateOfBirth = new DateTime(1989, 8, 15),
				Age = 34,
				PhoneNumber = "7779876543"
			},
			new Employee
			{
				Id = 20,
				FullName = "Rachel Adams",
				Department = "Sales",
				DateOfBirth = new DateTime(1994, 9, 28),
				Age = 29,
				PhoneNumber = "8884567890"
			},
			new Employee
			{
				Id = 21,
				FullName = "Steve Baker",
				Department = "IT",
				DateOfBirth = new DateTime(1990, 12, 5),
				Age = 32,
				PhoneNumber = "9993456789"
			},
			new Employee
			{
				Id = 22,
				FullName = "Tina Clark",
				Department = "HR",
				DateOfBirth = new DateTime(1986, 10, 20),
				Age = 37,
				PhoneNumber = "0002345678"
			},
			new Employee
			{
				Id = 23,
				FullName = "Ursula Diaz",
				Department = "Finance",
				DateOfBirth = new DateTime(1992, 3, 12),
				Age = 31,
				PhoneNumber = "1111234567"
			},
			new Employee
			{
				Id = 24,
				FullName = "Victor Evans",
				Department = "Marketing",
				DateOfBirth = new DateTime(1988, 7, 25),
				Age = 35,
				PhoneNumber = "2229876543"
			},
			new Employee
			{
				Id = 25,
				FullName = "Wendy Foster",
				Department = "Sales",
				DateOfBirth = new DateTime(1995, 11, 15),
				Age = 28,
				PhoneNumber = "3334567890"
			},
			new Employee
			{
				Id = 26,
				FullName = "Xander Garcia",
				Department = "IT",
				DateOfBirth = new DateTime(1991, 2, 15),
				Age = 32,
				PhoneNumber = "4443456789"
			},
			new Employee
			{
				Id = 27,
				FullName = "Yara Harris",
				Department = "HR",
				DateOfBirth = new DateTime(1987, 6, 28),
				Age = 36,
				PhoneNumber = "5552345678"
			},
			new Employee
			{
				Id = 28,
				FullName = "Zachary Johnson",
				Department = "Finance",
				DateOfBirth = new DateTime(1993, 4, 25),
				Age = 30,
				PhoneNumber = "6661234567"
			},
			new Employee
			{
				Id = 29,
				FullName = "Alice Smith",
				Department = "Marketing",
				DateOfBirth = new DateTime(1989, 8, 18),
				Age = 34,
				PhoneNumber = "7779876543"
			},
			new Employee
			{
				Id = 30,
				FullName = "Bob Johnson",
				Department = "Sales",
				DateOfBirth = new DateTime(1994, 9, 30),
				Age = 29,
				PhoneNumber = "8884567890"
			},
		});
	}
}