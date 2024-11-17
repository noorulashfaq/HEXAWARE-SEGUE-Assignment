namespace CodingTask3
{
	internal class Program
	{
		static void Main(string[] args)
		{

			#region Task 7
			//string[] trackingHistory = new string[10];
			//int currentIndex = 0;
			//string[] locations = { "Warehouse", "Distribution Center", "City Hub", "Out for Delivery", "Delivered" };

			//Console.WriteLine("Updating parcel location...");
			//foreach (string location in locations)
			//{
			//	if (currentIndex < trackingHistory.Length)
			//	{
			//		trackingHistory[currentIndex] = location;
			//		currentIndex++;

			//		Console.WriteLine($"Location updated to: {location}");

			//	}
			//}

			//Console.WriteLine("-----------------------------------------");
			//Console.WriteLine("\nTracking History:");
			//foreach (string update in trackingHistory)
			//{
			//	if (!string.IsNullOrEmpty(update))
			//	{
			//		Console.WriteLine(update);
			//	}
			//}
			//Console.ReadLine();
			#endregion

			#region Task 8
			CourierAvailability[] couriers = {
				new CourierAvailability("Courier A", 5.0, true),
				new CourierAvailability("Courier B", 3.2, false),
				new CourierAvailability("Courier C", 8.5, true),
				new CourierAvailability("Courier D", 2.0, true)
			};

			CourierAvailability nearestCourier = findNearestAvailableCourier(couriers);

			if (nearestCourier != null)
			{
				Console.WriteLine($"Nearest available courier is: {nearestCourier.name}" +
					$"\nDistance: {nearestCourier.distanceToOrder} km");
			}
			else
			{
				Console.WriteLine("No available courier found");
			}
			Console.ReadLine();
		}

		public static CourierAvailability findNearestAvailableCourier(CourierAvailability[] couriers)
		{
			CourierAvailability nearestCourier = null;
			double minDistance = double.MaxValue;
			foreach (CourierAvailability courier in couriers)
			{
				if (courier.isAvailable && courier.distanceToOrder < minDistance)
				{
					nearestCourier = courier;
					minDistance = courier.distanceToOrder;
				}
			}
			return nearestCourier;
		}
		#endregion
	}
}
