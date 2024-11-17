namespace CodingTask1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			#region Task 1
			//Console.WriteLine("Enter the order status [Processing, Delivered, Cancelled]: ");
			//string orderStatus = Console.ReadLine();
			//if (orderStatus.Equals("Processing", StringComparison.OrdinalIgnoreCase))
			//	Console.WriteLine("The order is in processing");
			//else if (orderStatus.Equals("Delivered", StringComparison.OrdinalIgnoreCase))
			//	Console.WriteLine("The order has been delivered");
			//else if (orderStatus.Equals("Cancelled", StringComparison.OrdinalIgnoreCase))
			//	Console.WriteLine("The order is cancelled");
			//else
			//	Console.WriteLine("Invalid status");
			#endregion

			#region Task 2
			//Console.WriteLine("Enter the weight of the parcel: ");
			//int weight = int.Parse(Console.ReadLine());
			//switch (weight)
			//{
			//	case <= 5:
			//		Console.WriteLine("Light weight parcel");
			//		break;
			//	case > 5 and <= 20:
			//		Console.WriteLine("Medium weight parcel");
			//		break;
			//	case > 20:
			//		Console.WriteLine("Heavy weight parcel");
			//		break;
			//}
			//string category = weight switch
			//{
			//	< 5 => "Light",
			//	>= 5 and <= 20 => "Medium",
			//	> 20 => "Heavy",
			//};
			//Console.WriteLine($"The parcel is categorized as: {category}");
			#endregion

			#region Task 3
			//int choice = 0;
			//do
			//{
			//	Console.WriteLine("1. Sign up\t2. Login\t3. Exit\nEnter your choice:");
			//	choice = int.Parse(Console.ReadLine());
			//	switch (choice)
			//	{
			//		case 1:
			//			Console.WriteLine("--------------New user registration--------------");
			//			Console.WriteLine("\nEnter your name: ");
			//			string userName = Console.ReadLine();
			//			Console.WriteLine("Enter your email: ");
			//			string userMail = Console.ReadLine();
			//			bool flag = true;
			//			string userPassword, userPasswordVerify;
			//			do
			//			{
			//				Console.WriteLine("Enter your password: ");
			//				userPassword = Console.ReadLine();
			//				Console.WriteLine("Re-enter your password: ");
			//				userPasswordVerify = Console.ReadLine();
			//				if (!userPasswordVerify.Equals(userPassword))
			//				{
			//					flag = false;
			//					Console.WriteLine("----------------------------------------");
			//					Console.WriteLine("Password doesn't match\nRetry!");
			//					Console.WriteLine("----------------------------------------");
			//				}
			//			} while (!userPassword.Equals(userPasswordVerify));
			//			if(flag)
			//			{
			//				Console.WriteLine($"Successfully registered, welcome {userName}");
			//			}
			//			break;

			//		case 2:
			//			Console.WriteLine("--------------User login--------------");
			//			Console.WriteLine("Enter username: ");
			//			string loggedUserName = Console.ReadLine();
			//			if (!loggedUserName.Equals("Noorul"))
			//			{
			//				Console.WriteLine("----------------------------------------");
			//				Console.WriteLine("No user found");
			//				Console.WriteLine("----------------------------------------");
			//			}
			//			Console.WriteLine("Enter password: ");
			//			string loggedUserPassword = Console.ReadLine();
			//			if (!loggedUserPassword.Equals("noor"))
			//			{
			//				Console.WriteLine("----------------------------------------");
			//				Console.WriteLine("Incorrect password");
			//				Console.WriteLine("----------------------------------------");
			//			}
			//			else
			//			{
			//				Console.WriteLine("----------------------------------------");
			//				Console.WriteLine($"Login successful, welcome {loggedUserName}");
			//				Console.WriteLine("----------------------------------------");
			//			}
			//			break;

			//		default:
			//			Console.WriteLine("----------------------------------------");
			//			Console.WriteLine("Invalid choice");
			//			Console.WriteLine("----------------------------------------");
			//			break;
			//	}
			//} while (choice != 3);
			#endregion

			#region Task 4
			Courier[] couriers = new Courier[]
			{
				new Courier { name = "Courier A", distanceToShipment = 5.0, maxLoadCapacity = 50.0, currentLoad = 10.0 },
				new Courier { name = "Courier B", distanceToShipment = 3.0, maxLoadCapacity = 30.0, currentLoad = 5.0 },
				new Courier { name = "Courier C", distanceToShipment = 10.0, maxLoadCapacity = 40.0, currentLoad = 20.0 }
			};

			double shipmentWeight = 15.0;
			int bestCourierIndex = -1;
			for (int i = 0; i < couriers.Length; i++)
			{
				var courier = couriers[i];
				if (courier.CanCarry(shipmentWeight))
				{
					if (bestCourierIndex == -1 || courier.distanceToShipment < couriers[bestCourierIndex].distanceToShipment)
					{
						bestCourierIndex = i;
					}
				}
			}
			if (bestCourierIndex != -1)
			{
				var assignedCourier = couriers[bestCourierIndex];
				Console.WriteLine($"Assigned Courier: {assignedCourier.name}\n" +
					$"Distance: {assignedCourier.distanceToShipment} km\n" +
					$"Available Capacity: {assignedCourier.maxLoadCapacity - assignedCourier.currentLoad} kg)");
			}
			else
			{
				Console.WriteLine("No courier found for the shipment.");
			}
			Console.ReadLine();
			#endregion
		}
	}
}
