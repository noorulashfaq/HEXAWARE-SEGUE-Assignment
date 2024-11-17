namespace CodingTask4
{
	internal class Program
	{
		static void Main(string[] args)
		{
			#region Task 9
			//string[,] parcels = new string[,] {
			//	{ "TRK001", "In Transit" },
			//	{ "TRK002", "Out for Delivery" },
			//	{ "TRK003", "Delivered" },
			//	{ "TRK004", "In Transit" },
			//	{ "TRK005", "Delivered" }
			//};

			//Console.WriteLine("Enter the tracking number: ");
			//string inputTrackingNumber = Console.ReadLine();
			//bool found = false;

			//for (int i = 0; i < parcels.GetLength(0); i++)
			//{
			//	if (parcels[i, 0] == inputTrackingNumber)
			//	{
			//		Console.WriteLine($"Tracking Number: {parcels[i, 0]}");
			//		Console.WriteLine($"Status: Parcel {parcels[i, 1]}");
			//		found = true;
			//		break;
			//	}
			//}

			//if (!found)
			//{
			//	Console.WriteLine("Tracking number not found");
			//}
			//         Console.ReadLine();
			#endregion

			#region Task 10
			//int choice = 1;
			//while (choice == 1)
			//{
			//	Console.WriteLine("Menu:\n1. Name\n2. Address\n3. phone\nEnter your choice:");
			//	int detail = int.Parse(Console.ReadLine());

			//	Console.WriteLine("Enter the data to validate:");
			//	string data = Console.ReadLine();

			//	bool isValid = false;

			//	switch (detail)
			//	{
			//		case 1:
			//			isValid = ValidateName(data);
			//			break;
			//		case 2:
			//			isValid = ValidateAddress(data);
			//			break;
			//		case 3:
			//			isValid = ValidatePhone(data);
			//			break;
			//		default:
			//			Console.WriteLine("Invalid detail type.");
			//			break;
			//	}

			//	if (isValid)
			//	{
			//		Console.WriteLine($"{detail} is valid.");
			//	}
			//	else
			//	{
			//		Console.WriteLine($"{detail} is invalid.");
			//	}
			//	Console.WriteLine("Press 1 to continue again or 0 to exit");
			//	choice = int.Parse(Console.ReadLine());
			//}
			#endregion

			#region Task 11
			//int choice = 1;
			//while (choice != 0)
			//{
			//	Console.WriteLine("Street:");
			//	string street = Console.ReadLine();

			//	Console.WriteLine("City:");
			//	string city = Console.ReadLine();

			//	Console.WriteLine("State:");
			//	string state = Console.ReadLine();

			//	Console.WriteLine("Zip code:");
			//	int zipCode = int.Parse(Console.ReadLine());

			//	try
			//	{
			//		Console.WriteLine($"Formatted Address: {FormatAddress(street, city, state, zipCode)}");
			//	}
			//	catch (ArgumentException ex)
			//	{
			//		Console.WriteLine($"Error: {ex.Message}");
			//	}
			//	Console.WriteLine("Enter 1 to continue or 0 to exit");
			//	choice = int.Parse(Console.ReadLine());
			//}
			#endregion

			#region Task 12
			//int choice = 1;
			//while (choice != 0)
			//{
			//	Console.WriteLine("Customer name:");
			//	string customerName = Console.ReadLine();
			//	Console.WriteLine("Order ID:");
			//	string orderNumber = Console.ReadLine();
			//	Console.WriteLine("Delivery address:");
			//	string deliveryAddress = Console.ReadLine();
			//	DateTime expectedDeliveryDate = DateTime.Now.AddDays(5);

			//	string emailContent = GenerateOrderConfirmationEmail(customerName, orderNumber, deliveryAddress, expectedDeliveryDate);

			//	Console.WriteLine(emailContent);

			//	Console.WriteLine("\nEnter 1 to continue or 0 to exit");
			//	choice = int.Parse(Console.ReadLine());
			//}
			#endregion

			#region Task 13
			//int choice = 1;
			//do
			//{
			//	Console.WriteLine("Enter source address:");
			//	string sourceAddress = Console.ReadLine();
			//	Console.WriteLine("Enter destination address:");
			//	string destinationAddress = Console.ReadLine();
			//	Console.WriteLine("Enter parcel weight:");
			//	double parcelWeight = double.Parse(Console.ReadLine());

			//	double shippingCost = CalculateShippingCost(sourceAddress, destinationAddress, parcelWeight);
			//	Console.WriteLine($"Shipping Cost: ${shippingCost}");

			//	Console.WriteLine("Enter 1 to continue or 0 to exit");
			//	choice = int.Parse(Console.ReadLine());
			//} while (choice != 0);
			#endregion

			#region Task 14
			//while (true)
			//{
			//	Console.WriteLine("Enter password:");
			//	string password = Console.ReadLine();
			//	bool isValid = ValidatePassword(password);
			//	if (isValid)
			//		Console.WriteLine("Valid password ");
			//	else
			//		Console.WriteLine("Invalid password ");
			//	Console.WriteLine("Enter 1 to continue or 0 to exit");
			//	int choice = int.Parse(Console.ReadLine());
			//	if (choice == 0) break;
			//}
			#endregion

			#region Task 15
			//List<string> addresses = new List<string>
			//{
			//	"123 Anna Salai, Salem",
			//	"123 anna salai, salem",
			//	"456 Gandhi Road, Coimbatore",
			//	"123 Anna Street, Chennai",
			//	"789 MGR Nagar, Erode",
			//	"123 Anna Salai, Salem"
			//};

			//Console.WriteLine("Finding similar addresses in Tamil Nadu...");
			//FindSimilarAddresses(addresses);
			//Console.ReadLine();
			#endregion
		}

		#region Task 10 required methods
		public static bool ValidateName(string name)
		{
			if (string.IsNullOrWhiteSpace(name))
				return false;

			foreach (char c in name)
			{
				if (!char.IsLetter(c) && c != ' ')
					return false;
			}

			string[] words = name.Split(' ');
			foreach (string word in words)
			{
				if (string.IsNullOrEmpty(word) || !char.IsUpper(word[0]))
					return false;
			}

			return true;
		}

		public static bool ValidateAddress(string address)
		{
			if (string.IsNullOrWhiteSpace(address))
				return false;

			foreach (char c in address)
			{
				if (char.IsSymbol(c) || char.IsPunctuation(c))
					return false;
			}

			return true;
		}

		public static bool ValidatePhone(string phone)
		{
			if (phone.Length != 10)
				return false;

			foreach (char c in phone)
			{
				if (!char.IsDigit(c))
					return false;
			}

			return true;
		}
		#endregion

		#region Task 11 required methods
		public static string FormatAddress(string street, string city, string state, int zipCode)
		{
			string formattedStreet = CapitalizeEachWord(street);
			string formattedCity = CapitalizeEachWord(city);
			string formattedState = CapitalizeEachWord(state);

			if (zipCode.ToString().Length == 6)
			{
				return $"{formattedStreet}, {formattedCity}, {formattedState}, {zipCode}";
			}
			else
			{
				throw new Exception("Invalid zip code. It must be exactly 6 digits.");
			}
		}

		private static string CapitalizeEachWord(string input)
		{
			string[] words = input.Split(' ');
			for (int i = 0; i < words.Length; i++)
			{
				if (words[i].Length > 0)
				{
					words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
				}
			}
			return string.Join(" ", words);
		}
		#endregion

		#region Task 12 required methods
		public static string GenerateOrderConfirmationEmail(string customerName, string orderNumber, string deliveryAddress, DateTime deliveryDate)
		{
			string email = $@"

Order Confirmation Email
----------------------------
Dear {customerName},

Thank you for your order!

Order Details:
- Order Number: {orderNumber}
- Delivery Address: {deliveryAddress}
- Expected Delivery Date: {deliveryDate:dddd, MMMM dd, yyyy}

We appreciate your business and hope you enjoy your purchase. If you have any questions or need further assistance, please do not hesitate to contact us.

Best regards,
Shippify";

			return email;
		}
		#endregion

		#region Task 13 required methods
		public static double CalculateShippingCost(string source, string destination, double weight)
		{
			double distance = DistanceCalculation(source, destination);
			const double costPerKilometer = 0.5;
			const double costPerKilogram = 2.0;
			double shippingCost = (distance * costPerKilometer) + (weight * costPerKilogram);
			return shippingCost;
		}

		private static double DistanceCalculation(string source, string destination)
		{
			if (source.Contains("Salem") && destination.Contains("Coimbatore"))
			{
				return 215;
			}
			else if (source.Contains("Salem") && destination.Contains("Ooty"))
			{
				return 1260;
			}
			else
			{
				return 500;
			}
		}
		#endregion

		#region Task 14 required methods
		public static bool ValidatePassword(string password)
		{
			if (password.Length < 8)
			{
				Console.WriteLine("Password must have at least 8 characters.");
				return false;
			}

			string specialChars = "!@#$%^&*()-_=+[]{}|;:,.<>?";

			bool hasUpperCase = false;
			bool hasLowerCase = false;
			bool hasDigit = false;
			bool hasSpecialChar = false;

			foreach (char ch in password)
			{
				if (char.IsUpper(ch))
					hasUpperCase = true;
				else if (char.IsLower(ch))
					hasLowerCase = true;
				else if (char.IsDigit(ch))
					hasDigit = true;
				else if (specialChars.Contains(ch))
					hasSpecialChar = true;

				if (hasUpperCase && hasLowerCase && hasDigit && hasSpecialChar)
					break;
			}

			if (!hasUpperCase)
				Console.WriteLine("Password must include at least one uppercase letter");
			if (!hasLowerCase)
				Console.WriteLine("Password must include at least one lowercase letter");
			if (!hasDigit)
				Console.WriteLine("Password must include at least one number");
			if (!hasSpecialChar)
				Console.WriteLine("Password must include at least one special character");

			return hasUpperCase && hasLowerCase && hasDigit && hasSpecialChar;
		}

		#endregion

		#region Task 15 required methods
		public static void FindSimilarAddresses(List<string> addresses)
		{
			for (int i = 0; i < addresses.Count; i++)
			{
				for (int j = i + 1; j < addresses.Count; j++)
				{
					if (addresses[i].ToLower() == addresses[j].ToLower())
					{
						Console.WriteLine($"\nDuplicate Addresses Found:\n- {addresses[i]}\n- {addresses[j]}");
					}
				}
			}
		}
		#endregion
	}
}
