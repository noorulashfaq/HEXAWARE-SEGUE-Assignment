using System;
using CMS_app.Service;

namespace CMS_app.Main
{
	public class MainModule
	{
		public void Run()
		{
			ICourierUserService courierUserService = new CourierUserService();
			int choice = 0;
			do
			{
				Console.WriteLine("------------Shippify------------");
				Console.WriteLine("Menu:\n\t1. User login\n\t2. New user registration\n\t3. Admin login\n\t4. Logout\n");
				Console.WriteLine("Enter your choice:");
				choice = int.Parse(Console.ReadLine());
				switch (choice)
				{
					case 2:
						Console.WriteLine("-------------------------------------\nNew User Registration");
						Console.WriteLine("Enter your name:");
						string userName = Console.ReadLine();
						Console.WriteLine("Enter your email:");
						string email = Console.ReadLine();
						Console.WriteLine("Enter your contact number:");
						long contact = long.Parse(Console.ReadLine());
						Console.WriteLine("Enter your address:");
						string address = Console.ReadLine();
						string password;
						while (true)
						{
							Console.WriteLine("Create a password:");
							password = Console.ReadLine();
							Console.WriteLine("Confirm your password:");
							string passwordVerify = Console.ReadLine();
							if (passwordVerify.Equals(password))
								break;
							else
								Console.WriteLine("Password does not match. Please re-enter");
						}
						User user = new User() { UserName = userName, Email = email, Password = password, Address = address, ContactNumber = contact };
						Console.WriteLine(courierUserService.AddNewUser(user));
						break;

					case 4:
						Console.WriteLine("Logging out");
						break;
				}
			} while (choice != 4);
		}
	}
}
