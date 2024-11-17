namespace CodingTask3
{
	public class CourierAvailability
	{
		public string name { get; set; }
		public double distanceToOrder { get; set; }
		public bool isAvailable { get; set; }
		public CourierAvailability(string userName, double distance, bool availability)
		{
			name = userName;
			distanceToOrder = distance;
			isAvailable = availability;
		}
	}
}