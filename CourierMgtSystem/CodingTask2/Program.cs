namespace CodingTask2
{
	internal class Program
	{
		static void Main(string[] args)
		{

			#region Task 5
			//Order[] orders = new Order[]
			//{
			//	new Order { orderID = 1, orderDate = "2024-01-02", customerID = 1, deliveryDate = "2024-01-15", price = 150.00 },
			//	new Order { orderID = 2, orderDate = "2024-09-21", customerID = 2, deliveryDate = "2024-09-29", price = 230.00 },
			//	new Order { orderID = 3, orderDate = "2024-06-02", customerID = 1, deliveryDate = "2024-06-15", price = 50.00 },
			//};
   //         Console.WriteLine("Enter Customer ID: ");
			//int customerID = int.Parse(Console.ReadLine());
			//Console.WriteLine("-----------------------------------------------------------------------------------");
			//for(int i = 0; i < orders.Length; i++)
			//{
			//	if (orders[i].customerID == customerID)
			//	{
			//		Console.WriteLine($"Order ID: {orders[i].orderID}, Order Date: {orders[i].orderDate}, Customer ID: {orders[i].customerID}, Price: {orders[i].price}");
			//	}
			//}
			//Console.WriteLine("-----------------------------------------------------------------------------------");
			//Console.ReadLine();
			#endregion

			#region Task 6
			double courierLocation = 10.0;
			double destinationLocation = 0.0;
			double speed = 1.0;
			
			Console.WriteLine("Tracking courier location...");
			while (courierLocation > destinationLocation)
			{
				courierLocation -= speed;
				Console.WriteLine($"Courier is {courierLocation:F1} km away from the destination.");
			}

			Console.WriteLine("Courier has arrived at the destination!");
			Console.ReadLine();
			#endregion
		}
	}
}
