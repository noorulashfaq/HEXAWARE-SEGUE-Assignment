using CMS_app.Exceptions;
using CMS_app.Main;
using CMS_app.Repository;
using System;

namespace CMS_app.Service
{
	public class CourierUserService : ICourierUserService
	{
		readonly ICourierUserRepository _courierUserRepository;
		readonly IAdminRepository _adminRepository;
		readonly IAdminService _adminService;

		public CourierUserService()
		{
			_courierUserRepository = new CourierUserRepository();
			_adminRepository = new AdminRepository();
			_adminService = new AdminService();
		}

		public void UserSignUp()
		{
			User user = new User();
			Console.WriteLine("\nNew User Registration");

			Console.Write("Name: ");
			user.UserName = Console.ReadLine();

			Console.Write("Email: ");
			user.Email = Console.ReadLine();

			while (true)
			{
				Console.Write("Contact number: ");
				user.ContactNumber = long.Parse(Console.ReadLine());
				if(user.ContactNumber.ToString().Length == 10)
				{
					break;
				}
			}

			Console.Write("Address: ");
			user.Address = Console.ReadLine();

			string password;
			while (true)
			{
				Console.Write("Create a password: ");
				password = Console.ReadLine();
				Console.Write("Confirm your password: ");
				string passwordVerify = Console.ReadLine();
				if (passwordVerify.Equals(password))
				{
					user.Password = passwordVerify;
					break;
				}
				else
				{
					Console.WriteLine("Password does not match. Please re-enter");
				}
			}
			int registeredUserId = _courierUserRepository.UserSignUp(user);
			if (registeredUserId > 0)
			{
				Console.WriteLine($"New user registered successfully\nYour ID is {registeredUserId}\n");
			}
			else
			{
				Console.WriteLine("Oops! The user could not be registered. Please try again!\n");
			}
		}

		public bool UserLogin()
		{
			Console.WriteLine("\nUser Login");

			Console.Write("Email: ");
			string email = Console.ReadLine();

			Console.Write("Password: ");
			string password = Console.ReadLine();

			int loginResult = _courierUserRepository.UserLogin(email, password);
			if (loginResult > 0)
			{
				MainModule.LoggedUserId = loginResult;
				return true;
			}
			return false;
		}

		public void PlaceOrder()
		{
			try
			{
				Courier courier = new Courier();

				Console.WriteLine("\nEnter particulars of the Courier");

				Console.Write("=> Receiver name: ");
				courier.ReceiverName = Console.ReadLine();

				Console.Write("=> Delivery address: ");
				courier.ReceiverAddress = Console.ReadLine();

				Console.Write("=> Weight (in kg): ");
				courier.Weight = double.Parse(Console.ReadLine());

				Console.WriteLine("List of Services:");
				_adminService.GetAllServices();
				Console.Write("=> Choose Service ID: ");
				courier.ServiceId = int.Parse(Console.ReadLine());

				Console.WriteLine("List of Employees:");
				_adminService.GetAllEmployees();
				Console.Write("=> Choose Employee ID: ");
				courier.EmployeeId = int.Parse(Console.ReadLine());

				string trackingNumber = _courierUserRepository.PlaceOrder(courier);

				if (trackingNumber != null)
				{
					Console.WriteLine($"Order is placed. Track your order using {trackingNumber}\n");
				}
				else
				{
					Console.WriteLine("Oops! Cannot place order. Please try again!\n");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message + "\nRetry!");
			}
		}

		public void GetOrderStatus()
		{
			Console.WriteLine("\nCheck order status");

			Console.Write("Order tracking number: ");
			string trackingNumber = Console.ReadLine();

			try
			{
				string result = _courierUserRepository.GetOrderStatus(trackingNumber);

				if (result != null)
				{
					Console.WriteLine($"The status of the Order {trackingNumber} is \"{result}\"");
				}
				else
				{
					throw new TrackingNumberNotFoundException($"Tracking number {trackingNumber} is not found");
				}
			}
			catch(TrackingNumberNotFoundException tnnfe)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine(tnnfe.Message);
				Console.ResetColor();
			}
			catch(Exception ex)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine(ex.Message);
				Console.ResetColor();
			}
		}

		public void CancelOrder()
		{
			Console.WriteLine("\nCancel order");

			Console.Write("Order tracking number: ");
			string trackingNumber = Console.ReadLine();

			try
			{
				bool result = _courierUserRepository.cancelOrder(trackingNumber);

				if (result)
				{
					Console.WriteLine($"The Order {trackingNumber} is cancelled");
				}
				else
				{
					throw new TrackingNumberNotFoundException($"Tracking number {trackingNumber} is not found");
				}
			}
			catch (TrackingNumberNotFoundException tnnfe)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine(tnnfe.Message);
				Console.ResetColor();
			}
			catch (Exception ex)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine(ex.Message);
				Console.ResetColor();
			}
		}

		public void GetAssignedOrders()
		{
			Console.WriteLine("\nGet assigned orders for employee");

			Console.WriteLine("List of Employees:");
			_adminService.GetAllEmployees();
			Console.Write("Enter Employee ID: ");
			int employeeId = int.Parse(Console.ReadLine());

			try
			{
				List<Courier> allCouriersByEmp = _courierUserRepository.GetAssignedOrder(employeeId);
				if(allCouriersByEmp.Count == 0)
				{
					throw new InvalidEmployeeIdException($"Employee ID {employeeId} not found");
				}
				else
				{
					Console.WriteLine($"Listing all couriers assigned to Employee ID {employeeId}");
					foreach (Courier courier in allCouriersByEmp)
					{
						Console.WriteLine(courier);
					}
				}
			}
			catch(InvalidEmployeeIdException iee)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine(iee.Message);
				Console.ResetColor();
			}
		}
	}
}
