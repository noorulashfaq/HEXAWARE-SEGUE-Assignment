using System;
using CMS_app.Service;

namespace CMS_app.Main
{
	public class MainModule
	{
		public static int LoggedUserId = 0;

		public void Run()
		{
			ICourierUserService courierUserService = new CourierUserService();
			IAdminService adminService = new AdminService();

			int choice = 0;
			do
			{
				Console.WriteLine("------------Shippify------------");
				Console.Write("Menu:\n\t1. User login\n\t2. New user registration\n\t3. Admin login\n\t4. Logout\n");
				Console.Write("Enter your choice: ");
				choice = int.Parse(Console.ReadLine());
				switch (choice)
				{
					case 1:
						bool loginStatus = courierUserService.UserLogin();
						if (loginStatus)
						{
							Console.ForegroundColor = ConsoleColor.Green;
							Console.WriteLine("Login successful. Welcome back!");
							Console.ResetColor();

							int userChoice = 0;
							do
							{
								Console.Write("\nUser menu:\n\t1. Place order\n\t2. Check order status\n\t3. Cancel order\n\t4. Logout\nEnter your choice: ");
								userChoice = int.Parse(Console.ReadLine());
								switch (userChoice)
								{
									case 1:
										courierUserService.PlaceOrder();
										break;

									case 2:
										courierUserService.GetOrderStatus();
										break;

									case 3:
										courierUserService.CancelOrder();
										break;

									case 4:
										LoggedUserId = 0;
										Console.ForegroundColor = ConsoleColor.Red;
										Console.WriteLine("Logging out...\n");
										Console.ResetColor();
										break;

									default:
										Console.WriteLine("Invalid choice");
										break;
								}
							} while (userChoice != 4);
						}
						else
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("Invalid credentials. Try again!");
							Console.ResetColor();
						}
						break;

					case 2:
						courierUserService.UserSignUp();
						break;

					case 3:
						int adminChoice = 0;
						do
						{
							Console.Write("\nAdmin menu:\n\t1. Add new Courier Service\n\t2. Add new Employee\n\t3. Add new Location\n\t4. Get Orders by Employee\n\t5. Logout\nEnter your choice: ");
							adminChoice = int.Parse(Console.ReadLine());
							switch (adminChoice)
							{
								case 1:
									adminService.AddNewCourierService();
									break;

								case 2:
									adminService.AddNewEmployee();
									break;

								case 3:
									adminService.AddNewLocation();
									break;

								case 4:
									courierUserService.GetAssignedOrders();
									break;

								case 5:
									Console.ForegroundColor = ConsoleColor.Red;
									Console.WriteLine("Logging out...\n");
									Console.ResetColor();
									break;

								default:
									Console.WriteLine("Invalid choice!");
									break;
							}
						}while(adminChoice != 5);
						break;

					case 4:
						Console.WriteLine("Exiting the application...");
						break;
				}
			} while (choice != 4);
		}
	}
}
