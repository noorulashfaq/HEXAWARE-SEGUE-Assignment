using System;

public class Courier
{
	//courierID , senderName , senderAddress , receiverName , receiverAddress , weight ,
	//status, trackingNumber , deliveryDate ,userId

	private long courierId;
	private int userId, trackingNumber, employeeId, serviceId;
	private string senderName, senderAddress, receiverName, receiverAddress, status;
	private string deliveryDate;
	private double weight;

    public long CourierId { get; set; }
	public int UserId {  get; set; }
	public string SenderName { get; set; }
	public string SenderAddress { get; set; }
	public string ReceiverName { get; set; }
	public string ReceicerAddress { get; set; }
	public string Status { get; set; }
	public int TrackingNumber { get; set; }
	public string DeliveryDate { get; set; }
	public double Weight { get; set; }
	public int EmployeeId { get; set; }
	public int ServiceId { get; set; }

	//public Courier()
	//{
	//}

	public Courier(long courierId, int userId, string senderName, string receiverName, string receiverAddress, string status, int trackingNumber, int employeeId, int serviceId)
	{
		CourierId = courierId;
		UserId = userId;
		SenderName = senderName;
		SenderAddress = senderAddress;
		ReceiverName = receiverName;
		ReceicerAddress = receiverAddress;
		Status = status;
		TrackingNumber = trackingNumber;
		DeliveryDate = deliveryDate;
		Weight = weight;
		EmployeeId = employeeId;
		ServiceId = serviceId;
	}

	public override string ToString()
	{
		return $"Courier ID: {CourierId}\t" +
			$"User ID: {UserId}\t" +
			$"Sender name: {SenderName}\t" +
			$"Sender address: {SenderAddress}" +
			$"Receiver address: {ReceicerAddress}\t" +
			$"Status: {Status}\t" +
			$"Tracking number: {TrackingNumber}" +
			$"Delivery date: {DeliveryDate}\t" +
			$"Weight: {Weight}\t" +
			$"Employee ID: {EmployeeId}\t" +
			$"Service ID: {ServiceId}\n";
	}


}
