using CMS_app.Entity;
using CMS_app.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_app.Service
{
	internal class AdminService : IAdminService
	{
		IAdminRepository _adminRepository;

		public AdminService()
		{
			_adminRepository = new AdminRepository();
		}

		public void AddNewCourierService()
		{
			CourierService service = new CourierService();
			Console.WriteLine("\nEnter Service details");

			Console.Write("Service name: ");
			service.ServiceName = Console.ReadLine();

			Console.Write("Cost of the service: ");
			service.Cost = double.Parse(Console.ReadLine());

			int addStatus = _adminRepository.AddNewCourierService(service);
			if (addStatus > 0)
			{
				Console.WriteLine("New service registered successfully\n");
			}
			else
			{
				Console.WriteLine("Oops! The service could not be registered. Please try again!\n");
			}
		}

		public void AddNewEmployee()
		{
			Employee employee = new Employee();
			Console.WriteLine("\nEnter employee details");

			Console.Write("Name: ");
			employee.EmployeeName = Console.ReadLine();

			Console.Write("Email: ");
			employee.Email = Console.ReadLine();

			while (true)
			{
				Console.Write("Contact number: ");
				employee.ContactNumber = long.Parse(Console.ReadLine());
				if (employee.ContactNumber.ToString().Length == 10)
				{
					break;
				}
			}

			Console.Write("Role: ");
			employee.Role = Console.ReadLine();

			Console.Write("Salary: ");
			employee.Salary = double.Parse(Console.ReadLine());

			int addStatus = _adminRepository.AddNewEmployee(employee);
			if (addStatus > 0)
			{
				Console.WriteLine("New employee registered successfully\n");
			}
			else
			{
				Console.WriteLine("Oops! The employee could not be registered. Please try again!\n");
			}
		}

		public void AddNewLocation()
		{
			Location location = new Location();
			Console.WriteLine("\nEnter Location details");

			Console.Write("Location name: ");
			location.LocationName = Console.ReadLine();

			Console.Write("Address: ");
			location.Address = Console.ReadLine();

			int addStatus = _adminRepository.AddNewLocation(location);
			if (addStatus > 0)
			{
				Console.WriteLine("New location registered successfully\n");
			}
			else
			{
				Console.WriteLine("Oops! The location could not be registered. Please try again!\n");
			}
		}

		public void GetAllEmployees()
		{
			try
			{
				List<Employee> allEmployees = _adminRepository.GetAllEmployees();
				if (allEmployees.Count == 0)
				{
					Console.WriteLine("No employees found");
					return;
				}
				Console.WriteLine("----------------------------------------------------\nListing all employees");
				Console.WriteLine("---------------------\n");
				foreach (Employee employee in allEmployees)
				{
					Thread.Sleep(250);
					Console.WriteLine(employee);
				}
				Console.WriteLine("----------------------------------------------------\n");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public void GetAllLocations()
		{
			try
			{
				List<Location> allLocations = _adminRepository.GetAllLocations();
				if (allLocations.Count == 0)
				{
					Console.WriteLine("No locations found");
					return;
				}
				Console.WriteLine("----------------------------------------------------\nListing all locations");
				Console.WriteLine("---------------------\n");
				foreach (Location location in allLocations)
				{
					Thread.Sleep(250);
					Console.WriteLine(location);
				}
				Console.WriteLine("----------------------------------------------------\n");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public void GetAllServices()
		{
			try
			{
				List<CourierService> allServices = _adminRepository.GetAllServices();
				if (allServices.Count == 0)
				{
					Console.WriteLine("No services found");
					return;
				}
				Console.WriteLine("----------------------------------------------------\nListing all services");
				Console.WriteLine("---------------------");
				foreach (CourierService service in allServices)
				{
					Thread.Sleep(250);
					Console.WriteLine(service);
				}
				Console.WriteLine("----------------------------------------------------\n");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}
