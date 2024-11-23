using System;

public class Courier
{
	//courierID , senderName , senderAddress , receiverName , receiverAddress , weight ,
	//status, trackingNumber , deliveryDate ,userId

	private long courierId;
	private int senderId, employeeId, serviceId;
	private string receiverName, receiverAddress, status, trackingNumber;
	private DateTime deliveryDate, orderedDate;
	private double weight;

    public long CourierId { get; set; }
	public int SenderId {  get; set; }
	public string ReceiverName { get; set; }
	public string ReceiverAddress { get; set; }
	public string Status { get; set; }
	public string TrackingNumber { get; set; }
	public DateTime DeliveryDate { get; set; }
	public DateTime OrderedDate { get; set; }
	public double Weight { get; set; }
	public int EmployeeId { get; set; }
	public int ServiceId { get; set; }

	public Courier()
	{
	}

	public Courier(long courierId, int userId, string senderName, string receiverName, string receiverAddress, string status, string trackingNumber, DateTime deliveryDate, DateTime orderedDate, int employeeId, int serviceId)
	{
		CourierId = courierId;
		SenderId = userId;
		ReceiverName = receiverName;
		ReceiverAddress = receiverAddress;
		Status = status;
		TrackingNumber = trackingNumber;
		DeliveryDate = deliveryDate;
		OrderedDate = orderedDate;
		Weight = weight;
		EmployeeId = employeeId;
		ServiceId = serviceId;
	}

	public override string ToString()
	{
		return $"Courier ID: {CourierId}\nUser ID: {SenderId}\nReceiver address: {ReceiverAddress}\nStatus: {Status}\nTracking number: {TrackingNumber}\nOrdered date: {OrderedDate}\nDelivery date: {DeliveryDate}\nWeight: {Weight}\nEmployee ID: {EmployeeId}\nService ID: {ServiceId}\n";
	}


}
